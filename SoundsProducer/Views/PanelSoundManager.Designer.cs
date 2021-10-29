
namespace SoundsProducer.Views
{
    partial class PanelSoundManager
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
            this.tableLayoutPanel_base = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel_top = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel_botton = new System.Windows.Forms.TableLayoutPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel_base.SuspendLayout();
            this.tableLayoutPanel_botton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_base
            // 
            this.tableLayoutPanel_base.ColumnCount = 1;
            this.tableLayoutPanel_base.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_base.Controls.Add(this.flowLayoutPanel_top, 0, 0);
            this.tableLayoutPanel_base.Controls.Add(this.tableLayoutPanel_botton, 0, 1);
            this.tableLayoutPanel_base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_base.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_base.Name = "tableLayoutPanel_base";
            this.tableLayoutPanel_base.RowCount = 2;
            this.tableLayoutPanel_base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_base.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel_base.Size = new System.Drawing.Size(1096, 374);
            this.tableLayoutPanel_base.TabIndex = 1;
            // 
            // flowLayoutPanel_top
            // 
            this.flowLayoutPanel_top.AutoScroll = true;
            this.flowLayoutPanel_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_top.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel_top.Name = "flowLayoutPanel_top";
            this.flowLayoutPanel_top.Size = new System.Drawing.Size(1090, 293);
            this.flowLayoutPanel_top.TabIndex = 0;
            // 
            // tableLayoutPanel_botton
            // 
            this.tableLayoutPanel_botton.ColumnCount = 4;
            this.tableLayoutPanel_botton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_botton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_botton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_botton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_botton.Controls.Add(this.button3, 0, 0);
            this.tableLayoutPanel_botton.Controls.Add(this.button4, 0, 0);
            this.tableLayoutPanel_botton.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel_botton.Controls.Add(this.button2, 0, 0);
            this.tableLayoutPanel_botton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_botton.Location = new System.Drawing.Point(0, 299);
            this.tableLayoutPanel_botton.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_botton.Name = "tableLayoutPanel_botton";
            this.tableLayoutPanel_botton.RowCount = 1;
            this.tableLayoutPanel_botton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_botton.Size = new System.Drawing.Size(1096, 75);
            this.tableLayoutPanel_botton.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(551, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(268, 69);
            this.button3.TabIndex = 3;
            this.button3.Text = "STOP ALL";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(825, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(268, 69);
            this.button4.TabIndex = 2;
            this.button4.Text = "STOP ALL";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(268, 69);
            this.button1.TabIndex = 1;
            this.button1.Text = "STOP ALL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(277, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(268, 69);
            this.button2.TabIndex = 0;
            this.button2.Text = "STOP ALL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PanelSoundManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel_base);
            this.Name = "PanelSoundManager";
            this.Size = new System.Drawing.Size(1096, 374);
            this.Load += new System.EventHandler(this.PanelSoundManager_Load);
            this.tableLayoutPanel_base.ResumeLayout(false);
            this.tableLayoutPanel_botton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_base;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_top;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_botton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
    }
}
