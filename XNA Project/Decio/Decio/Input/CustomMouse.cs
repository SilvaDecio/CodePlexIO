using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Decio.Input
{
    class CustomMouse
    {
        Texture2D Image;
        
        public Rectangle Rectangle;
        
        public Point ClickPlace;
        
        public Color[] Data;

        public CustomMouse(ContentManager Content)
        {
            Image = Content.Load<Texture2D>("Asset");

            ClickPlace = new Point(Mouse.GetState().X , Mouse.GetState().Y);

            Rectangle = new Rectangle((int)ClickPlace.X,(int)ClickPlace.Y,
                Image.Width,Image.Height);

            Data = new Color[Image.Width * Image.Height];
            Image.GetData(Data);
        }

        public void Update(GameTime gameTime)
        {
            ClickPlace.X = Mouse.GetState().X;
            ClickPlace.Y = Mouse.GetState().Y;

            Rectangle.X = (int)ClickPlace.X;
            Rectangle.Y = (int)ClickPlace.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, new Vector2(ClickPlace.X,ClickPlace.Y) , Color.White);
        }
    }
}