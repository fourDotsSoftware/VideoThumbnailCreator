using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace VideoThumbnailCreator
{
    public partial class TimeUpDownControl : UserControl
    {
        public string LastAcceptedValue = "";

        private TimeSpan _Time;
        public TimeSpan Time
        {
            set
            {
                _Time = value;
            }
            get
            {
                return _Time;
            }
        }        

        public string SecsString
        {
            get
            {
                decimal secs = (decimal)Time.TotalSeconds;
                decimal msecs = (decimal)Time.Milliseconds;
                decimal d = secs + msecs;

                return d.ToString().Replace(",", ".");
            }            
        }

        public double MSecs
        {
            get
            {
                return TextBoxTimeSpanValue.TotalMilliseconds;                
            }
        }


        public TimeUpDownControl()
        {
            InitializeComponent();
            Time = new TimeSpan(0, 0, 0, 0, 0);
            nUpDown.Maximum = (decimal)1000000000000000;
            nUpDown.Minimum = -(decimal)1000000000000000;
            nUpDown.Value = 0;
            OldValue = 0;

            txtBox.Focus();


        }
        
        public string Text
        {
            get
            {
                return txtBox.Text.Replace(",", ".");
            }
            set
            {
                txtBox.Text = value.Replace(",", ".");
                Time = TextBoxTimeSpanValue;
            }
        }               

        public string StringValue
        {
            get
            {
                return Time.Hours.ToString("D2") + ":" + Time.Minutes.ToString("D2") + ":" + Time.Seconds.ToString("D2") + "." + Time.Milliseconds.ToString("D3");
            }
        }

        public TimeSpan TextBoxTimeSpanValue
        {
            get
            {
                return new TimeSpan(0, int.Parse(txtBox.Text.Substring(0, 2)),
                    int.Parse(txtBox.Text.Substring(3, 2)),
                    int.Parse(txtBox.Text.Substring(6, 2)),
                    int.Parse(txtBox.Text.Substring(9, 3)));

            }
        }
        
        public static TimeSpan StringToTimeSpan(string str)
        {
            //00:00:15
            //01234567
            if (str.Length == 11)
            {
                return new TimeSpan(0, int.Parse(str.Substring(0, 2)),
                        int.Parse(str.Substring(3, 2)),
                        int.Parse(str.Substring(6, 2)),
                        int.Parse(str.Substring(9, 2))*10);
            }
            else if (str.Length == 8)
            {
                return new TimeSpan(0, int.Parse(str.Substring(0, 2)),
                        int.Parse(str.Substring(3, 2)),
                        int.Parse(str.Substring(6, 2)),
                        0);
            }
            else if (str.Length == 7)
            {
                return new TimeSpan(0, int.Parse(str.Substring(0, 1)),
                        int.Parse(str.Substring(2, 2)),
                        int.Parse(str.Substring(5, 2)),
                        0);
            }
            else
            {
                return new TimeSpan(0, int.Parse(str.Substring(0, 2)),
                        int.Parse(str.Substring(3, 2)),
                        int.Parse(str.Substring(6, 2)),
                        int.Parse(str.Substring(9, 3)));
            }
        }

        public static string TimeSpanToString(TimeSpan ts)
        {
            return ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2") + "." + ts.Milliseconds.ToString("D3");
        }

        public static string MsecsToString(int msecs)
        {
            //7msecs = msecs * 100;

            TimeSpan ts = new TimeSpan(0, 0, 0, 0, msecs);

            string str = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2") + "." + ts.Milliseconds.ToString("D3");

            return str;
        }

        public static int StringToMsecs(string str)
        {
            TimeSpan ts = StringToTimeSpan(str);

            //7return (int)(ts.TotalMilliseconds/100);
            return (int)(ts.TotalMilliseconds);
        }
        public static string MsecsToSecsString(int msecs)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, msecs);

            return ts.TotalSeconds.ToString("#0.00", new System.Globalization.CultureInfo("en-US"));
        }

        private void UpdateTextBoxSelection()
        {                       

            int selstart = txtBox.SelectionStart;
            
            txtBox.SelectionLength = 0;

            if (selstart == 0 || selstart == 1 || selstart==2)
            {                
                txtBox.Select(0, 2);
            }
            else if (selstart == 3 || selstart == 4 || selstart==5)
            {                
                txtBox.Select(3, 2);
            }
            else if (selstart == 6 || selstart == 7 || selstart==8)
            {                
                txtBox.Select(6, 2);
            }
            else if (selstart == 9 || selstart == 10 || selstart == 11 || selstart==12)
            {             
                txtBox.Select(9, 3);
            }            
        }

        public static int StringToMsecs2DecimalPlaces(string str)
        {
            TimeSpan ts = StringToTimeSpan(str);

            return (int)(ts.TotalMilliseconds);
        }

        public static string MsecsToString2DecimalPlaces(int msecs)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, msecs);

            string str = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2") + "." + ts.Milliseconds.ToString("D2");

            return str;
        }

        private void UpdateTextBoxSelectionLastChar()
        {
            int selstart = txtBox.SelectionStart;                      

            if (selstart == 2)
            {                
                txtBox.Select(0, 2);
            }
            else if (selstart == 5)
            {                
                txtBox.Select(3, 2);
            }
            else if (selstart == 8)
            {               
                txtBox.Select(6, 2);
            }
            else if (selstart == 12)
            {                
                txtBox.Select(9, 3);
            }
        }
                
        private decimal OldValue;
       
        private void nUpDown_ValueChanged(object sender, EventArgs e)
        {
            int spos = txtBox.SelectionStart;                      
            
            string seltxt="";


            int num = 0;
            
            
                if (txtBox.SelectionStart==0)
                {
                    num=int.Parse(txtBox.Text.Substring(0,2));
                }
                else if (txtBox.SelectionStart==3)
                {
                    num=int.Parse(txtBox.Text.Substring(3,2));
                }
                else if (txtBox.SelectionStart==6)
                {
                    num=int.Parse(txtBox.Text.Substring(6,2));
                }
                else if (txtBox.SelectionStart==9)
                {
                    num=int.Parse(txtBox.Text.Substring(9,3));
                }                
                                    

            if (nUpDown.Value - OldValue > 0)
            {                
                if (txtBox.SelectionStart <9)                    
                {
                    num++;

                    num=num%100;

                    txtBox.SelectedText = num.ToString("D2");
                    
                }
                else if (txtBox.SelectionStart >= 9)
                {
                    num++;

                    num = num % 1000;

                    txtBox.SelectedText = num.ToString("D3");
                }
            }
            else
            {                
                if (txtBox.SelectionStart <9)
                {
                    num--;

                    num = num % 100;

                    txtBox.SelectedText = num.ToString("D2");
                }
                else if (txtBox.SelectionStart >= 9)
                {
                    num--;

                    num = num % 1000;

                    txtBox.SelectedText = num.ToString("D3");
                }
            }

            OldValue = nUpDown.Value;
                                    
            txtBox.Focus();
            
            txtBox.SelectionStart = spos;
            UpdateTextBoxSelection();
            txtBox.Focus();

            this.Validate(); 
            //LastAcceptedValue = txtBox.Text;
        }        

        private void txtBox_Click(object sender, EventArgs e)
        {
            UpdateTextBoxSelection();
        }

        private void txtBox_KeyUp(object sender, KeyEventArgs e)
        {
            // remove comment if you want the control to behave like a datetimepicker and not a simple maskedtextbox
            
            //UpdateTextBoxSelectionLastChar();
        }

        private void txtBox_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateTextBoxSelection();
        }
        
    }
}
