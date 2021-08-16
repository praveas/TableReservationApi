// This is the main Interface for Commander Repo
using System;
using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepo
    {
        // Interface is list of methods/ signature that need to be provided to the consumer of this interface
        // Defining all the CRUD operations available

        bool SaveChanges();

        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);


    }
}
