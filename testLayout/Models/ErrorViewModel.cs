namespace testLayout.Models
{
    // The ErrorViewModel class represents data for displaying error information in views
    public class ErrorViewModel
    {
        // Gets or sets the unique request identifier associated with the error
        public string? RequestId { get; set; }

        // A computed property that indicates whether to show the request ID in the view
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
