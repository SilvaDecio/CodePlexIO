using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Decio.TileMap
{
    class TileMap
    {
        public string[,] Field;

        public Dictionary<string, Tile> TileDictionary;

        public const int Width = 2, Heigth = 2;

        public TileMap(ContentManager Content)
        {
            TileDictionary = new Dictionary<string, Tile>();
            TileDictionary.Add("Type1", new Tile(Content.Load<Texture2D>(
                "TileMap/Type1"),true));
            TileDictionary.Add("Type2", new Tile(Content.Load<Texture2D>(
                "TileMap/Type2"), false));
            TileDictionary.Add("Type3", new Tile(Content.Load<Texture2D>(
                "TileMap/Type3"), true));
            TileDictionary.Add("Type4", new Tile(Content.Load<Texture2D>(
                "TileMap/Type4"), true));

            Field = new string[Width, Heigth]
                {
                    {"Type1","Type2"},
                    {"Type3","Type4"}
                };
        }

        public Tile GenerateTile(int x , int y)
        {
            string local = Field[x, y];

            return TileDictionary[local];
        }

        public bool IsTilePassable(int x , int y)
        {
            if (GenerateTile(x,y).IsPassable)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Heigth; j++)
                {
                    Tile tileatual = GenerateTile(i, j);

                    tileatual.Draw(spriteBatch, new Vector2( i * tileatual.Image.Width, j * tileatual.Image.Height));
                }
            }
        }
    }
}