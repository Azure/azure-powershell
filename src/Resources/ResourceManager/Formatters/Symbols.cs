namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters
{
    public class Symbol
    {
        private readonly char character;

        public static Symbol WhiteSpace => new Symbol(' ');

        public static Symbol Quote => new Symbol('"');

        public static Symbol Colon => new Symbol(':');

        public static Symbol LeftSquareBracket => new Symbol('[');

        public static Symbol RightSquareBracket => new Symbol(']');
        
        public static Symbol Dot => new Symbol('.');

        public static Symbol Equal => new Symbol('=');

        public static Symbol Asterisk => new Symbol('*');

        public static Symbol Plus => new Symbol('+');

        public static Symbol Minus => new Symbol('-');

        public static Symbol Tilde => new Symbol('~');

        public static Symbol ExclamationPoint => new Symbol('!');

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
