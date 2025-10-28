using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostBuilderFuncApp;
using Newtonsoft.Json;

public static class HttpRequestDataExtensions
{
    public static async Task<string> LogRequestAsync(this HttpRequestData req, ILogger logger, bool prettyPrintJson = true)
    {
        logger.LogInformation("----- Incoming Request -----");

        logger.LogInformation("Method: {method}", req.Method);
        logger.LogInformation("URL: {url}", req.Url);

        //headers
        foreach(var header in req.Headers)
        {
            logger.LogInformation("Header => {key}: {value}", header.Key, string.Join(";",header.Value));
        }

        string body = null;

        //Read body safely by buffering first
        if(req.Body != null && req.Body.CanRead)
        {
            using var reader = new StreamReader(req.Body, Encoding.UTF8, leaveOpen: true);
            body = await reader.ReadToEndAsync();


            if (!string.IsNullOrEmpty(body))
            {
                if(prettyPrintJson && IsJson(body))
                {
                    try
                    {
                        var parsed = JsonConvert.DeserializeObject(body);
                        body = JsonConvert.SerializeObject(parsed, Formatting.Indented);
                    }
                    catch 
                    { 
                        //ignore pretty print errors and keep raw body
                    }
                }
                logger.LogInformation("Body: {body}", body);
            }
        }
        logger.LogInformation("----- End Request -----");
        return body;
    }
    static bool IsJson(string s)
    {
        s = s?.Trim();
        return s!= null && (s.StartsWith("{") || s.StartsWith("["));
    }
}
