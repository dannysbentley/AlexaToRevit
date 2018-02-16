using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaToRevit
{
    class CsvAlexaResponse
    {
        public string FilePath { get; set; }

        //***********************************CsvAlexaResponse***********************************
        public CsvAlexaResponse(string filePath)
        {
            //Check that the file exist. 
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentNullException("filePath");
            FilePath = filePath;
        }

        //***********************************ReadFile***********************************
        // This would only be used if we wanted to edit the by talking to alexa 
        // This method is not implemented. 
        private void ReadFile()
        {
            if (System.IO.File.Exists(FilePath))
            {
                // Stream file and read 
                using (var fs = new System.IO.FileStream(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite))
                {
                    //Read file stream 
                    using (var tr = new System.IO.StreamReader(fs))
                    {
                        // Read csv file. 
                        CsvHelper.CsvReader csvR = new CsvHelper.CsvReader(tr);

                        try
                        {
                            while (csvR.Read())
                            {                               
                                string item = csvR.GetField<string>(0);
                                string property = csvR.GetField<string>(1);
                            }
                        }
                        catch { }
                        // close 
                        tr.Dispose();
                        fs.Dispose();
                        fs.Close();
                    }
                }
            }
        }

        //***********************************WriteFile***********************************
        public void WriteFile(IEnumerable<DataRecords> records)
        {
            // Stream file    
            using (var fs = new System.IO.FileStream(FilePath, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
            {
                // Read stream as write. 
                using (var sw = new System.IO.StreamWriter(fs))
                {
                    CsvWriter csvW = new CsvWriter(sw);
                    // write updated records to database csv
                    csvW.WriteRecords(records);
                    sw.Dispose();
                }
                // close
                fs.Dispose();
                fs.Close();
            }
        }
    }
}
