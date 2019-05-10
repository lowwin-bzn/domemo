namespace Domemo{
public class Piece{
    public int Number{get; private set;}

    public Piece(int num){
        Number = num;
    }

    public bool IsSameNumber(int num){
        return Number == num;
    }

    public override string ToString()
    {
        return Number.ToString();
    }
}}
