using DSharpPlus.CommandsNext;
using System;

namespace StarArisingBot.Minigames.HungerGames
{
    public class HGWorldController
    {
        public int CurrentDay { get; set; }

        public bool IsDay { get; set; }
        public bool IsNight { get; set; }

        public int RemainingDialogues { get; set; }
        public int MaxRemainingDialogues { get; set; }

        private Random random;

        public HGWorldController()
        {
            CurrentDay = 1;
            IsDay = true;
            IsNight = false;
            RemainingDialogues = 5;
            MaxRemainingDialogues = 5;

            random = new Random();
        }
        public void SwapDayState()
        {
            IsDay = !IsDay;
            IsNight = !IsNight;

            RemainingDialogues = MaxRemainingDialogues;
        }
    }
}
