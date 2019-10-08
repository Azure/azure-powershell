namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ColorStringBuilder
    {
        private readonly StringBuilder stringBuilder = new StringBuilder();

        private readonly Stack<Color> colorStack = new Stack<Color>();

        public override string ToString()
        {
            return this.stringBuilder.ToString();
        }

        public ColorStringBuilder Append(string value)
        {
            this.stringBuilder.Append(value);

            return this;
        }

        public ColorStringBuilder Append(string value, Color color)
        {
            this.PushColor(color);
            this.stringBuilder.Append(value);
            this.PopColor();

            return this;
        }

        public ColorStringBuilder Append(object value)
        {
            this.stringBuilder.Append(value);

            return this;
        }

        public ColorStringBuilder Append(object value, Color color)
        {
            this.PushColor(color);
            this.stringBuilder.Append(value);
            this.PopColor();

            return this;
        }

        public ColorStringBuilder AppendLine()
        {
            this.stringBuilder.AppendLine();

            return this;
        }

        public ColorStringBuilder AppendLine(string value)
        {
            this.stringBuilder.AppendLine(value);

            return this;
        }

        public ColorStringBuilder AppendLine(string value, Color color)
        {
            this.PushColor(color);
            this.stringBuilder.AppendLine(value);
            this.PopColor();

            return this;
        }

        public ColorScope NewColorScope(Color color)
        {
            return new ColorScope(this, color);
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

        public class ColorScope: IDisposable
        {
            private readonly ColorStringBuilder builder;

            public ColorScope(ColorStringBuilder builder, Color color)
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

