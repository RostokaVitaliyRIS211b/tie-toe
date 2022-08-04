using g = SFML.Graphics;
using s = SFML.System;
using sus = System;
namespace Text
{
    public class Textbox: g.Drawable
    {
        protected g.RectangleShape rect;
        protected g.Text text;
        protected g.Font font;
        public Textbox() 
        { 
            rect = new g.RectangleShape();
            text = new g.Text();
            text.OutlineThickness = 0;
            font = new g.Font("C:/Users/Динозавр/source/repos/tie-toe/tie-toe/ofont.ru_Impact.ttf"); text.Font = font; 
        }
        public Textbox(g.RectangleShape rect, g.Text text, g.Font font)
        {
            font = new g.Font("C:/Users/Динозавр/source/repos/tie-toe/tie-toe/ofont.ru_Impact.ttf"); text.Font = font;
            this.rect = rect;
            this.text = text;
            this.font = font;
        }
        public void set_color_text(g.Color color)
        {
            text.FillColor=color;
        }
        public void set_Fill_color_rect(g.Color color)
        {
            rect.FillColor = color;
        }
        public void set_outline_color_rect(g.Color color)
        {
            rect.OutlineColor = color;
        }
        public void set_outline_thickness_rect(float thick)
        {
            rect.OutlineThickness = thick;
        }
        public void set_size_rect(s.Vector2f size)
        {
            rect.Size = size;
            rect.Origin = new s.Vector2f(size.X / 2, size.Y / 2);
        }
        public void set_pos(float x, float y)
        {
            //sus.Console.WriteLine("rect {0} {1}", rect.Origin, rect.Size);
            text.Origin = new s.Vector2f(text.GetGlobalBounds().Width / 2f, text.GetGlobalBounds().Height / 2f+text.CharacterSize/6f);// магические числа на
            rect.Position = new s.Vector2f(x, y);
            text.Position = new s.Vector2f(x, y);
            sus.Console.WriteLine("text {0} {1} {2}", text.Origin, text.GetGlobalBounds().Width, text.GetGlobalBounds().Top);
        }
        public void set_size_text(int size)
        {
            text.CharacterSize = (uint)size;
          
        }
        public void set_string(string str)
        {
            text.DisplayedString = str;
        }
        public void Draw(g.RenderTarget target, g.RenderStates states)
        {
            target.Draw(rect, states);
            target.Draw(text, states);
        }
    }
}
