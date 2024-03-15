using OOP_ICT.Abstractions;

namespace OOP_ICT.Second.Abstractions;

public interface IAccountFactory
{
    IAccount CreateAccount(Person player);
}