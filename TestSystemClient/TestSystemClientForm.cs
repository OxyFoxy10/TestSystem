﻿using DAL_TestSystem;
using Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSystemClient
{
    public partial class TestSystemClientForm : Form
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
       
        Socket sendSocket;

        InfoClients MyInfo = new InfoClients();
        
        public TestSystemClientForm()
        {
            InitializeComponent();
        }
          public TestSystemClientForm(GenericUnitOfWork work, User user)
        {
            InitializeComponent();           
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

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            //Відкриття сокета 
            buttonConnect.Enabled = false;
            buttonDisconnect.Enabled = true;
            sendSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPHostEntry iPHost = Dns.GetHostEntry(textBoxServerName.Text);
            IPAddress iPAddress = iPHost.AddressList[1];//Мережева картка 
            int port = int.Parse(textBoxPortNumber.Text);
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, port);

            try
            {
                sendSocket.Connect(iPEndPoint);
                MyInfo.ClientSocket = sendSocket;
                MyInfo.RemoteEndPoint = sendSocket.RemoteEndPoint.ToString();
                MyInfo.userClient = currentUser;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Please restart program", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
            finally
            {
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        try
                        {
                            Byte[] receiveByte = new byte[1024];
                            Int32 nCount = sendSocket.Receive(receiveByte);
                            //String receiveString = Encoding.ASCII.GetString(receiveByte, 0, nCount);
                            //if (receiveString.Contains("SymbolPlay") || receiveString.Contains("Game started"))
                            //{
                            //    if (receiveString.Contains("SymbolPlay"))
                            //    {
                            //        MyInfo.SymbolPlay = Convert.ToChar(receiveString.Substring(receiveString.Length - 3).Trim('\r', '\n'));
                            //        label2.Invoke(new Action(() => { label2.Text = MyInfo.SymbolPlay.ToString(); }));
                            //    }
                            //    if (receiveString.Contains("Game started"))
                            //    {
                            //        tableLayoutPanel1.Invoke(new Action(() => { tableLayoutPanel1.Enabled = true; }));
                            //        IsGameStarted = true;
                            //    }
                            //}
                            //else
                            //if (receiveString.Contains("Game over"))
                            //{
                            //    tableLayoutPanel1.Invoke(new Action(() => { tableLayoutPanel1.Enabled = false; }));
                            //    label3.Invoke(new Action(() => { label3.Visible = true; }));
                            //    IsGameOver = true;
                            //    string winner = receiveString.Substring(receiveString.Length - 1);
                            //    if (winner != "?")
                            //        label3.Invoke(new Action(() => { label3.Text = receiveString.Substring(0, receiveString.Length - 1); }));
                            //    else
                            //        label3.Invoke(new Action(() => { label3.Text += $"{Environment.NewLine}Dead heat. No one won"; }));
                            //}
                            //else
                            //{
                            //    charArray = Encoding.ASCII.GetChars(receiveByte, 0, nCount);
                            //    FuncGame(charArray);
                            //    if (IsGameOver == false && IsGameStarted == true)
                            //        tableLayoutPanel1.Invoke(new Action(() => { tableLayoutPanel1.Enabled = true; }));
                            //}
                        }
                        catch (Exception ex)
                        {
                            // MessageBox.Show(ex.Message);
                            return;
                        }
                    }
                });
            }
        }
    }
}
