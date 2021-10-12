using DAL_TestSystem;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSystemServer
{
    public partial class TestSystemServerForm : Form
    {
        GenericUnitOfWork mywork;
        IGenericRepository<User> repoUsers;
        IGenericRepository<Group> repoGroups;
        IGenericRepository<TestGroup> repoTestGroups;
        IGenericRepository<Test> repoTests;
        IGenericRepository<Question> repoQuestions;
        IGenericRepository<Answer> repoAnswers;
        IGenericRepository<Result> repoResults;
        IGenericRepository<UserAnswer> repoUserAnswers;
        public User currentUser;
        public TestSystemServerForm()
        {
            InitializeComponent();
        }

        public TestSystemServerForm(GenericUnitOfWork work, User user)
        {
            InitializeComponent();
            mywork = work;
            currentUser = user;
            repoUsers = mywork.Repository<User>();
            repoGroups=mywork.Repository<Group>();
            repoTestGroups= mywork.Repository<TestGroup>();
            repoTests= mywork.Repository<Test>();
            repoQuestions= mywork.Repository<Question>();
            repoAnswers= mywork.Repository<Answer>();
            repoResults= mywork.Repository<Result>();
            repoUserAnswers= mywork.Repository<UserAnswer>();
        }

        private void ToolStripMenuItemShowAll_Click(object sender, EventArgs e)
        {
            var res = repoTests.GetAll();
            dataGridViewTestManage.DataSource = res;
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
    }
}
