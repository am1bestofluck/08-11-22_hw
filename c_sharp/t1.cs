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
        int mIndexLeft=iIndexLeft, mIndexRight=iIndexRight;
        int tempSwapValues;
        int median=(iIndexLeft+iIndexRight)/2;
        while (mIndexLeft<mIndexRight)
        {
            while (iArray[mIndexLeft]<iArray[median])
            {
                mIndexLeft++;
            }//ищем отклонение в меньшую сторону
            while (iArray[mIndexRight]>iArray[median])
            {
                mIndexRight++;
            }//ищем отклонение в большую сторону
        }
        if (iArray[mIndexLeft]>iArray[mIndexRight])
        {
            tempSwapValues=iArray[mIndexLeft];
            iArray[mIndexLeft]=iArray[mIndexRight];
            iArray[mIndexRight]=tempSwapValues;
        }//если значение слева больше значения справа, то меняем их местами
        if (mIndexLeft<iIndexRight)
        {
            QuickSort(iArray,mIndexLeft,iIndexRight);
        }
        if (mIndexRight>iIndexLeft)
        {
            QuickSort(iArray,mIndexRight,iIndexLeft);
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
            for (int i = 0; i < lineModified.GetLength(0); i++)
            {
                ArrayMultiDimensional.QuickSort(
                    iArray:lineModified,
                    iIndexLeft:0,
                    iIndexRight:lineModified.GetLength(0)-1);
            }
            WriteLine();
            //сортировка одномерного массива.Бiстрая.
            //на входе массив и элемент по которому сортируем(p)
            //вводим два индекса по краям массива
            //пока левый индекс меньше правого:
                //двигаем левый вправо пока не найдём значение больше p
                //двигаем правый влево пока не найдём значение меньше p 
                //меняем элементы местами через сопроводительную переменную
            //получаем два новых подмассива слева и справа от разделителя
            //дробим массивы рекурсивно пока сопроводительные массивы больше одного элемента

            }
        }
    }