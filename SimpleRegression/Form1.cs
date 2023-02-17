using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleRegression
{
    public partial class Form1 : Form
    {
        double[] hours = { 2.5, 5.1, 3.2, 8.5, 3.5, 1.5, 9.2, 5.5, 8.3, 2.7, 7.7, 5.9, 4.5, 3.3, 1.1, 8.9, 2.5, 1.9, 6.1, 7.4, 2.7, 4.8, 3.8, 6.9, 7.8 };
        double[] grades = { 21, 47, 27, 75, 30, 20, 88, 60, 81, 25, 85, 62, 41, 42, 17, 95, 30, 24, 67, 69, 30, 54, 35, 76, 86 };
        double sumOfXY = 0;
        double sumOfY = 0;
        double sumOfX = 0;
        double sumOfXSquared = 0;
        double sumOfYSquared = 0;
        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Maximum = 9;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < hours.Length; i++)
            {
                // For the summation of Y (dependent)
                sumOfY += grades[i];

                // For the summation of X (independent)
                sumOfX += hours[i];

                //For the summation of XY
                double XY = hours[i] * grades[i];
                sumOfXY += XY;

                //For the summation of independent variable (hours) X raised to 2
                sumOfXSquared += Math.Pow(hours[i], 2);

                //For the summation of dependent variable (grades) Y raised to 2
                sumOfYSquared += Math.Pow(grades[i], 2);
            }

            
            int n = hours.Length;

            //Calculate for a
            double a = ((sumOfY * sumOfXSquared) - (sumOfX * sumOfXY)) / ((n * sumOfXSquared) - (Math.Pow(sumOfX, 2)));

            //Calculate for b
            double b = ((n * sumOfXY) - (sumOfX * sumOfY)) / ((n * sumOfXSquared) - (Math.Pow(sumOfX, 2)));

            double x = Convert.ToDouble(numericUpDown1.Value);
            double y = a + (b * x);

            if(y < 0) 
            { 
                y = 0;  
                label1.Text = y.ToString("0."); 
            }               
            else 
            { 
                label1.Text = y.ToString("0."); 
            }
            
        }
    }
}
