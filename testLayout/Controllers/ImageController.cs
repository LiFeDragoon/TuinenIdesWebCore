using Microsoft.AspNetCore.Mvc;
using TuinenIdes.be.Models;

public class ImageController : Controller
{
	private const string Username = "Ides";
	private const string Password = "25011989";
	private readonly IWebHostEnvironment _environment;

	public ImageController(IWebHostEnvironment environment)
	{
		_environment = environment;
	}

	public ActionResult Index()
	{
		bool isAuthenticated = HttpContext.User.Identity.IsAuthenticated;

		System.Diagnostics.Debug.WriteLine($"IsAuthenticated: {isAuthenticated}");



		var imageDirectory = Path.Combine(_environment.WebRootPath, "Images", "ImageAdded");
		var imageFiles = Directory.GetFiles(imageDirectory);

		var imageModels = new List<ImageModel>();
		foreach (var imageFile in imageFiles)
		{
			var fileName = Path.GetFileName(imageFile);
			var imageModel = new ImageModel { FileName = fileName };
			imageModel.SetImagePath(_environment.WebRootPath); // Set the correct image path
			imageModels.Add(imageModel);
		}

		ViewBag.IsAuthenticated = isAuthenticated;

		return View(imageModels);
	}

	[HttpGet]
	public ActionResult Login()
	{
		return View();
	}
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Login(string username, string password)
	{
		if (username == Username && password == Password)
		{
			HttpContext.Session.SetString("IsAuthenticated", "true");
			return RedirectToAction("Index");
		}
		else
		{
			// Clear any existing authentication status
			HttpContext.Session.Remove("IsAuthenticated");
			ViewBag.Error = "Invalid username or password";
			return View();
		}
	}


	public ActionResult Logout()
	{
		HttpContext.Session.Remove("IsAuthenticated");
		ViewBag.IsAuthenticated = false; // Reset IsAuthenticated
		return RedirectToAction("Index");
	}


	[HttpGet]
	public ActionResult Create()
	{
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Create(IFormFile file)
	{
		if (file != null && file.Length > 0)
		{
			var imageDirectory = Path.Combine(_environment.WebRootPath, "Images", "ImageAdded");
			var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
			var filePath = Path.Combine(imageDirectory, fileName);

			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				file.CopyTo(stream);
			}
		}

		return RedirectToAction("Index");
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult Delete(string fileName)
	{
		var imagePath = Path.Combine(_environment.WebRootPath, "Images", "ImageAdded", fileName);
		if (System.IO.File.Exists(imagePath))
		{
			System.IO.File.Delete(imagePath);
		}

		return RedirectToAction("Index");
	}
}
