//using System;
using System.Collections.Generic;
using tie_toe;
using Lines;
using Text;
using Polzet;
using g = SFML.Graphics;
using a = SFML.Audio;
using w = SFML.Window;
using s = SFML.System;
using System.Threading;
namespace Main
{
    public class Program
    {
        public static List<Sigh> sighs = new List<Sigh>();
        public static List<Textbox> textboxes = new List<Textbox>();
        public static List<HPolzynok> polzynoks = new List<HPolzynok>();
        static List<line> lines = new List<line>();
        public static g.Text text = new g.Text();
        protected static g.Font font = new g.Font("C:/Users/Динозавр/source/repos/tie-toe/tie-toe/ofont.ru_Impact.ttf");
        static int rank = 3/*количетво ячеек стороны квадартного игрового поля */, width_screen = 600, height_screen = 600, count_of_win = 3/*количество знаков в ряд нужное для победы */,player_win=0;
        static int side_of_cell = width_screen / rank/* размер одной клетки игрового поля*/;
        public static int player = 1;
        public static bool menu = true,settings=false;
        public static int Main()
        {
            
            //s.Vector2i mouse_pos = new s.Vector2i();
            
            Textbox textbox = new Textbox();
            textbox.set_size_text(32);
            textbox.set_string("START");
            textbox.set_color_text(g.Color.Black);
            textbox.set_outline_color_rect(g.Color.Black);
            textbox.set_outline_thickness_rect(2);
            textbox.set_Fill_color_rect(new g.Color(0,162,232));
            textbox.set_size_rect(new s.Vector2f(150, 60));
            textbox.set_pos(300, 200);
            Textbox textbox2 = new Textbox(ref textbox);
            textbox2.set_string("SETTINGS");
            textbox2.set_pos(300, 300);
            Textbox textbox3 = new Textbox(ref textbox);
            textbox3.set_string("EXIT");
            textbox3.set_pos(300,400);
            Textbox textbox4 = new Textbox();
            textbox4.set_size_text(48);
            textbox4.set_color_text(g.Color.Black);
            textbox4.set_string("Tie-toe");
            textbox4.set_pos(300, 100);
            textboxes.Add(textbox);
            textboxes.Add(textbox2);
            textboxes.Add(textbox3);
            textboxes.Add(textbox4);
            HPolzynok pol = new HPolzynok();
            pol.set_Fill_color_rect(new g.Color(0, 162, 232));
            pol.set_Outline_color_rect(g.Color.Black);
            pol.set_rect_outline_thickness(2);
            pol.set_size_rect(200, 20);
            pol.set_pos_polz(300, 300);
            pol.set_rad_act(20);
            pol.set_Fillcolor_act(new g.Color(0, 162, 232));
            pol.set_Outline_thickness_act(2);
            pol.set_outline_color_act(g.Color.Black);
            pol.change_val_func(test_val);
            polzynoks.Add(pol);
            text.FillColor = g.Color.Black;
            text.CharacterSize = 32;
            text.DisplayedString = "Count of win = " + count_of_win.ToString();
            text.Font = font;
            text.Origin = new s.Vector2f(text.GetGlobalBounds().Width / 2f, text.GetGlobalBounds().Height / 2f + text.CharacterSize / 6f);
            text.Position = new s.Vector2f(300, 240);
            g.RenderWindow MainWindow = new g.RenderWindow(new w.VideoMode((uint)width_screen, (uint)height_screen), "Tie-Toe");
            MainWindow.KeyPressed += Window_KeyPressed;// запрягаем делегатов
            MainWindow.MouseButtonPressed += MainWindow_MouseButtonPressed;
            MainWindow.MouseMoved += MainWindow_MouseMoved;
            create_lines(width_screen,height_screen,out lines,side_of_cell);
            while (MainWindow.IsOpen)
            {
                
                if (menu)
                {
                    MainWindow.Clear(g.Color.White);
                    MainWindow.DispatchEvents();
                    if (!settings)
                    {
                        foreach (Textbox textbox1 in textboxes)
                            MainWindow.Draw(textbox1);
                    }
                    else
                    {
                        foreach (HPolzynok polzynok in polzynoks)
                            MainWindow.Draw(polzynok);
                        MainWindow.Draw(text);
                    }
                    MainWindow.Display();
                }
                else
                {
                    MainWindow.Clear(g.Color.White);
                    MainWindow.DispatchEvents();
                    foreach (Sigh sigh in sighs)
                        MainWindow.Draw(sigh);
                    foreach (line line in lines)
                        MainWindow.Draw(line);
                    MainWindow.Display();
                    if (sighs.Count == rank * rank | player_win != 0)
                    {
                        Thread.Sleep(1500);// надо добавить подстветку тех когда выигрывает чел
                        //sus.Console.WriteLine("gay");
                        sighs.Clear();
                        player_win = 0;
                        //menu = true;
                    }
                  
                }
               

            }
            //Console.ReadKey();
            return 0;
        }

