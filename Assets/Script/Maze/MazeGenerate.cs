using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


namespace ru.lifanoff.Maze {

    /// <summary>
    /// Скрипт, генерирующий лабиринт
    /// </summary>
    public sealed class MazeGenerate : IEnumerable, IEnumerator {

        /// <summary>Размер лабиринта по оси X (количество блоков по оси X)</summary>
        public int sizeX { get; private set; }
        /// <summary>Размер лабиринта по оси Y (количество блоков по оси Y)</summary>
        public int sizeY { get; private set; }


        /// <summary>Структура лабиринта</summary>
        private List<List<Chunk>> maze;

        /// <summary>Получить доступ к элементу из списка блоков</summary>
        /// <param name="x">Положение блока по X</param>
        /// <param name="y">Положение блока по Y</param>
        /// <returns>Объект класса Chunk</returns>
        public Chunk this[int x, int y] {
            get {
                try {
                    return maze[x][y];
                } catch (ArgumentException) {
                    return null;
                }
            }
            private set {
                try {
                    maze[x][y] = value;
                } catch (ArgumentException) { }
            }
        }

        #region IEnumerable and IEnumerator
        private int enumeratorIndexX = 0;
        private int enumeratorIndexY = -1;

        public IEnumerator GetEnumerator() {
            return this;
        }

        public object Current {
            get { return this[enumeratorIndexX, enumeratorIndexY]; }
        }

        public bool MoveNext() {
            enumeratorIndexY++;

            if (enumeratorIndexY >= sizeY) {
                enumeratorIndexX++;
                enumeratorIndexY = 0;
            }

            if (enumeratorIndexX >= sizeX) {
                Reset();
                return false;
            }

            return true;
        }

        public void Reset() {
            enumeratorIndexX = 0;
            enumeratorIndexY = -1;
        }
        #endregion

        /// <param name="x">Размер лабиринта по оси X (количество блоков по оси X)</param>
        /// <param name="y">Размер лабиринта по оси Y (количество блоков по оси Y)</param>
        public MazeGenerate(int x, int y) {
            sizeX = x;
            sizeY = y;
            maze = new List<List<Chunk>>();

            Generate();
        }


        /// <summary>Генерация лабиринта</summary>
        private void Generate() {
            FillMaze();
            AssignNeighborChunks();
            AssignWallsChunks();
            MakeMaze();
        }

        /// <summary>Заполнить <seealso cref="maze"/></summary>
        private void FillMaze() {
            for (int x = 0; x < sizeX; x++) {
                maze.Add(new List<Chunk>());

                for (int y = 0; y < sizeY; y++) {
                    maze.Last().Add(new Chunk(x, y));
                }
            }
        }

        /// <summary>Назначить соседние блоки</summary>
        private void AssignNeighborChunks() {
            foreach (Chunk chunk in this) {
                chunk.leftChunk = this[chunk.x, chunk.y - 1];
                chunk.rightChunk = this[chunk.x, chunk.y + 1];
                chunk.topChunk = this[chunk.x - 1, chunk.y];
                chunk.bottomChunk = this[chunk.x + 1, chunk.y];
            }
        }

        /// <summary>Установить стены во все блоки</summary>
        private void AssignWallsChunks() {
            foreach (Chunk chunk in this) {
                chunk.leftWall = new Wall(Side.LEFT);
                chunk.rightWall = new Wall(Side.RIGHT);
                chunk.topWall = new Wall(Side.TOP);
                chunk.bottomWall = new Wall(Side.BOTTOM);
            }
        }

        #region MakeMaze
        /// <summary>Составить лабиринт</summary>
        private void MakeMaze() {
            throw new NotImplementedException("Попозже придумаю, как это сделать");
        }
        #endregion

    }//class
}//namespace
