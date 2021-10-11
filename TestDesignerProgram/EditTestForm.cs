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
    public partial class EditTestForm : Form
    {
        List<Question> Questionlist;
        List<string> adressList = new List<string>();
        Test currentTest;
        Answer currentAnswer;
        string pattern;
        Regex regex;
        string path;
        string currentTestPass;
        XmlSerializer formatter;
        int count = 0;
        public EditTestForm()
        {
            InitializeComponent();
            formatter = new XmlSerializer(
            typeof(Test),
            new XmlRootAttribute("Test")
            );
            path = @"TestList";
            DirectoryInfo Dr = new DirectoryInfo(path);
            if (Dr.Exists)
            {
                FileInfo[] files = Dr.GetFiles().Where(p => p.Extension == ".xml").ToArray();
                comboBox1.Items.AddRange(files);
                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
            }
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            CurrentTestClear();
            if (radioButton1.Checked == true)
            {
                comboBox1.Enabled = true;
                buttonOpenFile.Enabled = false;
            }
            if (radioButton2.Checked == true)
            {
                comboBox1.Enabled = false;
                buttonOpenFile.Enabled = true;
            }
        }       

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {

            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
           DialogResult dialogResult= openFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                CurrentQuestionClear();
                currentTest = new Test();
                try
                {
                    using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open))
                    {
                        currentTest = (Test)formatter.Deserialize(fs);
                    }
                    TestInfoLoading();
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("File not found or has incorrect name");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
           

        }

        private void TestInfoLoading()
        {
            textBoxAuthor.Text= currentTest.Author;
            textBoxTestName.Text= currentTest.TestName;
            listBoxQuestionList.Items.AddRange(currentTest.Questions.ToArray());
        }
        private void CurrentTestClear()
        {
            textBoxAuthor.Text = "";
            textBoxTestName.Text = "";
            listBoxQuestionList.Items.Clear();
            currentTest = null;
            CurrentQuestionClear();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentTestClear();
            currentTest = new Test();
            try
            {
                using (FileStream fs = new FileStream(path + "\\" + comboBox1.SelectedItem.ToString(), FileMode.Open))
                {
                    currentTest = (Test)formatter.Deserialize(fs);
                }
                TestInfoLoading();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found or has incorrect name");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void listBoxQuestionList_DoubleClick(object sender, EventArgs e)
        {
            CurrentQuestionClear();
            textBoxQuestion.Text = currentTest.Questions[listBoxQuestionList.SelectedIndex].Description;
            numericUpDownDifficulty.Value = currentTest.Questions[listBoxQuestionList.SelectedIndex].Difficulty;
            foreach (var item in currentTest.Questions[listBoxQuestionList.SelectedIndex].Answers)
            {
                checkedListBoxAnswerList.Items.Add(item, item.IsCorrect);
            }
        }
        private void CurrentQuestionClear()
        {
            textBoxQuestion.Text = "";
            numericUpDownDifficulty.Value = 1;
            checkedListBoxAnswerList.Items.Clear();            
        }

        private void buttonSaveQuestion_Click(object sender, EventArgs e)
        {

        }
    }
}
