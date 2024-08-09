using Microsoft.AspNetCore.Mvc;
using Quizgame.data;
using Quizgame.Models;
using Myproject;
using Microsoft.EntityFrameworkCore;

namespace Quizgame.Controllers
{
	public class QuizController : Controller
	{
		MyDbContext _dbContext;

		public QuizController(MyDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Start()
		{
			var quizgame = _dbContext.quizgames.Include(q => q.Options).ToList();
			{

			}
			var firstQuestion = quizgame[0];
			ViewBag.QuestionId = 0;
			ViewBag.Score = 0;
			return View("Start", firstQuestion);
			
		}
		[HttpPost]
		public IActionResult Start(int questionId, int optionId, int score)
		{
			var quizgame = _dbContext.quizgames.Include(q => q.Options).ToList();
			if (questionId >= quizgame.Count)
			{
				return RedirectToAction("Result");
			}
			var currentQuestion = quizgame[questionId];
			// increase score if right answer is selected
			if (currentQuestion.CorrectOptionId == optionId)
			{
				score++;
			}
			questionId++;
			if (questionId < quizgame.Count)
			{
				var nextQuestion = quizgame[questionId];
				ViewBag.QuestionId = questionId;
				ViewBag.score = score;
				return View(nextQuestion);
			}
			return RedirectToAction("Result", new {score});
		}

        public IActionResult Result(int score)
        {
			ViewBag.Score = score;
            return View();
        }
    }
}

