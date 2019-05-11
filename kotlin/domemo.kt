import java.util.*

class Player(val name:String, var pieces:MutableList<Int>){
    fun show() = println("${name}: ${pieces}")
    fun hasPiece(num:Int) = pieces.any{piece -> piece == num}
    fun remove(num:Int) = pieces.remove(num)
    fun isAllOpen() = pieces.count() == 0
}

class SimpleRandomPicker{
    val rand = Random()
    fun pick() = rand.nextInt(7) + 1
}

fun handPieceCount(playerCount:Int) = when(playerCount){
        2 -> 7
        3 -> 7
        4 -> 5
        5 -> 4
        else -> 0
}

fun fieldOpenPieceCount(playerCount:Int) = when(playerCount){
        2 -> 7
        3 -> 0
        4 -> 4
        5 -> 4
        else -> 0
}

fun main(args:Array<String>){
    val playerCount = 5

    val pieces = (1..7).flatMap{i -> (1..i).map{_ -> i}}.toMutableList()
    pieces.shuffle()
    val handPiece = handPieceCount(playerCount)
    val players = (0..playerCount-1).map{id -> Player("Player" + (id + 1), pieces.drop(id * handPiece).take(handPiece).toMutableList())}
    val fieldOpenPieces = pieces.drop(handPiece * playerCount).take(fieldOpenPieceCount(playerCount)).toMutableList()

    var currentPlayer = 0
    val picker = SimpleRandomPicker()
    while(players.all{p -> !p.isAllOpen()}){
        val p = players[currentPlayer]
        println("${p.name}'s Turn...")
        val otherPlayers = players.take(currentPlayer) + players.drop(currentPlayer + 1).take(players.size - currentPlayer + 1)
        println("field opened pieces: " + fieldOpenPieces)

        println("other player pieces")
        for(other in otherPlayers){
            other.show()
        }
        println()

        val choiceNum = picker.pick()
        println("choice number: ${choiceNum}")
        if(p.hasPiece(choiceNum)){
            println("has Piece! ${choiceNum}")
            p.remove(choiceNum)
            fieldOpenPieces.add(choiceNum)
        }
        currentPlayer = if(currentPlayer + 1 == players.size) 0 else currentPlayer + 1
        println()
    }

    for(p in players.filter{p -> p.isAllOpen()}){
        println("Winner ${p.name}")
    }
}