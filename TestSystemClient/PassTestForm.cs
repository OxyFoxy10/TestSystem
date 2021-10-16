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
        private DAL_TestSystem.Test userTest = new DAL_TestSystem.Test();
        private DAL_TestSystem.Question userTestQuestion = new DAL_TestSystem.Question();
        private DAL_TestSystem.Answer userTestAnswer = new DAL_TestSystem.Answer();
        Result currentResult = new Result();
        GenericUnitOfWork mywork;
        IGenericRepository<DAL_TestSystem.Test> repoTests;
        IGenericRepository<DAL_TestSystem.Question> repoQuestions;
        IGenericRepository<DAL_TestSystem.Answer> repoAnswers;
        IGenericRepository<Result> repoResults;
        IGenericRepository<UserAnswer> repoUserAnswers;
        public PassTestForm()
        {
            InitializeComponent();
        }
         public PassTestForm(GenericUnitOfWork work)
        {
            InitializeComponent();
            mywork = work;
            repoTests = mywork.Repository<DAL_TestSystem.Test>();
            repoQuestions = mywork.Repository<DAL_TestSystem.Question>();
            repoAnswers = mywork.Repository<DAL_TestSystem.Answer>();
            repoResults = mywork.Repository<Result>();
            repoUserAnswers = mywork.Repository<UserAnswer>();
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
                        (checkedListBoxAnswerList.Items[checkedListBoxAnswerList.SelectedIndex] as Answer).IsCorrect = true;
                    }
                    else (checkedListBoxAnswerList.Items[checkedListBoxAnswerList.SelectedIndex] as Answer).IsCorrect = false;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {

        }
    }
}
