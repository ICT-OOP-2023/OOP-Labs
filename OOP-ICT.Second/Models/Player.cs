using OOP_ICT.Abstractions;

namespace OOP_ICT.Second.Models;

public class Player : Person
{
    private Player(string name) : base(name) {}

    public static PlayerBuilder Builder()
    {
        return new PlayerBuilder();
    }
    
    public class PlayerBuilder
    {
        private string _name;

        public PlayerBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
        
        public  Player Build()
        {
            return new Player(_name);
        }
    }
}