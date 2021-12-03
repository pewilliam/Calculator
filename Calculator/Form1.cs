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
        double resultValue = 0;
        string operationPerformed = "";
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void NumericButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (txbResult.Text == "0" && button.Text == ".")
            {
                txbResult.Text += button.Text;
            }

            if (txbResult.Text == "0" || isOperationPerformed)
            {
                txbResult.Clear();
            }

            isOperationPerformed = false;
            
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
            resultValue = double.Parse(txbResult.Text, CultureInfo.InvariantCulture);
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
                    txbResult.Text = (resultValue + double.Parse(txbResult.Text, CultureInfo.InvariantCulture)).ToString("F1", CultureInfo.InvariantCulture);
                    break;
                case "-":
                    txbResult.Text = (resultValue - double.Parse(txbResult.Text, CultureInfo.InvariantCulture)).ToString("F1", CultureInfo.InvariantCulture);
                    break;
                case "*":
                    txbResult.Text = (resultValue * double.Parse(txbResult.Text, CultureInfo.InvariantCulture)).ToString("F1", CultureInfo.InvariantCulture);
                    break;
                case "/":
                    txbResult.Text = (resultValue / double.Parse(txbResult.Text, CultureInfo.InvariantCulture)).ToString("F1", CultureInfo.InvariantCulture);
                    break;
                default:
                    break;
            }

            resultValue = double.Parse(txbResult.Text, CultureInfo.InvariantCulture);
            currentOperationLabel.Text = "";
            isOperationPerformed = true;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case "0":
                    zero.PerformClick();
                    break;
                case "1":
                    one.PerformClick();
                    break;
                case "2":
                    two.PerformClick();
                    break;
                case "3":
                    three.PerformClick();
                    break;
                case "4":
                    four.PerformClick();
                    break;
                case "5":
                    five.PerformClick();
                    break;
                case "6":
                    six.PerformClick();
                    break;
                case "7":
                    seven.PerformClick();
                    break;
                case "8":
                    eight.PerformClick();
                    break;
                case "9":
                    nine.PerformClick();
                    break;
                case ".":
                    dotButton.PerformClick();
                    break;
                case ",":
                    dotButton.PerformClick();
                    break;
                case "+":
                    sum.PerformClick();
                    break;
                case "-":
                    subtraction.PerformClick();
                    break;
                case "*":
                    multiplication.PerformClick();
                    break;
                case "/":
                    division.PerformClick();
                    break;
                case "=":
                    equalsButton.PerformClick();
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                equalsButton.PerformClick();
            }
            if(e.KeyCode == Keys.Back)
            {
                clearEntryButton.PerformClick();
            }
            if(e.KeyCode == Keys.Delete)
            {
                clearEverythingButton.PerformClick();
                currentOperationLabel.Text = "";
            }
        }
    }
}
