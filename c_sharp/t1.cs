using static System.Console;
//DRY KISS YAGNI
//проектирование выше соглашений
//но когда когда пишешь, фокусируйся на форме _соглашениях_, чтобы читая фокусироваться на сути
namespace Array.DoubleDimensional//а это точно нужно?
//DO use PascalCasing, and separate namespace components with periods :
// https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-namespaces
{
    class ArrayMultiDimensional
    {
        private const int _minEstimated=0, _maxEstimated=100;
        //underscore for private fields
        //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/fields
        //Pascal case for Constants
        //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constants?redirectedfrom=MSDN
        //camel case for privates XD
        //https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions

        public int Columns,Rows;
        public int? Layers;
        int?[,,] _content_3d;
        int[,] _content_2d;
        public ArrayMultiDimensional(int rows,int columns, int? layers=null)
        // camel case for method Parameters
        {
            this.Columns=columns;
            this.Rows=rows;
            this.Layers=layers;
            this._content_3d=_fillArray_3d(
                rows_i:this.Rows,
                columns_i:this.Columns,
                layer_i:this.Layers
                )!;
            this._content_2d=_fillArray(
                rows_i:this.Rows,
                columns_i:this.Columns);
            
        }
        int [,] _fillArray(int rows_i, int columns_i)
        {
            //заполняем двумерный массив, рутина
            int[,] output=new int[rows_i,columns_i];
            return output;
        }
        int?[,,] _fillArray_3d(int rows_i, int columns_i, int? layer_i)
        {
            if (!layer_i.HasValue) return null!;
            else
            {
            int?[,,] output= new int? [rows_i,columns_i,layer_i.Value];
            int uniqueValue=new int();
            for (int layer = 0; layer < layer_i.Value; layer++)
            {
                for (int row = 0; row < rows_i; row++)
                {
                    for (int column = 0; column < columns_i; column++)
                    {
                        output[row,column,layer]=uniqueValue;
                        uniqueValue++;
                    }
                }
            }
            return output;
            }
        }
        
        public void PrintArray()
        {
            
        }
    }
}

namespace Array.TriDimensional
{

}