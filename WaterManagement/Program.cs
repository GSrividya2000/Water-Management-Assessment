using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WaterManagement
{
    public class Program
    {
        public string Bill(int appartmentType,int corporationWaterRatio, int borewellRatio, int totalGuests ) 
        {
            int tankerWater = totalGuests * 10 * 30;
            int appartmentWater=0;
            double totalBill;
            int tankerBill = 0;

            if (appartmentType == 2) 
            {
                appartmentWater = 3 * 10 * 30;
            }

            if(appartmentType == 3) 
            {
                appartmentWater = 5 * 10 * 30;
            }

            double corporationWaterBill = (appartmentWater / (corporationWaterRatio + borewellRatio)) * corporationWaterRatio *1;
            double borewellWaterBill = (appartmentWater / (corporationWaterRatio + borewellRatio)) * borewellRatio * 1.5;

            if (tankerWater <= 500) 
            {
                tankerBill = tankerWater * 2;
            }
            
            else if (tankerWater>=501 && tankerWater <= 1500) 
            {
                tankerBill = 500*2 + (tankerWater -500)*3;
            }

            else if (tankerWater>= 1501 && tankerWater <= 3000) 
            {
                tankerBill = 500*2+ 1500*3 + (tankerWater - 1500) * 5;

            }

            else if ( tankerWater >= 3001) 
            {
                tankerBill = 500*2+ 1500*3+ 3000*5 + (tankerWater - 3000) * 8;
            }

            totalBill = Math.Round(corporationWaterBill + borewellWaterBill + tankerBill);

            return $"{appartmentWater+tankerWater} {totalBill}";



        }

        public void startApplication(string input) 
        {
            int totalGuests = 0;
            int appartmentType=0;
            int corporationWaterRatio=0;
            int borewellWaterRatio=0;
            string[] strings = input.Split('\n');
            for (int i = 0; i < strings.Length; i++) 
            {
                string[] userInput= strings[i].Split(' ');
                if (userInput[0].ToUpper().Contains("ALLOT_WATER")) 
                {
                    appartmentType = Convert.ToInt32(userInput[1]);
                    string[] WaterRatio = userInput[2].Split(':');
                    corporationWaterRatio = Convert.ToInt32(WaterRatio[0]);
                    borewellWaterRatio = Convert.ToInt32(WaterRatio[1]);
                }

                else if (userInput[0].ToUpper().Contains("ADD_GUESTS")) 
                {
                    int addGuests= Convert.ToInt32(userInput[1]);
                    totalGuests= totalGuests + addGuests;
                }

                else if (userInput[0].ToUpper().Contains("BILL")) 
                {
                    Console.WriteLine(Bill(appartmentType, corporationWaterRatio, borewellWaterRatio, totalGuests));
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter the File Path:");
            string path;
            path = Console.ReadLine();

            if (path.StartsWith("\"")) 
            {
                path = path.Remove(0, 1);

            }
            if (path.EndsWith("\"")) 
            {
                path = path.Remove(path.Length - 1, 1);

            }

            path = @"" + path;

            StreamReader sr = new StreamReader(path);
            string input = sr.ReadToEnd();

            Program program = new Program();
            program.startApplication(input);
            Console.ReadLine();

        }
    }
}
