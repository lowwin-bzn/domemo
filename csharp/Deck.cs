using System.Collections.Generic;
using System.Linq;
using System;
namespace Domemo{

public class Deck{
    public Dictionary<int, List<Piece>> Pieces{get; private set;}
    public Deck(){
        Pieces = Enumerable
            .Range(1, 7)
            .ToDictionary(
                key => key,
                num => Enumerable
                    .Repeat(num, num)
                    .Select(pieceNum => new Piece(pieceNum))
                    .ToList()
            );
    }

    public Piece Pick(int num)
    {
        var res = Pieces[num].FirstOrDefault();
        if(res != null){
            Pieces[num].RemoveAt(0);
        }
        return res;
    }

    public Piece PickRandom()
    {
        var remainingPieceKeys = Pieces
            .Where(kv => kv.Value.Count > 0)
            .Select(kv => kv.Key);
        var num = remainingPieceKeys.ElementAt(
            new Random().Next(remainingPieceKeys.Count()));

        return Pick(num);
    }
}
}