        private static void MainWindow_MouseMoved(object sender, w.MouseMoveEventArgs e)
        {
            var window = (SFML.Window.Window)sender;
            if (settings)
            {
                foreach (HPolzynok polzynok in polzynoks)
                {
                    if (polzynok.contains(w.Mouse.GetPosition(window)) & w.Mouse.IsButtonPressed(w.Mouse.Button.Left))
                    {
                        polzynok.move(w.Mouse.GetPosition(window).X);
                        count_of_win = polzynok.get_value();
                        text.DisplayedString = "Count of win = " + count_of_win.ToString();
                        break;
                    }
                }
            }
        }

        private static int test_val(float x)
        {
            int count = 0;
            if (x >= 200 & x < 300)
                count = 3;
            else if (x >= 300 & x < 370)
                count = 4;
            else if (x >= 370)
                count = 5;
            return count;
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
        private static void MainWindow_MouseButtonPressed(object sender, w.MouseButtonEventArgs e)// обработка событий мыши
        { 
           var window = (SFML.Window.Window)sender;
            if(menu)
            {
                if(!settings)
                {
                    foreach (Textbox textbox in textboxes)
                    {
                        if (textbox.contains(w.Mouse.GetPosition(window)) & e.Button == w.Mouse.Button.Left)
                        {
                            if (textbox.get_string() == "START")
                            {
                                menu = false;
                                if (count_of_win == 3)
                                    rank = 3;
                                if (count_of_win == 4)
                                    rank = 8;
                                if (count_of_win == 5)
                                    rank = 10;
                                side_of_cell = width_screen / rank;
                                create_lines(width_screen, height_screen, out lines, side_of_cell);
                            }
                            if (textbox.get_string() == "SETTINGS")
                                settings = true;
                            if (textbox.get_string() == "EXIT")
                                window.Close();
                            break;
                        }
                    }

                }
                else
                {
                   foreach(HPolzynok polzynok in polzynoks)
                   {
                        if(polzynok.contains(w.Mouse.GetPosition(window))&(e.Button == w.Mouse.Button.Left))
                        {
                            polzynok.move(w.Mouse.GetPosition(window).X);
                            break;
                        }
                   }
                }
               
            }
            else
            {
                if (e.Button == w.Mouse.Button.Left & w.Mouse.GetPosition(window).X / side_of_cell >= 0 & w.Mouse.GetPosition(window).Y / side_of_cell >= 0 & sighs.Find(sigh => (s.Vector2i)sigh.sprite.Position == new s.Vector2i((w.Mouse.GetPosition(window).X / side_of_cell) * side_of_cell, (w.Mouse.GetPosition(window).Y / side_of_cell) * side_of_cell)) == null)// если игрок кликнул на пустую не занятую клетку
                {
                    Sigh sigh = new Sigh();
                    sigh.player = player;
                    if (player == 1)
                        sigh.img = new g.Image("cross.png");
                    else
                        sigh.img = new g.Image("circle.png");
                    sigh.texture = new g.Texture(sigh.img);
                    sigh.sprite = new g.Sprite(sigh.texture)
                    {
                        Scale = new s.Vector2f(side_of_cell / 200f, side_of_cell / 200f)
                    };
                    sigh.set_pos(new s.Vector2f((w.Mouse.GetPosition(window).X / side_of_cell) * side_of_cell, (w.Mouse.GetPosition(window).Y / side_of_cell) * side_of_cell));
                    sighs.Add(sigh);
                    ++player;
                    if (player == 3)
                        player = 1;  /*Console.WriteLine(sigh.sprite.Scale);*/

                }
                player_win = is_win();
            }
        }
        private static void Window_KeyPressed(object sender, SFML.Window.KeyEventArgs e)// обработка событий клавиатуры
        {
            var window = (SFML.Window.Window)sender;
            if (e.Code == SFML.Window.Keyboard.Key.Escape)
            {
                if(menu & !settings)
                window.Close();
                if (!menu & !settings)
                {
                    menu = true;
                    sighs.Clear();
                    player_win = 0;
                    player = 1;
                }
                if(settings)
                {
                    menu = true;
                    settings = false;
                }
                    
            }
        }
        private delegate void win_player(Sigh sighc, ref int player);
        private static int is_win()// проверка выиграл ли ктото из игроков
        {
            win_player a = new win_player(compare1);// зарпрягаем делегат
            a += compare2;
            a += compare3;
            a += compare4;
            int player = 0;

            //foreach (Sigh sigh in sighs)
            //    if(sigh.player==1)
            //        Console.WriteLine("position {0}", sigh.sprite.Position);
            
            foreach (Sigh sigh in sighs)// для каждого из существующих знаков проверяем не состоит ли этот знак в ряде с количеством знаков count_of_win
            {
                a(sigh, ref player);
                if (player != 0)
                    break;
            }

            //foreach (Sigh sigh in sighs)
            //    Console.WriteLine("position after {0}", sigh.sprite.Position);
            return player;
        }
        private static void compare1(Sigh sighc, ref int player)
        {
            int count_of_finds = 0, difference = side_of_cell;
            s.Vector2f pos = new s.Vector2f();// позиция искомого знака
            pos = sighc.sprite.Position;
            for (int i=0;i<count_of_win & player == 0;++i)
            {
                if (sighs.Find(sigh => sigh.sprite.Position == pos & sigh.player == sighc.player) != null)// ищем знаки распологающийся сверху справа по диагонали от текущего знака(крестика или нолика)
                    ++count_of_finds;
                pos.X += difference;
                pos.Y -= difference;
            }
            if (count_of_finds == count_of_win)
                player = sighc.player;
            //Console.WriteLine("compare1 {0}", count_of_finds);

        }
        private static void compare2(Sigh sighc, ref int player)// ищем знаки сверху текущего
        { 
            int count_of_finds = 0, difference = side_of_cell;
            s.Vector2f pos = new s.Vector2f();
            pos = sighc.sprite.Position;
            for (int i = 0; i < count_of_win & player == 0; ++i)
            {
                if (sighs.Find(sigh => sigh.sprite.Position == pos & sigh.player==sighc.player) != null)
                    ++count_of_finds;
                pos.Y -= difference;
            }
            if (count_of_finds == count_of_win)
                player = sighc.player;
            //Console.WriteLine("compare2 {0}", player);
        }
        private static void compare3(Sigh sighc, ref int player)// ищем знаки слева сверху по диагонали
        {
            int count_of_finds = 0, difference = side_of_cell;
            s.Vector2f pos = new s.Vector2f();
            pos = sighc.sprite.Position;
            for (int i = 0; i < count_of_win & player == 0; ++i)
            {
                if (sighs.Find(sigh => sigh.sprite.Position == pos & sigh.player == sighc.player) != null)
                    ++count_of_finds;
                pos.X -= difference;
                pos.Y -= difference;
            }
            if (count_of_finds == count_of_win)
                player = sighc.player;
            //Console.WriteLine("compare3 {0}", player);
        }
        private static void compare4(Sigh sighc, ref int player)// ищем знаки слева от текущего
        {
            int count_of_finds = 0, difference = side_of_cell;
            s.Vector2f pos = new s.Vector2f();
            pos = sighc.sprite.Position;
            for (int i = 0; i < count_of_win & player == 0; ++i)
            {
                if (sighs.Find(sigh => sigh.sprite.Position == pos & sigh.player == sighc.player) != null)
                    ++count_of_finds;
                pos.X -= difference;
            }
            if (count_of_finds == count_of_win)
                player = sighc.player;
            //Console.WriteLine("compare4 {0}", player);
        }


    }
}