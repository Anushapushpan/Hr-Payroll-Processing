using Databaselayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Master.CodesMaster
{
    public class CodeMasterManager
    {
        public int InsertCodesMasterToDb(string cmCode,string cmType, string cmDesc, int cmValue, string cmCrBy, DateTime cmCrDt,string cmActiveYn)
        {

            try
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                string sql = "INSERT INTO CODES_MASTER (CM_CODE, CM_TYPE, CM_DESC, CM_VALUE, CM_CR_BY, CM_CR_DT, CM_ACTIVE_YN)  VALUES (:cmCode,:cmType,:cmDesc,:cmValue,:cmCrBy,:cmCrDt,:cmActiveYn)";
                dict.Add("cmCode", cmCode);
                dict.Add("cmType", cmType);
                dict.Add("cmDesc", cmDesc);
                dict.Add("cmValue", cmValue);
                dict.Add("cmCrBy", cmCrBy);
                dict.Add("cmCrDt", cmCrDt);
                dict.Add("cmActiveYn", cmActiveYn);
                int rows = DBConnection.ExecuteQuery(dict, sql);
                return rows;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool isValidateUnique(string cmCode, string cmType)
        {
            try
            {
                int count;
                string query = $"SELECT * FROM CODES_MASTER WHERE CM_CODE='{cmCode}' AND CM_TYPE='{cmType}'";
                DataTable dt = DBConnection.ExecuteDataset(query);
                count = dt.Rows.Count;
                if (count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int UpdateCodeMaster(string cmCode, string cmType, string cmDesc, int cmValue, string cmUpBy, string cmUpDt, string cmActiveYn)
        {
            try
            {
                string sql = $"UPDATE CODES_MASTER SET CM_DESC='{cmDesc}',CM_VALUE={cmValue},CM_UP_BY='{cmUpBy}',CM_UP_DT='{cmUpDt}',CM_ACTIVE_YN='{cmActiveYn}' WHERE CM_CODE = '{cmCode}' AND CM_TYPE='{cmType}'";
                int gd = DBConnection.ExecuteQuery(sql);
                return gd;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int UpdateCodesMaster(CodeMasterEntity objCodesMasterEntity)
        {
            try
            {
                string sql = $"UPDATE CODES_MASTER SET CM_DESC='{objCodesMasterEntity.cmDesc}',CM_VALUE={objCodesMasterEntity.cmValue},CM_UP_BY='{objCodesMasterEntity.cmUpBy}',CM_UP_DT='{System.DateTime.Now.ToString("dd/MMMM/yyyy")}',CM_ACTIVE_YN='{objCodesMasterEntity.cmActiveYn}' WHERE CM_CODE = '{objCodesMasterEntity.cmCode}' AND CM_TYPE='{objCodesMasterEntity.cmType}'";
                int gd = DBConnection.ExecuteQuery(sql);
                return gd;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable FetchEmpStatus()
        {
            try
            {
                string query = $"select CM_CODE, CM_CODE||'-'||CM_DESC CM_DESC from codes_master where cm_type='EMP_STATUS' AND CM_ACTIVE_YN='Y'";
                DataTable dt = DBConnection.ExecuteDataset(query);
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable FetchDesignationFromCodesMaster()
        {
            try
            {
                string query = $"select CM_CODE, CM_CODE||'-'||CM_DESC CM_DESC from codes_master where cm_type='DESIGNATION' AND CM_ACTIVE_YN='Y'";
                DataTable dt = DBConnection.ExecuteDataset(query);
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable FetchDesignation()
        {
            try
            {
                string query = $"select CM_CODE, CM_DESC from codes_master where cm_type='DESIGNATION' AND CM_ACTIVE_YN='Y'";
                DataTable dt = DBConnection.ExecuteDataset(query);
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable FetchYear()
        {
            try
            {
                string query = $"select CM_CODE, CM_VALUE from codes_master where cm_type='YEAR' AND CM_ACTIVE_YN='Y'";
                DataTable dt = DBConnection.ExecuteDataset(query);
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable FetchGradesFromCodesMaster()
        {
            try
            {
                string query = $"select CM_CODE, CM_DESC from codes_master where cm_type='GRADE' AND CM_ACTIVE_YN='Y'";
                DataTable dt = DBConnection.ExecuteDataset(query);
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable FetchCodesMaster()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DBConnection.ExecuteDataset("SELECT * FROM CODES_MASTER");
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable FetchCodesMaster(string cmCode, string cmType)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DBConnection.ExecuteDataset($"SELECT * FROM CODES_MASTER WHERE CM_CODE='{cmCode}' AND CM_TYPE='{cmType}'");
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int DeleteCodesMaster(string cmType)
        {
            try
            {
                DataTable gd = new DataTable();
                string sql1 = $"DELETE FROM CODES_MASTER WHERE CM_CODE='{cmType}'";          
                int rows = DBConnection.ExecuteQuery(sql1);
                return rows;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int UpdateCodesMaster(string cmCode, string cmType, string cmDesc, int cmValue, string active, string cmUpBy)
        {
            try
            {
                string sql = $"UPDATE CODES_MASTER SET CM_DESC='{cmDesc}',CM_VALUE={cmValue},CM_UP_BY='{cmUpBy}',CM_UP_DT='{System.DateTime.Now.ToString("dd/MMMM/yyyy")}',CM_ACTIVE_YN='{active}' WHERE CM_CODE = '{cmCode}' AND CM_TYPE='{cmType}'";
                int gd = DBConnection.ExecuteQuery(sql);
                return gd;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
