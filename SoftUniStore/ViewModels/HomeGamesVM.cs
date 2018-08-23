namespace SoftUniStore.ViewModels
{
    using System.Collections.Generic;

    public class HomeGamesVM
    {
        public bool IsAuthenticated { get; set; }

        public IEnumerable<GameVM> GameVms { get; set; }
    }

}
