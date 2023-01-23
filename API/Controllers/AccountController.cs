using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using API;
using Newtonsoft.Json;
using System.Text;
using System.ServiceProcess;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        DBConnector dBConnector = new DBConnector();


        /// <summary>
        /// ��������� ���������� ��������
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        public string Get()
        {
            string sql = string.Format(
                "SELECT TOP(1)  Login, Password, Status " +
                "FROM           Accounts " +
                "WHERE          (Status = 0)"
                );
            string answer = "";
            dBConnector.OpenConnection();
            using (SqlCommand cmd = new SqlCommand(sql, dBConnector.connect))
            {
                cmd.CommandText = sql;
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();
                    string login    = sqlDataReader.GetValue(0).ToString().Trim();
                    string pass     = sqlDataReader.GetValue(1).ToString().Trim();
                    string status   = sqlDataReader.GetValue(2).ToString().Trim();
                    dBConnector.CloseConnection();
                    Update(login, "1");
                    Account account = new Account(login, pass, status);
                    answer = JsonConvert.SerializeObject(account);
                }
            }
            return answer;
        }

        /// <summary>
        /// ��������� ������� ��������
        /// </summary>
        /// <param name="login">�����</param>
        /// <param name="status">������</param>
        /// <returns></returns>
        [HttpPost("Update/{login}/{status}")]
        public IActionResult Update([FromRoute]string login, [FromRoute]string status)
        {
            string sql = string.Format("UPDATE Accounts SET Status = '{0}' WHERE Login = '{1}'", status, login);
            dBConnector.OpenConnection();
            using (SqlCommand cmd = new SqlCommand(sql, dBConnector.connect))
            {
                cmd.ExecuteNonQuery();
            }
            dBConnector.CloseConnection();
            return Ok();
        }
        [HttpGet("Avalible")]
        public IActionResult Avalible()
        {
            return Ok();
        }
        [HttpPost("Add/{login}/{password}")]
        public string Add([FromRoute] string login, [FromRoute] string password)
        {
            string sql = string.Format("SELECT * FROM Accounts WHERE Login = '{0}'", login);
            dBConnector.OpenConnection();
            using (SqlCommand cmd = new SqlCommand(sql, dBConnector.connect))
            {
                cmd.CommandText = sql;
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    dBConnector.CloseConnection();
                    sql = string.Format("UPDATE Accounts SET Password = '{1}' WHERE Login = '{0}'", login, password);
                    dBConnector.OpenConnection();
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    dBConnector.CloseConnection();
                    return "Update!";
                }
                else
                {
                    dBConnector.CloseConnection();
                }
                sql = string.Format("INSERT INTO Accounts (Login, Password, Status) VALUES ('{1}','{0}',0)", password, login);
                dBConnector.OpenConnection();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                dBConnector.CloseConnection();
                return "Add!";
            }

        }
        [HttpGet("GetAll")]
        public string GetAll()
        {
            string sql = string.Format("SELECT * FROM Accounts");
            StringBuilder stringBuilder = new StringBuilder();
            dBConnector.OpenConnection();
            using (SqlCommand cmd = new SqlCommand(sql, dBConnector.connect))
            {
                cmd.CommandText = sql;
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.HasRows)
                {
                    if (sqlDataReader.Read())
                    {
                        stringBuilder.Append(sqlDataReader.GetValue(0).ToString().Trim() + ";");
                        stringBuilder.Append(sqlDataReader.GetValue(1).ToString().Trim() + ";");
                        stringBuilder.Append(sqlDataReader.GetValue(2).ToString().Trim() + "\n");
                    }
                    else
                    {
                        break;
                    }
                }
                dBConnector.CloseConnection();
            }
            return stringBuilder.ToString();

        }
        
    }
}