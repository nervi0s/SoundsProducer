using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;

namespace SoundsProducer.Utils
{
    public class Sound_Player
    {
        public static List<Sound_Player> allInstancedSound_PlayerObjectsList = new List<Sound_Player>();

        private int id;
        private string path;
        private MediaPlayer mediaPlayer;
        private bool paused;

        // Constructor
        public Sound_Player(string path)
        {
            this.id = this.GetHashCode();
            this.path = path;
            this.mediaPlayer = new MediaPlayer();

            try
            {
                associatePathWithMediaPlayer();
            }
            catch (Exception e)
            {
                throw e;
            }

            initializeMediaPlayerEvents();

            allInstancedSound_PlayerObjectsList.Add(this);
        }

        // Private methods
        private void associatePathWithMediaPlayer()
        {
            if (!File.Exists(this.path))
                throw new Exception("Media file doesn't exist: " + (this.path == null ? "null" : this.path));

            this.mediaPlayer.Open(new Uri(this.path, UriKind.RelativeOrAbsolute));
        }
        private void initializeMediaPlayerEvents()
        {
            this.mediaPlayer.MediaEnded += onMediaEnded;
        }
        private void onMediaEnded(object sender, EventArgs e)
        {
            allInstancedSound_PlayerObjectsList.Remove(this);
            Console.WriteLine("Media with ID: " + this.id + " ended.");
        }

        // Public methods
        public void play()
        {
            Console.WriteLine("Media with ID: " + this.id + " playing.");
            this.mediaPlayer.Play();
        }

        public void stop()
        {
            Console.WriteLine("Media with ID: " + this.id + " stopped.");
            this.mediaPlayer.Stop();
        }

        public void pause()
        {
            Console.WriteLine("Media with ID: " + this.id + " paused.");
            this.mediaPlayer.Pause();
            this.paused = true;
        }

        public void setVolume(double value)
        {
            this.mediaPlayer.Volume = value;
        }

        public bool isPaused()
        {
            return this.paused;
        }

        public void setPaused(bool value)
        {
            this.paused = value;
        }

        public static void stopAll()
        {
            foreach (Sound_Player sp in allInstancedSound_PlayerObjectsList)
                sp.stop();

            allInstancedSound_PlayerObjectsList.Clear();
        }
    }
}
