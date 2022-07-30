using SFML.Graphics;
using System;
using g = SFML.Graphics;

namespace tie_toe
{
    internal  class Sigh : g.Drawable
    {
        g.Image img { get; set; }
        g.Texture texture { get; set; }
        g.Sprite sprite { get; set; }
        int player { get; set; }
        public Sigh()
        {
            player = 0;
        }
        public Sigh(Image img)
        {
            player = 0;
            this.img = img;
            texture.Update(img);
            sprite.Texture=texture;
        }
        public Sigh(string name)
        {
            player = 0;
            img = new Image(name);
            texture = new Texture(img);
            sprite = new Sprite(texture);
        }

        public void Draw(g.RenderTarget target,g.RenderStates states )
        {
            states = g.RenderStates.Default;
            target.Draw(sprite, states);
        }
    }

}
