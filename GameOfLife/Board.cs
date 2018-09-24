﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Board
    {
        private bool[,] _board;
        private int _noRows;
        private int _noColumns;

        public void Set(bool[,] board)
        {
            _board = board;
            _noRows = board.GetLength(0);
            _noColumns = board.GetLength(1);
        }

        private IEnumerable<bool> GetNeighbours(int boardTileY, int boardTileX)
        {
            var neighbours = new List<bool>();

            for (var i = boardTileY - 1; i <= boardTileY + 1; i++)
                for (var j = boardTileX - 1; j <= boardTileX + 1; j++)
                    if (i == boardTileY && j == boardTileX)
                        continue;
                    //if neighbour out of bounds add as dead
                    else if (i >= _noRows || i < 0 || j >= _noColumns || j < 0)
                        neighbours.Add(false);
                    else
                        neighbours.Add(_board[i, j]);

            return neighbours;
        }

        public void Evolve()
        {
            var boardAfter = new bool[_noRows, _noColumns];

            for (var i = 0; i < _noRows; i++)
                for (var j = 0; j < _noColumns; j++)
                {
                    var aliveCounter = GetNeighbours(i, j).Count(n => n);

                    switch (_board[i, j])
                    {
                        // if dead tile has exactly 3 neighbours that are alive it comes to live
                        case false when aliveCounter == 3:
                            boardAfter[i, j] = true;
                            break;

                        // if alive tile has 0 or 1 neighbours (is lonely) or more than 3 neighbours (overcrowded) it dies
                        case true when (aliveCounter < 2 || aliveCounter > 3):
                            boardAfter[i, j] = false;
                            break;

                        default:
                            boardAfter[i, j] = _board[i, j];
                            break;
                    }
                }

            _board = boardAfter;
        }

        public void Print()
        {
            for (var i = 0; i < _noRows; i++)
            {
                for (var j = 0; j < _noColumns; j++)
                    Console.Write(_board[i, j] ? Constants.AliveChar : Constants.DeadChar);

                Console.WriteLine();
            }
        }
    }
}