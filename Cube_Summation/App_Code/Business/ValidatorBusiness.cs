using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ValidatorBusiness
/// </summary>
public class ValidatorBusiness
{
    public DataTable ConsultRoute(string route)
    {
        string data;

        StreamReader read = new StreamReader(route);
        DataTable dtResponse = CreateDataTable();

        while ((data = read.ReadLine()) != null)
        {
            dtResponse.Rows.Add(data);
        }
        read.DiscardBufferedData();

        read.Dispose();

        read.Close();

        return dtResponse;
    }

    public bool ConsultFileExistence(string route)
    {
        if (File.Exists(route))
        {
            return true;
        }
        return false;
    }

    public DataTable CreateDataTable()
    {
        DataTable dtData = new DataTable();

        DataColumn column1 = new DataColumn();
        column1.DataType = Type.GetType("System.String");
        column1.AllowDBNull = true;
        column1.Caption = "TestCase";
        column1.ColumnName = "TestCase";
        dtData.Columns.Add(column1);

        DataColumn column2 = new DataColumn();
        column2.DataType = Type.GetType("System.String");
        column2.AllowDBNull = true;
        column2.Caption = "Query";
        column2.ColumnName = "Query";
        dtData.Columns.Add(column2);

        DataColumn column3 = new DataColumn();
        column3.DataType = Type.GetType("System.String");
        column3.AllowDBNull = true;
        column3.Caption = "Result";
        column3.ColumnName = "Result";
        dtData.Columns.Add(column3);

        return dtData;
    }
}