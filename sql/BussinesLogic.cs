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
        string GetError();
        void SetError(string sError);
    }




        public class BussinesLogic : IBussinesLogic
        {
            private readonly SqlDbContext _context;
        private string sError;

        public string GetError ()
        {
            return sError;
        }
        public void  SetError(string sError)
        
        {
           sError=sError;
        }

        public BussinesLogic()
        {
            
        }

        public BussinesLogic(SqlDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<terminals>> Get()
            {
            sError = "OK";

            try
            {
                var query = await _context.terminals.ToListAsync();
                if (query != null)
                    return query;
                else
                {
                    sError = "nema slogova";
                    return null;
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                return null;
            }
            
            }

        }
}
