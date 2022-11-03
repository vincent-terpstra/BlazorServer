namespace DataAccess.DbAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadDataAsync<T, U>(
        string storedProcedure,
        U parameters);

    Task SaveDataAsync<T>(
        string storedProcedure,
        T parameters);
}