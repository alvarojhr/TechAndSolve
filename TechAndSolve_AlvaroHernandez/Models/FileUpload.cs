using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TechAndSolve_AlvaroHernandez.Models
{
    public class FileUpload
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Identification { get; set; }
        public DateTime Execution { get; set; } = DateTime.Now;

        [NotMapped]
        public IFormFile File { get; set; }

        public void ProcessFile(StreamReader reader)
        {
            using (StreamWriter fileOut = new StreamWriter(@"lazy_loading_example_output.txt"))
            {
                int caseNumber = 1;
                string cases = reader.ReadLine();
                while (reader.Peek() > -1)
                {
                    int elementsQn = int.Parse(reader.ReadLine());
                    if (elementsQn <= 2)
                    {
                        fileOut.Write("Case #" + caseNumber + ": 1\n");
                        caseNumber++;
                        for (int i = 0; i < elementsQn; i++)
                        {
                            reader.ReadLine();
                        }
                    }
                    else
                    {
                        int trips = 0;
                        List<int> weights = new List<int>();

                        for (int i = 0; i < elementsQn; i++)
                        {
                            weights.Add(int.Parse(reader.ReadLine()));
                        }

                        weights = weights.OrderByDescending(s => s).ToList();

                        while (weights.Count > 0)
                        {
                            int heaviest = weights.FirstOrDefault();
                            weights.RemoveAt(0);

                            if (heaviest < 50)
                            {
                                double minElements = Math.Ceiling((50d / heaviest) - 1d);

                                if (weights.Count >= minElements)
                                {
                                    for (int i = 0; i < minElements; i++)
                                    {
                                        int lighter = weights.LastOrDefault();
                                        weights.RemoveAt(weights.Count - 1);
                                    }
                                    trips++;
                                }
                            }
                            else
                            {
                                trips++;
                            }
                        }
                        fileOut.Write("Case #" + caseNumber + ": " + trips+ "\n");
                        caseNumber++;
                    }
                }
            }
        }
    }
}
