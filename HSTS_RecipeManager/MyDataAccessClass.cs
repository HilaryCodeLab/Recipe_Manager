using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSTS_RecipeManager
{
    public class MyDataAccessClass
    {
        private IDbConnectionFactory connectionFactory;

        public MyDataAccessClass(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public void Insert(string name, int numServes, string category, int prepTime, string ingredients, string methods)
        {
            //var query = $"INSERT INTO `sakila`.`actor`(`first_name`,`last_name`) VALUES('" + firstname + "','" + lastname + "')";
            var query = $"INSERT INTO `RecipeBook`(`Name`, `Num_Serves`, `Category`, `Prep_Time`, `Ingredients`, `Methods`)VALUES('" + name + "','" + numServes + "','" + category + "','" + prepTime + "','" + ingredients + "','" + methods + "')";
            Console.WriteLine(query);
            using (var connection = connectionFactory.CreateConnection())
            {
                //Creates and returns a MySqlCommand object associated with the MySqlConnection. 
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    Console.WriteLine("Established connection");
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Insert query succesfully executed.");
                    connection.Close();//is not actually necessary as the using statement will make sure to close the connection.
                }
            }
        }
    }
}
