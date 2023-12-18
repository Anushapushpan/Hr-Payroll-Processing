﻿using Databaselayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Master.UserMaster
{
    public class UserMasterManager
    {
        public bool isLogin(string userName, string password)
        {
            try
            {
                int count;
                string sql = $"SELECT * FROM USER_MASTER WHERE  USER_NAME='{userName}' AND  USER_PASSWORD='{password}'";
                DataTable dt = DBConnection.ExecuteDataset(sql);
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

        public bool isPassword(string password)
        {
            try
            {
                int count;
                string sql = $"SELECT * FROM USER_MASTER WHERE USER_PASSWORD='{password}'";
                DataTable dt = DBConnection.ExecuteDataset(sql);
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

        public int ChangePwd(string newPassword, string username)
        {

            try
            {
                string sql = $"UPDATE USER_MASTER SET USER_PASSWORD='{newPassword}' WHERE USER_NAME='{username}'";
                int rows = DBConnection.ExecuteQuery(sql);
                return rows;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable FetchUserMaster()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = DBConnection.ExecuteDataset("SELECT * FROM USER_MASTER");
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool IsUnique(string userId)
        {
            try
            {
                int count;
                string query = $"SELECT * FROM USER_MASTER WHERE USER_ID='{userId}'";
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

        public bool IsInsertToUserMaster(UserMasterEntity objUserEntity)
        {
            try
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                string query = "INSERT INTO USER_MASTER(USER_ID, USER_NAME, USER_PASSWORD, USER_CR_BY,USER_CR_DT,USER_ACTIVE_YN) VALUES (:userId,:userName,:userPwd,:userCrBy,:userCrDt,:userActive)";
                dict.Add("userId", objUserEntity.userId);
                dict.Add("userName", objUserEntity.userName);
                dict.Add("userPwd", objUserEntity.userPassword);
                dict.Add("userCrBy", objUserEntity.userCrBy);
                dict.Add("userCrDt", objUserEntity.userCrDt);
                dict.Add("userActive", objUserEntity.userActiveYn);
                int rows = DBConnection.ExecuteQuery(dict, query);
                if (rows > 0)
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

        public DataTable FetchUserMaster(string userId)
        {
            try
            {
                string query = $"SELECT * FROM USER_MASTER WHERE USER_ID='{userId}'";
                DataTable dt = DBConnection.ExecuteDataset(query);
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int UpdateUser(UserMasterEntity objUserEntity)
        {
            try
            {
                string query = $"UPDATE USER_MASTER SET USER_NAME='{objUserEntity.userName}',USER_PASSWORD='{objUserEntity.userPassword}',USER_UP_BY='{objUserEntity.userUpBy}',USER_UP_DT='{System.DateTime.Now.ToString("dd/MMMM/yyyy")}',USER_ACTIVE_YN='{objUserEntity.userActiveYn}' WHERE USER_ID = '{objUserEntity.userId}'";
                int gd = DBConnection.ExecuteQuery(query);
                return gd;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int DeleteUser(string UserId)
        {
            try
            {
                DataTable gd = new DataTable();
                string sql1 = $"DELETE FROM USER_MASTER WHERE USER_ID='{UserId}'";
                string sql2 = $"DELETE FROM PR_EMPLOYEE WHERE EMP_NO='{UserId}'";
                string sql3 = $"DELETE FROM PR_EMPOLYEE_HR WHERE EH_EMP_NO='{UserId}'";
                int row1 = DBConnection.ExecuteQuery(sql1);
                int row2 = DBConnection.ExecuteQuery(sql2);
                int row3 = DBConnection.ExecuteQuery(sql3);
                int rows = row1 + row2+row3;
                return rows;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
