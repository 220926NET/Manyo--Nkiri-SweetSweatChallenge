// See https://aka.ms/new-console-template for more information

Console.WriteLine("Welcome to BlackJack");
Console.WriteLine("How much would you like to bet the min is 10 dollars and the max is 500");
int bet = Convert.ToInt32(Console.ReadLine());

BlackJack game = new BlackJack(bet);
game.startGame();

public class BlackJack{
    public string P1;
    public string dealer = "house";
    public int p1score = 0;
    public int dscore = 0;
    public int p1Wins = 0;
    public int dwins = 0;
    public int round =1;
    public bool won = false;

    public int p1bet; 


    //Constructor
    public BlackJack(int p1bet)
    {
        this.p1bet = p1bet;
    }


    //Main Method

    //static void Main(string[] args){

    //}


    //Methods
    public void startGame(){
        Console.WriteLine("What is your name");
        P1 = Console.ReadLine();
        Console.WriteLine($"\nWelcome {P1} lets go");
        Console.WriteLine("Objective: Dont get over 21");


        while(true)
        {
            Random rnd = new Random();

            if(round == 1)
            {
            int p1Card = rnd.Next(1,11);
            int dealerCard = rnd.Next(1,11);
            p1score = p1score + p1Card;
            dscore = dscore + dealerCard;

            Console.WriteLine($"{P1} you are dealt a {p1Card}");


            Console.WriteLine($"{dealer} is dealt a {dealerCard}\n");
            round++;

            }

            if(round > 1 && !won)
            {
                if(dscore > p1score){
                    //Console.WriteLine($"{P1} please select another card.");
                    Console.Clear();

                }
                else
                Console.WriteLine("Would you like another card? Hit or Stay");
                string hitorStay = Console.ReadLine();
                    
                if(hitorStay.ToLower() == "hit" && !won)
                    {
                        int p1Card = rnd.Next(1,11);
                        p1score = p1score + p1Card;
                        Console.WriteLine($"{P1} you are dealt {p1Card} total value: {p1score}\n");
                        CheckBust(p1score,dscore);
                        if(won) return;
                    }
                else if(round > 1 && hitorStay.ToLower() == "stay" && !won)
                {
                        while (dscore <= p1score && p1score >0)
                        {
                            int dealerCard = rnd.Next(1,11);
                            dscore =dscore + dealerCard;
                            Console.WriteLine($"{dealer} is dealt a {dealerCard} total value {dscore}\n");
                            CheckBust(p1score, dscore);
                            if(dscore > p1score)
                            {
                                Console.WriteLine($"{dealer} wins! you should stop gambling");
                                dwins++;
                        
                                ContinuePlaying();
                            }
                        }
                }
                
            }
            



        }

    }

    public void ContinuePlaying()
    {
        Console.WriteLine("Continue? Yes/No");
        string response = Console.ReadLine();

        if(response.ToLower() == "yes")
        {
            ResetGame();
        }
        else
        {
            Console.WriteLine("You sure...");
            Thread.Sleep(4000);
            Console.WriteLine("fine");
            ExitGame();
        }
    }

    public void ExitGame()
    {
        Console.Clear();
        Environment.Exit(0);

    }

    public void ResetGame()
    {
        p1score = 0;
        dscore = 0;
        round = 1;
        Console.Clear();
    }

    public void CheckBust(int p1score, int dscore)
    {
        if(p1score > 21)
        {
            Console.WriteLine($"{P1} you Bust, dealer wins");
            dwins++;
        }
        if(dscore > 21)
        {
            Console.WriteLine($"{dealer} Bust, {P1} wins");
            p1Wins++;
        }

    }

    /*public int PoolMoney(int p1bet)
    {
        if(won)
        {
            return p1bet;
        }else if(p1score == dscore)
        {
            Console.WriteLine("Push");
            return 0;
        }else if(p1score == 21)
        {
            return p1bet * 2;
        }else
        {
            return p1bet - p1bet;
        }
    } */

}
