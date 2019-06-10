using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MyAPIHelloworldApp
{
    public class DALManager
    {
        protected static string strConnect;
        public DALManager()
        {
            strConnect = ConfigurationSettings.AppSettings["masterConnectionString"];
             if (strConnect == null || string.IsNullOrEmpty(strConnect))
                throw new Exception("Fatal error: missing connecting string in web.config file");
            //strConnect = "Data Source=LAPTOP-2C0MNCNJ;Initial Catalog=master;Integrated Security=True";
        }
 
        /// <summary>  
        /// Gets a SqlConnection to the local sqlserver  
        /// </summary>  
        /// <returns>SqlConnection</returns>   
        protected SqlConnection GetConnection()
        {
            SqlConnection oConnection = new SqlConnection(strConnect);
            return oConnection;
        }

        public DataSet GetAllProduct()
        {
            SqlConnection oConnection = GetConnection();
            // build the command  
            SqlCommand oCommand = new SqlCommand("getAllProduct", oConnection);
            oCommand.CommandType = CommandType.StoredProcedure; // Parametrs            
            // Adapter and DataSet  
            SqlDataAdapter oAdapter = new SqlDataAdapter();
            oAdapter.SelectCommand = oCommand;
            DataSet oDataSet = new DataSet();
            try
            {
                oConnection.Open();
                oAdapter.Fill(oDataSet, "product"); return oDataSet;
            }
            catch (Exception oException)
            {

                throw oException;
            }
            finally
            {
                oConnection.Close();
            }
        }
    }
}