using System;
using System.Collections.Generic;

namespace SoundsProducer.Utils
{
    // Class that represents a manager for PlayableSound objects
    public class SoundManager
    {
        private readonly int id;                                                        // SoundManager instance ID

        private bool fadeInOut = true;                                                  // True allows fade in/out sounds, False don't allow fade in/out
        private double fadeInOutTime = -1;                                              // Time for fade in/out sounds, with -1 the sounds exist instantly
        private bool selfRepeat = true;                                                 // Used when 'fadeInOut' value is False. True permite que al darle al play de un sonido, este se repoduzca otra vez sin esperar que acabe el mismo (existen a la vez). False hace que al darle al play se detenga el sonido actual y comience desde cero otra vez el mismo.

        public List<PlayableSound> playableSoundsList = new List<PlayableSound>();      // Used to manage the PlayableSound objects associated with this SoundManager instance

        // Constructor to create a SoundManager with a initial PlayableSound object
        public SoundManager(PlayableSound playableSound, int id)
        {
            this.id = id;
            addSound(playableSound);
        }

        // Constructor to create a SoundManager with a initial PlayableSound objects list
        public SoundManager(List<PlayableSound> playableSounds, int id)
        {
            this.id = id;
            addSounds(playableSounds);
        }

        // ##### Public methods #####

        // Adds one PlayableSound object to this SoundManager instance
        public void addSound(PlayableSound playableSound)
        {
            if (!checkUniqueID(playableSound.getId()))
                throw new Exception("The ID: " + playableSound.getId() + " already exist.");
            else
                playableSoundsList.Add(playableSound);
        }

        // Adds PlayableSound objects list to this SoundManager instance
        public void addSounds(List<PlayableSound> playableSounds)
        {
            foreach (PlayableSound ps in playableSounds)
            {
                if (!checkUniqueID(ps.getId()))
                    throw new Exception("The ID: " + ps.getId() + " already exist.");
                else
                    playableSoundsList.Add(ps);
            }
        }

        // Plays the PlayableSound with the ID passed by argument with the specified delay
        public void playById(int playableSoundId, int delay = 0)
        {
            PlayableSound playableSound = getPlayableSoundById(playableSoundId);
            if (playableSound != null)
            {
                if (this.fadeInOut)
                {
                    playWithFadeInOut(playableSound, delay, this.fadeInOutTime);
                }
                else
                {
                    playWithoutFadeInOut(playableSound, delay);
                }
            }
            else
            {
                throw new Exception("The ID: " + playableSoundId + " doesn't exist.");
            }
        }

        // Stops the PlayableSound with the ID passed by argument with the specified delay
        public void stopById(int playableSoundId, int delay = 0)
        {
            PlayableSound playableSound = getPlayableSoundById(playableSoundId);
            if (playableSound != null)
            {
                if (this.fadeInOut)
                {
                    playableSound.stop(delay);
                }
                else
                {
                    stopAndRemove(playableSoundId, delay);
                }
            }
            else
            {
                throw new Exception("The ID: " + playableSoundId + " doesn't exist.");
            }
        }

        // Stops all sounds managed by this instance
        public void stopAll()
        {
            for (int i = getPlayableSounds().Count - 1; i >= 0; i--)
            {
                if (!this.fadeInOut)
                {
                    if (getPlayableSounds()[i].getPlayableSoundOwnerId() != null)
                    {
                        stopAndRemove(getPlayableSounds()[i].getPlayableSoundOwnerId().GetValueOrDefault(), 0);
                    }
                }
                else
                {
                    getPlayableSounds()[i].stop();
                }
            }
        }

        // Returns the volume value for the sounds with the passed ID managed by this instance
        public double getVolumeById(int playableSoundId)
        {
            PlayableSound playableSound = getPlayableSoundById(playableSoundId);
            if (playableSound != null)
            {
                return playableSound.getVolume();
            }
            else
            {
                throw new Exception("The ID: " + id + " doesn't exist.");
            }
        }

        // Sets the volume value for the sounds managed by this instance
        public void setVolumeById(int playableSoundId, double value)
        {
            PlayableSound playableSound = getPlayableSoundById(playableSoundId);
            if (playableSound != null)
            {
                playableSound.setVolume(value);

                if (!fadeInOut)
                    setVolumeToChilds(playableSoundId, value);
            }
            else
            {
                throw new Exception("The ID: " + playableSoundId + " doesn't exist.");
            }
        }

