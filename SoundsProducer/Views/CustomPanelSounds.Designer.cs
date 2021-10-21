
namespace SoundsProducer.Views
{
    partial class CustomPanelSounds
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_base = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_buttons = new System.Windows.Forms.TableLayoutPanel();
            this.button_play = new System.Windows.Forms.Button();
            this.button_pause = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.button_file_chooser = new System.Windows.Forms.Button();
            this.trackBar_volume = new System.Windows.Forms.TrackBar();
            this.panel_base.SuspendLayout();
            this.tableLayoutPanel_buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_volume)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_base
            // 
            this.panel_base.Controls.Add(this.tableLayoutPanel_buttons);
            this.panel_base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_base.Location = new System.Drawing.Point(0, 0);
            this.panel_base.Name = "panel_base";
            this.panel_base.Size = new System.Drawing.Size(1060, 98);
            this.panel_base.TabIndex = 0;
            // 
            // tableLayoutPanel_buttons
            // 
            this.tableLayoutPanel_buttons.ColumnCount = 4;
            this.tableLayoutPanel_buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 558F));
            this.tableLayoutPanel_buttons.Controls.Add(this.button_play, 0, 0);
            this.tableLayoutPanel_buttons.Controls.Add(this.button_pause, 1, 0);
            this.tableLayoutPanel_buttons.Controls.Add(this.button_stop, 2, 0);
            this.tableLayoutPanel_buttons.Controls.Add(this.button_file_chooser, 3, 0);
            this.tableLayoutPanel_buttons.Controls.Add(this.trackBar_volume, 0, 1);
            this.tableLayoutPanel_buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_buttons.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_buttons.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_buttons.Name = "tableLayoutPanel_buttons";
            this.tableLayoutPanel_buttons.RowCount = 2;
            this.tableLayoutPanel_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel_buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_buttons.Size = new System.Drawing.Size(1060, 98);
            this.tableLayoutPanel_buttons.TabIndex = 0;
            // 
            // button_play
            // 
            this.button_play.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_play.Location = new System.Drawing.Point(3, 3);
            this.button_play.Name = "button_play";
            this.button_play.Size = new System.Drawing.Size(161, 59);
            this.button_play.TabIndex = 0;
            this.button_play.Text = "PLAY";
            this.button_play.UseVisualStyleBackColor = true;
            this.button_play.Click += new System.EventHandler(this.button_play_Click);
            // 
            // button_pause
            // 
            this.button_pause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_pause.Location = new System.Drawing.Point(170, 3);
            this.button_pause.Name = "button_pause";
            this.button_pause.Size = new System.Drawing.Size(161, 59);
            this.button_pause.TabIndex = 1;
            this.button_pause.Text = "PAUSE";
            this.button_pause.UseVisualStyleBackColor = true;
            this.button_pause.Click += new System.EventHandler(this.button_pause_Click);
            // 
            // button_stop
            // 
            this.button_stop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_stop.Location = new System.Drawing.Point(337, 3);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(161, 59);
            this.button_stop.TabIndex = 2;
            this.button_stop.Text = "STOP";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // button_file_chooser
            // 
            this.button_file_chooser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_file_chooser.Location = new System.Drawing.Point(504, 3);
            this.button_file_chooser.Name = "button_file_chooser";
            this.button_file_chooser.Size = new System.Drawing.Size(553, 59);
            this.button_file_chooser.TabIndex = 3;
            this.button_file_chooser.Text = "PATH";
            this.button_file_chooser.UseVisualStyleBackColor = true;
            this.button_file_chooser.Click += new System.EventHandler(this.button_file_chooser_Click);
            // 
            // trackBar_volume
            // 
            this.tableLayoutPanel_buttons.SetColumnSpan(this.trackBar_volume, 4);
            this.trackBar_volume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar_volume.Location = new System.Drawing.Point(3, 68);
            this.trackBar_volume.Maximum = 100;
            this.trackBar_volume.Name = "trackBar_volume";
            this.trackBar_volume.Size = new System.Drawing.Size(1054, 27);
            this.trackBar_volume.TabIndex = 4;
            this.trackBar_volume.Value = 50;
            this.trackBar_volume.ValueChanged += new System.EventHandler(this.trackBar_volume_ValueChanged);
            // 
            // CustomPanelSounds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_base);
            this.Name = "CustomPanelSounds";
            this.Size = new System.Drawing.Size(1060, 98);
            this.Load += new System.EventHandler(this.CustomPanelSounds_Load);
            this.panel_base.ResumeLayout(false);
            this.tableLayoutPanel_buttons.ResumeLayout(false);
            this.tableLayoutPanel_buttons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_volume)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_base;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_buttons;
        private System.Windows.Forms.Button button_play;
        private System.Windows.Forms.Button button_pause;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Button button_file_chooser;
        private System.Windows.Forms.TrackBar trackBar_volume;
    }
}
