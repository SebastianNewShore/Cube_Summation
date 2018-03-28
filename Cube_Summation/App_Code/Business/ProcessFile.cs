using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Descripción breve de ProcessFile
/// </summary>
public class ProcessFile
{
    Queries QueryProcess = new Queries();
    ValidatorBusiness Validator = new ValidatorBusiness();

    public DataTable DataDistribution(DataTable dtFile, out string errorMessage)
    {
       
        var dtResponse = new DataTable();
        errorMessage = string.Empty;
        var count = 0;

        try
        {
            var cases = dtFile.Rows[0]["TestCase"].ToString().Split(' ');
            if (cases != null && cases.ToList().Count == 1 && int.Parse(cases[0].ToString()) <= RestrictionConstants.testCases)
            {
                var countCases = int.Parse(dtFile.Rows[0]["TestCase"].ToString());
                List<string>[] arrayMatriz = new List<string>[countCases];

                for (var i = 1; i <= dtFile.Rows.Count - 1; i++)
                {
                    var matriz = dtFile.Rows[i]["TestCase"].ToString().Split(' ');

                    if (matriz != null && matriz.ToList().Count == 2 && int.Parse(matriz[0].ToString()) > 0 && int.Parse(matriz[0].ToString()) <= RestrictionConstants.Matriz &&
                        int.Parse(matriz[1].ToString()) > 0 && int.Parse(matriz[1].ToString()) <= RestrictionConstants.Operations)
                    {
                        arrayMatriz[count] = new List<string>();
                        for (var j = i; j <= int.Parse(matriz[1].ToString()) + i; j++)
                        {
                            arrayMatriz[count].Add(dtFile.Rows[j]["TestCase"].ToString());
                        }
                        i = i + int.Parse(matriz[1].ToString()) - 1;
                        count++;
                    }
                    else
                    {
                        errorMessage = RestrictionConstants.ErrorArrayOrOperation;
                    }
                }
                dtResponse = MatrixCreation(arrayMatriz, out errorMessage);
            }
            else
            {
                errorMessage = RestrictionConstants.ErrorTestCase;
            }
        }
        catch
        {
            errorMessage = RestrictionConstants.GenericError;
        }
        return dtResponse;
    }

    private DataTable MatrixCreation(List<string>[] arrayMatriz, out string errorMessage)
    {
        var dtResponse = Validator.CreateDataTable();
        errorMessage = string.Empty;
        DataRow row;
        try
        {
            foreach (var item in arrayMatriz)
            {
                var index = Array.IndexOf(arrayMatriz, item);
                var dimension = int.Parse(item[0].ToString().Split(' ')[0]);
                int[,,] matriz = new int[dimension, dimension, dimension];
                item.RemoveAt(0);
                var dictionary = CaseProcessing(index, matriz, item, out errorMessage);

                foreach (var key in dictionary)
                {
                    row = dtResponse.NewRow();
                    row["TestCase"] = index + 1;
                    row["Query"] = key.Key + 1;
                    row["Result"] = key.Value;
                    dtResponse.Rows.Add(row);
                }
            }
        }
        catch
        {
            errorMessage = RestrictionConstants.GenericError;
        }
        return dtResponse;
    }

    private Dictionary<int,int> CaseProcessing(int index,int[,,] matriz, List<string> item, out string errorMessage)
    {
        var dictionary = new Dictionary<int, int>();
        errorMessage = string.Empty;
        var countQuery = 0;
        try
        {
            foreach (var query in item)
            {
                var result = 0;
                var name = query.Split(' ')[0];
                if (!string.IsNullOrEmpty(name) && (name.Trim() == RestrictionConstants.Query || name == RestrictionConstants.Update))
                {
                    switch (name.Trim())
                    {
                        case RestrictionConstants.Update:
                            matriz = QueryProcess.UpdateQuery(query.Split(' '), matriz, out errorMessage);
                            break;
                        case RestrictionConstants.Query:
                            result = QueryProcess.ResultQuery(query.Split(' '), matriz, out errorMessage);
                            dictionary.Add(countQuery, result);
                            countQuery++;
                            break;
                    }
                }
                else
                {
                    errorMessage = RestrictionConstants.UrecognizedQuery + " " + index;
                }
            }
        }
        catch
        {
            errorMessage = RestrictionConstants.GenericError;
        }
        return dictionary;
    }
}