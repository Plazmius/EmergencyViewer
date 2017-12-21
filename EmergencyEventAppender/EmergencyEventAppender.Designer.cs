namespace EmergencyEventAppender
{
    partial class EmergencyEventAppender
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
            this.components = new System.ComponentModel.Container();
            this.addButton = new System.Windows.Forms.Button();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.occuranceDateLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.occuranceDatePicker = new System.Windows.Forms.DateTimePicker();
            this.infoSourceLabel = new System.Windows.Forms.Label();
            this.infoSourceComboBox = new System.Windows.Forms.ComboBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.addButton.Location = new System.Drawing.Point(189, 403);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 32);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(53, 286);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(176, 24);
            this.typeComboBox.TabIndex = 1;
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(53, 263);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(40, 17);
            this.typeLabel.TabIndex = 2;
            this.typeLabel.Text = "Type";
            // 
            // occuranceDateLabel
            // 
            this.occuranceDateLabel.AutoSize = true;
            this.occuranceDateLabel.Location = new System.Drawing.Point(50, 209);
            this.occuranceDateLabel.Name = "occuranceDateLabel";
            this.occuranceDateLabel.Size = new System.Drawing.Size(109, 17);
            this.occuranceDateLabel.TabIndex = 4;
            this.occuranceDateLabel.Text = "Occurance date";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(50, 59);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(45, 17);
            this.nameLabel.TabIndex = 6;
            this.nameLabel.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(53, 79);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(176, 22);
            this.nameTextBox.TabIndex = 5;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(50, 118);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(79, 17);
            this.descriptionLabel.TabIndex = 8;
            this.descriptionLabel.Text = "Description";
            // 
            // descriptionRichTextBox
            // 
            this.descriptionRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionRichTextBox.Location = new System.Drawing.Point(53, 138);
            this.descriptionRichTextBox.Name = "descriptionRichTextBox";
            this.descriptionRichTextBox.Size = new System.Drawing.Size(358, 61);
            this.descriptionRichTextBox.TabIndex = 9;
            this.descriptionRichTextBox.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // occuranceDatePicker
            // 
            this.occuranceDatePicker.Location = new System.Drawing.Point(53, 229);
            this.occuranceDatePicker.Name = "occuranceDatePicker";
            this.occuranceDatePicker.Size = new System.Drawing.Size(176, 22);
            this.occuranceDatePicker.TabIndex = 11;
            // 
            // infoSourceLabel
            // 
            this.infoSourceLabel.AutoSize = true;
            this.infoSourceLabel.Location = new System.Drawing.Point(53, 316);
            this.infoSourceLabel.Name = "infoSourceLabel";
            this.infoSourceLabel.Size = new System.Drawing.Size(125, 17);
            this.infoSourceLabel.TabIndex = 13;
            this.infoSourceLabel.Text = "Information source";
            // 
            // infoSourceComboBox
            // 
            this.infoSourceComboBox.FormattingEnabled = true;
            this.infoSourceComboBox.Location = new System.Drawing.Point(53, 339);
            this.infoSourceComboBox.Name = "infoSourceComboBox";
            this.infoSourceComboBox.Size = new System.Drawing.Size(176, 24);
            this.infoSourceComboBox.TabIndex = 12;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(175, 27);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(101, 17);
            this.titleLabel.TabIndex = 14;
            this.titleLabel.Text = "Add new event";
            // 
            // EmergencyEventAppender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.infoSourceLabel);
            this.Controls.Add(this.infoSourceComboBox);
            this.Controls.Add(this.occuranceDatePicker);
            this.Controls.Add(this.descriptionRichTextBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.occuranceDateLabel);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.addButton);
            this.Name = "EmergencyEventAppender";
            this.Size = new System.Drawing.Size(459, 466);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label occuranceDateLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.RichTextBox descriptionRichTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DateTimePicker occuranceDatePicker;
        private System.Windows.Forms.Label infoSourceLabel;
        private System.Windows.Forms.ComboBox infoSourceComboBox;
        private System.Windows.Forms.Label titleLabel;
    }
}
