using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
    	public class RandObject:IComparable<RandObject>
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
            public int CompareTo(RandObject o)
            {
            	return this.Date.Year.CompareTo(o.Date.Year);
            }
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
           //Операции с сгенерированными объектами
            var select1= from m in mas where m.Phone==true select m;
            var sorted1 = from m in select1 orderby m.Number select m;
            foreach(var t in select1) 
            	Console.Write(t.Number+" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            foreach(var t in sorted1) 
            	Console.Write(t.Number+" ");
            var objgroups= from m in mas group m by m.Date.Year;
            Console.WriteLine("\n"+select1.All(u=>u.Another>4));
            Console.WriteLine(select1.Any(u=>u.Another>4));
            Console.WriteLine("Сумма (неизвестно чего но пусть будет)"+select1.Sum(n=>n.Number));
            Console.WriteLine("Минималный год в списке "+select1.Min().Date.Year);
            Console.WriteLine("Максимальный год в списке "+select1.Max().Date.Year);
            Console.ReadKey(true);
            
        }
    }
}
