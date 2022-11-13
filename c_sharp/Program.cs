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
    int[] argsT12 =new int[]{3,15};
    Dictionary<string,int> argsT3= new Dictionary<string, int>
    {{"colsArowsB",3},
    {"rowsA",5},
    {"colsB",6}};
    int[] argsT4= new int[]{3,4,5};
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Magenta;
    WriteLine("Аргументы функций не вводятся с консоли, но собраны в одном месте : Program.cs [12:20]");
    Console.ForegroundColor = ConsoleColor.White;
    string[] external_todo= File.ReadLines($"../README.MD").ToArray();//получаем массив строк, строки считаются с нуля
    WriteLine(external_todo[5]);//t1
    ArrayMultiDimensional t1 = new ArrayMultiDimensional(
        rows:argsT12[0],columns:argsT12[1]);
    WriteLine("Первоначальный массив:");
    t1.PrintArray();
    WriteLine("После сортировки:");
    ArrayMultiDimensional.SortLines(t1.Get());
    t1.PrintArray();
    Break();
    WriteLine(external_todo[16]);//t2
    t1.PrintArray();
    t1.ShowMinimalRow(t1.Get());
    Break();
    WriteLine(external_todo[30]);//t3
    ArrayMultiDimensional t31 = new ArrayMultiDimensional(rows:argsT3["rowsA"],columns:argsT3["colsArowsB"]);
    System.Diagnostics.Process.Start("explorer", "https://ru.onlinemschool.com/math/assistance/matrix/multiply/");//ну а чо :). Матрицы решать каждый может, а Ты найди в интернете кота :)).
    //ps: надеюсь эта строчка не вылетит.
    WriteLine("Первая матрица:");
    t31.PrintArray();
    ArrayMultiDimensional t32 = new ArrayMultiDimensional(rows:argsT3["colsArowsB"],columns:argsT3["colsB"]);
    WriteLine("Вторая матрица:");
    t32.PrintArray();
    int?[,] result= ArrayMultiDimensional.multiplyMatrices(t31.Get(),t32.Get());
    WriteLine("Вывод:");
    t31.PrintArray(externalMatrix:result);
    Break();
    WriteLine(external_todo[40]);//t4
    ArrayMultiDimensional t4= new ArrayMultiDimensional(rows:argsT4[0],columns:argsT4[1],layers:argsT4[2]);
    t4.PrintArray();
    Break();
    WriteLine(external_todo[48]);//t5
    SpiralShell t5 = new SpiralShell();
    t5.PrintArray();
    string shoutOut="Cоздал целый класс чтобы по итогу насовать"+
    "\nв конструктор магических чисел. Мдаа :')";
    WriteLine(shoutOut);

}
