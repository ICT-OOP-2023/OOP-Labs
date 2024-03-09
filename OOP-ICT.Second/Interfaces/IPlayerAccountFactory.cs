namespace OOP_ICT.Second.Interfaces;

public interface IPlayerAccountFactory
{
    IPlayerAccount CreatePlayerAccount(decimal initialBalance);
}