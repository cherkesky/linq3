using System;
using System.Collections.Generic;
using System.Linq;

namespace linqGroupBy
{
    public class SalesReportEntry
    {
        public string ReportNeighborhood { get; set; }
        public double ReportTotalSales { get; set; }
    }
    public class Kid {
        public string FullName {get; set;}
        public string Neighborhood {get; set;}
        public double Sales {get; set;}
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Kid> kids = new List<Kid>(){
                new Kid(){
                    FullName = "Billy Smith", Neighborhood = "Nolensville", Sales = 67.16
                },
                new Kid(){
                    FullName = "Jason Sync", Neighborhood = "North Nashville", Sales = 13.16
                },new Kid(){
                    FullName = "Guy Cherkesky", Neighborhood = "Brentwood", Sales = 666.66
                },
                new Kid(){
                    FullName = "Kyle Edwards", Neighborhood = "Nolensville", Sales = 117.10
                },
                new Kid(){
                    FullName = "Avery Barkley", Neighborhood = "The Nations", Sales = 97.16
                },
                new Kid(){
                    FullName = "Audrey Ellington", Neighborhood = "Nolensville", Sales = 57.18
                },
                new Kid(){
                    FullName = "Juanita Voss", Neighborhood = "North Nashville", Sales = 147.12
                },
                new Kid(){
                    FullName = "Scott Avett", Neighborhood = "North Nashville", Sales = 56.11
                }
            };

             List<SalesReportEntry> salesReport = (from kid in kids
             //dealing with kids list
                group kid by kid.Neighborhood into neighborhoodGroup
            //now dealing with neighborhoodGroup list
                select new SalesReportEntry {
                    ReportNeighborhood = neighborhoodGroup.Key, 
                    ReportTotalSales = neighborhoodGroup.Sum(kidObj => kidObj.Sales)
                }).OrderByDescending(sr => sr.ReportTotalSales).ToList();

            foreach(SalesReportEntry entry in salesReport)
            {
                Console.WriteLine($"{entry.ReportNeighborhood}, {entry.ReportTotalSales}");
            }
        }
    }
}