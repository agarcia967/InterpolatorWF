using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterpolatorWF
{
    public partial class Form1 : Form
    {
        private decimal interpolatedValue;
        private bool showDivZeroError;
        private string divZeroMessage = "DIV/0";

        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveValues();
        }

        private void init()
        {
            switch (Properties.Settings.Default.TabSelection)
            {
                case 0:
                    tabControl1.SelectedTab = tabSimple;
                    break;
                case 1:
                    tabControl1.SelectedTab = tabLinear;
                    break;
                case 2:
                    tabControl1.SelectedTab = tabBilinear;
                    break;
            }
            LoadValues();
        }

        private void LoadValues()
        {
            cboxShowDivZeroError.Checked = Properties.Settings.Default.ShowDivZeroError;
            numRatioX1.Value = Properties.Settings.Default.ValueSimpleX1;
            numRatioX2.Value = Properties.Settings.Default.ValueSimpleX2;
            numRatioY1.Value = Properties.Settings.Default.ValueSimpleY1;

            numLinearX1.Value = Properties.Settings.Default.ValueLinearX1;
            numLinearX2.Value = Properties.Settings.Default.ValueLinearX2;
            numLinearX3.Value = Properties.Settings.Default.ValueLinearX3;
            numLinearY1.Value = Properties.Settings.Default.ValueLinearY1;
            numLinearY3.Value = Properties.Settings.Default.ValueLinearY3;

            numBilinearX1.Value = Properties.Settings.Default.ValueBilinearX1;
            numBilinearX2.Value = Properties.Settings.Default.ValueBilinearX2;
            numBilinearX.Value = Properties.Settings.Default.ValueBilinearX;
            numBilinearY1.Value = Properties.Settings.Default.ValueBilinearY1;
            numBilinearY2.Value = Properties.Settings.Default.ValueBilinearY2;
            numBilinearY.Value = Properties.Settings.Default.ValueBilinearY;
            numBilinearQ11.Value = Properties.Settings.Default.ValueBilinearQ11;
            numBilinearQ12.Value = Properties.Settings.Default.ValueBilinearQ12;
            numBilinearQ21.Value = Properties.Settings.Default.ValueBilinearQ21;
            numBilinearQ22.Value = Properties.Settings.Default.ValueBilinearQ22;
        }

        private void SaveValues()
        {
            Properties.Settings.Default.ShowDivZeroError = cboxShowDivZeroError.Checked;

            Properties.Settings.Default.ValueSimpleX1 = numRatioX1.Value;
            Properties.Settings.Default.ValueSimpleX2 = numRatioX2.Value;
            Properties.Settings.Default.ValueSimpleY1 = numRatioY1.Value;

            Properties.Settings.Default.ValueLinearX1 = numLinearX1.Value;
            Properties.Settings.Default.ValueLinearX2 = numLinearX2.Value;
            Properties.Settings.Default.ValueLinearX3 = numLinearX3.Value;
            Properties.Settings.Default.ValueLinearY1 = numLinearY1.Value;
            Properties.Settings.Default.ValueLinearY3 = numLinearY3.Value;

            Properties.Settings.Default.ValueBilinearX1 = numBilinearX1.Value;
            Properties.Settings.Default.ValueBilinearX2 = numBilinearX2.Value;
            Properties.Settings.Default.ValueBilinearX = numBilinearX.Value;
            Properties.Settings.Default.ValueBilinearY1 = numBilinearY1.Value;
            Properties.Settings.Default.ValueBilinearY2 = numBilinearY2.Value;
            Properties.Settings.Default.ValueBilinearY = numBilinearY.Value;
            Properties.Settings.Default.ValueBilinearQ11 = numBilinearQ11.Value;
            Properties.Settings.Default.ValueBilinearQ12 = numBilinearQ12.Value;
            Properties.Settings.Default.ValueBilinearQ21 = numBilinearQ21.Value;
            Properties.Settings.Default.ValueBilinearQ22 = numBilinearQ22.Value;

            Properties.Settings.Default.Save();
        }

        private void simpleX1_ValueChanged(object sender, EventArgs e)
        {
            CalculateSimpleValue();
        }

        private void simpleY1_ValueChanged(object sender, EventArgs e)
        {
            CalculateSimpleValue();
        }

        private void simpleY2_ValueChanged(object sender, EventArgs e)
        {
            CalculateSimpleValue();
        }

        private void CalculateSimpleValue()
        {
            try
            {
                decimal calculatedValue = (numRatioX2.Value * numRatioY1.Value) / numRatioX1.Value;

                txtSimpleY2.Text = "" + calculatedValue;
            }
            catch (DivideByZeroException e)
            {
                if (showDivZeroError) txtSimpleY2.Text = divZeroMessage;
            }
        }

        private void linearX1_ValueChanged(object sender, EventArgs e)
        {
            CalculateLinearValue();
        }

        private void linearX2_ValueChanged(object sender, EventArgs e)
        {
            CalculateLinearValue();
        }

        private void linearX3_ValueChanged(object sender, EventArgs e)
        {
            CalculateLinearValue();
        }

        private void linearY1_ValueChanged(object sender, EventArgs e)
        {
            CalculateLinearValue();
        }

        private void linearY3_ValueChanged(object sender, EventArgs e)
        {
            CalculateLinearValue();
        }

        private void CalculateLinearValue()
        {
            decimal numerator, denominator;
            try
            {
                denominator = numLinearX3.Value - numLinearX1.Value;
                numerator = (numLinearX2.Value - numLinearX1.Value) * (numLinearY3.Value - numLinearY1.Value);
                interpolatedValue = (numerator / denominator) + numLinearY1.Value;

                txtLinearY2.Text = "" + interpolatedValue;
            }
            catch (DivideByZeroException e)
            {
                if (showDivZeroError) txtLinearY2.Text = divZeroMessage;
            }
        }

        private void bilinearX1_ValueChanged(object sender, EventArgs e)
        {
            CalculateBilinearValue();
        }

        private void bilinearX2_ValueChanged(object sender, EventArgs e)
        {
            CalculateBilinearValue();
        }

        private void bilinearY1_ValueChanged(object sender, EventArgs e)
        {
            CalculateBilinearValue();
        }

        private void bilinearY2_ValueChanged(object sender, EventArgs e)
        {
            CalculateBilinearValue();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            CalculateBilinearValue();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            CalculateBilinearValue();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            CalculateBilinearValue();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CalculateBilinearValue();
        }

        private void bilinearX_ValueChanged(object sender, EventArgs e)
        {
            CalculateBilinearValue();
        }

        private void bilinearY_ValueChanged(object sender, EventArgs e)
        {
            CalculateBilinearValue();
        }

        private void CalculateBilinearValue()
        {
            decimal numerator, denominator;
            interpolatedValue = 0;
            try
            {
                numerator = (numBilinearX2.Value - numBilinearX.Value) * (numBilinearY2.Value - numBilinearY.Value);
                denominator = (numBilinearX2.Value - numBilinearX1.Value) * (numBilinearY2.Value - numBilinearY1.Value);
                interpolatedValue = (numerator / denominator) * numBilinearQ11.Value;

                numerator = (numBilinearX.Value - numBilinearX1.Value) * (numBilinearY2.Value - numBilinearY.Value);
                denominator = (numBilinearX2.Value - numBilinearX1.Value) * (numBilinearY2.Value - numBilinearY1.Value);
                interpolatedValue += (numerator / denominator) * numBilinearQ21.Value;

                numerator = (numBilinearX2.Value - numBilinearX.Value) * (numBilinearY.Value - numBilinearY1.Value);
                denominator = (numBilinearX2.Value - numBilinearX1.Value) * (numBilinearY2.Value - numBilinearY1.Value);
                interpolatedValue += (numerator / denominator) * numBilinearQ12.Value;

                numerator = (numBilinearX.Value - numBilinearX1.Value) * (numBilinearY.Value - numBilinearY1.Value);
                denominator = (numBilinearX2.Value - numBilinearX1.Value) * (numBilinearY2.Value - numBilinearY1.Value);
                interpolatedValue += (numerator / denominator) * numBilinearQ22.Value;

                txtBilinearP.Text = "" + interpolatedValue;
            }
            catch (DivideByZeroException e)
            {
                if (showDivZeroError) txtBilinearP.Text = divZeroMessage;
            }
        }

        private void cboxClearAllValues_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxClearAllValues.Checked)
            {
                cboxClearBilinearValues.Checked = true;
                cboxClearLinearValues.Checked = true;
                cboxClearRatioValues.Checked = true;
            }
            else
            {
                cboxClearBilinearValues.Checked = false;
                cboxClearLinearValues.Checked = false;
                cboxClearRatioValues.Checked = false;
            }
        }

        private void UncheckAll()
        {
            if(cboxClearRatioValues.Checked &&
                cboxClearLinearValues.Checked &&
                cboxClearBilinearValues.Checked)
            {
                cboxClearAllValues.Checked = true;
            }
            else if (!cboxClearRatioValues.Checked &&
                !cboxClearLinearValues.Checked &&
                !cboxClearBilinearValues.Checked)
            {
                cboxClearAllValues.Checked = false;
            }
        }

        private void cboxClearRatioValues_CheckedChanged(object sender, EventArgs e)
        {
            UncheckAll();
        }

        private void cboxClearLinearValues_CheckedChanged(object sender, EventArgs e)
        {
            UncheckAll();
        }

        private void cboxClearBilinearValues_CheckedChanged(object sender, EventArgs e)
        {
            UncheckAll();
        }

        private void btnClearValues_Click(object sender, EventArgs e)
        {
            if (cboxClearRatioValues.Checked)
            {
                ClearValues(0);
            }
            else if (cboxClearLinearValues.Checked)
            {
                ClearValues(1);
            }
            else if (cboxClearBilinearValues.Checked)
            {
                ClearValues(2);
            }
        }

        private void ClearValues(int tab)
        {
            if (tab == 0)
            {
                numRatioX1.Value = 0;
                numRatioX2.Value = 0;
                numRatioY1.Value = 0;
            }
            else if (tab == 1)
            {
                numLinearX1.Value = 0;
                numLinearX2.Value = 0;
                numLinearX3.Value = 0;
                numLinearY1.Value = 0;
                numLinearY3.Value = 0;
            }
            else if (tab == 2)
            {
                numBilinearX1.Value = 0;
                numBilinearX2.Value = 0;
                numBilinearY1.Value = 0;
                numBilinearY2.Value = 0;
                numBilinearX.Value = 0;
                numBilinearY.Value = 0;
                numBilinearQ11.Value = 0;
                numBilinearQ12.Value = 0;
                numBilinearQ21.Value = 0;
                numBilinearQ22.Value = 0;
            }
        }

        private void cboxShowDivZeroError_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxShowDivZeroError.Checked) showDivZeroError = true;
            else showDivZeroError = false;
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex >= 0 && e.TabPageIndex <= 2)
            { 
                Properties.Settings.Default.TabSelection = e.TabPageIndex;
                Properties.Settings.Default.Save();
            }
        }
    }
}
