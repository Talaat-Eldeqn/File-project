using System.Diagnostics.Tracing;
using WMPLib;

namespace WindowsFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_prev = new System.Windows.Forms.Button();
            this.btn_open = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_pause = new System.Windows.Forms.Button();
            this.btn_play = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.track_list = new System.Windows.Forms.ListBox();
            this.player = new AxWMPLib.AxWindowsMediaPlayer();
            this.Repeat_fun = new System.Windows.Forms.Button();

            // Set form background color
            this.BackColor = System.Drawing.Color.FromArgb(31, 31, 31);

            // btn_prev
            this.btn_prev.Location = new System.Drawing.Point(10, 10);
            this.btn_prev.Size = new System.Drawing.Size(100, 40);
            this.btn_prev.Text = "⏮️";
            this.btn_prev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_prev.BackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btn_prev.ForeColor = System.Drawing.Color.White;
            this.btn_prev.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_prev.FlatAppearance.BorderSize = 0;
            this.btn_prev.UseVisualStyleBackColor = true;
            this.btn_prev.Click += new System.EventHandler(this.btn_prev_Click);

            // btn_open
            this.btn_open.Location = new System.Drawing.Point(120, 10);
            this.btn_open.Size = new System.Drawing.Size(100, 40);
            this.btn_open.Text = "📁";
            this.btn_open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_open.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btn_open.ForeColor = System.Drawing.Color.White;
            this.btn_open.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_open.FlatAppearance.BorderSize = 0;
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);

            // btn_next
            this.btn_next.Location = new System.Drawing.Point(230, 10);
            this.btn_next.Size = new System.Drawing.Size(100, 40);
            this.btn_next.Text = "⏭️";
            this.btn_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_next.BackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btn_next.ForeColor = System.Drawing.Color.White;
            this.btn_next.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_next.FlatAppearance.BorderSize = 0;
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);

            // btn_pause
            this.btn_pause.Location = new System.Drawing.Point(10, 60);
            this.btn_pause.Size = new System.Drawing.Size(100, 40);
            this.btn_pause.Text = "⏸️";
            this.btn_pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pause.BackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btn_pause.ForeColor = System.Drawing.Color.White;
            this.btn_pause.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pause.FlatAppearance.BorderSize = 0;
            this.btn_pause.UseVisualStyleBackColor = true;
            this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);

            // btn_play
            this.btn_play.Location = new System.Drawing.Point(120, 60);
            this.btn_play.Size = new System.Drawing.Size(100, 40);
            this.btn_play.Text = "▶️";
            this.btn_play.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_play.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btn_play.ForeColor = System.Drawing.Color.White;
            this.btn_play.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_play.FlatAppearance.BorderSize = 0;
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);

            // btn_stop
            this.btn_stop.Location = new System.Drawing.Point(230, 60);
            this.btn_stop.Size = new System.Drawing.Size(100, 40);
            this.btn_stop.Text = "⏹️";
            this.btn_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stop.BackColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btn_stop.ForeColor = System.Drawing.Color.White;
            this.btn_stop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stop.FlatAppearance.BorderSize = 0;
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);

            // track_list
            this.track_list.FormattingEnabled = true;
            this.track_list.HorizontalScrollbar = true;
            this.track_list.Location = new System.Drawing.Point(10, 110);
            this.track_list.Size = new System.Drawing.Size(320, 200);
            this.track_list.BackColor = System.Drawing.Color.FromArgb(31, 31, 31);
            this.track_list.ForeColor = System.Drawing.Color.White;
            this.track_list.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.track_list.TabIndex = 6;
            this.track_list.SelectedIndexChanged += new System.EventHandler(this.track_list_SelectedIndexChanged);

            // player
            this.player.Enabled = true;
            this.player.Location = new System.Drawing.Point(340, 10);
            this.player.Size = new System.Drawing.Size(620, 420);
            this.player.BackColor = System.Drawing.Color.Black;
            this.player.TabIndex = 0;
            this.player.Visible = true;
            



            // Repeat_fun
            this.Repeat_fun.Location = new System.Drawing.Point(340, 440);
            this.Repeat_fun.Size = new System.Drawing.Size(100, 40);
            this.Repeat_fun.Text = "🔁";
            this.Repeat_fun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Repeat_fun.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.Repeat_fun.ForeColor = System.Drawing.Color.White;
            this.Repeat_fun.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Repeat_fun.FlatAppearance.BorderSize = 0;
            this.Repeat_fun.UseVisualStyleBackColor = true;
            this.Repeat_fun.Click += new System.EventHandler(this.button1_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 500);
            this.Controls.Add(this.Repeat_fun);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.track_list);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.player);
            this.Controls.Add(this.btn_pause);
            this.Controls.Add(this.btn_prev);
            this.Controls.Add(this.btn_play);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Modern Media Player";
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer player;
        private System.Windows.Forms.Button btn_prev;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.ListBox track_list;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button Repeat_fun;
    }
}
