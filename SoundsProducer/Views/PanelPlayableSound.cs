using SoundsProducer.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SoundsProducer.Views
{
    // Custom panel with controls to manipulate sounds
    public partial class PanelPlayableSound : UserControl
    {
        private SoundManager soundManager;
        private PlayableSound playableSound;

        public PanelPlayableSound()
        {
            InitializeComponent();
        }

        public PanelPlayableSound(SoundManager soundManager, PlayableSound playableSound)
        {
            InitializeComponent();
            this.soundManager = soundManager;
            this.playableSound = playableSound;
        }

        private void button_file_chooser_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.button_file_chooser.Text = openFileDialog.FileName;
                this.soundManager.setPathById(this.playableSound.getId(), openFileDialog.FileName);
            }
        }

        private void button_play_Click(object sender, EventArgs e)
        {
            double trackbarValue = this.trackBar_volume.Value / 100.00;
            this.soundManager.setVolumeById(this.playableSound.getId(), trackbarValue);
            this.soundManager.playById(this.playableSound.getId(), 0);
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            this.soundManager.stopById(this.playableSound.getId(), 0);
        }

        private void button_pause_Click(object sender, EventArgs e)
        {
            // ToDo...
        }

        private void CustomPanelSounds_Load(object sender, EventArgs e)
        {
            this.button_file_chooser.Text = this.soundManager.getPathById(this.playableSound.getId());

            //double trackbarValue = this.trackBar_volume.Value / 100.00;
            //this.soundManager.setVolumeById(this.playableSound.getId(), trackbarValue);
            this.trackBar_volume.Value = (int)(this.soundManager.getVolumeById(this.playableSound.getId()) * 100);

            // Only for test purposes --------
            if (this.soundManager.getFadeInOut())
            {
                this.button_play.BackColor = Color.Moccasin;
                this.button_pause.BackColor = Color.Moccasin;
                this.button_stop.BackColor = Color.Moccasin;
                this.button_file_chooser.BackColor = Color.Moccasin;
            }
            else if (this.soundManager.getSelfRepeat())
            {
                this.button_play.BackColor = Color.LightGreen;
                this.button_pause.BackColor = Color.LightGreen;
                this.button_stop.BackColor = Color.LightGreen;
                this.button_file_chooser.BackColor = Color.LightGreen;
            }
            else
            {
                this.button_play.BackColor = Color.LightSalmon;
                this.button_pause.BackColor = Color.LightSalmon;
                this.button_stop.BackColor = Color.LightSalmon;
                this.button_file_chooser.BackColor = Color.LightSalmon;
            }
            // Only for test purposes --------
        }

        private void trackBar_volume_ValueChanged(object sender, EventArgs e)
        {
            double trackbarValue = this.trackBar_volume.Value / 100.00;
            this.soundManager.setVolumeById(this.playableSound.getId(), trackbarValue);
        }
    }
}
