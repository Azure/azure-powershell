
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
# function Update-AzMariaDbConfiguration
# {
#     [OutputType([Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.Api20180601Preview.IConfiguration])]
#     [CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
#     param(
#         [Parameter(ParameterSetName='ServerName', Mandatory, HelpMessage='You can obtain this value from the Azure Resource Manager API or the portal.')]
#         [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
#         [System.String]
#         # The name of the resource group that contains the resource.
#         # You can obtain this value from the Azure Resource Manager API or the portal.
#         ${ResourceGroupName},
    
#         [Parameter(ParameterSetName='ServerName', Mandatory, HelpMessage='The name of the server.')]
#         [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
#         [System.String]
#         # The name of the server.
#         ${ServerName},
    
#         [Parameter(ParameterSetName='ServerName', Mandatory, HelpMessage='The subscription ID that identifies an Azure subscription.')]
#         [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
#         [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
#         [System.String]
#         # The subscription ID that identifies an Azure subscription.
#         ${SubscriptionId},
    
#         [Parameter(ParameterSetName='ServerObject', Mandatory, ValueFromPipeline, HelpMessage='Identity Parameter')]
#         [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
#         [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Models.IMariaDbIdentity]
#         # Identity Parameter
#         # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
#         ${ServerObject},
    
#         # [Parameter(HelpMessage='Configurations to be updated.')]
#         # [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
#         # [System.Collections.Hashtable]
#         # ${Configuration},

#         [Parameter(HelpMessage='The name of the server configuration.')]
#         [Alias('ConfigurationName')]
#         [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Path')]
#         [System.String]
#         # The name of the server configuration.
#         ${Name},
    
#         [Parameter(HelpMessage='Value of the configuration.')]
#         [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Body')]
#         [System.String]
#         # Value of the configuration.
#         ${Value},
    
#         #region DefaultParameters
#         [Parameter()]
#         [Alias('AzureRMContext', 'AzureCredential')]
#         [ValidateNotNull()]
#         [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Azure')]
#         [System.Management.Automation.PSObject]
#         # The credentials, account, tenant, and subscription used for communication with Azure.
#         ${DefaultProfile},
    
#         [Parameter()]
#         [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
#         [System.Management.Automation.SwitchParameter]
#         # Run the command as a job
#         ${AsJob},
    
#         [Parameter(DontShow)]
#         [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
#         [System.Management.Automation.SwitchParameter]
#         # Wait for .NET debugger to attach
#         ${Break},
    
#         [Parameter(DontShow)]
#         [ValidateNotNull()]
#         [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
#         [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
#         # SendAsync Pipeline Steps to be appended to the front of the pipeline
#         ${HttpPipelineAppend},
    
#         [Parameter(DontShow)]
#         [ValidateNotNull()]
#         [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
#         [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Runtime.SendAsyncStep[]]
#         # SendAsync Pipeline Steps to be prepended to the front of the pipeline
#         ${HttpPipelinePrepend},
    
#         [Parameter()]
#         [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
#         [System.Management.Automation.SwitchParameter]
#         # Run the command asynchronously
#         ${NoWait},
    
#         [Parameter(DontShow)]
#         [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
#         [System.Uri]
#         # The URI for the proxy server to use
#         ${Proxy},
    
#         [Parameter(DontShow)]
#         [ValidateNotNull()]
#         [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
#         [System.Management.Automation.PSCredential]
#         # Credentials for a proxy server to use for the remote call
#         ${ProxyCredential},
    
#         [Parameter(DontShow)]
#         [Microsoft.Azure.PowerShell.Cmdlets.MariaDb.Category('Runtime')]
#         [System.Management.Automation.SwitchParameter]
#         # Use the default credentials for the proxy
#         ${ProxyUseDefaultCredentials}
#         #endregion DefaultParameters
#     )
    
#     process {
#         try {
#             if ($PSBoundParameters.ContainsKey('ServerObject')) {
#                 $ServerId = $PSBoundParameters['ServerObject'].Id
#                 $PSBoundParameters['ServerName'] = Get-ServerNameFromMariaDbId $ServerId
#                 $PSBoundParameters['ResourceGroupName'] = Get-ResourceGroupNameFromMariaDbId $ServerId
#                 $Null = $PSBoundParameters.Remove('ServerObject')
#             }

#             if ($PSBoundParameters.ContainsKey('Name')) {
#                 $Configuration = [System.Collections.Hashtable]::new()
#                 $Configuration.Add($Name, $Value)
#             }
#             if ($PSBoundParameters.ContainsKey('Configuration')) {
#                 $Null = $PSBoundParameters.Remove('Configuration')
#             }
#             foreach ($ConfigName in $Configuration.Keys) {
#                 $PSBoundParameters['Name'] = $ConfigName
#                 $PSBoundParameters['Value'] = $Configuration[$ConfigName]
#                 Az.MariaDb.internal\Update-AzMariaDbConfiguration @PSBoundParameters
#             }
#         } catch {
#             throw
#         }
#     }
# }
