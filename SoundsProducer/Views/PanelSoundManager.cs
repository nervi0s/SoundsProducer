using SoundsProducer.Utils;
using System;
using System.Windows.Forms;

namespace SoundsProducer.Views
{
    public partial class PanelSoundManager : UserControl
    {
        private SoundManager soundManager;
        public PanelSoundManager()
        {
            InitializeComponent();
        }

        public PanelSoundManager(SoundManager soundManager)
        {
            InitializeComponent();
            this.soundManager = soundManager;
        }

        private void PanelSoundManager_Load(object sender, EventArgs e)
        {
            foreach (PlayableSound playableSound in this.soundManager.getPlayableSounds())
            {
                this.flowLayoutPanel_top.Controls.Add(new PanelPlayableSound(this.soundManager, playableSound));
            }

            if (this.soundManager.getFadeInOut())
            {
                this.button1.Text = "fadeInOutTime = -1";
                this.button2.Text = "fadeInOutTime = 6000";
                this.button3.Text = "fadeInOutTime = 2000";
                this.button4.Text = "fadeInOutTime = 1000";
            }
            else
            {
                this.button1.Text = "selfRepeat = true";
                this.button2.Text = "selfRepeat = false";
                this.button3.Text = "selfRepeat = true";
                this.button4.Text = "selfRepeat = false";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.soundManager.getFadeInOut())
            {
                this.soundManager.setFadeInOutTime(-1);
            }
            else
            {
                this.soundManager.setSelfRepeat(true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.soundManager.getFadeInOut())
            {
                this.soundManager.setFadeInOutTime(6000);
            }
            else
            {
                this.soundManager.setSelfRepeat(false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.soundManager.getFadeInOut())
            {
                this.soundManager.setFadeInOutTime(2000);
            }
            else
            {
                this.soundManager.setSelfRepeat(true);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.soundManager.getFadeInOut())
            {
                this.soundManager.setFadeInOutTime(1000);
            }
            else
            {
                this.soundManager.setSelfRepeat(false);
            }
        }
    }
}
