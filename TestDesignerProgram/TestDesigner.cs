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
    public partial class TestDesigner : Form
    {
        List<Question> currentTestQuestionlist;
      //  List<string> adressList = new List<string>();
        Test currentTest;
        Question newQuestion;
        Question editQuestion;
        Question tempQuestion;
        Answer currentAnswer;
        string pattern;
        Regex regex;
        string path;
        string currentTestPass;
        XmlSerializer formatter;
        DirectoryInfo directoryInfo;
        int count = 0;
        bool isQuestionInEdit = false;
        bool isAnswerInEdit = false;
        public TestDesigner()
        {
            InitializeComponent();
            formatter = new XmlSerializer(
           typeof(Test),
           new XmlRootAttribute("Test")
           );
            path = @"TestList";
           directoryInfo = new DirectoryInfo(path);
            directoryInfo.Create();
            currentTestQuestionlist = new List<Question>();
            currentTest = new Test();
           newQuestion = new Question();
           editQuestion = new Question();
            pattern = @"^[?!',.0-9a-zA-ZöäüÖÄÜа-яА-ЯёЁїЇґҐіІ\s-]+$";
            regex = new Regex(pattern);
            if(comboBoxAnswerList.Items.Count>0)
            comboBoxAnswerList.SelectedIndex = 0;     
         
           
        }
        private void buttonCheckTestName_Click(object sender, EventArgs e)
        {
            bool success = regex.IsMatch(textBoxTestName.Text);
            bool checkFile = true;
            int increase = 1;
            if (success)
            {
                currentTestPass = path + "\\" + currentTest.TestName + ".xml";
                groupBoxQuestion.Enabled = true;
                checkFile= File.Exists(currentTestPass);
                while(checkFile)
                {
                    currentTestPass = path + "\\" + currentTest.TestName +increase+ ".xml";
                    increase++;
                    checkFile = File.Exists(currentTestPass);
                }
            }
            else MessageBox.Show(String.Format("String \"{0}\" doesn\'t correspont template \"{1}\"\nPlease try again!", textBoxTestName, pattern));
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            DialogResult dialogResult = openFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                CurrentTestClear2();
                currentTest = new Test();
                try
                {
                    using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open))
                    {
                        currentTest = (Test)formatter.Deserialize(fs);
                    }
                    currentTestPass = openFileDialog1.FileName;
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
            textBoxAuthor2.Text = currentTest.Author;
            textBoxTestName2.Text = currentTest.TestName;
            listBoxQuestionList2.Items.AddRange(currentTest.Questions.ToArray());
            currentTestQuestionlist = currentTest.Questions;
        }
       
        private void CurrentTestClear()
        {
            textBoxAuthor.Text = "";
            textBoxTestName.Text = "";
            listBoxQuestionList.Items.Clear();
            groupBoxQuestion.Enabled = false;
            buttonSaveTest.Enabled = false;
            currentTest = new Test ();
            CurrentQuestionClear();
        }
        private void CurrentTestClear2()
        {
            textBoxAuthor2.Text = "";
            textBoxTestName2.Text = "";
            listBoxQuestionList2.Items.Clear();
            buttonSaveTest2.Enabled = false;
            currentTest = new Test();
            CurrentQuestionClear2();
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentTestClear2();
            currentTest = new Test();
            try
            {
                using (FileStream fs = new FileStream(path + "\\" + toolStripComboBoxChooseFile.SelectedItem.ToString(), FileMode.Open))
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

       
        private void CurrentQuestionClear()
        {
            textBoxQuestion.Text = "";
            numericUpDownDifficulty.Value = 1;
            comboBoxAnswerList.Items.Clear();
            comboBoxAnswerList.Text="";
            newQuestion = new Question();
        }
        private void CurrentQuestionClear2()
        {
            textBoxQuestion2.Text = "";
            textBoxAnswer2.Text = "";
            numericUpDownDifficulty2.Value = 1;
            checkedListBoxAnswerList.Items.Clear();            
            newQuestion = new Question();
            editQuestion = new Question();
        }       

        private void textBoxAuthor_TextChanged(object sender, EventArgs e)
        {
            currentTest.Author = textBoxAuthor.Text;
        }

        private void textBoxTestName_TextChanged(object sender, EventArgs e)
        {
            currentTest.TestName = textBoxTestName.Text;
            groupBoxQuestion.Enabled = false;
        }

        private void buttonSaveQuestion_Click(object sender, EventArgs e)
        {
            bool hasCorrectAnswer = false;
            foreach (Answer item in comboBoxAnswerList.Items)
            {
                if (item.IsCorrect == true)
                    hasCorrectAnswer = true;
            }
            if (hasCorrectAnswer == true)
            {               
                buttonSaveTest.Enabled = true;
                count++;
                newQuestion.Difficulty = Convert.ToInt32(numericUpDownDifficulty.Value);
                newQuestion.Description = textBoxQuestion.Text;
                newQuestion.Number = count;
                for (int i = 0; i < comboBoxAnswerList.Items.Count; i++)
                {
                    newQuestion.Answers.Add(comboBoxAnswerList.Items[i] as Answer);
                }
                if (!listBoxQuestionList.Items.Contains(newQuestion))
                {
                    listBoxQuestionList.Items.Add(newQuestion);

                }
                else { MessageBox.Show("Same question already added"); return; }
                CurrentQuestionClear();
            }
            else MessageBox.Show("There are no correct answer in Answer comboBox, please add one before saving to Question List");

        }

        private void textBoxQuestion_TextChanged(object sender, EventArgs e)
        {            
            if (textBoxQuestion.Text == "")
            {
                textBoxAnswer.Enabled = false;
                buttonRemoveAnswer.Enabled = false;
                buttonAddAnswer.Enabled = false;
                buttonSaveQuestion.Enabled = false;
            }
            else
            {
                textBoxAnswer.Enabled = true;
            }
        }

        private void textBoxAnswer_TextChanged(object sender, EventArgs e)
        {
            buttonAddAnswer.Enabled = true;            
        }

        private void buttonAddAnswer_Click(object sender, EventArgs e)
        {
            currentAnswer = new Answer();
            currentAnswer.Description = textBoxAnswer.Text;
            if (checkBoxIsCorrect.CheckState == CheckState.Checked)
                currentAnswer.IsCorrect = true;
            else currentAnswer.IsCorrect = false;           
            if (!comboBoxAnswerList.Items.Contains(currentAnswer))
            {
                comboBoxAnswerList.Items.Add(currentAnswer);
                comboBoxAnswerList.Text = currentAnswer.Description;
                textBoxAnswer.Text = "";
                buttonAddAnswer.Enabled = false;
                checkBoxIsCorrect.Checked = false;
            }
            else
            {               
                MessageBox.Show("Same answer already added!");
            }          

        }

        private void buttonRemoveAnswer_Click(object sender, EventArgs e)
        {
            if (comboBoxAnswerList.SelectedItem != null)
                comboBoxAnswerList.Items.RemoveAt(comboBoxAnswerList.SelectedIndex);
        }

        private void comboBoxAnswerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAnswerList.Items.Count > 0)
            {
                if (comboBoxAnswerList.SelectedIndex < 0)
                    comboBoxAnswerList.SelectedIndex = 0;
                buttonRemoveAnswer.Enabled = true;
            }
            buttonSaveQuestion.Enabled = true;
        }

        private void buttonSaveTest_Click(object sender, EventArgs e)
        {
            foreach (var item in listBoxQuestionList.Items)
            {
                currentTest.Questions.Add(item as Question);
            }

            using (FileStream fs = new FileStream(currentTestPass, FileMode.Create))
            {
                formatter.Serialize(fs, currentTest);
            }            
            MessageBox.Show("Test saved!");
            CurrentTestClear();
            currentTest = new Test();
        }

        private void buttonRemoveQuestion_Click(object sender, EventArgs e)
        {            
            int indexToDelete = 0;
            if (listBoxQuestionList.Items.Count > 1)
            {
                indexToDelete = listBoxQuestionList.SelectedIndex;
                listBoxQuestionList.Items.RemoveAt(indexToDelete);
                for (int i = 0; i < listBoxQuestionList.Items.Count; i++)
                {
                    (listBoxQuestionList.Items[i] as Question).Number = i + 1;
                }
            }
            else
            {

              DialogResult dialogResult=  MessageBox.Show("Last item cannot be removed! Cancel Test Creating?", "Test Remove quaery!",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    CurrentTestClear();
                }                
            }
            buttonRemoveQuestion.Enabled = false;
        }
        private void textBoxQuestion2_TextChanged(object sender, EventArgs e)
        {
            if (textBoxQuestion2.Text == "")
            {
                checkedListBoxAnswerList.Enabled = false;
                textBoxAnswer2.Enabled = false;
                buttonRemoveAnswer2.Enabled = false;
                buttonAddToAnswerList2.Enabled = false;
                buttonSaveQuestion2.Enabled = false;
            }
            else
            {
                checkedListBoxAnswerList.Enabled = true;
                textBoxAnswer2.Enabled = true;
            }
        }

        private void buttonRemoveAnswer2_Click(object sender, EventArgs e)
        {
            if(checkedListBoxAnswerList.SelectedItem!=null&& checkedListBoxAnswerList.Items.Count>0)
                checkedListBoxAnswerList.Items.RemoveAt(checkedListBoxAnswerList.SelectedIndex);
            else MessageBox.Show("Zero answer is forbidden! Please add one");

        }
        private void textBoxAnswer2_TextChanged(object sender, EventArgs e)
        {
            buttonAddToAnswerList2.Enabled = true;
        }

       
        private void buttonAddToAnswerList2_Click(object sender, EventArgs e)
        {
            buttonAddToAnswerList2.Enabled = false;
            Answer tempAnswer = new Answer();
            tempAnswer.Description = textBoxAnswer2.Text;
            if (checkBoxIsCorrect2.CheckState == CheckState.Checked)
                tempAnswer.IsCorrect = true;
            else tempAnswer.IsCorrect = false;
            if (isAnswerInEdit==false)
            {                
                if (!checkedListBoxAnswerList.Items.Contains(tempAnswer))
                {
                    checkedListBoxAnswerList.Items.Add(tempAnswer, tempAnswer.IsCorrect);
                }
                else if (textBoxAnswer2.Text == "")
                {
                    return;
                }
                else
                {
                    MessageBox.Show("Same answer already added! Work in Answer ListBox to change Correct status!");
                }
            }
            else
            {               
                if (checkedListBoxAnswerList.Items.Contains(tempAnswer))
                {
                    MessageBox.Show("Nothing changed! Work in Answer ListBox to change Correct status!");
                }
                else if (textBoxAnswer2.Text == "")
                {
                    return;
                }
                else
                {
                    int indexToReplace = checkedListBoxAnswerList.SelectedIndex;
                    if (checkedListBoxAnswerList.SelectedItem != null)
                    {
                        checkedListBoxAnswerList.Items.RemoveAt(indexToReplace);
                        checkedListBoxAnswerList.Items.Insert(indexToReplace, tempAnswer);
                        checkedListBoxAnswerList.SelectedIndex = indexToReplace;
                    }
                }
            }           
            textBoxAnswer2.Text = "";
            buttonSaveQuestion2.Enabled = true;
            buttonAddToAnswerList2.Text = "Add To AnswerList";
            isAnswerInEdit = false;
        }

        private void checkedListBoxAnswerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBoxAnswerList.Items.Count > 0)
            {
                if (checkedListBoxAnswerList.SelectedIndex < 0)
                    checkedListBoxAnswerList.SelectedIndex = 0;
                buttonRemoveAnswer2.Enabled = true;
            }
            buttonSaveQuestion2.Enabled = true;
            if (checkedListBoxAnswerList.Items.Count > 0)
            {
                try
                {
                    if (checkedListBoxAnswerList.SelectedIndex < 0)
                        checkedListBoxAnswerList.SelectedIndex = 0;
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
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        //private void buttonEditAnswer_Click(object sender, EventArgs e)
        //{
        //    CheckCorrectAnswer();
        //    currentTest.Questions[count - 1]
        //                .Answers[checkedListBoxAnswerList.SelectedIndex]
        //                .Description = checkedListBoxAnswerList.SelectedItem.ToString();

        //    buttonEditAnswer.Enabled = false;
        //}
        //private void CheckCorrectAnswer()
        //{
        //    try
        //    {
        //        for (int i = 0; i < checkedListBoxAnswerList.Items.Count; i++)
        //        {
        //            currentTest.Questions[count - 1]
        //                .Answers
        //                .Find(x => x.Description == (checkedListBoxAnswerList.Items[i] as Answer)
        //                .Description)
        //                .IsCorrect = checkedListBoxAnswerList.GetItemChecked(i);
        //        }
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message); }
        //}

       
        
        private void toolStripComboBoxChooseFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentTestClear2();
              
            currentTest = new Test();
            currentTestQuestionlist = new List<Question>();
            try
            {
                using (FileStream fs = new FileStream(path + "\\" + toolStripComboBoxChooseFile.SelectedItem.ToString(), FileMode.Open))
                {
                    currentTest = (Test)formatter.Deserialize(fs);
                }
                currentTestPass = path + "\\" + toolStripComboBoxChooseFile.SelectedItem.ToString();
                TestInfoLoading();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File not found or has incorrect name");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void textBoxAuthor2_TextChanged(object sender, EventArgs e)
        {
          //  currentTest.Author = textBoxAuthor2.Text;
        }

    
        private void buttonSaveTest2_Click(object sender, EventArgs e)
        {
            currentTest.Questions.Clear();
            foreach (Question item in listBoxQuestionList2.Items)
            {
                currentTest.Questions.Add(item);
            }
            using (FileStream fs = new FileStream(currentTestPass, FileMode.Truncate))
            {
                //fs.Position = 0;
                formatter.Serialize(fs, currentTest);
            }
            CurrentTestClear2();

          //  currentTest = new Test();
        }

        private void tabControlDesignTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTest = new Test();
            count = 0;
            if (tabControlDesignTest.SelectedTab.Text== "Edit Test")
            {
                toolStripComboBoxChooseFile.Items.Clear();
                if (directoryInfo.Exists)
                {
                    FileInfo[] files = directoryInfo.GetFiles().Where(p => p.Extension == ".xml").ToArray();
                    toolStripComboBoxChooseFile.Items.AddRange(files);
                    if (toolStripComboBoxChooseFile.Items.Count > 0)
                        toolStripComboBoxChooseFile.SelectedIndex = 0;
                }
            }      
            else if (tabControlDesignTest.SelectedTab.Text == "Create New Test")
            {
                CurrentTestClear();
            }
        }

        private void textBoxTestName2_TextChanged(object sender, EventArgs e)
        {
            //buttonAddNewQuestion.Enabled = true;
        }

        private void listBoxQuestionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonRemoveQuestion.Enabled = true;
        }

        private void buttonRename_Click(object sender, EventArgs e)
        {
            //if (textBoxTestName2.Text != currentTest.TestName)
            //{
            //    bool success = regex.IsMatch(textBoxTestName2.Text);
            //    if (success)
            //    {
            //        currentTest.TestName = textBoxTestName2.Text;
            //        currentTestPass = path + "\\" + currentTest.TestName + ".xml";
            //        groupBoxQuestionView2.Enabled = false;
            //        buttonSaveTest2.Enabled = true;
            //    }
            //    else MessageBox.Show(String.Format("String \"{0}\" doesn\'t correspont template \"{1}\"\nPlease try again!", textBoxTestName, pattern));

            //}

        }

        private void buttonRemoveQuestion2_Click(object sender, EventArgs e)
        {
            int indexToDelete = 0;
            if (listBoxQuestionList2.Items.Count > 1)
            {
                indexToDelete = listBoxQuestionList2.SelectedIndex;
                listBoxQuestionList2.Items.RemoveAt(indexToDelete);
                List<Question> listq = new List<Question>();
               
                for (int i = 0; i < listBoxQuestionList2.Items.Count; i++)
                {
                    (listBoxQuestionList2.Items[i] as Question).Number = i + 1;
                    listq.Add(listBoxQuestionList2.Items[i] as Question);
                }
                listBoxQuestionList2.Items.Clear();
                listBoxQuestionList2.Items.AddRange(listq.ToArray());
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Last item cannot be removed! Cancel Test Creating?", "Test Remove quaery!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    CurrentTestClear2();
                }
            }
            buttonRemoveQuestion2.Enabled = false;
        }

        private void buttonSaveQuestion2_Click(object sender, EventArgs e)
        {
            bool hasCorrectAnswer = false;
            foreach (Answer item in checkedListBoxAnswerList.Items)
            {
                if (item.IsCorrect == true)
                    hasCorrectAnswer = true;
            }
            if (hasCorrectAnswer == true)
            {
                buttonSaveTest2.Enabled = true;
                groupBoxQuestionView2.Enabled = false;
                if (isQuestionInEdit == false)
                {
                    newQuestion.Difficulty = Convert.ToInt32(numericUpDownDifficulty2.Value);
                    newQuestion.Description = textBoxQuestion2.Text;
                    for (int i = 0; i < checkedListBoxAnswerList.Items.Count; i++)
                    {
                        newQuestion.Answers.Add(checkedListBoxAnswerList.Items[i] as Answer);
                    }
                    if (!listBoxQuestionList2.Items.Contains(newQuestion))
                    {
                        listBoxQuestionList2.Items.Add(newQuestion);
                    }
                    else
                    {
                        MessageBox.Show("Same answer already present!");
                        return;
                    }
                }
                else
                {
                    editQuestion.Difficulty = Convert.ToInt32(numericUpDownDifficulty2.Value);
                    editQuestion.Description = textBoxQuestion2.Text;
                    editQuestion.Answers.Clear();
                    for (int i = 0; i < checkedListBoxAnswerList.Items.Count; i++)
                    {
                        editQuestion.Answers.Add(checkedListBoxAnswerList.Items[i] as Answer);
                    }
                    int indexToReplace = listBoxQuestionList2.Items.IndexOf(editQuestion);
                    listBoxQuestionList2.Items.RemoveAt(indexToReplace);
                    listBoxQuestionList2.Items.Insert(indexToReplace, editQuestion);                     
                }
                isQuestionInEdit = false;
                CurrentQuestionClear2();
            }
            else { MessageBox.Show("There are no correct answer in Answer comboBox, please add one before saving to Question List"); return; }
        }

        private void buttonAddNewQuestion_Click(object sender, EventArgs e)
        {
            CurrentQuestionClear2();
            groupBoxQuestionView2.Enabled = true;
            groupBoxQuestionView2.Text = "Create New Question View";          
            newQuestion.Number = listBoxQuestionList2.Items.Count + 1;
            isQuestionInEdit = false;
        }
      
        private void buttonEditQuestion2_Click(object sender, EventArgs e)
        {
            CurrentQuestionClear2();           
            if (listBoxQuestionList2.SelectedItem != null)
            {
                groupBoxQuestionView2.Enabled = true;
  //              buttonAddAnswer.Enabled = true;
                groupBoxQuestionView2.Text = "Edit Question View";
                CurrentQuestionLoad();
                editQuestion = (listBoxQuestionList2.SelectedItem as Question);
                isQuestionInEdit = true;
            }
          
            else MessageBox.Show("Please select question to edit!");

        }     
        private void CurrentQuestionLoad()
        {
            //if (listBoxQuestionList2.Items.Count > 0)
            //{
            //    if (listBoxQuestionList2.SelectedIndex < 0)
            //        listBoxQuestionList2.SelectedIndex = 0;
            //    buttonRemoveQuestion2.Enabled = true;

            //    groupBoxQuestionView2.Enabled = true;
                textBoxQuestion2.Text = (listBoxQuestionList2.SelectedItem as Question).Description;
                numericUpDownDifficulty2.Value = (listBoxQuestionList2.SelectedItem as Question).Difficulty;
           // }
            foreach (Answer item in (listBoxQuestionList2.SelectedItem as Question).Answers)
            {
                checkedListBoxAnswerList.Items.Add(item, item.IsCorrect);
            }
        }

        private void checkedListBoxAnswerList_DoubleClick(object sender, EventArgs e)
        {
            textBoxAnswer2.Text = checkedListBoxAnswerList.Text;
            checkBoxIsCorrect2.Checked = (checkedListBoxAnswerList.Items[checkedListBoxAnswerList.SelectedIndex] as Answer).IsCorrect;
            isAnswerInEdit = true;
        }

        private void listBoxQuestionList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonRemoveQuestion2.Enabled = true;
            buttonEditQuestion2.Enabled = true;
            buttonSaveTest2.Enabled = true;
        }
    }
}
