using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestDesignerDll
{
	[Serializable]
	[XmlRoot]
	public class Test
	{
		[XmlElement]
		public string TestName { get; set; }
		[XmlElement]
		public string Author { get; set; }
		[XmlElement(ElementName = "QuestionCount")]
		public int QuestionCount { get { return Questions.Count; } }
		[XmlElement(ElementName = "Question")]
		public List<Question> Questions { get; set; }
		public Test() { this.Questions = new List<Question>(); }

        public Test(string testName, string author, List<Question> questions)
        {
            TestName = testName;
            Author = author;
            Questions = questions;
        }
        public override string ToString()
        {
			return $"Test Name: {TestName} | Author {Author} | Question Count: {QuestionCount}";
        }
     
    }
	[Serializable]
	[XmlRoot]
	public class Answer
	{
		[XmlElement(ElementName = "Description")]
		public string Description { get; set; }
		[XmlAttribute]
		public bool IsCorrect { get; set; }
        public override bool Equals(object obj)
        {
			return obj is Answer answer &&
				   Description == answer.Description;
        }
        public override string ToString()
        {
            return $"{Description}";
		}
    }
	[Serializable]
	[XmlRoot]
	public class Question
	{		
		[XmlAttribute]
		public int Number { get; set; }
		[XmlAttribute]
		public string Description { get; set; }
		[XmlElement(ElementName = "Difficulty")]
		public int Difficulty { get; set; } = 1;
		[XmlElement(ElementName = "Answer")]
		public List<Answer> Answers { get; set; }
		public Question() { this.Answers = new List<Answer>(); }

        public Question(string description, int difficulty, List<Answer> answers)
        {
            Description = description;
            Difficulty = difficulty;
            Answers = answers;
        }

        public override string ToString()
        {
			//return $"Question {Count}: {Description}\n" +
			//	$"Answers:\n{string.Join<Answer>("\n", Answers)}";
			return $"Question {Number}:{Description}";
		}

        public override bool Equals(object obj)
        {
            return obj is Question question &&
                   Description == question.Description;
        }
    }

}
