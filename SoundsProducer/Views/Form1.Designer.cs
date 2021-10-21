
namespace SoundsProducer
{
    partial class Form_root
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel_base = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel_top = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel_botton = new System.Windows.Forms.TableLayoutPanel();
            this.button_stop_all = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel_base.Size = new System.Drawing.Size(1094, 450);
            this.tableLayoutPanel_base.TabIndex = 0;
            // 
            // flowLayoutPanel_top
            // 
            this.flowLayoutPanel_top.AutoScroll = true;
            this.flowLayoutPanel_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_top.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel_top.Name = "flowLayoutPanel_top";
            this.flowLayoutPanel_top.Size = new System.Drawing.Size(1088, 369);
            this.flowLayoutPanel_top.TabIndex = 0;
            // 
            // tableLayoutPanel_botton
            // 
            this.tableLayoutPanel_botton.ColumnCount = 1;
            this.tableLayoutPanel_botton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_botton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_botton.Controls.Add(this.button_stop_all, 0, 0);
            this.tableLayoutPanel_botton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_botton.Location = new System.Drawing.Point(0, 375);
            this.tableLayoutPanel_botton.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel_botton.Name = "tableLayoutPanel_botton";
            this.tableLayoutPanel_botton.RowCount = 1;
            this.tableLayoutPanel_botton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_botton.Size = new System.Drawing.Size(1094, 75);
            this.tableLayoutPanel_botton.TabIndex = 1;
            // 
            // button_stop_all
            // 
            this.button_stop_all.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_stop_all.Location = new System.Drawing.Point(3, 3);
            this.button_stop_all.Name = "button_stop_all";
            this.button_stop_all.Size = new System.Drawing.Size(1088, 69);
            this.button_stop_all.TabIndex = 0;
            this.button_stop_all.Text = "STOP ALL";
            this.button_stop_all.UseVisualStyleBackColor = true;
            this.button_stop_all.Click += new System.EventHandler(this.button_stop_all_Click);
            // 
            // Form_root
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1094, 450);
            this.Controls.Add(this.tableLayoutPanel_base);
            this.Name = "Form_root";
            this.Text = "Sounds Producer";
            this.Load += new System.EventHandler(this.Form_root_Load);
            this.tableLayoutPanel_base.ResumeLayout(false);
            this.tableLayoutPanel_botton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_base;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_top;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_botton;
        private System.Windows.Forms.Button button_stop_all;
    }
}

