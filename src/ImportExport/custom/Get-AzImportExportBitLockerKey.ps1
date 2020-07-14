
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
Returns the BitLocker Keys for all drives in the specified job.
.Description
Returns the BitLocker Keys for all drives in the specified job.
.Example
PS C:\> Get-AzImportExportBitLockerKey -JobName test-job -ResourceGroupName ImportTestRG 
BitLockerKey                                            DriveId
------------                                            -------
238810-662376-448998-450120-652806-203390-606320-483076 9CA995BA

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveBitLockerKey
.Link
https://docs.microsoft.com/en-us/powershell/module/az.importexport/get-azimportexportbitlockerkey
#>
function Get-AzImportExportBitLockerKey {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Models.Api20161101.IDriveBitLockerKey])]
    [CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory, HelpMessage="The name of the import/export job.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
        [System.String]
        # The name of the import/export job.
        ${JobName},
    
        [Parameter(Mandatory, HelpMessage="The resource group name uniquely identifies the resource group within the user subscription.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
        [System.String]
        # The resource group name uniquely identifies the resource group within the user subscription.
        ${ResourceGroupName},
    
        [Parameter(HelpMessage="The subscription ID for the Azure user.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # The subscription ID for the Azure user.
        ${SubscriptionId},
    
        [Parameter(HelpMessage="Specifies the preferred language for the response.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Header')]
        [System.String]
        # Specifies the preferred language for the response.
        ${AcceptLanguage},
    
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImportExport.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )
    
    process {
        Az.ImportExport.internal\Get-AzImportExportBitLockerKey @PSBoundParameters
    }
}
    