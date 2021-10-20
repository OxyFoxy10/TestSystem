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
using TestSystemClient;

namespace TestSystemServer
{
    public partial class LoginServerForm : Form
    {
        public LoginServerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (GenericUnitOfWork work = new GenericUnitOfWork(new TestSystemDBContext(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString)))
            {
                IGenericRepository<User> repoUsers = work.Repository<User>();
                var res = repoUsers.FindAll(x => x.Login == textBox2.Text && x.Password == textBox3.Text).FirstOrDefault();
                if (res != null &&res.IsAdmin==true)
                {
                    TestSystemServerForm testSystemServerForm  = new TestSystemServerForm(work, res);
                    DialogResult dialogResult = testSystemServerForm.ShowDialog();
                }
                //else if (res != null && res.Groups!= null&& res.IsAdmin == false)
                //{
                //    TestSystemClientForm newClientForm = new TestSystemClientForm(work, res);
                //     DialogResult dialogResult =newClientForm.ShowDialog();
                //}
                else
                    MessageBox.Show("Login or password incorrect, please try again later");
                work.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }
    }
}
