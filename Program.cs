using System;

namespace LightstringExample
{
    abstract class Lightstring
    {
        protected Bulb[] bulbs;

        public Lightstring(int numberOfBulbs)
        {
            bulbs = new Bulb[numberOfBulbs];
            for (int i = 0; i < numberOfBulbs; i++)
            {
                bulbs[i] = new Bulb(i);
            }
        }

        public virtual string GetBulbState(int bulbNumber)
        {
            return bulbs[bulbNumber].IsOn() ? "on" : "off";
        }
    }

    class SimpleLightstring : Lightstring
    {
        public SimpleLightstring(int numberOfBulbs) : base(numberOfBulbs)
        {
        }

        public override string GetBulbState(int bulbNumber)
        {
            return base.GetBulbState(bulbNumber);
        }
    }

    class ColoredLightstring : Lightstring
    {
        private readonly Color[] colors = { Color.Red, Color.Yellow, Color.Green, Color.Blue };
        private readonly int colorCount = 4;

        public ColoredLightstring(int numberOfBulbs) : base(numberOfBulbs)
        {
            for (int i = 0; i < numberOfBulbs; i++)
            {
                int colorIndex = (i / colorCount) % colors.Length;
                bulbs[i] = new ColoredBulb(i, colors[colorIndex]);
            }
        }

        public override string GetBulbState(int bulbNumber)
        {
            return $"{base.GetBulbState(bulbNumber)}, color: {(bulbs[bulbNumber] as ColoredBulb)?.GetColor()}";
        }
    }

    class Bulb
    {
        protected readonly int serialNumber;

        public Bulb(int serialNumber)
        {
            this.serialNumber = serialNumber;
        }

        public virtual bool IsOn()
        {
            return (DateTime.Now.Minute % 2 == 0 && serialNumber % 2 == 0)
                || (DateTime.Now.Minute % 2 == 1 && serialNumber % 2 == 1);
        }
    }

    class ColoredBulb : Bulb
    {
        private readonly Color color;

        public ColoredBulb(int serialNumber, Color color) : base(serialNumber)
        {
            this.color = color;
        }

        public string GetColor()
        {
            return color.ToString();
        }
    }

    enum Color
    {
        Red,
        Yellow,
        Green,
        Blue
    }

    class Program
    {
        static void Main(string[] args)
        {
            Lightstring simpleLightstring = new SimpleLightstring(10);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Bulb {i + 1}: {simpleLightstring.GetBulbState(i)}");
            }

            Lightstring coloredLightstring = new ColoredLightstring(10);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Bulb {i + 1}: {coloredLightstring.GetBulbState(i)}");
            }

            Console.ReadLine();
        }
    }
}