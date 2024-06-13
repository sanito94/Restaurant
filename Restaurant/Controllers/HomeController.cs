﻿using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Models.Contact;
using Restaurant.Infrastructure.Data.Models;
using Restaurant.Models;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using Restaurant.Infrastructure.Data;
using Restaurant.Core.Services;
using Restaurant.Core.Models.Menu;
using Restaurant.Core.Contracts;
using Restaurant.Core.Models.BookATable;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RestaurantDbContext context;

        public HomeController(
            ILogger<HomeController> logger,
            RestaurantDbContext _context)
        {
            _logger = logger;
            context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult About()
        {
            return View();
        }

        public IActionResult Event()
        {
            return View();
        }

        public IActionResult Chef()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }

        public IActionResult BookTable()
        {
            var model = new BookATableViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> BookTable(BookATableViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("BookATableFormError", "Error");
            }

            BookATable table = new BookATable() 
            {
                Name = model.Name,
                Email= model.Email,
                PhoneNumber = model.PhoneNumber,
                Day = model.Day,
                Hour = model.Hour,
                NumberOfPeople = model.NumberOfPeople,
            };

            await context.BookATables.AddAsync(table);
            await context.SaveChangesAsync();

            return RedirectToAction("BookATableForm", "Success");
        }

        public IActionResult Contact()
        {
            var model = new ContactViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("ContactFormError", "Error");
            }

            Contact sender = new Contact()
            {
                SenderEmail = model.SenderEmail,
                SenderName = model.SenderName,
                Message = model.Message,
                Date = DateTime.Now,
                Subject = model.Subject,
                PhoneNumber = model.PhoneNumber,
            };

            
            string fromMail = "maskata1994@gmail.com";
            string fromPassword = "rnfa pook vlsc lelr";

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            MailMessage mailMessageToMe = new MailMessage();
            mailMessageToMe.From = new MailAddress(sender.SenderEmail);
            mailMessageToMe.Subject = sender.Subject;
            mailMessageToMe.To.Add(new MailAddress(fromMail));
            mailMessageToMe.Body = $"New message: {sender.Message}{Environment.NewLine} from: {sender.SenderEmail}";

            smtpClient.Send(mailMessageToMe);


            MailMessage mailMessageToSender = new MailMessage();
            mailMessageToSender.From = new MailAddress(fromMail);
            mailMessageToSender.Subject = "Auto Respond Message";
            mailMessageToSender.To.Add(new MailAddress(sender.SenderEmail));
            mailMessageToSender.Body = $"Thank you for contacting ChernevRestaurant. We will contact you as soon as possible";

            smtpClient.Send(mailMessageToSender);

            await context.Contacts.AddAsync(sender);
            await context.SaveChangesAsync();

            return RedirectToAction("SuccessContactForm", "Success");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}