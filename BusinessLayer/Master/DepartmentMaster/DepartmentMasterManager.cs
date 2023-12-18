﻿using Databaselayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Master.DepartmentMaster
{
    public class DepartmentMasterManager
    {
        public int InsertDeptMasterToDb(string deptNo, string deptName, string deptCrBy, DateTime deptCrDt)
        {
            try
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                string query = "INSERT INTO DEPARTMENT_MASTER(DEPT_NO, DEPT_NAME, DEPT_CR_BY, DEPT_CR_DT) VALUES (:deptNo,:deptName,:deptCrBy,:deptCrDt)";
                dict.Add("deptNo", deptNo);
                dict.Add("deptName", deptName);
                dict.Add("deptCrBy", deptCrBy);
                dict.Add("deptCrDt", deptCrDt);
                int rows = DBConnection.ExecuteQuery(dict, query);
                return rows;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool isValidateUnique(string deptNo)
        {
            try
            {
                int count;
                string query = $"SELECT * FROM DEPARTMENT_MASTER WHERE DEPT_NO='{deptNo}'";
                DataTable dt = DBConnection.ExecuteDataset(query);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int UpdateCodeMaster(string deptNo,string deptName, string deptUpBy, string deptUpDt)
        {
            try
            {
                string query = $"UPDATE DEPARTMENT_MASTER SET DEPT_NAME='{deptName}',DEPT_UP_BY='{deptUpBy}',DEPT_UP_DT='{deptUpDt}' WHERE DEPT_NO = '{deptNo}'";
                int gd = DBConnection.ExecuteQuery(query);
                return gd;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable FetchDeptNo()
        {
            try
            {
                string query = $"SELECT DEPT_NO, DEPT_NO||'-'|| DEPT_NAME DEPT_NAME FROM DEPARTMENT_MASTER ORDER BY DEPT_NO";
                DataTable dt = DBConnection.ExecuteDataset(query);
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable FetDepartmentDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DBConnection.ExecuteDataset("SELECT * FROM DEPARTMENT_MASTER");
                return dt;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public int DeleteDept(string deptNo)
        {
            try
            {
                DataTable gd = new DataTable();
                string sql1 = $"DELETE FROM DEPARTMENT_MASTER WHERE DEPT_NO='{deptNo}'";
                string sql2 = $"DELETE FROM PR_EMPLOYEE WHERE EMP_DEPTNO='{deptNo}'";
                string sql3 = $"SELECT EMP_NO FROM PR_EMPLOYEE WHERE EMP_DEPTNO='{deptNo}'";
                gd = DBConnection.ExecuteDataset(sql3);
                string empno = "";
                if (gd.Rows.Count > 0)
                {
                    foreach (DataRow ds in gd.Rows)
                    {
                        empno= ds["EMP_NO"].ToString();
                    }
                }
                string sql4 = $"DELETE FROM PR_EMPOLYEE_HR WHERE EH_EMP_NO='{empno}'";
                int row1 = DBConnection.ExecuteQuery(sql1);
                int row2 = DBConnection.ExecuteQuery(sql2);
                int row3 = DBConnection.ExecuteQuery(sql4);
                int rows = row1 + row2;
                return rows;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DataTable FetchDepartmentMaster(string deptNo)
        {
            try
            {
                string query = $"SELECT * FROM DEPARTMENT_MASTER WHERE DEPT_NO='{deptNo}'";
                DataTable dt = DBConnection.ExecuteDataset(query);
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int UpdateDept(string deptNo, string deptName, string deptUpBy)
        {
            try
            {
                string query = $"UPDATE DEPARTMENT_MASTER SET DEPT_NAME='{deptName}',DEPT_UP_BY='{deptUpBy}',DEPT_UP_DT='{System.DateTime.Now.ToString("dd/MMMM/yyyy")}' WHERE DEPT_NO = '{deptNo}'";
                int gd = DBConnection.ExecuteQuery(query);
                return gd;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int UpdateDepartment(DepartmentMasterEntity objdeptEntity)
        {
            try
            {
                string query = $"UPDATE DEPARTMENT_MASTER SET DEPT_NAME='{objdeptEntity.deptName}',DEPT_UP_BY='{objdeptEntity.deptName}',DEPT_UP_DT='{System.DateTime.Now.ToString("dd/MMMM/yyyy")}' WHERE DEPT_NO = '{objdeptEntity.deptNo}'";
                int gd = DBConnection.ExecuteQuery(query);
                return gd;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
