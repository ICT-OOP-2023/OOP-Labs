using OOP_ICT.Abstractions;

namespace OOP_ICT.Second.Abstractions;

public interface IBank
{
    void Deposit(Person player, uint sum);
    
    void Withdraw(Person player, uint sum);
    
    bool CheckTheAmountOfMoneyToBet(Person player, uint sum);
    
    uint GetBalance(Person player);
    
    IAccount GetAccount(Person player);
    
    void CreateAccount(Person player);
    
    void RemoveAccount(Person player);
}