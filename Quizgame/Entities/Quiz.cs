namespace Quizgame.Entities
{
	public class Quiz
	{
		public int Id { get; set; }
		public string Question { get; set; }
		public List<QuizOption> Options { get; set; }
		public int CorrectOptionId { get; set; }
	}

	public class QuizOption
	{
		public int Id { get; set; }
		public string Answer { get; set; }
		public int QuizId { get; set; }
		public Quiz Quiz { get; set; }
	}
}
