// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using static System.Console;
main();
void main()
{
    Console.Clear();
    string[] external_todo= File.ReadLines($"../README.MD").ToArray();//получаем массив строк, строки считаются с нуля
    WriteLine(external_todo[5]);//t1
    ArrayMultiDimensional t1 = new ArrayMultiDimensional(rows:3,columns:10);
    WriteLine("Первоначальный массив:");
    t1.PrintArray();
    WriteLine();
    WriteLine("После сортировки:");
    t1.PrintArray();

    WriteLine();
    WriteLine(external_todo[16]);//t2
    WriteLine();
    WriteLine(external_todo[30]);//t3
    WriteLine();
    WriteLine(external_todo[40]);//t4
    ArrayMultiDimensional t4= new ArrayMultiDimensional(rows:3,columns:4,layers:5);
    t4.PrintArray();
    WriteLine();
    WriteLine(external_todo[48]);//t5
    WriteLine();
    //будем считать что это применение dry

}
