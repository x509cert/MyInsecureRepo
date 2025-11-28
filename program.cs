using Microsoft.Data.SqlClient;

// ❌ Intentionally insecure – hard-coded credentials
var connectionString =
    "Server=localhost;" +
    "Database=MyDatabase;" +
    "User Id=demo_user;" +
    "Password=SuperSecretPassword123;" +
    "Encrypt=True;" +
    "TrustServerCertificate=True;";

var storageString = 
    "sv=2024-11-04&ss=b&srt=s&sp=rltf&se=2025-12-01T03:28:03Z&st=2025-11-28T19:13:03Z&spr=https&sig=xoJSdIqujDvXcjP5PF4o20Ia623NfG996hoxZthN4cc%3D"; 

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
