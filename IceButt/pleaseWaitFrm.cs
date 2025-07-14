using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IceButt
{
    public partial class pleaseWaitFrm : Form
    {
        BoolWrapper done;
        Form1 parentFrm;
        string title;
        public pleaseWaitFrm(BoolWrapper isDone, Form1 parentForm, string Title)//isDone signals to the form to close
        {
            InitializeComponent();
            done = isDone;
            parentFrm = parentForm;
            title = Title;
        }

        private void pleaseWaitFrm_Load(object sender, EventArgs e)
        {
            this.Text = title;
            parentFrm.StartThread(()=>
            {
                while (!done.Value)
                {
                    Thread.Sleep(100);
                    if (label1.Text.Count(f => f == '.') >=4)
                    {
                        parentFrm.InvokeIfRequired(label1, () => label1.Text = "Please wait");                    
                    }
                    else
                    {
                        parentFrm.InvokeIfRequired(label1, () => label1.Text = label1.Text + ".");
                    }
                }
                parentFrm.InvokeIfRequired(this, () => this.Close());
            });
        }
    }
}
