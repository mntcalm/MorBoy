using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    class Field : Panel
    {
        public Field(int offset, string name)
        {
            Name = name;
            Location = new Point(0 + offset, 0);
            Size = new Size(DataManager.GameDimension * Cell.CellSize, DataManager.GameDimension * Cell.CellSize);

            SetCells();
        }

        /// <summary>
        /// Расставляет ячейки на игровом поле field
        /// </summary>
        private void SetCells()
        {
            for (int x = 0; x < DataManager.GameDimension; x++)
            {
                for (int y = 0; y < DataManager.GameDimension; y++)
                {
                    Cell cell = new Cell(x, y);

                    //блок определения в массив ячеек из DataManager
                    //ячейки сравниваются по признаку имени поля (this.Name), в котором они находятся
                    switch (this.Name)
                    {
                        case "userField": DataManager.userCellField[x][y] = cell; break;
                        case "botField": DataManager.botCellField[x][y] = cell; break;
                        default: break;
                    }

                    Controls.Add(cell);
                }
            }
        }
    }
}
