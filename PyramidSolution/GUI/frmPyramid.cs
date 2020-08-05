using PyramidSolution.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PyramidSolution.GUI
{
    public partial class frmPyramid : Form
    {
        IPyramidLogic _PyramidLogic;
        public frmPyramid(IPyramidLogic PyramidLogic)
        {
            InitializeComponent();
            _PyramidLogic = PyramidLogic;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog objFileDialogue = new OpenFileDialog();
           

            if (objFileDialogue.ShowDialog() == DialogResult.OK)
            {
                txtSelectFile.Text = objFileDialogue.FileName;
            }
        }

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
            if (txtSelectFile.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Select file", "Select file", MessageBoxButtons.OK);
                return;
            }
            try
            {
                //EnableControls(false);
                //Application.DoEvents();
                var numbersToAdd = await _PyramidLogic.processPyramidData(txtSelectFile.Text);

                int sum = 0;
                foreach (int i in numbersToAdd)
                {
                    sum = sum + i;
                    txtResult.AppendText(i.ToString());
                    txtResult.AppendText(Environment.NewLine);
                }
                MessageBox.Show("Maximum Sum=: " + sum.ToString());
                if (!string.IsNullOrEmpty(sum.ToString())){
                    btnClear.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is some error happened." + ex.Message.ToString());
            }
            finally
            {
                //EnableControls(true);
            }
        }
        /// <summary>
        /// To clear the fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSelectFile.Clear();
            txtResult.Clear();
            btnClear.Enabled = false;
        }
    }
}
