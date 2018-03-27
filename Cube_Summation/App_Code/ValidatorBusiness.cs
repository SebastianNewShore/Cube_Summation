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

        DataColumn columna1 = new DataColumn();
        columna1.DataType = Type.GetType("System.String");
        columna1.AllowDBNull = true;
        columna1.Caption = "Data";
        columna1.ColumnName = "Data";
        dtData.Columns.Add(columna1);

        return dtData;
    }
}