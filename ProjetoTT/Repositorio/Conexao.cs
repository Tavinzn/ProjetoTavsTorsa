using MySql.Data.MySqlClient;
using ProjetoTT.Models;
using System.Data;

namespace ProjetoTT.Repositorio
{
    public class Conexao
    {
        //Declaração privada e somente de leitura
        private readonly string _connectionString;

        //metodo de configuração chamando a string de conexão no appsettings.json 
        public UsuarioRepositorio(IConfiguration configuration) => _connectionString = configuration.GetConnectionString("DefaultConnection");

        // metodo adicionar usuario(esse metodo aparece na controller)
        public void AdicionarUsuario(Usuario usuario)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.CreateCommand();
                cmd.CommandText = "INSERT INTO Usuarios (Nome, Email, Senha) VALUES (@Nome, @Email, @Senha)";
                cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
