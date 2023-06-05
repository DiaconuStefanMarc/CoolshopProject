using System;
using System.Collections;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        // controllo passaggio corretto argomenti
        if (args.Length < 3)
        {
            Console.WriteLine("launch the script with the requested arguments: file csv, index column, search key");
            Environment.Exit(0);
        }

        string file = args[0];
        int column = int.Parse(args[1]);
        string key = args[2];
        string result = null;
        List<Person> records = new List<Person>();


        try
        {
            //letttura file
            using (StreamReader reader = new StreamReader(file))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] cells = line.Split(',');
                    Person persona = new Person(cells[0], cells[1], cells[2], cells[3]);
                    records.Add(persona);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("file didn't open correctly");
        }

        //ricerca informazioni richieste
        foreach (Person target in records) {
            if (target != null)
            {
                if (target.getKey(column) == key)
                {
                    result = target.ToString();
                }
            }
        }
   
        //output dello script
        if (result != null)
        {
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("file doesn't contain the requested information");
        }
    }
}
    //classe usata per gestire il contenuto del file
    class Person
    {
        string number;
        string last;
        string first;
        string date;

        public Person(string number, string last, string first, string date)
        {
            this.number = number;
            this.last = last;
            this.first = first;
            this.date = date;
        }

        public string getKey(int column)
        {
            switch (column)
            {
                case 0:
                    return number;
                case 1:
                    return last;
                case 2:
                    return first; 
                case 3:
                return date;
            default:
                return null;
            }
        }
        public override string ToString()
        {
            return (number + "," + last + "," + first + "," + date);
        }
    }
  