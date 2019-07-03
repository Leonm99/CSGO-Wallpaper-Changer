using System;
using System.Windows.Forms;

namespace CSGO_Wallpaper
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();
            linkLabel1.LinkArea = new LinkArea(13, 66);
            linkLabel2.LinkArea = new LinkArea(62, 89);

        }

        private void Label1_Click(object sender, System.EventArgs e)
        {

        }

        private void Label2_Click(object sender, System.EventArgs e)
        {

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/Jayby18/panorama_wallpaper_changer");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }

        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/Leonm99");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void LabelProductName_Click(object sender, EventArgs e)
        {

        }
    }
}
