using System.Text;

namespace LifeGame;

public sealed class GameFieldMatrix
{
    private char[,] _field = new char[10, 10];
    
    public GameFieldMatrix()
    {
        FillFieldWithDeadBodies();
    }

    private void FillFieldWithDeadBodies()
    {
        for (var i = 0; i < 10; i++)
        {
            for (var j = 0; j < 10; j++)
            {
                _field[i, j] = '-';
            }
        }
    }

    public void Print()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        var convertedFieldToString = new StringBuilder();
        
        for (var i = 0; i < 10; i++)
        {
            for (var j = 0; j < 10; j++)
            {
                convertedFieldToString.Append(_field[i,j]);
            }

            convertedFieldToString.Append('\n');
        }

        return convertedFieldToString.ToString();
    }

    public void SetStartCells()
    {
        _field[3, 4] = '*';
        _field[4, 5] = '*';
        _field[5, 3] = '*';
        _field[5, 4] = '*';
        _field[5, 5] = '*';
    }

    public void NextTurn()
    {
        var newField = new char[10, 10];
        
        for (var i = 0; i < 10; i++)
        {
            for (var j = 0; j < 10; j++)
            {
                ProcessCellTurn(i, j, newField);
            }
        }

        _field = newField;
    }

    private void ProcessCellTurn(int i, int j, char[,] newField)
    {
        var aliveCells = 0;

        try
        {
            if (_field[i - 1, j] == '*')
            {
                aliveCells++;
            }
        }
        catch (Exception)
        {
            // ignored
        }

        try
        {
            if (_field[i - 1, j - 1] == '*')
            {
                aliveCells++;
            }
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {    
            if (_field[i - 1, j + 1] == '*')
            {
                aliveCells++;
            }
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            if (_field[i + 1, j - 1] == '*')
            {
                aliveCells++;
            }
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            if (_field[i + 1, j] == '*')
            {
                aliveCells++;
            }
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            if (_field[i + 1, j + 1] == '*')
            {
                aliveCells++;
            }
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            if (_field[i, j + 1] == '*')
            {
                aliveCells++;
            }
        }
        catch (Exception)
        {
            // ignored
        }
        
        try
        {
            if (_field[i, j - 1] == '*')
            {
                aliveCells++;
            }
        }
        catch (Exception)
        {
            // ignored
        }

        if (aliveCells is > 3 or < 2)
        {
            newField[i,j] = '-';
        }

        if (aliveCells == 2)
        {
            newField[i, j] = _field[i, j];
        }

        if (aliveCells == 3)
        {
            newField[i, j] = '*';
        }
    }
}

