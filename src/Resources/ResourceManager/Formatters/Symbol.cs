namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters
{
    public class Symbol
    {
        private readonly char character;

        public static Symbol WhiteSpace { get; } = new Symbol(' ');

        public static Symbol Quote { get; } = new Symbol('"');

        public static Symbol Colon { get; } = new Symbol(':');

        public static Symbol LeftSquareBracket { get; } = new Symbol('[');

        public static Symbol RightSquareBracket { get; } = new Symbol(']');
        
        public static Symbol Dot { get; } = new Symbol('.');

        public static Symbol Equal { get; } = new Symbol('=');

        public static Symbol Asterisk { get; } = new Symbol('*');

        public static Symbol Plus { get; } = new Symbol('+');

        public static Symbol Minus { get; } = new Symbol('-');

        public static Symbol Tilde { get; } = new Symbol('~');

        public static Symbol ExclamationPoint { get; } = new Symbol('!');

        private Symbol(char character)
        {
            this.character = character;
        }

        public override string ToString()
        {
            return this.character.ToString();
        }

        public char ToChar()
        {
            return this.character;
        }
    }
}
