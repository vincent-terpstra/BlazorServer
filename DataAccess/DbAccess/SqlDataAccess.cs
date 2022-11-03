using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DataAccess.DbAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly string _connectionString;

    public SqlDataAccess(IConfiguration config, string connectionId = "Default")
    {
        _connectionString = config.GetConnectionString(connectionId)!;
    }

    public SqlDataAccess(string connectionString)
    {
        _connectionString = connectionString;
    }
    

    public async Task<IEnumerable<TResult>> LoadData<TResult, TRequest>(
        string storedProcedure,
        TRequest parameters)
    {
        using IDbConnection connection = new NpgsqlConnection(_connectionString);
        return await connection.QueryAsync<TResult>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(
        string storedProcedure,
        T parameters)
    {
        using IDbConnection connection = new NpgsqlConnection(_connectionString);
        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}
