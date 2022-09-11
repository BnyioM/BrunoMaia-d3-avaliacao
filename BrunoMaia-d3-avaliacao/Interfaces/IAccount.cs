using cadastro.Models;

namespace cadastro.Interfaces
{
    public interface IAccount
    {
        List<Account> ReadAll();
    }
}