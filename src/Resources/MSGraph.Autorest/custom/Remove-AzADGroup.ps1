
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
Deletes entity from groups.
.Description
Deletes entity from groups.
.Link
https://docs.microsoft.com/powershell/module/az.resources/remove-azadgroup
#>
function Remove-AzADGroup {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='ObjectIdParameterSet', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='ObjectIdParameterSet', Mandatory)] 
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Path')]
    [System.String]
    # key: id of group
    ${ObjectId},

    [Parameter(ParameterSetName='DisplayNameParameterSet', Mandatory)] 
    [System.String]
    # The display name of the group to be removed.
    ${DisplayName},

    [Parameter(ParameterSetName = 'InputObjectParameterSet', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphGroup]
    # user input object
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Header')]
    [System.String]
    # ETag
    ${IfMatch},

    [Parameter()]
    [Alias("AzContext", "AzureRmContext", "AzureCredential")]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)


  process {
    switch ($PSCmdlet.ParameterSetName) {
        'ObjectIdParameterSet' {
            $id = $PSBoundParameters['ObjectId']
            $null = $PSBoundParameters.Remove('ObjectId')
            break
        }
        'InputObjectParameterSet' {
            $id = $PSBoundParameters['InputObject'].Id
            $null = $PSBoundParameters.Remove('InputObject')
            break
        }
        'DisplayNameParameterSet' {
            $list = Get-AzADGroup -DisplayName $PSBoundParameters['DisplayName'] -Select Id
            if($null -eq $list) {
                Write-Error "Group with display name '$($PSBoundParameters['DisplayName'])' does not exist."
                return
            }
            if($list -is [System.Array]) {
                Write-Error "More than one group found with display name '$($PSBoundParameters['DisplayName'])'. Please use the Get-AzADGroup cmdlet to get the object id of the desired group."
                return
            }
            $id = $list.Id
            $null = $PSBoundParameters.Remove('DisplayName')
            break
        }
    }
    $PSBoundParameters['Id'] = $id

    Az.MSGraph.internal\Remove-AzADGroup @PSBoundParameters
  }
}
