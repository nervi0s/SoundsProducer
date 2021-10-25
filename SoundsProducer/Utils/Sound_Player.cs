using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SoundsProducer.Utils
{
    // Class to manage sounds using a MediaPlayer class
    public class Sound_Player
    {
        public static List<Sound_Player> allInstancedChildObjectsList = new List<Sound_Player>(); // Static list with all instanced child objects of this class
        private static List<Sound_Player> mainObjectsInstancedList = new List<Sound_Player>(); // Static list with all instanced main objects of this class

        private int id; // Used to identify the main object which creates the other ones that plays the sound
        private int subId = 0; // Used to identify the objects created by a main object
        public bool simultaneity; // Used by the main object to determine if his child objects can be played simultaneously
        public bool hardStopWithNoSimultaneity; // Used by the main object to determine if his child objects can stop all the sounds when simultaneously isn't allowed
        private string path;
        private MediaPlayer mediaPlayer;
        private bool paused;
        private double volume;

        // Constructor to create the main object
        public Sound_Player(string path, int id, bool simultaneity, bool hardStopWithNoSimultaneity)
        {
            this.id = id;
            this.path = path;
            this.simultaneity = simultaneity;
            this.hardStopWithNoSimultaneity = hardStopWithNoSimultaneity;
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
            mainObjectsInstancedList.Add(this);
        }

        // Constructor to create objects by a main object
        private Sound_Player(string path, int id, int subId)
        {
            this.id = id;
            this.subId = subId;
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
            allInstancedChildObjectsList.Remove(this);
            Console.WriteLine("Sound with SubID: " + this.subId + " created by media with ID: " + this.id + " is now ended.");
        }

        private void play()
        {
            Console.WriteLine("New playable sound with SubID: " + this.subId + " created by media with ID: " + this.id + " is now playing.");
            this.mediaPlayer.Play();
        }

        private void pause()
        {
            Console.WriteLine("New playable sound with SubID: " + this.subId + " created by media with ID: " + this.id + " is now paused.");
            this.mediaPlayer.Pause();
        }

        private void stopAndRemove()
        {
            Console.WriteLine("The playable sound with SubID: " + this.subId + " created by media with ID: " + this.id + " is now stopped.");
            this.mediaPlayer.Stop();
            allInstancedChildObjectsList.Remove(this);
        }

        private int childInstancesCounter(int id) // Returns the number of objects created by a main object
        {
            int counter = 0;
            foreach (Sound_Player item in allInstancedChildObjectsList)
            {
                if (item.id == id)
                    counter++;
            }
            return counter;
        }

        // Public methods
        async public void play(int delay = 0) // simultaneously true allow play sounds and the same time, false don't allow it. hardStopWithNoSimultaneity true stop all the sounds, false stops only sound with same main ID.
        {
            await Task.Delay(delay);
            Console.WriteLine("Media with ID: " + this.id + " calling to play.");

            if (this.paused)
            {
                foreach (Sound_Player sp_child in allInstancedChildObjectsList)
                {
                    if (sp_child.id == this.id)
                        sp_child.play();
                }
                this.paused = false;
            }
            else
            {
                if (!this.simultaneity && this.hardStopWithNoSimultaneity)
                {
                    stopAll();
                }
                if (!this.simultaneity && !this.hardStopWithNoSimultaneity)
                {
                    stopAllWithID(this.id);
                }
                Sound_Player sp = new Sound_Player(this.path, this.id, childInstancesCounter(this.id) + 1);
                allInstancedChildObjectsList.Add(sp);
                sp.mediaPlayer.Volume = this.volume;
                sp.play();
            }
        }

        async public void stop(int delay = 0)
        {
            await Task.Delay(delay);
            Console.WriteLine("Media with ID: " + this.id + " calling to stop.");
            for (int i = allInstancedChildObjectsList.Count - 1; i >= 0; i--)
            {
                if (allInstancedChildObjectsList[i].id == this.id)
                {
                    allInstancedChildObjectsList[i].stopAndRemove();
                    break;
                }
            }

            if (this.childInstancesCounter(this.id) == 0)
            {
                this.paused = false;
            }
        }

        async public void pause(int delay = 0)
        {
            await Task.Delay(delay);
            Console.WriteLine("Media with ID: " + this.id + " calling to pause.");

            foreach (Sound_Player sp_child in allInstancedChildObjectsList)
            {
                if (sp_child.id == this.id)
                {
                    sp_child.pause();
                    this.paused = true;
                }
            }
        }

        public void setVolume(double value) // Used by the main object to set the volume of all his child objects 
        {
            this.volume = value;
            foreach (Sound_Player sp_child in allInstancedChildObjectsList)
            {
                if (sp_child.id == this.id)
                    sp_child.mediaPlayer.Volume = value;
            }
        }

        public bool isPaused()
        {
            return this.paused;
        }

        public static void stopAll() // Static method that allows stop all sounds in the list allInstancedSound_PlayerObjectsList
        {
            for (int i = allInstancedChildObjectsList.Count - 1; i >= 0; i--)
                allInstancedChildObjectsList[i].stopAndRemove();

            allInstancedChildObjectsList.Clear();

            foreach (Sound_Player sp_main in mainObjectsInstancedList)
            {
                sp_main.paused = false;
            }
        }

        public static void stopAllWithID(int id) // Static method that allows stop all sounds with a specific ID in the list allInstancedSound_PlayerObjectsList
        {
            for (int i = allInstancedChildObjectsList.Count - 1; i >= 0; i--)
            {
                if (allInstancedChildObjectsList[i].id == id)
                    allInstancedChildObjectsList[i].stopAndRemove();
            }
        }

        public string getPath()
        {
            return this.path;
        }

        public void setPath(string path)
        {
            this.path = path;
        }
    }
}
