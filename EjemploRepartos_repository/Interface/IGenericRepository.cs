namespace EjemploRepartos_repository.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        T CreateGeneric<T>(T entity) where T : class;
        List<T> CreateRangeGeneric<T>(List<T> entity) where T : class;
        T UpdateGeneric<T>(T entity) where T : class;
        Task<int> SaveChangesAsync();
        T RemoveGeneric<T>(T entity) where T : class;
        List<T> UpdateRangeGeneric<T>(List<T> entity) where T : class;
        List<T> RemoveRangeGeneric<T>(List<T> entity) where T : class;
    }
}
