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

namespace TestSystemClient
{
    public partial class LoginClientForm : Form
    {
        public LoginClientForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (GenericUnitOfWork work2 = new GenericUnitOfWork(new TestSystemDBContext(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString)))
            {
                IGenericRepository<User> repoUsers = work2.Repository<User>();
                IGenericRepository<Group> repoGroups = work2.Repository<Group>();
                var res = repoUsers.FindAll(x => x.Login == textBox2.Text && x.Password == textBox3.Text).FirstOrDefault();
                if (res != null&&res.Groups!=null)
                {
                    TestSystemClientForm newClientForm = new TestSystemClientForm(work2, res);
                    // DialogResult dialogResult =newClientForm.ShowDialog();
                    newClientForm.ShowDialog();
                }
                else
                    MessageBox.Show("Login or password incorrect, please try again later");
                work2.Dispose();
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
