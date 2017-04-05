using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DEA.Database.Repository
{
    public static class BaseRepository<TEntity> where TEntity : class
    {
        //Must have this here otherwise the context closes too soon and won't save or get from database!
        private static readonly DEAContext db = new DEAContext();

        public static async Task InsertAsync(TEntity entity)
        {
           
                db.Set<TEntity>().Add(entity);
                db.Entry(entity).State = EntityState.Added;
                await db.SaveChangesAsync();
            
        }

        public static async Task UpdateAsync(TEntity entity)
        {
            
                db.Set<TEntity>().Add(entity);
                db.Entry(entity).State = EntityState.Modified;
                await db.SaveChangesAsync();
            
        }

        public static async Task DeleteAsync(TEntity entity)
        {
            
                db.Set<TEntity>().Remove(entity);
                db.Entry(entity).State = EntityState.Deleted;
                await db.SaveChangesAsync();
            
        }

        public static IQueryable<TEntity> GetAll()
        {
           return db.Set<TEntity>();
        }

    }
}
