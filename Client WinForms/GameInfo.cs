namespace Client
{
    /// <summary>
    /// Класс-структура, хранящая ответ на GET запрос к серверу
    /// </summary>
    class GameInfo
    {
        public string gameID { get; set; }
        public int fieldX { get; set; }
        public int FieldY { get; set; }
        public string player1 { get; set; }
        public string player2 { get; set; }
        public string status { get; set; }
        public int[][] p1field { get; set; }
        public int[][] p2field { get; set; }
        public string reserved { get; set; }
    }
}
