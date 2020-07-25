using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WebApplication3.Models;

namespace WebApplication3.ViewModels
{
    public class PlayersSearchViewModel
    {
        public IList<Player> Players { get; set; }
        public SelectList Positions { get; set; }
        public string PlayerPosition { get; set; }
        public SelectList Countries { get; set; }
        public string PlayerCountry { get; set; }

    }
}
