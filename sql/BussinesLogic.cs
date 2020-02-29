using BlazorApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Service
{

    public interface IBussinesLogic
    {
        Task<IEnumerable<terminals>> Get();

    }


        public class BussinesLogic : IBussinesLogic
        {
            private readonly SqlDbContext _context;

            public BussinesLogic(SqlDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<terminals>> Get()
            {

            try
            {
                var query = await _context.terminals.ToListAsync();
                if (query != null)
                    return query;
                else
                    return null;
            }
            catch (Exception ex)
            {

                return null;
            }
            }

        }
}
