using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //Generic Constraint
    //class : Referans tip olabilir.
    //T : class,IEntity => Bir referans tipi olmalı, IEntity veya IEntity'den implemente olan bir şey olmalı.
    //T : class,IEntity,new() => new'lenebilir olmalı.
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        //Şartları sağlayan tüm öğeleri al.
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        //Yeni bir öğe ekle.
        void Add(T entity);
        //Bir öğeyi sil.
        void Delete(T entity);
        //Öğeyi güncelle.
        void Update(T entity);
    }
}
