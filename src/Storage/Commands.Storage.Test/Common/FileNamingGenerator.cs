﻿// ----------------------------------------------------------------------------------
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.WindowsAzure.Management.Storage.Test.Common
{
    /// <summary>
    /// Provides utilities to generate different names for file service.
    /// </summary>
    internal static class FileNamingGenerator
    {
        public const int MaxShareNameLength = 63;

        public const int MaxFileNameLength = 255;

        public const int MaxPathLength = 1024;

        public const int MinShareNameLength = 3;

        private const char Dash = '-';

        private const double DashRate = 0.2;

        private static readonly Tuple<int, int> ValidASCIIRange = new Tuple<int, int>(0x0020, 0x07E);

        private static readonly char[] InvalidFileNameCharacters = new char[] { '\\', '/', ':', '|', '<', '>', '*', '?', '"' };

        private static readonly char[] ValidShareNameCharactersExceptDash =
            Enumerable.Range(0, 26).Select(x => (char)('a' + x)).Concat(
            Enumerable.Range(0, 10).Select(x => (char)('0' + x))).ToArray();

        public static string GenerateValidASCIIName(int length)
        {
            return GenerateNameFromRange(length, ValidASCIIRange);
        }

        public static string GenerateValidShareName(int length)
        {
            return GenerateShareNameInternal(length);
        }

        public static string GenerateInvalidShareName_DoubleDash(int length)
        {
            return GenerateShareNameInternal(length, ensureDoubleDash: true);
        }

        public static string GenerateInvalidShareName_StartsWithDash(int length)
        {
            return GenerateShareNameInternal(length, startsWithDash: true);
        }

        public static string GenerateInvalidShareName_EndsWithDash(int length)
        {
            return GenerateShareNameInternal(length, endsWithDash: true);
        }

        public static string GenerateInvalidShareName_UpperCase(int length)
        {
            return GenerateShareNameInternal(length, ensureUpperCase: true);
        }

        public static string GenerateNameFromRange(int length, Tuple<int, int> range)
        {
            Random r = new Random();
            StringBuilder sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                char ch;
                do
                {
                    ch = Convert.ToChar(r.Next(range.Item1, range.Item2));
                }
                while (InvalidFileNameCharacters.Contains(ch));
                sb.Append(ch);
            }

            return sb.ToString();
        }

        private static string GenerateShareNameInternal(int length, bool ensureDoubleDash = false, bool startsWithDash = false, bool endsWithDash = false, bool ensureUpperCase = false)
        {
            Random r = new Random();
            StringBuilder sb = new StringBuilder(length);

            if (startsWithDash)
            {
                sb.Append(Dash);
            }
            else
            {
                sb.Append(ValidShareNameCharactersExceptDash[r.Next(ValidShareNameCharactersExceptDash.Length)]);
            }

            bool lastIsDash = false;
            bool doubleDashEnsured = false;
            for (int i = 0; i < length - 2; i++)
            {
                if (ensureDoubleDash && lastIsDash)
                {
                    sb.Append(Dash);
                    doubleDashEnsured = true;
                }
                if (!lastIsDash && r.NextDouble() < DashRate)
                {
                    sb.Append(Dash);
                    lastIsDash = true;
                }
                else
                {
                    sb.Append(ValidShareNameCharactersExceptDash[r.Next(ValidShareNameCharactersExceptDash.Length)]);
                }
            }

            if (endsWithDash)
            {
                sb.Append(Dash);
            }
            else
            {
                sb.Append(ValidShareNameCharactersExceptDash[r.Next(ValidShareNameCharactersExceptDash.Length)]);
            }

            if (ensureDoubleDash && !doubleDashEnsured)
            {
                int pos = r.Next(1, length - 2);
                sb[pos] = Dash;
                sb[pos + 1] = Dash;
            }

            if (ensureUpperCase)
            {
                var allLettersPosition = new List<int>(sb.Length);
                for (int i = 0; i < sb.Length; i++)
                {
                    if (sb[i] >= 'a' && sb[i] <= 'z')
                    {
                        allLettersPosition.Add(i);
                    }
                }

                int index = allLettersPosition[r.Next(allLettersPosition.Count)];
                sb[index] = Char.ToUpperInvariant(sb[index]);
            }

            return sb.ToString();
        }
    }
}
