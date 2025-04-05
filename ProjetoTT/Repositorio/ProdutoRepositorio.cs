using MySql.Data.MySqlClient;
using ProjetoTT.Models;
using System.Data;

namespace ProjetoTT.Repositorio
{
    public class ProdutoRepositorio
    {
        //STRING DE CONEXÃO
        private readonly string _conexaoMySQL;
        public ProdutoRepositorio(IConfiguration configuration)
        {
            _conexaoMySQL = configuration.GetConnectionString("ConexaoMySQL");
        }
        public void AdicionarProduto(Produto produto)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                MySqlCommand cmd = new("INSERT INTO Produto (Nome, Descricao, Preco) VALUES (@Nome,@Descricao,@Preco)", conexao);
                cmd.Parameters.AddWithValue("@Nome", produto.Nome);
                cmd.Parameters.AddWithValue("@Descricao",produto.Descricao);
                cmd.Parameters.AddWithValue("@Preco",produto.Preco);
                cmd.ExecuteNonQuery();

            }
        }

        public Produto ObterProduto(string nome)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new("SELECT * FROM Usuario WHERE Nome = @nome", conexao);
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = nome;
                /* cmd.Parameters.AddWithValue("@Email", email);*/

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Produto produto = new Produto();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (dr.Read())
                {
                    produto.Id = Convert.ToInt32(dr["Id"]);
                    produto.Nome = (string)dr["Nome"];
                    produto.Descricao = (string)dr["Descricao"];
                    produto.Preco = (Decimal)dr["Preco"];

                }
                return produto;
            }
        }
    }
}

