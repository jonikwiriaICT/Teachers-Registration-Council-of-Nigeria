using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Foundation;
using System.Data;
using System.Data.SqlClient;


    public partial class SysAdminModel : _Database
    {
        //To Get Lga
        public DataSet GetLicensedReportLgaByState(string sState)
        {
            try
            {
                if (sState == "ALL")
                {
                    SqlCommand objCmd = new SqlCommand();
                    string sSQL = "select * from qry_Licensed_lga_by_State";
                    objCmd.CommandText = sSQL;
                    return ExecuteDataSet(objCmd);
                }
                else
                {
                    SqlCommand objCmd = new SqlCommand();
                    string sSQL = "select  ROW_NUMBER() over(order by [Total] ) as [S/N],  StateID, LgaID, [Category A], [Category B], [Category C], [Category D], [Category E], Total from (select   StateID, LgaID, CategoryA as [Category A], CategoryB as [Category B], CategoryC as [Category C], CategoryD as [Category D], CategoryE as [Category E], sum([CategoryA] + [CategoryB] + [CategoryC] + [CategoryD] + [CategoryE]) as [Total] from (select StateID, LgaID, count([categoryA]) as [CategoryA], count([CategoryB]) as [CategoryB], count([CategoryC]) as [CategoryC], count([CategoryD]) as [CategoryD], count([CategoryE]) as [CategoryE] from (select state_id as [StateID], lga_id as [LgaID], case when category='A' then 'A' end as [CategoryA], case when category='B' then 'B' end as [CategoryB], case when category='C' then 'C' end as [CategoryC], case when category='D' then 'D' end as [CategoryD], case when category='E' then 'E' end as [CategoryE] from " + sState + ") as tbla group by StateID, LgaID) as tblabu group by StateID, LgaID, CategoryA, CategoryB, CategoryC, CategoryD, CategoryE union select  'zTotal' as StateID, '' AS LgaID, [Category A], [Category B], [Category C], [Category D], [Category E], Total from(select count(StateID) as StateID, count(LgaID) AS[LgaID], sum([Category A]) as [Category A], sum([Category B]) as [Category B], sum([Category A]) as [Category C], sum([Category D]) as [Category D], sum([Category E]) as [Category E], SUM([Total]) as [Total] from(select  StateID, LgaID, CategoryA as [Category A], CategoryB as [Category B], CategoryC as [Category C], CategoryD as [Category D], CategoryE as [Category E], sum([CategoryA] + [CategoryB] + [CategoryC] + [CategoryD] + [CategoryE]) as [Total] from(select StateID, LgaID, count([categoryA]) as [CategoryA], count([CategoryB]) as [CategoryB], count([CategoryC]) as [CategoryC], count([CategoryD]) as [CategoryD], count([CategoryE]) as [CategoryE] from(select state_id as [StateID], lga_id as [LgaID], case when category = 'A' then 'A' end as [CategoryA], case when category = 'B' then 'B' end as [CategoryB], case when category = 'C' then 'C' end as [CategoryC], case when category = 'D' then 'D' end as [CategoryD], case when category = 'E' then 'E' end as [CategoryE] from LICENSEDABIA) as tbla group by StateID, LgaID) as tblabu group by StateID, LgaID, CategoryA, CategoryB, CategoryC, CategoryD, CategoryE) as tblT) as tblabs) as tblAllStates";
                    objCmd.CommandText = sSQL;
                    return ExecuteDataSet(objCmd);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

        //To Get State
        public DataSet GetLicensedReportByState(string sState)
        {
            try
            {
                if (sState == "ALL")
                {
                    SqlCommand objCmd = new SqlCommand();
                    string sSQL = "select * from qry_Licensed_state";
                    objCmd.CommandText = sSQL;
                    return ExecuteDataSet(objCmd);
                }
                else
                {
                    SqlCommand objCmd = new SqlCommand();
                    string sSQL = "select ROW_NUMBER() over (order by Total) as [S/N], StateID, [Category A], [Category B], [Category C], [Category D], [Category E], Total from (select StateID, CategoryA as [Category A], CategoryB as [Category B], CategoryC as [Category C], CategoryD as [Category D], CategoryE as [Category E], Total as [Total] from (SELECT StateID, CategoryA, CategoryB, CategoryC, CategoryD, CategoryE, sum([CategoryA] + [CategoryB] + [CategoryC] + [CategoryD] + [CategoryE]) as [Total] from  (select StateID, COUNT([CategoryA]) as [CategoryA], count([CategoryB]) as [CategoryB], count([CategoryC]) as [CategoryC], COUNT([CategoryD]) as [CategoryD],COUNT([CategoryE]) as [CategoryE] from (select state_id as [StateID], case when category='A' then 'A' end as [CategoryA], case when category='B' then 'B' end as [CategoryB], case when category='C' then 'C' end as [CategoryC], case when category='D' then 'D' end as [CategoryD], case when category='E' then 'E' end as [CategoryE] from " + sState + " ) as tblCount group by StateID) as tblallState group by StateID, CategoryA, CategoryB, CategoryC, CategoryD, CategoryE) as allGrantToal union SELECT 'zTotal' as StateID, [Category A], [Category B], [Category C], [Category D], [Category E], [Total] FROM(select count(StateID) AS StateID, sum([Category A]) as [Category A], sum([Category B]) as [Category B], sum([Category C]) as [Category C], sum([Category D]) as [Category D], sum([Category E]) as [Category E], sum([Total]) as [Total] from(select StateID, CategoryA as [Category A], CategoryB as [Category B], CategoryC as [Category C], CategoryD as [Category D], CategoryE as [Category E], Total as [Total] from (SELECT StateID, CategoryA, CategoryB, CategoryC, CategoryD, CategoryE, sum([CategoryA] + [CategoryB] + [CategoryC] + [CategoryD] + [CategoryE]) as [Total] from(select StateID, COUNT([CategoryA]) as [CategoryA], count([CategoryB]) as [CategoryB], count([CategoryC]) as [CategoryC], COUNT([CategoryD]) as [CategoryD],COUNT([CategoryE]) as [CategoryE] from(select state_id as [StateID], case when category = 'A' then 'A' end as [CategoryA], case when category = 'B' then 'B' end as [CategoryB], case when category = 'C' then 'C' end as [CategoryC], case when category = 'D' then 'D' end as [CategoryD], case when category = 'E' then 'E' end as [CategoryE] from LICENSEDABIA) as tblCount group by StateID) as tblallState group by StateID, CategoryA, CategoryB, CategoryC, CategoryD, CategoryE) as allGrantToal) as granttotal) AS ALLgRANTtOTALsTATE) as tblallTotalCountState";
                    objCmd.CommandText = sSQL;
                    return ExecuteDataSet(objCmd);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

    }

