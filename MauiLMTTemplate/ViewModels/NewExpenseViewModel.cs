using Azure.AI.FormRecognizer.Models;
using Azure;
using MauiLMTTemplate.Models.Expenses;
using MauiLMTTemplate.Services.Azure;
using MauiLMTTemplate.ViewModels.Base;
using Microsoft.Extensions.Logging;

namespace MauiLMTTemplate.ViewModels
{
    public partial class NewExpenseViewModel : ViewModelBase
    {
        [ObservableProperty]
        private CreateExpense _NewExpense = new CreateExpense();

        [ObservableProperty]
        private decimal _Amount;

        private readonly ILogger<NewExpenseViewModel> _logger;
        private readonly IAzureOCRService _azureOCRService;

        public NewExpenseViewModel(INavigationService navigationService,
            ILogger<NewExpenseViewModel> logger,
            IAzureOCRService azureOCRService)
            : base(navigationService)
        {
            _logger = logger;
            _azureOCRService = azureOCRService;
        }

        public override Task InitializeAsync()
        {
            return base.InitializeAsync();
        }

        [RelayCommand]
        private async Task AddAttachAsync()
        {
            // Logic to capture or select a picture
            var receiptImage = await CaptureOrSelectImage().ConfigureAwait(false);

            // Optionally, you can display the image in the UI if needed
            // ...

            if (receiptImage != null)
            {
                // Perform OCR on the receipt image to extract the amount
                var extractedAmount = await PerformOCR(receiptImage).ConfigureAwait(false);

                // Update the Amount in the CreateExpense model
                if (extractedAmount.HasValue)
                {
                    NewExpense.Amount = extractedAmount.Value;
                    Amount = extractedAmount.Value;
                }
            }
        }

        [RelayCommand]
        private async Task SaveExpenseAsync()
        {
            await _navigationService.NavigateToAsync("..");
        }

        private async Task<Stream?> CaptureOrSelectImage()
        {
            try
            {
                // Ask the user if they want to use the camera or pick from the gallery
                string action = await Shell.Current.DisplayActionSheet(
                    "Add Photo",
                    "Cancel",
                    null,
                    "Take Photo",
                    "Pick from Gallery");

                FileResult photo = null;

                if (action == "Take Photo")
                {
                    // Check if the camera is available
                    if (MediaPicker.Default.IsCaptureSupported)
                    {
                        photo = await MediaPicker.CapturePhotoAsync();
                    }
                    else
                    {
                        _logger.LogError("Camera not available");
                        return null;
                    }
                }
                else if (action == "Pick from Gallery")
                {
                    photo = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                    {
                        Title = "Please pick a photo"
                    });
                }
                else
                {
                    return null; // User cancelled or tapped outside the action sheet
                }

                if (photo != null)
                {
                    var stream = await photo.OpenReadAsync();
                    return stream;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                _logger.LogError($"Capture/Select Image failed: {ex.Message}");
            }

            return null;
        }

        private async Task<decimal?> PerformOCR(Stream imageStream)
        {
            var client = _azureOCRService.GetClient();

            try
            {
                // Make sure the stream is at the beginning if it has been read before
                if (imageStream.CanSeek)
                {
                    imageStream.Position = 0;
                }

                RecognizeReceiptsOperation operation = await client.StartRecognizeReceiptsAsync(imageStream);
                Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
                RecognizedFormCollection receipts = operationResponse.Value;

                // Assume we take the first recognized receipt and get the total amount
                foreach (RecognizedForm receipt in receipts)
                {
                    if (receipt.Fields.TryGetValue("Total", out FormField totalField))
                    {
                        if (totalField.Value.ValueType == FieldValueType.Float)
                        {
                            return (decimal?)totalField.Value.AsFloat();
                        }
                        else if (totalField.Value.ValueType == FieldValueType.Int64)
                        {
                            return (decimal?)totalField.Value.AsInt64();
                        }
                        // Add additional type checks if necessary
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Receipt analysis failed: {ex.Message}");
            }

            return null;
        }
    }
}
