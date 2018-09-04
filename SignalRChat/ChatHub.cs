using System;
using System.Diagnostics;
using System.IO;
using System.Web;
using Microsoft.AspNet.SignalR;
namespace SignalRChat
{
    public class ChatHub : Hub
    {
        public void Send(string player, string bidprice, string buyprice)
        {
            File.WriteAllText(@"player.ahk", "");
            StreamWriter sw = new StreamWriter("player.ahk");
            sw.WriteLine("Sleep, 400");
            char[] playerProcessing = player.ToCharArray();
            sw.WriteLine("WinActivate, Madden NFL 19 ahk_class Frostbite ahk_exe Madden19.exe");
            foreach (char c in playerProcessing)
            {
                string curChar = c.ToString();
                if (c == ' ')
                {
                    curChar = "Space";
                }
                sw.WriteLine("Send, {" + curChar + " Down}");
                sw.WriteLine("Sleep, 200");
                sw.WriteLine("Send, {" + curChar + " Up}");
                sw.WriteLine("Sleep, 200");
            }
            sw.WriteLine("dark  := \"bid" + bidprice + "buy" + buyprice + "dark.PNG\"");
            sw.WriteLine("light := \"bid" + bidprice + "buy" + buyprice + "light.PNG\"");
            sw.Close();
            Process.Start("mainprocess.ahk");
        }
    }
}