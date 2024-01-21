using System.Collections.Generic;
using UnityEngine;

public struct XY
{
    public int x;
    public int y;
}

public struct PieceMove
{
    public ChessPiece piece;
    public XY move;
    public XY position;
    public ChessPiece target;
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
                        moves.Add(new PieceMove { piece = piece, move = move, position = position });
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
        foreach (ChessPiece[] row in board)
        {
            foreach (ChessPiece piece in row)
            {
                if (piece != null)
                {
                    score += piece.GetValue();
                }
            }
        }
        return score;
    }

    public PieceMove? GetBestMove(bool isPlayer, int depth)
    {
        PieceMove[] moves = GetPieceMoves(isPlayer);
        int bestScore = isPlayer ? int.MinValue : int.MaxValue;
        PieceMove? bestMove = null;
        foreach (PieceMove move in moves)
        {
            ApplyPieceMove(move);
            int score = Minimax(depth - 1, !isPlayer, int.MinValue, int.MaxValue);
            UndoPieceMove(move);
            if (isPlayer && score > bestScore || !isPlayer && score < bestScore)
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
            return Evaluate();

        PieceMove[] moves = GetPieceMoves(isPlayer);
        foreach (PieceMove move in moves)
        {
            ApplyPieceMove(move);
            int score = Minimax(depth - 1, !isPlayer, alpha, beta);
            UndoPieceMove(move);
            if (isPlayer)
                alpha = System.Math.Max(alpha, score);
            else
                beta = System.Math.Min(beta, score);
            if (beta <= alpha)
                break;
        }
        return isPlayer ? alpha : beta;
    }
}