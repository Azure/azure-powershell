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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.NetAppFiles.Test.ScenarioTests.ScenarioTest
{
    public class CacheTests : NetAppFilesTestRunner
    {
        public CacheTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        // ANF Cache (FlexCache) requires a pre-existing on-prem ONTAP cluster reachable from
        // the cache's peering subnet to peer with as the origin volume. The required inputs are:
        //   - OriginPeerClusterName  : ONTAP cluster name of the external cluster
        //   - OriginPeerAddress      : Intercluster LIF IP addresses, one per node
        //   - OriginPeerVserverName  : External Vserver (SVM) hosting the origin volume
        //   - OriginPeerVolumeName   : External origin volume name
        // The Set-...CachePool / Reset-...CacheSmbPassword / Get-...CachePeeringPassphrase tests
        // additionally require a successfully created cache (i.e. a real peered ONTAP origin).
        //
        // We do not have an on-prem ONTAP fixture available in the test environment, so all of
        // these tests are skipped. Re-enable them once a peered ONTAP cluster (or a service-side
        // mock) is wired into the test fixture.

        [Fact(Skip = "Requires pre-provisioned on-prem ONTAP cluster reachable from the cache peering subnet. Enable once ONTAP fixture is available.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCacheCrud()
        {
            TestRunner.RunTestScript("Test-CacheCrud");
        }

        [Fact(Skip = "Requires pre-provisioned on-prem ONTAP cluster reachable from the cache peering subnet. Enable once ONTAP fixture is available.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCachePipeline()
        {
            TestRunner.RunTestScript("Test-CachePipeline");
        }

        [Fact(Skip = "Requires pre-provisioned on-prem ONTAP cluster reachable from the cache peering subnet. Enable once ONTAP fixture is available.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCachePeeringPassphrase()
        {
            TestRunner.RunTestScript("Test-CachePeeringPassphrase");
        }

        [Fact(Skip = "Requires pre-provisioned on-prem ONTAP cluster reachable from the cache peering subnet AND a second target capacity pool. Enable once ONTAP fixture is available.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCachePoolChange()
        {
            TestRunner.RunTestScript("Test-CachePoolChange");
        }

        [Fact(Skip = "Requires pre-provisioned on-prem ONTAP cluster reachable from the cache peering subnet and an SMB-enabled cache. Enable once ONTAP fixture is available.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCacheResetSmbPassword()
        {
            TestRunner.RunTestScript("Test-CacheResetSmbPassword");
        }
    }
}
