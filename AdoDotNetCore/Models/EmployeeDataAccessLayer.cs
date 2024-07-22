using System.Data;
using System.Data.SqlClient;

namespace AdoDotNetCore.Models
{
    public class EmployeeDataAccessLayer
    {
        string cs = ConnectionString.dbcs;

        public List<Employee> getAllEmployee()
        {
            List<Employee> empList = new List<Employee>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                ////SQL Server Statement
                //string query = "select Id,Name,Gender,Age,Designation,City from Employee";
                //SqlCommand cmd = new SqlCommand(query, con);
                ////SqlCommand cmd = new SqlCommand("select Id,Name,Gender,Age,Designation,City from Employee", con);
                //cmd.CommandType = CommandType.Text;

                //SQL Server stored procedure
                SqlCommand cmd = new SqlCommand("spGetAllEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employee emp = new Employee();

                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["Name"].ToString() ?? "";
                    emp.Gender = reader["Gender"].ToString() ?? "";
                    emp.Age = Convert.ToInt32(reader["Age"]);
                    emp.Designation = reader["Designation"].ToString() ?? "";
                    emp.City = reader["City"].ToString() ?? "";

                    empList.Add(emp);
                }
            }
            return empList;
        }

        public void AddEmployee(Employee emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                ////SQL Server Statement
                //string query = "insert into Employee (Name,Gender,Age,Designation,City) values (@name,@gender,@age,@designation,@city)";
                //SqlCommand cmd = new SqlCommand(query, con);
                ////SqlCommand cmd = new SqlCommand("insert into Employee (Name,Gender,Age,Designation,City) values (@name,@gender,@age,@designation,@city)", con);
                //cmd.CommandType = CommandType.Text;

                //SQL Server stored procedure
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", emp.Name);
                cmd.Parameters.AddWithValue("@gender", emp.Gender);
                cmd.Parameters.AddWithValue("@age", emp.Age);
                cmd.Parameters.AddWithValue("@designation", emp.Designation);
                cmd.Parameters.AddWithValue("@city", emp.City);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Employee getEmployeeById(int? id)
        {
            Employee emp = new Employee();
            using (SqlConnection con = new SqlConnection(cs))
            {
                ////SQL Server Statement
                //string query = "select Id,Name,Gender,Age,Designation,City from Employee where Id = @id";
                //SqlCommand cmd = new SqlCommand(query, con);
                ////SqlCommand cmd = new SqlCommand("select Id,Name,Gender,Age,Designation,City from Employee where Id = @id", con);
                //cmd.CommandType = CommandType.Text;

                //SQL Server stored procedure
                SqlCommand cmd = new SqlCommand("spGetEmployeeById", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["Name"].ToString() ?? "";
                    emp.Gender = reader["Gender"].ToString() ?? "";
                    emp.Age = Convert.ToInt32(reader["Age"]);
                    emp.Designation = reader["Designation"].ToString() ?? "";
                    emp.City = reader["City"].ToString() ?? "";
                }
            }
            return emp;
        }

        public void UpdateEmployee(Employee emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                ////SQL Server Statement
                //string query = "update Employee set Name=@name,Gender=@gender,Age=@age,Designation=@designation,City=@city where Id=@id";
                //SqlCommand cmd = new SqlCommand(query, con);
                ////SqlCommand cmd = new SqlCommand("update Employee set Name=@name,Gender=@gender,Age=@age,Designation=@designation,City=@city where Id=@id", con);
                //cmd.CommandType = CommandType.Text;

                //SQL Server stored procedure
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", emp.Id);
                cmd.Parameters.AddWithValue("@name", emp.Name);
                cmd.Parameters.AddWithValue("@gender", emp.Gender);
                cmd.Parameters.AddWithValue("@age", emp.Age);
                cmd.Parameters.AddWithValue("@designation", emp.Designation);
                cmd.Parameters.AddWithValue("@city", emp.City);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int? id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                ////SQL Server Statement
                //string query = "delete from Employee where Id=@id";
                //SqlCommand cmd = new SqlCommand(query, con);
                ////SqlCommand cmd = new SqlCommand("delete from Employee where Id=@id", con);
                //cmd.CommandType = CommandType.Text;

                //SQL Server stored procedure
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        } 
    }
}
