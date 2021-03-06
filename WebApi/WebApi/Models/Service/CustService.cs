﻿using Dapper;
using EF.Diagnostics.Profiling;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class CustService : ICustService
    {
        public string Para { get; set; }
        public string Para2 { get; set; }

        public Func<IDbConnection> CustConnection { get; set; }
        private IDatabaseHelper DatabaseHelper { get; set; }

        public string getCust1()
        {
            return "getCust1";
        }
        public string getCust2()
        {
            return "getCust2";
        }

        public string getCust3()
        {
            return Para;
        }

        public string getCust4()
        {
            return Para2;
        }
        public string getCust5()
        {
            using (ProfilingSession.Current.Step("Data.LoadActiveDemoData"))
            {
                using (var conn = CustConnection())
                {
                    string sqlStatement = "select top 1 * from Customer where CustomerID=@CustomerID";

                    var result = conn.Query<dynamic>(
                           sqlStatement,
                           new
                           {
                               CustomerID = 7
                           })
                           .FirstOrDefault();


                    //conn.Open();

                    //using (var cmd = conn.CreateCommand())
                    //{
                    //    cmd.CommandType = CommandType.Text;
                    //    cmd.CommandText = "select top 1 * from Customer";

                    //    using (var reader = cmd.ExecuteReader())
                    //    {
                    //        var results = reader;
                    //    }
                    //}
                }
            //}


            //using (var cn = this.DramaConnection())
            //{
            //    var list = cn.Query(
            //  "SELECT top 1* FROM Cust ");

            //}
                return Para2;
        }

    }
}