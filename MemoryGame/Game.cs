namespace MemoryGame
{
    class Game
    {
        public Game()
        {
            Strf();
        }

        public Image[] List { get; } = {
            Properties.Resources.resim0,Properties.Resources.resim0,
            Properties.Resources.resim1,Properties.Resources.resim1,
            Properties.Resources.resim2,Properties.Resources.resim2,
            Properties.Resources.resim3,Properties.Resources.resim3,
            Properties.Resources.resim4,Properties.Resources.resim4,
            Properties.Resources.resim5,Properties.Resources.resim5,
            Properties.Resources.resim6,Properties.Resources.resim6,
            Properties.Resources.resim7,Properties.Resources.resim7,
            Properties.Resources.resim8,Properties.Resources.resim8,
            Properties.Resources.resim9,Properties.Resources.resim9
        };
        public void Strf()
        {
            for (int i = List.Length - 1; i > 0; i--)
            {
                Random random = new();
                int randomIndex = random.Next(0, i + 1);
                (List[randomIndex], List[i]) = (List[i], List[randomIndex]);
            }
        }
    }
}
