
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
Updates the alert rule.
.Description
Updates the alert rule.

.Link
https://learn.microsoft.com/powershell/module/az.securityinsights/Update-azsentinelalertrule
#>
function Update-AzSentinelAlertRule {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.AlertRule])]
    [CmdletBinding(DefaultParameterSetName = 'UpdateScheduled', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
    param(
        [Parameter(ParameterSetName = 'UpdateFusionMLTI')]
        [Parameter(ParameterSetName = 'UpdateMicrosoftSecurityIncidentCreation')]
        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        # Gets subscription credentials which uniquely identify Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},
        
        [Parameter(ParameterSetName = 'UpdateFusionMLTI', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateMicrosoftSecurityIncidentCreation', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateNRT', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateScheduled', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [System.String]
        # The Resource Group Name.
        ${ResourceGroupName},

        [Parameter(ParameterSetName = 'UpdateFusionMLTI', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateMicrosoftSecurityIncidentCreation', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateNRT', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateScheduled', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [System.String]
        # The name of the workspace.
        ${WorkspaceName},

        [Parameter(ParameterSetName = 'UpdateFusionMLTI', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateMicrosoftSecurityIncidentCreation', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateNRT', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateScheduled', Mandatory)]
        #[Alias('RuleId')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [System.String]
        # The name of Operational Insights Resource Provider.
        ${RuleId},

        [Parameter(ParameterSetName = 'UpdateViaIdentityFusionMLTI', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityMicrosoftSecurityIncidentCreation', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT', Mandatory, ValueFromPipeline)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled', Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity]
        # Identity Parameter
        # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
        ${InputObject},

        [Parameter(ParameterSetName = 'UpdateFusionMLTI', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityFusionMLTI', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${FusionMLorTI},

        [Parameter(ParameterSetName = 'UpdateMicrosoftSecurityIncidentCreation', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityMicrosoftSecurityIncidentCreation', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${MicrosoftSecurityIncidentCreation},

        [Parameter(ParameterSetName = 'UpdateNRT', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${NRT},

        [Parameter(ParameterSetName = 'UpdateScheduled', Mandatory)]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${Scheduled},

        [Parameter(ParameterSetName = 'UpdateFusionMLTI')]
        [Parameter(ParameterSetName = 'UpdateMicrosoftSecurityIncidentCreation')]
        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityFusionMLTI')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityMicrosoftSecurityIncidentCreation')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${AlertRuleTemplateName},
        
        [Parameter(ParameterSetName = 'UpdateFusionMLTI')]
        [Parameter(ParameterSetName = 'UpdateMicrosoftSecurityIncidentCreation')]
        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityFusionMLTI')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityMicrosoftSecurityIncidentCreation')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Switch]
        ${Enabled},

        [Parameter(ParameterSetName = 'UpdateFusionMLTI')]
        [Parameter(ParameterSetName = 'UpdateMicrosoftSecurityIncidentCreation')]
        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityFusionMLTI')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityMicrosoftSecurityIncidentCreation')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Switch]
        ${Disabled},

        [Parameter(ParameterSetName = 'UpdateMicrosoftSecurityIncidentCreation')]
        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityMicrosoftSecurityIncidentCreation')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${Description},

        [Parameter(ParameterSetName = 'UpdateMicrosoftSecurityIncidentCreation')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityMicrosoftSecurityIncidentCreation')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String[]]
        ${DisplayNamesFilter},

        [Parameter(ParameterSetName = 'UpdateMicrosoftSecurityIncidentCreation')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityMicrosoftSecurityIncidentCreation')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String[]]
        ${DisplayNamesExcludeFilter},


        [Parameter(ParameterSetName = 'UpdateMicrosoftSecurityIncidentCreation')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityMicrosoftSecurityIncidentCreation')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.MicrosoftSecurityProductName])]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.MicrosoftSecurityProductName]
        ${ProductFilter},
            
        [Parameter(ParameterSetName = 'UpdateMicrosoftSecurityIncidentCreation')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityMicrosoftSecurityIncidentCreation')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertSeverity[]]
        #High, Medium, Low, Informational
        ${SeveritiesFilter},

        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${Query},
        
        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${DisplayName},

        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.DefaultInfo(Script = 'New-TimeSpan -Hours 5')]
        [System.TimeSpan]
        ${SuppressionDuration},

        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Switch]
        ${SuppressionEnabled},

        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertSeverity])]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertSeverity]
        ${Severity},

        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AttackTactic])]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AttackTactic]
        [System.String[]]
        ${Tactic},
            
        
        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Switch]
        ${CreateIncident},

        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Switch]
        ${GroupingConfigurationEnabled},

        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Switch]
        ${ReOpenClosedIncident},

        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.DefaultInfo(Script = 'New-TimeSpan -Hours 5')]
        [System.TimeSpan]
        ${LookbackDuration},

        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.DefaultInfo(Script = '"AllEntities"')]
        [ValidateSet('AllEntities', 'AnyAlert', 'Selected')]
        [System.String]
        ${MatchingMethod},
            
        
        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertDetail])]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertDetail[]]
        ${GroupByAlertDetail}, 
        
        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [string[]] 
        ${GroupByCustomDetail},
        
        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EntityMappingType])]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EntityMappingType[]]
        ${GroupByEntity},
    
        
        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        #'Account', 'Host', 'IP', 'Malware', 'File', 'Process', 'CloudApplication', 'DNS', 'AzureResource', 'FileHash', 'RegistryKey', 'RegistryValue', 'SecurityGroup', 'URL', 'Mailbox', 'MailCluster', 'MailMessage', 'SubmissionMail'
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.EntityMapping[]]
        ${EntityMapping},

        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${AlertDescriptionFormat},

        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${AlertDisplayNameFormat},

        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${AlertSeverityColumnName},

        [Parameter(ParameterSetName = 'UpdateNRT')]
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityNRT')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${AlertTacticsColumnName},


        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.TimeSpan]
        ${QueryFrequency},

        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.TimeSpan]
        ${QueryPeriod},

        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.TriggerOperator])]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.TriggerOperator]
        ${TriggerOperator},
        
        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [int]
        ${TriggerThreshold},

        [Parameter(ParameterSetName = 'UpdateScheduled')]
        [Parameter(ParameterSetName = 'UpdateViaIdentityUpdateScheduled')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EventGroupingAggregationKind])]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EventGroupingAggregationKind]
        ${EventGroupingSettingAggregationKind},
            
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
            $null = $PSBoundParameters.Remove('FusionMLorTI')
            $null = $PSBoundParameters.Remove('MicrosoftSecurityIncidentCreation')
            $null = $PSBoundParameters.Remove('NRT')
            $null = $PSBoundParameters.Remove('Scheduled')
            #Handle Get
            $GetPSBoundParameters = @{}
            if($PSBoundParameters['InputObject']){
                $GetPSBoundParameters.Add('InputObject', $PSBoundParameters['InputObject'])
            }
            else {
                $GetPSBoundParameters.Add('ResourceGroupName', $PSBoundParameters['ResourceGroupName'])
                $GetPSBoundParameters.Add('WorkspaceName', $PSBoundParameters['WorkspaceName'])
                $GetPSBoundParameters.Add('RuleId', $PSBoundParameters['RuleId'])
            }
            $AlertRule = Az.SecurityInsights\Get-AzSentinelAlertRule @GetPSBoundParameters

            #Fusion
            if ($AlertRule.Kind -eq 'Fusion'){
                If($PSBoundParameters['AlertTemplateName']){
                    $AlertRule.AlertRuleTemplateName = $PSBoundParameters['AlertRuleTemplateName']
                    $null = $PSBoundParameters.Remove('AlertRuleTemplateName')
                }
                
                If($PSBoundParameters['Enabled']){
                    $AlertRule.Enabled = $true
                    $null = $PSBoundParameters.Remove('Enabled')
                }
                if($PSBoundParameters['Disabled']) {
                    $AlertRule.Enabled = $false
                    $null = $PSBoundParameters.Remove('Disabled')
                }
            }
            #MSIC
            if($AlertRule.Kind -eq 'MicrosoftSecurityIncidentCreation'){
                If($PSBoundParameters['AlertRuleTemplateName']){
                    $AlertRule.AlertRuleTemplateName = $PSBoundParameters['AlertRuleTemplateName']
                    $null = $PSBoundParameters.Remove('AlertRuleTemplateName')
                }
                
                If($PSBoundParameters['Enabled']){
                    $AlertRule.Enabled = $true
                    $null = $PSBoundParameters.Remove('Enabled')
                }
                if($PSBoundParameters['Disabled']) {
                    $AlertRule.Enabled = $false
                    $null = $PSBoundParameters.Remove('Disabled')
                }
                
                If($PSBoundParameters['Description']){
                    $AlertRule.Description = $PSBoundParameters['Description']
                    $null = $PSBoundParameters.Remove('Description')
                }
                
                If($PSBoundParameters['DisplayNamesFilter']){
                    $AlertRule.DisplayNamesFilter = $PSBoundParameters['DisplayNamesFilter']
                    $null = $PSBoundParameters.Remove('DisplayNamesFilter')
                }
                
                If($PSBoundParameters['DisplayNamesExcludeFilter']){
                    $AlertRule.DisplayNamesExcludeFilter = $PSBoundParameters['DisplayNamesExcludeFilter']
                    $null = $PSBoundParameters.Remove('DisplayNamesExcludeFilter')
                }
                
                If($PSBoundParameters['ProductFilter']){
                    $AlertRule.ProductFilter = $PSBoundParameters['ProductFilter']
                    $null = $PSBoundParameters.Remove('ProductFilter')
                }

                If($PSBoundParameters['SeveritiesFilter']){
                    $Parameter.SeveritiesFilter = $PSBoundParameters['SeveritiesFilter']
                    $null = $PSBoundParameters.Remove('SeveritiesFilter')
                }
            }
            #ML
            if ($AlertRule.Kind -eq 'MLBehaviorAnalytics'){
                If($PSBoundParameters['AlertRuleTemplateName']){
                    $AlertRule.AlertRuleTemplateName = $PSBoundParameters['AlertRuleTemplateName']
                    $null = $PSBoundParameters.Remove('AlertRuleTemplateName')
                }
                
                If($PSBoundParameters['Enabled']){
                    $AlertRule.Enabled = $true
                    $null = $PSBoundParameters.Remove('Enabled')
                }
                if($PSBoundParameters['Disabled']) {
                    $AlertRule.Enabled = $false
                    $null = $PSBoundParameters.Remove('Disabled')
                }
            }

            #NRT
            if($AlertRule.Kind -eq 'NRT'){
                If($PSBoundParameters['AlertRuleTemplateName']){
                    $AlertRule.Enabled = $PSBoundParameters['AlertRuleTemplateName']
                    $null = $PSBoundParameters.Remove('AlertRuleTemplateName')
                }
                
                If($PSBoundParameters['Enabled']){
                    $AlertRule.Enabled = $true
                    $null = $PSBoundParameters.Remove('Enabled')
                }
                if($PSBoundParameters['Disabled']) {
                    $AlertRule.Enabled = $false
                    $null = $PSBoundParameters.Remove('Disabled')
                }
                
                If($PSBoundParameters['Description']){
                    $AlertRule.Description = $PSBoundParameters['Description']
                    $null = $PSBoundParameters.Remove('Description')
                }
                
                If($PSBoundParameters['Query']){
                    $AlertRule.Query = $PSBoundParameters['Query']
                    $null = $PSBoundParameters.Remove('Query')
                }

                If($PSBoundParameters['DisplayName']){
                    $AlertRule.DisplayName = $PSBoundParameters['DisplayName']
                    $null = $PSBoundParameters.Remove('DisplayName')
                }

                If($PSBoundParameters['SuppressionDuration']){
                    $AlertRule.SuppressionDuration = $PSBoundParameters['SuppressionDuration']
                    $null = $PSBoundParameters.Remove('SuppressionDuration')
                }

                If($PSBoundParameters['SuppressionEnabled']){
                    $AlertRule.SuppressionEnabled = $true
                    $null = $PSBoundParameters.Remove('SuppressionEnabled')
                }
                else{
                    $AlertRule.SuppressionEnabled = $false
                }
                
                If($PSBoundParameters['Severity']){
                    $AlertRule.Severity = $PSBoundParameters['Severity']
                    $null = $PSBoundParameters.Remove('Severity')
                }
                
                If($PSBoundParameters['Tactic']){
                    $AlertRule.Tactic = $PSBoundParameters['Tactic']
                    $null = $PSBoundParameters.Remove('Tactic')
                }
                
                If($PSBoundParameters['IncidentConfigurationCreateIncident']){
                    $AlertRule.IncidentConfigurationCreateIncident = $true
                    $null = $PSBoundParameters.Remove('IncidentConfigurationCreateIncident')
                }
                else{
                    $AlertRule.IncidentConfigurationCreateIncident = $false
                }
                
                If($PSBoundParameters['Enabled']){
                    $AlertRule.GroupingConfigurationEnabled = $true
                    $null = $PSBoundParameters.Remove('Enabled')
                }
                else{
                    $AlertRule.GroupingConfigurationEnabled = $false
                }
                
                If($PSBoundParameters['ReOpenClosedIncident']){
                    $AlertRule.GroupingConfigurationReOpenClosedIncident = $true
                    $null = $PSBoundParameters.Remove('ReOpenClosedIncident')
                }
                else{
                    $AlertRule.GroupingConfigurationReOpenClosedIncident = $false
                }
                
                If($PSBoundParameters['LookbackDuration']){
                    $AlertRule.GroupingConfigurationLookbackDuration = $PSBoundParameters['LookbackDuration']
                    $null = $PSBoundParameters.Remove('LookbackDuration')
                }

                If($PSBoundParameters['MatchingMethod']){
                    $AlertRule.GroupingConfigurationMatchingMethod = $PSBoundParameters['MatchingMethod']
                    $null = $PSBoundParameters.Remove('MatchingMethod')
                }

                If($PSBoundParameters['GroupByAlertDetail']){
                    $AlertRule.GroupingConfigurationGroupByAlertDetail = $PSBoundParameters['GroupByAlertDetail']
                    $null = $PSBoundParameters.Remove('GroupByAlertDetail')
                }

                If($PSBoundParameters['GroupByCustomDetail']){
                    $AlertRule.GroupingConfigurationGroupByCustomDetail = $PSBoundParameters['GroupByCustomDetail']
                    $null = $PSBoundParameters.Remove('GroupByCustomDetail')
                }
                
                If($PSBoundParameters['GroupByEntity']){
                    $AlertRule.GroupingConfigurationGroupByEntity = $PSBoundParameters['GroupByEntity']
                    $null = $PSBoundParameters.Remove('GroupByEntity')
                }

                If($PSBoundParameters['EntityMapping']){
                    $AlertRule.EntityMapping = $PSBoundParameters['EntityMapping']
                    $null = $PSBoundParameters.Remove('EntityMapping')
                }

                If($PSBoundParameters['AlertDescriptionFormat']){
                    $AlertRule.AlertDetailOverrideAlertDescriptionFormat = $PSBoundParameters['AlertDescriptionFormat']
                    $null = $PSBoundParameters.Remove('AlertDescriptionFormat')
                }

                If($PSBoundParameters['AlertDisplayNameFormat']){
                    $AlertRule.AlertDetailOverrideAlertDisplayNameFormat = $PSBoundParameters['AlertDisplayNameFormat']
                    $null = $PSBoundParameters.Remove('AlertDisplayNameFormat')
                }

                If($PSBoundParameters['AlertSeverityColumnName']){
                    $AlertRule.AlertDetailOverrideAlertSeverityColumnName = $PSBoundParameters['AlertSeverityColumnName']
                    $null = $PSBoundParameters.Remove('AlertSeverityColumnName')
                }

                If($PSBoundParameters['AlertTacticsColumnName']){
                    $AlertRule.AlertDetailOverrideAlertTacticsColumnName = $PSBoundParameters['AlertTacticsColumnName']
                    $null = $PSBoundParameters.Remove('AlertTacticsColumnName')
                }
                
            }
            #Scheduled
            if ($AlertRule.Kind -eq 'Scheduled'){
                If($PSBoundParameters['AlertRuleTemplateName']){
                    $AlertRule.Enabled = $PSBoundParameters['AlertRuleTemplateName']
                    $null = $PSBoundParameters.Remove('AlertRuleTemplateName')
                }
                
                If($PSBoundParameters['Enabled']){
                    $AlertRule.Enabled = $true
                    $null = $PSBoundParameters.Remove('Enabled')
                }
                if($PSBoundParameters['Disabled']) {
                    $AlertRule.Enabled = $false
                    $null = $PSBoundParameters.Remove('Disabled')
                }
                
                If($PSBoundParameters['Description']){
                    $AlertRule.Description = $PSBoundParameters['Description']
                    $null = $PSBoundParameters.Remove('Description')
                }
                
                If($PSBoundParameters['Query']){
                    $AlertRule.Query = $PSBoundParameters['Query']
                    $null = $PSBoundParameters.Remove('Query')
                }

                If($PSBoundParameters['DisplayName']){
                    $AlertRule.DisplayName = $PSBoundParameters['DisplayName']
                    $null = $PSBoundParameters.Remove('DisplayName')
                }

                If($PSBoundParameters['SuppressionDuration']){
                    $AlertRule.SuppressionDuration = $PSBoundParameters['SuppressionDuration']
                    $null = $PSBoundParameters.Remove('SuppressionDuration')
                }

                If($PSBoundParameters['SuppressionEnabled']){
                    $AlertRule.SuppressionEnabled = $true
                    $null = $PSBoundParameters.Remove('SuppressionEnabled')
                }
                else{
                    $AlertRule.SuppressionEnabled = $false
                }
                
                If($PSBoundParameters['Severity']){
                    $AlertRule.Severity = $PSBoundParameters['Severity']
                    $null = $PSBoundParameters.Remove('Severity')
                }

                If($PSBoundParameters['Tactic']){
                    $AlertRule.Tactic = $PSBoundParameters['Tactic']
                    $null = $PSBoundParameters.Remove('Tactic')
                }
                
                If($PSBoundParameters['CreateIncident']){
                    $AlertRule.IncidentConfigurationCreateIncident = $true
                    $null = $PSBoundParameters.Remove('CreateIncident')
                }
                else{
                    $AlertRule.IncidentConfigurationCreateIncident = $false
                }
                
                If($PSBoundParameters['GroupingConfigurationEnabled']){
                    $AlertRule.GroupingConfigurationEnabled = $true
                    $null = $PSBoundParameters.Remove('GroupingConfigurationEnabled')
                }
                else{
                    $AlertRule.GroupingConfigurationEnabled = $false
                }
                
                If($PSBoundParameters['ReOpenClosedIncident']){
                    $AlertRule.GroupingConfigurationReOpenClosedIncident = $PSBoundParameters['ReOpenClosedIncident']
                    $null = $PSBoundParameters.Remove('ReOpenClosedIncident')
                }
                else{
                    $AlertRule.GroupingConfigurationReOpenClosedIncident = $false
                }
                
                If($PSBoundParameters['LookbackDuration']){
                    $AlertRule.GroupingConfigurationLookbackDuration = $PSBoundParameters['LookbackDuration']
                    $null = $PSBoundParameters.Remove('LookbackDuration')
                }

                If($PSBoundParameters['MatchingMethod']){
                    $AlertRule.GroupingConfigurationMatchingMethod = $PSBoundParameters['MatchingMethod']
                    $null = $PSBoundParameters.Remove('MatchingMethod')
                }

                If($PSBoundParameters['GroupByAlertDetail']){
                    $AlertRule.GroupingConfigurationGroupByAlertDetail = $PSBoundParameters['GroupByAlertDetail']
                    $null = $PSBoundParameters.Remove('GroupByAlertDetail')
                }

                If($PSBoundParameters['GroupByCustomDetail']){
                    $AlertRule.GroupingConfigurationGroupByCustomDetail = $PSBoundParameters['GroupByCustomDetail']
                    $null = $PSBoundParameters.Remove('GroupByCustomDetail')
                }
                
                If($PSBoundParameters['GroupByEntity']){
                    $AlertRule.GroupingConfigurationGroupByEntity = $PSBoundParameters['GroupByEntity']
                    $null = $PSBoundParameters.Remove('GroupByEntity')
                }

                If($PSBoundParameters['EntityMapping']){
                    $AlertRule.EntityMapping = $PSBoundParameters['EntityMapping']
                    $null = $PSBoundParameters.Remove('EntityMapping')
                }

                If($PSBoundParameters['AlertDescriptionFormat']){
                    $AlertRule.AlertDetailOverrideAlertDescriptionFormat = $PSBoundParameters['AlertDescriptionFormat']
                    $null = $PSBoundParameters.Remove('AlertDescriptionFormat')
                }

                If($PSBoundParameters['AlertDisplayNameFormat']){
                    $AlertRule.AlertDetailOverrideAlertDisplayNameFormat = $PSBoundParameters['AlertDisplayNameFormat']
                    $null = $PSBoundParameters.Remove('AlertDisplayNameFormat')
                }

                If($PSBoundParameters['AlertSeverityColumnName']){
                    $AlertRule.AlertDetailOverrideAlertSeverityColumnName = $PSBoundParameters['AlertSeverityColumnName']
                    $null = $PSBoundParameters.Remove('AlertSeverityColumnName')
                }

                If($PSBoundParameters['AlertTacticsColumnName']){
                    $AlertRule.AlertDetailOverrideAlertTacticsColumnName = $PSBoundParameters['AlertTacticsColumnName']
                    $null = $PSBoundParameters.Remove('AlertTacticsColumnName')
                }

                If($PSBoundParameters['QueryFrequency']){
                    $AlertRule.QueryFrequency = $PSBoundParameters['QueryFrequency']
                    $null = $PSBoundParameters.Remove('QueryFrequency')
                }

                If($PSBoundParameters['QueryPeriod']){
                    $AlertRule.QueryPeriod = $PSBoundParameters['QueryPeriod']
                    $null = $PSBoundParameters.Remove('QueryPeriod')
                }

                If($PSBoundParameters['TriggerOperator']){
                    $AlertRule.TriggerOperator = $PSBoundParameters['TriggerOperator']
                    $null = $PSBoundParameters.Remove('TriggerOperator')
                }

                If($null -ne $PSBoundParameters['TriggerThreshold']){
                    $AlertRule.TriggerThreshold = $PSBoundParameters['TriggerThreshold']
                    $null = $PSBoundParameters.Remove('TriggerThreshold')
                }

                If($PSBoundParameters['EventGroupingSettingAggregationKind']){
                    $AlertRule.EventGroupingSettingAggregationKind = $PSBoundParameters['EventGroupingSettingAggregationKind']
                    $null = $PSBoundParameters.Remove('EventGroupingSettingAggregationKind')
                }
            }
            #TI
            if ($AlertRule.Kind -eq 'ThreatIntelligence'){
                If($PSBoundParameters['AlertRuleTemplateName']){
                    $AlertRule.AlertRuleTemplateName = $PSBoundParameters['AlertRuleTemplateName']
                    $null = $PSBoundParameters.Remove('AlertRuleTemplateName')
                }

                If($PSBoundParameters['Enabled']){
                    $AlertRule.Enabled = $true
                    $null = $PSBoundParameters.Remove('Enabled')
                }
                if($PSBoundParameters['Disabled']) {
                    $AlertRule.Enabled = $false
                    $null = $PSBoundParameters.Remove('Disabled')
                }
            }
            
            $null = $PSBoundParameters.Add('AlertRule', $AlertRule) 

            Az.SecurityInsights.internal\Update-AzSentinelAlertRule @PSBoundParameters
        }
        catch {
            throw
        }
    }
}
