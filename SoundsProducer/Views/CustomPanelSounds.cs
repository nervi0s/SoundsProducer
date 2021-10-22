using SoundsProducer.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SoundsProducer.Views
{
    // Custom panel with controls to manage sounds
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

            double trackbarValue = this.trackBar_volume.Value / 100.00;
            try
            {
                if (sp_list.Count > 0)
                {
                    Sound_Player lastSound_PlayerCreated = sp_list[sp_list.Count - 1];
                    if (lastSound_PlayerCreated.isPaused())
                    {
                        if (!Sound_Player.allInstancedSound_PlayerObjectsList.Contains(lastSound_PlayerCreated))
                        {
                            sp_list.Remove(lastSound_PlayerCreated);
                            lastSound_PlayerCreated.setPaused(false);
                            Sound_Player sp = new Sound_Player(this.path);
                            sp_list.Add(sp);
                            sp.setVolume(trackbarValue);
                            sp.play(false, 0);
                        }
                        else
                        {
                            lastSound_PlayerCreated.setVolume(trackbarValue);
                            lastSound_PlayerCreated.play(false, 0);
                            lastSound_PlayerCreated.setPaused(false);
                        }
                    }
                    else
                    {
                        Sound_Player sp = new Sound_Player(this.path);
                        sp.setVolume(trackbarValue);
                        sp_list.Add(sp);
                        sp.play(false, 0);
                    }
                }
                else
                {
                    Sound_Player sp = new Sound_Player(this.path);
                    sp_list.Add(sp);
                    sp.setVolume(trackbarValue);
                    sp.play(false, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
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
