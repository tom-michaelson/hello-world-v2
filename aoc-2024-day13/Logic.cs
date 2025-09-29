using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorldV2.aoc_2024_day13
{
    public class Logic
    {
        
        public void Handle()
        {
            //var f = File.Parse("./aoc-2024-day13/input.txt", 10000000000000);
            var f = File.Parse("./aoc-2024-day13/test.txt", 10000000000000);
            var totalCost = 0L;
            foreach(var line in f.Lines)
            {
                try
                {
                    Console.Write("line: ");
                    var best = BestCost(line);
                    Console.WriteLine(best);
                    totalCost += best;
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    //couldn't find prize
                }
            }
            Console.WriteLine("Total Cost: " + totalCost);
        }

        private long BestCost(FileLine line)
        {
            line.Init();
            while (!line.Compare()) { }
            return line.CurrentCost();
        }
    }
}
