using Azure;
using Azure.AI.FormRecognizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLMTTemplate.Services.Azure
{
    public class AzureOCRService : IAzureOCRService
    {
        public FormRecognizerClient _client;

        public AzureOCRService()
        {

        }

        private FormRecognizerClient InitClient()
        {
            string endpoint = "https://westeurope.api.cognitive.microsoft.com/";
            string apiKey = "cd19fdc5076e49eb814da592e04e9b95";
            return _client = new FormRecognizerClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
        }

        public FormRecognizerClient GetClient()
        {
            return _client ??= InitClient();
        }
    }
}
