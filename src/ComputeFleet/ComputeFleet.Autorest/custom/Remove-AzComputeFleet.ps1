
# # ----------------------------------------------------------------------------------
# #
# # Copyright Microsoft Corporation
# # Licensed under the Apache License, Version 2.0 (the "License");
# # you may not use this file except in compliance with the License.
# # You may obtain a copy of the License at
# # http://www.apache.org/licenses/LICENSE-2.0
# # Unless required by applicable law or agreed to in writing, software
# # distributed under the License is distributed on an "AS IS" BASIS,
# # WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# # See the License for the specific language governing permissions and
# # limitations under the License.
# # ----------------------------------------------------------------------------------

# <#
# .Synopsis
# Delete Organization resource
# .Description
# Delete Organization resource
# .Example
# PS C:\> Remove-AzComputeFleetOrganization -ResourceGroupName azure-rg-test -Name computefleetorg-01-portal

# .Example
# PS C:\>  Get-AzComputeFleetOrganization -ResourceGroupName azure-rg-test -Name computefleetorg-02-pwsh | Remove-AzComputeFleetOrganization


# .Inputs
# Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeFleetIdentity
# .Outputs
# System.Boolean
# .Notes
# COMPLEX PARAMETER PROPERTIES

# To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

# INPUTOBJECT <IComputeFleetIdentity>: Identity Parameter
#   [Id <String>]: Resource identity path
#   [OrganizationName <String>]: Organization resource name
#   [ResourceGroupName <String>]: Resource group name
#   [SubscriptionId <String>]: Microsoft Azure subscription id
# .Link
# https://learn.microsoft.com/powershell/module/az.computefleet/remove-azcomputefleetorganization
# #>
# function Remove-AzComputeFleetOrganization {
# [OutputType([System.Boolean])]
# [CmdletBinding(DefaultParameterSetName='Delete', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
# param(
#     [Parameter(ParameterSetName='Delete', Mandatory)]
#     [Alias('OrganizationName')]
#     [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category('Path')]
#     [System.String]
#     # Organization resource name
#     ${Name},

#     [Parameter(ParameterSetName='Delete', Mandatory)]
#     [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category('Path')]
#     [System.String]
#     # Resource group name
#     ${ResourceGroupName},

#     [Parameter(ParameterSetName='Delete')]
#     [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category('Path')]
#     [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
#     [System.String]
#     # Microsoft Azure subscription id
#     ${SubscriptionId},

#     [Parameter(ParameterSetName='DeleteViaIdentity', Mandatory, ValueFromPipeline)]
#     [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category('Path')]
#     [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.IComputeFleetIdentity]
#     # Identity Parameter
#     # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
#     ${InputObject},

#     [Parameter()]
#     [Alias('AzureRMContext', 'AzureCredential')]
#     [ValidateNotNull()]
#     [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category('Azure')]
#     [System.Management.Automation.PSObject]
#     # The credentials, account, tenant, and subscription used for communication with Azure.
#     ${DefaultProfile},

#     [Parameter()]
#     [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category('Runtime')]
#     [System.Management.Automation.SwitchParameter]
#     # Run the command as a job
#     ${AsJob},

#     [Parameter(DontShow)]
#     [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category('Runtime')]
#     [System.Management.Automation.SwitchParameter]
#     # Wait for .NET debugger to attach
#     ${Break},

#     [Parameter(DontShow)]
#     [ValidateNotNull()]
#     [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category('Runtime')]
#     [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.SendAsyncStep[]]
#     # SendAsync Pipeline Steps to be appended to the front of the pipeline
#     ${HttpPipelineAppend},

#     [Parameter(DontShow)]
#     [ValidateNotNull()]
#     [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category('Runtime')]
#     [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Runtime.SendAsyncStep[]]
#     # SendAsync Pipeline Steps to be prepended to the front of the pipeline
#     ${HttpPipelinePrepend},

#     [Parameter()]
#     [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category('Runtime')]
#     [System.Management.Automation.SwitchParameter]
#     # Run the command asynchronously
#     ${NoWait},

#     [Parameter()]
#     [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category('Runtime')]
#     [System.Management.Automation.SwitchParameter]
#     # Returns true when the command succeeds
#     ${PassThru},

#     [Parameter(DontShow)]
#     [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category('Runtime')]
#     [System.Uri]
#     # The URI for the proxy server to use
#     ${Proxy},

#     [Parameter(DontShow)]
#     [ValidateNotNull()]
#     [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category('Runtime')]
#     [System.Management.Automation.PSCredential]
#     # Credentials for a proxy server to use for the remote call
#     ${ProxyCredential},

#     [Parameter(DontShow)]
#     [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Category('Runtime')]
#     [System.Management.Automation.SwitchParameter]
#     # Use the default credentials for the proxy
#     ${ProxyUseDefaultCredentials}
# )

#     process {
#         # Get a computefleet orgnization via name or object.      
#         if ($PSBoundParameters.ContainsKey('InputObject')) {
#             $computefleetOrg = ($InputObject | Get-AzComputeFleetOrganization)
#         } else {
#             $computefleetOrg = Get-AzComputeFleetOrganization -ResourceGroupName $ResourceGroupName -Name $Name
#         }

#         # Check plan id of the computefleet organization.
#         # Print pay warning mssage if the planid maps to payg type. Otherwise print commit warning message.    
#         if (('computefleet-cloud-azure-payg-prod', 'computefleet-cloud-azure-payg-stag').Contains($computefleetOrg.OfferDetailPlanId)){
#             $warnningMsg = (Get-Content -Path (Join-Path $PSScriptRoot "payWarning.txt")) -join "`n"
#         } else {
#             $warnningMsg = (Get-Content -Path (Join-Path $PSScriptRoot "commitWarning.txt")) -join "`n"
#         }

#         # Get user confirmation info.
#         do {
#             Write-Host -ForegroundColor Yellow $warnningMsg
#             $confirmation = (Read-Host "Do you want to proceed (Y/N)?").ToUpper()
#         } while(($confirmation -ne 'Y') -and ($confirmation -ne 'N'))    

#         if ($confirmation -eq 'N') {
#             Write-Host -ForegroundColor Red 'Operation cancelled.'
#             return
#         }

#         try {
#             Az.ComputeFleet.internal\Remove-AzComputeFleetOrganization @PSBoundParameters
#         } catch {
#             throw
#         }
#     }
# }

