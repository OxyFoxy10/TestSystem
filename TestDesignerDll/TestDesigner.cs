using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestDesignerDll
{
	[XmlRoot(ElementName = "TestDesigner")]
	public class TestDesigner
	{
		[XmlElement(ElementName = "Author")]
		public string Author { get; set; }
		[XmlElement(ElementName = "TestName")]
		public string TestName { get; set; }
		[XmlElement(ElementName = "QuestionCount")]
		public string QuestionCount { get; set; }
		[XmlElement(ElementName = "Question")]
		public List<Question> QuestionList { get; set; }
		[XmlRoot(ElementName = "Answer")]
		public class Answer
		{
			[XmlElement(ElementName = "Description")]
			public string Description { get; set; }
			[XmlElement(ElementName = "IsRight")]
			public string IsRight { get; set; }
		}
		[XmlRoot(ElementName = "Question")]
		public class Question
		{
			[XmlElement(ElementName = "Description")]
			public string Description { get; set; }
			[XmlElement(ElementName = "Difficulty")]
			public string Difficulty { get; set; }
			[XmlElement(ElementName = "Answer")]
			public List<Answer> AnswerList { get; set; }
		}
	}
}
