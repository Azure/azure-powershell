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
using Xunit;

namespace Microsoft.Azure.Commands.ManagedCache.Test
{
    public class PSCacheClientTest
    {
        [Fact]
        public void ManagedCache_NormalizeCacheServiceName()
        {
            PSCacheClient client = new PSCacheClient();
            Assert.Equal("foobar", client.NormalizeCacheServiceName("FOOBAR"));
            //can't start with a  number
            Assert.Throws(typeof(ArgumentException), () => { client.NormalizeCacheServiceName("2222"); });
            //too short
            Assert.Throws(typeof(ArgumentException), () => { client.NormalizeCacheServiceName("foo"); });
            //too long
            Assert.Throws(typeof(ArgumentException), () => { client.NormalizeCacheServiceName("h01234567890123456789"); });
            //empty
            Assert.Throws(typeof(ArgumentException), () => { client.NormalizeCacheServiceName(""); });
        }
    }
}
