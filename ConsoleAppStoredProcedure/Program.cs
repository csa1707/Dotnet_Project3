using System.Data.SqlClient;

class Program
{

    static void Main()
    {

        try
        {



            Console.WriteLine("hello ajith , welcome to stored procedure program");

            var connection = "Data Source= DESKTOP-IURUBDV\\SQLEXPRESS; Initial Catalog=practice;Integrated Security=True";

            var spname = "getVendors";

            Console.WriteLine("execution of create sp");

            using (SqlConnection conn = new SqlConnection(connection))
            {

                conn.Open();

                using (SqlCommand cmd = new SqlCommand(spname, conn))
                {

                    cmd.CommandText = spname;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine("{0}-{1}",reader.GetInt32(0),reader.GetString(1));
                            Console.WriteLine("{0}-{1}-{2}", reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                        }

                    }


                }

                conn.Close();
            }

            Console.WriteLine("execution of insert sp");
            var insertsp = "insertVendor";
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(insertsp, conn))
                {

                    cmd.CommandText = insertsp;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    cmd.Parameters.Add("@eid", System.Data.SqlDbType.Int).Value = 110;
                    cmd.Parameters.Add("@vegname", System.Data.SqlDbType.VarChar, 10).Value = "cucumber";
                    cmd.Parameters.Add("@cost", System.Data.SqlDbType.Int).Value = 40;

                    cmd.ExecuteNonQuery();
                }


                conn.Close();
            }

            Console.WriteLine("execution of remove sp");
            var removesp = "removevendor";
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(removesp, conn))
                {

                    cmd.CommandText = removesp;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    cmd.Parameters.Add("@eid", System.Data.SqlDbType.Int).Value = 110;


                    cmd.ExecuteNonQuery();
                }


                conn.Close();
            }

        }
        catch(Exception ex)
        {

            Console.WriteLine("error occured so transfeerd to catch block" + ex.Message.ToString());

        }
        finally
        {
            Console.WriteLine("this is finally block executed");

        }


    }



}