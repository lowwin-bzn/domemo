namespace Domemo
{
    public class Turn
    {
        public Player Player{get; private set;}
        private NumberPicker.INumberPicker picker;

        public Turn(Player player, NumberPicker.INumberPicker picker){
            Player = player;
            this.picker = picker;
        }

        public void ShowTurnStartMessage()
        {
            System.Console.WriteLine(Player.Name + "'s Turn...");
        }

        public int ChoiseNumber(){
            return picker.Pick();
        }
    }
}