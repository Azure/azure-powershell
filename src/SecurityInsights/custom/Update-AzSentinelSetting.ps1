
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
    [CmdletBinding(DefaultParameterSetName = 'UpdateExpandedAnomaliesEyesOnEntityAnalytics', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(ParameterSetName = 'UpdateExpandedAnomaliesEyesOnEntityAnalytics')]
        [Parameter(ParameterSetName = 'UpdateExpandedUeba')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # Gets subscription credentials which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},
        
        [Parameter(ParameterSetName = 'UpdateExpandedAnomaliesEyesOnEntityAnalytics', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedUeba', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [System.String]
        # The Resource Group Name.
        ${ResourceGroupName},

        [Parameter(ParameterSetName = 'UpdateExpandedAnomaliesEyesOnEntityAnalytics', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedUeba', Mandatory)]
        #[Alias('DataConnectionName')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [System.String]
        # The name of the workspace.
        ${WorkspaceName},

        [Parameter(ParameterSetName = 'UpdateExpandedAnomaliesEyesOnEntityAnalytics', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateExpandedUeba', Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.SettingKind])]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        # The setting Name 
        ${SettingsName},

        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedAnomaliesEyesOnEntityAnalytics', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedUeba', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},

        #Anomalies
        #.EyesOn
        #.EntityAnalytics
        [Parameter(ParameterSetName = 'UpdateExpandedAnomaliesEyesOnEntityAnalytics', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedAnomaliesEyesOnEntityAnalytics', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.Boolean]
        ${Enabled},

        #.Ueba
        [Parameter(ParameterSetName = 'UpdateExpandedUeba', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityExpandedUeba', Mandatory)]
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
                $GetPSBoundParameters.Add('ResourceGroupName', ($PSBoundParameters['InputObject']).Id.Split('/')[4])
                $GetPSBoundParameters.Add('WorkspaceName', ($PSBoundParameters['InputObject']).Id.Split('/')[8])
                $Name = ($PSBoundParameters['InputObject']).Name
            }
            else {
                $GetPSBoundParameters.Add('ResourceGroupName', $PSBoundParameters['ResourceGroupName'])
                $GetPSBoundParameters.Add('WorkspaceName', $PSBoundParameters['WorkspaceName'])
                $Name = $PSBoundParameters['SettingsName']
             }
            if($Name -eq 'Ueba'){
                $GetPSBoundParameters.Add('SettingsName', 'Ueba')
                $ueba = Az.SecurityInsights\Get-AzSentinelSetting @GetPSBoundParameters
            }
            else{
                $Settings = Az.SecurityInsights\Get-AzSentinelSetting @GetPSBoundParameters
            }
            
 
            if ($Name -eq 'Anomalies'){
                If($PSBoundParameters['Enabled'] -eq $true){
                    if($Settings.Name -contains 'Anomalies'){
                        Write-Host "$Name is already Enabled!" -ForegroundColor Green
                    }
                    else{
                        Az.SecurityInsights.internal\Update-AzSentinelSetting -ResourceGroupName $GetPSBoundParameters['ResourceGroupName'] -WorkspaceName $GetPSBoundParameters['WorkspaceName'] -SettingsName $Name -Kind $Name
                    }
                }
              
                If($PSBoundParameters['Enabled'] -eq $false){
                    if($Settings.Name -contains 'Anomalies'){
                        Az.SecurityInsights.internal\Remove-AzSentinelSetting -ResourceGroupName $GetPSBoundParameters['ResourceGroupName'] -WorkspaceName $GetPSBoundParameters['WorkspaceName'] -SettingsName $Name
                    }
                    else{
                        Write-Host "$Name is already Disabled!" -ForegroundColor Green
                    }
                }
            }
            if ($Name -eq 'EyesOn'){
                If($PSBoundParameters['Enabled'] -eq $true){
                    if($Settings.Name -contains 'EyesOn'){
                        Write-Host "$Name is already Enabled!" -ForegroundColor Green
                    }
                    else{
                        Az.SecurityInsights.internal\Update-AzSentinelSetting -ResourceGroupName $GetPSBoundParameters['ResourceGroupName'] -WorkspaceName $GetPSBoundParameters['WorkspaceName'] -SettingsName $Name -Kind $Name
                    }                   
                }
                
                If($PSBoundParameters['Enabled'] -eq $false){
                    if($Settings.Name -contains 'EyesOn'){
                        Az.SecurityInsights.internal\Remove-AzSentinelSetting -ResourceGroupName $GetPSBoundParameters['ResourceGroupName'] -WorkspaceName $GetPSBoundParameters['WorkspaceName'] -SettingsName $Name
                    }
                    else{
                        Write-Host "$Name is already Disabled!" -ForegroundColor Green
                    }
                }
            }
            if ($Name -eq 'EntityAnalytics'){
                If($PSBoundParameters['Enabled'] -eq $true){
                    if($Settings.Name -contains 'EntityAnalytics'){
                        Write-Host "$Name is already Enabled!" -ForegroundColor Green
                    }
                    else{
                        Az.SecurityInsights.internal\Update-AzSentinelSetting -ResourceGroupName $GetPSBoundParameters['ResourceGroupName'] -WorkspaceName $GetPSBoundParameters['WorkspaceName'] -SettingsName $Name -Kind $Name
                    }                   
                }
                
                If($PSBoundParameters['Enabled'] -eq $false){
                    if($Settings.Name -contains 'EntityAnalytics'){
                        Az.SecurityInsights.internal\Remove-AzSentinelSetting -ResourceGroupName $GetPSBoundParameters['ResourceGroupName'] -WorkspaceName $GetPSBoundParameters['WorkspaceName'] -SettingsName $Name
                    }
                    else{
                        Write-Host "$Name is already Disabled!" -ForegroundColor Green
                    }
                }
            }

            if ($Name -eq 'Ueba'){
                If($PSBoundParameters['DataSource']){
                    $ueba.DataSource = $PSBoundParameters['DataSource']
                    $null = $PSBoundParameters.Remove('DataSource')
                }
                $null = $PSBoundParameters.Add('Setting', $Setting)
                Az.SecurityInsights.internal\Update-AzSentinelSetting @PSBoundParameters
            }
        }
        catch {
            throw
        }
    }
}