using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2048.Properties;

namespace _2048
{
   public struct Numbers
    {
        public int Number { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public object GetImage()
        {
            return Resources.ResourceManager.GetObject(Number.ToString());
        }

        public Numbers(int num=2, int x=0, int y=0)
        {
            Number = num;
            PositionX = x;
            PositionY = y;
        }

        public override string ToString()
        {
            return $"{Number} {PositionX} {PositionY}";
        }

        public static explicit operator Numbers(int i)
        {
            return  new Numbers(i);
        }
    }
}
