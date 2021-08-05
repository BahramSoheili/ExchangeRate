using Core.Queries;
using ExchangeRateApisManager.Domains.Currency.Queries;
using ExchangeRateApisManager.Domains.Currency.ValueObjects;
using ExchangeRateApisManager.Domains.Currency.View;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExchangeRateApis.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class CurrencyController : Controller
    {    
        private readonly IQueryBus _queryBus;
        public CurrencyController(IQueryBus queryBus)
        {
            _queryBus = queryBus;
        }    
        [HttpPost]
        public Task<double> GetCurrency([FromBody] CurrencyInfo data)
        {
            return _queryBus.Send<GetCurrency, double> (new GetCurrency(data));
        }
    }    
}
