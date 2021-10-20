using DAL_TestSystem;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using TestDesignerDll;
using TestSystemClient;

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
        public User currentUser = new User();
        DAL_TestSystem.Test currentTestDal = new DAL_TestSystem.Test();
        List<DAL_TestSystem.Test> tests = new List<DAL_TestSystem.Test>();
        List<DAL_TestSystem.Group> groupsList = new List<Group>();
        List<DAL_TestSystem.User> usersList = new List<User>();
        DAL_TestSystem.Question currentQuestionDal;
        TestDesignerDll.Test curentTestXml;
        XmlSerializer formatter;
        bool IsnewGroup = false;
        bool IsnewUser = false;
        Group currentGroup = new Group();
        User newUser = new User();
        Socket listenSocket; // тільки для прослуховування
        public static List<InfoClients> ClientsList = new List<InfoClients>();
        Byte[] sendByte;
        CancellationToken ct;
        CancellationTokenSource tokenSource2;
        CancellationToken ctReceive;
        CancellationTokenSource tokenSourceReceive;
        bool isNewTestAssigned = false;
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
            ToolStripMenuItemShowAll.Text = "Renew";
            groupBoxAssignTest.Enabled = true;
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
        }

        private void toolStripMenuItemShowAllUser_Click(object sender, EventArgs e)
        {
            toolStripMenuItemShowAllUser.Text = "Renew!";
            var res = repoUsers.GetAll()
                .Select(x => new {
                    Id = x.Id,
                    Login = x.Login,
                    Password = x.Password,
                    IsAdmin = x.IsAdmin,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Groups = String.Join<Group>(",", x.Groups)
                }).ToList();
            dataGridViewUserManage.DataSource = res;
        }

        private void toolStripMenuItemShowAllGroups_Click(object sender, EventArgs e)
        {
            toolStripMenuItemShowAllGroups.Text = "Renew";
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
                    repoTests.Add(currentTestDal);
                    currentTestDal = repoTests.GetAll().Select(x => x).Where(x => x.TestName == currentTestDal.TestName && x.Author == currentTestDal.Author).FirstOrDefault();
                    for (int i = 0; i < curentTestXml.Questions.Count; i++)
                    {
                        currentQuestionDal = new DAL_TestSystem.Question();
                        currentQuestionDal.Description = curentTestXml.Questions[i].Description;
                        currentQuestionDal.Difficulty = curentTestXml.Questions[i].Difficulty;
                        currentQuestionDal.Number = curentTestXml.Questions[i].Number;
                        currentQuestionDal.GetTest = currentTestDal;
                        repoQuestions.Add(currentQuestionDal);
                        for (int j = 0; j < curentTestXml.Questions[i].Answers.Count; j++)
                        {
                            currentAnswerDal = new DAL_TestSystem.Answer()
                            {
                                Description = curentTestXml.Questions[i].Answers[j].Description,
                                IsCorrect = curentTestXml.Questions[i].Answers[j].IsCorrect
                            };
                            currentAnswerDal.GetQuestion = currentQuestionDal;
                            repoAnswers.Add(currentAnswerDal);
                        }
                    }
                    dataGridViewTestManage.DataSource = repoTests.GetAll();
                    ToolStripMenuItemShowAll_Click(sender, e);
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("File not found or has incorrect name");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

            }
        }

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

        private void listBoxQuestionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAnswerGroupBox();
            if (listBoxQuestionList.SelectedIndex >= 0)
            {
                currentQuestionDal = listBoxQuestionList.SelectedItem as DAL_TestSystem.Question;
                textBoxQuestion.Text = (listBoxQuestionList.SelectedItem as DAL_TestSystem.Question).Description;
                foreach (DAL_TestSystem.Answer item in (listBoxQuestionList.SelectedItem as DAL_TestSystem.Question).Answers)
                {
                    checkedListBoxAnswerList.Items.Add(item, item.IsCorrect);
                }
                numericUpDownDifficulty.Value = (listBoxQuestionList.SelectedItem as DAL_TestSystem.Question).Difficulty;
            }

        }
        private void ToolStripMenuItemRemoveTest_Click(object sender, EventArgs e)
        {
            if (dataGridViewTestManage.SelectedRows.Count > 0)
            {
                var testToRemove = repoTests.FindById(int.Parse(dataGridViewTestManage.SelectedRows[0].Cells[0].Value.ToString()));
                repoTests.Remove(testToRemove);
                ToolStripMenuItemShowAll_Click(sender, e);
            }

        }

        private void buttonAssignTest_Click(object sender, EventArgs e)
        {
            if (comboBoxGroup.SelectedItem == null)
            {
                MessageBox.Show("Please check group to assign test!");
                return;
            }
            buttonAssignTest.Visible = false;
            TestGroup newTestGroup = new TestGroup() { TestDate = DateTime.Now };
            lock (repoGroups)
            {
                newTestGroup.GetGroups = repoGroups.FindById((comboBoxGroup.SelectedItem as Group).Id);
                lock (repoTests)
                {
                    newTestGroup.GetTests = repoTests.FindById(currentTestDal.Id);
                }
            }
            lock (repoTestGroups)
            {
               var res=repoTestGroups.GetAll()
                    .Select(c=>c).Where(x=>x.GetTests.Id== newTestGroup.GetTests.Id&&x.GetGroups.Id== newTestGroup.GetGroups.Id).FirstOrDefault();
                if(res==null)
                repoTestGroups.Add(newTestGroup);
                else
                    MessageBox.Show($"{newTestGroup.GetTests.TestName} is already assigned to this group!");
            }
            isNewTestAssigned = true;
            AssignTestSent(newTestGroup);

        }
        private void TestInfoLoading()
        {
            if (tests.Count > 0 && dataGridViewTestManage.SelectedRows.Count > 0)
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
            comboBoxGroup.Items.Clear();
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
            buttonAssignTest.Visible = true;
            buttonAssignTest.Enabled = true;
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

        private void FillUserCheckList()
        {
            var existingUsers = repoUsers.GetAll();

            foreach (var item in existingUsers)
            {
                if (!CheckedListBoxUsers.Items.Contains(item))
                    CheckedListBoxUsers.Items.Add(item, false);
            }
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
            var existingUsers = repoUsers.GetAll();
            foreach (var item in groupToEdit.Users)
            {
                CheckedListBoxUsers.Items.Add(item, true);
            }

            foreach (var item in existingUsers)
            {
                if (!CheckedListBoxUsers.Items.Contains(item))
                    CheckedListBoxUsers.Items.Add(item, false);
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
        }

        private void ClearUserView()
        {
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            checkBoxIsAdmin.Checked = false;
            buttonSaveUser.Visible = false;
            IsnewUser = false;
            newUser = new User();
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
            var userToEdit = repoUsers.FindById(int.Parse(dataGridViewUserManage.SelectedRows[0].Cells[0].Value.ToString()));
            textBoxLogin.Text = userToEdit.Login;
            textBoxPassword.Text = userToEdit.Password;
            textBoxFirstName.Text = userToEdit.FirstName;
            textBoxLastName.Text = userToEdit.LastName;
            checkBoxIsAdmin.Checked = userToEdit.IsAdmin;
        }

        private void toolStripMenuItemRemoveUser_Click(object sender, EventArgs e)
        {
            var userToDelete = repoUsers.FindById(int.Parse(dataGridViewUserManage.SelectedRows[0].Cells[0].Value.ToString()));
            if (userToDelete != null && userToDelete.Id != 1)
            {
                repoUsers.Remove(userToDelete);
                toolStripMenuItemShowAllUser_Click(sender, e);
            }
        }

        private void buttonSaveUser_Click(object sender, EventArgs e)
        {
            newUser.Login = textBoxLogin.Text;
            newUser.Password = textBoxPassword.Text;
            newUser.FirstName = textBoxFirstName.Text;
            newUser.LastName = textBoxLastName.Text;
            newUser.IsAdmin = checkBoxIsAdmin.Checked;

            if (IsnewUser == true)
            {
                repoUsers.Add(newUser);
                toolStripMenuItemShowAllUser_Click(sender, e);
                IsnewUser = false;
                buttonSaveUser.Text = "Save";
            }
            else
            {
                var userToEdit = repoUsers.FindById(int.Parse(dataGridViewUserManage.SelectedRows[0].Cells[0].Value.ToString()));
                userToEdit.Login = newUser.Login;
                userToEdit.Password = newUser.Password;
                userToEdit.FirstName = newUser.FirstName;
                userToEdit.LastName = newUser.LastName;
                userToEdit.IsAdmin = newUser.IsAdmin;
                repoUsers.Update(userToEdit);
                buttonSaveGroup.Text = "Save";
                toolStripMenuItemShowAllUser_Click(sender, e);
            }
            ClearUserView();
        }

        private async void buttonStartServer_ClickAsync(object sender, EventArgs e)
        {
            buttonStartServer.Enabled = false;
            buttonStopServer2.Enabled = true;
            listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // сервер завжди сідає на Localhost
            IPHostEntry iPHostEntry = Dns.GetHostEntry("localhost");
            IPAddress iPAddress = iPHostEntry.AddressList[1]; //[0] - доступ до першої мережевої карти
            // номер порта
            int port = int.Parse(textBoxPortNumberServer.Text);
            //Створення сервера
            // Створюємо кінцеву точку
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, port);
            // призначення сокета bind
            listenSocket.Bind(iPEndPoint);//сідає на конкретний порт
            tokenSource2 = new CancellationTokenSource();
            ct = tokenSource2.Token;
            #region TaskListeningClientConnection
            await Task.Run(() =>
            {
                #region ListeningClientConnection
                listenSocket.Listen(3);
                while (true)//вічно слухати
                {
                    if (ct.IsCancellationRequested)
                    {
                        return;
                    }
                    try
                    {
                        Socket clientSocket = listenSocket.Accept(); //.Accept() - це блокуюча функцію

                        InfoClients infoClients = new InfoClients()
                        {
                            RemoteEndPoint = clientSocket.RemoteEndPoint.ToString(),
                            ClientSocket = clientSocket
                        };
                        //добавляєм клієнтів які приєдналися до сервера
                        listBox1_clientList.Invoke(new Action(() => listBox1_clientList.Items.Add(infoClients)));
                        textBox2.Invoke(new Action(() => {
                            textBox2.Text += $"client {infoClients.ClientSocket.Handle}" +
                            $" ip {infoClients.RemoteEndPoint} joined chat{Environment.NewLine}";
                        }));
                        ClientsList.Add(infoClients);
                        sendByte = new byte[1024];
                        sendByte = Encoding.ASCII.GetBytes($"client {infoClients.ClientSocket.Handle} ip {infoClients.RemoteEndPoint}{Environment.NewLine}");
                        infoClients.ClientSocket.Send(sendByte);
                        //Читання повідомлення яке надходить від клієнта
                        tokenSourceReceive = new CancellationTokenSource();
                        ctReceive = tokenSourceReceive.Token;
                        #region TaskReadMessageFromClient
                        Task.Run(() =>
                        {
                            ctReceive.ThrowIfCancellationRequested();
                            #region ReadMessageFromClient
                            while (true)//постійно читаєм( чекаєм на повідомлення клієнта)
                            {
                                if (ctReceive.IsCancellationRequested)
                                {
                                    // Clean up here, then...
                                    //ctReceive.ThrowIfCancellationRequested();                                    
                                    return;
                                }
                                Socket receiveSocket = infoClients.ClientSocket;
                                byte[] receivebyte = new byte[1024];
                                //Читання
                                try
                                {
                                    Int32 nCount = receiveSocket.Receive(receivebyte);//Receive() -  блокуюча функція - чекає доки не буде повідомлення
                                    String receiveString = Encoding.ASCII.GetString(receivebyte, 0, nCount);
                                    if (receiveString.Contains("close"))
                                    {
                                        string clientLeft = $"Member {infoClients.RemoteEndPoint} has left chat!{Environment.NewLine}";
                                        listBox1_clientList.Invoke(new Action(() => listBox1_clientList.Items.Remove(infoClients)));
                                        ClientsList.Remove(infoClients);
                                        infoClients.Dispose();
                                        textBox2.Invoke(new Action(() => { textBox2.Text += clientLeft + Environment.NewLine; }));
                                        break;
                                    }
                                    else if (receiveString.Contains("test finished"))
                                    {
                                        string clientfinished = $"{receiveString} IP {infoClients.RemoteEndPoint}!{Environment.NewLine}";
                                        textBox2.Invoke(new Action(() => { textBox2.Text += clientfinished + Environment.NewLine; }));
                                        sendByte = new byte[1024];
                                        sendByte = Encoding.ASCII.GetBytes($"client {infoClients.ClientSocket.Handle} ip {infoClients.RemoteEndPoint} can check his resuls now!{Environment.NewLine}");
                                        infoClients.ClientSocket.Send(sendByte);
                                        toolStripMenuItem2_Click(sender, e);                                      
                                    }
                                }
                                catch
                                {
                                    return;
                                }
                            }
                            #endregion ReadMessageFromClient
                        }, tokenSourceReceive.Token

                            );
                        #endregion TaskReadMessageFromClient
                    }
                    catch
                    {
                        // ct.ThrowIfCancellationRequested();                                            
                        return;
                    }
                }
                #endregion ListeningClientConnection
            }, tokenSource2.Token);
            #endregion TaskListeningClientConnection
        }

        private void AssignTestSent(TestGroup newTestGroup)
        {
            // конвертуємо повідомлення в байти
            Byte[] sendByte = new byte[1024];
            // var currentTestGroup = repoTestGroups.GetAll();
            if (ClientsList.Count > 0 && isNewTestAssigned == true)
            {
                foreach (var item in ClientsList)
                {
                    sendByte = new byte[1024];
                    sendByte = Encoding.ASCII.GetBytes($"TestGroup{newTestGroup.Id}");
                    try
                    {
                        item.ClientSocket.Send(sendByte); // відправка повідомлення
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                isNewTestAssigned = false;
            }

        }

        private void buttonStopServer2_Click(object sender, EventArgs e)
        {
            try
            {
                tokenSource2.Cancel();
                if (tokenSourceReceive != null)
                    tokenSourceReceive.Cancel();
            }

            finally
            {
                for (int i = 0; i < listBox1_clientList.Items.Count; i++)
                {
                    (listBox1_clientList.Items[i] as InfoClients).ClientSocket.Close();
                    listBox1_clientList.Items.RemoveAt(i);
                }
                listenSocket.Close();
                this.Close();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Text = "Renew";
            var res = repoResults.GetAll();           
            if (res != null)
                dataGridViewResults.DataSource = res;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2.Text = "Renew";
            var testgroupToDelete = repoTestGroups.GetAll().Select(x => x).Where(x=>x.UsersPassedTest.Count == x.GetGroups.Users.Count).ToList();
            if (testgroupToDelete != null&& testgroupToDelete.Count>0)
            {
               DialogResult dr= MessageBox.Show($"Some Tests assigned to group are fully passed\n TestGroup table will be cleaned from those elements!", "Need admin attention!",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
               if(dr==DialogResult.Yes)
                foreach (var item in testgroupToDelete)
                {
                    repoTestGroups.Remove(item);                  
                }               
            }
            
            var res = repoTestGroups.GetAll().Select(x => new { Id = x.Id, TestDate = x.TestDate, TestName = x.GetTests.TestName, GetGroups = x.GetGroups, Users = String.Join<User>(",", x.GetGroups.Users), Userspassed = String.Join<User>(",", x.UsersPassedTest) }).ToList();

            if (res != null)
                dataGridViewTestGroup.DataSource = res;
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewResults.SelectedRows.Count > 0)
            {
                var resultToRemove = repoResults.FindById(int.Parse(dataGridViewResults.SelectedRows[0].Cells[0].Value.ToString()));
                repoResults.Remove(resultToRemove);
                toolStripMenuItem1_Click(sender, e);
            }

        }

        private void removeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridViewTestGroup.SelectedRows.Count > 0)
            {
                var testGroupToRemove = repoTestGroups.FindById(int.Parse(dataGridViewTestGroup.SelectedRows[0].Cells[0].Value.ToString()));
                repoTestGroups.Remove(testGroupToRemove);
                toolStripMenuItem2_Click(sender, e);
            }

        }
    }
}
