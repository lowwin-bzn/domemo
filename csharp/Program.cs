using System;

namespace Domemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Initialize();

            while(!game.IsGameSet){
                var turn = game.GetTurn();
                turn.ShowTurnStartMessage();
                if(game.IsYourTurn){
                    game.ShowOpenPiecesForYou();
                }

                var choise = turn.ChoiseNumber();
                System.Console.WriteLine(turn.Player.Name + " choised number: " + choise);

                if(turn.Player.HasPiece(choise)){
                    System.Console.WriteLine(turn.Player.Name + " Hit piece: " + choise);
                    game.RemovePiece(turn.Player, choise);
                }

                game.TurnEnd();
            }

            Console.WriteLine("This game winner: " + game.Winner.Name);
        }
    }
}
