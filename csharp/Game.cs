using System.Linq;

namespace Domemo
{
    public class Game
    {
        Player you = new Player("You");
        Player oppo = new Player("Other");
        Field field = new Field();
        Deck deck = new Deck();

        public Player TurnTarget{get; private set;}

        public bool IsGameSet{get{return you.RemainingPieceCount == 0 || oppo.RemainingPieceCount == 0;}}
        public bool IsYourTurn{get{return TurnTarget == you;}}

        public Player Winner{
            get{
                if(you.RemainingPieceCount == 0){
                    return you;
                }
                if(oppo.RemainingPieceCount == 0){
                    return oppo;
                }
                return null;
            }
        }

        public void Initialize()
        {
            foreach(var draw in Enumerable.Range(0, 7)){
                you.AddToHand(deck.PickRandom());
            }
            foreach(var draw in Enumerable.Range(0, 7)){
                oppo.AddToHand(deck.PickRandom());
            }

            foreach(var drawPiece in deck.Pieces.Values.SelectMany(_ => _))
            {
                field.Add(drawPiece);
            }

            TurnTarget = you;
        }

        public void ShowOpenPiecesForYou()
        {
            field.Show();
            oppo.Show();
        }

        public Turn GetTurn()
        {
            return IsYourTurn
                ? new Turn(you, new NumberPicker.StdinPicker())
                : new Turn(oppo, new NumberPicker.UncheckedOpenPieceNumberPicker());
        }

        public void TurnEnd()
        {
            TurnTarget = IsYourTurn ? oppo : you;
        }

        public void RemovePiece(Player target, int number)
        {
            var piece = target.RemoveFromHand(number);
            field.Add(piece);
        }
    }
}