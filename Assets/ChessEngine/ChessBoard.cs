using System.Collections.Generic;
using UnityEngine;

public struct XY
{
    public int x;
    public int y;
}

public class PieceMove
{
    public ChessPiece piece;
    public XY move;
    public XY position;
    public ChessPiece target;

    public PieceMove(ChessPiece piece, XY move, XY position)
    {
        this.piece = piece;
        this.move = move;
        this.position = position;
    }
}

public class ChessBoard
{
    public readonly ChessPiece[][] board;

    public ChessBoard()
    {
        board = new ChessPiece[8][];
        for (int i = 0; i < 8; i++)
        {
            board[i] = new ChessPiece[8];
        }
    }

    public PieceMove[] GetPieceMoves(bool isPlayer)
    {
        List<PieceMove> moves = new();
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                ChessPiece piece = board[y][x];
                if (piece != null && piece.isPlayer == isPlayer)
                {
                    XY[] pieceMoves = piece.GetMoves(x, y, board);
                    foreach (XY move in pieceMoves)
                    {
                        XY position = new() { x = x, y = y };
                        moves.Add(new PieceMove(piece, move, position));
                    }
                }
            }
        }
        return moves.ToArray();
    }

    public void AddPiece(ChessPiece piece, int x, int y)
    {
        board[y][x] = piece;
    }

    public void ApplyPieceMove(PieceMove pieceMove)
    {
        int x = pieceMove.position.x;
        int y = pieceMove.position.y;
        int dx = pieceMove.move.x;
        int dy = pieceMove.move.y;
        board[y][x] = null;
        pieceMove.target = board[y + dy][x + dx];
        board[y + dy][x + dx] = pieceMove.piece;
    }

    public void UndoPieceMove(PieceMove pieceMove)
    {
        int x = pieceMove.position.x;
        int y = pieceMove.position.y;
        int dx = pieceMove.move.x;
        int dy = pieceMove.move.y;
        board[y][x] = pieceMove.piece;
        board[y + dy][x + dx] = pieceMove.target;
    }

    public int Evaluate()
    {
        int score = 0;
        for (int y = 0; y < 8; y++)
            for (int x = 0; x < 8; x++)
            {
                ChessPiece piece = board[y][x];
                if (piece != null)
                {
                    int[][] scores = piece.GetScores();
                    int sign = piece.isPlayer ? 1 : -1;
                    score += (scores[y][x] + piece.GetValue()) * sign;
                }
            }
        return score;
    }

    public PieceMove GetBestMove(bool isPlayer, int depth)
    {
        PieceMove[] moves = GetPieceMoves(isPlayer);
        int bestScore = int.MinValue;
        PieceMove bestMove = null;
        foreach (PieceMove move in moves)
        {
            ApplyPieceMove(move);
            int score = Minimax(depth - 1, !isPlayer, int.MinValue, int.MaxValue);
            UndoPieceMove(move);
            if (isPlayer && score < bestScore || !isPlayer && score > bestScore)
            {
                bestScore = score;
                bestMove = move;
            }
        }
        return bestMove;
    }

    private int Minimax(int depth, bool isPlayer, int alpha, int beta)
    {
        if (depth == 0)
            return -Evaluate();

        int best = isPlayer ? int.MinValue : int.MaxValue;
        foreach (PieceMove move in  GetPieceMoves(isPlayer))
        {
            ApplyPieceMove(move);
            int score = Minimax(depth - 1, !isPlayer, alpha, beta);
            UndoPieceMove(move);
            best = isPlayer ? Mathf.Max(best, score) : Mathf.Min(best, score);
        }
        return best;
    }

    public void PrintBoard()
    {
        string boardString = "";
        foreach (ChessPiece[] row in board)
        {
            foreach (ChessPiece piece in row)
            {
                if (piece != null)
                {
                    string name = piece.GetName();
                    if (name == "Knight")
                    {
                        name = "N";
                    }
                    if (piece.isPlayer)
                    {
                        name = name.ToLower();
                    }
                    boardString += name[0] + "\t";
                }
                else
                {
                    boardString += "." + "\t";
                }
            }
            boardString += "\n";
        }
        Debug.Log(boardString);
    }
}