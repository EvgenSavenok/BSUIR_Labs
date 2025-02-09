using Microsoft.Data.SqlClient;

namespace Chat_Sirinity_Server.Database;

public class AuthenticationDb
{
    private const string ConnectionString = "Server=EUGENSAVENOK;Database=ChatSirinity;Trusted_Connection=True;TrustServerCertificate=True;";
    public async Task<bool> TryLoginUser(string login, string password)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            await connection.OpenAsync();
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT COUNT(*) FROM ClientsAuthenticationData WHERE Name = @Name AND Password = @Password";
            command.Parameters.AddWithValue("@Name", login);
            command.Parameters.AddWithValue("@Password", password);
            command.Connection = connection;
            int count = (int)await command.ExecuteScalarAsync();
            return count > 0;
        }
    }

    public async Task<int> GetIdByName()
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            await connection.OpenAsync();
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT ID FROM ClientsAuthenticationData WHERE Name = @Name";
            command.Parameters.AddWithValue("@Name", AuthenticationDbCols.Name);
            command.Connection = connection;
            object result = command.ExecuteScalar();
            return Convert.ToInt32(result);
        }
    }

    public async Task<bool> TryRegisterUser(string login, string password)
    {
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            await connection.OpenAsync();
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO ClientsAuthenticationData (Name, Password) VALUES (@Name, @Password)";
            command.Parameters.AddWithValue("@Name", login);
            command.Parameters.AddWithValue("@Password", password);
            command.Connection = connection;
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
                return true;
            else
                return false;
        }
    }
}
