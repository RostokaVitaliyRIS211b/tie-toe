using System;
using System.Collections.Generic;
using tie_toe;
using Lines;
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
            List<line> lines = new List<line>();
            g.RenderWindow MainWindow = new g.RenderWindow(new w.VideoMode((uint)width_screen, (uint)height_screen), "Tie-Toe");
            MainWindow.KeyPressed += Window_KeyPressed;
            MainWindow.MouseButtonPressed += MainWindow_MouseButtonPressed;
            create_lines(width_screen,height_screen,out lines,side_of_cell);
            while (MainWindow.IsOpen)
            {
                mouse_pos=w.Mouse.GetPosition(MainWindow);
                MainWindow.Clear(g.Color.White);
                MainWindow.DispatchEvents();
                foreach (line line in lines)
                    MainWindow.Draw(line);
                MainWindow.Display();
            }
            Console.ReadKey();
            return 0;
        }
        private static void create_lines(int width_screen, int height_screen,out List<line> lines,int side_of_cell)
        {
            lines=new List<line>();
            for(int i = 0; i <= width_screen; i+=side_of_cell)
            {
                line line1 = new line();
                line1.point_one = new s.Vector2i(i, 0);
                line1.point_two = new s.Vector2i(i, height_screen);
                line1.color = new g.Color(0, 255, 255);
                lines.Add(line1);
            }
            for (int i = 0; i <= height_screen; i += side_of_cell)
            {
                line line1 = new line();
                line1.point_one = new s.Vector2i(0, i);
                line1.point_two = new s.Vector2i(width_screen, i);
                line1.color = new g.Color(0, 255, 255);
                lines.Add(line1);
            }
        }
        private static void MainWindow_MouseButtonPressed(object sender, w.MouseButtonEventArgs e)
        { 
           var window = (SFML.Window.Window)sender;
           if (e.Button == w.Mouse.Button.Left)
           {
              
           }
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