using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TerrasoftTestApp.Metrics.Interfaces;
using TerrasoftTestApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TerrasoftTestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextMetricController : ControllerBase
    {
        private readonly IEnumerable<ITextMetric> metricsList;

        public TextMetricController(IEnumerable<ITextMetric> metricsList)
        {
            this.metricsList = metricsList;
        }

        [HttpGet]
        public ActionResult<TextResponseModel> GetMetricTypes()
        {
            string[] metricTypes = metricsList.Select(x => x.Name).ToArray();
            return Ok(metricTypes);
        }

        [HttpPost]
        public ActionResult<TextResponseModel> PostText([FromBody] TextRequestModel textRequestModel)
        {
            var metric = metricsList.FirstOrDefault(x => x.Name == textRequestModel.MetricType);

            if (metric == null)
            {
                return BadRequest();
            }
            var processedText = metric?.Process(textRequestModel.Text);

            var textRespone = new TextResponseModel
            {
                MetricType = textRequestModel.MetricType,
                MetricResult = processedText
            };
            return Ok(textRespone);
        }
    }
}
