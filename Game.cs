﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Raylib_cs;
using Math_Library;

namespace MathForGames
{
    class Game
    {
        private static bool _gameOver = false;
        private static Scene[] _scenes;
        private static int _currentSceneIndex;
        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;
        //Static function used to set game over without an instance of game.
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }

        public static Scene[] GetScene(int index)
        {
            return _scenes[index];
        }

        public static int Addscene(Scene scene)
        {
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            for (int i = 0; i < _scenes.Length; i++)
            {
                tempArray[i] = _scenes[i];
            }
            int index = _scenes.Length;
            tempArray[index] = scene;
            _scenes = tempArray;

            return index;
        }

        public static bool RemoveScene(Scene scene)
        {
            if(scene == null)
            {
                return false;
            }

            bool removed = false;

            Scene[] tempArray = new Scene[_scenes.Length - 1];

            int j = 0;
            for(int i = 0; i < _scenes.Length; i++)
            {
                if (tempArray[i] != scene)
                {
                    tempArray[j] = _scenes[i];
                    j++;
                }
                else
                {
                    removed = true;
                }

            }
            if(removed)
            _scenes = tempArray;

            return removed;
        }

        public static void SetCurrentScene(int index)
        {
            if (index< 0 || index >= _scenes.Length)
                return;

            if (_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].End();


            _currentSceneIndex = index;

        }
        public static bool GetKeyDown(int key)
        {
            return Raylib.IsKeyDown((KeyboardKey)key); 
        }
        public static ConsoleKey GetNextKey()
        {
            return (ConsoleKey)(Raylib.GetKeyPressed() + 32);
        }
        public Game()
        {
            _scenes = new Scene[0];
        }
        

        public static bool CheckKey(ConsoleKey key)
        {
            return false;
        }

        public static bool GetKeyPressed(int key)
        {
            int keyPressed = Raylib.GetKeyPressed();
           if(keyPressed == 65 + 32)
            {

            }
            return false;
        }
        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            Raylib.InitWindow(1024, 760, "Math For Games");
            Raylib.SetTargetFPS(60);


            Console.CursorVisible = false;
            Console.Title = "Math For Games";

            Scene scene = new Scene();
           
            Actor actor = new Actor(0, 0,Color.GREEN, 'a', ConsoleColor.Green);
            actor.Velocity.X = 1;
            scene.AddActor(actor);
            Player player = new Player(0, 1,Color.RED, '@', ConsoleColor.Red);
            scene.AddActor(player);
            Addscene(scene);
            int startingSceneIndex = Addscene(scene);
            SetCurrentScene(startingSceneIndex);


            
        }


        //Called every frame.
        public void Update()
        {
            if (!_scenes[_currentSceneIndex].Started)
                _scenes[_currentSceneIndex].Start();

            _scenes[_currentSceneIndex].Update();
            
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);
            Console.Clear();

            _scenes[_currentSceneIndex].Draw();
            Raylib.EndDrawing();
        }


        //Called when the game ends.
        public void End()
        {
            if(!_scenes[_currentSceneIndex].Started)
            _scenes[_currentSceneIndex].End();
        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();

            while (!_gameOver && !Raylib.WindowShouldClose())
            {
                GetKeyPressed(65);
                Update();
                Draw();
                while (Console.KeyAvailable) Console.ReadKey(true);

                Thread.Sleep(250);
            }

            End();
        }
    }
}
