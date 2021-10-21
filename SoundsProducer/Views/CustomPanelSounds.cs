using SoundsProducer.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SoundsProducer.Views
{
    public partial class CustomPanelSounds : UserControl
    {
        private List<Sound_Player> sp_list = new List<Sound_Player>();
        private string path;

        public CustomPanelSounds()
        {
            InitializeComponent();
        }

        public CustomPanelSounds(string path)
        {
            InitializeComponent();
            this.path = path;
        }

        private void button_file_chooser_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                button_file_chooser.Text = openFileDialog.FileName;
                this.path = button_file_chooser.Text;
            }
        }

        private void button_play_Click(object sender, EventArgs e)
        {
            if (Sound_Player.allInstancedSound_PlayerObjectsList.Count == 0)
                this.sp_list.Clear();

            if (sp_list.Count > 0)
            {
                Sound_Player lastSound_PlayerCreated = sp_list[sp_list.Count - 1];
                if (lastSound_PlayerCreated.isPaused())
                {
                    lastSound_PlayerCreated.play();
                    lastSound_PlayerCreated.setPaused(false);
                }
                else
                {
                    Sound_Player sp = new Sound_Player(this.path);
                    sp_list.Add(sp);
                    sp.play();
                }
            }
            else
            {
                Sound_Player sp = new Sound_Player(this.path);
                sp_list.Add(sp);
                sp.play();
            }
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            if (sp_list.Count > 0)
            {
                Sound_Player lastSound_PlayerCreated = sp_list[sp_list.Count - 1];
                if (Sound_Player.allInstancedSound_PlayerObjectsList.Contains(lastSound_PlayerCreated))
                    lastSound_PlayerCreated.stop();
                sp_list.Remove(lastSound_PlayerCreated);
                Sound_Player.allInstancedSound_PlayerObjectsList.Remove(lastSound_PlayerCreated);
            }
        }

        private void button_pause_Click(object sender, EventArgs e)
        {
            if (sp_list.Count > 0)
            {
                Sound_Player lastSound_PlayerCreated = sp_list[sp_list.Count - 1];
                if (Sound_Player.allInstancedSound_PlayerObjectsList.Contains(lastSound_PlayerCreated))
                    lastSound_PlayerCreated.pause();
            }
        }

        private void CustomPanelSounds_Load(object sender, EventArgs e)
        {
            this.button_file_chooser.Text = this.path;
        }

        private void trackBar_volume_ValueChanged(object sender, EventArgs e)
        {
            double trackbarValue = this.trackBar_volume.Value / 100.00;
            foreach (Sound_Player sp in sp_list)
                sp.setVolume(trackbarValue);
        }
    }
}
