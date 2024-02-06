using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;


public class EmailHandelingController : Controller
{
    // GET: EmailHandeling (This is not required in your specific case)
    public ActionResult Index()
    {
        return View();
    }
    public ActionResult Thanks()
    {
        return View();
    }

    // POST: EmailHandeling/SubmitEmail
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult SubmitEmail(string email, string message)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(message))
        {
            // If any of the fields are empty or have only white spaces,
            // redirect back to the "Contact" (Index) page
            return RedirectToAction("Index");
        }
        // Replace the following email address with your desired recipient email
        string recipientEmail = "tuinenides@gmail.com, lieven.delameillieure@gmail.com";

        // Configure your SMTP server settings
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
        smtpClient.Port = 587; // Use the appropriate port for your SMTP server
        smtpClient.EnableSsl = true; // Use SSL if required
        smtpClient.Credentials = new System.Net.NetworkCredential("webbrowserclient@gmail.com", "ttodwsfbwnxhaefm");

        // Create the email message
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress(email); // Sender's email address
        mailMessage.To.Add(recipientEmail); // Recipient's email address
        mailMessage.Subject = "Contact Form Submission"; // Subject of the email
        mailMessage.Body = $"From: {email}\n\nMessage: {message}";


        try
        {
            // Send the email
            smtpClient.Send(mailMessage);

            // Redirect to the "Thanks" page upon successful email submission
            return RedirectToAction("Thanks");
        }
        catch (Exception ex)
        {
            // Handle any exceptions that occurred while sending the email.
            // Redirect back to the "Contact" (Index) page in case of an error
            return RedirectToAction("Index", "EmailHandeling");
        }
    }
}
