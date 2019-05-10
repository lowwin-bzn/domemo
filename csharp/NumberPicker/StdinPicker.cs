namespace Domemo.NumberPicker
{
    public class StdinPicker : INumberPicker
    {
        public int Pick(){
            System.Console.Write("put number: ");
            var choiseNumber = int.Parse(System.Console.ReadKey().KeyChar.ToString());
            System.Console.WriteLine();
            return choiseNumber;
        }
    }
}