
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
Discards the set of resources included in the request body.
The discard operation is triggered on the moveResources in the moveState 'CommitPending' or 'DiscardFailed', on a successful completion the moveResource moveState do a transition to MovePending.
To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.
.Description
Discards the set of resources included in the request body.
The discard operation is triggered on the moveResources in the moveState 'CommitPending' or 'DiscardFailed', on a successful completion the moveResource moveState do a transition to MovePending.
To aid the user to prerequisite the operation the client can call operation with validateOnly property set to true.
.Example
PS C:\> Invoke-AzResourceMoverInitiateMove -ResourceGroupName "RG-MoveCollection-demoRMS" -MoveCollectionName "PS-centralus-westcentralus-demoRMS"  -MoveResource $('psdemorm-vnet') -MoveResourceInputType "MoveResourceId" -ValidateOnly

AdditionalInfo : 
Code           : 
Detail         : 
EndTime        : 2/10/2021 12:39:48 PM
Id             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveCollections/PS-centralus-westcentralus-demoRMS/operations/095f3d5
                 1-ebd1-4c5b-9a65-d78ebe3ac345
Message        : 
Name           : 095f3d51-ebd1-4c5b-9a65-d78ebe3ac345
Property       : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Any
StartTime      : 2/10/2021 12:39:37 PM
Status         : Succeeded

.Example
PS C:\> Invoke-AzResourceMoverDiscard -ResourceGroupName "RG-MoveCollection-demoRMS" -MoveCollectionName "PS-centralus-westcentralus-demoRMS"  -MoveResource $('psdemorm-vnet') -MoveResourceInputType "MoveResourceId"

AdditionalInfo : 
Code           : 
Detail         : 
EndTime        : 2/10/2021 12:56:33 PM
Id             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveCollections/PS-centralus-westcentralu
                 s-demoRMS/operations/290472e3-c8de-4c55-aba1-3a34a7a4ab38
Message        : 
Name           : 290472e3-c8de-4c55-aba1-3a34a7a4ab38
Property       : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Any
StartTime      : 2/10/2021 12:55:21 PM
Status         : Succeeded

.Example
PS C:\>  Invoke-AzResourceMoverDiscard -ResourceGroupName "RG-MoveCollection-demoRMS" -MoveCollectionName "PS-centralus-westcentralus-demoRMS"  -MoveResource $('/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PSDemoRM/providers/Microsoft.Network/networkSecurityGroups/PSDemoVM-nsg') -MoveResourceInputType "MoveResourceSourceId"

AdditionalInfo : 
Code           : 
Detail         : 
EndTime        : 2/10/2021 1:01:32 PM
Id             : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveCollections/PS-centralus-westcentralu
                 s-demoRMS/operations/955fd43c-10b6-481e-888b-d26d6ec42aea
Message        : 
Name           : 955fd43c-10b6-481e-888b-d26d6ec42aea
Property       : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Any
StartTime      : 2/10/2021 1:00:00 PM
Status         : Succeeded



.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationStatus
.Link
https://docs.microsoft.com/powershell/module/az.resourcemover/invoke-azresourcemoverdiscard
#>
function Invoke-AzResourceMoverDiscard {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IOperationStatus])]
[CmdletBinding(DefaultParameterSetName='DiscardExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('MoveCollectionName')]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Path')]
    [System.String]
    # The Move Collection Name.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Path')]
    [System.String]
    # The Resource Group Name.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The Subscription ID.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Body')]
    [System.String[]]
    # Gets or sets the list of resource Id's, by default it accepts move resource id's unless the input type is switched via moveResourceInputType property.
    ${MoveResource},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveResourceInputType])]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Support.MoveResourceInputType]
    # Defines the move resource input type.
    ${MoveResourceInputType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Gets or sets a value indicating whether the operation needs to only run pre-requisite.
    ${ValidateOnly},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            DiscardExpanded = 'Az.ResourceMover.private\Invoke-AzResourceMoverDiscard_DiscardExpanded';
        }
        if (('DiscardExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
