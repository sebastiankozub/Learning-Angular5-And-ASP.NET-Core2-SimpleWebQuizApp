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
    public class AnswerController : ControllerBase
    {
        [HttpGet("All/{questionId}")]
        public IActionResult All(int questionId)
        {
            var sampleResults = new List<AnswerViewModel>
            {
                new AnswerViewModel()
                {
                    Id = 1,
                    QuestionId = questionId,
                    Text = "Przyjaciół i rodzinę",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                }
            };

            for (int i = 2; i < 10; i++)
            {
                sampleResults.Add(new AnswerViewModel()
                {
                    Id = 1,
                    QuestionId = questionId,
                    Text = String.Format("Jakaś inna odpowiedź {0}",i),
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }

            return new JsonResult(sampleResults, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });
        }
    }
}