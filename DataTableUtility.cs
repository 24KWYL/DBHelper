using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Office.Interop.Excel;

namespace DBHelper
{
    public class DataTableUtility
    {
        public static void OutputExcel(String FieldPath)
        {

        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="column">传入的指定列</param>
        /// <param name="FieldPath">保存的文件路径</param>
        public static bool ImportExcel(System.Data.DataTable dt, string column, string filepath)
        {
            //1.传入DataTable ，更新指定列（字符串型）。即向指定列追加固定字符串
            if (column != "")
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][column] = dt.Rows[i][column] + ".jpg";
            }
            //2.将DataTable中的数据导出到指定路径的excel。
            if (dt == null)
            {
                return false;
            }
            else
            {
                int rowNum = dt.Rows.Count;
                int columnNum = dt.Columns.Count;
                int rowIndex = 1;
                int columnIndex = 0;
                Application xlApp = new ApplicationClass();
                xlApp.DefaultFilePath = "";
                xlApp.DisplayAlerts = true;
                xlApp.SheetsInNewWorkbook = 1;
                Workbook xlBook = xlApp.Workbooks.Add(true);
                //将DataTable的列名导入Excel表第一行
                foreach (DataColumn dc in dt.Columns)
                {
                    columnIndex++;
                    xlApp.Cells[rowIndex, columnIndex] = dc.ColumnName;
                }
                //将DataTable中的数据导入Excel中
                for (int i = 0; i < rowNum; i++)
                {
                    rowIndex++;
                    columnIndex = 0;
                    for (int j = 0; j < columnNum; j++)
                    {
                        columnIndex++;
                        xlApp.Cells[rowIndex, columnIndex] = dt.Rows[i][j].ToString();
                    }
                }
                xlApp.DisplayAlerts = false;
                xlBook.SaveCopyAs(filepath);
                xlApp.Workbooks.Close();
                return true;
            }
        }
    }
}
