using DAL_TestSystem;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using TestDesignerDll;

namespace TestSystemServer
{
    public partial class TestSystemServerForm : Form
    {
        GenericUnitOfWork mywork;
        IGenericRepository<User> repoUsers;
        IGenericRepository<Group> repoGroups;
        IGenericRepository<TestGroup> repoTestGroups;
        IGenericRepository<DAL_TestSystem.Test> repoTests;
        IGenericRepository<DAL_TestSystem.Question> repoQuestions;
        IGenericRepository<DAL_TestSystem.Answer> repoAnswers;
        IGenericRepository<Result> repoResults;
        IGenericRepository<UserAnswer> repoUserAnswers;
        public User currentUser;
        DAL_TestSystem.Test currentTestDal =new DAL_TestSystem.Test ();
        DAL_TestSystem.Question currentQuestionDal;
        TestDesignerDll.Test curentTestXml;
        DAL_TestSystem.Answer currentAnswer;
        XmlSerializer formatter;
        int count = 0;
        public TestSystemServerForm()
        {
            InitializeComponent();
        }

        public TestSystemServerForm(GenericUnitOfWork work, User user)
        {
            InitializeComponent();
            formatter = new XmlSerializer(
            typeof(TestDesignerDll.Test),
            new XmlRootAttribute("Test")
            );
            mywork = work;
            currentUser = user;
            repoUsers = mywork.Repository<User>();
            repoGroups=mywork.Repository<Group>();
            repoTestGroups= mywork.Repository<TestGroup>();
            repoTests= mywork.Repository<DAL_TestSystem.Test>();
            repoQuestions= mywork.Repository<DAL_TestSystem.Question>();
            repoAnswers= mywork.Repository<DAL_TestSystem.Answer>();
            repoResults= mywork.Repository<Result>();
            repoUserAnswers= mywork.Repository<UserAnswer>();
        }

        private void ToolStripMenuItemShowAll_Click(object sender, EventArgs e)
        {
            var res = repoTests.GetAll();
            dataGridViewTestManage.DataSource = res;
            this.dataGridViewTestManage.Columns["Results"].Visible = false;
            this.dataGridViewTestManage.Columns["TestGroups"].Visible = false;
            this.dataGridViewTestManage.Columns["Questions"].Visible = false;
        }

        private void tabPageResults_Click(object sender, EventArgs e)
        {
            var res = repoResults.GetAll();
            dataGridViewResults.DataSource = res;
            //bindingNavigator2.BindingSource = repoResults.GetAll();
        }

