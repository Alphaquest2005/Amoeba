using SystemInterfaces;
using EFRepository;

namespace DataServices.Actors
{
    public static class CreateEntityExtensions
    {
        
        public static void CreateEntity<TEntity>(this ICreateEntity<TEntity> msg) where TEntity: class, IEntity
        {
            EF7DataContext<TEntity>.Create(msg);
        }

    }


}