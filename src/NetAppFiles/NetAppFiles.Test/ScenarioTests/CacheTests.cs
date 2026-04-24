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

        // ============================================================================
        // ANF Cache (FlexCache) scenario tests -- LIVE ONLY
        // ============================================================================
        //
        // PREREQUISITE: ON-PREM ONTAP or CVO
        // -------------------------------
        // Each test creates a real Microsoft.NetApp/netAppAccounts/capacityPools/caches
        // resource that peers with an external on-prem ONTAP cluster (typically a
        // Cloud Volumes ONTAP / CVO instance). That cluster must be running and
        // reachable from the cache's peering subnet BEFORE the test runs, and you
        // must have SSH access to it. Required origin inputs (set in
        // Get-CacheOriginPlaceholder inside CacheTests.ps1):
        //   - OriginPeerClusterName  : ONTAP cluster name of the external cluster
        //   - OriginPeerAddress      : Intercluster LIF IP addresses, one per node
        //   - OriginPeerVserverName  : External Vserver (SVM) hosting the origin volume
        //   - OriginPeerVolumeName   : External origin volume name
        //
        // WHY THIS TEST IS INTERACTIVE (and why it is Skip'd by default)
        // --------------------------------------------------------------
        // FlexCache provisioning is a multi-stage handshake:
        //   Creating -> ClusterPeeringOfferSent -> VserverPeeringOfferSent -> Succeeded
        // At each '*OfferSent' state the service waits for the on-prem operator to
        // accept the offer on the CVO via SSH. There is no public API to perform
        // this acceptance from Azure; it MUST be done on the CVO CLI. The PowerShell
        // test therefore polls cacheState, prints the exact CVO commands to paste,
        // and resumes automatically once the state advances. See
        // Invoke-CacheInteractivePeering / Wait-AnfCacheState /
        // Write-CacheManualPeeringInstructions in CacheTests.ps1.
        //
        // Because every run requires a human at the CVO, these tests cannot run in
        // CI and are decorated with [Fact(Skip = LiveOnlySkip)].
        //
        // HOW TO RUN LIVE
        // ---------------
        //   1. Update Get-CacheOriginPlaceholder in CacheTests.ps1 with your CVO
        //      coordinates.
        //   2. Temporarily remove the Skip argument from the [Fact] you want to run
        //      (e.g. '[Fact]' instead of '[Fact(Skip = LiveOnlySkip)]').
        //   3. Sign into Azure in the same shell:
        //        Connect-AzAccount
        //        Set-AzContext -Subscription <subscription-id>
        //   4. From the repo root run (pwsh):
        //
        //        $env:AZURE_TEST_MODE = 'Record'
        //        dotnet test src\NetAppFiles\NetAppFiles.Test\NetAppFiles.Test.csproj `
        //            --filter "FullyQualifiedName~TestCacheCrud" `
        //            --logger "console;verbosity=detailed"
        //
        //   5. When the console prints '=== ON-PREM ONTAP ACTION REQUIRED ===',
        //      SSH into the CVO and paste the literal command block shown. The test
        //      resumes automatically once cacheState advances; do NOT press a key in
        //      the test host.
        //   6. Restore the Skip attribute before committing so CI does not attempt
        //      live execution.
        //
        // ALTERNATIVE: VISUAL STUDIO TEST EXPLORER
        // ----------------------------------------
        // These are standard xUnit [Fact]s and run in Test Explorer once the
        // Skip argument is removed. The catch: VS does NOT inherit shell env vars,
        // so set AZURE_TEST_MODE=Record at the USER level BEFORE launching VS:
        //
        //     [Environment]::SetEnvironmentVariable('AZURE_TEST_MODE','Record','User')
        //
        // Then close and reopen Visual Studio (env vars are read at process start).
        // In Test Explorer: right-click TestCacheCrud -> Run. The Write-Host banner
        // with the on-prem ONTAP peering commands appears in the test's Output pane
        // (select the test row, then 'Open additional output for this result').
        // Wait-AnfCacheState enforces its own timeouts internally; no [Fact(Timeout=)]
        // is needed. Unset the var (or set it to 'Playback') when done so unrelated
        // tests do not try to record.
        // ============================================================================

        private const string LiveOnlySkip =
            "Live-only: requires on-prem ONTAP CVO and an engineer to paste cluster/vserver peering commands when prompted. Run with AZURE_TEST_MODE=Record. See header comment above for the full command.";

        [Fact(Skip = LiveOnlySkip)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCacheCrud()
        {
            TestRunner.RunTestScript("Test-CacheCrud");
        }

        [Fact(Skip = LiveOnlySkip)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCachePipeline()
        {
            TestRunner.RunTestScript("Test-CachePipeline");
        }

        [Fact(Skip = LiveOnlySkip)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCachePoolChange()
        {
            TestRunner.RunTestScript("Test-CachePoolChange");
        }

        [Fact(Skip = LiveOnlySkip)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCacheResetSmbPassword()
        {
            TestRunner.RunTestScript("Test-CacheResetSmbPassword");
        }
    }
}
