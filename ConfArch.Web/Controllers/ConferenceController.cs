using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ConfArch.Data.Models;
using ConfArch.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConfArch.Web.Controllers
{
    [AllowAnonymous]
    public class ConferenceController: Controller
    {
        private readonly IConferenceRepository repo;
        public UserRepository userRepository;

        public ConferenceController(IConferenceRepository repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index(/*string password = "Starkenius"*//*UserRepository userRepository*/)
        {
            //user User = new user();
            //Console.WriteLine(user password.Sha256());
            //using (var sha = SHA256.Create())
            //{
            //    var bytes = Encoding.UTF8.GetBytes(password);
            //    var hash = sha.ComputeHash(bytes);

            //    /*return */Console.WriteLine(Convert.ToBase64String(hash));
            //}
            ViewBag.Title = "Organizer - Conference Overview";
            return View(await repo.GetAll());
        }

        public IActionResult Add()
        {
            ViewBag.Title = "Organizer - Add Conference";
            return View(new ConferenceModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ConferenceModel model)
        {
            if (ModelState.IsValid)
                await repo.Add(model);

            return RedirectToAction("Index");
        }
    }
}
