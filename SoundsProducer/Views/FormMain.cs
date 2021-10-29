using SoundsProducer.Utils;
using SoundsProducer.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace SoundsProducer
{
    public partial class FormMain : Form
    {
        private List<SoundManager> soundManagersList = new List<SoundManager>();
        public FormMain()
        {
            InitializeComponent();
        }

        private void button_stop_all_Click(object sender, EventArgs e)
        {
            foreach (SoundManager sm in soundManagersList)
            {
                sm.stopAll();
            }
        }

        private void Form_root_Load(object sender, EventArgs e) // Loads all the controls to manage sounds
        {
            string settings = "./settings.xml";
            Xml_Reader xml_Reader = new Xml_Reader(settings);

            List<List<string>> soundManagersAttributesList = xml_Reader.GetNodeAttributesValuesList("SoundManager");
            List<List<Dictionary<string, string>>> playableSoundsInfo = xml_Reader.getNodeChildsAttriburesAndValues("Sounds");
            List<List<PlayableSound>> playableSoundsList = getPlayableSoundsList(playableSoundsInfo);

            for (int i = 0; i < soundManagersAttributesList.Count; i++)
            {
                int managerID = int.Parse(soundManagersAttributesList[i][0]);
                SoundManager soundManager = new SoundManager(playableSoundsList[i], managerID);

                soundManager.setFadeInOut(Boolean.Parse(soundManagersAttributesList[i][1]));
                soundManager.setFadeInOutTime(Double.Parse(soundManagersAttributesList[i][2]));
                soundManager.setSelfRepeat(Boolean.Parse(soundManagersAttributesList[i][3]));

                soundManagersList.Add(soundManager);
                this.flowLayoutPanel_top.Controls.Add(new PanelSoundManager(soundManager));
            }
        }

        private List<List<PlayableSound>> getPlayableSoundsList(List<List<Dictionary<string, string>>> playableSoundsInfo)
        {
            List<List<PlayableSound>> playableSoundsList = new List<List<PlayableSound>>();

            foreach (List<Dictionary<string, string>> dictionaryList in playableSoundsInfo)
            {
                List<PlayableSound> psList = new List<PlayableSound>();

                foreach (Dictionary<string, string> dictionary in dictionaryList)
                {
                    string[] attribues = dictionary["attributes"].Split(',');
                    string path = dictionary["value"];

                    PlayableSound ps = new PlayableSound(path, int.Parse(attribues[0]), int.Parse(attribues[2]));

                    NumberFormatInfo provider = new NumberFormatInfo();
                    provider.NumberDecimalSeparator = ".";

                    ps.setVolume(Convert.ToDouble(attribues[1], provider));
                    psList.Add(ps);
                }
                playableSoundsList.Add(psList);
            }
            return playableSoundsList;
        }
    }
}
