using SystemInterfaces;
using EFRepository;

namespace DataServices.Actors
{
    public static class DeleteEntityExtensions
    {
        
        public static void DeleteEntity<TEntity>(this IDeleteEntity<TEntity> msg) where TEntity : class, IEntity
        {
            EF7DataContext<TEntity>.Delete(msg);
        }

    }
}