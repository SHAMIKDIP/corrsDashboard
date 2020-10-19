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

        public void AddReasonCodes(ReasonCodes reasonCodes, int metricId)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                var reasonCodeData = db.ReasonCodes.FirstOrDefault(r => r.ReasonCode == reasonCodes.ReasonCode);
                if (reasonCodeData == null)
                {
                    db.ReasonCodes.Add(reasonCodes);
                    db.SaveChanges();

                    int newReasconCodeId = reasonCodes.ReasonCodeId;
                    AddMetricReasonCodeDependencyDetails(newReasconCodeId, metricId);
                }
                else
                {
                    AddMetricReasonCodeDependencyDetails(reasonCodeData.ReasonCodeId, metricId);
                }
                transaction.Commit();
            }
        }

        public void AddMetricReasonCodeDependencyDetails(int reasonCodeId, int metricId)
        {
            Corrsmetricreasoncodedependency cmrcDependency = new Corrsmetricreasoncodedependency();
            cmrcDependency.MetricId = metricId;
            cmrcDependency.ReasonId = reasonCodeId;
            cmrcDependency.Flag = 1;
            db.Corrsmetricreasoncodedependency.Add(cmrcDependency);
            db.SaveChanges();
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
