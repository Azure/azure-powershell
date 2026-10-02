# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License")
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Runs the independent remote server registration cmdlets in sequence.
.DESCRIPTION
Exercises the three-step, non-piped flow:
1. Get-StorageSyncServer         - reads local server information through the agent (COM).
2. Register-AzStorageSyncServer  - creates the registered server resource in Azure (ARM).
3. Connect-StorageSyncServer     - connects the local server using values from step 2 (COM).

The commands do not share objects. Values are read from one command and supplied as
explicit parameters to the next, exactly as an operator would.

In Record/Live mode this runs against the real Azure File Sync agent and managed
identity on the local machine, so the machine must be Arc-enabled or an Azure VM with a
system-assigned managed identity and the Azure File Sync agent installed.
#>
function Test-RemoteServerRegistrationSequence
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName
    Write-Verbose "========================================================================"
    Write-Verbose "Test-RemoteServerRegistrationSequence starting"
    Write-Verbose "RecordMode : $(Get-StorageTestMode) | IsLive : $(IsLive)"
    Write-Verbose "========================================================================"
    try
    {
        # Test
        $storageSyncServiceName = Get-ResourceName("sss")
        $resourceGroupLocation = Get-ResourceGroupLocation
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices")

        Write-Verbose "[Setup] RGName: $resourceGroupName | Loc: $resourceGroupLocation | Type : ResourceGroup"
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation
        Write-Verbose "[Setup] Resource group '$resourceGroupName' created."

        Write-Verbose "[Setup] Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        $storageSyncService = New-AzStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName -AssignIdentity -IdentityType SystemAssigned
        Write-Verbose "[Setup] StorageSyncService created. ResourceId: $($storageSyncService.ResourceId)"
        Write-Verbose "[Setup] StorageSyncService StorageSyncServiceUid: $($storageSyncService.StorageSyncServiceUid)"

        # Step 1: read local server information (COM only, no Azure calls).
        Write-Verbose "------------------------------------------------------------------------"
        Write-Verbose "[Step 1] Get-StorageSyncServer (local COM read)"
        $localServer = Get-StorageSyncServer -Verbose
        Assert-NotNull $localServer "Get-StorageSyncServer returned null."
        Assert-NotNull $localServer.ServerId "Local server id was not returned."
        Assert-NotNull $localServer.ServerRole "Local server role was not returned."
        Write-Verbose "[Step 1] Local ServerId     : $($localServer.ServerId)"
        Write-Verbose "[Step 1] Local ServerName   : $($localServer.ServerName)"
        Write-Verbose "[Step 1] Local ServerRole   : $($localServer.ServerRole)"
        Write-Verbose "[Step 1] Local IsInCluster  : $($localServer.IsInCluster)"
        Write-Verbose "[Step 1] Local ClusterId    : $($localServer.ClusterId)"
        Write-Verbose "[Step 1] Local ClusterName  : $($localServer.ClusterName)"
        Write-Verbose "[Step 1] Local ApplicationId: $($localServer.ApplicationId)"
        Write-Verbose "[Step 1] Local TenantId     : $($localServer.TenantId)"
        Write-Verbose "[Step 1] Local AgentVersion : $($localServer.AgentVersion)"
        Write-Verbose "[Step 1] Local ServerOSVer  : $($localServer.ServerOSVersion)"

        # The application id is discovered from the local managed identity. In Record/Live
        # mode this comes from the real Arc/Azure VM identity; the same value is supplied to
        # the register and connect steps so the identity checks line up on this machine.
        $applicationId = $localServer.ApplicationId
        if (IsLive)
        {
            Assert-NotNull $applicationId "The local server does not have a managed identity application id. Ensure this Arc/Azure VM server has a system-assigned managed identity enabled."
        }
        Write-Verbose "[Step 1] Using ApplicationId for registration: $applicationId"

        # Step 2: create the registered server resource in Azure (ARM only).
        Write-Verbose "------------------------------------------------------------------------"
        Write-Verbose "[Step 2] Register-AzStorageSyncServer (ARM create, generates ServerId)"
        $registeredServer = Register-AzStorageSyncServer -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -ApplicationId $applicationId -AgentVersion $localServer.AgentVersion -ServerRole $localServer.ServerRole -ServerOSVersion $localServer.ServerOSVersion -FriendlyName $localServer.ServerName -Verbose
        Assert-NotNull $registeredServer "Register-AzStorageSyncServer returned null."
        Assert-NotNull $registeredServer.ServerId "Registered server id was not returned."
        Assert-NotNull $registeredServer.ApplicationId "Registered server application id was not returned."
        if (IsLive)
        {
            # In Record/Live mode the registered resource echoes back the exact application id we supplied.
            # In Playback the recorded response carries the originally recorded id, which intentionally differs
            # from the deterministic mock identity, so this cross-boundary equality is only asserted when live.
            Assert-AreEqual ([string]$applicationId) ([string]$registeredServer.ApplicationId)
        }
        Write-Verbose "[Step 2] Registered ServerId             : $($registeredServer.ServerId)"
        Write-Verbose "[Step 2] Registered ResourceId           : $($registeredServer.ResourceId)"
        Write-Verbose "[Step 2] Registered ApplicationId        : $($registeredServer.ApplicationId)"
        Write-Verbose "[Step 2] Registered StorageSyncServiceUid: $($registeredServer.StorageSyncServiceUid)"
        Write-Verbose "[Step 2] Registered ManagementEndpointUri: $($registeredServer.ManagementEndpointUri)"
        Write-Verbose "[Step 2] Registered DiscoveryEndpointUri : $($registeredServer.DiscoveryEndpointUri)"
        Write-Verbose "[Step 2] Registered MonitoringEndpointUri: $($registeredServer.MonitoringEndpointUri)"
        Write-Verbose "[Step 2] Registered ServiceLocation      : $($registeredServer.ServiceLocation)"
        Write-Verbose "[Step 2] Registered ResourceLocation     : $($registeredServer.ResourceLocation)"
        Write-Verbose "[Step 2] Registered ProvisioningState    : $($registeredServer.ProvisioningState)"

        # Step 3: connect the local server using values copied from the register output
        # (COM only). No pipeline handoff and no second Azure create call.
        Write-Verbose "------------------------------------------------------------------------"
        Write-Verbose "[Step 3] Connect-StorageSyncServer (local COM connect using Step 2 values)"
        $connectedServer = Connect-StorageSyncServer `
            -ResourceGroupName $resourceGroupName `
            -StorageSyncServiceName $storageSyncServiceName `
            -ServerId $registeredServer.ServerId `
            -ApplicationId $applicationId `
            -StorageSyncServiceUid $registeredServer.StorageSyncServiceUid `
            -ManagementEndpointUri $registeredServer.ManagementEndpointUri `
            -DiscoveryEndpointUri $registeredServer.DiscoveryEndpointUri `
            -ServiceLocation $registeredServer.ServiceLocation `
            -ResourceLocation $registeredServer.ResourceLocation `
            -MonitoringEndpointUri $registeredServer.MonitoringEndpointUri `
            -MonitoringConfiguration $registeredServer.MonitoringConfiguration `
            -Verbose

        Assert-NotNull $connectedServer "Connect-StorageSyncServer returned null."
        Assert-AreEqual $registeredServer.ServerId $connectedServer.ServerId
        Write-Verbose "[Step 3] Connected ServerId  : $($connectedServer.ServerId)"
        Write-Verbose "[Step 3] Connected ServerRole: $($connectedServer.ServerRole)"
        Write-Verbose "[Step 3] Connected ClusterId : $($connectedServer.ClusterId)"

        Write-Verbose "------------------------------------------------------------------------"
        Write-Verbose "[Verify] Get-AzStorageSyncServer by ServerId to confirm it exists in Azure"
        $fetchedServer = Get-AzStorageSyncServer -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -ServerId $registeredServer.ServerId -Verbose
        Assert-AreEqual $registeredServer.ServerId $fetchedServer.ServerId
        Write-Verbose "[Verify] Fetched ServerId          : $($fetchedServer.ServerId)"
        Write-Verbose "[Verify] Fetched ProvisioningState : $($fetchedServer.ProvisioningState)"
        Write-Verbose "[Verify] Fetched ActiveAuthType    : $($fetchedServer.ActiveAuthType)"

        Write-Verbose "------------------------------------------------------------------------"
        Write-Verbose "[Teardown] Unregister Server: $($registeredServer.ServerId)"
        Unregister-AzStorageSyncServer -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -ServerId $registeredServer.ServerId -AsJob | Wait-Job
        Write-Verbose "[Teardown] Server unregistered."

        Write-Verbose "[Teardown] Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName -AsJob | Wait-Job
        Write-Verbose "[Teardown] StorageSyncService removed."
    }
    finally
    {
        # Cleanup
        Write-Verbose "[Cleanup] Removing ResourceGroup : $resourceGroupName"
        Clean-ResourceGroup $resourceGroupName
        Write-Verbose "Test-RemoteServerRegistrationSequence finished."
    }
}
