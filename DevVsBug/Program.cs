// See https://aka.ms/new-console-template for more information
using Models;
static class Program
{
    static bool BugIsDeath = false;
    static bool DevIsDeath = false;

    static void  Main(string[] args)
    {
        Console.WriteLine("Dev VS Bug!");

        //1 - Création des deux combattants

        Bug NullRef = new Bug();
        NullRef.Pv = 15;

        Dev JuniorDev = new Dev();
        JuniorDev.Pv = 10;

        //1.1 Abonnement aux events
        NullRef.ESante += Perso_ESante;
        JuniorDev.ESante += Perso_ESante;
        NullRef.EFight += Perso_EFight;
        JuniorDev.EFight += Perso_EFight;

        //2 - Combat jusqu'à la mort d'un des deux
        while (!BugIsDeath && !DevIsDeath)
        {
            NullRef.Attaque(JuniorDev, 2);
            JuniorDev.Attaque(NullRef, 4);
        }

        //3 - On vérifie qui a gagné
        if (BugIsDeath) Display("JuniorDev a gagné!");
        else Display("NulRef a gagné!");
    }

    private static void Perso_EFight(object? sender, FightEventArgs e)
    {
        if (sender != null)
        {
            if (sender is Dev) BugIsDeath = true;
            else DevIsDeath = true;
        }
        
        Display($"{e.Message} ({sender?.ToString()})");
    }

    private static void Perso_ESante(string message)
    {
        Display($"{message}");
    }

    private static void Display(string info)
    {
        //? - On affiche le déroulement du jeux
        Console.WriteLine(info);
    }
}
