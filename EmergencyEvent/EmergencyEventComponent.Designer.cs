using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows.Forms;

namespace EmergencyEventComponent
{
    partial class EmergencyEventComponent
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmergencyEventComponent));
            this.showEvents = new System.Windows.Forms.Button();
            this.dateFromPicker = new System.Windows.Forms.DateTimePicker();
            this.dateToPicker = new System.Windows.Forms.DateTimePicker();
            this.eventsGrid = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.startDateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.eventsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // showEvents
            // 
            resources.ApplyResources(this.showEvents, "showEvents");
            this.showEvents.Name = "showEvents";
            this.showEvents.UseVisualStyleBackColor = true;
            this.showEvents.Click += new System.EventHandler(this.showEvents_Click);
            // 
            // dateFromPicker
            // 
            resources.ApplyResources(this.dateFromPicker, "dateFromPicker");
            this.dateFromPicker.Name = "dateFromPicker";
            this.dateFromPicker.Value = new System.DateTime(2017, 11, 16, 20, 2, 20, 915);
            // 
            // dateToPicker
            // 
            resources.ApplyResources(this.dateToPicker, "dateToPicker");
            this.dateToPicker.Name = "dateToPicker";
            this.dateToPicker.Value = new System.DateTime(2017, 11, 23, 20, 2, 20, 918);
            // 
            // eventsGrid
            // 
            resources.ApplyResources(this.eventsGrid, "eventsGrid");
            this.eventsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.Type,
            this.Description,
            this.Date});
            this.eventsGrid.Name = "eventsGrid";
            // 
            // Title
            // 
            resources.ApplyResources(this.Title, "Title");
            this.Title.Name = "Title";
            // 
            // Type
            // 
            resources.ApplyResources(this.Type, "Type");
            this.Type.Name = "Type";
            // 
            // Description
            // 
            resources.ApplyResources(this.Description, "Description");
            this.Description.Name = "Description";
            // 
            // Date
            // 
            resources.ApplyResources(this.Date, "Date");
            this.Date.Name = "Date";
            // 
            // endDateLabel
            // 
            resources.ApplyResources(this.endDateLabel, "endDateLabel");
            this.endDateLabel.Name = "endDateLabel";
            // 
            // startDateLabel
            // 
            resources.ApplyResources(this.startDateLabel, "startDateLabel");
            this.startDateLabel.Name = "startDateLabel";
            // 
            // EmergencyEventComponent
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.startDateLabel);
            this.Controls.Add(this.endDateLabel);
            this.Controls.Add(this.eventsGrid);
            this.Controls.Add(this.dateToPicker);
            this.Controls.Add(this.dateFromPicker);
            this.Controls.Add(this.showEvents);
            this.Name = "EmergencyEventComponent";
            ((System.ComponentModel.ISupportInitialize)(this.eventsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button showEvents;
        private DateTimePicker dateFromPicker;
        private DateTimePicker dateToPicker;
        private DataGridView eventsGrid;
        private Label endDateLabel;
        private Label startDateLabel;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Date;
    }
}
