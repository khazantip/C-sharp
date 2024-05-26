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
        //������ ����������� (������ � ������)
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

                //������� ����� �������
                var column = new List<int>();

                var prevPixel = 1; //���������� �������
                var blackCounter = 0; //������� ������ ��������

                //��������� �� ��������
                for (int y = 0; y < Size; y++)
                {
                    //����� ������� x � y
                    var pixel = image.GetPixel(x, y);
                    //���������, ��� ������� ������
                    if (pixel.R == 0)
                    {
                        blackCounter++;
                        prevPixel = 0;
                    }
                    // ���������, ��� ������� �����, � ���������� ������
                    else if (pixel.R != 0 && prevPixel == 0)
                    {
                        column.Add(blackCounter);
                        blackCounter = 0;
                        prevPixel = 1;
                    }

                    // ���������, ��� � �������� �� ����� � �� � ����� �������
                    if (blackCounter != 0 && y == Size - 1)
                    {
                        column.Add(blackCounter);
                    }
                }
                //��������� ������� � ������� �������
                Top.Add(column);
            }

            // ��������� �� �������
            for (int y = 0; y < Size; y++)
            {
                //������� ����� ������                
                var row = new List<int>();

                var prevPixelL = 1;
                var blackCounterL = 0;

                for (int x = 0; x < Size; x++)
                {
                    //����� ������� x � y
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
                    // ���������, ��� � �������� �� ����� � �� � ����� ������                   
                    if (blackCounterL != 0 && x == Size - 1)
                    {
                        row.Add(blackCounterL);
                    }
                }
                //��������� ������ � ����� �������
                Left.Add(row);
            }
        }



    }
}