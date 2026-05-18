public void MoveLeft()
{
    bool canMove = _mazeMap[(_currX,_currY)][0];

    if (canMove)
    {
        _currX--;
    }
    else
    {
        throw new InvalidOperationException("Can't go that way!");
    }
}

public void MoveRight()
{
    bool canMove = _mazeMap[(_currX,_currY)][1];

    if (canMove)
    {
        _currX++;
    }
    else
    {
        throw new InvalidOperationException("Can't go that way!");
    }
}

public void MoveUp()
{
    bool canMove = _mazeMap[(_currX,_currY)][2];

    if (canMove)
    {
        _currY--;
    }
    else
    {
        throw new InvalidOperationException("Can't go that way!");
    }
}

public void MoveDown()
{
    bool canMove = _mazeMap[(_currX,_currY)][3];

    if (canMove)
    {
        _currY++;
    }
    else
    {
        throw new InvalidOperationException("Can't go that way!");
    }
}
