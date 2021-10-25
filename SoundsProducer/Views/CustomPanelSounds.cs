using SoundsProducer.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SoundsProducer.Views
{
    // Custom panel with controls to manage sounds
    public partial class CustomPanelSounds : UserControl
    {
        private string path;
        private Sound_Player sound_player;

        public CustomPanelSounds()
        {
            InitializeComponent();
        }

        public CustomPanelSounds(Sound_Player sound_player)
        {
            InitializeComponent();
            this.sound_player = sound_player;
            this.path = this.sound_player.getPath();
        }

        private void button_file_chooser_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                button_file_chooser.Text = openFileDialog.FileName;
                this.sound_player.setPath(openFileDialog.FileName);
                this.path = this.sound_player.getPath();
            }
        }

        private void button_play_Click(object sender, EventArgs e)
        {
            double trackbarValue = this.trackBar_volume.Value / 100.00;
            try
            {
                this.sound_player.setVolume(trackbarValue);
                this.sound_player.play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            this.sound_player.stop();
        }

        private void button_pause_Click(object sender, EventArgs e)
        {
            this.sound_player.pause();
        }

        private void CustomPanelSounds_Load(object sender, EventArgs e)
        {
            this.button_file_chooser.Text = this.path;

            // Only for test purpose
            if (this.sound_player.simultaneity)
            {
                panel_base.BackColor = Color.Green;
            }
            else
            {
                if (this.sound_player.hardStopWithNoSimultaneity)
                {
                    panel_base.BackColor = Color.Red;
                }
                else
                {
                    panel_base.BackColor = Color.Orange;
                }
            }
        }

        private void trackBar_volume_ValueChanged(object sender, EventArgs e)
        {
            double trackbarValue = this.trackBar_volume.Value / 100.00;
            this.sound_player.setVolume(trackbarValue);
        }
    }
}
