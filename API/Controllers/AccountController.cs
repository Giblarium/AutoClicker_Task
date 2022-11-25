using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using API;
using Newtonsoft.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        DBConnector dBConnector = new DBConnector();


        /// <summary>
        /// Получение незанятого аккаунта
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
        /// Установка статуса аккаунту
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="status">Статус</param>
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
    }
}