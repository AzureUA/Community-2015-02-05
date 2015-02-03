namespace AzureEventHub.UI.Panel
{
	partial class PanelDemoSimple
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnSendMessage = new System.Windows.Forms.Button();
			this.tbMessage = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.lbReceiversCount = new System.Windows.Forms.Label();
			this.lbMessagesReceived = new System.Windows.Forms.Label();
			this.rtbMessages = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
			this.splitContainer1.Size = new System.Drawing.Size(668, 376);
			this.splitContainer1.SplitterDistance = 334;
			this.splitContainer1.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnSendMessage);
			this.groupBox1.Controls.Add(this.tbMessage);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(334, 376);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// btnSendMessage
			// 
			this.btnSendMessage.Location = new System.Drawing.Point(251, 17);
			this.btnSendMessage.Name = "btnSendMessage";
			this.btnSendMessage.Size = new System.Drawing.Size(75, 23);
			this.btnSendMessage.TabIndex = 1;
			this.btnSendMessage.Text = "Send";
			this.btnSendMessage.UseVisualStyleBackColor = true;
			this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
			// 
			// tbMessage
			// 
			this.tbMessage.Location = new System.Drawing.Point(6, 19);
			this.tbMessage.Name = "tbMessage";
			this.tbMessage.Size = new System.Drawing.Size(239, 20);
			this.tbMessage.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.rtbMessages);
			this.groupBox2.Controls.Add(this.lbMessagesReceived);
			this.groupBox2.Controls.Add(this.lbReceiversCount);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(330, 376);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "groupBox2";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Receivers count:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(102, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Messages received:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(249, 17);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 42);
			this.button1.TabIndex = 2;
			this.button1.Text = "Create receiver";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// lbReceiversCount
			// 
			this.lbReceiversCount.AutoSize = true;
			this.lbReceiversCount.Location = new System.Drawing.Point(129, 22);
			this.lbReceiversCount.Name = "lbReceiversCount";
			this.lbReceiversCount.Size = new System.Drawing.Size(13, 13);
			this.lbReceiversCount.TabIndex = 3;
			this.lbReceiversCount.Text = "0";
			// 
			// lbMessagesReceived
			// 
			this.lbMessagesReceived.AutoSize = true;
			this.lbMessagesReceived.Location = new System.Drawing.Point(129, 46);
			this.lbMessagesReceived.Name = "lbMessagesReceived";
			this.lbMessagesReceived.Size = new System.Drawing.Size(13, 13);
			this.lbMessagesReceived.TabIndex = 4;
			this.lbMessagesReceived.Text = "0";
			// 
			// rtbMessages
			// 
			this.rtbMessages.Location = new System.Drawing.Point(9, 62);
			this.rtbMessages.Name = "rtbMessages";
			this.rtbMessages.Size = new System.Drawing.Size(315, 308);
			this.rtbMessages.TabIndex = 5;
			this.rtbMessages.Text = "";
			// 
			// PanelDemoSimple
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Name = "PanelDemoSimple";
			this.Size = new System.Drawing.Size(668, 376);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnSendMessage;
		private System.Windows.Forms.TextBox tbMessage;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lbMessagesReceived;
		private System.Windows.Forms.Label lbReceiversCount;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox rtbMessages;
	}
}
