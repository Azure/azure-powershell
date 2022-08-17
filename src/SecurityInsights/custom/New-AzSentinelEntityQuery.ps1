
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
Creates or updates the entity query.
.Description
Creates or updates the entity query.

.Link
https://docs.microsoft.com/powershell/module/az.securityinsights/new-azsentinelentityquery
#>
function New-AzSentinelEntityQuery {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.CustomEntityQuery])]
    [CmdletBinding(DefaultParameterSetName = 'Activity', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # Gets subscription credentials which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},
        
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [System.String]
        # The Resource Group Name.
        ${ResourceGroupName},

        [Parameter(Mandatory)]
        #[Alias('DataConnectionName')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [System.String]
        # The name of the workspace.
        ${WorkspaceName},

        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.DefaultInfo(Script = '(New-Guid).Guid')]
        [System.String]
        # The Id of the Entity Query.
        ${Id},

        [Parameter(Mandatory)]
        [ArgumentCompleter( { param ( $CommandName, $EntityQueryName, $WordToComplete, $CommandAst, $FakeBoundParameters ) return @('Activity') })]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EntityQueryKind]
        # Kind of the the Entity Query
        ${Kind},

        [Parameter(ParameterSetName = 'Activity', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${Title},

        [Parameter(ParameterSetName = 'Activity', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${Content},

        [Parameter(ParameterSetName = 'Activity', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${Description},

        [Parameter(ParameterSetName = 'Activity', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${QueryDefinitionQuery},

        [Parameter(ParameterSetName = 'Activity', Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EntityType])]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EntityType]
        ${InputEntityType},
        
        [Parameter(ParameterSetName = 'Activity')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [String[]]
        ${RequiredInputFieldsSet},

        [Parameter(ParameterSetName = 'Activity')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')] 
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.ActivityEntityQueriesPropertiesEntitiesFilter]
        ${EntitiesFilter},

        [Parameter(ParameterSetName = 'Activity')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${TemplateName},

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

            if ($PSBoundParameters['Kind'] -eq 'Activity'){
                $EntityQuery = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.ActivityCustomEntityQuery]::new()
                
                $EntityQuery.Title = $PSBoundParameters['Title']
                $null = $PSBoundParameters.Remove('Title')

                $EntityQuery.Content = $PSBoundParameters['Content']
                $null = $PSBoundParameters.Remove('Content')

                $EntityQuery.Description = $PSBoundParameters['Description']
                $null = $PSBoundParameters.Remove('Description')

                $EntityQuery.QueryDefinitionQuery = $PSBoundParameters['QueryDefinitionQuery']
                $null = $PSBoundParameters.Remove('QueryDefinitionQuery')

                $EntityQuery.InputEntityType = $PSBoundParameters['InputEntityType']
                $null = $PSBoundParameters.Remove('InputEntityType')
                
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
            }
            else {
                Write-Error "This cmdlet only works with Entity Queries of the Activity kind."
                break
            }
    
            #$EntityQuery.Kind = $PSBoundParameters['Kind']
            $null = $PSBoundParameters.Remove('Kind')

            $null = $PSBoundParameters.Add('EntityQuery', $EntityQuery)

            Az.SecurityInsights.internal\New-AzSentinelEntityQuery @PSBoundParameters
        }
        catch {
            throw
        }
    }
}