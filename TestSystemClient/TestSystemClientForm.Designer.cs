
namespace TestSystemClient
{
    partial class TestSystemClientForm
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
            this.tabControlGroupManage = new System.Windows.Forms.TabControl();
            this.tabPageConnect = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxPortNumber = new System.Windows.Forms.TextBox();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxServerName = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemResults = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuStrip4 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.passTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTestSelect = new System.Windows.Forms.DataGridView();
            this.textBoxFromServerMessages = new System.Windows.Forms.TextBox();
            this.tabControlGroupManage.SuspendLayout();
            this.tabPageConnect.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.menuStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlGroupManage
            // 
            this.tabControlGroupManage.Controls.Add(this.tabPageConnect);
            this.tabControlGroupManage.Controls.Add(this.tabPage1);
            this.tabControlGroupManage.Controls.Add(this.tabPage2);
            this.tabControlGroupManage.Location = new System.Drawing.Point(12, 12);
            this.tabControlGroupManage.Name = "tabControlGroupManage";
            this.tabControlGroupManage.SelectedIndex = 0;
            this.tabControlGroupManage.Size = new System.Drawing.Size(825, 342);
            this.tabControlGroupManage.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControlGroupManage.TabIndex = 14;
            // 
            // tabPageConnect
            // 
            this.tabPageConnect.Controls.Add(this.panel2);
            this.tabPageConnect.Location = new System.Drawing.Point(4, 29);
            this.tabPageConnect.Name = "tabPageConnect";
            this.tabPageConnect.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConnect.Size = new System.Drawing.Size(817, 309);
            this.tabPageConnect.TabIndex = 5;
            this.tabPageConnect.Text = "Connect";
            this.tabPageConnect.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxFromServerMessages);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.textBoxPortNumber);
            this.panel2.Controls.Add(this.buttonDisconnect);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.textBoxServerName);
            this.panel2.Controls.Add(this.buttonConnect);
            this.panel2.Location = new System.Drawing.Point(45, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(619, 272);
            this.panel2.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(35, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 20);
            this.label14.TabIndex = 23;
            this.label14.Text = "Port";
            // 
            // textBoxPortNumber
            // 
            this.textBoxPortNumber.Location = new System.Drawing.Point(142, 43);
            this.textBoxPortNumber.Name = "textBoxPortNumber";
            this.textBoxPortNumber.Size = new System.Drawing.Size(159, 26);
            this.textBoxPortNumber.TabIndex = 22;
            this.textBoxPortNumber.Text = "33000";
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Enabled = false;
            this.buttonDisconnect.Location = new System.Drawing.Point(465, 8);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(119, 61);
            this.buttonDisconnect.TabIndex = 17;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(35, 14);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(101, 20);
            this.label18.TabIndex = 7;
            this.label18.Text = "Server Name";
            // 
            // textBoxServerName
            // 
            this.textBoxServerName.Enabled = false;
            this.textBoxServerName.Location = new System.Drawing.Point(142, 11);
            this.textBoxServerName.Name = "textBoxServerName";
            this.textBoxServerName.Size = new System.Drawing.Size(159, 26);
            this.textBoxServerName.TabIndex = 8;
            this.textBoxServerName.Text = "localhost";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(327, 8);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(119, 61);
            this.buttonConnect.TabIndex = 9;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.menuStrip1);
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(817, 309);
            this.tabPage1.TabIndex = 6;
            this.tabPage1.Text = "Results";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(3);
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemResults});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(146, 33);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemResults
            // 
            this.toolStripMenuItemResults.Name = "toolStripMenuItemResults";
            this.toolStripMenuItemResults.Size = new System.Drawing.Size(127, 29);
            this.toolStripMenuItemResults.Text = "Load Results";
            this.toolStripMenuItemResults.Click += new System.EventHandler(this.toolStripMenuItemResults_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 39);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(748, 264);
            this.dataGridView2.TabIndex = 17;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.menuStrip4);
            this.tabPage2.Controls.Add(this.dataGridViewTestSelect);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(817, 309);
            this.tabPage2.TabIndex = 7;
            this.tabPage2.Text = "Test Manage";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // menuStrip4
            // 
            this.menuStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip4.GripMargin = new System.Windows.Forms.Padding(3);
            this.menuStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip4.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.passTestToolStripMenuItem});
            this.menuStrip4.Location = new System.Drawing.Point(3, 3);
            this.menuStrip4.Name = "menuStrip4";
            this.menuStrip4.Size = new System.Drawing.Size(218, 33);
            this.menuStrip4.TabIndex = 9;
            this.menuStrip4.Text = "menuStrip4";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(102, 29);
            this.toolStripMenuItem2.Text = "Load Test";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // passTestToolStripMenuItem
            // 
            this.passTestToolStripMenuItem.Name = "passTestToolStripMenuItem";
            this.passTestToolStripMenuItem.Size = new System.Drawing.Size(97, 29);
            this.passTestToolStripMenuItem.Text = "Pass Test";
            this.passTestToolStripMenuItem.Click += new System.EventHandler(this.passTestToolStripMenuItem_Click);
            // 
            // dataGridViewTestSelect
            // 
            this.dataGridViewTestSelect.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewTestSelect.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewTestSelect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTestSelect.Location = new System.Drawing.Point(6, 39);
            this.dataGridViewTestSelect.MultiSelect = false;
            this.dataGridViewTestSelect.Name = "dataGridViewTestSelect";
            this.dataGridViewTestSelect.RowHeadersWidth = 62;
            this.dataGridViewTestSelect.RowTemplate.Height = 28;
            this.dataGridViewTestSelect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTestSelect.Size = new System.Drawing.Size(465, 264);
            this.dataGridViewTestSelect.TabIndex = 10;
            // 
            // textBoxFromServerMessages
            // 
            this.textBoxFromServerMessages.Location = new System.Drawing.Point(39, 75);
            this.textBoxFromServerMessages.Multiline = true;
            this.textBoxFromServerMessages.Name = "textBoxFromServerMessages";
            this.textBoxFromServerMessages.Size = new System.Drawing.Size(545, 179);
            this.textBoxFromServerMessages.TabIndex = 24;
            // 
            // TestSystemClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 356);
            this.Controls.Add(this.tabControlGroupManage);
            this.Name = "TestSystemClientForm";
            this.Text = "ClientForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestSystemClientForm_FormClosing);
            this.tabControlGroupManage.ResumeLayout(false);
            this.tabPageConnect.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.menuStrip4.ResumeLayout(false);
            this.menuStrip4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTestSelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlGroupManage;
        private System.Windows.Forms.TabPage tabPageConnect;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox textBoxPortNumber;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxServerName;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.DataGridView dataGridViewTestSelect;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemResults;
        private System.Windows.Forms.ToolStripMenuItem passTestToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxFromServerMessages;
    }
}

