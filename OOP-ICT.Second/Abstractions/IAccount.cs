using OOP_ICT.Abstractions;

namespace OOP_ICT.Second.Abstractions;

public interface IAccount
{
    string Name { get; }
    
    uint Balance { get; set; }
    
    Person Owner { get; }
}