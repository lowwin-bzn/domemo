namespace Domemo.NumberPicker {
    public class UncheckedOpenPieceNumberPicker : INumberPicker {
        public int Pick () {
            var choiseNumber = new System.Random ().Next (1, 8);
            return choiseNumber;
        }
    }
}