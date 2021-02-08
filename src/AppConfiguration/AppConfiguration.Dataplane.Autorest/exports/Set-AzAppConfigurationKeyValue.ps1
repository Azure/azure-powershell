
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
Creates a key-value.
.Description
Creates a key-value.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IKeyValue
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IKeyValue
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

ENTITY <IKeyValue>: .
  [ContentType <String>]: 
  [ETag <String>]: 
  [Etag <String>]: 
  [Key <String>]: 
  [Label <String>]: 
  [LastModified <DateTime?>]: 
  [LastModified1 <String>]: 
  [Locked <Boolean?>]: 
  [SyncToken <String>]: 
  [Tag <IKeyValueTags>]: Dictionary of <string>
    [(Any) <String>]: This indicates any property can be added to this object.
  [Value <String>]: 
.Link
https://docs.microsoft.com/powershell/module/az.appconfiguration/set-azappconfigurationkeyvalue
#>
function Set-AzAppConfigurationKeyValue {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IKeyValue])]
[CmdletBinding(DefaultParameterSetName='PutExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Uri')]
    [System.String]
    # The endpoint of the App Configuration instance to send requests to.
    ${Endpoint},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Path')]
    [System.String]
    # The key of the key-value to create.
    ${Key},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Query')]
    [System.String]
    # The label of the key-value to create.
    ${Label},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Header')]
    [System.String]
    # Used to perform an operation only if the targeted resource's etag matches the value provided.
    ${IfMatch},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Header')]
    [System.String]
    # Used to perform an operation only if the targeted resource's etag does not match the value provided.
    ${IfNoneMatch},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Header')]
    [System.String]
    # Used to guarantee real-time consistency between requests.
    ${SyncToken},

    [Parameter(ParameterSetName='Put', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IKeyValue]
    # .
    # To construct, see NOTES section for ENTITY properties and create a hash table.
    ${Entity},

    [Parameter(ParameterSetName='PutExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Body')]
    [System.String]
    # .
    ${ContentType},

    [Parameter(ParameterSetName='PutExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Body')]
    [System.String]
    # .
    ${Etag},

    [Parameter(ParameterSetName='PutExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Body')]
    [System.String]
    # .
    ${Key1},

    [Parameter(ParameterSetName='PutExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Body')]
    [System.String]
    # .
    ${Label1},

    [Parameter(ParameterSetName='PutExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Body')]
    [System.DateTime]
    # .
    ${LastModified},

    [Parameter(ParameterSetName='PutExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # .
    ${Locked},

    [Parameter(ParameterSetName='PutExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IKeyValueTags]))]
    [System.Collections.Hashtable]
    # Dictionary of <string>
    ${Tag},

    [Parameter(ParameterSetName='PutExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Body')]
    [System.String]
    # .
    ${Value},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Category('Runtime')]
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
            Put = 'Az.AppConfiguration.private\Set-AzAppConfigurationKeyValue_Put';
            PutExpanded = 'Az.AppConfiguration.private\Set-AzAppConfigurationKeyValue_PutExpanded';
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
