
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
Get requirements state for a data connector type.
.Description
Get requirements state for a data connector type.

.Link
https://docs.microsoft.com/powershell/module/az.securityinsights/invoke-azsentineldataconnectorscheckrequirement
#>
function Invoke-AzSentinelDataConnectorsCheckRequirement {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.DataConnectorsCheckRequirements])]
    [CmdletBinding(DefaultParameterSetName = 'AzureActiveDirectory', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # Gets subscription credentials which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},
        
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.DefaultInfo(Script = '"Microsoft.OperationalInsights"')]
        [System.String]
        # The name of Operational Insights Resource Provider.
        ${OperationalInsightsResourceProvider},

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

        [Parameter(Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.DataConnectorKind])]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.DataConnectorKind]
        # Kind of the the data connection
        ${Kind},


        [Parameter(ParameterSetName = 'AzureActiveDirectory')]
        [Parameter(ParameterSetName = 'AzureAdvancedThreatProtection')]
        [Parameter(ParameterSetName = 'Dynamics365')]
        [Parameter(ParameterSetName = 'MicrosoftCloudAppSecurity')]
        [Parameter(ParameterSetName = 'MicrosoftDefenderAdvancedThreatProtection')]
        [Parameter(ParameterSetName = 'MicrosoftThreatIntelligence')]
        [Parameter(ParameterSetName = 'MicrosoftThreatProtection')]
        [Parameter(ParameterSetName = 'Office365')]
        [Parameter(ParameterSetName = 'OfficeATP')]
        [Parameter(ParameterSetName = 'ThreatIntelligence')]
        [Parameter(ParameterSetName = 'ThreatIntelligenceTaxii')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.DefaultInfo(Script = '(Get-AzContext).Tenant.Id')]
        [System.String]
        # The TenantId.
        ${TenantId},

        [Parameter(ParameterSetName = 'AzureSecurityCenter', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        # ASC Subscription Id.
        ${ASCSubscriptionId},

        #[Parameter(ParameterSetName = 'AmazonWebServicesCloudTrail', Mandatory)]
        #[Parameter(ParameterSetName = 'AmazonWebServicesS3', Mandatory)]
        #[Parameter(ParameterSetName = 'GenericUI', Mandatory)]

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

            if ($PSBoundParameters['Kind'] -eq 'AzureActiveDirectory'){
                $DataConnectorsCheckRequirement = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.AadCheckRequirements]::new()
                $DataConnectorsCheckRequirement.TenantId = $PSBoundParameters['TenantId']
                $null = $PSBoundParameters.Remove('TenantId')
            }
            if($PSBoundParameters['Kind'] -eq 'AzureAdvancedThreatProtection'){
                $DataConnectorsCheckRequirement = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.AatpCheckRequirements]::new()
                $DataConnectorsCheckRequirement.TenantId = $PSBoundParameters['TenantId']
                $null = $PSBoundParameters.Remove('TenantId')
            }
            if($PSBoundParameters['Kind'] -eq 'Dynamics365'){
                $DataConnectorsCheckRequirement = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.Dynamics365CheckRequirements]::new()
                $DataConnectorsCheckRequirement.TenantId = $PSBoundParameters['TenantId']
                $null = $PSBoundParameters.Remove('TenantId')
            }
            if($PSBoundParameters['Kind'] -eq 'MicrosoftCloudAppSecurity'){
                $DataConnectorsCheckRequirement = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.MCASCheckRequirements]::new()
                $DataConnectorsCheckRequirement.TenantId = $PSBoundParameters['TenantId']
                $null = $PSBoundParameters.Remove('TenantId')
            }
            if($PSBoundParameters['Kind'] -eq 'MicrosoftDefenderAdvancedThreatProtection'){
                $DataConnectorsCheckRequirement = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.MDATPCheckRequirements]::new()
                $DataConnectorsCheckRequirement.TenantId = $PSBoundParameters['TenantId']
                $null = $PSBoundParameters.Remove('TenantId')
            }
            if($PSBoundParameters['Kind'] -eq 'MicrosoftThreatIntelligence'){
                $DataConnectorsCheckRequirement = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.MSTICheckRequirements]::new()
                $DataConnectorsCheckRequirement.TenantId = $PSBoundParameters['TenantId']
                $null = $PSBoundParameters.Remove('TenantId')
            }
            if($PSBoundParameters['Kind'] -eq 'MicrosoftThreatProtection'){
                $DataConnectorsCheckRequirement = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.MtpCheckRequirements]::new()
                $DataConnectorsCheckRequirement.TenantId = $PSBoundParameters['TenantId']
                $null = $PSBoundParameters.Remove('TenantId')
            }
            #if($PSBoundParameters['Kind'] -eq 'Office365'){
            #    $DataConnectorsCheckRequirement = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.Office365CheckRequirements]::new()
            #    $DataConnectorsCheckRequirement.TenantId = $PSBoundParameters['TenantId']
            #    $null = $PSBoundParameters.Remove('TenantId')
            #}
            if($PSBoundParameters['Kind'] -eq 'OfficeATP'){
                $DataConnectorsCheckRequirement = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.OfficeATPCheckRequirements]::new()
                $DataConnectorsCheckRequirement.TenantId = $PSBoundParameters['TenantId']
                $null = $PSBoundParameters.Remove('TenantId')
            }
            if($PSBoundParameters['Kind'] -eq 'ThreatIntelligence'){
                $DataConnectorsCheckRequirement = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.TICheckRequirements]::new()
                $DataConnectorsCheckRequirement.TenantId = $PSBoundParameters['TenantId']
                $null = $PSBoundParameters.Remove('TenantId')
            }
            if($PSBoundParameters['Kind'] -eq 'ThreatIntelligenceTaxii'){
                $DataConnectorsCheckRequirement = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.TiTaxiiCheckRequirements]::new()
                $DataConnectorsCheckRequirement.TenantId = $PSBoundParameters['TenantId']
                $null = $PSBoundParameters.Remove('TenantId')
            }

            if($PSBoundParameters['Kind'] -eq 'AzureSecurityCenter'){
                $DataConnectorsCheckRequirement = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.ASCCheckRequirements]::new()
                $DataConnectorsCheckRequirement.SubscriptionId = $PSBoundParameters['ASCSubscriptionId']
                $null = $PSBoundParameters.Remove('ASCSubscriptionId')
            }
            #if($PSBoundParameters['Kind'] -eq 'AmazonWebServicesCloudTrail'){}
            #if($PSBoundParameters['Kind'] -eq 'AmazonWebServicesS3'){}
            #if($PSBoundParameters['Kind'] -eq 'GenericUI'){}
    
            $DataConnectorsCheckRequirement.Kind = $PSBoundParameters['Kind']
            $null = $PSBoundParameters.Remove('Kind')

            $null = $PSBoundParameters.Add('DataConnectorsCheckRequirement', $DataConnectorsCheckRequirement)

            Az.SecurityInsights.internal\Invoke-AzSentinelDataConnectorsCheckRequirement @PSBoundParameters
        }
        catch {
            throw
        }
    }
}