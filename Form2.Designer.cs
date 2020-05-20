namespace WindowsFormsApp1
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.channelIdTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.watchBtn = new System.Windows.Forms.Button();
            this.channelMsgsTextBox = new System.Windows.Forms.TextBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.loggedUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // channelIdTextBox
            // 
            this.channelIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelIdTextBox.Location = new System.Drawing.Point(325, 36);
            this.channelIdTextBox.Name = "channelIdTextBox";
            this.channelIdTextBox.Size = new System.Drawing.Size(235, 29);
            this.channelIdTextBox.TabIndex = 0;
            this.channelIdTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(150, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Channel ID to watch :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // watchBtn
            // 
            this.watchBtn.Location = new System.Drawing.Point(596, 36);
            this.watchBtn.Name = "watchBtn";
            this.watchBtn.Size = new System.Drawing.Size(106, 29);
            this.watchBtn.TabIndex = 2;
            this.watchBtn.Text = "Watch";
            this.watchBtn.UseVisualStyleBackColor = true;
            this.watchBtn.Click += new System.EventHandler(this.watchBtn_Click);
            // 
            // channelMsgsTextBox
            // 
            this.channelMsgsTextBox.BackColor = System.Drawing.Color.White;
            this.channelMsgsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelMsgsTextBox.Location = new System.Drawing.Point(136, 87);
            this.channelMsgsTextBox.Multiline = true;
            this.channelMsgsTextBox.Name = "channelMsgsTextBox";
            this.channelMsgsTextBox.ReadOnly = true;
            this.channelMsgsTextBox.Size = new System.Drawing.Size(629, 268);
            this.channelMsgsTextBox.TabIndex = 3;
            this.channelMsgsTextBox.TextChanged += new System.EventHandler(this.channelMsgsTextBox_TextChanged);
            // 
            // messageTextBox
            // 
            this.messageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageTextBox.Location = new System.Drawing.Point(136, 375);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(629, 31);
            this.messageTextBox.TabIndex = 4;
            this.messageTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            this.messageTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messageTextBox_KeyDown);
            this.messageTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.messageTextBox_KeyUp);
            // 
            // loggedUser
            // 
            this.loggedUser.AutoSize = true;
            this.loggedUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loggedUser.ForeColor = System.Drawing.Color.Lime;
            this.loggedUser.Location = new System.Drawing.Point(739, 9);
            this.loggedUser.Name = "loggedUser";
            this.loggedUser.Size = new System.Drawing.Size(111, 20);
            this.loggedUser.TabIndex = 5;
            this.loggedUser.Text = "Logged user - ";
            this.loggedUser.Click += new System.EventHandler(this.loggedUser_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(976, 441);
            this.Controls.Add(this.loggedUser);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.channelMsgsTextBox);
            this.Controls.Add(this.watchBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.channelIdTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.Opacity = 0.95D;
            this.Text = "Discord";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Shown += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox channelIdTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button watchBtn;
        private System.Windows.Forms.TextBox channelMsgsTextBox;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Label loggedUser;
    }
}