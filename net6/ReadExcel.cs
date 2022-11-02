using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace net6
{
    internal class ReadExcel
    {
        public static List<Account> ReadExcelBook(string path)
        {
            List<Account> accounts = new List<Account>();
            Excel.Application ObjWorkExcel = new Excel.Application(); //открыть эксель
            Excel.Workbook ObjWorkBook;
            Excel.Worksheet ObjWorkSheet;
            try
            {

                ObjWorkBook = ObjWorkExcel.Workbooks.Open(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing); //открыть файл
                ObjWorkSheet = (Excel.Worksheet)ObjWorkBook.Sheets[1];
                var lastCell = ObjWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell);
                for (int i = 0; i < lastCell.Row; i++)
                {
                    string login = ObjWorkSheet.Cells[i + 1, 1].Text.ToString();
                    string pass = ObjWorkSheet.Cells[i + 1, 2].Text.ToString();
                    accounts.Add(new Account(login, pass, Status.InWork));
                }

                ObjWorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохраняя
            }
            catch (Exception e)
            {

            }
            finally
            {
                ObjWorkExcel.Quit(); // выйти из экселя
                GC.Collect(); // убрать за собой
            }
            return accounts;
        }
    }
}
