using cadastro.Interfaces;
using cadastro.Models;
using System.Data.SqlClient;

namespace cadastro.Repositories
{
    internal class AccountRepository : IAccount
    {
        private readonly string stringConexao = "Server=labsoft.pcs.usp.br; Initial Catalog=db_2; User id=usuario_2; pwd=8781878478;";

        public List<Account> ReadAll()
        {
            List<Account> listAccounts = new();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT * FROM Accounts";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Account account = new()
                        {
                            IdAccount = rdr["IdAccount"].ToString(),
                            Name = rdr[1].ToString(),
                            Email = rdr[2].ToString(),
                            Password = rdr[3].ToString(),
                        };

                        listAccounts.Add(account);
                    }
                }
            }

            return listAccounts;
        }
    }
}