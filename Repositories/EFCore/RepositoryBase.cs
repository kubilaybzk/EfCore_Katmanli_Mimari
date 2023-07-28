using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        /* 
         Şimdi burada soyut olarak bu classı tanımlıyoruz bu sayede

            Burada Crud işlemlerini yapmamız için neye ihtiyacımız var bir context nesnesine bunun için RepositoryContext'i kullanmamız gerekiyor.

            Context'e erişim sağlayacak işlemimizi burada gerçekleştirelim constructor üzerinden.

            Şimdi bunun newlenmemesi lazım yani burada şöyle bir durum söz konusu bu implementasyonlar sadece kalıtım ile devr alınsın başka türlü işlenemesin.

            Bundan dolayı RepositoryBase classımızın  abstrack olması lazım.


            
                
         */


        protected readonly RepositoryContext _context;

        public RepositoryBase(RepositoryContext context) {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
             _context.Set<T>().Update(entity);
        }

        

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool changeTracker)=>
            !changeTracker ?
             _context.Set<T>().Where(expression).AsNoTracking() :
             _context.Set<T>().Where(expression);
                                                                              
        public IQueryable<T> FindAll(bool changeTracker)=>
            !changeTracker ?
             _context.Set<T>().AsNoTracking() :
             _context.Set<T>();
            
        
    }
}

