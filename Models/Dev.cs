namespace Models
{
    public class Dev: IPerso<Bug>, IPerso<Code>
    {
        
        public event DelegateSante? ESante;
        public event EventHandler<FightEventArgs>? EFight;

        private int _Pv;
        

        public int Pv { get => _Pv; set => _Pv = value; }
        

        //public void Attaque(Bug bug, int degats=1)
        //{
        //    bug.Encaisse(degats);
        //}

        public void Encaisse(int degats)
        {
            Pv -= degats;
            if(ESante != null) ESante($"Dev : {Pv}");

            if (Pv <= 0)
            {
                if (EFight != null) EFight(this, new FightEventArgs() { Message = "'Arrrgh' dit le dev" });
            }
        }
    }
}