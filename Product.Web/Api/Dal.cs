using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Runtime.CompilerServices;

namespace Product.Web.Api
{
    public class Dal
    {
        SqlConnection sqlConnection;


        public Dal()
        {
            var configuration = GetConfiguration();
            sqlConnection = new SqlConnection(configuration["ConnectionStrings:dbConnection"]);

        }



        IConfiguration GetConfiguration()
        {
            IConfiguration AppSetting = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            return AppSetting;
        }


        public DataTable GetData()
        {
        
            try
            {
                using SqlConnection con = sqlConnection;
                using SqlCommand command = new SqlCommand();
                DataTable dtTable = new DataTable();

                con.Open();
                command.CommandText = "Select ProductId, Name, ProductNumber, ListPrice  from Production.Product Order by Name";
                command.CommandType = CommandType.Text;
                command.Connection = con;
                dtTable.Load(command.ExecuteReader());

                return dtTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public DataSet GetDataById(int ProductId)
        {

            try
            {
                using SqlConnection con = sqlConnection;
                using SqlCommand command = new SqlCommand();
                DataSet dt = new DataSet();

                con.Open();

                string commandText = "Select ProductId, Name, Color,Size  from Production.Product WHERE ProductId = @ProductId;  Select StartDate,EndDate,StandardCost from Production.ProductCostHistory where ProductId = @ProductId";

                command.Connection = con;
                command.CommandText = commandText;
                command.Parameters.Add("@ProductId", SqlDbType.Int);
                command.Parameters["@ProductId"].Value = ProductId;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);

                return dt;

            }
                catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
