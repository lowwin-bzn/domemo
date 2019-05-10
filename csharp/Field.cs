using System.Collections.Generic;
namespace Domemo{
public class Field{
    private List<Piece> shownPieces = new List<Piece>();

    public void Add(Piece piece){
        shownPieces.Add(piece);
    }

    public void Show()
    {
        System.Console.WriteLine("opened piece: "
            + string.Join(", ", shownPieces));
    }
}
}