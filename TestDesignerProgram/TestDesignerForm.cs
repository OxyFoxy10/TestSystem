using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using TestDesignerDll;

namespace TestDesignerProgram
{
    public partial class TestDesignerForm : Form
    {
        List<Question> Questionlist;
        Test currentTest;
        Answer currentAnswer;
        string pattern;
        Regex regex;
        string path;
        string currentTestPass;
        XmlSerializer formatter;
        int count = 0;
        public TestDesignerForm()
        {
            InitializeComponent();
            formatter = new XmlSerializer(
            typeof(Test),
            new XmlRootAttribute("Test")
            );
            path = @"TestList";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            directoryInfo.Create();
            Questionlist = new List<Question>();
            currentTest = new Test();
            pattern = @"^[?!',.0-9a-zA-ZöäüÖÄÜа-яА-ЯёЁїЇґҐіІ\s-]+$";
            regex = new Regex(pattern);
        }

        private void textBoxAuthor_TextChanged(object sender, EventArgs e)
        {
            currentTest.Author = textBoxAuthor.Text;
        }
        private void textBoxTestName_TextChanged(object sender, EventArgs e)
        {
            bool success = regex.IsMatch(textBoxTestName.Text);
            if (success)
            {
                currentTest.TestName = textBoxTestName.Text;
                currentTestPass = path + "\\" + currentTest.TestName + ".xml";
                buttonSave.Enabled = true;
            }
            else MessageBox.Show(String.Format("String \"{0}\" doesn\'t correspont template \"{1}\"", textBoxTestName.Text, pattern));

        }
       
        private void textBoxQuestion_TextChanged(object sender, EventArgs e)
        {
            if (textBoxQuestion.Text == "")
            {
                buttonOk.Enabled = false;
            }
            else
            {
                buttonOk.Enabled = true;
            }
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            count++;
            currentTest.Questions.Add(new Question() { Description = textBoxQuestion.Text, Number = count, Difficulty = Convert.ToInt32(numericUpDownDifficulty.Value) });
            textBoxAnswer.Enabled = true;
            checkedListBoxAnswerList.Items.Clear();
            textBoxQuestion.Text = "";

        }

        private void textBoxAnswer_TextChanged(object sender, EventArgs e)
        {
            if (textBoxAnswer.Text == "")
            {
                buttonAdd.Enabled = false;
            }
            else
            {
                buttonAdd.Enabled = true;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            currentTest.Questions[count - 1].Answers.Add(new Answer() { Description = textBoxAnswer.Text });
            currentTest.QuestionCount++;
            currentAnswer = new Answer();
            currentAnswer.Description = textBoxAnswer.Text;
            if (checkBoxIsCorrect.CheckState == CheckState.Checked)
                currentAnswer.IsCorrect = true;
            else currentAnswer.IsCorrect = false;
            if (currentTest.Questions[count - 1].Answers.Contains(currentAnswer) == false)
                currentTest.Questions[count - 1].Answers.Add(currentAnswer);
            if (checkedListBoxAnswerList.Items.Contains(currentAnswer) == false)
            {
                if (currentAnswer.IsCorrect == true)
                {
                    checkedListBoxAnswerList.Items.Add(currentAnswer, CheckState.Checked);
                }
                else { checkedListBoxAnswerList.Items.Add(currentAnswer, CheckState.Unchecked); }
            }
            else MessageBox.Show("Same answer is already added");
            textBoxAnswer.Text = "";
        }
        private void CheckCorrectAnswer()
        {
            try
            {
                for (int i = 0; i < checkedListBoxAnswerList.Items.Count; i++)
                {
                    currentTest.Questions[count - 1]
                        .Answers
                        .Find(x => x.Description == (checkedListBoxAnswerList.Items[i] as Answer)
                        .Description)
                        .IsCorrect = checkedListBoxAnswerList.GetItemChecked(i);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void checkedListBoxAnswerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonEditAnswer.Enabled = true;
            textBoxAnswer.Text = checkedListBoxAnswerList.SelectedItem.ToString();

            if (checkedListBoxAnswerList.GetItemChecked(checkedListBoxAnswerList.SelectedIndex) == true)
            {
                for (int i = 0; i < checkedListBoxAnswerList.Items.Count; i++)
                {
                    if (i != checkedListBoxAnswerList.SelectedIndex)
                        checkedListBoxAnswerList.SetItemChecked(i, false);
                    else
                        checkedListBoxAnswerList.SetItemChecked(i, true);
                }
                           (checkedListBoxAnswerList.Items[checkedListBoxAnswerList.SelectedIndex] as Answer).IsCorrect = true;
            }
            else (checkedListBoxAnswerList.Items[checkedListBoxAnswerList.SelectedIndex] as Answer).IsCorrect = false;

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream(currentTestPass, FileMode.Create))
            {
                formatter.Serialize(fs, currentTest);
            }
            currentTest = new Test();
        }

        private void buttonEditAnswer_Click(object sender, EventArgs e)
        {
            CheckCorrectAnswer();
            buttonEditAnswer.Enabled = false;
        }
    }
}
