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

using System;
using Microsoft.Azure.Commands.ManagedCache.Models;
using Microsoft.Azure.Management.ManagedCache.Models;
using Xunit;

namespace Microsoft.Azure.Commands.ManagedCache.Test
{
    public class CacheSkuCountConvertTest
    {
        [Fact]
        public void ManagedCache_ConversionWorksForBasicSku()
        {
            CacheSkuCountConvert convert = new CacheSkuCountConvert(CacheServiceSkuType.Basic);
            Assert.Equal("128MB", convert.ToMemorySize(1));
            Assert.Equal("256MB", convert.ToMemorySize(2));
            Assert.Equal(2, convert.ToSkuCount("256"));
            Assert.Equal(1, convert.ToSkuCount("128MB"));
            Assert.Equal(1, convert.ToSkuCount("128mb"));
            Assert.Throws(typeof(ArgumentException), () => { convert.ToSkuCount("2222"); });
            Assert.Throws(typeof(ArgumentException), () => { convert.ToSkuCount("foo-bar"); });
        }

        [Fact]
        public void ManagedCache_ConversionWorksForStandardSku()
        {
            CacheSkuCountConvert convert = new CacheSkuCountConvert(CacheServiceSkuType.Standard);
            Assert.Equal("1GB", convert.ToMemorySize(1));
            Assert.Equal("2GB", convert.ToMemorySize(2));
            Assert.Equal(1, convert.ToSkuCount("1GB"));
            Assert.Equal(10, convert.ToSkuCount("10GB"));
            Assert.Throws(typeof(ArgumentException), () => { convert.ToSkuCount("11"); });
            Assert.Throws(typeof(ArgumentException), () => { convert.ToSkuCount("foo-bar"); });
        }

        [Fact]
        public void ManagedCache_ConversionWorksForPremiumSku()
        {
            CacheSkuCountConvert convert = new CacheSkuCountConvert(CacheServiceSkuType.Premium);
            Assert.Equal("5GB", convert.ToMemorySize(1));
            Assert.Equal("10GB", convert.ToMemorySize(2));
            Assert.Equal(1, convert.ToSkuCount("5GB"));
            Assert.Equal(30, convert.ToSkuCount("150GB"));
            Assert.Throws(typeof(ArgumentException), () => { convert.ToSkuCount("12MB"); });
            Assert.Throws(typeof(ArgumentException), () => { convert.ToSkuCount("-1"); });
        }

        [Fact]
        public void ManagedCache_CountIsOneIfMemorySizeIsNull()
        {
            Assert.Equal(1, new CacheSkuCountConvert(CacheServiceSkuType.Basic).ToSkuCount(null));
        }
    }
}
