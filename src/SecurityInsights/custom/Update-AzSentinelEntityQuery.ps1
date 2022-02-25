
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
Updates the entity query.
.Description
Updates the entity query.

.Link
https://docs.microsoft.com/powershell/module/az.securityinsights/update-azsentinelentityquery
#>
function Update-AzSentinelEntityQuery {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.CustomEntityQuery])]
    [CmdletBinding(DefaultParameterSetName = 'UpdateActivity', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(ParameterSetName = 'UpdateActivity')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # Gets subscription credentials which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},
        
        [Parameter(ParameterSetName = 'UpdateActivity', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [System.String]
        # The Resource Group Name.
        ${ResourceGroupName},

        [Parameter(ParameterSetName = 'UpdateActivity', Mandatory)]
        #[Alias('DataConnectionName')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [System.String]
        # The name of the workspace.
        ${WorkspaceName},

        [Parameter(ParameterSetName = 'UpdateActivity', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [System.String]
        # The Id of the Entity Query.
        ${EntityQueryId},

        [Parameter(ParameterSetName = 'UpdateViaIdentityActivity', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},

        [Parameter(ParameterSetName = 'UpdateActivity')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityActivity')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${Title},

        [Parameter(ParameterSetName = 'UpdateActivity')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityActivity')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${Content},

        [Parameter(ParameterSetName = 'UpdateActivity')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityActivity')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${Description},

        [Parameter(ParameterSetName = 'UpdateActivity')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityActivity')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${QueryDefinitionQuery},

        [Parameter(ParameterSetName = 'UpdateActivity')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityActivity')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EntityType])]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EntityType]
        ${InputEntityType},
        
        [Parameter(ParameterSetName = 'UpdateActivity')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityActivity')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [String[]]
        ${RequiredInputFieldsSet},

        [Parameter(ParameterSetName = 'UpdateActivity')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityActivity')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')] 
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.ActivityEntityQueriesPropertiesEntitiesFilter]
        ${EntitiesFilter},

        [Parameter(ParameterSetName = 'UpdateActivity')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityActivity')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${TemplateName},

        [Parameter(ParameterSetName = 'UpdateActivity')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityActivity')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Switch]
        ${Enabled},

        [Parameter(ParameterSetName = 'UpdateActivity')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityActivity')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Switch]
        ${Disabled},        

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        try {
            #Handle Get
            $GetPSBoundParameters = @{}
            if($PSBoundParameters['InputObject']){
                $GetPSBoundParameters.Add('InputObject', $PSBoundParameters['InputObject'])
            }
            else {
                $GetPSBoundParameters.Add('ResourceGroupName', $PSBoundParameters['ResourceGroupName'])
                $GetPSBoundParameters.Add('WorkspaceName', $PSBoundParameters['WorkspaceName'])
                $GetPSBoundParameters.Add('EntityQueryId', $PSBoundParameters['EntityQueryId'])
            }
            $EntityQuery = Az.SecurityInsights\Get-AzSentinelEntityQuery @GetPSBoundParameters

            if ($EntityQuery.Kind -eq 'Activity'){
                If($PSBoundParameters['Title']){
                    $EntityQuery.Title = $PSBoundParameters['Title']
                    $null = $PSBoundParameters.Remove('Title')
                }

                If($PSBoundParameters['Content']){
                    $EntityQuery.Content = $PSBoundParameters['Content']
                    $null = $PSBoundParameters.Remove('Content')
                }

                If($PSBoundParameters['Description']){
                    $EntityQuery.Description = $PSBoundParameters['Description']
                    $null = $PSBoundParameters.Remove('Description')
                }

                If($PSBoundParameters['QueryDefinitionQuery']){
                    $EntityQuery.QueryDefinitionQuery = $PSBoundParameters['QueryDefinitionQuery']
                    $null = $PSBoundParameters.Remove('QueryDefinitionQuery')
                }

                If($PSBoundParameters['InputEntityType']){
                    $EntityQuery.InputEntityType = $PSBoundParameters['InputEntityType']
                    $null = $PSBoundParameters.Remove('InputEntityType')
                }
                
                If($PSBoundParameters['RequiredInputFieldsSet']){
                    $EntityQuery.RequiredInputFieldsSet = $PSBoundParameters['RequiredInputFieldsSet']
                    $null = $PSBoundParameters.Remove('RequiredInputFieldsSet')
                }

                If($PSBoundParameters['EntitiesFilter']){
                    $EntityQuery.EntitiesFilter = $PSBoundParameters['EntitiesFilter']
                    $null = $PSBoundParameters.Remove('EntitiesFilter')
                }

                If($PSBoundParameters['TemplateName']){
                    $EntityQuery.TemplateName = $PSBoundParameters['TemplateName']
                    $null = $PSBoundParameters.Remove('TemplateName')
                }

                If($PSBoundParameters['Enabled']){
                    $EntityQuery.Enabled = $true
                    $null = $PSBoundParameters.Remove('Enabled')
                }
                
                If($PSBoundParameters['Disabled']){
                    $EntityQuery.Enabled = $false
                    $null = $PSBoundParameters.Remove('Disabled')
                }
            }
            else {
                Write-Error "This cmdlet only works with Entity Queries of the Activity kind."
                break
            }
    
            $null = $PSBoundParameters.Add('EntityQuery', $EntityQuery)

            Az.SecurityInsights.internal\Update-AzSentinelEntityQuery @PSBoundParameters
        }
        catch {
            throw
        }
    }
}