using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de RestrictionConstants
/// </summary>
public static class RestrictionConstants
{
    public const int testCases = 50;
    public const int Matriz = 100;
    public const int Operations = 1000;
    public const string Query = "QUERY";
    public const string Update = "UPDATE";
    public const string ValueOutsideRange = "The result of the query exceeds the maximum value, therefore it will not be updated";
    public const string ErrorUpdatingQuery = "an error occurred while trying to update the array";
    public const string ErrorQuery = "an error occurred while trying to process the sum";
    public const string UrecognizedQuery = "Invalid query, check testcase number";
    public const string GenericError = "I'm sorry there was an error processing the data";
    public const string ErrorTestCase = "verify the format or number of test cases entered";
    public const string ErrorArrayOrOperation = "verify the format of array and operations or their quantity";
    public const string NumberOfFiles = "Can not be attached more than 1 file";
    public const string SelectFile = "Please select a file";
    public const string ValidFile = "Please select a valid file";
    public const string ErrorLoad = "Sorry there were problems with the loading of the file";
    public const string FileUpload = "the file with the queries were loaded correctly";
    public const string FileExist = "This file has already been loaded, so it will only be replaced";
    public const string ValidExtension = ".txt";
}