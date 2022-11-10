using static System.Console;

class SpiralShell: ArrayMultiDimensional
{
    new protected const int _minEstimated=0, _maxEstimated=1;
    new int[,] _fillArray(int iRows,
            int iColumns,
            int iMin=_minEstimated,
            int iMax=_maxEstimated)
    {
        int content=0;
        int[,] output = new int[iRows,iColumns];
            // Спиральное заполнение
            // Задаем первое значение.
            int coordX=0,coordY=0;
            bool canProceed=true;
            while (canProceed){
            try
            {
                if (output[coordX+1,coordY]!=0&&
                    output[coordX,coordY+1]!=0&&
                    output[coordX-1,coordY]!=0&&
                    output[coordX,coordY-1]!=0)//если шагать уже некуда
                    {
                        canProceed=false;//то выходим из цикла
                    }
                else
                {
                    //шагаем
                    output[coordX,coordY]=content;//заполняем значение
                    content++;// меняем маркер
                    while 
                }
            }
            catch (IndexOutOfRangeException e)//перехватываем очевидное
            {
                WriteLine($"error!: {coordX} {coordY}");//для дебага
            }

            }

                //шагаем по о-икс пока не край о-икс // край о-икс это или предел о-икс, или слева и справа не ноль
                //шагаем по о-игрек пока не край о-игрек // край о-игрек это или предел о-игрек или сверху и снизу не ноль
            }
            // Задаем новое значение;
            // ДВИГАЕМСЯ!
            //если это край:
            //    //край значит или предел по иксу или что дальше по направлению хода не ноль...дальше по направлению хода означает что значения слева и справа не нулевые
            //проверяем верх-низ
            //    если это край по о-игрек:
            //    //край значит или предел по игреку или что дальше по направлению хода не ноль...дальше по направлению хода означает что значения сверху и снизу не нулевые
            //
            //если это НЕ край:
            // если слева 0, а справа цифра:
            //    прибавляем к о-икс
            //иначе если справа 0 а слева цифра:
            //    убавляем от о-икс


            // МАСТЕР-КЛАСС : ВЫВЕСТИ ЭЛЕМЕНТЫ СИНХРОННО^^ 
            // кто сказал yagni ._.
        return output;
    }
     public SpiralShell(int iRows, int iColumns): base(iRows=iRows,iColumns=iColumns)
    {
        this._content_2d=_fillArray(
            iRows:this.Rows,
            iColumns:this.Columns);
            
    }

}