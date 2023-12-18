using Databaselayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Master.ErrorCodeMaster
{
    
    public class ErrorCodeMasterManager
    {
        ErrorCodeMasterEntity objErrEntity = new ErrorCodeMasterEntity();
        public bool IsInsertErrorMaster(ErrorCodeMasterEntity objErrEntity)
        {
            try
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                string query = "INSERT INTO ERROR_CODE_MASTER(ERR_CODE, ERR_TYPE, ERR_DESC, ERR_CR_BY,ERR_CR_DT) VALUES (:errCode,:errType,:errDesc,:errCrBy,:errCrDt)";
                dict.Add("errCode", objErrEntity.errCode);
                dict.Add("errType", objErrEntity.errType);
                dict.Add("errDesc", objErrEntity.errDesc);
                dict.Add("errCrBy", objErrEntity.errCrBy);
                dict.Add("errCrDt", objErrEntity.errCrDt);
                int rows = DBConnection.ExecuteQuery(dict, query);
                if(rows>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool IsUnique(string errCode)
        {
            try
            {
                int count;
                string query = $"SELECT * FROM ERROR_CODE_MASTER WHERE ERR_CODE='{errCode}'";
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

        public DataTable FetchErrorGrid()
        {
            try
            {
                string query = $"SELECT * FROM ERROR_CODE_MASTER";
                DataTable dt = DBConnection.ExecuteDataset(query);
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable FetchErrorMaster(string errCode)
        {
            try
            {
                string query = $"SELECT * FROM ERROR_CODE_MASTER WHERE ERR_CODE='{errCode}'";
                DataTable dt = DBConnection.ExecuteDataset(query);
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool IsRowDeleted(string errCode)
        {
            try
            {
                string query = $"DELETE FROM ERROR_CODE_MASTER WHERE ERR_CODE='{errCode}'";
                int rows = DBConnection.ExecuteQuery(query);               
                if (rows > 0)
                {
                    return true;
                }
                return false ;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int UpdateErrorMaster(ErrorCodeMasterEntity objErrorEntity)
        {
            try
            {
                string query = $"UPDATE ERROR_CODE_MASTER SET  ERR_TYPE='{objErrorEntity.errType}',ERR_DESC='{objErrorEntity.errDesc}',ERR_CR_BY='{objErrorEntity.errUpBy}',ERR_UP_DT='{System.DateTime.Now.ToString("dd/MMMM/yyyy")}' WHERE ERR_CODE = '{objErrorEntity.errCode}'";
                int gd = DBConnection.ExecuteQuery(query);
                return gd;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable FetchLoginError()
        {
            try
            {
                string query = $"SELECT ERR_DESC FROM ERROR_CODE_MASTER WHERE ERR_CODE='5'";
                DataTable dt = DBConnection.ExecuteDataset(query);
                return dt;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public DataTable FetchDeletion()
        {
            try
            {
                string query = $"SELECT ERR_DESC FROM ERROR_CODE_MASTER WHERE ERR_CODE='3'";
                DataTable dt = DBConnection.ExecuteDataset(query);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SavedSuccessfully()
        {
            try
            {
                string query = $"SELECT ERR_DESC FROM ERROR_CODE_MASTER WHERE ERR_CODE='1'";
                DataTable dt = DBConnection.ExecuteDataset(query);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable UpdatedSuccessfully()
        {
            try
            {
                string query = $"SELECT ERR_DESC FROM ERROR_CODE_MASTER WHERE ERR_CODE='2'";
                DataTable dt = DBConnection.ExecuteDataset(query);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
