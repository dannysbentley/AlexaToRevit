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
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentNullException("filePath");
            FilePath = filePath;
        }

        //***********************************ReadFile***********************************
        private void ReadFile()
        {
            if (System.IO.File.Exists(FilePath))
            {
                using (var fs = new System.IO.FileStream(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite))
                {
                    using (var tr = new System.IO.StreamReader(fs))
                    {
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
            
            using (var fs = new System.IO.FileStream(FilePath, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
            {
                using (var sw = new System.IO.StreamWriter(fs))
                {
                    CsvWriter csvW = new CsvWriter(sw);

                    csvW.WriteRecords(records);
                    sw.Dispose();
                }
                fs.Dispose();
                fs.Close();
            }
        }
    }
}
