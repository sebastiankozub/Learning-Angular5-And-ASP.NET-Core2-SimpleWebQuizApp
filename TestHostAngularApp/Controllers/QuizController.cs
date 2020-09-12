using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestHostAngularApp.ViewModels;
using Newtonsoft.Json;

namespace TestHostAngularApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var sampleQuiz = new List<QuizViewModel>
            {
                new QuizViewModel()
                {
                    Id = id,
                    Title = "Co cenisz w życiu najbardziej?",
                    Description = String.Format("Test osobowości Sebastiana nr {0}", id),
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                }
            };

            return new JsonResult(sampleQuiz, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException("NotImplemented");
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException("NotImplemented");
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException("NotImplemented");
        }

        [HttpGet("Latest/{num?}")]
        public IActionResult Latest(int num = 10)
        {
            var sampleQuizzes = new List<QuizViewModel>
            { 
                new QuizViewModel()
                {
                    Id = 1,
                    Title = "Co cenisz w życiu najbardziej?",
                    Description = "Test osobowości Sebastiana.",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                }
            };

            for (int i = 2; i < num; i++)
            {
                sampleQuizzes.Add(new QuizViewModel()
                {
                    Id = i,
                    Title = String.Format("Co cenisz w życiu najbardziej? Quiz nr {0}", i),
                    Description = "Test osobowości Sebastiana.",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }

            return new JsonResult(sampleQuizzes, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });
        }

        [HttpGet("ByTitle/{num:int?}")]
        public IActionResult ByTitle(int num = 10)
        {
            var sampleQuizzes = ((JsonResult)Latest(num)).Value as List<QuizViewModel>;

            return new JsonResult(sampleQuizzes.OrderBy(t => t.Title), 
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }

        [HttpGet("Random/{num:int?}")]
        public IActionResult Random(int num = 10)
        {
            var sampleQuizzes = ((JsonResult)Latest(num)).Value as List<QuizViewModel>;

            return new JsonResult(
                sampleQuizzes.OrderBy(t => Guid.NewGuid()), 
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }
    }
}