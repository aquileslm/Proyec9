using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace WebApplication3
{
    public class Class1
    {


        private const String SERVER = "localhost";

        private const String PORT = "5432";

        private const String USER = "postgres";

        private const String PASSWORD = "admin";

        private const String DATABASE = "proyectodes9";
        private NpgsqlConnection connection;

        public void DatabaseHelper()

        {

            // Create connection object.

            connection = new NpgsqlConnection(

                "Server=" + SERVER + ";" +

                "Port=" + PORT + ";" +

                "User Id=" + USER + ";" +

                "Password=" + PASSWORD + ";" +

                "Database=" + DATABASE + ";");

            }
            


// Open database connection.

        private void openConnection()

        {

            try

            {

                connection.Open();

            }

            catch (NpgsqlException ex)

            {

                showError(ex);

            }

        }



        // Close database connection.

        private void closeConnection()

        {

            try

            {

                connection.Close();

            }

            catch (NpgsqlException ex)

            {

                showError(ex);

            }

        }


        // Show error to message box.

        private void showError(NpgsqlException ex)

        {

            // mbox.Show(ex.Message, "Error", MessageBoxButtons.OK,

            //   MessageBoxIcon.Error);

        }


    }
}
