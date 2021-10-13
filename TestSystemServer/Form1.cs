using DAL_TestSystem;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSystemServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (GenericUnitOfWork work = new GenericUnitOfWork(new TestSystemDBContext(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString)))
            {
                IGenericRepository<User> repoUsers = work.Repository<User>();
                IGenericRepository<Group> repoGroups = work.Repository<Group>();
                var res = repoUsers.FindAll(x => x.Login == textBox2.Text && x.Password == textBox3.Text).FirstOrDefault();
                var res2 = repoGroups.GetAll().FirstOrDefault(); 
                //var res2 = repoGroups.GetAll().FirstOrDefault(); 
                if (res != null)
                {
                    TestSystemServerForm testSystemServerForm  = new TestSystemServerForm(work, res);
                    DialogResult dialogResult = testSystemServerForm.ShowDialog();
                }
                else
                    MessageBox.Show("Login or password incorrect, please try again later");
                work.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (GenericUnitOfWork work = new GenericUnitOfWork(new TestSystemDBContext(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString)))
            {
                RegisterUserForm registerUserForm = new RegisterUserForm(work);
                DialogResult dialogResult = registerUserForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    MessageBox.Show("User added");
                }
                work.Dispose();
            }
        }
    }
}
