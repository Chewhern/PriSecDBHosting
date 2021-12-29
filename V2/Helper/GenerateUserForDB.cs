﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace PriSecDBAPI.Helper
{
    public class GenerateUserForDB
    {
        public MySqlConnection GenerateDBUserConnection = new MySqlConnection();
        public Boolean CheckConnection;
        public String SecretPath = "{Path of MySQL Database Account in generating database account for user}";
        public String ConnectionString = "";

        public void setConnection()
        {
            using (StreamReader SecretPathReader = new StreamReader(SecretPath))
            {
                while ((ConnectionString = SecretPathReader.ReadLine()) != null)
                {
                    GenerateDBUserConnection.ConnectionString = ConnectionString;
                }
            }
        }

        public Boolean LoadConnection(ref String Exception)
        {
            setConnection();
            try
            {
                GenerateDBUserConnection.Open();
                CheckConnection = true;
            }
            catch (MySqlException exception)
            {
                CheckConnection = false;
                Exception = exception.ToString();
            }
            return CheckConnection;
        }

    }
}
