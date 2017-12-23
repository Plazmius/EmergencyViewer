using CommonServiceLocator;
using EmergencyEventComponent;
using Unity.ServiceLocation;

namespace EmergencyEventViewer
{
    partial class EventViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventViewer));
            EmergencyEventComponent.IEmergencyEventStorage emergencyEventStorage2 = ServiceLocator.Current.GetInstance<IEmergencyEventStorage>();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.componentInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.emergencyEventComponent1 = new EmergencyEventComponent.EmergencyEventComponent(emergencyEventStorage2);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.emergencyEventAppender1 = new EmergencyEventAppender.EmergencyEventAppender();
            this.menuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.componentInfoToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            // 
            // componentInfoToolStripMenuItem
            // 
            resources.ApplyResources(this.componentInfoToolStripMenuItem, "componentInfoToolStripMenuItem");
            this.componentInfoToolStripMenuItem.Name = "componentInfoToolStripMenuItem";
            this.componentInfoToolStripMenuItem.Click += new System.EventHandler(this.componentInfoToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.emergencyEventComponent1);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // emergencyEventComponent1
            // 
            resources.ApplyResources(this.emergencyEventComponent1, "emergencyEventComponent1");
            this.emergencyEventComponent1.Storage = emergencyEventStorage2;
            this.emergencyEventComponent1.Name = "emergencyEventComponent1";
            this.emergencyEventComponent1.Load += new System.EventHandler(this.emergencyEventComponent1_Load);
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.emergencyEventAppender1);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // emergencyEventAppender1
            // 
            resources.ApplyResources(this.emergencyEventAppender1, "emergencyEventAppender1");
            this.emergencyEventAppender1.Name = "emergencyEventAppender1";
            this.emergencyEventAppender1.Load += new System.EventHandler(this.emergencyEventAppender1_Load);
            // 
            // EventViewer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "EventViewer";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EmergencyEventComponent.EmergencyEventComponent emergencyEventComponent1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem componentInfoToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private EmergencyEventAppender.EmergencyEventAppender emergencyEventAppender1;
    }
}

