using System;
using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data.Interface
{
    public interface ITable
    {
        IEnumerable<Table> GetAllTable();
        IEnumerable<Table> GetAllTableByDate(DateTime date);
        
    }
}
