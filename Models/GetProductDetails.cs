using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public static class GetProductDetailsFunctions
    {
        [FunctionName(nameof(GetProductDetails))]
        public static IActionResult GetProductDetails(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            string productId = null;
            if (req.GetQueryParameterDictionary()?.TryGetValue(@"productId", out productId) == true
                && !string.IsNullOrWhiteSpace(productId))
            {
                return new OkObjectResult($@"The product name for your product id {productId} is Starfruit Explosion");
            }

            return new BadRequestObjectResult("productId query parameter is required");
        }
    }
}
