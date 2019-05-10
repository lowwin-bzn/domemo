using System.Collections.Generic;
using System.Linq;

namespace Domemo
{
    public class Player
    {
        public string Name{get; private set;}
        public int RemainingPieceCount{get{return pieces.Count;}}

        private List<Piece> pieces = new List<Piece>();

        public Player(string name)
        {
            Name = name;
        }

        public bool HasPiece(int num)
        {
            return pieces.Any(piece => piece.IsSameNumber(num));
        }

        public void AddToHand(Piece piece)
        {
            pieces.Add(piece);
        }

        public Piece RemoveFromHand(int num)
        {
            var removePiece = pieces.First(piece => piece.IsSameNumber(num));
            pieces.Remove(removePiece);
            return removePiece;
        }

        public void Show()
        {
            System.Console.WriteLine(
                string.Format("{0} pieces: {1}", Name, string.Join(", ", pieces)));
        }
    }
}