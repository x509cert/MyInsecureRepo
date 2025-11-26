using Microsoft.Data.SqlClient;

// ❌ Intentionally insecure – hard-coded credentials
var connectionString =
    "Server=localhost;" +
    "Database=MyDatabase;" +
    "User Id=demo_user;" +
    "Password=SuperSecretPassword123;" +
    "Encrypt=True;" +
    "TrustServerCertificate=True;";

try
{
    using var connection = new SqlConnection(connectionString);
    await connection.OpenAsync();

    Console.WriteLine("✅ Connected to SQL Server.");

    await using var command = new SqlCommand("SELECT @@VERSION", connection);
    var version = (string?)await command.ExecuteScalarAsync();

    Console.WriteLine("SQL Server version:");
    Console.WriteLine(version);
}
catch (SqlException ex)
{
    Console.Error.WriteLine("❌ SQL error:");
    Console.Error.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.Error.WriteLine("❌ General error:");
    Console.Error.Wri
