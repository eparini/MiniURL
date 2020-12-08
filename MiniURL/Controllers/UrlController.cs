using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniURL.Models;
using MiniURL.Services;
using System;
using System.Threading.Tasks;

namespace MiniURL.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UrlController : ControllerBase
    {

        private readonly ILogger<UrlController> _logger;
        private readonly ICosmosDbService _cosmosDbService;
        public UrlController(ILogger<UrlController> logger, ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
            _logger = logger;
        }

        [HttpPost]
        [Route("generateshorturl")]
        public async Task<Response> GenerateShortURL([FromBody] Request request)
        {
            Item newItem = new Item();
            newItem.LongURL = request.url;
            newItem.ShortURL = URLGeneratorService.GenerateMiniURL(request.url);
            newItem.ExpirationDate = new DateTime().AddMonths(3).ToUniversalTime();
            await _cosmosDbService.AddItemAsync(newItem);
            Response res = new Response();
            res.shortURL = newItem.ShortURL;
            return res;
        }

        [HttpPost]
        [Route("getlongurl")]
        public async Task<Item> GetLongURL([FromBody] Request request)
        {
            if (string.IsNullOrEmpty(request.url))
                return null;
            else
                return await _cosmosDbService.GetItemAsync(request.url);
        }



    }
}
