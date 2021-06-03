using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public static float SetValueForText1 = 0; // variable for Bill value
        public static int SetValueForText2 = 0; // variable for Tip % value
        public static int SetValueForText3 = 0; // variable for number of person value

        public static float tip = 0;              // tip
        public static float tipPerPerson = 0;     // tip per person
        public static float totPerPerson = 0;     // total per person
        public Form1()
        {
            InitializeComponent();
            
        }

        private void TipCalculator_Load(object sender, EventArgs e)
        {

        }

        private void calculate(object sender, EventArgs e)  //calculate button
        {
            textBox1.Text = Math.Round(float.Parse(textBox1.Text), 2).ToString();  // Rounding Bill to only 2 decimal places
            SetValueForText1 = float.Parse(textBox1.Text);


            SetValueForText2 = int.Parse(textBox2.Text); 

            SetValueForText3 = int.Parse(textBox3.Text);
            

            tip = SetValueForText1 * SetValueForText2 / 100;   // calculating tip

            tipPerPerson = tip / SetValueForText3;
            tipPerPerson = (float)Math.Round(tipPerPerson, 2);    // Calculating tip per person and rounding it to 2 decimal places

            totPerPerson = (SetValueForText1 + tip) / SetValueForText3;   // calculating total amount per person and rounding it to 2 decimal places
            totPerPerson = (float)Math.Round(totPerPerson, 2);

            textBox4.Text = "$" + (tipPerPerson.ToString());
            textBox5.Text = "$" + (totPerPerson.ToString());
        }

        private void tip_Incrementer(object sender, EventArgs e) // + button to increase 1 value in Tip
        {
            if (int.Parse(textBox2.Text) < 100)
            {
                textBox2.Text = (int.Parse(textBox2.Text) + 1).ToString();
            }
        }

        private void tip_Decrementer(object sender, EventArgs e) // - button to decrease 1 value in Tip
        {
            if (int.Parse(textBox2.Text) > 0)
            {
                textBox2.Text = (int.Parse(textBox2.Text) - 1).ToString();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)  // Bill textbox
       {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9.-]+"))  // To check if the number is floating point
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }

            float value;
            if (float.TryParse(textBox1.Text, out value))    // setting the max and min value of Bill
            {
                if (value > 100000)
                    textBox1.Text = "0.00";
                else if (value <0 )
                    textBox1.Text = "0.00";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)   // Tip %
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))  
            {
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }

            int value;
            if (int.TryParse(textBox2.Text, out value))
            {
                if (value > 100)
                    textBox2.Text = "100";
                else if (value < 0)
                    textBox2.Text = "0";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)   // Number of people
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9]"))
            {
                textBox3.Text = textBox2.Text.Remove(textBox3.Text.Length - 1);
            }

            int value;
            if (int.TryParse(textBox3.Text, out value))
            {
                if (value > 1000)
                    textBox3.Text = "1000";
                else if (value < 1)
                    textBox3.Text = "1";
            }
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }


        private void people_Incrementer(object sender, EventArgs e) // + button to increase 1 value in No of people
        {
            if (int.Parse(textBox3.Text) < 1000)
            {
                textBox3.Text = (int.Parse(textBox3.Text) + 1).ToString();
            }
        }

        private void people_Decrementer(object sender, EventArgs e)  // - button to decrease 1 value in No of people
        {
            if (int.Parse(textBox3.Text) > 1)
            {
                textBox3.Text = (int.Parse(textBox3.Text) - 1).ToString();
            }
            
        }

        

        private void reset(object sender, EventArgs e) // reset button
        {
            textBox1.Text = "0.00";
            textBox2.Text = "10";
            textBox3.Text = "1";
            textBox4.Text = "$0.00";
            textBox5.Text = "$0.00";
        }

    }
}
