using g = SFML.Graphics;
using s = SFML.System;
using sus=System;
namespace Polzet
{
    public class HPolzynok:g.Drawable
    {
        protected g.RectangleShape rect;
        protected g.RectangleShape p;
        protected g.RectangleShape p1;
        protected g.CircleShape end1;
        protected g.CircleShape end2;
        protected g.CircleShape active;
        protected int value;
        protected delegate float coord(float x);
        protected delegate int val(float x);
        protected coord mvf;
        protected val v;
        protected float standart_func(float x)
        {
            return x >= rect.Position.X-rect.Size.X/2 & x <= rect.Position.X+rect.Size.X/2 ? x : active.Position.X;
        }
        protected int vl(float x)
        {
            return (int)(x-rect.Position.X);
        }


        public HPolzynok()
        {
            rect = new g.RectangleShape();
            end1 = new g.CircleShape();
            end2 = new g.CircleShape();
            p = new g.RectangleShape();
            p1 = new g.RectangleShape();
            active = new g.CircleShape();
            mvf += standart_func;
            v += vl;
            value = 0;
        }
        public void set_Fill_color_rect(g.Color color)
        {
            rect.FillColor = color;
            end1.FillColor = color;
            end2.FillColor = color;
            p.FillColor = color;
            p1.FillColor = color;
        }
        public void set_size_rect(float x,float y)
        {
            rect.Size = new s.Vector2f(x - y, y);
            rect.Origin = new s.Vector2f((x-y)/2, y / 2);
            end1.Radius = y/2;
            end1.Origin = new s.Vector2f(y/2, y/2);
            end2.Radius = y/2;
            end2.Origin = new s.Vector2f(y/2, y/2);
            p.Size = new s.Vector2f(y/2 + rect.OutlineThickness , y);
            p.Origin = new s.Vector2f(0, y / 2);
            p1.Size = new s.Vector2f(y/2 + rect.OutlineThickness, y);
            p1.Origin = new s.Vector2f(y/2 + rect.OutlineThickness, y / 2);
        }
        public void set_rect_outline_thickness(float ou)
        {
            rect.OutlineThickness = ou;
            end1.OutlineThickness = ou;
            end2.OutlineThickness = ou;
            p.Size = new s.Vector2f(p.Size.X+ou,p.Size.Y);
            p1.Size = new s.Vector2f(p1.Size.X + ou, p1.Size.Y);
            p1.Origin = new s.Vector2f(p1.Origin.X + ou,p1.Origin.Y);
        }
        public void set_Outline_color_rect(g.Color color)
        {
            rect.OutlineColor = color;
            end1.OutlineColor = color;
            end2.OutlineColor = color;
        }
        public void set_pos_polz(float x, float y)
        {
            rect.Position = new s.Vector2f(x, y);
            end1.Position = new s.Vector2f(x-rect.Size.X/2, y);
            end2.Position = new s.Vector2f(x + rect.Size.X / 2, y);
            p.Position = new s.Vector2f(x - rect.Size.X / 2, y);
            p1.Position = new s.Vector2f(x + rect.Size.X / 2, y);
            active.Position = new s.Vector2f(x - rect.Size.X / 2, y);
        }
        public void set_rad_act(float rad)
        {
            active.Radius = rad;
            active.Origin = new s.Vector2f(rad, rad);
        }
        public void set_Fillcolor_act(g.Color color)
        {
            active.FillColor = color;
        }
        public void set_outline_color_act(g.Color color)
        {
            active.OutlineColor = color;
        }
        public void set_Outline_thickness_act(float ou)
        {
            active.OutlineThickness = ou;
        }
        public int get_value()
        {
            return value;
        }
        public void change_func(sus.Func<float,float> func)
        {
            mvf = new coord(func);//очищаем делегат от всех прочих функций и заносим одну новую
            //sus.Console.WriteLine("Length {0}", mvf.GetInvocationList().Length);
        }
        public void move(float x)
        {
            active.Position=new s.Vector2f(mvf(x),active.Position.Y);
            value = v(mvf(x));
        }
        public bool contains(s.Vector2i pos)
        {
            return rect.GetGlobalBounds().Contains(pos.X, pos.Y) | active.GetGlobalBounds().Contains(pos.X,pos.Y);
        }
        public bool contains(s.Vector2f pos)
        {
            return rect.GetGlobalBounds().Contains(pos.X, pos.Y) | active.GetGlobalBounds().Contains(pos.X, pos.Y);
        }
        public bool contains(float X,float Y)
        {
            return rect.GetGlobalBounds().Contains(X, Y) | active.GetGlobalBounds().Contains(X, Y);
        }
        public void Draw(g.RenderTarget target, g.RenderStates states)
        {
            target.Draw(rect, states);
            target.Draw(end1, states);
            target.Draw(end2, states);
            target.Draw(p1, states);
            target.Draw(p, states);
            target.Draw(active, states);
        }

    }
}
