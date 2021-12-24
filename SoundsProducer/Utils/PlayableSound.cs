using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SoundsProducer.Utils
{
    // Class that represents playable sounds
    public class PlayableSound
    {
        private int managerId;                  // SoundManager ID thats manages this instance
        private int? playableSoundOwnerId;      // In some cases a PlayableSound can be slave from another one (used when this instance is associated with a SoundManager with its fadeInOut attribute in false)
        private int id;                         // PlayableSoud instance ID
        private string path;                    // The sound file path associated with this instance
        private bool playing;                   // True when this sound is playing, otherwise false
        private bool paused;                    // True when this sound is paused, otherwise false
        private bool fadingOut;                 // True when this sound is fading out, otherwise false
        private bool fadingIn;                  // True when this sound is fading in, otherwise false
        private double volume;                  // The PlayableSoud instance volume value
        private MediaPlayer mediaPlayer;        // .NET API class (the sound core)

        // Constructor to create a PlayableSound
        public PlayableSound(string path, int id, int managerId)
        {
            this.managerId = managerId;
            this.id = id;
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
        }

        // Constructor to create a PlayableSound (used by SoundManager when this instance is associated with a SoundManager with its fadeInOut attribute in False)
        public PlayableSound(string path, int id, int managerId, int playableSoundOwner)
        {
            this.managerId = managerId;
            this.playableSoundOwnerId = playableSoundOwner;
            this.id = id;
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
        }

        // ##### Public methods #####

        // Plays this sound with the passed delay by argument
        async public void play(int delay = 0)
        {
            await Task.Delay(delay);
            Console.WriteLine("PlayableSound with ID: " + this.id + " managed by SoundManager with ID: " + this.managerId + " is now playing.");
            this.playing = true;
            this.paused = false;
            this.mediaPlayer.Play();
        }

        // Stops this sound with the passed delay by argument
        async public void stop(int delay = 0)
        {
            if (this.isPlaying() || this.isPaused()) // Stops the sound if his playing status is true or it was paused
            {
                await Task.Delay(delay);
                Console.WriteLine("PlayableSound with ID: " + this.id + " managed by SoundManager with ID: " + this.managerId + " is now stopped.");
                this.playing = false;
                this.paused = false;
                this.mediaPlayer.Stop();
            }
        }

        // Pauses the sound with the passed delay by argument
        async public void pause(int delay = 0)
        {
            if (this.isPlaying()) // Stops the sound only if his playing status is true
            {
                await Task.Delay(delay);
                Console.WriteLine("PlayableSound with ID: " + this.id + " managed by SoundManager with ID: " + this.managerId + " is now paused.");
                this.playing = false;
                this.paused = true;
                this.mediaPlayer.Pause();
            }
        }

        // Sets the sound volume of this instance
        public void setVolume(double value)
        {
            if (this.volume >= 0 && this.volume <= 1)
            {
                this.volume = Math.Round(value, 2);
                this.mediaPlayer.Volume = Math.Round(value, 2);
            }

            if (this.volume < 0)
            {
                this.volume = 0;
                this.mediaPlayer.Volume = 0;
            }

            if (this.volume > 1)
            {
                this.volume = 1;
                this.mediaPlayer.Volume = 1;
            }
        }

        // Turns down the sound volume to zero in the milliseconds passed by argument
        async public void fadeOutSound(double ms)
        {
            if (ms != -1)
            {
                Console.WriteLine("PlayableSound with ID: " + this.id + " managed by SoundManager with ID: " + this.managerId + " is starting to fade out.");
                Console.WriteLine(this.volume + " <-- Inital volume.");
                Console.WriteLine((this.volume * 100.00) + " <-- Steps to the end.");
                Console.WriteLine(ms / (this.volume * 100.00) + " <-- ms between puases.");

                double steps = this.volume * 100.00;
                double msToPause = ms / (this.volume * 100.00);
                fadingOut = true;
                fadingIn = false;

                int stepsCounter = 1;

                while ((stepsCounter <= steps || this.volume > 0) && !this.fadingIn && this.playing) // this.volume > 0 is used in the case that the volume is manipulated when the sound is fading out 
                {
                    if (this.volume == 0)
                        break;

                    Console.WriteLine("Fade out step: " + stepsCounter);
                    this.setVolume(Math.Round(this.volume, 2) - 0.01); // Math.Round is used because strange values was appearing like 0.499999 etc 
                    await Task.Delay((int)msToPause);

                    stepsCounter++;
                }

                fadingOut = false;
                if (!this.fadingIn)
                    this.stop();
            }
        }

        // Turns up the sound volume to 'volumeTo' value in the milliseconds passed by argument
        async public void fadeInSound(double ms)
        {
            if (ms != -1)
            {
                const int volumeTo = 50; // Target volume to arrive (0-100)

                Console.WriteLine("PlayableSound with ID: " + this.id + " managed by SoundManager with ID: " + this.managerId + " is starting to fade in.");
                Console.WriteLine(this.volume + " <-- Inital volume.");
                Console.WriteLine(volumeTo - (this.volume * 100.00) + " <-- Steps to arrive to target volume. " + volumeTo);
                Console.WriteLine(ms / (volumeTo - (this.volume * 100.00)) + " <-- ms between puases.");

                double steps = volumeTo - (this.volume * 100.00);
                double msToPause = ms / steps;
                fadingIn = true;
                fadingOut = false;
                this.playing = true;

                int stepsCounter = 1;

                while ((stepsCounter <= steps && this.volume * 100.00 < volumeTo) && !this.fadingOut && this.playing)
                {
                    Console.WriteLine("Fade in step: " + stepsCounter);
                    this.setVolume(Math.Round(this.volume, 2) + 0.01);
                    await Task.Delay((int)msToPause);

                    stepsCounter++;
                }

                fadingIn = false;
                Console.WriteLine("PlayableSound with ID: " + this.id + " managed by SoundManager with ID: " + this.managerId + " appear with volume: " + this.volume);
            }
        }

        public int getManagerId()
        {
            return this.managerId;
        }

        public int? getPlayableSoundOwnerId()
        {
            return this.playableSoundOwnerId;
        }

        public int getId()
        {
            return this.id;
        }

        public string getPath()
        {
            return this.path;
        }

        // Changes the sound file path associated with this instance 
        public void setPath(string path)
        {
            this.path = path;
            this.mediaPlayer.Open(new Uri(this.path, UriKind.RelativeOrAbsolute));
        }

        public bool isPlaying()
        {
            return this.playing;
        }

        public bool isPaused()
        {
            return this.paused;
        }

        public bool isFadingOut()
        {
            return this.fadingOut;
        }

        public bool isFadingIn()
        {
            return this.fadingIn;
        }

        public double getVolume()
        {
            return this.volume;
        }

        // ##### Private methods #####

        private void associatePathWithMediaPlayer()
        {
            if (!File.Exists(this.path))
                throw new Exception("Media file doesn't exist: " + (this.path == null ? "null" : this.path));

            this.mediaPlayer.Open(new Uri(this.path, UriKind.RelativeOrAbsolute));
        }

        private void initializeMediaPlayerEvents()
        {
            this.mediaPlayer.MediaEnded += onMediaEnded; // Associates the MediaEnded event (that occurs when the sound has finished to playback) with a handler method
        }

        // This handler method is called when the MediaEnded event is fired
        private void onMediaEnded(object sender, EventArgs e)
        {
            Console.WriteLine("PlayableSound with ID: " + this.id + " managed by SoundManager with ID: " + this.managerId + " is now ended.");
        }
    }
}
