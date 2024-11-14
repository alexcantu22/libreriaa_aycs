
using libreriaa_AYCS.Data.Models;
using libreriaa_AYCS.Data.ViewModels;
using System;
using System.Linq;

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

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publishers.Where(N => N.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthorsVM()
                {
                    Name = n.Name,
                    BookAuthors = n.Books.Select(n => new BookAuthorVM()
                    {
                        BookName = n.Titulo,
                        BookAuthors = n.Book_Authors.Select(n => n.Author.FullName).ToList()
                    }).ToList()
                }).FirstOrDefault();
            return _publisherData;
        }
    }
}
