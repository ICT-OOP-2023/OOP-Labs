using OOP_ICT.Second.Interfaces;

namespace OOP_ICT.Second.Models;

public class PlayerAccountFactory
{
    public IPlayerAccount CreatePlayerAccount(decimal initialBalance)
    {
        return new PlayerAccount(initialBalance);
    }
}