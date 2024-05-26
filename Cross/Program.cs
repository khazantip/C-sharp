using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Cross
{
    public class GameImage
    {
        //размер изображения (высота и ширина)
        public int Size { get; set; }

        public List<List<int>> Left { get; set; }
        public List<List<int>> Top { get; set; }

        public GameImage()
        {
            Left = new List<List<int>>();
            Top = new List<List<int>>();
        }

        public GameImage(Bitmap image)
        {
            Size = image.Height;

            Left = new List<List<int>>();
            Top = new List<List<int>>();


            for (int x = 0; x < Size; x++)
            {
                //Left.Add(new List<int>());
                //Top.Add(new List<int>());

                //создаем новый столбец
                var column = new List<int>();

                var prevPixel = 1; //предыдущий пиксель
                var blackCounter = 0; //счетчик черных пикселей

                //Пробегаем по столбцам
                for (int y = 0; y < Size; y++)
                {
                    //берем пиксель x и y
                    var pixel = image.GetPixel(x, y);
                    //проверяем, что пиксель черный
                    if (pixel.R == 0)
                    {
                        blackCounter++;
                        prevPixel = 0;
                    }
                    // проверяем, что пиксель белый, а предыдущий черный
                    else if (pixel.R != 0 && prevPixel == 0)
                    {
                        column.Add(blackCounter);
                        blackCounter = 0;
                        prevPixel = 1;
                    }

                    // проверяем, что в счетчике не пусто и мы в конце столбца
                    if (blackCounter != 0 && y == Size - 1)
                    {
                        column.Add(blackCounter);
                    }
                }
                //добавляем столбец в верхнюю область
                Top.Add(column);
            }

            // Пробегаем по строкам
            for (int y = 0; y < Size; y++)
            {
                //создаем новый строку                
                var row = new List<int>();

                var prevPixelL = 1;
                var blackCounterL = 0;

                for (int x = 0; x < Size; x++)
                {
                    //берем пиксель x и y
                    var pixel = image.GetPixel(x, y);

                    if (pixel.R == 0)
                    {
                        blackCounterL++;
                        prevPixelL = 0;
                    }
                    else if (pixel.R != 0 && prevPixelL == 0)
                    {
                        row.Add(blackCounterL);
                        blackCounterL = 0;
                        prevPixelL = 1;
                    }
                    // проверяем, что в счетчике не пусто и мы в конце строки                   
                    if (blackCounterL != 0 && x == Size - 1)
                    {
                        row.Add(blackCounterL);
                    }
                }
                //добавляем строку в левую область
                Left.Add(row);
            }
        }



    }
}