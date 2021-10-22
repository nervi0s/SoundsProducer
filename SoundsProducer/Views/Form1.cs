using SoundsProducer.Utils;
using SoundsProducer.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SoundsProducer
{
    public partial class Form_root : Form
    {
        public Form_root()
        {
            InitializeComponent();
        }

        private void button_stop_all_Click(object sender, EventArgs e)
        {
            Sound_Player.stopAll();
        }

        private void Form_root_Load(object sender, EventArgs e) // Loads all the paths with sounds from settings file, then instance a CustomPanelSounds and adds it the form
        {
            string settings = "./settings.xml";
            Xml_Reader xml_Reader = new Xml_Reader(settings);
            List<string> paths = xml_Reader.GetNodeValues("Sound");

            foreach (string path in paths)
            {
                this.flowLayoutPanel_top.Controls.Add(new CustomPanelSounds(path));
            }
        }
    }
}
