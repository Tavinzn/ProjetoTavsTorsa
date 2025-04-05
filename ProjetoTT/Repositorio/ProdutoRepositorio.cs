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
                conexao.Open();
                MySqlCommand cmd = new("INSERT INTO Produto (Nome, Descricao, Preco) VALUES (@Nome,@Descricao,@Preco);", conexao);
                cmd.Parameters.AddWithValue("@Nome", produto.Nome);
                cmd.Parameters.AddWithValue("@Descricao",produto.Descricao);
                cmd.Parameters.AddWithValue("@Preco",produto.Preco);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

