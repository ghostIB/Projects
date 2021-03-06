﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            LongNumber a = LongNumber.Convert("46846168486464512") * LongNumber.Convert("464135187475");
            a.Show();
            Console.ReadKey();
        }
    }

    class LongNumber
    {
        public List<byte> Number { get; private set; }
        public int Length { get; private set; }
        public LongNumber(int inputNumber)
        {  
            int tmp;
            int len = inputNumber.ToString().Length;
            Number = new List<byte>();
            if (inputNumber == 0)
            {
                Number.Add(0);
            }
            else
            {
                for (int i = 0; i < len; i++)
                {
                    tmp = inputNumber % 10;
                    inputNumber = inputNumber / 10;
                    Number.Add((byte)tmp);
                }
            }
            Length = Number.Count;
        }
        public LongNumber(List<byte> inputList)
        {
            Number = inputList;
            Length = inputList.Count;
        }
        public static LongNumber Convert(string stringNumber)
        {
            if (stringNumber=="0")
            {
                return new LongNumber(0);
            }
            Exception excp = new Exception("stringNumber can't be converted to LongNumber");
            if (stringNumber[0]=='0')
            {
                throw excp;
            }
            List<byte> resultList = new List<byte>();
            foreach (char elem in stringNumber)
            {
                resultList.Add(byte.Parse(elem+""));
            }
            resultList.Reverse();
            return new LongNumber(resultList);
        }
        public static LongNumber operator +(LongNumber first,LongNumber second)
        {
            byte result1=0;
            byte result2=0;
            byte brain = 0;
            byte numeral = 0;
            List<byte> resultList = new List<byte>();
            if (second==new LongNumber(0) || first== new LongNumber(0)) return first==new LongNumber(0) ? second:first;
            int tmp = first.Length >= second.Length ? first.Length : second.Length;
            for (int i=0;i<tmp+1; i++)
            {
                if (i>second.Length-1)
                {
                    result2 = 0;
                }
                else
                {
                    result2 = second.Number[i];
                }
                if (i>first.Length-1)
                {
                    result1 = 0;
                }
                else
                {
                    result1 = first.Number[i];
                }
                numeral = (byte)(result1 + result2 + brain);
                if (numeral == 0) return new LongNumber(resultList);
                resultList.Add((byte)(numeral%10));
                brain = (byte)((numeral) / 10);
            }
            return new LongNumber(resultList);
        }
        public static LongNumber operator -(LongNumber first, LongNumber second)
        {
            if (first==second)
            {
                return new LongNumber(0);
            }
            byte result1 = 0;
            byte result2 = 0;
            int numeral = 0;
            bool minus = false;
            List<byte> resultList = new List<byte>();
            int tmp = first.Length >= second.Length ? first.Length : second.Length;
            for (int i = 0; i < tmp; i++)
            {
                if (i > second.Length-1)
                {
                    result2 = 0;
                }
                else
                {
                    result2 = second.Number[i];
                }
                if (i > first.Length-1)
                {
                    result1 = 0;
                }
                else
                {
                    result1 = first.Number[i];
                }
                numeral = (result1 - result2);
                if (minus) numeral--;
                if (numeral<0)
                {
                    numeral += 10;
                    minus = true;
                }
                else
                {
                    minus = false;
                }
                if (numeral == 0) return new LongNumber(resultList);
                resultList.Add((byte)(numeral));
            }
            return new LongNumber(resultList);
        }
        public static LongNumber operator +(LongNumber first, int second)
        {
            return first + new LongNumber(second);
        }
        public static LongNumber operator -(LongNumber first, int second)
        {
            return first - new LongNumber(second);
        }
        public static LongNumber operator *(LongNumber first,LongNumber second)
        {
            byte brain = 0;
            LongNumber shorter = first.Length <= second.Length ? first : second;
            LongNumber longer = first.Length > second.Length ? first : second;
            List<List<long>> sums = new List<List<long>>();
            byte tmp = 0;
            List<int> finalSums= new List<int>();
            List<byte> result = new List<byte>();
            string str;
            for (int i=0;i<shorter.Length;i++)
            {
                sums.Add(new List<long>());
                for (int j=0;j<longer.Length;j++)
                {
                    sums[i].Add(shorter.Number[i] * longer.Number[j]);
                }
            }
            for (int i=0;i<longer.Length+shorter.Length;i++)
            {
                finalSums.Add(0);
            }
            for (int i = 0; i < longer.Length; i++)
            {
                for (int j = 0; j < shorter.Length; j++)
                {
                    finalSums[j+i]+=(int) sums[j][i];
                }
            }
            for (int i=0;i<finalSums.Count;i++)
            {
                tmp = (byte)((finalSums[i]+brain) / 10);
                str = (finalSums[i] + brain).ToString();
                finalSums[i] = int.Parse(str[str.Length-1]+"");
                brain = tmp;
            }
            if (finalSums[finalSums.Count-1]==0)
            {
                finalSums.RemoveAt(finalSums.Count - 1);
            }
            for (int i=0;i<finalSums.Count;i++)
            {
                result.Add((byte)finalSums[i]);
            }
            return new LongNumber(result);
        }
        public static bool operator >(LongNumber first, LongNumber second)
        {
            if (first.Length > second.Length)
            {
                return true;
            }
            else if (first.Length < second.Length)
            {
                return false;
            }
            else
            {
                for (int i = first.Number.Count - 1; i >= 0; i--)
                {
                    if (first.Number[i] != second.Number[i])
                    {
                        return first.Number[i] > second.Number[i];
                    }
                }
            }
            return false;
        }
        public void Show()
        {
            List<byte> tmp=Number;
            tmp.Reverse();
            foreach (byte elem in tmp)
            {
                Console.Write(elem);
            }
            Console.WriteLine();
        }
        public static bool operator <(LongNumber first, LongNumber second)
        {
            return second > first;
        }
        public static bool operator ==(LongNumber first, LongNumber second)
        {
            return !(first > second || second > first);
        }
        public static bool operator !=(LongNumber first, LongNumber second)
        {
            return !(first == second);
        }
        public static bool operator >=(LongNumber first, LongNumber second)
        {
            return first>second||first==second;
        }
        public static bool operator <=(LongNumber first, LongNumber second)
        {
            return first < second || first == second;
        }
    }
}
