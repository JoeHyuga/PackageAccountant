using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ChartHelp
    {
        public List<string> GetRandomColor(int count)
        {
            List<string> list = new List<string>();
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                int index = random.Next(0, 214);
                string color = ColorCode(index);
                while (list.Contains(color)) {
                    index = random.Next(0, 214);
                    color = ColorCode(index);
                }
                list.Add(color);
            }

            return list;
        }

        public string ColorCode(int index)
        {
            StringBuilder str = new StringBuilder();
            str.Append("#990033,#CC6699,#FF6699,");
            str.Append("#FF3399,#FF9999,#FF99CC,#FF0099,#CC3366,#FF0033,#CC3399,#3333CC,#3399CC,#6600CC,");
            str.Append("#FF66FF,#CC33CC,#CC00FF,#FF33FF,#CC99FF,#9900CC,#FF00FF,#CC66FF,#990099,#CC0099,");
            str.Append("#CC33FF,#CC99CC,#990066,#FFCC00,#CC9000,#663300,#CC66CC,#CC00CC,#663366,");
            str.Append("#660099,#666FF,#000CC,#9933CC,#666699,#660066,#333366,#0066CC,#9900FF,#333399,");
            str.Append("#99CCFF,#9933FF,#330099,#6699FF,#9966CC,#3300CC,#003366,#330033,#3300FF,#6699CC,");
            str.Append("#663399,#3333FF,#006699,#0099CC,#6600FF,#3366CC,#003399,#6633FF,#000066,#9966FF,");
            str.Append("#0033FF,#66CCFF,#330066,#6633CC,#FF3366,#993366,#CC0066,#CC0033,#FF0066,#0066FF,#3366FF,#3399FF,");
            str.Append("#0099FF,#CCCCFF,#000033,#33CCFF,#9999FF,#0000FF,#00CCFF,#9999CC,#000099,#6666CC,");
            str.Append("#0033CC,#FFFFCC,#FF0000,#FF6600,#663333,#CC6666,#FF6666,#993399,#FFFF99,");
            str.Append("#FFCC66,#FF9900,#FF9966,#CC3300,#996666,#FFCCCC,#660000,#FF3300,#FF6666,#FFCC33,");
            str.Append("#CC6600,#FF6633,#996633,#CC9999,#FF3333,#990000,#CC9966,#FFFF33,#CC9933,#993300,");
            str.Append("#FF9933,#330000,#993333,#CC3333,#CC0000,#FFCC99,#FFFF00,#996600,#CC6633,");
            str.Append("#99FFFF,#33CCCC,#00CC99,#666633,#669999,#00FFCC,#336633,#33CC66,#CCC33,#66FFFF,");
            str.Append("#66CCCC,#66FFCC,#66FF66,#009933,#00CC33,#66FF00,#336600,#33300,#33FFFF,#339999,");
            str.Append("#99FFCC,#339933,#33FF66,#33CC33,#99FF00,#669900,#666600,#00FFFF,#336666,#00FF99,");
            str.Append("#99CC99,#00FF66,#66FF33,#66CC00,#99CC00,#999933,#00CCCC,#006666,#339966,#66FF99,");
            str.Append("#CCFFCC,#00FF00,#00CC00,#CCFF66,#CCCC66,#009999,#003333,#006633,#33FF99,#CCFF99,");
            str.Append("#66CC33,#33CC00,#CCFF33,#99FF66,#99FF99,#009966,#33FF33,#33FF00,#99CC33,#006600,");
            str.Append("#339900,#CCFF00,#999966,#99CCCC,#33FFCC,#669966,#00CC66,#99FF33,#003300,#99CC66,");
            str.Append("#999900,#CCCC99,#CCFFFF,#33CC99,#66CC66,#66CC99,#00FF33,#009900,#669900,#669933,");
            str.Append("#FFFFF,#CCCCCC,#999999,#666666,#333333,#000000,#CCCC00,#FF66CC,#FF33CC,#FFCCFF,#FF99FF,#FF00CC");
            var arry=str.ToString().Split(',');
            return arry[index];
        }
    }
}
