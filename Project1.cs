using System;

class Program
{
    static char[,] board;
    static char currentPlayer;
    static bool gameEnd;

    static void Main()
    {
        InitializeBoard();
        currentPlayer = 'X';
        gameEnd = false;

        while (!gameEnd)
        {
            DrawBoard();
            GetPlayerMove();
            CheckForWin();
            SwitchPlayer();
        }
    }

    static void InitializeBoard()
    {
        board = new char[3, 3];
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                board[row, col] = '-';
            }
        }
    }

    static void DrawBoard()
    {
        Console.WriteLine("   0 1 2");
        for (int row = 0; row < 3; row++)
        {
            Console.Write($"{row}  ");
            for (int col = 0; col < 3; col++)
            {
                Console.Write($"{board[row, col]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void GetPlayerMove()
    {
        Console.WriteLine($"Player {currentPlayer}, enter your move (row column):");
        string input = Console.ReadLine();
        string[] coordinates = input.Split(' ');
        int row = int.Parse(coordinates[0]);
        int col = int.Parse(coordinates[1]);

        if (IsValidMove(row, col))
        {
            board[row, col] = currentPlayer;
        }
        else
        {
            Console.WriteLine("Invalid move. Try again.");
            GetPlayerMove();
        }
    }

    static bool IsValidMove(int row, int col)
    {
        return row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == '-';
    }

    static void CheckForWin()
    {
        if (HasPlayerWon('X'))
        {
            Console.WriteLine("Player X wins!");
            gameEnd = true;
        }
        else if (HasPlayerWon('O'))
        {
            Console.WriteLine("Player O wins!");
            gameEnd = true;
        }
        else if (IsBoardFull())
        {
            Console.WriteLine("It's a draw!");
            gameEnd = true;
        }
    }

    static bool HasPlayerWon(char player)
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player)
            {
                return true; // horizontal win
            }
            if (board[0, i] == player && board[1, i] == player && board[2, i] == player)
            {
                return true; // vertical win
            }
        }

        if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
        {
            return true; // diagonal win (top-left to bottom-right)
        }
        if (board[2, 0] == player && board[1, 1] == player && board[0, 2] == player)
        {
            return true; // diagonal win (bottom-left to top-right)
        }

        return false; // no win
    }

    static bool IsBoardFull()
    {
        for (int row = 0; row <3; row++)
{
for (int col = 0; col < 3; col++)
{
if (board[row, col] == ‘-’)
{
return false; // empty cell found, board is not full
}
}
}
return true; // no empty cells found, board is full
}

static void SwitchPlayer()
{
    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
}

}
