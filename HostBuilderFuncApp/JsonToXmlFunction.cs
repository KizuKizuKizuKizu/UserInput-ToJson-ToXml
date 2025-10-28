using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;


namespace HostBuilderFuncApp;

public class JsonToXmlFunction
{
    private readonly ILogger _logger;


    public JsonToXmlFunction(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<JsonToXmlFunction>();
    }



    [Function("JsonToXmlFunction")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
    {
        _logger.LogInformation("JSON => XML mapping started.");
        
        var body = await req.LogRequestAsync(_logger);

        if (string.IsNullOrWhiteSpace(body))
        {
            var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
            await badResponse.WriteStringAsync("Request body cannot be empty");
            return badResponse;
        }
        JObject input;

        try
        {
            input = JObject.Parse(body);
        }
        catch (Exception) 
        {
            var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
            await badResponse.WriteStringAsync("Invalid JSON format");
            return badResponse;
        }

        var xml = new XElement("Order",
            new XAttribute("id", (string)input["order"]?["orderId"] ?? "Unknown"),
            new XElement("Customer",
            new XElement("Name", (string)input["customer"]?["name"] ?? "Unknown")
            ),
            new XElement("Shipping",
            new XElement("City", (string)input["shipping"]?["city"] ?? "Unknown")
            ),
            new XElement("Amount", (string)input["order"]?["amount"] ?? "0"),
            new XElement("MappedAtUtc", DateTime.UtcNow)
            );
        
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/xml");
        await response.WriteStringAsync(xml.ToString());
        return response;                
    }
}