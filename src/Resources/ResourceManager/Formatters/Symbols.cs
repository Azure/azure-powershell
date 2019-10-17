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
