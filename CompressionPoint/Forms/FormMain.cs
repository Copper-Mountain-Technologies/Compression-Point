// Copyright ©2016-2017 Copper Mountain Technologies
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR
// ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using CopperMountainTech;
using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CompressionPoint
{
    public partial class FormMain : Form
    {
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private enum ComConnectionStateEnum
        {
            INITIALIZED,
            NOT_CONNECTED,
            CONNECTED_VNA_NOT_READY,
            CONNECTED_VNA_READY
        }

        private ComConnectionStateEnum previousComConnectionState = ComConnectionStateEnum.INITIALIZED;
        private ComConnectionStateEnum comConnectionState = ComConnectionStateEnum.NOT_CONNECTED;

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private int selectedChannel = -1;
        private int selectedTrace = -1;
        private int selectedSearchMarker = -1;

        // ------------------------------------------------------------------------------------------------------------

        private long previousSplitIndex = -1;
        private long previousNumOfTraces = -1;
        private long previousNumOfMarkers = -1;
        private const int maxNumOfMarkers = 15;

        private string[] previousSweepTypeArray;

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        public FormMain()
        {
            InitializeComponent();

            // --------------------------------------------------------------------------------------------------------

            // set form icon
            Icon = Properties.Resources.app_icon;

            // set form title
            Text = Program.programName;

            // disable resizing the window
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = true;

            // position the plug-in in the lower right corner of the screen
            Rectangle workingArea = Screen.GetWorkingArea(this);
            Location = new Point(workingArea.Right - Size.Width - 130,
                                 workingArea.Bottom - Size.Height - 50);

            // always display on top
            TopMost = true;

            // --------------------------------------------------------------------------------------------------------

            // disable ui
            panelMain.Enabled = false;

            // set version label text
            toolStripStatusLabelVersion.Text = "v" + Assembly.GetExecutingAssembly().GetName().Version.ToString(3);

            // init ui
            buttonS21.Enabled = false;
            buttonAddMarker.Enabled = false;
            buttonRemoveMarker.Enabled = false;
            checkBoxSearchLoop.Checked = false;
            groupBoxSearchForCompressionPoint.Enabled = false;
            labelCompressionPointValue.Text = "--.-------";
            groupBoxCompressionPointValue.Enabled = false;

            // --------------------------------------------------------------------------------------------------------

            // init previous sweep type array
            previousSweepTypeArray = new string[Program.vna.maxNumberOfChannels];

            // --------------------------------------------------------------------------------------------------------

            // start the ready timer
            timerReady.Interval = 250; // 250 ms interval
            timerReady.Enabled = true;
            timerReady.Start();

            // start the update timer
            timerUpdate.Interval = 250; // 250 ms interval
            timerUpdate.Enabled = true;
            timerUpdate.Start();

            // init the search loop timer
            timerSearchLoop.Interval = 1000; // 1 s interval
            timerSearchLoop.Enabled = true;

            // --------------------------------------------------------------------------------------------------------
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //
        // Timers
        //
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void timerReady_Tick(object sender, EventArgs e)
        {
            try
            {
                // is vna ready?
                if (Program.vna.app.Ready)
                {
                    // yes... vna is ready
                    comConnectionState = ComConnectionStateEnum.CONNECTED_VNA_READY;
                }
                else
                {
                    // no... vna is not ready
                    comConnectionState = ComConnectionStateEnum.CONNECTED_VNA_NOT_READY;
                }
            }
            catch (COMException)
            {
                // com connection has been lost
                comConnectionState = ComConnectionStateEnum.NOT_CONNECTED;
                Application.Exit();
                return;
            }

            if (comConnectionState != previousComConnectionState)
            {
                previousComConnectionState = comConnectionState;

                switch (comConnectionState)
                {
                    default:
                    case ComConnectionStateEnum.NOT_CONNECTED:

                        // update vna info text box
                        toolStripStatusLabelVnaInfo.ForeColor = Color.White;
                        toolStripStatusLabelVnaInfo.BackColor = Color.Red;
                        toolStripStatusLabelSpacer.BackColor = toolStripStatusLabelVnaInfo.BackColor;
                        toolStripStatusLabelVnaInfo.Text = "VNA NOT CONNECTED";

                        // disable ui
                        panelMain.Enabled = false;

                        break;

                    case ComConnectionStateEnum.CONNECTED_VNA_NOT_READY:

                        // update vna info text box
                        toolStripStatusLabelVnaInfo.ForeColor = Color.White;
                        toolStripStatusLabelVnaInfo.BackColor = Color.Red;
                        toolStripStatusLabelSpacer.BackColor = toolStripStatusLabelVnaInfo.BackColor;
                        toolStripStatusLabelVnaInfo.Text = "VNA NOT READY";

                        // disable ui
                        panelMain.Enabled = false;

                        break;

                    case ComConnectionStateEnum.CONNECTED_VNA_READY:

                        // get vna info
                        Program.vna.PopulateInfo(Program.vna.app.NAME);

                        // update vna info text box
                        toolStripStatusLabelVnaInfo.ForeColor = SystemColors.ControlText;
                        toolStripStatusLabelVnaInfo.BackColor = SystemColors.Control;
                        toolStripStatusLabelSpacer.BackColor = toolStripStatusLabelVnaInfo.BackColor;
                        toolStripStatusLabelVnaInfo.Text = Program.vna.modelString + "   " + "SN:" + Program.vna.serialNumberString + "   " + Program.vna.versionString;

                        // enable ui
                        panelMain.Enabled = true;

                        break;
                }
            }
        }

        // ============================================================================================================

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            if (comConnectionState == ComConnectionStateEnum.CONNECTED_VNA_READY)
            {
                // ----------------------------------------------------------------------------------------------------

                // get the split index (needed to determine number of channels)
                long splitIndex = 1;
                try
                {
                    splitIndex = Program.vna.app.SCPI.DISPlay.SPLit;
                }
                catch
                {
                }

                // update channel selection combo box
                if (splitIndex != previousSplitIndex)
                {
                    if (comboBoxChannel.DroppedDown == false)
                    {
                        // populate channel selection combo box
                        populateChannelComboBox(splitIndex);
                        previousSplitIndex = splitIndex;
                    }
                }

                // ----------------------------------------------------------------------------------------------------

                bool referenceMarkerState = false;
                long numOfMarkers = 0;
                string sweepType = "";
                bool isPowerSweep = false;

                if (selectedChannel != -1)
                {
                    try
                    {
                        // get number of traces for the selected channel
                        long numOfTraces = Program.vna.app.SCPI.CALCulate[selectedChannel].PARameter.COUNt;

                        // update trace selection combo box
                        if (numOfTraces != previousNumOfTraces)
                        {
                            if (comboBoxTrace.DroppedDown == false)
                            {
                                // populate trace selection combo box
                                populateTraceComboBox(numOfTraces);
                                previousNumOfTraces = numOfTraces;
                            }
                        }

                        // --------------------------------------------------------------------------------------------

                        // make the selected channel and trace active
                        object err = Program.vna.app.SCPI.CALCulate[selectedChannel].PARameter[selectedTrace].SELect;

                        // get selected channel's reference marker on/off state
                        referenceMarkerState = Program.vna.app.SCPI.CALCulate[selectedChannel].SELected.MARKer.REFerence.STATe;
                        checkBoxReferenceMarker.Checked = referenceMarkerState;

                        // get number of markers on selected channel and trace
                        numOfMarkers = Program.vna.app.SCPI.CALCulate[selectedChannel].SELected.MARKer.COUNt;

                        // get actual number of markers
                        numOfMarkers = getActualNumberOfMarkers(Program.vna.family, numOfMarkers, referenceMarkerState);

                        // are there any markers?
                        if (numOfMarkers < 1)
                        {
                            // no... init selected search marker
                            selectedSearchMarker = -1;
                        }

                        // get selected channel's sweep type
                        sweepType = Program.vna.app.SCPI.SENSe[selectedChannel].SWEep.TYPE;

                        // check for power sweep
                        if (sweepType.Contains("POW"))
                        {
                            isPowerSweep = true;
                        }
                        else
                        {
                            isPowerSweep = false;
                        }
                        checkBoxPowerSweep.Checked = isPowerSweep;

                        // get selected trace's measurement parameter
                        string traceMeasurementParameter = Program.vna.app.SCPI.CALCulate[selectedChannel].PARameter[selectedTrace].DEFine;

                        // check for S21
                        if (traceMeasurementParameter.Equals("S21"))
                        {
                            buttonS21.Enabled = false;
                        }
                        else
                        {
                            buttonS21.Enabled = true;
                        }
                    }
                    catch
                    {
                    }
                }

                // ----------------------------------------------------------------------------------------------------

                // update search marker selection combo box
                if (numOfMarkers != previousNumOfMarkers)
                {
                    if (comboBoxSearchMarker.DroppedDown == false)
                    {
                        // populate search marker selection combo box
                        populateSearchMarkerComboBox(numOfMarkers);
                        previousNumOfMarkers = numOfMarkers;
                    }
                }

                // ----------------------------------------------------------------------------------------------------

                // update add marker button enabled state
                if ((selectedChannel != -1) &&
                    (selectedTrace != -1) &&
                    (numOfMarkers < maxNumOfMarkers))
                {
                    buttonAddMarker.Enabled = true;
                }
                else
                {
                    buttonAddMarker.Enabled = false;
                }

                // update remove marker button enabled state
                if ((selectedChannel != -1) &&
                    (selectedTrace != -1) &&
                    (numOfMarkers > 0))
                {
                    buttonRemoveMarker.Enabled = true;
                }
                else
                {
                    buttonRemoveMarker.Enabled = false;
                }

                // update search button enabled state
                if ((selectedChannel != -1) &&
                   (selectedTrace != -1) &&
                   (referenceMarkerState == true) &&
                   (selectedSearchMarker != -1) &&
                   (isPowerSweep == true))
                {
                    groupBoxSearchForCompressionPoint.Enabled = true;
                }
                else
                {
                    checkBoxSearchLoop.Checked = false;
                    groupBoxSearchForCompressionPoint.Enabled = false;
                    groupBoxCompressionPointValue.Enabled = false;
                }

                // ----------------------------------------------------------------------------------------------------
            }
        }

        // ============================================================================================================

        private void timerSearchLoop_Tick(object sender, EventArgs e)
        {
            if (checkBoxSearchLoop.Checked == true)
            {
                try
                {
                    search();
                }
                catch
                {
                }
            }
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //
        // Select and Configure the Channel
        //
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void populateChannelComboBox(long splitIndex)
        {
            // prevent combo box from flickering when update occurs
            comboBoxChannel.BeginUpdate();

            // clear channel selection combo box
            comboBoxChannel.Items.Clear();

            int numOfChannels = 0;
            try
            {
                // determine number of channels from the split index
                numOfChannels = Program.vna.DetermineNumberOfChannels(splitIndex);

                // populate the channel number combo box
                for (int ch = 1; ch < numOfChannels + 1; ch++)
                {
                    comboBoxChannel.Items.Add(ch.ToString());
                }

                try
                {
                    // determine the active channel
                    long activeChannel = Program.vna.app.SCPI.SERVice.CHANnel.ACTive;

                    // init channel selection to the active channel
                    comboBoxChannel.SelectedIndex = (int)(activeChannel - 1);
                }
                catch
                {
                }
            }
            catch
            {
            }

            // prevent combo box from flickering when update occurs
            comboBoxChannel.EndUpdate();
        }

        // ------------------------------------------------------------------------------------------------------------

        private void comboBoxChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            // has channel selection changed?
            if (selectedChannel != comboBoxChannel.SelectedIndex + 1)
            {
                // yes...

                // update selected channel
                selectedChannel = comboBoxChannel.SelectedIndex + 1;

                // note: init this so trace selection combo box will get updated
                previousNumOfTraces = -1;
            }
        }

        // ------------------------------------------------------------------------------------------------------------

        private void checkBoxPowerSweep_MouseUp(object sender, MouseEventArgs e)
        {
            if (checkBoxPowerSweep.Checked == true)
            {
                // save current sweep type
                string sweepType = Program.vna.app.SCPI.SENSe[selectedChannel].SWEep.TYPE;
                if (!sweepType.Contains("POW"))
                {
                    previousSweepTypeArray[selectedChannel - 1] = sweepType;
                }

                // set channel sweep type to power sweep
                Program.vna.app.SCPI.SENSe[selectedChannel].SWEep.TYPE = "POWer";
            }
            else
            {
                // set channel sweep type to previous type
                if (!String.IsNullOrEmpty(previousSweepTypeArray[selectedChannel - 1]))
                {
                    Program.vna.app.SCPI.SENSe[selectedChannel].SWEep.TYPE = previousSweepTypeArray[selectedChannel - 1];
                }
            }
        }

        // ------------------------------------------------------------------------------------------------------------

        private void buttonS21_Click(object sender, EventArgs e)
        {
            try
            {
                // set selected trace to s21
                Program.vna.app.SCPI.CALCulate[selectedChannel].PARameter[selectedTrace].DEFine = "S21";
            }
            catch (COMException ex)
            {
                // display error message
                showMessageBoxForComException(ex);
            }
        }

        // ------------------------------------------------------------------------------------------------------------

        private void checkBoxReferenceMarker_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxReferenceMarker.Checked == true)
            {
                // make the selected channel and trace active
                object err = Program.vna.app.SCPI.CALCulate[selectedChannel].PARameter[selectedTrace].SELect;

                // turn reference marker on
                Program.vna.app.SCPI.CALCulate[selectedChannel].SELected.MARKer.REFerence.STATe = true;
            }
            else
            {
                // make the selected channel and trace active
                object err = Program.vna.app.SCPI.CALCulate[selectedChannel].PARameter[selectedTrace].SELect;

                // turn reference marker off
                Program.vna.app.SCPI.CALCulate[selectedChannel].SELected.MARKer.REFerence.STATe = false;
            }
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //
        // Select the Trace
        //
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void populateTraceComboBox(long numOfTraces)
        {
            // prevent combo box from flickering when update occurs
            comboBoxTrace.BeginUpdate();

            // clear trace selection combo box
            comboBoxTrace.Items.Clear();

            if (numOfTraces > 0)
            {
                // loop thru all traces on the selected channel
                for (int trace = 1; trace < numOfTraces + 1; trace++)
                {
                    // populate trace selection combo box
                    comboBoxTrace.Items.Add(trace.ToString());
                }

                try
                {
                    // determine the active trace for the selected channel
                    long activeTrace = Program.vna.app.SCPI.SERVice.CHANnel[selectedChannel].TRACe.ACTive;

                    // init trace selection to the active trace
                    comboBoxTrace.SelectedIndex = (int)(activeTrace - 1);
                }
                catch
                {
                }
            }

            // prevent combo box from flickering when update occurs
            comboBoxTrace.EndUpdate();
        }

        // ------------------------------------------------------------------------------------------------------------

        private void comboBoxTrace_SelectedIndexChanged(object sender, EventArgs e)
        {
            // has channel or trace selection changed?
            if (selectedTrace != comboBoxTrace.SelectedIndex + 1)
            {
                // yes...

                // update selected trace
                selectedTrace = comboBoxTrace.SelectedIndex + 1;

                // note: init this so search marker selection combo box will get updated
                previousNumOfMarkers = -1;
            }
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //
        // Move the Reference Marker (R) to a Linear Region of the Trace
        //
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //
        // Add and Select a Search Marker
        //
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void populateSearchMarkerComboBox(long numOfMarkers)
        {
            // prevent combo box from flickering when update occurs
            comboBoxSearchMarker.BeginUpdate();

            // clear search marker selection combo box
            comboBoxSearchMarker.Items.Clear();

            if ((selectedChannel != -1) && (selectedTrace != -1))
            {
                // populate the search marker combo box
                for (int marker = 0; marker < numOfMarkers; marker++)
                {
                    comboBoxSearchMarker.Items.Add((marker + 1).ToString());
                }
            }

            long activeMarker = 0;
            try
            {
                // determine the active marker for the selected channel and trace
                activeMarker = Program.vna.app.SCPI.SERVice.CHANnel[selectedChannel].TRACe[selectedTrace].MARKer.ACTive;
            }
            catch
            {
                // note: this is a vna family that does not have command to determine the active marker...
                try
                {
                    // are there any markers?
                    if (comboBoxSearchMarker.Items.Count > 0)
                    {
                        // set the active marker to the last marker (that's all we can do)
                        activeMarker = comboBoxSearchMarker.Items.Count;

                        // make this marker active
                        object err = Program.vna.app.SCPI.CALCulate[selectedChannel].SELected.MARKer[activeMarker].ACTivate;
                    }
                }
                catch
                {
                }
            }

            // init trace selection to the active trace
            if ((int)activeMarker <= comboBoxSearchMarker.Items.Count)
            {
                comboBoxSearchMarker.SelectedIndex = (int)(activeMarker - 1);
            }
            else
            {
                selectedSearchMarker = -1;
            }

            // prevent combo box from flickering when update occurs
            comboBoxSearchMarker.EndUpdate();
        }

        // ------------------------------------------------------------------------------------------------------------

        private void comboBoxSearchMarker_SelectedIndexChanged(object sender, EventArgs e)
        {
            // has search marker selection changed?
            if (selectedSearchMarker != comboBoxSearchMarker.SelectedIndex + 1)
            {
                // yes...

                // update selected search marker
                selectedSearchMarker = comboBoxSearchMarker.SelectedIndex + 1;

                // make the selected channel and trace active
                object err = Program.vna.app.SCPI.CALCulate[selectedChannel].PARameter[selectedTrace].SELect;

                // make the selected search marker active
                err = Program.vna.app.SCPI.CALCulate[selectedChannel].SELected.MARKer[selectedSearchMarker].ACTivate;
            }
        }

        // ------------------------------------------------------------------------------------------------------------

        private void buttonAddMarker_Click(object sender, EventArgs e)
        {
            if ((selectedChannel != -1) && (selectedTrace != -1))
            {
                try
                {
                    // make the selected channel and trace active
                    object err = Program.vna.app.SCPI.CALCulate[selectedChannel].PARameter[selectedTrace].SELect;

                    // get selected channel's reference marker on/off state
                    bool referenceMarkerState = Program.vna.app.SCPI.CALCulate[selectedChannel].SELected.MARKer.REFerence.STATe;

                    // get number of markers on selected channel and trace
                    long numOfMarkers = Program.vna.app.SCPI.CALCulate[selectedChannel].SELected.MARKer.COUNt;

                    // get actual number of markers
                    numOfMarkers = getActualNumberOfMarkers(Program.vna.family, (int)numOfMarkers, referenceMarkerState);

                    if (numOfMarkers < maxNumOfMarkers)
                    {
                        // calculate next marker number
                        long nextMarker = numOfMarkers + 1;

                        // turn on next marker
                        err = Program.vna.app.SCPI.CALCulate[selectedChannel].SELected.MARKer[nextMarker].ACTivate;
                    }
                }
                catch (COMException ex)
                {
                    // display error message
                    showMessageBoxForComException(ex);
                }
            }
        }

        private void buttonRemoveMarker_Click(object sender, EventArgs e)
        {
            if ((selectedChannel != -1) && (selectedTrace != -1))
            {
                try
                {
                    // make the selected channel and trace active
                    object err = Program.vna.app.SCPI.CALCulate[selectedChannel].PARameter[selectedTrace].SELect;

                    // get selected channel's reference marker on/off state
                    bool referenceMarkerState = Program.vna.app.SCPI.CALCulate[selectedChannel].SELected.MARKer.REFerence.STATe;

                    // get number of markers on selected channel and trace
                    long numOfMarkers = Program.vna.app.SCPI.CALCulate[selectedChannel].SELected.MARKer.COUNt;

                    // get actual number of markers
                    numOfMarkers = getActualNumberOfMarkers(Program.vna.family, numOfMarkers, referenceMarkerState);

                    if (numOfMarkers > 0)
                    {
                        // turn marker off
                        Program.vna.app.SCPI.CALCulate[selectedChannel].SELected.MARKer[numOfMarkers].STATe = false;
                    }
                }
                catch (COMException ex)
                {
                    // display error message
                    showMessageBoxForComException(ex);
                }
            }
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //
        // Search for 1 dB the Compression Point
        //
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                search();
            }
            catch (COMException ex)
            {
                // display error message
                showMessageBoxForComException(ex);
            }
        }

        // ------------------------------------------------------------------------------------------------------------

        private void checkBoxSearchLoop_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSearchLoop.Checked == true)
            {
                timerSearchLoop.Start();
            }
            else
            {
                timerSearchLoop.Stop();
            }
        }

        // ------------------------------------------------------------------------------------------------------------

        private void search()
        {
            if ((selectedChannel != -1) && (selectedTrace != -1) && (selectedSearchMarker != -1))
            {
                try
                {
                    // make the selected channel and trace active
                    object err = Program.vna.app.SCPI.CALCulate[selectedChannel].PARameter[selectedTrace].SELect;

                    // make the selected search marker active
                    err = Program.vna.app.SCPI.CALCulate[selectedChannel].SELected.MARKer[selectedSearchMarker].ACTivate;

                    // ------------------------------------------------------------------------------------------------

                    // note: delta marker bug in tr family before version 17.2.2 gets/sets absolute instead of delta values
                    bool isAbsoluteValues = false;
                    if (Program.vna.family == VnaFamilyEnum.TR)
                    {
                        string currentVersionString = Program.vna.versionString.Replace("v", "");
                        string versionToCompareAgainstString = "17.2.2";
                        if (isOlderVersion(currentVersionString, versionToCompareAgainstString))
                        {
                            isAbsoluteValues = true;
                        }
                    }

                    // ------------------------------------------------------------------------------------------------

                    // move search marker to same stimulus value as reference marker
                    double delta = 0;
                    if (isAbsoluteValues == true)
                    {
                        delta = Program.vna.app.SCPI.CALCulate[selectedChannel].SELected.MARKer[16].X;
                    }
                    Program.vna.app.SCPI.CALCulate[selectedChannel].SELected.MARKer[selectedSearchMarker].X = delta;

                    // get reference marker response value
                    double[] searchMarkerResponseData = Program.vna.app.SCPI.CALCulate[selectedChannel].SELected.MARKer[16].Y;

                    // set marker search target value to reference marker response value minus 1.0 dB
                    double targetValue = (searchMarkerResponseData[0] - 1.0);
                    Program.vna.app.SCPI.CALCulate[selectedChannel].SELected.MARKer[selectedSearchMarker].FUNCtion.TARGet = targetValue;

                    // ------------------------------------------------------------------------------------------------

                    // target search to the right from the marker to find compression point
                    Program.vna.app.SCPI.CALCulate[selectedChannel].SELected.MARKer[selectedSearchMarker].FUNCtion.TYPE = "RTARget";
                    err = Program.vna.app.SCPI.CALCulate[selectedChannel].SELected.MARKer[selectedSearchMarker].FUNCtion.EXECute;

                    // ------------------------------------------------------------------------------------------------

                    // get search marker stimulus value
                    double searchMarkerStimulusData = Program.vna.app.SCPI.CALCulate[selectedChannel].SELected.MARKer[selectedSearchMarker].X;

                    double compressionValue = searchMarkerStimulusData;
                    if (isAbsoluteValues == false)
                    {
                        // get reference marker stimulus value
                        double referenceMarkerStimulusData = Program.vna.app.SCPI.CALCulate[selectedChannel].SELected.MARKer[16].X;

                        // calculate 1db compression value
                        compressionValue = referenceMarkerStimulusData + searchMarkerStimulusData;
                    }

                    // display 1db compression value
                    labelCompressionPointValue.Text = compressionValue.ToString("N7");
                    groupBoxCompressionPointValue.Enabled = true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //
        // UTILITIES
        //
        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        private long getActualNumberOfMarkers(VnaFamilyEnum vnaFamily, long number, bool isReferenceMarkerOn)
        {
            if (vnaFamily != VnaFamilyEnum.TR)
            {
                // is reference marker on?
                if (isReferenceMarkerOn == true)
                {
                    // don't include the reference marker in the total number of markers
                    number = number - 1;
                    if (number < 0)
                    {
                        number = 0;
                    }
                }
            }

            return number;
        }

        // ------------------------------------------------------------------------------------------------------------

        private void showMessageBoxForComException(COMException e)
        {
            MessageBox.Show(Program.vna.GetUserMessageForComException(e),
                Program.programName,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ------------------------------------------------------------------------------------------------------------

        private bool isOlderVersion(string currentVersionString, string versionToCompareAgainstString)
        {
            var currentVersion = new Version(currentVersionString);
            var versionToCompareAgainst = new Version(versionToCompareAgainstString);

            var result = currentVersion.CompareTo(versionToCompareAgainst);
            if (result > 0)
            {
                // current version is greater
                return false;
            }
            else if (result < 0)
            {
                // version to compare against is greater
                return true;
            }
            else
            {
                // versions are equal
                return false;
            }
        }

        // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
    }
}