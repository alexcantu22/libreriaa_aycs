﻿using libreriaa_AYCS.Data.ViewModels;
using libreriaa_AYCS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
namespace libreriaa_AYCS.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Titulo = book.Titulo,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,
                Autor = book.Autor,
                CoverUrl = book.CoverUrl,
                dateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }
        //metodo que nos permite obtener una lista de todos los libros de la BD
         public List<Book> GetAllBks() => _context.Books.ToList();
        //metodo que nos permite obtener el libro por ID de la BD
       public Book GetBookById(int bookid) => _context.Books.FirstOrDefault(n => n.id == bookid);
        //metodo que nos permite editar una libro de todos los libros de la BD
        public Book UpdateBookById(int bookid, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid); 
            if (_book == null)
            {
                _book.Titulo = book.Titulo;
                _book.Descripcion = book.Descripcion;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.Genero = book.Genero;
                _book.Autor = book.Autor;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }
            return _book;
        }

        public void DeleteBookyById(int bookid)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid);
            if ( _book != null)
            {
                _context.Books.Remove( _book );
                _context.SaveChanges();
            }
        }

    }
}
