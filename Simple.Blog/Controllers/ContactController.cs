

using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoRepository;
using Simple.Blog.Models;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace Simple.Blog.Controllers
{
    public class ContactController:SurfaceController
    {
        private readonly MongoClient Client;
        private readonly IMongoDatabase DB;

        public ContactController(
            IConfiguration configuration,
            IUmbracoContextAccessor umbracoContextAccessor,
            IUmbracoDatabaseFactory databaseFactory,
            ServiceContext services,
            AppCaches appCaches,
            IProfilingLogger profilingLogger,
            IPublishedUrlProvider publishedUrlProvider)
            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            Client = new MongoClient(configuration["MyKey"]);
            DB = Client.GetDatabase("simpleblog");
        }

        [HttpPost]
        public IActionResult CreateContactMessage(ContactViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return CurrentUmbracoPage();
                }
                var collection = DB.GetCollection<ContactViewModel>("Contact");
                // var contactMessage = contactRepository.Add(model);
                collection.InsertOne(model);
                //ViewBag.Contact = contactMessage;
                return RedirectToCurrentUmbracoPage();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
