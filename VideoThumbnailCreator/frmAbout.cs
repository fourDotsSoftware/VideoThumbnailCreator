using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VideoThumbnailCreator
{
    public partial class frmAbout : CustomForm
    {
        public static string lblf = "";

        // license email
        public static string LDT = "";

        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblAbout.Text = Module.ApplicationTitle + "\n\n" +
            "Developed by Alexander Triantafyllou\n" +
            "Copyright © 2021 - 4dots Software\n";

            ullProductWebpage.Text = Module.ProductWebpageURL;

            /*
            if (frmAbout.LDT == string.Empty)
            {
                lblRegistered.Text = TranslateHelper.Translate("Trial Version - Unlicensed");
            }
            else
            {
                lblRegistered.Text = TranslateHelper.Translate("Business Version - Licensed");

                lblLicenseKey.Text = frmAbout.LDT;

                btnRegister.Visible = false;

                btnBuy.Visible = false;
            }*/
        }
                
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.4dots-software.com");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.4dots-software.com/support/");
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Module.BuyURL);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            
        }
    }
}