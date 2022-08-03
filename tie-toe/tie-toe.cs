using g = SFML.Graphics;
using s = SFML.System;
using System.Collections.Generic;
namespace tie_toe
{
    public  class Sigh : g.Drawable
    {
        public g.Image img { get; set; }
        public g.Texture texture { get; set; }
        public g.Sprite sprite { get; set; }
        public int player { get; set; }
        public Sigh()
        {
            player = 0;
        }
        public Sigh(ref Sigh sigh)
        {
            img = sigh.img;
            texture = sigh.texture;
            sprite = sigh.sprite;
            player = sigh.player;
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
        public s.Vector2f get_pos()
        {
            return sprite.Position;
        }
        public void set_pos(float x,float y)
        {
            sprite.Position = new s.Vector2f(x, y);
        }
        public void set_pos(s.Vector2f vec)
        {
            sprite.Position = vec;
        }
        public void Draw(g.RenderTarget target,g.RenderStates states )
        {
            states = g.RenderStates.Default;
            target.Draw(sprite, states);
        }
    }

}
