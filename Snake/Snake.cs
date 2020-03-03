﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : Figure
    {
        Direction direction;
        public Snake(Point tail, int lenght, Direction _direction)
        {
            pList = new List<Point>();
            direction = _direction;
            for (int i = 0; i < lenght; i++)
            {
                Point p = new Point( tail );
                p.Move(i, direction);
                pList.Add(p);
            }
        }


        internal void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }

        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }
        public void HandleKey(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            else if (key.Key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
            else if (key.Key == ConsoleKey.UpArrow)
                direction = Direction.UP;
            else if (key.Key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
        }
    }
}