        private void toolStripMenuItemShowAllUser_Click(object sender, EventArgs e)
        {
            var res = repoUsers.GetAll();
            dataGridViewUserManage.DataSource = res;
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemShowAllGroups_Click(object sender, EventArgs e)
        {
            var res = repoGroups.GetAll();
            dataGridViewGroupManage.DataSource = res;
        }

        private void loadTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
           currentTestDal = new DAL_TestSystem.Test();
           DAL_TestSystem.Answer currentAnswerDal;
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            DialogResult dialogResult = openFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
               curentTestXml = new TestDesignerDll.Test();
                try
                {
                    using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open))
                    {
                        curentTestXml = (TestDesignerDll.Test)formatter.Deserialize(fs);
                    }
                    currentTestDal.TestName = curentTestXml.TestName;
                    currentTestDal.Author = curentTestXml.Author;
                 //   repoTests.Add(currentTestDal);
                 //   currentTestDal= repoTests.GetAll().Select(x => x).Where(x => x.TestName == currentTestDal.TestName).FirstOrDefault();
                    for (int i = 0; i < curentTestXml.Questions.Count; i++)
                    {
                        currentQuestionDal = new DAL_TestSystem.Question();
                        currentQuestionDal.Description = curentTestXml.Questions[i].Description;
                        currentQuestionDal.Difficulty = curentTestXml.Questions[i].Difficulty;
                        currentQuestionDal.Number = curentTestXml.Questions[i].Number;
                       // currentQuestionDal.GetTest = currentTestDal;
                       // repoQuestions.Add(currentQuestionDal);
                       // currentQuestionDal= repoQuestions.GetAll().Select(x => x).Where(x => x.Description == currentQuestionDal.Description&&x.GetTest==currentQuestionDal.GetTest).FirstOrDefault();
                        for (int j = 0; j < curentTestXml.Questions[i].Answers.Count; j++)
                        {
                            currentAnswerDal = new DAL_TestSystem.Answer() {
                                Description = curentTestXml.Questions[i].Answers[j].Description,
                                IsCorrect = curentTestXml.Questions[i].Answers[j].IsCorrect,
                              //  GetQuestion = currentQuestionDal
                            };
                            repoAnswers.Add(currentAnswerDal);
                            currentAnswerDal= repoAnswers.GetAll().Select(x => x).Where(x => x.Description == currentAnswerDal.Description).FirstOrDefault();
                            currentQuestionDal.Answers.Add(currentAnswerDal);                           
                        }
                       // repoQuestions.Update(currentQuestionDal);
                        repoQuestions.Add(currentQuestionDal);
                        currentTestDal.Questions.Add(currentQuestionDal);                       
                    }
                   // repoTests.Update(currentTestDal);                   
                    repoTests.Add(currentTestDal);                   
                    dataGridViewTestManage.DataSource = repoTests.GetAll();
                   

                   // TestInfoLoading();
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("File not found or has incorrect name");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

        }

        private void ToolStripMenuItemAddTest_Click(object sender, EventArgs e)
        {
            DAL_TestSystem.Test newTest = new DAL_TestSystem.Test()
            {
                TestName = textBoxTestName.Text,
                Author = textBoxAuthor.Text
            };
            if (listBoxQuestionList.Items.Count > 0)
            {
                foreach (var item in listBoxQuestionList.Items)
                {
                    newTest.Questions.Add(item as DAL_TestSystem.Question);
                }
            }
            else MessageBox.Show("No Questions in Test");
        }

        private void buttonAddAnswer_Click(object sender, EventArgs e)
        {
            DAL_TestSystem.Answer currentAnswer = new DAL_TestSystem.Answer();
            currentAnswer.Description = textBoxAnswer.Text;
            if (checkBoxIsCorrect.CheckState == CheckState.Checked)
                currentAnswer.IsCorrect = true;
            else currentAnswer.IsCorrect = false;
            currentAnswer.Id = (comboBoxAnswerList.SelectedItem as DAL_TestSystem.Answer).Id;
            if (!comboBoxAnswerList.Items.Contains(currentAnswer))
            {
                comboBoxAnswerList.Items.Add(currentAnswer);
                repoAnswers.Add(currentAnswer);
                textBoxAnswer.Text = "";
                buttonAddAnswer.Enabled = false;
            }
            else {
                int index = comboBoxAnswerList.SelectedIndex;
                comboBoxAnswerList.Items.RemoveAt(index);
                comboBoxAnswerList.Items.Insert(index, currentAnswer);
                repoAnswers.Update(currentAnswer);
                MessageBox.Show("Same answer already added!");
            }
           
        }

