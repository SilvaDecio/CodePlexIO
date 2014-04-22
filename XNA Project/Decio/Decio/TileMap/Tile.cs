using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Decio.TileMap
{
    class Tile
    {
        public Texture2D Image;

        public bool IsPassable;
       
        public Tile(Texture2D image , bool passable) 
        {
            Image = image;

            IsPassable = passable;
        }

        public void Draw(SpriteBatch spriteBatch , Vector2 Position)
        {
            spriteBatch.Draw(Image, Position, Color.White);
        }
    }
}