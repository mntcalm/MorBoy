using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    class GameForm : Form
    {
        public GameForm() 
        {
            Field userField = new Field(0, "userField");
            Field botField = new Field(DataManager.GameDimension * Cell.CellSize + 50, "botField");

            this.Controls.Add(userField);
            this.Controls.Add(botField);

            Size = new Size(userField.Width + botField.Width + 67, userField.Height + 100);
        }

        /// <summary>
        /// Обновляет текст на всех ячейках в игровых полях 
        /// </summary>
        public static void UpdateTextOnCells() 
        {
            for (int x = 0; x < DataManager.GameDimension; x++)
            {
                for (int y = 0; y < DataManager.GameDimension; y++)
                {
                    DataManager.userCellField[x][y].Text = DataManager.gameInfo.p1field[x][y].ToString();
                    DataManager.botCellField[x][y].Text = DataManager.gameInfo.p2field[x][y].ToString();
                    
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GameForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "GameForm";
            this.ResumeLayout(false);

        }
    }
}
