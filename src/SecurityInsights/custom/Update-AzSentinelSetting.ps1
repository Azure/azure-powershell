
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
Updates setting.
.Description
Updates setting.

.Link
https://docs.microsoft.com/powershell/module/az.securityinsights/update-azsentinelsetting
#>
function Update-AzSentinelSetting {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.Settings])]
    [CmdletBinding(DefaultParameterSetName = 'UpdateExpandedAnomalies', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(ParameterSetName = 'UpdateExpandedAnomalies')]
        [Parameter(ParameterSetName = 'UpdateExpandedEyesOn')]
        [Parameter(ParameterSetName = 'UpdateExpandedEntityAnalytics')]
        [Parameter(ParameterSetName = 'UpdateExpandedUeba')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # Gets subscription credentials which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},
        
        [Parameter(ParameterSetName = 'UpdateExpandedAnomalies', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedEyesOn', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedEntityAnalytics', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedUeba', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [System.String]
        # The Resource Group Name.
        ${ResourceGroupName},

        [Parameter(ParameterSetName = 'UpdateExpandedAnomalies', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedEyesOn', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedEntityAnalytics', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedUeba', Mandatory)]
        #[Alias('DataConnectionName')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [System.String]
        # The name of the workspace.
        ${WorkspaceName},

        [Parameter(ParameterSetName = 'UpdateExpandedAnomalies', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedEyesOn', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedEntityAnalytics', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedUeba', Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.SettingKind])]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        # The setting Name
        ${SettingsName},

        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedAnomalies', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEyesOn', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEntityAnalytics', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedUeba', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},

        #Anomalies
         #.EyesOn
         #.EntityAnalytics
        [Parameter(ParameterSetName = 'UpdateExpandedAnomalies')]
        [Parameter(ParameterSetName = 'UpdateExpandedEyesOn')]
        [Parameter(ParameterSetName = 'UpdateExpandedEntityAnalytics')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedAnomalies')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEyesOn')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEntityAnalytics')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Switch]
        ${Enabled},

        [Parameter(ParameterSetName = 'UpdateExpandedAnomalies')]
        [Parameter(ParameterSetName = 'UpdateExpandedEyesOn')]
        [Parameter(ParameterSetName = 'UpdateExpandedEntityAnalytics')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedAnomalies')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEyesOn')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedEntityAnalytics')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Switch]
        ${Disabled},

        #.Ueba
        [Parameter(ParameterSetName = 'UpdateExpandedUeba')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedUeba')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.UebaDataSources])]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.UebaDataSources[]]
        ${DataSource},

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
                 $GetPSBoundParameters.Add('OperationalInsightsResourceProvider', $PSBoundParameters['OperationalInsightsResourceProvider'])
                 $GetPSBoundParameters.Add('ResourceGroupName', $PSBoundParameters['ResourceGroupName'])
                 $GetPSBoundParameters.Add('WorkspaceName', $PSBoundParameters['WorkspaceName'])
                 $GetPSBoundParameters.Add('Kind', $PSBoundParameters['Kind'])
             }
             $Setting = Az.SecurityInsights\Get-AzSentinelSetting @GetPSBoundParameters
 
            if ($Setting.Kind -eq 'Anomalies'){
                If($PSBoundParameters['Enabled']){
                    $Setting.IsEnabled = $true
                    $null = $PSBoundParameters.Remove('Enabled')
                }
                
                If($PSBoundParameters['Disabled']){
                    $Setting.IsEnabled = $false
                    $null = $PSBoundParameters.Remove('Disabled')
                }
            }
            if ($Setting.Kind -eq 'EyesOn'){
                If($PSBoundParameters['Enabled']){
                    $Setting.IsEnabled = $true
                    $null = $PSBoundParameters.Remove('Enabled')
                }
                
                If($PSBoundParameters['Disabled']){
                    $Setting.IsEnabled = $false
                    $null = $PSBoundParameters.Remove('Disabled')
                }
            }
            if ($Setting.Kind -eq 'EntityAnalytics'){
                If($PSBoundParameters['Enabled']){
                    $Setting.IsEnabled = $true
                    $null = $PSBoundParameters.Remove('Enabled')
                }
                
                If($PSBoundParameters['Disabled']){
                    $Setting.IsEnabled = $false
                    $null = $PSBoundParameters.Remove('Disabled')
                }
            }

            if ($Setting.Kind -eq 'Ueba'){
                If($PSBoundParameters['DataSource']){
                    $Setting.DataSource = $PSBoundParameters['DataSource']
                    $null = $PSBoundParameters.Remove('DataSource')
                }
            }
    
            $null = $PSBoundParameters.Add('Setting', $Setting)
            
            Az.SecurityInsights.internal\Update-AzSentinelSetting @PSBoundParameters
        }
        catch {
            throw
        }
    }
}