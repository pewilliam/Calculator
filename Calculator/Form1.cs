using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void NumericButtonClick(object sender, EventArgs e)
        {
            if(txbResult.Text == "0" || isOperationPerformed)
            {
                txbResult.Clear();
            }

            isOperationPerformed = false;
            Button button = (Button)sender;
            
            if(button.Text == ".")
            {
                if (!txbResult.Text.Contains("."))
                {
                    txbResult.Text += button.Text;
                }
            }
            else
            {
                txbResult.Text += button.Text;
            }
        }

        private void OperatorButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            operationPerformed = button.Text;
            resultValue = double.Parse(txbResult.Text);
            isOperationPerformed = true;
            currentOperationLabel.Text = resultValue + " " + operationPerformed;
        }

        private void ClearEntry(object sender, EventArgs e)
        {
            txbResult.Text = "0";
        }

        private void ClearButton(object sender, EventArgs e)
        {
            txbResult.Text = "0";
            resultValue = 0;
        }

        private void ResultButton(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+": 
                    txbResult.Text = (resultValue + double.Parse(txbResult.Text)).ToString();
                    break;
                case "-":
                    txbResult.Text = (resultValue - double.Parse(txbResult.Text)).ToString();
                    break;
                case "*":
                    txbResult.Text = (resultValue * double.Parse(txbResult.Text)).ToString();
                    break;
                case "/":
                    txbResult.Text = (resultValue / double.Parse(txbResult.Text)).ToString();
                    break;
                default:
                    break;
            }

            resultValue = double.Parse(txbResult.Text);
            currentOperationLabel.Text = "";
        }
    }
}
