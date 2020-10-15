using corrsDashboard.IRepositories;
using corrsDashboard.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace corrsDashboard.Repositories
{
    public class Addreasoncode : IAddreasoncode
    {
        corrsdatabaseContext db;
        public Addreasoncode(corrsdatabaseContext _db)
        {
            db = _db;
        }
        public async Task<List<Metricbasedreasoncodeview>> Getallreasoncode()
        {
            if (db != null)
            {
                return await db.Metricbasedreasoncodeview.ToListAsync();
            }

            return null;
        }
    }
}
