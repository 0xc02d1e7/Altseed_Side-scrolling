﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altseed_Side_scrolling
{

    public class Player : Character
    {
        private asd.Texture2D[] Bouningen = new asd.Texture2D[6];

        public Player(Maps _map)
            : base(_map, 13.0f, 32.0f, new asd.Vector2DF(100.0f, 100.0f))
        {
            for (int i = 0; i < 6; i++)
            {
                Bouningen[i] = asd.Engine.Graphics.CreateTexture2D("Resources/Characters/W" + i.ToString() + ".png");
            }
            Texture = Bouningen[0];
            CenterPosition = new asd.Vector2DF((float)Texture.Size.X / 2.0f, (float)Texture.Size.Y / 2.0f);

        }

        protected override void OnUpdate()
        {
            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Left) == asd.KeyState.Hold)//左移動
            {
                Velocity1.X = -2.0f;
            }
            else if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Right) == asd.KeyState.Hold)//右移動
            {
                Velocity1.X = 2.0f;
            }
            else Velocity1.X = 0.0f;

            if (asd.Engine.Keyboard.GetKeyState(asd.Keys.Up) == asd.KeyState.Hold /*&& Math.Abs(Movement.Y) < 0.1f*/)//ジャンプ
            {
                Velocity1.Y = -4.0f;
            }

            base.OnUpdate();

            if (Math.Abs(Movement.Y) > 0.1f)
            {
                Texture = Bouningen[5];
                Anime = 0;
            }
            else Texture = Bouningen[(Anime / 4) % 4];
            //System.Console.WriteLine("{0},{1} :{2},{3}", Velocity1.X, Velocity1.Y,Position.X,Position.Y);
        }
    }
}
