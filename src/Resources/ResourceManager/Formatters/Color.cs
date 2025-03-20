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

    public class Color : IEquatable<Color>
    {
        private const char Esc = (char)27;

        private readonly string colorCode;

        public static Color Orange { get; } = new Color($"{Esc}[38;5;208m");

        public static Color Green { get; } = new Color($"{Esc}[38;5;77m");

        public static Color Purple { get; } = new Color($"{Esc}[38;5;141m");

        public static Color Blue { get; } = new Color($"{Esc}[38;5;39m");

        public static Color Gray { get; } = new Color($"{Esc}[38;5;246m");

        public static Color Reset { get; } = new Color($"{Esc}[0m");

        public static Color Red { get; } = new Color($"{Esc}[38;5;196m");

        public static Color DarkYellow { get; } = new Color($"{Esc}[38;5;136m");

        private Color(string colorCode)
        {
            this.colorCode = colorCode;
        }

        public override string ToString()
        {
            return this.colorCode;
        }

        public override int GetHashCode()
        {
            return colorCode != null ? colorCode.GetHashCode() : 0;
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

        public bool Equals(Color other)
        {
            return other != null && string.Equals(this.colorCode, other.colorCode);
        }
    }
}
