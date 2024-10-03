using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PTNF.Models.DTOs;
using PTNF.Services;
using System.Data;

public class SPAsignarSaldoService : ISPAsignarSaldoService
{
    private readonly IConfiguration _configuration;

    public SPAsignarSaldoService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<GestorSaldoDTO>> ExecuteStoredProcedureAsync()
    {
        string connectionString = _configuration.GetConnectionString("CadenaSql");
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();
            using (SqlCommand command = new SqlCommand("SP_AsignarSaldos", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    //Mapeo el resultado a al DTO
                    List<GestorSaldoDTO> resultList = new List<GestorSaldoDTO>();
                    while (await reader.ReadAsync())
                    {
                        GestorSaldoDTO gestorSaldo = new GestorSaldoDTO
                        {
                            GestorId = reader.GetInt32(reader.GetOrdinal("GestorId")),
                            Gestor = reader.GetString(reader.GetOrdinal("Gestor")),
                            NombreCta = reader.GetString(reader.GetOrdinal("NombreCta")),
                            Saldo = reader.GetDecimal(reader.GetOrdinal("Saldo"))
                        };
                        resultList.Add(gestorSaldo);
                    }
                    return resultList;
                }
            }
        }
    }

}


