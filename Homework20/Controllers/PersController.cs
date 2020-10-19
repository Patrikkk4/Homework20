using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Homework20.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Homework20.Controllers
{
    public class PersController : Controller
    {
        public List<Character> Characters { get; set; } = new List<Character>();

        IWebHostEnvironment webHost;

        public PersController(IWebHostEnvironment webHost)
        {
            this.webHost = webHost;
        }

        public IActionResult Pers()
        {
            ViewBag.chrs = GetCharacters();

            return View();
        }

        private List<Character> GetCharacters()
        {
            string temp = System.IO.File.ReadAllText("pers.json");

            var tempJson = JsonConvert.DeserializeObject<List<Character>>(temp);

            return tempJson;
        }

        [HttpPost]
        public IActionResult AddPers(IFormFile uploadImage, string name, string bio)
        {           
            string img = $@"/Images/{uploadImage.FileName}";

            UploadFile(img, uploadImage);

            Characters = GetCharacters();

            Character character = new Character(img, name, bio);           

            Characters.Add(character);

            string temp = JsonConvert.SerializeObject(Characters);

            System.IO.File.WriteAllText("pers.json", temp);

            return Redirect("/Pers/Pers");
        }

        private async void UploadFile(string path, IFormFile uploadImage)
        {
            using (var FileStream = new FileStream($@"{webHost.WebRootPath}/{path}", FileMode.Create))
            {
                await uploadImage.CopyToAsync(FileStream);
            }
        }
    }
}
