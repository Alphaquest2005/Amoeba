using SystemInterfaces;
using EFRepository;

namespace DataServices.Actors
{
    public static class EntityChangesExtensions
    {
        public static void UpdateEntity<TEntity>(this IUpdateEntityWithChanges<TEntity> msg) where TEntity : class, IEntity
        {

            EF7DataContext<TEntity>.Update(msg);
        }

        public static void AddEntity<TEntity>(this IAddOrGetEntityWithChanges<TEntity> msg) where TEntity : class, IEntity
        {

            EF7DataContext<TEntity>.Add(msg);
        }
    }
}