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
    public class ResultController : ControllerBase
    {
        [HttpGet("All/{quizId}")]
        public IActionResult All(int quizId)
        {
            var sampleResults = new List<ResultViewModel>
            {
                new ResultViewModel()
                {
                    Id = 1,
                    QuizId = quizId,
                    Text = "Co cenisz w życiu najbardziej?",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                }
            };

            for(int i = 2; i < 10; i++)
            {
                sampleResults.Add(new ResultViewModel()
                {
                    Id = 1,
                    QuizId = quizId,
                    Text = String.Format("Zapisz liczbę {0} w języku polskim!", i),
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }

            return new JsonResult( sampleResults, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });
        }
    }
}