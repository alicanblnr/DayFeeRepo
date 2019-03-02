using System;
using System.Collections.Generic;
using System.Text;
using LibraryBusiness;
using System.Configuration;
using System.Xml;

namespace LibraryApplication
{
    public class Program{
        static void Main(string[] args){
            if (args == null || args.Length != 3) {
                PrintUsage();
                return;
            }
            String fee = "";
            try{
                var result = PrintUsage();
                fee = new PenaltyFeeCalculator().Calculate(Convert.ToDateTime(result[1]), Convert.ToDateTime(result[2]), result[0]);
            }
            catch (Exception e) {
                PrintErrorMessage(e);
            }
            PrintResultMessage(fee);
           
        }
        private static string[] PrintUsage(){
            string[] result = null;
            Console.WriteLine("Please provide these parameters (without brackets) : <CountryCode>, <DateStart>, <DateEnd>");
            var data = Console.ReadLine();

            if(!data.Contains(",") && data == null)
            {
                PrintErrorMessage(new Exception());
            }
            else
            {
                var dataArr = data.Split(',');
                if(dataArr.Length < 2) PrintErrorMessage(new Exception());

                for (int i = 1; i < dataArr.Length; i++)
                {
                    var date = dataArr[i];

                    Convert.ToDateTime(date);
                }
                result = dataArr;
            }
            return result;
        }
        private static void PrintAnyKeyMessage(){
            Console.WriteLine("Press any key to continue");
        }
        private static void PrintResultMessage(string fee){
            Console.WriteLine("Penalty Fee is {0}", fee);
            PrintAnyKeyMessage();
            Console.ReadKey();
        }
        private static void PrintErrorMessage(Exception e) {
            Console.WriteLine("Exception : " + e.Message);
            Console.WriteLine("Stacktrace : ");
            Console.WriteLine(e.StackTrace);
            PrintAnyKeyMessage();
            Console.ReadKey();
        }
    }

}
