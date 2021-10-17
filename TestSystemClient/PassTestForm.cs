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
   
    public partial class PassTestForm : Form
    {
        public DAL_TestSystem.Test incomingTest = new Test() ;
        public DAL_TestSystem.Test outgoingTest = new Test() ;
        private DAL_TestSystem.Question currentQuestion = new DAL_TestSystem.Question();
        private DAL_TestSystem.Answer currentAnswer = new DAL_TestSystem.Answer();
        bool IsConsideredTrue = false;
        private List<DAL_TestSystem.Answer> currentAnswerList = new List<Answer>();
        private DAL_TestSystem.UserAnswer currentUsersAnswer;
        Result currentResult = new Result();      
        GenericUnitOfWork mywork;
        User currentUser = new User();

      //  IGenericRepository<DAL_TestSystem.Test> repoTests;
        //IGenericRepository<DAL_TestSystem.Question> repoQuestions;
        //IGenericRepository<DAL_TestSystem.Answer> repoAnswers;
        IGenericRepository<Result> repoResults;
        IGenericRepository<UserAnswer> repoUserAnswers;
        IGenericRepository<Answer> repoAnswers;
        int qcount = 0;
        DateTime testStart;
        public PassTestForm()
        {
            InitializeComponent();
        }
         public PassTestForm(GenericUnitOfWork work, Test test, User user)
        {
            InitializeComponent();
            mywork = work;
            incomingTest = test;
            currentUser = user;
          //  repoTests = mywork.Repository<DAL_TestSystem.Test>();
            //repoQuestions = mywork.Repository<DAL_TestSystem.Question>();
            //repoAnswers = mywork.Repository<DAL_TestSystem.Answer>();
            repoResults = mywork.Repository<Result>();
            repoUserAnswers = mywork.Repository<UserAnswer>();
            repoAnswers = mywork.Repository<Answer>();
            TestInfoLoading();
           // currentUsersAnswer.GetUserss = currentUser;
        }

        private void TestInfoLoading()
        {
           
                   
            //  outgoingTest = incomingTest; //є перевантажений equals, тому краще прописати всі пункти окремо
            outgoingTest.Id = incomingTest.Id;
            outgoingTest.TestName = incomingTest.TestName;
            outgoingTest.Author = incomingTest.Author;
            outgoingTest.Questions = incomingTest.Questions;
            outgoingTest.TestGroups = incomingTest.TestGroups;
            outgoingTest.Results = incomingTest.Results;
            foreach (Question item in outgoingTest.Questions)
            {
                listBoxQuestions.Items.Add(item);
                qcount++;
            }
            listBoxQuestions.SelectedItem = listBoxQuestions.Items[0];
            listBoxQuestions_Load();

        }
            private void checkedListBoxAnswerList_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                      //  (checkedListBoxAnswerList.Items[checkedListBoxAnswerList.SelectedIndex] as Answer).IsCorrect = true;
                    }
                  //  else (checkedListBoxAnswerList.Items[checkedListBoxAnswerList.SelectedIndex] as Answer).IsCorrect = false;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
           // var res = repoUserAnswers.GetAll().Select(x => x.GetUserss).Where(x => x.Id == currentUser.Id);

            currentResult.GetUser = currentUser;
            currentResult.GetTest = outgoingTest;
            currentResult.TestDate = DateTime.Now;
          //  currentResult.CalculateResult();
            repoResults.Add(currentResult);
            MessageBox.Show(currentUser.Id.ToString());
            var res = repoResults.GetAll().Select(x => x).Where(x => x.GetUser.Id == currentUser.Id && x.GetTest.Id == outgoingTest.Id).Select(c => c.Mark).FirstOrDefault();
            if (res != null)
                MessageBox.Show(res.ToString());

        }

        private void buttonStartTest_Click(object sender, EventArgs e)
        {
            // listBoxQuestions.Enabled = true;
            testStart = DateTime.Now;
            buttonNext.Enabled = true;
            buttonStartTest.Enabled = false;
            checkedListBoxAnswerList.Enabled = true;
        }
        private void listBoxQuestions_Load()
        {
            CurrentQuestionClear();
            textBoxQuestion.Text = (listBoxQuestions.SelectedItem as Question).Description;
            foreach (var item in (listBoxQuestions.SelectedItem as Question).Answers)
            {
                    checkedListBoxAnswerList.Items.Add(item, false);               
            }
           // listBoxQuestions.Enabled = false;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
           

            foreach (Answer item in checkedListBoxAnswerList.CheckedItems)
            {
                currentUsersAnswer = new DAL_TestSystem.UserAnswer() { UserAnswerDate = DateTime.Now, GetUserss = currentUser, GetAnswers=item };
                if (item.IsCorrect == true)
                    currentUsersAnswer.IsAnsweredCorectly = true;
                else   if (item.IsCorrect == false)
                    currentUsersAnswer.IsAnsweredCorectly = false;              
                    repoUserAnswers.Add(currentUsersAnswer);                
            }           
            SelectNextQuestion();
            listBoxQuestions_Load();
          //  listBoxQuestions.Enabled = true;
        }

        private void SelectNextQuestion()
        {
            int currentIndex = listBoxQuestions.SelectedIndex;
            if (currentIndex < listBoxQuestions.Items.Count - 1)
                listBoxQuestions.SelectedIndex = currentIndex + 1;    
            else if(currentIndex== listBoxQuestions.Items.Count - 1)
            {
                buttonNext.Enabled = false;
                buttonFinish.Enabled = true;
            }
        }

        private void CurrentQuestionClear()
        {
            textBoxQuestion.Text = ""; 
            checkedListBoxAnswerList.Items.Clear();
        }

        private void listBoxQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonNext.Enabled = true;
        }
    }
}
