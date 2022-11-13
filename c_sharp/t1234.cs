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

    public void PrintArray(int?[,] externalMatrix=null!)
    {
        if (externalMatrix==null)//этот иф пришлось делать чтобы не писать отдельную процедуру печати для результата умножения матриц
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
    else
    {
        for (int row = 0; row < externalMatrix.GetLength(0); row++)
            {
                for (int column = 0; column < externalMatrix.GetLength(1); column++)
                {
                    Write($"{externalMatrix[row, column]} ");
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
        //inspiration:5%: https://www.youtube.com/watch?v=DmFXdwy_mH0
        //inspiration:85%: https://code-maze.com/csharp-quicksort-algorithm/
     //задаём сопроводительные величины: шаги от сторон к центру и тестовый случай
     int mIndexLeft=iIndexLeft,mIndexRight=iIndexRight,
     testCase=iArray[mIndexLeft];//тестовый случай может быть любой, значит и первый тоже
     int temp;//сопроводительная, для смены мест значений
     //ищём что менять местами, пока шаги не встретились
     while (mIndexLeft<=mIndexRight)
     {
        while (testCase>iArray[mIndexRight])//шагаем влево, если значение больше теста то Мы его будем переносить
        {
            mIndexRight--;//пропускаем те значения справа от теста которые и так меньше теста
        }
        while (testCase<iArray[mIndexLeft])//шагаем вправо, если значение меньше теста то Мы его будем переносить
        {
            mIndexLeft++;//пропускаем те значения слева от теста которые и так больше теста
        }
        if (iArray[mIndexLeft]<=iArray[mIndexRight])//меняем местами, шагаем по индесу чтобы выйти из while
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
        int[] lineReArranged;
        for (int row = 0; row < twoDimensionalArray.GetLength(0); row++)
        {
            lineReArranged = new int[twoDimensionalArray.GetLength(1)];
            for (int column = 0; column < twoDimensionalArray.GetLength(1); column++)
            {
                lineReArranged[column] = twoDimensionalArray[row, column];
            
            }
            ArrayMultiDimensional.QuickSort(
                    iArray:lineReArranged,
                    iIndexLeft:0,
                    iIndexRight:lineReArranged.GetLength(0)-1);
            for (int i = 0; i < lineReArranged.GetLength(0); i++)
            {
                twoDimensionalArray[row,i]=lineReArranged[i];
            }
        }
            WriteLine();
        }
    public void ShowMinimalRow(int[,] twoDimensionalArray)
    {
        int[] lineObserved;
        int temp_min;
        Dictionary<int,Array> output = new Dictionary<int, Array>();
        for (int row = 0; row < twoDimensionalArray.GetLength(0); row++)
        {
            temp_min=0;
            lineObserved = new int[twoDimensionalArray.GetLength(1)];
            for (int column = 0; column < twoDimensionalArray.GetLength(1); column++)
            {
                lineObserved[column]= twoDimensionalArray[row,column];
                temp_min+=twoDimensionalArray[row,column];
            }
            output.Add(temp_min,lineObserved);
            WriteLine($"{temp_min}: {output[temp_min].GetValue(0)}..{output[temp_min].GetValue(output[temp_min].Length-1)}");
        }
        WriteLine($"Строка с минимальной({output.Keys.Min()}) суммой элементов: №{output.Keys.ToList().IndexOf(output.Keys.Min())+1}");
        // foreach (var item in output[output.Keys.Min()])
        // {
        //     Write($"{item} ");
        // }
        // WriteLine();// задача выводить массив не поставлена
    }

    public static int?[,] multiplyMatrices( int[,] firstMatrix, int[,] secondMatrix)
    {
        if (firstMatrix.GetLength(1)!=secondMatrix.GetLength(0))
        {
            WriteLine("Размерность матриц не совпадает.");
            return null!;
        }
        //c богом...
        //размерность матрицы на выходе: число колонок из матрицы б, число строк из матрицы а.
        int?[,] output= new int?[firstMatrix.GetLength(0),secondMatrix.GetLength(1)];
        int[] tempRow, tempColumn;
        //каждый элемент расчитывается 
        for (int row = 0; row < output.GetLength(0); row++)
        {
            tempRow= new int[firstMatrix.GetLength(1)];
            tempColumn= new int[secondMatrix.GetLength(0)];
            for (int column = 0; column < output.GetLength(1); column++)
            {
                for (int collectRow = 0; collectRow < firstMatrix.GetLength(1); collectRow++)
                {
                    tempRow[collectRow]=firstMatrix[row,collectRow];
                }
                for (int collectColumn = 0; collectColumn < secondMatrix.GetLength(0); collectColumn++)
                {
                    tempColumn[collectColumn]=secondMatrix[collectColumn,column];
                }

                output[row,column]=multiplyTwoArrays(tempRow,tempColumn);//умножаем поэлементно строку на столбец
            }
            
            //сначала все строки на первый столбец потом все строки на второй столбец и так далее... рекурсия?? 
        }
        return output;
    }
    public static int multiplyTwoArrays(int[] iRow,int[] iColumn, int iIndex=0)
    {
        if (iIndex==iRow.Length) return 0;
        else return iRow[iIndex]*iColumn[iIndex]+multiplyTwoArrays(iRow,iColumn,++iIndex);//^^
    }
}