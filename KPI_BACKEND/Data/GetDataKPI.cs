using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KPI_BACKEND.DbConnect;
using System.IO;
using System.Data;
using Antlr.Runtime;

namespace KPI_BACKEND.Data
{
    public class GetDataKPI
    {
        private string connectString = "Data Source=(local);Initial Catalog=KPI_DataB;Integrated Security=True";
        /*public List<rpt_kpiResult> Get_DataAll() 
        {
            using (DbConnectDataContext dbContext = new DbConnectDataContext(connectString))

            return dbContext.rpt_kpi().ToList();
        }*/
        public List<spKPIGetData_from_AStaffResult> Get_DataWithParamID(string _year,string _month,string _OrgCode)
        {
            using (DbConnectDataContext dbContext = new DbConnectDataContext(connectString))

            return dbContext.spKPIGetData_from_AStaff(_year,_month,_OrgCode).ToList();
        }



    }
}