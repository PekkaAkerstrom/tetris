using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tetris;

namespace ConsoleApplication1
{
    class Program
    {
        private void subscribe(Game game)
        {
            game.TickEvent += OnTickEvent;
        }
        private void OnTickEvent(Game game, EventArgs e)
        {
            Console.Write(game.toString());
            Console.Write("Score: ");
            Console.WriteLine(game.score.ToString());
            if (game.gameOver) Console.WriteLine("GameOver");
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome");

            Game game = new Game(9, 9);

            Console.WriteLine("Empty Board, 9*9");
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Drop piece X");
            game.drop("X");
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Wait one tick");
            game.tick();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Wait one tick");
            game.tick();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Wait one tick, should stop at bottom");
            game.moveToBottom();
            game.tick();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Drop piece Y");
            game.drop("Y");
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Wait one tick");
            game.tick();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Wait one tick, should stop at X");
            game.moveToBottom();
            game.tick();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Drop piece Z");
            game.drop("Z");
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Move Left");
            game.moveLeft();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Wait one tick");
            game.tick();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Wait one tick");
            game.tick();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Wait one tick, should stop at bottom");
            game.moveToBottom();
            game.tick();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Drop piece Z");
            game.drop("Z");
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Move Right");
            game.moveRight();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Wait one tick");
            game.tick();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Wait one tick");
            int score = game.tick();
            Console.Write(game.toString());
            Console.Write("Score: ");
            Console.WriteLine(score.ToString());

            Console.WriteLine("");
            Console.WriteLine("Wait one tick, should stop at bottom");
            game.moveToBottom();
            score = game.tick();
            Console.Write(game.toString());
            Console.Write("Score: ");
            Console.WriteLine(score.ToString());

            Console.WriteLine("");
            Console.WriteLine("Drop piece ZZ-ZZ");
            game.drop("ZZZZ");
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Move Left");
            game.moveLeft();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Move Left");
            game.moveLeft();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Move Left");
            game.moveLeft();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Move Left");
            game.moveLeft();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Move Left, should stop at edge");
            game.moveLeft();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Wait one tick, should stop at bottom");
            game.moveToBottom();
            score = game.tick();
            Console.Write(game.toString());
            Console.Write("Score: ");
            Console.WriteLine(score.ToString());

            Console.WriteLine("");
            Console.WriteLine("Drop piece III-III-III");
            game.drop(".I..I..I.");
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Rotate Left");
            game.rotateLeft();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Wait one tick");
            game.tick();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Rotate Right");
            game.rotateRight();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Move Left");
            game.moveLeft();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Move Left");
            game.moveLeft();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Move Left");
            game.moveLeft();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Move Left");
            game.moveLeft();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Move Left");
            game.moveLeft();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Rotate Right, should not rotate since it is blocked by wall");
            game.rotateRight();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Wait one tick, should stop at bottom");
            game.moveToBottom();
            score = game.tick();
            Console.Write(game.toString());
            Console.Write("Score: ");
            Console.WriteLine(score.ToString());

            Console.WriteLine("");
            Console.WriteLine("Drop piece .AA-.A.-AA.");
            game.drop(".AA.A.AA.");
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Rotate Left");
            game.rotateLeft();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Wait one tick");
            game.tick();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Rotate Right");
            game.rotateRight();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Move Left");
            game.moveLeft();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Wait one tick, should stop at bottom");
            game.moveToBottom();
            score = game.tick();
            Console.Write(game.toString());
            Console.Write("Score: ");
            Console.WriteLine(score.ToString());

            Console.WriteLine("");
            Console.WriteLine("Drop piece .BB-BB.-...");
            game.drop(".BBBB....");
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Wait one tick");
            game.tick();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Rotate Right");
            game.rotateRight();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Move Right");
            game.moveRight();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Wait one tick, should stop at bottom");
            game.moveToBottom();
            score = game.tick();
            Console.Write(game.toString());
            Console.Write("Score: ");
            Console.WriteLine(score.ToString());

            Console.WriteLine("");
            Console.WriteLine("Drop piece ZZ-ZZ");
            game.drop("ZZZZ");
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Wait one tick");
            game.tick();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Rotate Right");
            game.rotateRight();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Move Right");
            game.moveRight();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Move Right");
            game.moveRight();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Move Right");
            game.moveRight();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Move Right");
            game.moveRight();
            Console.Write(game.toString());

            Console.WriteLine("");
            Console.WriteLine("Wait one tick, should stop at bottom");
            game.moveToBottom();
            score = game.tick();
            Console.Write(game.toString());
            Console.Write("Score: ");
            Console.WriteLine(score.ToString());

            game = new Game(9, 9);

            Console.WriteLine("");
            Console.WriteLine("Empty Board, 9*9");
            Console.Write(game.toString());
            score = game.score;
            Console.Write("Score: ");
            Console.WriteLine(score.ToString());

            Program p = new Program();
            p.subscribe(game);
            game.start();

            ConsoleKey userInput = Console.ReadKey(true).Key;
            while ( userInput != ConsoleKey.Escape)
            {
                userInput = Console.ReadKey(true).Key;
                if (userInput == ConsoleKey.A) game.moveLeft();
                else if (userInput == ConsoleKey.D) game.moveRight();
                else if (userInput == ConsoleKey.S) game.moveToBottom();
                else if (userInput == ConsoleKey.Q) game.rotateLeft();
                else if (userInput == ConsoleKey.E) game.rotateRight();
            }

        }
    }
}
