
namespace TestSystemClient
{
    partial class PassTestForm
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
            this.groupBoxPassTest = new System.Windows.Forms.GroupBox();
            this.buttonFinish = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.checkedListBoxAnswerList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxQuestion = new System.Windows.Forms.TextBox();
            this.groupBoxPassTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPassTest
            // 
            this.groupBoxPassTest.Controls.Add(this.buttonFinish);
            this.groupBoxPassTest.Controls.Add(this.buttonNext);
            this.groupBoxPassTest.Controls.Add(this.buttonPrevious);
            this.groupBoxPassTest.Controls.Add(this.checkedListBoxAnswerList);
            this.groupBoxPassTest.Controls.Add(this.label1);
            this.groupBoxPassTest.Controls.Add(this.textBoxQuestion);
            this.groupBoxPassTest.Location = new System.Drawing.Point(39, 13);
            this.groupBoxPassTest.Name = "groupBoxPassTest";
            this.groupBoxPassTest.Size = new System.Drawing.Size(695, 425);
            this.groupBoxPassTest.TabIndex = 0;
            this.groupBoxPassTest.TabStop = false;
            // 
            // buttonFinish
            // 
            this.buttonFinish.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonFinish.Location = new System.Drawing.Point(189, 374);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(322, 44);
            this.buttonFinish.TabIndex = 20;
            this.buttonFinish.Text = "Finish Test";
            this.buttonFinish.UseVisualStyleBackColor = false;
            this.buttonFinish.Click += new System.EventHandler(this.buttonFinish_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(354, 324);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(322, 44);
            this.buttonNext.TabIndex = 19;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Location = new System.Drawing.Point(29, 324);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(322, 44);
            this.buttonPrevious.TabIndex = 18;
            this.buttonPrevious.Text = "Previous";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxAnswerList
            // 
            this.checkedListBoxAnswerList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBoxAnswerList.FormattingEnabled = true;
            this.checkedListBoxAnswerList.Location = new System.Drawing.Point(29, 153);
            this.checkedListBoxAnswerList.Name = "checkedListBoxAnswerList";
            this.checkedListBoxAnswerList.ScrollAlwaysVisible = true;
            this.checkedListBoxAnswerList.Size = new System.Drawing.Size(644, 165);
            this.checkedListBoxAnswerList.TabIndex = 17;
            this.checkedListBoxAnswerList.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxAnswerList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose the answer";
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxQuestion.Location = new System.Drawing.Point(29, 43);
            this.textBoxQuestion.Multiline = true;
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.ReadOnly = true;
            this.textBoxQuestion.Size = new System.Drawing.Size(644, 86);
            this.textBoxQuestion.TabIndex = 0;
            // 
            // PassTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxPassTest);
            this.Name = "PassTestForm";
            this.Text = "PassTestForm";
            this.groupBoxPassTest.ResumeLayout(false);
            this.groupBoxPassTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPassTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxQuestion;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.CheckedListBox checkedListBoxAnswerList;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonFinish;
    }
}