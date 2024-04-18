using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Array to store file paths
        private string[] paths;
        // Array to store file names
        private string[] files;

        // Event handler for opening files
        private void btn_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            // Allow multiple file selection
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Get selected file names
                files = ofd.SafeFileNames;
                // Get selected file paths
                paths = ofd.FileNames;

                // Add file names to the list box
                for (int x = 0; x < files.Length; x++)
                {
                    track_list.Items.Add(files[x]);
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

                    // Update the player volume
                    player.settings.volume = trackBar1.Value;

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

        // Event handler for PlayStateChange event
        private void Player_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            // Check if the track has ended
            if ((WMPLib.WMPPlayState)e.newState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
                // Play the next track if available
                if (track_list.SelectedIndex < track_list.Items.Count - 1)
                {
                    track_list.SelectedIndex++;
                }
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

        // Event handler for the volume control
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // Set the player volume based on the trackBar value
            player.settings.volume = trackBar1.Value;
        }

        // Event handler for the Stop button
        private void btn_stop_Click(object sender, EventArgs e)
        {
            player.Ctlcontrols.stop();
        }
    }
}
