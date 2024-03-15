
using OOP_ICT.Abstractions;
using OOP_ICT.Second.Abstractions;

namespace OOP_ICT.Second.Models;

public class Account : IAccount
{
    public string Name { get; }
    public uint Balance { get; set; }
    public Person Owner { get; }

    public Account(Person owner)
    {
        Name = owner.Name;
        Balance = 0;
        Owner = owner;
    }
}