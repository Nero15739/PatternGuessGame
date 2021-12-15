using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PatternGuessGame
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            buttons.Add(btnTL);
            buttons.Add(btnTM);
            buttons.Add(btnTR);
            buttons.Add(btnML);
            buttons.Add(btnMM);
            buttons.Add(btnMR);
            buttons.Add(btnBL);
            buttons.Add(btnBM);
            buttons.Add(btnBR);
            
        }
        //Global Variables
        List<Button> buttons = new List<Button>();
        int intLv = 1; //for number of consecutive clicks
        List<int> clickSequence = new List<int>();//list for the click order
        List<int> clickOrder = new List<int>();
        int clickCount = 0;

        private void createSequence()
        {
            clickSequence.Clear();
            Random rng = new Random();
            //repeats to the current lv
            for (int i = 0; i < intLv; i++)
            {   //creates a random click             
                
                clickSequence.Add(rng.Next(0, 8));
            }
            
        }

        private void EnableDisable(bool x)
        {
            foreach (var item in buttons)
            {
                item.Enabled = x;
            }
        }

        private void showSequence()
        {
            EnableDisable(false);
            foreach (var item in clickSequence)
            {                
                    buttons[item].BackColor = Color.Red;
                    Thread.Sleep(1000);
                buttons[item].BackColor = Color.White;          
                
            }
            EnableDisable(true);
        }

        private void Failed()
        {
            MessageBox.Show($"Ha Suffer\nCurrentLevel: {intLv}");
            intLv = 1;
            Application.Restart();
        }

        private void CheckSequence()
        {
            for (int i = 0; i < clickSequence.Count-1; i++)
            {
                if (clickSequence[i] != clickOrder[i])
                {
                    Failed();
                    return;
                }
            }
            intLv++;
            clickOrder.Clear();
            clickCount = 0;
            lblLvl.Text = $"{intLv}";
            createSequence();
            Thread t = new Thread(new ThreadStart(showSequence));
            t.Start();
        }

       //button clicks

        private void btnTL_Click(object sender, EventArgs e)
        {
            clickCount++;
            clickOrder.Add(0);
            if (clickCount == intLv)
            {
                CheckSequence();
            }
        }

        private void btnTM_Click(object sender, EventArgs e)
        {
            clickCount++;
            clickOrder.Add(1);
            if (clickCount == intLv)
            {
                CheckSequence();
            }
        }

        private void btnTR_Click(object sender, EventArgs e)
        {
            clickCount++;
            clickOrder.Add(2);
            if (clickCount == intLv)
            {
                CheckSequence();
            }
        }

        private void btnML_Click(object sender, EventArgs e)
        {
            clickCount++;
            clickOrder.Add(3);
            if (clickCount == intLv)
            {
                CheckSequence();
            }
        }

        private void btnMM_Click(object sender, EventArgs e)
        {
            clickCount++;
            clickOrder.Add(4);
            if (clickCount == intLv)
            {
                CheckSequence();
            }
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            clickCount++;
            clickOrder.Add(5);
            if (clickCount == intLv)
            {
                CheckSequence();
            }
        }

        private void btnBL_Click(object sender, EventArgs e)
        {
            clickCount++;
            clickOrder.Add(6);
            if (clickCount == intLv)
            {
                CheckSequence();
            }
        }

        private void btnBM_Click(object sender, EventArgs e)
        {
            clickCount++;
            clickOrder.Add(7);
            if (clickCount == intLv)
            {
                CheckSequence();
            }
        }

        private void btnBR_Click(object sender, EventArgs e)
        {
            clickCount++;
            clickOrder.Add(8);
            if (clickCount == intLv)
            {
                CheckSequence();
            }
        }
        

        //Start button click
        private void btnStart_Click(object sender, EventArgs e)
        {
            createSequence();
            Thread t = new Thread(new ThreadStart(showSequence));
            t.Start();
            
        }        
    }
}
