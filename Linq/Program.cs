using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Linq
{
    class Program
    {
    	[Serializable]
    	public class RandObject
        {
    		public int Number; 
            public int Another;
            public bool  Phone;
            public DateTime Date;
            public string Name;
            
            public RandObject (int number,int another,bool phone,string name, DateTime date)
            {
            	Number=number;
            	Another=another;
            	Phone=phone;
            	Name=name;
            	Date=date;
            	
            }   
        }
    	public static void  Output (RandObject[]mas)
    	{
    		foreach(RandObject r in mas)
              	{
              		Console.Write(r.Name+" ");
              	}
            Console.WriteLine("");
            Console.WriteLine("");
    	}

        static void Main(string[] args)
        {
        	//Генерация 100 объектов
            RandObject[] mas = new RandObject[100];
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
            	int day=rand.Next(1,28),month=rand.Next(1,12),year=rand.Next(2000,2010);
            	DateTime date= new DateTime(year,month,day);
            	char ch=(char) rand.Next(0,255);
            	int p= rand.Next(1,3);
            	bool phone;
            	if(p==1)phone=true;
            	else phone=false;
                int number=rand.Next(0,10);
                int another=rand.Next(0,10);
                mas[i]= new RandObject(number,another,phone,Convert.ToString(ch),date);     
            }
            string path = @"C:\Users\Danil\Desktop\t.txt";
           //Операции с сгенерированными объектами
            BinaryFormatter formarter= new BinaryFormatter();
            
            using (FileStream fs = new FileStream(path,FileMode.OpenOrCreate))
            {
            	formarter.Serialize(fs,mas);
            }
            Output(mas);
            
              using (FileStream fs = new FileStream(path,FileMode.OpenOrCreate))
            {
              	RandObject[] desmas=(RandObject[])formarter.Deserialize(fs);
              	Output(desmas);
            }
            
            Console.ReadKey(true);
        }
    }
}
