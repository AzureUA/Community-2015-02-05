﻿namespace AzureEventHub.UI
{
	partial class FormMain
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
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.panelDemoSimple1 = new AzureEventHub.UI.Panel.PanelDemoSimple();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.panelDemoSimple1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(670, 448);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Simple";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// panelDemoSimple1
			// 
			this.panelDemoSimple1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelDemoSimple1.Location = new System.Drawing.Point(3, 3);
			this.panelDemoSimple1.Name = "panelDemoSimple1";
			this.panelDemoSimple1.Size = new System.Drawing.Size(664, 442);
			this.panelDemoSimple1.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(678, 474);
			this.tabControl1.TabIndex = 0;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(678, 474);
			this.Controls.Add(this.tabControl1);
			this.Name = "FormMain";
			this.Text = "Event Hub";
			this.tabPage1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabPage tabPage1;
		private Panel.PanelDemoSimple panelDemoSimple1;
		private System.Windows.Forms.TabControl tabControl1;

	}
}

