using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
// using Newtonsoft.Json;
using System.Text.Json;
using testBackend.Models;
using System.Text;
using Newtonsoft.Json;

namespace testBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("Policy")]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private string clioToken;

        public ContactsController(ILogger<ContactsController> logger)
        {
            _logger = logger;
            // get clio token
            using (StreamReader r = new StreamReader("./ApiKeys/apikeys.json"))
            {
                string json = r.ReadToEnd();
                ApiKeyList apikeys = JsonConvert.DeserializeObject<ApiKeyList>(json);
                clioToken = apikeys.clioToken;
            }
        }

        // get all contacts
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            string url = $"https://app.clio.com/api/v4/contacts.json";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", clioToken);
                var responseTask = await client.GetStringAsync(url);

                return Ok(responseTask);
            }
        }

        // get single contact with id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetContact(string id)
        {
            string url = $"https://app.clio.com/api/v4/contacts/{id}.json";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", clioToken);
                var responseTask = await client.GetAsync(url);

                if (responseTask.IsSuccessStatusCode)
                {
                    var responseTaskString = await client.GetStringAsync(url);
                    return Ok(responseTaskString);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpPost]
        public async void AddNewContact()
        {
            NewContact nc = new NewContact()
            {
                Name = "From WebApi",
                Type = "Person"
            };

            string url = $"https://app.clio.com/api/v4/contacts.json";

            // use httpclient to send post request

            
        }
    }
}
