namespace Models
{
    public class Bug:IPerso<Dev>
    {
        public event DelegateSante? ESante;
        public event EventHandler<FightEventArgs>? EFight;
        private int _Pv; 

        public int Pv { get => _Pv; set => _Pv = value; }
         

        //public void Attaque(Dev dev, int degats = 1)
        //{
        //    dev.Encaisse(degats);
        //}

        public void Encaisse(int degats)
        {
            Pv -= degats;

            if (ESante != null) ESante($"Bug : {Pv}");
            if (Pv <= 0)
            {
                if (EFight != null) EFight(this, new FightEventArgs() { Message = "'Arrrgh' dit le bug" });
            }
        }
    }
}
