using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VideoJoinerExpert
{
    public partial class frmMsgCheckBox : VideoJoinerExpert.CustomForm
    {
        public enum MsgModeEnum
        {
            OnBlackDetectExcludeMode,
            OnCutWithKeepSameFormat,
            BachJoinFormat
        }

        public MsgModeEnum MsgMode;

        public frmMsgCheckBox()
        {
            InitializeComponent();
        }

        public frmMsgCheckBox(MsgModeEnum msgmode,string msg):this()
        {
            MsgMode = msgmode;
            lblMsg.Text = msg;
            lblMsg.Left = this.ClientRectangle.Width / 2 - lblMsg.Width / 2;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (chkDoNotShowAgain.Checked)
            {
                /*
                if (MsgMode == MsgModeEnum.OnBlackDetectExcludeMode)
                {
                    Properties.Settings.Default.MsgBlackDetectExcludeMode = false;
                }
                else if (MsgMode == MsgModeEnum.OnCutWithKeepSameFormat)
                {
                    Properties.Settings.Default.MsgCutWithKeepSameFormat = false;
                }
                else if (MsgMode == MsgModeEnum.BachJoinFormat)
                {
                    Properties.Settings.Default.MsgBatchJoinFormat = false;
                }*/
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
