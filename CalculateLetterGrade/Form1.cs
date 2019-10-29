using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculateLetterGrade
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                decimal numberGrade = Convert.ToDecimal(txtNumber.Text);

                string letterGrade = Calculate(numberGrade);

                DisplayAnswer(letterGrade);
            }

            txtNumber.Focus();
        }

        /// <summary>
        /// Validates input for format and range
        /// </summary>
        /// <returns></returns>
        public bool ValidateInput()
        {
            try
            {
                decimal numberGrade = Convert.ToDecimal(txtNumber.Text);
                if (numberGrade > 120 || numberGrade < 0)
                {
                    MessageBox.Show("Grade must be between 0 and 120");
                    txtNumber.Clear();
                    return false;
                }
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Must enter a number");
                txtNumber.Clear();
                return false;
            }
        }

        /// <summary>
        /// Takes a number grade and returns the corresponding letter grade
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        private string Calculate(decimal grade)
        {
            if (grade >= 100)
            {
                return "A+";
            }
            else if (grade >= 90)
            {
                return "A";
            }
            else if (grade >= 80)
            {
                return "B";
            }
            else if (grade >= 70)
            {
                return "C";
            }
            else if (grade >= 60)
            {
                return "D";
            }
            else
            {
                return "F";
            }
        }

        /// <summary>
        /// Displays the letter grade in the Result label
        /// </summary>
        /// <param name="grade"></param>
        private void DisplayAnswer(string grade)
        {
            lblResult.Text = grade;
        }

        /// <summary>
        /// Closes the form when Exit button is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
