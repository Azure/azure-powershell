# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
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
.Synopsis
Sets a Relay Cluster
.Description
Sets a Relay Cluster.
The cmdlet reads the current cluster first and only applies the properties that are being
changed, so tags or capacity can be updated without having to re-specify -Location and -SkuCapacity.
#>

function Set-AzRelayCluster{
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.IRelayCluster])]
    [CmdletBinding(DefaultParameterSetName = 'SetExpanded', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
param(
        [Parameter(ParameterSetName = 'SetExpanded', Mandatory, HelpMessage = "The name of the Relay Dedicated Cluster")]
        [Alias('ClusterName')]
        [Microsoft.Azure.PowerShell.Cmdlets.Relay.Category('Path')]
        [System.String]
        # The name of the Relay Dedicated Cluster.
        ${Name},

        [Parameter(ParameterSetName = 'SetExpanded', Mandatory, HelpMessage = "The name of the resource group. The name is case insensitive.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Relay.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(ParameterSetName = 'SetExpanded', HelpMessage = "The ID of the target subscription.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Relay.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Relay.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(ParameterSetName = 'SetViaIdentityExpanded', Mandatory, ValueFromPipeline, HelpMessage = "Identity parameter. To construct, see NOTES section for INPUTOBJECT properties and create a hash table.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Relay.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.IRelayIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},

        [Parameter(HelpMessage = "The number of capacity units assigned to the Relay cluster.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Relay.Category('Body')]
        [System.Int32]
        # The number of capacity units assigned to the Relay cluster.
        ${SkuCapacity},

        [Parameter(HelpMessage = "Resource tags.")]
        [Microsoft.Azure.PowerShell.Cmdlets.Relay.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Relay.Models.ITrackedResourceTags]
        # Resource tags.
        ${Tag},

        [Parameter(HelpMessage = "The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.")]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Relay.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The DefaultProfile parameter is not functional.
        # Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.
        ${DefaultProfile},

        [Parameter(HelpMessage = "Run the command as a job")]
        [Microsoft.Azure.PowerShell.Cmdlets.Relay.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Relay.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Relay.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Relay.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Relay.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Relay.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(HelpMessage = "Run the command asynchronously")]
        [Microsoft.Azure.PowerShell.Cmdlets.Relay.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Relay.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Relay.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.Relay.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
)
    dynamicparam {
        $dynamicParameters = [System.Management.Automation.RuntimeDefinedParameterDictionary]::new()
        $wrapped = Get-Command 'Az.Relay.private\New-AzRelayCluster_Create' -ErrorAction Ignore
        if ($wrapped -and [System.Management.Automation.IDynamicParameters].IsAssignableFrom($wrapped.ImplementingType)) {
            $instance = [System.Activator]::CreateInstance($wrapped.ImplementingType)
            foreach ($entry in $instance.GetDynamicParameters().GetEnumerator()) {
                if (-not $dynamicParameters.ContainsKey($entry.Key)) { $dynamicParameters.Add($entry.Key, $entry.Value) }
            }
        }
        return $dynamicParameters
    }
    process{
try{
            $hasCapacity = $PSBoundParameters.Remove('SkuCapacity')
            $hasTag = $PSBoundParameters.Remove('Tag')
            $hasAsJob = $PSBoundParameters.Remove('AsJob')
            $null = $PSBoundParameters.Remove('WhatIf')
            $null = $PSBoundParameters.Remove('Confirm')

            # 1. Get the existing cluster so unchanged properties (Location, Capacity, Tier) are preserved.
            $readParameters = Get-AzRelayReadParameters -CommandName 'Get-AzRelayCluster' -BoundParameters $PSBoundParameters
            $cluster = Get-AzRelayCluster @readParameters

            # 2. Apply only the requested changes on top of the current state.
            $hasProperty = $false

            if ($hasCapacity) {
                $cluster.SkuCapacity = $SkuCapacity
                $hasProperty = $true
            }
            if ($hasTag) {
                $cluster.Tag = $Tag
                $hasProperty = $true
            }

            if (($hasProperty -eq $false) -and ($PSCmdlet.ParameterSetName -eq 'SetViaIdentityExpanded')){
                throw 'Please specify the property you want to update on the -InputObject. Refer https://go.microsoft.com/fwlink/?linkid=2204690#behavior-of--inputobject for example.'
            }

            # 3. Put the full resource body back, resolving the identity from the fetched resource.
            $null = $PSBoundParameters.Remove('InputObject')
            $idSegments = $cluster.Id.Split('/')
            $PSBoundParameters['SubscriptionId'] = $idSegments[2]
            $PSBoundParameters['ResourceGroupName'] = $idSegments[4]
            $PSBoundParameters['Name'] = $cluster.Name

            if ($hasAsJob) {
                $PSBoundParameters.Add('AsJob', $true)
            }

            if ($PSCmdlet.ShouldProcess("Relay Cluster $($cluster.Name)", "Create or update")) {
                Az.Relay.private\New-AzRelayCluster_Create -Resource $cluster @PSBoundParameters
            }
}
catch{
throw
}
}
}