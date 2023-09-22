using System.Collections.Concurrent;

string[] list = File.ReadAllLines("../../../Husdjur.csv");

Dictionary<string, int> animal = new Dictionary<string, int>();

List<int> petAge = new List<int>(); // Skapar listan 'petAge'
List<string> names = new List<string>(); // Namnen

foreach (string line in list)
{
    string[] split = line.Split(",");

    if (int.TryParse(split[1], out int age))
    {
        string petName = split[0].ToLower();
        animal.Add(petName, age);   // Lägger till 'petName' och 'age' i dictionary 'animal'
        petAge.Add(age);    // Lägger till 'age' i listan 'petAge'
        names.Add(petName);
    }
    else
    {
        Console.WriteLine("Something went wrong");
    }
}

//petAge.Sort(); // Funkar att sortera här, men hur göra med en 'for'-loop?


for (int i = 0; i < petAge.ToArray().Length; i++)
{
    for (int j = 0; j < petAge.ToArray().Length - 1; j++)
    {

        int first = petAge[j];
        int second = petAge[j + 1];

        string name1 = names[j];
        string name2 = names[j + 1];

        if (first > second)
        {
            petAge[j] = second;     
            petAge[j + 1] = first; 
            
            names[j] = name2;
            names[j + 1] = name1;

        }
    }
}

List<string> results = new List<string>();


for (int i =  0 ; i < petAge.Count ; i++)      // Börja räkna bakifrån
{
    results.Add(names[i] + "," + petAge[i]);
}

File.WriteAllLines("../../../sorteradeDjur.txt" , results); // Använda hur????


/*


int temp = 0;


for (int i = 0; i < petAge.ToArray().Length; i++)
{

    for (int j = 0; j < petAge.ToArray().Length - 1; j++)
    {
        int first = petAge[i];
        int second = petAge[i + 1];
        if (first > second)
        {

            first = second;
            second = first;
            

        }


    }
    
}

Console.WriteLine(petAge);


*/


/*

Console.WriteLine();
Console.WriteLine("Choose a name: ");



bool isRunning = true;

string? input = Console.ReadLine().ToLower();

while (isRunning)
{
    if (animal.ContainsKey(input))
    {
        Console.WriteLine("Birthyear of " + input + " is " + (2023 - animal[input]));
        isRunning = false;
    }
    else
    {
        Console.WriteLine("Name dosent exist, try again");
        isRunning = true;
        input = Console.ReadLine().ToLower();

    }
}




//Console.WriteLine(split[0]);


*/