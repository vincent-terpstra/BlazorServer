namespace DataAccess.DbAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(
        string storedProcedure,
        U parameters);

    Task SaveData<T>(
        string storedProcedure,
        T parameters);
}