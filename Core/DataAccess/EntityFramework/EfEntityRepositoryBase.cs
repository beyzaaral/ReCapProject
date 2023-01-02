using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity : class,IEntity,new()
        where TContext:DbContext,new()
    {
        public void Add(TEntity entity)
        {
            //Idısposeble pattern implementation of c#
            using (TContext context = new TContext())   //okuldan sql dosyasını alınca dosya adını yaz
            {
                //addedEntity - değişken 
                var addedEntity = context.Entry(entity);  //referansı yakalamak için yazılır.
                addedEntity.State = EntityState.Added; //o aslında eklenecek liste
                context.SaveChanges();  //ekle 

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //addedEntity - değişken 
                var deletedEntity = context.Entry(entity);  //referansı yakalamak için yazılır.
                deletedEntity.State = EntityState.Deleted; //o aslında silinecek liste
                context.SaveChanges();  //sil 

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)

        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        //lamda olarak kullanılıyor üst kısım
        {
            //eğer filtre göndermediyse veri kaynağındaki tüm data'yı getir ama filtre verdiyse ona göre data'yı listele
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
                //ilk alanda filte olmadan datayı getiriyor            ikinci alanda filtreleyerek getirir
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //addedEntity - değişken 
                var updatedEntity = context.Entry(entity);  //referansı yakalamak için yazılır.
                updatedEntity.State = EntityState.Modified; //o aslında güllenecek liste
                context.SaveChanges();  //güncelle 

            }
        }
    }
}
