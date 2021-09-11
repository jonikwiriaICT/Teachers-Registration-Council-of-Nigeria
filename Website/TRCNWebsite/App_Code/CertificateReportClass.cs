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
        public string sCode = "";
        public string sDesc = "";
        //To Get Teacher Report
        public DataSet GetTeacherQueryReport(string sState, string sLga)
        {
            try
            {

                if (sLga == "ALL")
                {
                    SqlCommand objCmd = new SqlCommand();
                    string sSQL = "select ROW_NUMBER() over (order by [RecID]) as [S/N], RegistrationNo as [Registration Number], PQENo as [PQE Number], firstname as [Firstname], middlename as [Middlename], Surname as [Surname], MaritalStatus as [Marital Status], Gender as [Gender], DateOfBirth as [Date Of Birth], StateID as [StateID], LgaID as [LgaID], TelephoneNo as [Telephone Number], Address as [Address], Nationality as [Nationality], Category as [Category], CurrentEmployer as [Current Employer], Education_level as [Education Level], InstitutionAttended as [Intitution Attended], NinNo as [Nin Number], AreaOfDiscipline as [Area Of Discipline], RegistrationStatus as [Registration Status], CeritificateStatus as [Certificate Status], RRRNo as [RRR Number], Email as [Email], SchoolType as [School Type]  from (select rec_id as [RecID], registration_no as [RegistrationNo], pqe_number as [PQENo], surname as [Surname], firstname as [Firstname], middlename as [Middlename], marital_status as [MaritalStatus], sex as [Gender], dob as [DateOfBirth], state_id as [StateID], lga_origin as [LgaID], phone_no as [TelephoneNo], address as [Address], nationality as [Nationality], category as [Category], current_employer as [CurrentEmployer], education_level as [Education_level], institution_attended as [InstitutionAttended], nin_no as [NinNo], area_of_discipline as [AreaOfDiscipline], case when registration_status='1' then 'VERIFIED' else 'NOT VERIFIED' end as [RegistrationStatus], case when printing_status='1' then 'PRINTED' else 'NOT PRINTED' END AS [CeritificateStatus], bank_teller as [RRRNo], email as [Email], school_type as [SchoolType]  from " + sState + ") as tblabuja ";
                    objCmd.CommandText = sSQL;
                    return ExecuteDataSet(objCmd);
                }
                else
                {
                    SqlCommand objCmd = new SqlCommand();
                    string sSQL = "select ROW_NUMBER() over (order by [RecID]) as [S/N], RegistrationNo as [Registration Number], PQENo as [PQE Number], firstname as [Firstname], middlename as [Middlename], Surname as [Surname], MaritalStatus as [Marital Status], Gender as [Gender], DateOfBirth as [Date Of Birth], StateID as [StateID], LgaID as [LgaID], TelephoneNo as [Telephone Number], Address as [Address], Nationality as [Nationality], Category as [Category], CurrentEmployer as [Current Employer], Education_level as [Education Level], InstitutionAttended as [Intitution Attended], NinNo as [Nin Number], AreaOfDiscipline as [Area Of Discipline], RegistrationStatus as [Registration Status], CeritificateStatus as [Certificate Status], RRRNo as [RRR Number], Email as [Email], SchoolType as [School Type]  from (select rec_id as [RecID], registration_no as [RegistrationNo], pqe_number as [PQENo], surname as [Surname], firstname as [Firstname], middlename as [Middlename], marital_status as [MaritalStatus], sex as [Gender], dob as [DateOfBirth], state_id as [StateID], lga_origin as [LgaID], phone_no as [TelephoneNo], address as [Address], nationality as [Nationality], category as [Category], current_employer as [CurrentEmployer], education_level as [Education_level], institution_attended as [InstitutionAttended], nin_no as [NinNo], area_of_discipline as [AreaOfDiscipline], case when registration_status='1' then 'VERIFIED' else 'NOT VERIFIED' end as [RegistrationStatus], case when printing_status='1' then 'PRINTED' else 'NOT PRINTED' END AS [CeritificateStatus], bank_teller as [RRRNo], email as [Email], school_type as [SchoolType]  from " + sState + ") as tblabuja where LgaID='" + sLga + "'";
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
        //To Get Lga
        public DataSet GetCertificateReportLgaByState(string sState, string sLga)
        {
            try
            {
                if (sState == "ALL" && sLga == "ALL")
                {
                    SqlCommand objCmd = new SqlCommand();
                    string sSQL = "select * from qry_lga_by_state";
                    objCmd.CommandText = sSQL;
                    return ExecuteDataSet(objCmd);
                }
                else if (sState != "ALL" && sLga == "ALL")
                {
                    SqlCommand objCmd = new SqlCommand();
                    string sSQL = "select  ROW_NUMBER() over(order by [Total] ) as [S/N],  StateID, LgaID, [Category A], [Category B], [Category C], [Category D], [Category E], Total from (select   StateID, LgaID, CategoryA as [Category A], CategoryB as [Category B], CategoryC as [Category C], CategoryD as [Category D], CategoryE as [Category E], sum([CategoryA] + [CategoryB] + [CategoryC] + [CategoryD] + [CategoryE]) as [Total] from (select StateID, LgaID, count([categoryA]) as [CategoryA], count([CategoryB]) as [CategoryB], count([CategoryC]) as [CategoryC], count([CategoryD]) as [CategoryD], count([CategoryE]) as [CategoryE] from (select state_id as [StateID], lga_origin as [LgaID], case when category='A' then 'A' end as [CategoryA], case when category='B' then 'B' end as [CategoryB], case when category='C' then 'C' end as [CategoryC], case when category='D' then 'D' end as [CategoryD], case when category='E' then 'E' end as [CategoryE] from " + sState + ") as tbla group by StateID, LgaID) as tblabu group by StateID, LgaID, CategoryA, CategoryB, CategoryC, CategoryD, CategoryE union select  'zTotal' as StateID, '' AS LgaID, [Category A], [Category B], [Category C], [Category D], [Category E], Total from(select count(StateID) as StateID, count(LgaID) AS[LgaID], sum([Category A]) as [Category A], sum([Category B]) as [Category B], sum([Category C]) as [Category C], sum([Category D]) as [Category D], sum([Category E]) as [Category E], SUM([Total]) as [Total] from(select  StateID, LgaID, CategoryA as [Category A], CategoryB as [Category B], CategoryC as [Category C], CategoryD as [Category D], CategoryE as [Category E], sum([CategoryA] + [CategoryB] + [CategoryC] + [CategoryD] + [CategoryE]) as [Total] from(select StateID, LgaID, count([categoryA]) as [CategoryA], count([CategoryB]) as [CategoryB], count([CategoryC]) as [CategoryC], count([CategoryD]) as [CategoryD], count([CategoryE]) as [CategoryE] from(select state_id as [StateID], lga_origin as [LgaID], case when category = 'A' then 'A' end as [CategoryA], case when category = 'B' then 'B' end as [CategoryB], case when category = 'C' then 'C' end as [CategoryC], case when category = 'D' then 'D' end as [CategoryD], case when category = 'E' then 'E' end as [CategoryE] from " + sState + ") as tbla group by StateID, LgaID) as tblabu group by StateID, LgaID, CategoryA, CategoryB, CategoryC, CategoryD, CategoryE) as tblT) as tblabs) as tblAllStates";
                    objCmd.CommandText = sSQL;
                    return ExecuteDataSet(objCmd);
                }
                else
                {
                    SqlCommand objCmd = new SqlCommand();
                    string sSQL = "select  ROW_NUMBER() over(order by [Total] ) as [S/N],  StateID, LgaID, [Category A], [Category B], [Category C], [Category D], [Category E], Total from (select   StateID, LgaID, CategoryA as [Category A], CategoryB as [Category B], CategoryC as [Category C], CategoryD as [Category D], CategoryE as [Category E], sum([CategoryA] + [CategoryB] + [CategoryC] + [CategoryD] + [CategoryE]) as [Total] from (select StateID, LgaID, count([categoryA]) as [CategoryA], count([CategoryB]) as [CategoryB], count([CategoryC]) as [CategoryC], count([CategoryD]) as [CategoryD], count([CategoryE]) as [CategoryE] from (select state_id as [StateID], lga_origin as [LgaID], case when category='A' then 'A' end as [CategoryA], case when category='B' then 'B' end as [CategoryB], case when category='C' then 'C' end as [CategoryC], case when category='D' then 'D' end as [CategoryD], case when category='E' then 'E' end as [CategoryE] from " + sState + ") as tbla group by StateID, LgaID) as tblabu group by StateID, LgaID, CategoryA, CategoryB, CategoryC, CategoryD, CategoryE union select  'zTotal' as StateID, '' AS LgaID, [Category A], [Category B], [Category C], [Category D], [Category E], Total from(select count(StateID) as StateID, count(LgaID) AS[LgaID], sum([Category A]) as [Category A], sum([Category B]) as [Category B], sum([Category C]) as [Category C], sum([Category D]) as [Category D], sum([Category E]) as [Category E], SUM([Total]) as [Total] from(select  StateID, LgaID, CategoryA as [Category A], CategoryB as [Category B], CategoryC as [Category C], CategoryD as [Category D], CategoryE as [Category E], sum([CategoryA] + [CategoryB] + [CategoryC] + [CategoryD] + [CategoryE]) as [Total] from(select StateID, LgaID, count([categoryA]) as [CategoryA], count([CategoryB]) as [CategoryB], count([CategoryC]) as [CategoryC], count([CategoryD]) as [CategoryD], count([CategoryE]) as [CategoryE] from(select state_id as [StateID], lga_origin as [LgaID], case when category = 'A' then 'A' end as [CategoryA], case when category = 'B' then 'B' end as [CategoryB], case when category = 'C' then 'C' end as [CategoryC], case when category = 'D' then 'D' end as [CategoryD], case when category = 'E' then 'E' end as [CategoryE] from " + sState + ") as tbla group by StateID, LgaID) as tblabu group by StateID, LgaID, CategoryA, CategoryB, CategoryC, CategoryD, CategoryE) as tblT) as tblabs) as tblAllStates  WHERE LgaID='" + sLga + "'";
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
        public DataSet GetLicensedReportLgaByState(string sState, string sLga)
        {
            try
            {
                if (sState == "ALL" && sLga == "ALL")
                {
                    SqlCommand objCmd = new SqlCommand();
                    string sSQL = "select * from qry_Licensed_lga_by_State";
                    objCmd.CommandText = sSQL;
                    return ExecuteDataSet(objCmd);
                }
                else if (sState != "ALL" && sLga == "ALL")
                {
                    SqlCommand objCmd = new SqlCommand();
                    string sSQL = "select  ROW_NUMBER() over(order by [Total] ) as [S/N],  StateID, LgaID, [Category A], [Category B], [Category C], [Category D], [Category E], Total from (select   StateID, LgaID, CategoryA as [Category A], CategoryB as [Category B], CategoryC as [Category C], CategoryD as [Category D], CategoryE as [Category E], sum([CategoryA] + [CategoryB] + [CategoryC] + [CategoryD] + [CategoryE]) as [Total] from (select StateID, LgaID, count([categoryA]) as [CategoryA], count([CategoryB]) as [CategoryB], count([CategoryC]) as [CategoryC], count([CategoryD]) as [CategoryD], count([CategoryE]) as [CategoryE] from (select state_id as [StateID], lga_origin as [LgaID], case when category='A' then 'A' end as [CategoryA], case when category='B' then 'B' end as [CategoryB], case when category='C' then 'C' end as [CategoryC], case when category='D' then 'D' end as [CategoryD], case when category='E' then 'E' end as [CategoryE] from " + sState + ") as tbla group by StateID, LgaID) as tblabu group by StateID, LgaID, CategoryA, CategoryB, CategoryC, CategoryD, CategoryE union select  'zTotal' as StateID, '' AS LgaID, [Category A], [Category B], [Category C], [Category D], [Category E], Total from(select count(StateID) as StateID, count(LgaID) AS[LgaID], sum([Category A]) as [Category A], sum([Category B]) as [Category B], sum([Category C]) as [Category C], sum([Category D]) as [Category D], sum([Category E]) as [Category E], SUM([Total]) as [Total] from(select  StateID, LgaID, CategoryA as [Category A], CategoryB as [Category B], CategoryC as [Category C], CategoryD as [Category D], CategoryE as [Category E], sum([CategoryA] + [CategoryB] + [CategoryC] + [CategoryD] + [CategoryE]) as [Total] from(select StateID, LgaID, count([categoryA]) as [CategoryA], count([CategoryB]) as [CategoryB], count([CategoryC]) as [CategoryC], count([CategoryD]) as [CategoryD], count([CategoryE]) as [CategoryE] from(select state_id as [StateID], lga_origin as [LgaID], case when category = 'A' then 'A' end as [CategoryA], case when category = 'B' then 'B' end as [CategoryB], case when category = 'C' then 'C' end as [CategoryC], case when category = 'D' then 'D' end as [CategoryD], case when category = 'E' then 'E' end as [CategoryE] from " + sState + ") as tbla group by StateID, LgaID) as tblabu group by StateID, LgaID, CategoryA, CategoryB, CategoryC, CategoryD, CategoryE) as tblT) as tblabs) as tblAllStates";
                    objCmd.CommandText = sSQL;
                    return ExecuteDataSet(objCmd);
                }
                else
                {
                    SqlCommand objCmd = new SqlCommand();
                    string sSQL = "select  ROW_NUMBER() over(order by [Total] ) as [S/N],  StateID, LgaID, [Category A], [Category B], [Category C], [Category D], [Category E], Total from (select   StateID, LgaID, CategoryA as [Category A], CategoryB as [Category B], CategoryC as [Category C], CategoryD as [Category D], CategoryE as [Category E], sum([CategoryA] + [CategoryB] + [CategoryC] + [CategoryD] + [CategoryE]) as [Total] from (select StateID, LgaID, count([categoryA]) as [CategoryA], count([CategoryB]) as [CategoryB], count([CategoryC]) as [CategoryC], count([CategoryD]) as [CategoryD], count([CategoryE]) as [CategoryE] from (select state_id as [StateID], lga_origin as [LgaID], case when category='A' then 'A' end as [CategoryA], case when category='B' then 'B' end as [CategoryB], case when category='C' then 'C' end as [CategoryC], case when category='D' then 'D' end as [CategoryD], case when category='E' then 'E' end as [CategoryE] from " + sState + ") as tbla group by StateID, LgaID) as tblabu group by StateID, LgaID, CategoryA, CategoryB, CategoryC, CategoryD, CategoryE union select  'zTotal' as StateID, '' AS LgaID, [Category A], [Category B], [Category C], [Category D], [Category E], Total from(select count(StateID) as StateID, count(LgaID) AS[LgaID], sum([Category A]) as [Category A], sum([Category B]) as [Category B], sum([Category C]) as [Category C], sum([Category D]) as [Category D], sum([Category E]) as [Category E], SUM([Total]) as [Total] from(select  StateID, LgaID, CategoryA as [Category A], CategoryB as [Category B], CategoryC as [Category C], CategoryD as [Category D], CategoryE as [Category E], sum([CategoryA] + [CategoryB] + [CategoryC] + [CategoryD] + [CategoryE]) as [Total] from(select StateID, LgaID, count([categoryA]) as [CategoryA], count([CategoryB]) as [CategoryB], count([CategoryC]) as [CategoryC], count([CategoryD]) as [CategoryD], count([CategoryE]) as [CategoryE] from(select state_id as [StateID], lga_origin as [LgaID], case when category = 'A' then 'A' end as [CategoryA], case when category = 'B' then 'B' end as [CategoryB], case when category = 'C' then 'C' end as [CategoryC], case when category = 'D' then 'D' end as [CategoryD], case when category = 'E' then 'E' end as [CategoryE] from " + sState + ") as tbla group by StateID, LgaID) as tblabu group by StateID, LgaID, CategoryA, CategoryB, CategoryC, CategoryD, CategoryE) as tblT) as tblabs) as tblAllStates  WHERE LgaID='" + sLga + "'";
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
        public DataSet GetCertificateReportByState(string sState)
        {
            try
            {

                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select * from qry_Licensed_state where [StateID]='" + sState + "";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);

            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

        public DataSet GetCertificateAllByState()
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select * from tbl_state_query";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet GetLicensedAllByState()
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select * from qry_Licensed_state";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        //GetAll Teacher Query
        public DataSet GetAllTeacherByEachColumn(string sState, string sLga, string sSearch)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select ROW_NUMBER() over (order by [RecID]) as [S/N], RegistrationNo as [Registration Number], PQENo as [PQE Number], firstname as [Firstname], middlename as [Middlename], Surname as [Surname], MaritalStatus as [Marital Status], Gender as [Gender], DateOfBirth as [Date Of Birth], StateID as [StateID], LgaID as [LgaID], TelephoneNo as [Telephone Number], Address as [Address], Nationality as [Nationality], Category as [Category], CurrentEmployer as [Current Employer], Education_level as [Education Level], InstitutionAttended as [Intitution Attended], NinNo as [Nin Number], AreaOfDiscipline as [Area Of Discipline], RegistrationStatus as [Registration Status], CeritificateStatus as [Certificate Status], RRRNo as [RRR Number], Email as [Email], SchoolType as [School Type]  from (select rec_id as [RecID], registration_no as [RegistrationNo], pqe_number as [PQENo], surname as [Surname], firstname as [Firstname], middlename as [Middlename], marital_status as [MaritalStatus], sex as [Gender], dob as [DateOfBirth], state_id as [StateID], lga_origin as [LgaID], phone_no as [TelephoneNo], address as [Address], nationality as [Nationality], category as [Category], current_employer as [CurrentEmployer], education_level as [Education_level], institution_attended as [InstitutionAttended], nin_no as [NinNo], area_of_discipline as [AreaOfDiscipline], case when registration_status='1' then 'VERIFIED' else 'NOT VERIFIED' end as [RegistrationStatus], case when printing_status='1' then 'PRINTED' else 'NOT PRINTED' END AS [CeritificateStatus], bank_teller as [RRRNo], email as [Email], school_type as [SchoolType]  from  " + sState + ") as tblabuja WHERE LgaID='" + sLga + "'  AND  (RegistrationNo='" + sSearch + "' or PQENo='" + sSearch + "' or Firstname='" + sSearch + "' or Middlename='" + sSearch + "' or Surname='" + sSearch + "' or MaritalStatus='" + sSearch + "' or Gender='" + sSearch + "' or DateOfBirth='" + sSearch + "'  or TelephoneNo='" + sSearch + "' or Address='" + sSearch + "' or Nationality='" + sSearch + "' or Category='" + sSearch + "' or CurrentEmployer='" + sSearch + "' or Education_level='" + sSearch + "' or InstitutionAttended='" + sSearch + "' or NinNo='" + sSearch + "' or AreaOfDiscipline='" + sSearch + "' or RegistrationStatus='" + sSearch + "' or CeritificateStatus='" + sSearch + "' or RRRNo='" + sSearch + "' or Email='" + sSearch + "' or SchoolType='" + sSearch + "')";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public DataSet LoadLgaByState(string sState)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = " SELECT 'ALL' AS [Code], 'ALL' as [Desc] union select distinct  lga_origin AS [Code], lga_origin AS [Desc] FROM  " + sState + "  ";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }

        public DataSet LoadAreaOfDiscipline(string sState, string sLga)
        {
            try
            {
                SqlCommand objCmd = new SqlCommand();
                string sSQL = "select distinct  area_of_discipline as [Code], area_of_discipline as [Desc] from " + sState + " where lga_origin='" + sLga + "'";
                objCmd.CommandText = sSQL;
                return ExecuteDataSet(objCmd);
            }
            catch (Exception ex)
            {
                ErrorMessage += ex.Message;
                return null;
            }
        }
        public bool GetDropDownState(string sState)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = "select DISTINCT lga_id as [Desc],  lga_id as [Code] from " + sState + "";
                SqlCommand objCmd = new SqlCommand();
                objCmd.Parameters.Clear();
                objCmd.CommandText = sSQL;
                ds = ExecuteDataSet(objCmd);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    ErrorMessage = "User ID was not Found";
                    return false;
                }
                sCode = ds.Tables[0].Rows[0]["Code"].ToString();
                sDesc = ds.Tables[0].Rows[0]["Desc"].ToString();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                return false;
            }
        }

        //Get report By all Types

    }

