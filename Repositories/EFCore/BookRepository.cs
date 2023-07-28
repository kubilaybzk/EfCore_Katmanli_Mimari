using System;
using Entities.Models;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneBook(Book book)
        =>
            Create(book);
        

        public void DeleteOneBook(Book book)
        =>
            Delete(book);
        

        public IQueryable<Book> GetAllBooks(bool trackchanges)
        =>
            FindAll(trackchanges).OrderBy(b=>b.Id);
        

        public IQueryable<Book> GetOneBookById(int id, bool trackchanges)
        =>
            FindByCondition(b=>b.Id==id, trackchanges);
        

        public void UpdateOneBook(Book book)
        =>
            Update(book);
        
    }
}

