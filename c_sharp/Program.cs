// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using static System.Console;
Main();
void Break()
{
    // WriteLine("Enter для продолжения");
    // ReadLine();
}
void Main()
{
    int[] argsT1 =new int[]{3,10};
    int[] argsT4= new int[]{3,4,5};

    // Console.Clear();
    string[] external_todo= File.ReadLines($"../README.MD").ToArray();//получаем массив строк, строки считаются с нуля
    WriteLine(external_todo[5]);//t1
    ArrayMultiDimensional t1 = new ArrayMultiDimensional(
        rows:argsT1[0],columns:argsT1[1]);
    WriteLine("Первоначальный массив:");
    t1.PrintArray();
    WriteLine("После сортировки:");
    ArrayMultiDimensional.SortLines(t1.Get());
    t1.PrintArray();
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
    SpiralShell t5 = new SpiralShell();//создал целый класс чтобы по итогу насовать
    // в конструктор магических чисел. Это фиаско =\ :))
    t5.PrintArray();

}
