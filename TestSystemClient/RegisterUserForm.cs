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

namespace TestSystemClient
{
    public partial class RegisterUserForm : Form
    {
        GenericUnitOfWork mywork;
        IGenericRepository<User> repoUsers;
        GroupBox groupBoxUser;
        TextBox textBoxUserName1;
        TextBox textBoxUserName2;
        TextBox textBoxUserLogin;
        TextBox textBoxUserPassword;

        Label labelUserName1;
        Label labelUserName2;
        Label labelUserAge;
        Label labelUserLogin;
        Label labelUserPassword;
        Button buttonAddUser;
        public RegisterUserForm()
        {
            InitializeComponent();
            groupBoxUser = new GroupBox() { Text = "Add User" };

            groupBoxUser.Location = new Point(300, 36);
            groupBoxUser.Visible = false;
            groupBoxUser.Size = new Size(344, 300);
            textBoxUserName1 = new TextBox() { Location = new Point(110, 25), Size = new Size(181, 26) };
            textBoxUserName2 = new TextBox() { Location = new Point(110, 57), Size = new Size(181, 26) };
            textBoxUserLogin = new TextBox() { Location = new Point(110, 121), Size = new Size(181, 26) };
            textBoxUserPassword = new TextBox() { Location = new Point(110, 153), Size = new Size(181, 26) };

            labelUserName1 = new Label() { Location = new Point(7, 31), Text = "First Name" };
            labelUserName2 = new Label() { Location = new Point(7, 63), Text = "Last Name" };          
            labelUserLogin = new Label() { Location = new Point(7, 127), Text = "Login" };
            labelUserPassword = new Label() { Location = new Point(7, 159), Text = "Password" };
            buttonAddUser = new Button() { Location = new Point(110, 217), Size = new Size(181, 38), Text = "Add User" };
            buttonAddUser.Click += ButtonAddUser_Click;
            groupBoxUser.Controls.Add(labelUserName1);
            groupBoxUser.Controls.Add(labelUserName2);
            groupBoxUser.Controls.Add(labelUserAge);
            groupBoxUser.Controls.Add(labelUserLogin);
            groupBoxUser.Controls.Add(labelUserPassword);
            groupBoxUser.Controls.Add(textBoxUserName1);
            groupBoxUser.Controls.Add(textBoxUserName2);
            groupBoxUser.Controls.Add(textBoxUserLogin);
            groupBoxUser.Controls.Add(textBoxUserPassword);
            groupBoxUser.Controls.Add(buttonAddUser);
            groupBoxUser.SuspendLayout();
            this.Controls.Add(groupBoxUser);
        }
        public RegisterUserForm(GenericUnitOfWork work)
        {
            InitializeComponent();
            mywork = work;
            repoUsers = mywork.Repository<User>();
            groupBoxUser = new GroupBox() { Text = "Add User" };

            groupBoxUser.Location = new Point(300, 36);
            groupBoxUser.Visible = false;
            groupBoxUser.Size = new Size(344, 300);
            textBoxUserName1 = new TextBox() { Location = new Point(110, 25), Size = new Size(181, 26) };
            textBoxUserName2 = new TextBox() { Location = new Point(110, 57), Size = new Size(181, 26) };
            textBoxUserLogin = new TextBox() { Location = new Point(110, 89), Size = new Size(181, 26) };
            textBoxUserPassword = new TextBox() { Location = new Point(110, 121), Size = new Size(181, 26) };

            labelUserName1 = new Label() { Location = new Point(7, 31), Text = "First Name" };
            labelUserName2 = new Label() { Location = new Point(7, 63), Text = "Last Name" };
            labelUserLogin = new Label() { Location = new Point(7, 95), Text = "Login" };
            labelUserPassword = new Label() { Location = new Point(7, 127), Text = "Password" };
            buttonAddUser = new Button() { Location = new Point(110, 217), Size = new Size(181, 38), Text = "Add User" };
            buttonAddUser.Click += ButtonAddUser_Click;
            groupBoxUser.Controls.Add(labelUserName1);
            groupBoxUser.Controls.Add(labelUserName2);
            groupBoxUser.Controls.Add(labelUserAge);
            groupBoxUser.Controls.Add(labelUserLogin);
            groupBoxUser.Controls.Add(labelUserPassword);
            groupBoxUser.Controls.Add(textBoxUserName1);
            groupBoxUser.Controls.Add(textBoxUserName2);
            groupBoxUser.Controls.Add(textBoxUserLogin);
            groupBoxUser.Controls.Add(textBoxUserPassword);
            groupBoxUser.Controls.Add(buttonAddUser);
            groupBoxUser.SuspendLayout();
            groupBoxUser.Visible = true;
            groupBoxUser.BringToFront();
            this.Controls.Add(groupBoxUser);
        }
        private void ButtonAddUser_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                FirstName = textBoxUserName1.Text,
                LastName = textBoxUserName2.Text,
                Login = textBoxUserLogin.Text,
                Password = textBoxUserPassword.Text
            };
            user.IsAdmin = false;
            repoUsers.Add(user);
            DialogResult = DialogResult.OK;
        }
    }
}
