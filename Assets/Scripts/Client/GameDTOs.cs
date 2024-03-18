using Client.DTO;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Client.DTO
{
    public class GamesTypesDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description;
        public string Genre { get; set; }
        public int ActivePlayers { get; set; }
        public int TotalPlayers { get; set; }
        public int Rating { get; set; }
        public int TotalRates { get; set; }
        public string Version { get; set; }
        public int BuildNumber { get; set; }
        public bool IsVertical { get; set; }
        public int GameConfigId { get; set; }
        public string GameState { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    public class GameTypesAllGamesDTO
    {
        public List<GamesTypesDTO> Games { get; set; }
    }
}