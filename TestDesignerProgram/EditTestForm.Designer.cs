
namespace TestDesignerProgram
{
    partial class EditTestForm
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
            this.groupBoxChooseTest = new System.Windows.Forms.GroupBox();
            this.listBoxQuestionList = new System.Windows.Forms.ListBox();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBoxQuestionList = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxQuestion = new System.Windows.Forms.TextBox();
            this.groupBoxQuestion = new System.Windows.Forms.GroupBox();
            this.buttonSaveQuestion = new System.Windows.Forms.Button();
            this.checkedListBoxAnswerList = new System.Windows.Forms.CheckedListBox();
            this.textBoxTestName = new System.Windows.Forms.TextBox();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownDifficulty = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonRemoveQuestion = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxChooseTest.SuspendLayout();
            this.groupBoxQuestionList.SuspendLayout();
            this.groupBoxQuestion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDifficulty)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxChooseTest
            // 
            this.groupBoxChooseTest.Controls.Add(this.comboBox1);
            this.groupBoxChooseTest.Controls.Add(this.radioButton2);
            this.groupBoxChooseTest.Controls.Add(this.radioButton1);
            this.groupBoxChooseTest.Controls.Add(this.buttonOpenFile);
            this.groupBoxChooseTest.Location = new System.Drawing.Point(41, 25);
            this.groupBoxChooseTest.Name = "groupBoxChooseTest";
            this.groupBoxChooseTest.Size = new System.Drawing.Size(258, 190);
            this.groupBoxChooseTest.TabIndex = 0;
            this.groupBoxChooseTest.TabStop = false;
            this.groupBoxChooseTest.Text = "choose Test";
            // 
            // listBoxQuestionList
            // 
            this.listBoxQuestionList.FormattingEnabled = true;
            this.listBoxQuestionList.ItemHeight = 20;
            this.listBoxQuestionList.Location = new System.Drawing.Point(19, 120);
            this.listBoxQuestionList.Name = "listBoxQuestionList";
            this.listBoxQuestionList.ScrollAlwaysVisible = true;
            this.listBoxQuestionList.Size = new System.Drawing.Size(308, 164);
            this.listBoxQuestionList.TabIndex = 1;
            this.listBoxQuestionList.DoubleClick += new System.EventHandler(this.listBoxQuestionList_DoubleClick);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Enabled = false;
            this.buttonOpenFile.Location = new System.Drawing.Point(16, 114);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(194, 38);
            this.buttonOpenFile.TabIndex = 2;
            this.buttonOpenFile.Text = "Open File from PC";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(16, 26);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(228, 24);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "choose file from ComboBox";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(16, 84);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(174, 24);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "Choose file from PC";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBoxQuestionList
            // 
            this.groupBoxQuestionList.Controls.Add(this.buttonRemoveQuestion);
            this.groupBoxQuestionList.Controls.Add(this.button2);
            this.groupBoxQuestionList.Controls.Add(this.textBoxTestName);
            this.groupBoxQuestionList.Controls.Add(this.textBoxAuthor);
            this.groupBoxQuestionList.Controls.Add(this.label2);
            this.groupBoxQuestionList.Controls.Add(this.label1);
            this.groupBoxQuestionList.Controls.Add(this.listBoxQuestionList);
            this.groupBoxQuestionList.Location = new System.Drawing.Point(314, 36);
            this.groupBoxQuestionList.Name = "groupBoxQuestionList";
            this.groupBoxQuestionList.Size = new System.Drawing.Size(351, 376);
            this.groupBoxQuestionList.TabIndex = 1;
            this.groupBoxQuestionList.TabStop = false;
            this.groupBoxQuestionList.Text = "groupBox1";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(16, 50);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(194, 28);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.Location = new System.Drawing.Point(17, 34);
            this.textBoxQuestion.Multiline = true;
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.Size = new System.Drawing.Size(314, 80);
            this.textBoxQuestion.TabIndex = 2;
            // 
            // groupBoxQuestion
            // 
            this.groupBoxQuestion.Controls.Add(this.numericUpDownDifficulty);
            this.groupBoxQuestion.Controls.Add(this.label5);
            this.groupBoxQuestion.Controls.Add(this.buttonSaveQuestion);
            this.groupBoxQuestion.Controls.Add(this.textBoxQuestion);
            this.groupBoxQuestion.Controls.Add(this.checkedListBoxAnswerList);
            this.groupBoxQuestion.Location = new System.Drawing.Point(686, 36);
            this.groupBoxQuestion.Name = "groupBoxQuestion";
            this.groupBoxQuestion.Size = new System.Drawing.Size(353, 376);
            this.groupBoxQuestion.TabIndex = 4;
            this.groupBoxQuestion.TabStop = false;
            this.groupBoxQuestion.Text = "Question";
            // 
            // buttonSaveQuestion
            // 
            this.buttonSaveQuestion.Location = new System.Drawing.Point(17, 333);
            this.buttonSaveQuestion.Name = "buttonSaveQuestion";
            this.buttonSaveQuestion.Size = new System.Drawing.Size(314, 37);
            this.buttonSaveQuestion.TabIndex = 11;
            this.buttonSaveQuestion.Text = "Save changes";
            this.buttonSaveQuestion.UseVisualStyleBackColor = true;
            this.buttonSaveQuestion.Click += new System.EventHandler(this.buttonSaveQuestion_Click);
            // 
            // checkedListBoxAnswerList
            // 
            this.checkedListBoxAnswerList.CheckOnClick = true;
            this.checkedListBoxAnswerList.FormattingEnabled = true;
            this.checkedListBoxAnswerList.Location = new System.Drawing.Point(17, 162);
            this.checkedListBoxAnswerList.Name = "checkedListBoxAnswerList";
            this.checkedListBoxAnswerList.Size = new System.Drawing.Size(314, 165);
            this.checkedListBoxAnswerList.TabIndex = 0;
            // 
            // textBoxTestName
            // 
            this.textBoxTestName.Location = new System.Drawing.Point(113, 78);
            this.textBoxTestName.Name = "textBoxTestName";
            this.textBoxTestName.Size = new System.Drawing.Size(214, 26);
            this.textBoxTestName.TabIndex = 7;
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(113, 36);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(214, 26);
            this.textBoxAuthor.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Test Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Author";
            // 
            // numericUpDownDifficulty
            // 
            this.numericUpDownDifficulty.Location = new System.Drawing.Point(100, 120);
            this.numericUpDownDifficulty.Name = "numericUpDownDifficulty";
            this.numericUpDownDifficulty.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownDifficulty.TabIndex = 13;
            this.numericUpDownDifficulty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Difficulty";
            // 
            // buttonRemoveQuestion
            // 
            this.buttonRemoveQuestion.Location = new System.Drawing.Point(19, 333);
            this.buttonRemoveQuestion.Name = "buttonRemoveQuestion";
            this.buttonRemoveQuestion.Size = new System.Drawing.Size(308, 37);
            this.buttonRemoveQuestion.TabIndex = 14;
            this.buttonRemoveQuestion.Text = "Remove question";
            this.buttonRemoveQuestion.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(19, 290);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(308, 37);
            this.button2.TabIndex = 15;
            this.button2.Text = "Add Question";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // EditTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 450);
            this.Controls.Add(this.groupBoxQuestion);
            this.Controls.Add(this.groupBoxQuestionList);
            this.Controls.Add(this.groupBoxChooseTest);
            this.Name = "EditTestForm";
            this.Text = "EditTestForm";
            this.groupBoxChooseTest.ResumeLayout(false);
            this.groupBoxChooseTest.PerformLayout();
            this.groupBoxQuestionList.ResumeLayout(false);
            this.groupBoxQuestionList.PerformLayout();
            this.groupBoxQuestion.ResumeLayout(false);
            this.groupBoxQuestion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDifficulty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxChooseTest;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.ListBox listBoxQuestionList;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBoxQuestionList;
        private System.Windows.Forms.TextBox textBoxQuestion;
        private System.Windows.Forms.GroupBox groupBoxQuestion;
        private System.Windows.Forms.Button buttonSaveQuestion;
        private System.Windows.Forms.CheckedListBox checkedListBoxAnswerList;
        private System.Windows.Forms.TextBox textBoxTestName;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownDifficulty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonRemoveQuestion;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}