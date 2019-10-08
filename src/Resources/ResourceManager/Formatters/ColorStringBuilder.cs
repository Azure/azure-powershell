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

