using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Game
    {
        private GameBoard board;
        private Block block;
        public int score { get; private set; }
        public bool gameOver { get; private set; }

        private System.Timers.Timer clock;

        public event TickEventHandler TickEvent;
        public delegate void TickEventHandler(Game g, EventArgs e);

        private Object gameLock;

        public Game(int rows, int lanes) {
            gameLock = new Object();
            gameOver = false;
            board = new GameBoard(rows, lanes);
            block = null;
            score = 0;
        }

        public void start()
        {
            clock = new System.Timers.Timer(1000);
            clock.Elapsed += OnTimedEvent;
            clock.AutoReset = false;
            clock.Start();
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (!gameOver)
            {
                tick();
                TickEvent(this, null);
                clock.Start();
            }
        }

        public int tick()
        {
            lock (gameLock)
            {
                if (block != null)
                {
                    if (isBoardFree(1, 0, block))
                    {
                        block.move(1, 0);
                    }
                    else
                    {
                        // Put block to board and remove it
                        putBlock();
                    }
                }
                else
                {
                    // Spawn new block
                    drop(BlockGenerator.getNextBlock());
                    if (!isBoardFree(0, 0, block))
                    {
                        //Game over
                        gameOver = true;
                        clock.Stop();
                        //TickEvent(this, null);
                    }
                }
                return score;
            }
        }

        public void drop(String x) {
            block = new Block(x);
            block.move(0, board.lanes / 2 - block.lanes / 2);
        }

        private bool isBoardFree(int x, int y, Block block)
        {
            if (block == null) return false;

            bool free = true;

            for (int row = 0; row < block.rows; row++)
            {
                for (int lane = 0; lane < block.lanes; lane++)
                {
                    int globalRow = row + block.rowPosititon;
                    int globalLane = lane + block.lanePosititon;

                    if (block != null && block.isGlobalPositionOccupied(globalRow, globalLane))
                    {
                        if (globalRow + x >= board.rows ||
                            globalRow + x < 0 ||
                            globalLane + y >= board.lanes ||
                            globalLane + y < 0)
                        {
                            return false;
                        }
                        free = free && board.isEmpty(globalRow + x, globalLane + y);
                    }
                }
            }
            return free;
        }

        private void putBlock()
        {
            for (int row = 0; row < board.rows; row++)
            {
                for (int lane = 0; lane < board.lanes; lane++)
                {
                    if (block.isGlobalPositionOccupied(row, lane))
                    {
                        board.setCell(row, lane, block.getGlobalCell(row, lane));
                    }
                }
            }
            int linesRemoved = board.removeFullLines();
            score += linesRemoved;
            if(linesRemoved>0 && clock != null)
                clock.Interval = clock.Interval / 2.0;
            block = null;
        }

        public void rotateLeft()
        {
            lock (gameLock)
            {
                if (block != null)
                {
                    Grid rotatedGrid = block.rotate(1);
                    if (rotatedGrid != null)
                    {
                        Block rotatedBlock = new Block(rotatedGrid, block.rowPosititon, block.lanePosititon);
                        if (isBoardFree(0, 0, rotatedBlock))
                        {
                            block = rotatedBlock;
                        }
                    }
                }
            }
        }

        public void rotateRight()
        {
            lock (gameLock)
            {
                if (block != null)
                {
                    Grid rotatedGrid = block.rotate(-1);
                    if (rotatedGrid != null)
                    {
                        Block rotatedBlock = new Block(rotatedGrid, block.rowPosititon, block.lanePosititon);
                        if (isBoardFree(0, 0, rotatedBlock))
                        {
                            block = rotatedBlock;
                        }
                    }
                }
            }
        }

        public void moveLeft()
        {
            lock (gameLock)
            {
                if (isBoardFree(0, -1, block))
                {
                    block.move(0, -1);
                }
            }
        }

        public void moveRight()
        {
            lock (gameLock)
            {
                if (isBoardFree(0, 1, block))
                {
                    block.move(0, 1);
                }
            }
        }

        public void moveToBottom()
        {
            lock (gameLock)
            {
                while (isBoardFree(1, 0, block))
                {
                    block.move(1, 0);
                }
            }
        }

        public String toString() {
            String s = "";
            for (int row = 0; row < board.rows; row++)
            {
                for (int lane = 0; lane < board.lanes; lane++)
                {
                    if(block != null && block.isGlobalPositionOccupied(row, lane))
                    {
                        s += block.getGlobalCell(row, lane);
                    }
                    else
                    {
                        s += board.getCell(row, lane);
                    }
                }
                s += "\n";
            }
            return s;
        }
        
    }
}