        // Returns the sound file path associated to PlayableSound object ID
        public string getPathById(int playableSoundId)
        {
            PlayableSound playableSound = getPlayableSoundById(playableSoundId);
            if (playableSound != null)
            {
                return playableSound.getPath();
            }
            else
            {
                throw new Exception("The ID: " + id + " doesn't exist.");
            }
        }

        // Allows to change the sound file path associated with a PlayableSound object
        public void setPathById(int id, string path)
        {
            PlayableSound playableSound = getPlayableSoundById(id);
            if (playableSound != null)
            {
                playableSound.setPath(path);
            }
            else
            {
                throw new Exception("The ID: " + id + " doesn't exist.");
            }
        }

        // Returns the PlayableSound list associated with this SoundManager instance
        public List<PlayableSound> getPlayableSounds()
        {
            return this.playableSoundsList;
        }

        public PlayableSound getPlayableSoundById(int id)
        {
            foreach (PlayableSound ps in playableSoundsList)
                if (ps.getId() == id)
                    return ps;

            return null;
        }

        public int getId()
        {
            return this.id;
        }

        public bool getFadeInOut()
        {
            return this.fadeInOut;
        }

        public void setFadeInOut(bool value)
        {
            this.fadeInOut = value;
        }

        public void setFadeInOutTime(double ms)
        {
            this.fadeInOutTime = ms;
        }

        public bool getSelfRepeat()
        {
            return this.selfRepeat;
        }

        public void setSelfRepeat(bool value)
        {
            this.selfRepeat = value;
        }

        // ##### Private methods #####

        private bool checkUniqueID(int id) // True if the passed id argument is unique, otherwise False
        {
            foreach (PlayableSound ps in playableSoundsList)
                if (ps.getId() == id)
                    return false;

            return true;
        }

        // Used when the 'fadeInOut' is set with True
        private void playWithFadeInOut(PlayableSound playableSoundToAppear, int delay, double mergeTime)
        {
            bool wasNecessaryFadeOutSound = false;
            foreach (PlayableSound ps in playableSoundsList)
            {
                if (ps.getId() != playableSoundToAppear.getId())
                {
                    if (ps.isPlaying())
                    {
                        wasNecessaryFadeOutSound = true;
                        ps.fadeOutSound(mergeTime);
                    }
                }
            }
            if (wasNecessaryFadeOutSound && mergeTime != -1)
            {
                playableSoundToAppear.setVolume(0);
                playableSoundToAppear.fadeInSound(mergeTime);
            }
            playableSoundToAppear.play(delay);
        }

        // Used when the 'fadeInOut' is set with False
        private void playWithoutFadeInOut(PlayableSound playableSoundToPlay, int delay)
        {
            if (!this.selfRepeat)
            {
                stopAndRemove(playableSoundToPlay.getId(), delay);
            }

            int rId = new Random().Next(1000000);

            playableSoundsList.Add(new PlayableSound(playableSoundToPlay.getPath(), rId, this.id, playableSoundToPlay.getId()));
            playableSoundsList[playableSoundsList.Count - 1].setVolume(playableSoundToPlay.getVolume());
            playableSoundsList[playableSoundsList.Count - 1].play(delay);
        }

        // Stops and delete a PlayableSound child object, associated with an another PlayableSound object acting as owner. Used when 'fadeInOut' is dissable
        private void stopAndRemove(int playableSoundOwnerId, int delay)
        {
            for (int i = playableSoundsList.Count - 1; i >= 0; i--)
            {
                if (playableSoundsList[i].getPlayableSoundOwnerId() == playableSoundOwnerId)
                {
                    playableSoundsList[i].stop(delay);
                    playableSoundsList.Remove(playableSoundsList[i]);
                    break;
                }
            }
        }

        // Sets the volume value for all child objects of the a main PlayableSound , using his ID. Used when 'fadeInOut' is dissable
        private void setVolumeToChilds(int playableSoundOwnerId, double value)
        {
            foreach (PlayableSound ps in playableSoundsList)
            {
                if (ps.getPlayableSoundOwnerId() == playableSoundOwnerId)
                {
                    ps.setVolume(value);
                }
            }
        }
    }
}
