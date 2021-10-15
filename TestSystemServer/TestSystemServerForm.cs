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
        public User currentUser=new User ();
        DAL_TestSystem.Test currentTestDal = new DAL_TestSystem.Test();
        List<DAL_TestSystem.Test> tests = new List<DAL_TestSystem.Test>();
        List<DAL_TestSystem.Group> groupsList = new List<Group>();
        List<DAL_TestSystem.User> usersList = new List<User>();
        DAL_TestSystem.Question currentQuestionDal;
        TestDesignerDll.Test curentTestXml;
        XmlSerializer formatter;
        bool IsnewGroup = false;
        bool IsnewUser = false;
        bool IseditGroup = false;
        bool ISeditUser = false;
        Group currentGroup = new Group();
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
            repoGroups = mywork.Repository<Group>();
            repoTestGroups = mywork.Repository<TestGroup>();
            repoTests = mywork.Repository<DAL_TestSystem.Test>();
            repoQuestions = mywork.Repository<DAL_TestSystem.Question>();
            repoAnswers = mywork.Repository<DAL_TestSystem.Answer>();
            repoResults = mywork.Repository<Result>();
            repoUserAnswers = mywork.Repository<UserAnswer>();
        }

        private void ToolStripMenuItemShowAll_Click(object sender, EventArgs e)
        {
            var res = repoTests.GetAll();
            dataGridViewTestManage.DataSource = res;
            tests = res.ToList();
            this.dataGridViewTestManage.Columns["Results"].Visible = false;
            this.dataGridViewTestManage.Columns["TestGroups"].Visible = false;
            this.dataGridViewTestManage.Columns["Questions"].Visible = false;
        }

        private void tabPageResults_Click(object sender, EventArgs e)
        {
            var res = repoResults.GetAll();
            dataGridViewResults.DataSource = res;
            //bindingNavigator2.BindingSource = res.;
        }

        private void toolStripMenuItemShowAllUser_Click(object sender, EventArgs e)
        {
            var res = repoUsers.GetAll();
            dataGridViewUserManage.DataSource = res;
        }

        private void toolStripMenuItemShowAllGroups_Click(object sender, EventArgs e)
        {
            var res = repoGroups.GetAll().Select(x => new { Id = x.Id, Name = x.GroupName, Users = String.Join<User>(",", x.Users), TestGroups = String.Join<TestGroup>(",", x.TestGroups) }).ToList();
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
                    for (int i = 0; i < curentTestXml.Questions.Count; i++)
                    {
                        currentQuestionDal = new DAL_TestSystem.Question();
                        currentQuestionDal.Description = curentTestXml.Questions[i].Description;
                        currentQuestionDal.Difficulty = curentTestXml.Questions[i].Difficulty;
                        currentQuestionDal.Number = curentTestXml.Questions[i].Number;
                        for (int j = 0; j < curentTestXml.Questions[i].Answers.Count; j++)
                        {
                            currentAnswerDal = new DAL_TestSystem.Answer()
                            {
                                Description = curentTestXml.Questions[i].Answers[j].Description,
                                IsCorrect = curentTestXml.Questions[i].Answers[j].IsCorrect,
                            };
                            repoAnswers.Add(currentAnswerDal);
                            currentAnswerDal = repoAnswers.GetAll().Select(x => x).Where(x => x.Description == currentAnswerDal.Description).FirstOrDefault();
                            currentQuestionDal.Answers.Add(currentAnswerDal);
                        }
                        repoQuestions.Add(currentQuestionDal);
                        currentTestDal.Questions.Add(currentQuestionDal);
                    }
                    repoTests.Add(currentTestDal);
                    dataGridViewTestManage.DataSource = repoTests.GetAll();
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("File not found or has incorrect name");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

        }

        //private void ToolStripMenuItemAddTest_Click(object sender, EventArgs e)
        //{
        //    DAL_TestSystem.Test newTest = new DAL_TestSystem.Test()
        //    {
        //        TestName = textBoxTestName.Text,
        //        Author = textBoxAuthor.Text
        //    };
        //    if (listBoxQuestionList.Items.Count > 0)
        //    {
        //        foreach (var item in listBoxQuestionList.Items)
        //        {
        //            newTest.Questions.Add(item as DAL_TestSystem.Question);
        //        }
        //    }
        //    else MessageBox.Show("No Questions in Test");
        //}
        private void ClearAnswerGroupBox()
        {

            textBoxQuestion.Text = "";
            checkedListBoxAnswerList.Items.Clear();
            numericUpDownDifficulty.Value = 1;

        }
        private void ClearTestGroupBox()
        {
            textBoxAuthor.Text = "";
            textBoxTestName.Text = "";
            listBoxQuestionList.Items.Clear();
            ClearAnswerGroupBox();
        }
        //private void buttonSaveTest_Click(object sender, EventArgs e)
        //{           
        //    for (int i = 0; i < listBoxQuestionList.Items.Count; i++)
        //    {
        //        if (!currentTestDal.Questions.Contains(listBoxQuestionList.Items[i] as DAL_TestSystem.Question))
        //        currentTestDal.Questions.Add(listBoxQuestionList.Items[i] as DAL_TestSystem.Question);
        //    }
        //    var res = repoTests.FindById(currentTestDal.Id);
        //    if (res == null)
        //        repoTests.Add(currentTestDal);
        //    else repoTests.Update(currentTestDal);
        //    ClearTestGroupBox();
        //}
        private void listBoxQuestionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAnswerGroupBox();
            currentQuestionDal = listBoxQuestionList.SelectedItem as DAL_TestSystem.Question;
            textBoxQuestion.Text = (listBoxQuestionList.SelectedItem as DAL_TestSystem.Question).Description;
            foreach (DAL_TestSystem.Answer item in (listBoxQuestionList.SelectedItem as DAL_TestSystem.Question).Answers)
            {
                checkedListBoxAnswerList.Items.Add(item, item.IsCorrect);
            }
            numericUpDownDifficulty.Value = (listBoxQuestionList.SelectedItem as DAL_TestSystem.Question).Difficulty.Value;
        }
        private void ToolStripMenuItemRemoveTest_Click(object sender, EventArgs e)
        {
            var testToRemove = repoTests.FindById(int.Parse(dataGridViewTestManage.SelectedRows[0].Cells[0].Value.ToString()));
            repoTests.Remove(testToRemove);
            ToolStripMenuItemShowAll_Click(sender, e);
        }

        private void buttonAssignTest_Click(object sender, EventArgs e)
        {
            buttonAssignTest.Enabled = false;
            TestGroup newTestGroup = new TestGroup() { TestDate = DateTime.Now };
            newTestGroup.GetGroups = repoGroups.FindById((comboBoxGroup.SelectedItem as Group).Id);
            newTestGroup.GetTests = repoTests.FindById(currentTestDal.Id);
            repoTestGroups.Add(newTestGroup);
        }
        private void TestInfoLoading()
        {
            if (tests.Count > 0)
            {
                int index = Convert.ToInt32(dataGridViewTestManage.SelectedRows[0].Cells[0].Value.ToString());
                textBoxAuthor.Text = tests.Select(x => x).Where(x => x.Id == index).FirstOrDefault().Author;
                textBoxTestName.Text = tests.Select(x => x).Where(x => x.Id == index).FirstOrDefault().TestName;
                listBoxQuestionList.Items.AddRange(tests.Select(x => x).Where(x => x.Id == index).FirstOrDefault().Questions.ToArray());
                currentTestDal = tests.Select(x => x).Where(x => x.Id == index).FirstOrDefault();
            }
        }
        private void GroupInfoLoading()
        {
            groupsList = repoGroups.GetAll().ToList();
            comboBoxGroup.Items.AddRange(groupsList.Select(x => x).ToArray());
        }
        private void dataGridViewTestManage_SelectionChanged(object sender, EventArgs e)
        {
            ClearTestGroupBox();
            TestInfoLoading();
        }

        private void assignTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupInfoLoading();
            groupBoxAssignTest.Enabled = true;
        }

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Group item in groupsList)
            {
                foreach (User i in item.Users)
                {
                    if (!usersList.Contains(i))
                        usersList.Add(i);
                }
            }
            comboBoxUser.Items.AddRange(usersList.Select(x => x).ToArray());
            buttonAssignTest.Enabled = true;
        }

        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonAssignTest.Enabled = true;
        }

        private void toolStripMenuItemAdGroup_Click(object sender, EventArgs e)
        {
            ClearGroupView();
            buttonSaveGroup.Text = "Add To group";
            buttonSaveGroup.Visible = true;
            IsnewGroup = true;
            FillUserCheckList();

        }
        private void ClearGroupView()
        {
            textBoxGroupName.Text = "";
            CheckedListBoxUsers.Items.Clear();
            buttonSaveGroup.Visible = false;
            currentGroup = new Group();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            currentGroup.GroupName = textBoxGroupName.Text;
            var query = CheckedListBoxUsers.CheckedItems;
            foreach (var item in query)
            {
                var res = repoUsers.FindById((item as User).Id);
                currentGroup.Users.Add(res);
            }
            if (IsnewGroup == true)
            {
                repoGroups.Add(currentGroup);
                toolStripMenuItemShowAllGroups_Click(sender, e);
                IsnewGroup = false;
                buttonSaveGroup.Text = "Save";
            }
            else
            {
                var groupToEdit = repoGroups.FindById(int.Parse(dataGridViewGroupManage.SelectedRows[0].Cells[0].Value.ToString()));
                groupToEdit.GroupName = currentGroup.GroupName;
                groupToEdit.Users = currentGroup.Users;
                repoGroups.Update(groupToEdit);
                buttonSaveGroup.Text = "Save";
                toolStripMenuItemShowAllGroups_Click(sender, e);
            }
            ClearGroupView();
        }

        private void toolStripMenuItemEditGroup_Click(object sender, EventArgs e)
        {
            ClearGroupView();
            buttonSaveGroup.Text = "Edit Group";
            buttonSaveGroup.Visible = true;
            IsnewGroup = false;
            FillGroupView();
        }

        private void FillGroupView()
        {
            var groupToEdit = repoGroups.FindById(int.Parse(dataGridViewGroupManage.SelectedRows[0].Cells[0].Value.ToString()));
            textBoxGroupName.Text = groupToEdit.GroupName;
            FillUserCheckList();
        }
        private void FillUserCheckList()
        {
            var existingUsers = repoUsers.GetAll();
            foreach (var item in existingUsers)
            {
                CheckedListBoxUsers.Items.Add(item, item.IsAdmin);
            }
        }
        private void FillGroupCheckList()
        {
            var existingGroup = repoGroups.GetAll();
            foreach (var item in existingGroup)
            {
                foreach (var i in item.Users)
                {
                    if (currentUser!=null && i.Id == currentUser.Id)
                        checkedListBoxGroups.Items.Add(item, true);
                    else
                        checkedListBoxGroups.Items.Add(item, false);
                }

            }
        }
        private void toolStripMenuItemRemoveGroup_Click(object sender, EventArgs e)
        {
            var groupToDelete = repoGroups.FindById(int.Parse(dataGridViewGroupManage.SelectedRows[0].Cells[0].Value.ToString()));
            if (groupToDelete.GroupName != "Administrators")
            {
                repoGroups.Remove(groupToDelete);
                toolStripMenuItemShowAllGroups_Click(sender, e);
            }
        }

        private void toolStripMenuItemAddUser_Click(object sender, EventArgs e)
        {
            ClearUserView();
            buttonSaveUser.Text = "Add To Users";
            buttonSaveUser.Visible = true;
            IsnewUser = true;
            FillGroupCheckList();
        }

        private void ClearUserView()
        {
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            checkBoxIsAdmin.Checked = false;
            checkedListBoxGroups.Items.Clear();
            buttonSaveUser.Visible = false;
            currentUser = new User();
        }

        private void toolStripMenuItemEditUser_Click(object sender, EventArgs e)
        {
            ClearUserView();
            buttonSaveGroup.Text = "Edit User";
            buttonSaveUser.Visible = true;
            IsnewUser = false;
            FillUserView();
        }

        private void FillUserView()
        {
            var userToEdit = repoUsers.FindById(int.Parse(dataGridViewGroupManage.SelectedRows[0].Cells[0].Value.ToString()));
            textBoxLogin.Text = userToEdit.Login;
            textBoxPassword.Text = userToEdit.Password;
            textBoxFirstName.Text = userToEdit.FirstName;
            textBoxLastName.Text = userToEdit.LastName;
            checkBoxIsAdmin.Checked = userToEdit.IsAdmin;
            FillGroupCheckList();
        }

        private void toolStripMenuItemRemoveUser_Click(object sender, EventArgs e)
        {
            var userToDelete = repoUsers.FindById(int.Parse(dataGridViewGroupManage.SelectedRows[0].Cells[0].Value.ToString()));
            if (userToDelete != null && userToDelete.Id != 1)
            {
                repoUsers.Remove(userToDelete);
                toolStripMenuItemShowAllGroups_Click(sender, e);
            }
        }

        private void buttonSaveUser_Click(object sender, EventArgs e)
        {
            currentUser.Login = textBoxLogin.Text;
            currentUser.Password = textBoxPassword.Text;
            currentUser.FirstName = textBoxFirstName.Text;
            currentUser.LastName = textBoxLastName.Text;
            currentUser.IsAdmin = checkBoxIsAdmin.Checked;
            var query = checkedListBoxGroups.CheckedItems;
            foreach (var item in query)
            {
                var res = repoGroups.FindById((item as Group).Id);
                currentUser.Groups.Add(res);
            }
            if (IsnewUser == true)
            {
                repoUsers.Add(currentUser);
                toolStripMenuItemShowAllUser_Click(sender, e);
                IsnewUser = false;
                buttonSaveUser.Text = "Save";
            }
            else
            {
                var userToEdit = repoUsers.FindById(int.Parse(dataGridViewGroupManage.SelectedRows[0].Cells[0].Value.ToString()));
                userToEdit.Login = currentUser.Login;
                userToEdit.Password = currentUser.Password;
                userToEdit.FirstName= currentUser.FirstName;
                userToEdit.LastName=currentUser.LastName;
                userToEdit.IsAdmin= currentUser.IsAdmin;
                userToEdit.Groups = currentUser.Groups;
                repoUsers.Update(userToEdit);
                buttonSaveGroup.Text = "Save";
                toolStripMenuItemShowAllUser_Click(sender, e);
            }
            ClearUserView();
        }
    }
}
