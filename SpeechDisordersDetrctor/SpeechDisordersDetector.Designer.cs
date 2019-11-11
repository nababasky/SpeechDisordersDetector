namespace SpeechDisordersDetrctor
{
    partial class SpeechDisordersDetector
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dataObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelReadyFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawDataPanel = new System.Windows.Forms.Panel();
            this.predictionPanel = new System.Windows.Forms.Panel();
            this.loadFileButton = new System.Windows.Forms.Button();
            this.predictionLabel = new System.Windows.Forms.Label();
            this.sampleRateValue = new System.Windows.Forms.Label();
            this.sampleRate = new System.Windows.Forms.Label();
            this.selectedFolder = new System.Windows.Forms.Label();
            this.selectedFolderUrl = new System.Windows.Forms.Label();
            this.AddFolderRawData = new System.Windows.Forms.Button();
            this.AddRawDataLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.rawDataPanel.SuspendLayout();
            this.predictionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataObjectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dataObjectToolStripMenuItem
            // 
            this.dataObjectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rawDataToolStripMenuItem,
            this.modelReadyFilesToolStripMenuItem});
            this.dataObjectToolStripMenuItem.Name = "dataObjectToolStripMenuItem";
            this.dataObjectToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.dataObjectToolStripMenuItem.Text = "Data Object";
            // 
            // rawDataToolStripMenuItem
            // 
            this.rawDataToolStripMenuItem.Name = "rawDataToolStripMenuItem";
            this.rawDataToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.rawDataToolStripMenuItem.Text = "Raw Data";
            this.rawDataToolStripMenuItem.Click += new System.EventHandler(this.rawDataToolStripMenuItem_Click_1);
            // 
            // modelReadyFilesToolStripMenuItem
            // 
            this.modelReadyFilesToolStripMenuItem.Name = "modelReadyFilesToolStripMenuItem";
            this.modelReadyFilesToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.modelReadyFilesToolStripMenuItem.Text = "Model Ready Files";
            this.modelReadyFilesToolStripMenuItem.Click += new System.EventHandler(this.modelReadyFilesToolStripMenuItem_Click);
            // 
            // rawDataPanel
            // 
            this.rawDataPanel.Controls.Add(this.predictionPanel);
            this.rawDataPanel.Controls.Add(this.sampleRateValue);
            this.rawDataPanel.Controls.Add(this.sampleRate);
            this.rawDataPanel.Controls.Add(this.selectedFolder);
            this.rawDataPanel.Controls.Add(this.selectedFolderUrl);
            this.rawDataPanel.Controls.Add(this.AddFolderRawData);
            this.rawDataPanel.Controls.Add(this.AddRawDataLabel);
            this.rawDataPanel.Location = new System.Drawing.Point(13, 28);
            this.rawDataPanel.Name = "rawDataPanel";
            this.rawDataPanel.Size = new System.Drawing.Size(775, 410);
            this.rawDataPanel.TabIndex = 1;
            this.rawDataPanel.Visible = false;
            // 
            // predictionPanel
            // 
            this.predictionPanel.Controls.Add(this.listView1);
            this.predictionPanel.Controls.Add(this.label1);
            this.predictionPanel.Controls.Add(this.loadFileButton);
            this.predictionPanel.Controls.Add(this.predictionLabel);
            this.predictionPanel.Location = new System.Drawing.Point(0, 0);
            this.predictionPanel.Name = "predictionPanel";
            this.predictionPanel.Size = new System.Drawing.Size(775, 410);
            this.predictionPanel.TabIndex = 6;
            this.predictionPanel.Visible = false;
            // 
            // loadFileButton
            // 
            this.loadFileButton.Location = new System.Drawing.Point(688, 14);
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.Size = new System.Drawing.Size(75, 23);
            this.loadFileButton.TabIndex = 2;
            this.loadFileButton.Text = "Load File";
            this.loadFileButton.UseVisualStyleBackColor = true;
            this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);
            // 
            // predictionLabel
            // 
            this.predictionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.predictionLabel.Location = new System.Drawing.Point(3, 14);
            this.predictionLabel.Name = "predictionLabel";
            this.predictionLabel.Size = new System.Drawing.Size(157, 25);
            this.predictionLabel.TabIndex = 1;
            this.predictionLabel.Text = "Prediction";
            // 
            // sampleRateValue
            // 
            this.sampleRateValue.AutoSize = true;
            this.sampleRateValue.Location = new System.Drawing.Point(88, 67);
            this.sampleRateValue.Name = "sampleRateValue";
            this.sampleRateValue.Size = new System.Drawing.Size(0, 13);
            this.sampleRateValue.TabIndex = 5;
            // 
            // sampleRate
            // 
            this.sampleRate.AutoSize = true;
            this.sampleRate.Location = new System.Drawing.Point(4, 67);
            this.sampleRate.Name = "sampleRate";
            this.sampleRate.Size = new System.Drawing.Size(71, 13);
            this.sampleRate.TabIndex = 4;
            this.sampleRate.Text = "Sample Rate:";
            // 
            // selectedFolder
            // 
            this.selectedFolder.AutoSize = true;
            this.selectedFolder.Location = new System.Drawing.Point(90, 44);
            this.selectedFolder.Name = "selectedFolder";
            this.selectedFolder.Size = new System.Drawing.Size(0, 13);
            this.selectedFolder.TabIndex = 3;
            // 
            // selectedFolderUrl
            // 
            this.selectedFolderUrl.Location = new System.Drawing.Point(4, 44);
            this.selectedFolderUrl.Name = "selectedFolderUrl";
            this.selectedFolderUrl.Size = new System.Drawing.Size(89, 23);
            this.selectedFolderUrl.TabIndex = 2;
            this.selectedFolderUrl.Text = "Selected Folder:";
            // 
            // AddFolderRawData
            // 
            this.AddFolderRawData.Location = new System.Drawing.Point(688, 12);
            this.AddFolderRawData.Name = "AddFolderRawData";
            this.AddFolderRawData.Size = new System.Drawing.Size(75, 23);
            this.AddFolderRawData.TabIndex = 1;
            this.AddFolderRawData.Text = "Add Folder";
            this.AddFolderRawData.UseVisualStyleBackColor = true;
            this.AddFolderRawData.Click += new System.EventHandler(this.AddFolderRawData_Click);
            // 
            // AddRawDataLabel
            // 
            this.AddRawDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddRawDataLabel.Location = new System.Drawing.Point(3, 9);
            this.AddRawDataLabel.Name = "AddRawDataLabel";
            this.AddRawDataLabel.Size = new System.Drawing.Size(157, 25);
            this.AddRawDataLabel.TabIndex = 0;
            this.AddRawDataLabel.Text = "Add Raw Data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Actual Result - Expected Result";
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(10, 71);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(753, 336);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // SpeechDisordersDetector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rawDataPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SpeechDisordersDetector";
            this.Text = "SpeechDisordersDetector";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.rawDataPanel.ResumeLayout(false);
            this.rawDataPanel.PerformLayout();
            this.predictionPanel.ResumeLayout(false);
            this.predictionPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dataObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modelReadyFilesToolStripMenuItem;
        private System.Windows.Forms.Panel rawDataPanel;
        private System.Windows.Forms.Label AddRawDataLabel;
        private System.Windows.Forms.Button AddFolderRawData;
        private System.Windows.Forms.Label selectedFolder;
        private System.Windows.Forms.Label selectedFolderUrl;
        private System.Windows.Forms.Label sampleRateValue;
        private System.Windows.Forms.Label sampleRate;
        private System.Windows.Forms.Panel predictionPanel;
        private System.Windows.Forms.Button loadFileButton;
        private System.Windows.Forms.Label predictionLabel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
    }
}

