
using API;
using Microsoft.Data.SqlClient;
using System;
using Excel = Microsoft.Office.Interop.Excel;

List<Account> accounts = ReadExcelBook(args[0]);
DBConnector dBConnector = new DBConnector();


foreach (var item in accounts)
{
    string sqlSelect = string.Format($"SELECT * FROM Accounts WHERE Login = {item.Login}");
    using (SqlCommand cmd = new SqlCommand(sqlSelect, dBConnector.connect))
    {
        cmd.CommandText = sqlSelect;
        dBConnector.OpenConnection();
        SqlDataReader sqlDataReader = cmd.ExecuteReader();
        

        if (sqlDataReader.HasRows)
        {
            dBConnector.CloseConnection();
            string sqlUpdate = string.Format(
                $"UPDATE    Accounts " +
                $"SET       Login ='{item.Login}', Password ='{item.Password}', Status =0 " +
                $"WHERE     Login ='{item.Login}'");
            cmd.CommandText = sqlUpdate;
            dBConnector.OpenConnection();
            cmd.ExecuteNonQuery();
            dBConnector.CloseConnection();

        }
        else
        {
            dBConnector.CloseConnection();
            string sqlInsert = string.Format(
                $"INSERT INTO   Accounts " +
                $"              (Login, Password, Status) " +
                $"VALUES        ('{item.Login}', '{item.Password}', 0)");
            cmd.CommandText = sqlInsert;
            dBConnector.OpenConnection();
            cmd.ExecuteNonQuery();
            dBConnector.CloseConnection();

        }
    }

}



/// <summary>
/// Чтение книги с паролями
/// </summary>
/// <param name="path">Путь к книге Excel</param>
/// <returns>Возвращает список аккаунтов</returns>
List<Account> ReadExcelBook(string path)
{
    Excel.Application ObjWorkExcel = new Excel.Application(); //открыть эксель
    Excel.Workbook ObjWorkBook;
    Excel.Worksheet ObjWorkSheet;
    //PrintLog.Print($"Открытие книги " + path, "", "", LevelEvent.Info);
    List<Account> loginList = new List<Account>();
    try
    {
        ObjWorkBook = ObjWorkExcel.Workbooks.Open(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing); //открыть файл
        ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1];
        var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);
        //PrintLog.Print($"Книга открыта.", "", "", LevelEvent.Info);
        for (int i = 0; i < lastCell.Row; i++)
        {
            string login = ObjWorkSheet.Cells[i + 1, 1].Text.ToString();
            string pass = ObjWorkSheet.Cells[i + 1, 2].Text.ToString();
            loginList.Add(new Account(login, pass));
        }

        ObjWorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохраняя
    }
    catch (Exception e)
    {
        return new List<Account>();
    }
    finally
    {
        ObjWorkExcel.Quit(); // выйти из экселя
        GC.Collect(); // убрать за собой
    }
    return loginList;
}

class Account
{
    public string Login { get; set; }
    public string Password { get; set; }

    public Account(string login, string password)
    {
        Login = login;
        Password = password;
    }
}