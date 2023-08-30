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

namespace Microsoft.Azure.Commands.KeyVault.Helpers
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
            stringBuilder.Append(value);

            return this;
        }

        public ColoredStringBuilder Append(string value, Color color)
        {
            PushColor(color);
            Append(value);
            PopColor();

            return this;
        }

        private void PopColor()
        {
            colorStack.Pop();
            stringBuilder.Append(colorStack.Count > 0 ? colorStack.Peek() : Color.Reset);
        }

        public ColoredStringBuilder Append(object value)
        {
            stringBuilder.Append(value);

            return this;
        }

        public ColoredStringBuilder Append(object value, Color color)
        {
            PushColor(color);
            Append(value);
            PopColor();

            return this;
        }

        public ColoredStringBuilder AppendLine()
        {
            stringBuilder.AppendLine();

            return this;
        }

        public ColoredStringBuilder AppendLine(string value)
        {
            stringBuilder.AppendLine(value);

            return this;
        }

        public ColoredStringBuilder AppendLine(string value, Color color)
        {
            PushColor(color);
            AppendLine(value);
            PopColor();

            return this;
        }

        public AnsiColorScope NewColorScope(Color color)
        {
            return new AnsiColorScope(this, color);
        }

        private void PushColor(Color color)
        {
            colorStack.Push(color);
            stringBuilder.Append(color);
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
                builder.PopColor();
            }
        }
    }
}