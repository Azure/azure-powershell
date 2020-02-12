namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ColoredStringBuilder
    {
        private readonly StringBuilder stringBuilder = new StringBuilder();

        private readonly Stack<Color> colorStack = new Stack<Color>();

        public override string ToString()
        {
            return stringBuilder.ToString();
        }

        public ColoredStringBuilder Append(string value)
        {
            this.stringBuilder.Append(value);

            return this;
        }

        public ColoredStringBuilder Append(string value, Color color)
        {
            this.PushColor(color);
            this.Append(value);
            this.PopColor();

            return this;
        }

        public ColoredStringBuilder Append(object value)
        {
            this.stringBuilder.Append(value);

            return this;
        }

        public ColoredStringBuilder Append(object value, Color color)
        {
            this.PushColor(color);
            this.Append(value);
            this.PopColor();

            return this;
        }

        public ColoredStringBuilder AppendLine()
        {
            this.stringBuilder.AppendLine();

            return this;
        }

        public ColoredStringBuilder AppendLine(string value)
        {
            this.stringBuilder.AppendLine(value);

            return this;
        }

        public ColoredStringBuilder AppendLine(string value, Color color)
        {
            this.PushColor(color);
            this.AppendLine(value);
            this.PopColor();

            return this;
        }

        public AnsiColorScope NewColorScope(Color color)
        {
            return new AnsiColorScope(this, color);
        }

        private void PushColor(Color color)
        {
            this.colorStack.Push(color);
            this.stringBuilder.Append(color);
        }

        private void PopColor()
        {
            this.colorStack.Pop();
            this.stringBuilder.Append(this.colorStack.Count > 0 ? this.colorStack.Peek() : Color.Reset);
        }

        public class AnsiColorScope: IDisposable
        {
            private readonly ColoredStringBuilder builder;

            public AnsiColorScope(ColoredStringBuilder builder, Color color)
            {
                this.builder = builder;
                this.builder.PushColor(color);
            }

            public void Dispose()
            {
                this.builder.PopColor();
            }
        }
    }
}
