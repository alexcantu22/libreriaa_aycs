
using libreriaa_AYCS.Data.Models;
using libreriaa_AYCS.Data.ViewModels;
using System;

namespace libreriaa_AYCS.Data.Services
{
    public class AuthorService
    {
        private AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }
        //metodo que nos deja agregar un nuevo autor a la BD
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
               
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }
    }
}
