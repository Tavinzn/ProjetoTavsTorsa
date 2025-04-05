using MySql.Data.MySqlClient;
using ProjetoTT.Models;
using System.Data;



namespace ProjetoTT.Repositorio
{
    public class UsuarioRepositorio
    {
        //STRING DE CONEXÃO
        private readonly string _conexaoMySQL;
        public UsuarioRepositorio(IConfiguration configuration)
        {
            _conexaoMySQL = configuration.GetConnectionString("ConexaoMySQL");
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new("INSERT INTO Usuario (Nome, Email, Senha) VALUES (@Nome,@Email,@Senha)", conexao);
                cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                cmd.ExecuteNonQuery();
            }
        }

        public Usuario ObterUsuario(string email)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new("SELECT * FROM Usuario WHERE Email = @email", conexao);
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                /* cmd.Parameters.AddWithValue("@Email", email);*/

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Usuario usuario = new Usuario();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    usuario.Id = Convert.ToInt32(dr["Id"]);
                    usuario.Nome = (string)dr["Nome"];
                    usuario.Email = (string)dr["Email"];
                    usuario.Senha = (string)dr["Senha"];

                }
                return usuario;
            }
        }
    }
}

