using System;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Начать игру" на главной форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm();
            gameForm.Show();
            this.Hide();

            //DataManager.GameId = DataManager.PostRequest("http://sb.mailboxly.info", "");
            //gameForm.Text = "Game ID = " + DataManager.GameId;

            //получаем от сервера json-данные и тут же их парсим в структуру GameInfo
            DataManager.gameInfo = 
                JsonConvert.DeserializeObject<GameInfo>(DataManager.GetRequest("http://sb.mailboxly.info/?gameid=AA22DD5511"));

            GameForm.UpdateTextOnCells();

            gameForm.Text = "Game ID = " + DataManager.gameInfo.gameID;

            gameForm.FormClosed += new FormClosedEventHandler(OnGameFormClose);//слушатель закрытия игрового окна
        }

        /// <summary>
        /// Обработчик события, когда GameForm закрывается
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGameFormClose(object sender, FormClosedEventArgs e)
        {
            this.Show();
            //??? Отправлять запрос на сервер об удалении(?) данной игры
        }
    }
}
