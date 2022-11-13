using static System.Console;
//DRY KISS YAGNI
//проектирование выше соглашений
//но когда когда пишешь, фокусируйся на форме _соглашениях_, чтобы читая фокусироваться на сути
//DO use PascalCasing, and separate namespace components with periods :
// https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-namespaces
class ArrayMultiDimensional
{
    protected const int _minEstimated = 0, _maxEstimated = 100;
    //underscore for private fields
    //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/fields
    //Pascal case for Constants
    //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constants?redirectedfrom=MSDN
    //camel case for privates XD
    //https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions

    public int Columns, Rows;
    public int? Layers;
    protected int?[,,] _content_3d;
    protected int[,] _content_2d;
    public ArrayMultiDimensional(int rows, int columns, int? layers = null)
    // camel case for method Parameters
    {
        this.Columns = columns;
        this.Rows = rows;
        this.Layers = layers;
        this._content_3d = _fillArray_3d(
            iRows: this.Rows,
            iColumns: this.Columns,
            iLayer: this.Layers
            )!;
        this._content_2d = _fillArray(
            iRows: this.Rows,
            iColumns: this.Columns);

    }
    protected int[,] _fillArray(
        int iRows, int iColumns,
        int iMin = _minEstimated,
        int iMax = _maxEstimated)
    {
        //заполняем двумерный массив, рутина
        int[,] output = new int[iRows, iColumns];
        Random content = new Random();
        for (int row = 0; row < iRows; row++)
        {
            for (int column = 0; column < iColumns; column++)
            {
                output[row, column] = content.Next(iMin,iMax);
            }
        }
        return output;
    }
    int?[,,] _fillArray_3d(int iRows, int iColumns, int? iLayer)
    {
        if (!iLayer.HasValue) return null!;
        else
        {
            int?[,,] output = new int?[iRows, iColumns, iLayer.Value];
            int uniqueValue = 10;
            for (int layer = 0; layer < iLayer.Value; layer++)
            {
                for (int row = 0; row < iRows; row++)
                {
                    for (int column = 0; column < iColumns; column++)
                    {
                        output[row, column, layer] = uniqueValue;
                        uniqueValue++;
                    }
                }
            }
            return output;
        }
    }

    public void PrintArray()
    {
        if (this._content_3d != null)
        {
            for (int layer = 0; layer < this._content_3d.GetLength(2); layer++)
            {
                for (int row = 0; row < this._content_3d.GetLength(0); row++)
                {
                    for (int column = 0; column < this._content_3d.GetLength(1); column++)
                    {
                        Write($"[{row} {column} {layer}]: {this._content_3d[row, column, layer]} ");
                    }
                    WriteLine();
                }
                WriteLine();
            }
        }
        else
        {
            for (int row = 0; row < this._content_2d.GetLength(0); row++)
            {
                for (int column = 0; column < this._content_2d.GetLength(1); column++)
                {
                    Write($"{this._content_2d[row, column]} ");
                }
                WriteLine();
            }
        }
    }
    public int[,] Get()
    {
        return this._content_2d;
    }
    public static void QuickSort(int [] iArray,int iIndexLeft,int iIndexRight)
    {
        //source: https://www.youtube.com/watch?v=DmFXdwy_mH0
        //source: https://code-maze.com/csharp-quicksort-algorithm/
     //задаём сопроводительные величины: шаги от сторон к центру и тестовый случай
     int mIndexLeft=iIndexLeft,mIndexRight=iIndexRight,
     testCase=iArray[mIndexLeft];//тестовый случай может быть любой, значит и первый тоже
     int temp;//сопроводительная, для смены мест значений
     //ищём что менять местами, пока шаги не встретились
     while (mIndexLeft<=mIndexRight)
     {
        while (testCase<iArray[mIndexRight])//шагаем влево, если значение меньше теста то Мы его будем переносить
        {
            mIndexRight--;//пропускаем те значения справа от теста которые и так больше теста
        }
        while (testCase>iArray[mIndexLeft])//шагаем вправо, если значение больше теста то Мы его будем переносить
        {
            mIndexLeft++;//пропускаем те значения слева от теста которые и так меньше теста
        }
        if (iArray[mIndexLeft]>=iArray[mIndexRight])//меняем местами, шагаем по индесу чтобы выйти из while
        {
            temp=iArray[mIndexLeft];
            iArray[mIndexLeft]=iArray[mIndexRight];
            iArray[mIndexRight]=temp;
            mIndexLeft++;//шаг чтобы выйти из while
            mIndexRight--;   
        //рекурсия.... Сначала создать условие для выхода
        if (mIndexLeft<iIndexRight)//шагаем пока не дошли слева на право
        {
            QuickSort(iArray,mIndexLeft,iIndexRight);
        }
        if (mIndexRight>iIndexLeft)//шагаем пока не дошли справа на лево
        {
            QuickSort(iArray,iIndexLeft,mIndexRight);
        }
        }
     }   
    }
    public static void SortLines(int[,] twoDimensionalArray)
    {
        int[] lineModified;
        for (int row = 0; row < twoDimensionalArray.GetLength(0); row++)
        {
            lineModified = new int[twoDimensionalArray.GetLength(1)];
            for (int column = 0; column < twoDimensionalArray.GetLength(1); column++)
            {
                lineModified[column] = twoDimensionalArray[row, column];
            
            }
            ArrayMultiDimensional.QuickSort(
                    iArray:lineModified,
                    iIndexLeft:0,
                    iIndexRight:lineModified.GetLength(0)-1);
            for (int i = 0; i < lineModified.GetLength(0); i++)
            {
                twoDimensionalArray[row,i]=lineModified[i];
            }
        }
            WriteLine();
        }
    // public 
    }