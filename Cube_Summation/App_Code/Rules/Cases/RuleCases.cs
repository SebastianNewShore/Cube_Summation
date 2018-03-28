using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de RuleCases
/// </summary>
public class RuleCases
{
    public bool ValidateTestCase(string[] cases)
    {
        if (cases != null && cases.ToList().Count == 1 && int.Parse(cases[0].ToString()) <= RestrictionConstants.testCases)
        {
            return true;
        }
        return false;
    }

    public bool ValidateMatriz(string[] matriz)
    {
        if (matriz != null && matriz.ToList().Count == 2 && int.Parse(matriz[0].ToString()) > 0 && int.Parse(matriz[0].ToString()) <= RestrictionConstants.Matriz &&
        int.Parse(matriz[1].ToString()) > 0 && int.Parse(matriz[1].ToString()) <= RestrictionConstants.Operations)
        {
            return true;
        }
        return false;
    }
}