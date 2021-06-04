using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    /*В свойстве Location у каждой ячейки Х и У стоят наоборот, потому что
      при прямом обращении к Х и У горизонтальные линии будут отображаться вертикально.
      Для получения положения ячейки в массиве, можно обратиться к полям CoordX и CoordY,
      где Х - положение по вертикали, У - положение по горизонтали*/
    public class Cell : Button
    {
        public const int CellSize = 25;
        public int CoordX { get; set; }
        public int CoordY { get; set; }

        public Cell(int x, int y)
        {
            Size = new Size(CellSize, CellSize);
            Location = new Point(y * Cell.CellSize, x * Cell.CellSize);
            CoordX = x;
            CoordY = y;

            Click += new System.EventHandler(MouseClickHandler);
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку на игровом поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseClickHandler(object sender, EventArgs e)
        {
            Cell cell = sender as Cell;
            MessageBox.Show(cell.CoordX.ToString() + ", " + cell.CoordY.ToString());
        }

        /// <summary>
        /// Изменяет картинку (пока что) кнопки
        /// </summary>
        public void UpdateCellText()
        {
            switch (Parent.Name)
            {
                case "userField": Text = DataManager.gameInfo.p1field[this.CoordX][this.CoordY].ToString(); break;
                case "botField": Text = DataManager.gameInfo.p2field[this.CoordX][this.CoordY].ToString(); break;
                default: break;
            }
        }
    }
}
