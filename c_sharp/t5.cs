using static System.Console;

class SpiralShell: ArrayMultiDimensional
{
    new protected const int _minEstimated=0, _maxEstimated=1;
    new int[,] _fillArray(int iRows,
            int iColumns,
            int iMin=_minEstimated,
            int iMax=_maxEstimated)
    {

        int[,] output= new int[iRows,iColumns];//1 cтрока
        // int floor, int 
        int content=0;
        for (int coordY = 0; coordY < iColumns; coordY++)
        {
            output[0,coordY]=content;
            content++;
        }
        for (int coordX = 1; coordX < iRows; coordX++)//последний столбец
        {
            output[coordX,iColumns-1]=content;
            content++;
        }
        for (int coordY = iColumns-2; coordY >= 0; coordY--)//последняя строка
        {
            output[iRows-1,coordY]=content;
            content++;
        }
        for (int coordX = iRows-1; coordX < 1; coordX--)//первый столбец
        {
            output[coordX,0]=content;
            content++;
        }
        for (int coordY = 0; coordY < iColumns-1; coordY++)//вторая строка
        {
            output[1,coordY]=content;
            content++;
        }
        for (int coordX = iRows-2; coordX < iRows-1; coordX++)//третий столбец
        {
            output[coordX,2]=content;
            content++;
        }
        for (int coordY = iColumns-1; coordY < iColumns-2; coordY--)//третья строка
        {
            output[coordY,2]=content;
            content++;
        }

        return output;
    }
     public SpiralShell(int iRows, int iColumns): base(iRows=iRows,iColumns=iColumns)
    {
        this._content_2d=_fillArray(
            iRows:this.Rows,
            iColumns:this.Columns);
            
    }

}