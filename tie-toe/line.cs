using g = SFML.Graphics;
using w = SFML.Window;
using s = SFML.System;
namespace Lines
{
    internal class line:g.Drawable
    {
        s.Vector2i point_one { get; set; }
        s.Vector2i point_two { get; set; }
        g.Color color { get; set; }
        public void Draw(g.RenderTarget target, g.RenderStates states)
        {
            g.VertexArray lines=new g.VertexArray();
            g.Vertex one = new g.Vertex(((s.Vector2f)point_one),color);
            g.Vertex two = new g.Vertex(((s.Vector2f)point_two), color);
            lines.Append(one);
            lines.Append(two);
            states = g.RenderStates.Default;
            target.Draw(lines,states);
        }

    }
}
