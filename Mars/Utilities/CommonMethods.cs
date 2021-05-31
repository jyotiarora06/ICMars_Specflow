using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using AventStack.ExtentReports;
using ExcelDataReader;
using OpenQA.Selenium;




namespace Mars.Utilities
{
    public class CommonMethods
    {
        //Capture Screenshot

        public MediaEntityModelProvider CaptureScreenshotAndReturnModel(string Name)
        {
            var screenshot = ((ITakesScreenshot)Driver.driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, Name).Build();

        }

        public class ExcelLibHelper
        {
            

            private static DataTable ExcelToDataTable(String filename, String sheetName)
            {
                //Open file and returns as Stream
                using (System.IO.FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read))
                {
                    //CreateOpenXmlReader via ExcelReaderFactory 
                    using (IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                    { 

                        //Return as DataSet and set the frist row as column name
                        DataSet result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });


                        DataTableCollection table = result.Tables;


                        DataTable resultTable = table[sheetName];


                        //Return
                        return resultTable;
                    }
                }
            }

            static List<DataCollection> dataCol = new List<DataCollection>();
            

            public static void PopulateInCollection(string fileName, String sheetName)
            {
                //dataCollection = new List<DataCollection>();

                DataTable table = ExcelToDataTable(fileName, sheetName);

                //Iterate through the rows and columns of the Table
                for (int row = 1; row <= table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        DataCollection dtTable = new DataCollection()
                        {
                            rowNumber = row,
                            colName = table.Columns[col].ColumnName,
                            colValue = table.Rows[row - 1][col].ToString()
                        };

                        //Add all the details for each row
                        dataCol.Add(dtTable);
                    }
                }

            }

            public static string ReadData(int rowNumber, string columnName)
            {
                try
                {
                    //Retriving Data using LINQ to reduce amount of iterations
                    string data = (from colData in dataCol
                                   where colData.colName == columnName && colData.rowNumber == rowNumber
                                   select colData.colValue).SingleOrDefault();

                    //var data   = dataCollection.Where(collectionData => collectionData.columnName == columnName && collectionData.rowNumber == rowNumber).SingleOrDefault().columnValue; 
                    return data.ToString();
                }
                catch (Exception e)
                {   
                    e.StackTrace.ToString();
                    return null;
                }
            }


            public class DataCollection
            {
                public int rowNumber { get; set; }

                public string colName { get; set; }

                public string colValue { get; set; }
            }
        }
    }
}
