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

namespace Microsoft.Azure.Commands.RedisCache.Models
{
    using System.Collections.Generic;

    internal static class SizeConverter
    {
        public const string MB250 = "250MB";
        public const string GB1 = "1GB";
        public const string GB2_5 = "2.5GB";
        public const string GB6 = "6GB";
        public const string GB13 = "13GB";
        public const string GB26 = "26GB";
        public const string GB53 = "53GB";

        public const string C0String = "C0";
        public const string C1String = "C1";
        public const string C2String = "C2";
        public const string C3String = "C3";
        public const string C4String = "C4";
        public const string C5String = "C5";
        public const string C6String = "C6";

        public const string P1String = "P1";
        public const string P2String = "P2";
        public const string P3String = "P3";
        public const string P4String = "P4";

        private static Dictionary<string, string> skuStringToActualSize = new Dictionary<string, string>{
            { C0String, MB250 },
            { C1String, GB1 },
            { C2String, GB2_5 },
            { C3String, GB6 },
            { C4String, GB13 },
            { C5String, GB26 },
            { C6String, GB53 },
            { P1String, GB6 },
            { P2String, GB13 },
            { P3String, GB26 },
            { P4String, GB53 }
        };

        public static string GetSizeInRedisSpecificFormat(string actualSizeFromUser, bool isPremiumCache)
        {
            switch (actualSizeFromUser)
            {
                // accepting actual sizes
                case MB250:
                    return C0String;
                case GB1:
                    return C1String;
                case GB2_5:
                    return C2String;
                case GB6:
                    if (isPremiumCache)
                    {
                        return P1String;
                    }
                    else
                    {
                        return C3String;
                    }
                case GB13:
                    if (isPremiumCache)
                    {
                        return P2String;
                    }
                    else
                    {
                        return C4String;
                    }
                case GB26:
                    if (isPremiumCache)
                    {
                        return P3String;
                    }
                    else
                    {
                        return C5String;
                    }
                case GB53:
                    if (isPremiumCache)
                    {
                        return P4String;
                    }
                    else
                    {
                        return C6String;
                    }
                // accepting C0, C1 etc.
                default:
                    return actualSizeFromUser;
            }
        }

        public static string GetSizeInUserSpecificFormat(string skuFamily, int skuCapacity)
        {
            string sizeConstant = skuFamily + skuCapacity.ToString();
            if (skuStringToActualSize.ContainsKey(sizeConstant))
            {
                return skuStringToActualSize[sizeConstant];
            }
            return null;
        }
    }
}
