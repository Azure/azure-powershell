namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters
{
    using System;

    public class Color : IEquatable<Color>
    {
        private const char Esc = (char)27;

        private readonly string colorCode;

        public static Color Red => new Color($"{Esc}[0;31m");

        public static Color Green => new Color($"{Esc}[0;32m");

        public static Color Yellow => new Color($"{Esc}[0;33m");

        public static Color Blue => new Color($"{Esc}[0;34m");

        public static Color Cyan => new Color($"{Esc}[0;36m");

        public static Color Reset => new Color($"{Esc}[0m");

        private Color(string colorCode)
        {
            this.colorCode = colorCode;
        }

        public override string ToString()
        {
            return this.colorCode;
        }

        public bool Equals(Color other)
        {
            return other != null && string.Equals(colorCode, other.colorCode);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == this.GetType() && Equals((Color)obj);
        }

        public override int GetHashCode()
        {
            return colorCode != null ? colorCode.GetHashCode() : 0;
        }
    }
}
