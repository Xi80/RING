using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace RING
{
    class Program
    {
        static string SelectComPort()
        {
            bool flag = true;
            int index,tmp;
            string[] portList;
            string selected;

            try
            {
                Console.WriteLine("");
                portList = SerialPort.GetPortNames();
                for (index = 0; index < portList.Length; index++)
                {
                    Console.WriteLine("{0}:{1}",index,portList[index]);
                }

                do
                {
                    Console.Write("リスニングするCOMポートを選択>");
                    selected = Console.ReadLine();
                    if (int.TryParse(selected, out tmp) && tmp < portList.Length)
                    {
                        flag = false;
                    }
                    else
                    {
                        //範囲外，または存在しない
                        continue;
                    }
                } while (flag);

                return portList[tmp];
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        static void Main(string[] args)
        {
            SelectComPort();
            Console.WriteLine("Hello World!");
        }
    }
}
