﻿using System;
using System.Collections.Generic;
using tie_toe;
using Lines;
using g = SFML.Graphics;
using a = SFML.Audio;
using w = SFML.Window;
using s = SFML.System;
using System.Threading;
namespace Main
{
    public class Program
    {
        public static List<Sigh> sighs =new List<Sigh>();
        static int rank = 3, width_screen = 600, height_screen = 600, count_of_win = 3,player_win=0;
        static int side_of_cell = width_screen / rank;
        public static int player = 1;     
        public static int Main()
        {
            
            //s.Vector2i mouse_pos = new s.Vector2i();
            List<line> lines = new List<line>();
            g.RenderWindow MainWindow = new g.RenderWindow(new w.VideoMode((uint)width_screen, (uint)height_screen), "Tie-Toe");
            MainWindow.KeyPressed += Window_KeyPressed;
            MainWindow.MouseButtonPressed += MainWindow_MouseButtonPressed;
            create_lines(width_screen,height_screen,out lines,side_of_cell);
            while (MainWindow.IsOpen)
            {
                MainWindow.Clear(g.Color.White);
                MainWindow.DispatchEvents();
                foreach (Sigh sigh in sighs)
                    MainWindow.Draw(sigh);
                foreach (line line in lines)
                    MainWindow.Draw(line);
                MainWindow.Display();
                if(sighs.Count==rank*rank | player_win!=0)
                {
                    Console.WriteLine("gay");
                    Thread.Sleep(1000);
                    sighs.Clear();
                }
            }
            Console.ReadKey();
            return 0;
        }
        private static void create_lines(int width_screen, int height_screen,out List<line> lines,int side_of_cell)
        {
            lines=new List<line>();
            for(int i = 0; i <= width_screen; i+=side_of_cell)
            {
                line line1 = new line
                {
                    point_one = new s.Vector2i(i, 0),
                    point_two = new s.Vector2i(i, height_screen),
                    color = new g.Color(0, 255, 255)
                };
                lines.Add(line1);
            }
            for (int i = 0; i <= height_screen; i += side_of_cell)
            {
                line line1 = new line
                {
                    point_one = new s.Vector2i(0, i),
                    point_two = new s.Vector2i(width_screen, i),
                    color = new g.Color(0, 255, 255)
                };
                lines.Add(line1);
            }
        }
        private static void MainWindow_MouseButtonPressed(object sender, w.MouseButtonEventArgs e)
        { 
           var window = (SFML.Window.Window)sender;
           if (e.Button == w.Mouse.Button.Left & w.Mouse.GetPosition(window).X/side_of_cell>=0 & w.Mouse.GetPosition(window).Y / side_of_cell >= 0)
           {
              Sigh sigh = new Sigh();
              sigh.player = player;
              if (player==1)
                sigh.img = new g.Image("C:/Users/Динозавр/source/repos/tie-toe/tie-toe/cross.png");
              else
                sigh.img = new g.Image("C:/Users/Динозавр/source/repos/tie-toe/tie-toe/circle.png");
                sigh.texture = new g.Texture(sigh.img);
                sigh.sprite = new g.Sprite(sigh.texture)
                {
                    Scale = new s.Vector2f(side_of_cell / 200, side_of_cell / 200)
                };
                sigh.set_pos(new s.Vector2f((w.Mouse.GetPosition(window).X / side_of_cell) * side_of_cell, (w.Mouse.GetPosition(window).Y / side_of_cell) * side_of_cell));
                sighs.Add(sigh);
                ++player;
                if (player == 3)
                    player = 1;
           }
            player_win = is_win();
        }
        private static void Window_KeyPressed(object sender, SFML.Window.KeyEventArgs e)
        {
            var window = (SFML.Window.Window)sender;
            if (e.Code == SFML.Window.Keyboard.Key.Escape)
            {
                window.Close();
            }
        }
        private delegate void win_player(Sigh sighc, ref int player);
        private static int is_win()
        {
            win_player a = new win_player(compare1);
            a += compare2;
            a += compare3;
            a += compare4;
            int player = 0;
           
            foreach (Sigh sigh in sighs)
                Console.WriteLine("position before {0}",sigh.sprite.Position);
            
            foreach (Sigh sigh in sighs)
            {
                a(sigh, ref player);
                if (player != 0)
                    break;
            }

            foreach (Sigh sigh in sighs)
                Console.WriteLine("position after {0}", sigh.sprite.Position);
            return player;
        }
        private static void compare1(Sigh sighc, ref int player)
        {
            int count_of_finds = 0, difference = side_of_cell;
            s.Vector2f pos = new s.Vector2f();
            pos = sighc.position;
            for (int i=0;i<count_of_win;++i)
            {
                pos.X += difference;
                pos.Y -= difference;
                if (sighs.Find(sigh => sigh.position == pos) != null)
                    ++count_of_finds;
            }
            if (count_of_finds == count_of_win)
                player = sighc.player;

            //Console.WriteLine("compare1 {0}" , player);
        }
        private static void compare2(Sigh sighc, ref int player)
        { 
            int count_of_finds = 0, difference = side_of_cell;
            s.Vector2f pos = new s.Vector2f();
            pos = sighc.position;
            for (int i = 0; i < count_of_win; ++i)
            {
                pos.Y -= difference;
                if (sighs.Find(sigh => sigh.position == pos) != null)
                    ++count_of_finds;
            }
            if (count_of_finds == count_of_win)
                player = sighc.player;
            //Console.WriteLine("compare2 {0}", player);
        }
        private static void compare3(Sigh sighc, ref int player)
        {
            int count_of_finds = 0, difference = side_of_cell;
            s.Vector2f pos = new s.Vector2f();
            pos = sighc.position;
            for (int i = 0; i < count_of_win; ++i)
            {
                pos.X -= difference;
                pos.Y -= difference;
                if (sighs.Find(sigh => sigh.position == pos) != null)
                    ++count_of_finds;
            }
            if (count_of_finds == count_of_win)
                player = sighc.player;
            //Console.WriteLine("compare3 {0}", player);
        }
        private static void compare4(Sigh sighc, ref int player)
        {
            int count_of_finds = 0, difference = side_of_cell;
            s.Vector2f pos = new s.Vector2f();
            pos = sighc.position;
            for (int i = 0; i < count_of_win; ++i)
            {
                pos.X -= difference;
                if (sighs.Find(sigh => sigh.position == pos) != null)
                    ++count_of_finds;
            }
            if (count_of_finds == count_of_win)
                player = sighc.player;
            //Console.WriteLine("compare4 {0}", player);
        }


    }
}