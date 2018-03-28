using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Queries
/// </summary>
public class Queries
{
    public int ResultQuery(string[] item, int[,,] matriz, out string errorMessage)
    {
        errorMessage = string.Empty;
        var result = 0;
        try
        {
            var initialX = int.Parse(item[1])-1;
            var initialY = int.Parse(item[2])-1;
            var initialZ = int.Parse(item[3])-1;
            var finalX = int.Parse(item[4])-1;
            var finalY = int.Parse(item[5])-1;
            var finalZ = int.Parse(item[6])-1;


            for (var dim1 = initialX; dim1 <= finalX; dim1++)
            {
                for (var dim2 = initialY; dim2 <= finalY; dim2++)
                {
                    for (var dim3 = initialZ; dim3 <= finalZ; dim3++)
                    {
                        result += matriz[dim1, dim2,dim3];
                    }

                }
            }
        }
        catch
        {
            errorMessage = RestrictionConstants.ErrorQuery;
        }
        return result;
    }

    public int[,,] UpdateQuery(string[] item, int[,,] matriz, out string errorMessage)
    {
        errorMessage = string.Empty;
        try
        {
            var value = int.Parse(item[4]);
            if (value > Math.Pow(10,9))
            {
                errorMessage = RestrictionConstants.ValueOutsideRange;
                return matriz;
            }
               

            var x = int.Parse(item[1])-1;
            var y = int.Parse(item[2])-1;
            var z = int.Parse(item[3])-1;
            
            matriz[x, y, z] = value;
        }
        catch
        {
            errorMessage = RestrictionConstants.ErrorUpdatingQuery;
        }
        return matriz;
    }
}