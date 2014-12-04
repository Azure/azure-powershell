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

namespace Microsoft.Azure.Commands.ManagedCache.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ManagedCache.Models;

    //This class bridges the concept gap between "memory size" used by the commandlets 
    //and the "sku count" at server
    class CacheSkuCountConvert
    {
        private CacheServiceSkuType skuName;
        private int min;
        private int max;
        private int increment;
        private string unit; //MB or GB
        public CacheSkuCountConvert(CacheServiceSkuType sku)
        {
            skuName = sku;
            if (sku == CacheServiceSkuType.Basic)
            {
                min = 128;
                max = 1024;
                increment = 128;
                unit = "MB";
            }
            else if (sku == CacheServiceSkuType.Standard)
            {
                min = 1;
                max = 10;
                increment = 1;
                unit = "GB";
            }
            else
            {
                min = 5;
                max = 150;
                increment = 5;
                unit = "GB";
            }
        }

        public int ToSkuCount (string memorySize)
        {
            if (string.IsNullOrEmpty(memorySize))
            {
                return 1;
            }
            if (memorySize.EndsWith(unit, StringComparison.OrdinalIgnoreCase))
            {
                memorySize = memorySize.Substring(0, memorySize.Length - unit.Length);
            }
            int size;
            if (!int.TryParse(memorySize, out size) ||
                size < min || size > max || (size % increment) != 0)
            {
                throw new ArgumentException(
                    string.Format(Properties.Resources.InvalidCacheMemorySize, min, max, unit));
            }
            return  size / increment;
        }

        public string ToMemorySize (int skuCount)
        {
            return GetMemoryDisplayInfo(skuCount * increment);
        }

        public string[] GetValueList()
        {
            List<string> values = new List<string>();
            for (int i = min; i <= max; i+= increment)
            {
                values.Add(GetMemoryDisplayInfo(i));
            }
            return values.ToArray();
        }

        private string GetMemoryDisplayInfo(int memory)
        {
            return string.Format("{0}{1}", memory, unit);
        }
    }
}
