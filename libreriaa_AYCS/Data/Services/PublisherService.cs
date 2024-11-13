
using libreriaa_AYCS.Data.Models;
using libreriaa_AYCS.Data.ViewModels;
using System;

namespace libreriaa_AYCS.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }
        //metodo que nos deja agregar una nueva Editora a la BD
        public void AddPublisher(PublisherVM publisher)
        {
            var _Publisher = new Publisher()
            {
                Name = publisher.Name
               
            };
            _context.Publishers.Add(_Publisher);
            _context.SaveChanges();
        }
    }
}
