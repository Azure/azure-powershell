// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ColoredStringBuilder
    {
        private readonly StringBuilder stringBuilder = new StringBuilder();

        private readonly Stack<Color> colorStack = new Stack<Color>();

        private readonly List<string> indentStack = new List<string>();

        private bool atLineStart = true;

        public override string ToString()
        {
            return stringBuilder.ToString();
        }

        public ColoredStringBuilder Append(string value)
        {
            this.AppendWithIndent(value);

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
            this.AppendWithIndent(value?.ToString());

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
            this.atLineStart = true;

            return this;
        }

        public ColoredStringBuilder AppendLine(string value)
        {
            this.AppendWithIndent(value);
            this.stringBuilder.AppendLine();
            this.atLineStart = true;

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

        public void Insert(int index, string value)
        {
            if (index >= 0 && index <= this.stringBuilder.Length)
            {
                this.stringBuilder.Insert(index, value);
            }
        }

        public void InsertLine(int index, string value, Color color)
        {
            if (color != Color.Reset)
            {
                this.Insert(index, Color.Reset.ToString());
            }
            this.Insert(index, value + Environment.NewLine);
            if (color != Color.Reset)
            {
                this.Insert(index, color.ToString());
            }
        }

        public int GetCurrentIndex()
        {
            return this.stringBuilder.Length;
        }

        public void PushIndent(string indent)
        {
            this.indentStack.Add(indent);
        }

        public void PopIndent()
        {
            if (this.indentStack.Count > 0)
            {
                this.indentStack.RemoveAt(this.indentStack.Count - 1);
            }
        }

        public void EnsureNumNewLines(int numNewLines)
        {
            if (this.stringBuilder.Length == 0)
            {
                for (int i = 0; i < numNewLines; i++)
                {
                    this.stringBuilder.AppendLine();
                }
                return;
            }

            string currentText = this.stringBuilder.ToString();
            int existingNewlines = 0;

            for (int i = currentText.Length - 1; i >= 0; i--)
            {
                if (currentText[i] == '\n')
                {
                    existingNewlines++;
                    if (i > 0 && currentText[i - 1] == '\r')
                    {
                        i--;
                    }
                }
                else if (currentText[i] != '\r')
                {
                    break;
                }
            }

            int remainingNewlines = numNewLines - existingNewlines;
            for (int i = 0; i < remainingNewlines; i++)
            {
                this.stringBuilder.AppendLine();
            }
        }

        public void Clear()
        {
            this.stringBuilder.Clear();
            this.colorStack.Clear();
            this.indentStack.Clear();
            this.atLineStart = true;
        }

        private void AppendWithIndent(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            for (int i = 0; i < value.Length; i++)
            {
                if (this.atLineStart && value[i] != '\r' && value[i] != '\n')
                {
                    this.AppendIndent();
                    this.atLineStart = false;
                }

                this.stringBuilder.Append(value[i]);

                if (value[i] == '\n')
                {
                    this.atLineStart = true;
                }
            }
        }

        private void AppendIndent()
        {
            if (this.indentStack.Count > 0)
            {
                this.stringBuilder.Append(string.Join("", this.indentStack));
            }
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

        public class AnsiColorScope : IDisposable
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