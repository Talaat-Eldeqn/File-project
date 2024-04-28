using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib; // Windows Media Player Library
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Unsubscribe from any existing PlayStateChange event handlers and subscribe to a new one
            player.PlayStateChange -= Player_PlayStateChange;
            player.PlayStateChange += Player_PlayStateChange;

            // Initialize shuffle to true
            isShuffleEnabled = true;
        }

        private bool isShuffleEnabled = false; // Flag to indicate if shuffle is enabled
        private bool isRepeatEnabled = false; // Flag to indicate if repeat is enabled
        private string[] paths; // Array to store file paths
        private string[] files; // Array to store file names

        // Event handler for opening files
        private void btn_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Multiselect = true, // Allow selecting multiple files
                Filter = "Media Files|*.mpg;*.avi;*.wma;*.mov;*.wav;*.mp2;*.mp3;*.mp4;*.flv;*.m4a;*.mkv;|All Files|*.*"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                files = ofd.SafeFileNames; // Get the names of the selected files
                paths = ofd.FileNames; // Get the paths of the selected files

                track_list.Items.Clear(); // Clear the list box

                // Add the file names to the list box
                for (int x = 0; x < files.Length; x++)
                {
                    track_list.Items.Add(files[x]);
                }

                // Shuffle the playlist if shuffle is enabled
                if (isShuffleEnabled)
                {
                    ShufflePlaylist();
                }
            }
        }

        // Event handler for selecting a track from the list box
        private void track_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (track_list.SelectedIndex >= 0 && track_list.SelectedIndex < paths.Length)
            {
                try
                {
                    // Play the selected track
                    player.URL = paths[track_list.SelectedIndex];
                    player.Ctlcontrols.play();

                    // Unsubscribe from previous PlayStateChange event
                    player.PlayStateChange -= Player_PlayStateChange;
                    // Subscribe to the PlayStateChange event to handle track ending
                    player.PlayStateChange += Player_PlayStateChange;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error playing the selected track: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Single Event handler for PlayStateChange event
        private void Player_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            // Check if the current state is 'Media Ended'
            if ((WMPPlayState)e.newState == WMPPlayState.wmppsMediaEnded)
            {
                // Decide the next track to play based on whether shuffle is enabled
                int nextIndex = isShuffleEnabled ? GetNextShuffleIndex() : track_list.SelectedIndex + 1;

                // Check if we've reached the end of the playlist
                if (nextIndex >= track_list.Items.Count)
                {
                    if (isRepeatEnabled) // If repeat is enabled, either reshuffle or restart from the beginning
                    {
                        if (isShuffleEnabled)
                            ShufflePlaylist(); // Reshuffle if shuffle is enabled
                        nextIndex = 0; // Start from the beginning
                    }
                    else
                    {
                        return; // Stop playback or handle as needed
                    }
                }

                // Set the next item as the current selection and play
                track_list.SelectedIndex = nextIndex; // This will trigger 'track_list_SelectedIndexChanged' to play the next track
            }
        }

        // Event handler for the Play button
        private void btn_play_Click(object sender, EventArgs e)
        {
            player.Ctlcontrols.play();
        }

        // Event handler for the Pause button
        private void btn_pause_Click(object sender, EventArgs e)
        {
            player.Ctlcontrols.pause();
        }

        // Event handler for the Next button
        private void btn_next_Click(object sender, EventArgs e)
        {
            if (track_list.SelectedIndex < track_list.Items.Count - 1)
            {
                track_list.SelectedIndex++;
            }
        }

        // Event handler for the Previous button
        private void btn_prev_Click(object sender, EventArgs e)
        {
            if (track_list.SelectedIndex > 0)
            {
                track_list.SelectedIndex--;
            }
        }

        // Event handler for the Stop button
        private void btn_stop_Click(object sender, EventArgs e)
        {
            player.Ctlcontrols.stop();
        }

        // Event handler for the repeat button
        private void button1_Click(object sender, EventArgs e)
        {
            isRepeatEnabled = !isRepeatEnabled; // Toggle the repeat state

            // Update button text to reflect the new state
            Repeat_fun.Text = isRepeatEnabled ? "Repeat: ON" : "Repeat: OFF";
        }

        // Helper method to get the next index for shuffle mode
        private int GetNextShuffleIndex()
        {
            // Implement shuffle logic here to determine the next index
            // For now, just proceed linearly as an example
            return track_list.SelectedIndex + 1;
        }

        // Helper method to shuffle the playlist
        private void ShufflePlaylist()
        {
            Random rnd = new Random();

            // Fisher-Yates shuffle algorithm
            int n = track_list.Items.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);

                // Swap items in the list box
                var value = track_list.Items[k];
                track_list.Items[k] = track_list.Items[n];
                track_list.Items[n] = value;

                // Swap paths as well to keep track_list and paths in sync
                string tempPath = paths[k];
                paths[k] = paths[n];
                paths[n] = tempPath;
            }

            // Automatically play the first song in the shuffled playlist
            track_list.SelectedIndex = 0;
        }
    }
}
