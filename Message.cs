using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iTunesSVKS
{
    public partial class Message : Form
    {
        public Message()
        {
            InitializeComponent();
            if (Properties.Settings.Default.messageToPost != null)
            {
                messageBox.Text = Properties.Settings.Default.messageToPost;
            }
        }

        private void Message_Load(object sender, EventArgs e)
        {

        }

        private void publishButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.messageToPost = messageBox.Text;
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
