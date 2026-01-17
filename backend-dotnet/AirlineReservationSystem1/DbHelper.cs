using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace AirlineReservationSystem
{
    public static class DbHelper
    {
        // update if your credentials differ
        private static readonly string ConnString = "server=localhost;database=reservation;uid=root;pwd=root;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnString);
        }

        public static DataTable GetDataTable(string sql, params MySqlParameter[] parameters)
        {
            using (var con = GetConnection())
            using (var cmd = new MySqlCommand(sql, con))
            using (var da = new MySqlDataAdapter(cmd))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
