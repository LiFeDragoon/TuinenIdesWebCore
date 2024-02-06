namespace TuinenIdes.be.Models
{
    public class ImageModel
    {
        public string FileName { get; set; }
        public string ImagePath { get; set; }
        public string ImageDescription { get; set; }

        public ImageModel()
        {
            ImageDescription = "No description available";
        }

        // Method to set the image path based on the web root
        public void SetImagePath(string webRootPath)
        {
            ImagePath = Path.Combine("Images", "ImageAdded", FileName);
        }
    }
}
