using Azure.AI.FormRecognizer;

namespace MauiLMTTemplate.Services.Azure
{
    public interface IAzureOCRService
    {
        FormRecognizerClient GetClient();
    }
}