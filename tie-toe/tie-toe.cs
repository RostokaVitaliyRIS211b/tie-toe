﻿using g = SFML.Graphics;

namespace tie_toe
{
    internal  class Sigh : g.Drawable
    {
        public g.Image img { get; set; }
        public g.Texture texture { get; set; }
        public g.Sprite sprite { get; set; }
        public int player { get; set; }
        public Sigh()
        {
            player = 0;
        }
        public Sigh(g.Image img)
        {
            player = 0;
            this.img = img;
            texture.Update(img);
            sprite.Texture=texture;
        }
        public Sigh(string name)
        {
            player = 0;
            img = new g.Image(name);
            texture = new g.Texture(img);
            sprite = new g.Sprite(texture);
        }

        public void Draw(g.RenderTarget target,g.RenderStates states )
        {
            states = g.RenderStates.Default;
            target.Draw(sprite, states);
        }
    }

}
