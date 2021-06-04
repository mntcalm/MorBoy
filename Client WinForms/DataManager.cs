using System.Net;
using System.IO;

namespace Client
{
    static class DataManager
    {
        public static WebClient webClient = new WebClient();
        public static GameInfo gameInfo = new GameInfo();
        public static int GameDimension { get; } = 5;//размерность игры (5х5)

        public static Cell[][] userCellField = InitArray();
        public static Cell[][] botCellField = InitArray();

        /// <summary>
        /// Осуществляет GET запрос по указанному URI
        /// </summary>
        /// <returns></returns>
        public static string GetRequest(string uri)
        {
            string response = string.Empty;

            using (Stream stream = webClient.OpenRead(uri))
            using (StreamReader reader = new StreamReader(stream))
                response = reader.ReadToEnd();

            return response;
        }

        /// <summary>
        /// Осуществляет POST запрос по указанному URI
        /// </summary>
        /// <param name="uri">Адрес, по которому осуществляется запрос</param>
        /// <param name="data">JSON, который отправляется по адресу</param>
        /// <returns></returns>
        public static string PostRequest(string uri, string data)
        {
            string response = webClient.UploadString(uri, data);

            return response;
        }

        /// <summary>
        /// Вспомогательный метод. Задаёт размерность массивам внутри зубчатого массива
        /// </summary>
        /// <param name="arr"></param>
        private static Cell[][] InitArray() 
        {
            Cell[][] arr = new Cell[GameDimension][];

            for (int i = 0; i < GameDimension; i++)
                arr[i] = new Cell[GameDimension];

            return arr;
        }
    }
}
