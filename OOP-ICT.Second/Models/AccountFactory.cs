using OOP_ICT.Abstractions;
using OOP_ICT.Second.Abstractions;

namespace OOP_ICT.Second.Models;

public class AccountFactory : IAccountFactory
{
    public IAccount CreateAccount(Person player)
    {
        return new Account(player);
    }
}