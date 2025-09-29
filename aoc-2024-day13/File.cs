using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;

namespace HelloWorldV2.aoc_2024_day13
{
    internal class File
    {
        private static Regex ButtonARegex = new Regex(@"Button A: X\+(\d+), Y\+(\d+)");
        private static Regex ButtonBRegex = new Regex(@"Button B: X\+(\d+), Y\+(\d+)");
        private static Regex PrizeRegex = new Regex(@"Prize: X=(\d+), Y=(\d+)");
        public FileLine[] Lines { get; set; }

        public static File Parse(string path, long prizeFactor)
        {
            var lines = System.IO.File.ReadAllLines(path);
            var fileLines = lines
                .Select((line, idx) => new { line, idx })
                .GroupBy((lineIdx) => lineIdx.idx / 4)
                .Select(group =>
                {
                    var fileLine = new FileLine();
                    group.ToList().ForEach(lineIdx =>
                    {
                        var buttonA = ButtonARegex.Match(lineIdx.line);
                        if (buttonA.Success)
                        {
                            fileLine.A = new Button(int.Parse(buttonA.Groups[1].Value), int.Parse(buttonA.Groups[2].Value));
                        }
                        var buttonB = ButtonBRegex.Match(lineIdx.line);
                        if (buttonB.Success)
                        {
                            fileLine.B = new Button(int.Parse(buttonB.Groups[1].Value), int.Parse(buttonB.Groups[2].Value));
                        }
                        var prize = PrizeRegex.Match(lineIdx.line);
                        if (prize.Success)
                        {
                            fileLine.Prize = new Prize(int.Parse(prize.Groups[1].Value) + prizeFactor, int.Parse(prize.Groups[2].Value) + prizeFactor);
                        }
                    });
                    return fileLine;
                });
                return new File { Lines = fileLines.ToArray() };
        }
    }
}
