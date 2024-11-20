
using libreriaa_AYCS.Data.Models;
using libreriaa_AYCS.Data.ViewModels;
using libreriaa_AYCS.Exceptions;
using System;
using System.Linq;
using System.Text.RegularExpressions;

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
        public Publisher AddPublisher(PublisherVM publisher)
        {
            if (StringsStartWithNumber(publisher.Name)) throw new PublisherNameException("El nombre empieza con un numero",
               publisher.Name);
            var _Publisher = new Publisher()
            {
                Name = publisher.Name
               
            };
            _context.Publishers.Add(_Publisher);
            _context.SaveChanges();

            return _Publisher;
        }

        public Publisher GetPublisherByID(int id) => _context.Publishers.FirstOrDefault(n => n.Id == id);

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

        internal void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
            if (_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"La editora con el id {id} no existe!");
            }
        }
        private bool StringsStartWithNumber(string name) => (Regex.IsMatch(name, @"^\d"));
        }
    }

