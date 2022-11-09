// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using static System.Console;
main();
void main()
{
    string[] external_todo= File.ReadLines($"../README.MD").ToArray();//получаем массив строк, строки считаются с нуля
    WriteLine(external_todo[5]);//t1
    Array.DoubleDimensional.ArrayMultiDimensional t1 = new Array.DoubleDimensional.ArrayMultiDimensional(rows:5,columns:6);
    t1.PrintArray();
    WriteLine();
    WriteLine(external_todo[16]);//t2
    WriteLine();
    WriteLine(external_todo[30]);//t3
    WriteLine();
    WriteLine(external_todo[40]);//t4
    WriteLine();
    WriteLine(external_todo[48]);//t5
    WriteLine();
    //будем считать что это применение dry

}
