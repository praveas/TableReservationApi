using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Data.DB;
using Commander.Data.Interface;
using Commander.Models;

namespace Commander.Data.Implementation
{
    public class SqlTableRepo : ITable
    {
        private readonly CommanderContext _context;

        public SqlTableRepo(CommanderContext context)
        {
            _context = context;
        }

        public IEnumerable<Table> GetAllTable()
        {
            return _context.Table.ToList();
        }

        public IEnumerable<Table> GetAllTableByDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
