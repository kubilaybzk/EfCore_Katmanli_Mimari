using System;
using Entities.Models;

namespace Repositories.Contracts
{
	public interface IBookRepository:IRepositoryBase<Book>
	{
		//Bu repository altında sorgulanabilir ifadeler Crud ifadeleri vs için ,
		//Bir Contract belirtmiş oluyoruz, Daha sonrası için buralarda eklemeler yapılacak pagination vs vs için

		void CreateOneBook(Book book);

        void UpdateOneBook(Book book);

        void DeleteOneBook(Book book);

		IQueryable<Book> GetAllBooks(bool trackchanges);

		IQueryable<Book> GetOneBookById(int id, bool trackchanges);

    }
}

