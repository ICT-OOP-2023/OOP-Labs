namespace OOP_ICT.Second.Interfaces;

public interface IPlayerAccount
{
    decimal Balance { get; }
    void Deposit(decimal amount);
    bool Withdraw(decimal amount);
}