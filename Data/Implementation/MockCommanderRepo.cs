using System;
using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data.Implementation
{
    public class MockCommanderRepo : ICommanderRepo // call the name of the interface to implement
    {
        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" },
                new Command { Id = 1, HowTo = "Cut Bread", Line = "Get a Knife", Platform = "Knife & Chopping Board" },
                new Command { Id = 2, HowTo = "Make a cup of tea", Line = "Place teabag to cup", Platform = "Cup & Kettle" }
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}
