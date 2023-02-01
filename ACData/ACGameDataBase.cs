using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using AntonellaCortes_PROGRESOFINAL.Models;

namespace AntonellaCortes_PROGRESOFINAL.Data
{
    public class ACGameDataBase
    {
        string _dbPath;
        private SQLiteConnection conn;

        public ACGameDataBase(string DatabasePath)
        {
            _dbPath = DatabasePath;
        }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<ACGame>();
        }

        public int AddNewGame(ACGame game)
        {
            Init();
            int result = conn.Insert(game);
            return result;
        }

        public int UpadateGame(ACGame game)
        {
            Init();
            int result = conn.Update(game);
            return result;
        }

        public int DeleteGame(ACGame game)
        {
            Init();
            int result = conn.Delete(game);
            return result;
        }

        public List<ACGame> GetAllGames()
        {
            Init();
            List<ACGame> games = conn.Table<ACGame>().ToList();
            return games;
        }

        public ACGame GetGame(int id)
        {
            ACGame game1 = new ACGame(); //ham
            Init();
            List<ACGame> games = conn.Table<ACGame>().ToList();
            foreach (ACGame game2 in games) //hame
            {
                if (game2.ID == id)
                    game1 = game2;
            }
            return game1;
        }
    }
}