        private void buttonSaveQuestion_Click(object sender, EventArgs e)
        {
            count++;
           
            currentQuestionDal.Difficulty = Convert.ToInt32(numericUpDownDifficulty.Value);
            currentQuestionDal.Number = count;
            for (int i = 0; i < comboBoxAnswerList.Items.Count; i++)
            {
                currentQuestionDal.Answers.Add(comboBoxAnswerList.Items[i] as DAL_TestSystem.Answer);
            }
            if (!listBoxQuestionList.Items.Contains(currentQuestionDal))
            {
                listBoxQuestionList.Items.Add(currentQuestionDal);
                repoQuestions.Add(currentQuestionDal);                
            }
            else MessageBox.Show("Same question already added");


        }
        private void ClearAnswerGroupBox()
        {
            textBoxAnswer.Text = "";
            textBoxQuestion.Text = "";
            comboBoxAnswerList.Items.Clear();
            numericUpDownDifficulty.Value = 1;
            checkBoxIsCorrect.Checked = false;
        }
        private void ClearTestGroupBox()
        {
            textBoxAuthor.Text = "";
            textBoxTestName.Text = "";
            listBoxQuestionList.Items.Clear();

        }
        private void buttonSaveTest_Click(object sender, EventArgs e)
        {
            count = 0;

            for (int i = 0; i < listBoxQuestionList.Items.Count; i++)
            {
                if (!currentTestDal.Questions.Contains(listBoxQuestionList.Items[i] as DAL_TestSystem.Question))
                currentTestDal.Questions.Add(listBoxQuestionList.Items[i] as DAL_TestSystem.Question);
            }
            var res = repoTests.FindById(currentTestDal.Id);
            if (res == null)
                repoTests.Add(currentTestDal);
            else repoTests.Update(currentTestDal);
            ClearTestGroupBox();
        }

        private void textBoxQuestion_TextChanged(object sender, EventArgs e)
        {
            //currentQuestionDal = new DAL_TestSystem.Question();
            currentQuestionDal.Description = textBoxQuestion.Text;
        }

        private void textBoxAnswer_TextChanged(object sender, EventArgs e)
        {
            buttonAddAnswer.Enabled = true;
        }

        private void textBoxAuthor_TextChanged(object sender, EventArgs e)
        {
          //  currentTestDal = new DAL_TestSystem.Test();
            currentTestDal.Author = textBoxAuthor.Text;
        }

        private void textBoxTestName_TextChanged(object sender, EventArgs e)
        {
            currentTestDal.TestName = textBoxTestName.Text;
        }

        private void dataGridViewTestManage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridViewTestManage_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void ToolStripMenuItemEditTest_Click(object sender, EventArgs e)
        {
            currentTestDal = repoTests.FindById(int.Parse(dataGridViewTestManage.SelectedRows[0].Cells[0].Value.ToString()));
            textBoxTestName.Text = currentTestDal.TestName;
            textBoxAuthor.Text = currentTestDal.Author;
            listBoxQuestionList.Items.AddRange(currentTestDal.Questions.ToArray());
        }

        private void listBoxQuestionList_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void comboBoxAnswerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxAnswer.Text = comboBoxAnswerList.Text;
            checkBoxIsCorrect.Checked = (comboBoxAnswerList.SelectedItem as DAL_TestSystem.Answer).IsCorrect;
            currentAnswer = repoAnswers.FindById((comboBoxAnswerList.SelectedItem as DAL_TestSystem.Answer).Id);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void listBoxQuestionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAnswerGroupBox();
            currentQuestionDal = listBoxQuestionList.SelectedItem as DAL_TestSystem.Question;
            textBoxQuestion.Text = listBoxQuestionList.SelectedItem.ToString();
            comboBoxAnswerList.Items.AddRange((listBoxQuestionList.SelectedItem as DAL_TestSystem.Question).Answers.ToArray());
            numericUpDownDifficulty.Value = (listBoxQuestionList.SelectedItem as DAL_TestSystem.Question).Difficulty.Value;
        }

        private void buttonRemoveAnswer_Click(object sender, EventArgs e)
        {
           
        }

        private void ToolStripMenuItemRemoveTest_Click(object sender, EventArgs e)
        {
            var testToRemove = repoTests.FindById(int.Parse(dataGridViewTestManage.SelectedRows[0].Cells[0].Value.ToString()));
            repoTests.Remove(testToRemove);
            ToolStripMenuItemShowAll_Click(sender, e);
        }
    }
}
