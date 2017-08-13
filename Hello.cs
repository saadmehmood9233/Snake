using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        string input = "21 14|9 24|3";
        string[] inputs = input.Split('|');

        // Direction in which snake is moving
        // 0: left, 1: up, 2: right, 3: down
        int direction = Int32.Parse(inputs[2]);
        string[] food_points = inputs[0].Split(' ');
        int foodX = Int32.Parse(food_points[0]);    // Food point possition X
        int foodY = Int32.Parse(food_points[1]);    // Food point possition Y


        string[] dat = inputs[1].Split(',');
        int[][] queue = new int[dat.Length][];      // List of player points [[X,Y], [X,Y]]

        for (int j = 0; j < dat.Length; j++)
        {
        queue[j] = new int[2];
        string[] player_points = dat[j].Split(' ');

        queue[j][0] = Int32.Parse(player_points[0]);
        queue[j][1] = Int32.Parse(player_points[1]);
        }

        // Write Your Code here
        // Warning: Please do not change code above :)
        if(direction == 0) {
         Console.WriteLine("2 1");
        } else if (direction == 1) {
            Console.WriteLine("2 2");
        } else if (direction == 2) {
            Console.WriteLine("2 3");
        } else {
            Console.WriteLine("2 0");
        }
    }
}

        