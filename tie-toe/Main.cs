using System;
using tie_toe;
using g = SFML.Graphics;
using a = SFML.Audio;
using w = SFML.Window;
using s = SFML.System;
namespace Main
{
    class Program
    {
        public static int Main()
        {
            int rank = 3, width_screen=600,height_screen=600;
            int side_of_cell = width_screen / rank;
            s.Vector2i mouse_pos = new s.Vector2i();
            g.RenderWindow MainWindow = new g.RenderWindow(new w.VideoMode((uint)width_screen, (uint)height_screen), "Tie-Toe");
            g.CircleShape circle = new g.CircleShape(30);
            circle.FillColor = g.Color.Blue;
            circle.Position = new s.Vector2f(1000, 700);
            MainWindow.KeyPressed += Window_KeyPressed;
            while (MainWindow.IsOpen)
            {
                mouse_pos=w.Mouse.GetPosition(MainWindow);
                MainWindow.Clear(g.Color.White);
                MainWindow.DispatchEvents();
                MainWindow.Display();
                //Console.WriteLine("GAY");
            }
            Console.ReadKey();
            return 0;
        }
        private static void Window_KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            var window = (SFML.Window.Window)sender;
            if (e.Code == SFML.Window.Keyboard.Key.Escape)
            {
                window.Close();
            }
        }
    }
}