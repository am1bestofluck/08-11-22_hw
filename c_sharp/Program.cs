// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using static System.Console;
Main();
void Break()
{
    Console.BackgroundColor = ConsoleColor.Blue;
    WriteLine("Enter для продолжения");
    Console.BackgroundColor = ConsoleColor.Black;
    ReadLine();
    Console.Clear();
}
void Main()
{   
    int[] argsT1 =new int[]{3,15};
    int[] argsT4= new int[]{3,4,5};
    
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Magenta;
    WriteLine("Аргументы функций не вводятся с консоли, но собраны в одном месте : Program.cs [12:13]");
    Console.ForegroundColor = ConsoleColor.White;
    string[] external_todo= File.ReadLines($"../README.MD").ToArray();//получаем массив строк, строки считаются с нуля
    WriteLine(external_todo[5]);//t1
    ArrayMultiDimensional t1 = new ArrayMultiDimensional(
        rows:argsT1[0],columns:argsT1[1]);
    WriteLine("Первоначальный массив:");
    t1.PrintArray();
    WriteLine("После сортировки:");
    ArrayMultiDimensional.SortLines(t1.Get());
    t1.PrintArray();
    string longRead="\nПолучилось разобраться, ура-ура. Но с другой стороны, три строчки ниже дадут абсолютно такой же результат."+
    "\nList<int> tmp=lineModified.ToList();"+
    "\ntmp.Sort();\n"+
    "lineModified=tmp.ToArray();\n";
    WriteLine(longRead);
    Break();
    WriteLine(external_todo[16]);//t2
    Break();
    WriteLine(external_todo[30]);//t3
    Break();
    WriteLine(external_todo[40]);//t4
    ArrayMultiDimensional t4= new ArrayMultiDimensional(rows:argsT4[0],columns:argsT4[1],layers:argsT4[2]);
    t4.PrintArray();
    Break();
    WriteLine(external_todo[48]);//t5
    SpiralShell t5 = new SpiralShell();
    t5.PrintArray();
    string shoutOut="Cоздал целый класс чтобы по итогу насовать"+
    "\nв конструктор магических чисел. Это фиаско =\\ :))";
    WriteLine(shoutOut);

}
