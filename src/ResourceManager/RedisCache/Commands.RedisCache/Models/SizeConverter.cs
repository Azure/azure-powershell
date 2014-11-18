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
    public static class SizeConverter
    {
        public const string C0 = "250MB";
        public const string C1 = "1GB";
        public const string C2 = "2.5GB";
        public const string C3 = "6GB";
        public const string C4 = "13GB";
        public const string C5 = "26GB";
        public const string C6 = "53GB";

        public const string C0String = "C0";
        public const string C1String = "C1";
        public const string C2String = "C2";
        public const string C3String = "C3";
        public const string C4String = "C4";
        public const string C5String = "C5";
        public const string C6String = "C6";

        public static string GetSizeInRedisSpecificFormat(string actualSizeFromUser)
        { 
            switch(actualSizeFromUser)
            {
                // accepting actual sizes
                case C0:
                    return C0String;
                case C1:
                    return C1String;
                case C2:
                    return C2String;
                case C3:
                    return C3String;
                case C4:
                    return C4String;
                case C5:
                    return C5String;
                case C6:
                    return C6String;
                // accepting C0, C1 etc.
                case C0String:
                    return C0String;
                case C1String:
                    return C1String;
                case C2String:
                    return C2String;
                case C3String:
                    return C3String;
                case C4String:
                    return C4String;
                case C5String:
                    return C5String;
                case C6String:
                    return C6String;
                default:
                    return C1String;
            }
        }

        public static string GetSizeInUserSpecificFormat(string skuFamily, int skuCapacity)
        {
            string sizeConstant = skuFamily + skuCapacity.ToString();
            switch (sizeConstant)
            {
                // accepting C0, C1 etc.
                case C0String:
                        return C0;
                case C1String:
                        return C1;
                case C2String:
                        return C2;
                case C3String:
                        return C3;
                case C4String:
                        return C4;
                case C5String:
                        return C5;
                case C6String:
                        return C6;
                default:
                    return C1;
            }
        }
    }
}
