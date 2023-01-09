using System;
using FirebirdSql.Data.FirebirdClient;
using System.Configuration;
using System.Data;

namespace CadastroDePessoas
{
    public class Conexao
    {
        private static readonly Conexao instanciaFireBird = new Conexao();

        private Conexao() { }

        public static Conexao getInstancia()
        {
            return instanciaFireBird;
        }

        public FbConnection getConexao()
        {
            string conn = ConfigurationManager.ConnectionStrings["FireBirdConnectionString"].ToString();
            return new FbConnection(conn);
        }

        public static DataTable fb_GetDados()
        {
            using (FbConnection conexaoFireBird = Conexao.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();

                    string mSQL = "Select * from Pessoas";

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataAdapter da = new FbDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }

        public static void fb_InserirDados(Pessoa pessoa)
        {
            using (FbConnection conexaoFireBird = Conexao.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();

                    string mSQL = "INSERT into Pessoas Values(" + pessoa.ID + ",'" + pessoa.Nome + "','" + pessoa.Endereco + "','" + pessoa.Telefone + "','" + pessoa.Email + "')";

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_ExcluirDados(int id)
        {
            using (FbConnection conexaoFireBird = Conexao.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();

                    string mSQL = "DELETE from Pessoas Where id= " + id;

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static Pessoa fb_ProcuraDados(int id)
        {
            using (FbConnection conexaoFireBird = Conexao.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();

                    string mSQL = "Select * from Pessoas Where id = " + id;

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    FbDataReader dr = cmd.ExecuteReader();

                    Pessoa pessoa = new Pessoa();
                    while (dr.Read())
                    {
                        pessoa.ID = Convert.ToInt32(dr[0]);
                        pessoa.Nome = dr[1].ToString();
                        pessoa.Endereco = dr[2].ToString();
                        pessoa.Telefone = dr[3].ToString();
                        pessoa.Email = dr[4].ToString();
                    }
                    return pessoa;

                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
        public static void fb_AlterarDados(Pessoa pessoa)
        {
            using (FbConnection conexaoFireBird = Conexao.getInstancia().getConexao())
            {
                try
                {
                    conexaoFireBird.Open();

                    string mSQL = "Update Pessoas set nome= '" + pessoa.Nome + "', endereco= '" + pessoa.Endereco + "', telefone = '" + pessoa.Telefone + "', email= '" + pessoa.Email + "'" + " Where id= " + pessoa.ID;

                    FbCommand cmd = new FbCommand(mSQL, conexaoFireBird);
                    cmd.ExecuteNonQuery();
                }
                catch (FbException fbex)
                {
                    throw fbex;
                }
                finally
                {
                    conexaoFireBird.Close();
                }
            }
        }
    }
}
