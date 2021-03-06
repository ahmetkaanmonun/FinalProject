﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{

    //NuGet

    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposable pattern implementation of C#
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); //referansı yakala
                addedEntity.State = EntityState.Added; //ekle
                context.SaveChanges(); //işlemleri yap
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); //referansı yakala
                deletedEntity.State = EntityState.Deleted; //sil
                context.SaveChanges(); //işlemleri yap
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                return context.Set<Product>().SingleOrDefault(filter);

            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {

                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); //referansı yakala
                updatedEntity.State = EntityState.Modified; //güncelle
                context.SaveChanges(); //işlemleri yap
            }
        }
    }
}
