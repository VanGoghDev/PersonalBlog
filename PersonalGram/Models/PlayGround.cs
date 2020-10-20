using System;

namespace PersonalGram.Models
{
    public class PlayGround
    {
        public int StonesAndJewelry()
        {
            var j= Console.ReadLine();
            var s = Console.ReadLine();
            var jArr = j.ToCharArray();
            var sArr = s.ToCharArray();
            var jLen = j.Length;
            var sLen = s.Length;
            var result = 0;
            Console.WriteLine($"j = {j}");
            Console.WriteLine($"s = {s}");
            // foreach (var str in s)
            // {
            //     if (j.IndexOf(str) >= 0)
            //     {
            //         result++;
            //     }
            // }
            for (var i = 0; i < jLen; i++)
            {
                for (var k = 0; k < sLen; k++)
                {
                    if (sArr[k] == jArr[i])
                    {
                        result++;
                    }
                }
            }
            Console.WriteLine($"{result}");
            return result;
        }
    }
}