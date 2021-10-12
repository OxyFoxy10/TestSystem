
namespace TestDesignerProgram
{
    partial class TestDesignerForm
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
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.textBoxTestName = new System.Windows.Forms.TextBox();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxQuestion = new System.Windows.Forms.GroupBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.numericUpDownDifficulty = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxQuestion = new System.Windows.Forms.TextBox();
            this.groupBoxAnwersList = new System.Windows.Forms.GroupBox();
            this.buttonEditAnswer = new System.Windows.Forms.Button();
            this.checkedListBoxAnswerList = new System.Windows.Forms.CheckedListBox();
            this.textBoxAnswer = new System.Windows.Forms.TextBox();
            this.groupBoxAnswer = new System.Windows.Forms.GroupBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.checkBoxIsCorrect = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxInfo.SuspendLayout();
            this.groupBoxQuestion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDifficulty)).BeginInit();
            this.groupBoxAnwersList.SuspendLayout();
            this.groupBoxAnswer.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.textBoxTestName);
            this.groupBoxInfo.Controls.Add(this.textBoxAuthor);
            this.groupBoxInfo.Controls.Add(this.label2);
            this.groupBoxInfo.Controls.Add(this.label1);
            this.groupBoxInfo.Location = new System.Drawing.Point(24, 13);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(341, 120);
            this.groupBoxInfo.TabIndex = 0;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Info";
            // 
            // textBoxTestName
            // 
            this.textBoxTestName.Location = new System.Drawing.Point(110, 66);
            this.textBoxTestName.Name = "textBoxTestName";
            this.textBoxTestName.Size = new System.Drawing.Size(214, 26);
            this.textBoxTestName.TabIndex = 3;
            this.textBoxTestName.TextChanged += new System.EventHandler(this.textBoxTestName_TextChanged);
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(110, 30);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(214, 26);
            this.textBoxAuthor.TabIndex = 2;
            this.textBoxAuthor.TextChanged += new System.EventHandler(this.textBoxAuthor_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Test Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Author";
            // 
            // groupBoxQuestion
            // 
            this.groupBoxQuestion.Controls.Add(this.buttonOk);
            this.groupBoxQuestion.Controls.Add(this.numericUpDownDifficulty);
            this.groupBoxQuestion.Controls.Add(this.label5);
            this.groupBoxQuestion.Controls.Add(this.textBoxQuestion);
            this.groupBoxQuestion.Location = new System.Drawing.Point(399, 13);
            this.groupBoxQuestion.Name = "groupBoxQuestion";
            this.groupBoxQuestion.Size = new System.Drawing.Size(347, 187);
            this.groupBoxQuestion.TabIndex = 1;
            this.groupBoxQuestion.TabStop = false;
            this.groupBoxQuestion.Text = "Question";
            // 
            // buttonOk
            // 
            this.buttonOk.Enabled = false;
            this.buttonOk.Location = new System.Drawing.Point(267, 122);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(64, 36);
            this.buttonOk.TabIndex = 8;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // numericUpDownDifficulty
            // 
            this.numericUpDownDifficulty.Location = new System.Drawing.Point(117, 132);
            this.numericUpDownDifficulty.Name = "numericUpDownDifficulty";
            this.numericUpDownDifficulty.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownDifficulty.TabIndex = 6;
            this.numericUpDownDifficulty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Difficulty";
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.Location = new System.Drawing.Point(25, 30);
            this.textBoxQuestion.Multiline = true;
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.Size = new System.Drawing.Size(306, 83);
            this.textBoxQuestion.TabIndex = 4;
            this.textBoxQuestion.TextChanged += new System.EventHandler(this.textBoxQuestion_TextChanged);
            // 
            // groupBoxAnwersList
            // 
            this.groupBoxAnwersList.Controls.Add(this.buttonEditAnswer);
            this.groupBoxAnwersList.Controls.Add(this.checkedListBoxAnswerList);
            this.groupBoxAnwersList.Location = new System.Drawing.Point(24, 162);
            this.groupBoxAnwersList.Name = "groupBoxAnwersList";
            this.groupBoxAnwersList.Size = new System.Drawing.Size(341, 220);
            this.groupBoxAnwersList.TabIndex = 1;
            this.groupBoxAnwersList.TabStop = false;
            this.groupBoxAnwersList.Text = "Answers List";
            // 
            // buttonEditAnswer
            // 
            this.buttonEditAnswer.Location = new System.Drawing.Point(10, 174);
            this.buttonEditAnswer.Name = "buttonEditAnswer";
            this.buttonEditAnswer.Size = new System.Drawing.Size(314, 34);
            this.buttonEditAnswer.TabIndex = 11;
            this.buttonEditAnswer.Text = "Edit Correct Answer";
            this.buttonEditAnswer.UseVisualStyleBackColor = true;
            this.buttonEditAnswer.Click += new System.EventHandler(this.buttonEditAnswer_Click);
            // 
            // checkedListBoxAnswerList
            // 
            this.checkedListBoxAnswerList.CheckOnClick = true;
            this.checkedListBoxAnswerList.FormattingEnabled = true;
            this.checkedListBoxAnswerList.Location = new System.Drawing.Point(10, 25);
            this.checkedListBoxAnswerList.Name = "checkedListBoxAnswerList";
            this.checkedListBoxAnswerList.Size = new System.Drawing.Size(314, 142);
            this.checkedListBoxAnswerList.TabIndex = 0;
            this.checkedListBoxAnswerList.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxAnswerList_SelectedIndexChanged);
            // 
            // textBoxAnswer
            // 
            this.textBoxAnswer.Enabled = false;
            this.textBoxAnswer.Location = new System.Drawing.Point(25, 25);
            this.textBoxAnswer.Multiline = true;
            this.textBoxAnswer.Name = "textBoxAnswer";
            this.textBoxAnswer.Size = new System.Drawing.Size(306, 92);
            this.textBoxAnswer.TabIndex = 6;
            this.textBoxAnswer.TextChanged += new System.EventHandler(this.textBoxAnswer_TextChanged);
            // 
            // groupBoxAnswer
            // 
            this.groupBoxAnswer.Controls.Add(this.buttonAdd);
            this.groupBoxAnswer.Controls.Add(this.checkBoxIsCorrect);
            this.groupBoxAnswer.Controls.Add(this.textBoxAnswer);
            this.groupBoxAnswer.Location = new System.Drawing.Point(399, 206);
            this.groupBoxAnswer.Name = "groupBoxAnswer";
            this.groupBoxAnswer.Size = new System.Drawing.Size(347, 164);
            this.groupBoxAnswer.TabIndex = 2;
            this.groupBoxAnswer.TabStop = false;
            this.groupBoxAnswer.Text = "Answer";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Enabled = false;
            this.buttonAdd.Location = new System.Drawing.Point(267, 123);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(64, 36);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // checkBoxIsCorrect
            // 
            this.checkBoxIsCorrect.AutoSize = true;
            this.checkBoxIsCorrect.Location = new System.Drawing.Point(25, 123);
            this.checkBoxIsCorrect.Name = "checkBoxIsCorrect";
            this.checkBoxIsCorrect.Size = new System.Drawing.Size(100, 24);
            this.checkBoxIsCorrect.TabIndex = 8;
            this.checkBoxIsCorrect.Text = "IsCorrect";
            this.checkBoxIsCorrect.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(765, 22);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(80, 348);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // TestDesignerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 394);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxAnswer);
            this.Controls.Add(this.groupBoxAnwersList);
            this.Controls.Add(this.groupBoxQuestion);
            this.Controls.Add(this.groupBoxInfo);
            this.Name = "TestDesignerForm";
            this.Text = "Create New Test";
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.groupBoxQuestion.ResumeLayout(false);
            this.groupBoxQuestion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDifficulty)).EndInit();
            this.groupBoxAnwersList.ResumeLayout(false);
            this.groupBoxAnswer.ResumeLayout(false);
            this.groupBoxAnswer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxQuestion;
        private System.Windows.Forms.GroupBox groupBoxAnwersList;
        private System.Windows.Forms.TextBox textBoxTestName;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.NumericUpDown numericUpDownDifficulty;
        private System.Windows.Forms.TextBox textBoxAnswer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxQuestion;
        private System.Windows.Forms.GroupBox groupBoxAnswer;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.CheckBox checkBoxIsCorrect;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckedListBox checkedListBoxAnswerList;
        private System.Windows.Forms.Button buttonEditAnswer;
    }
}

