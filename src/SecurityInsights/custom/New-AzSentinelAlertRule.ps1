
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
Creates or updates the alert rule.
.Description
Creates or updates the alert rule.

.Link
https://docs.microsoft.com/powershell/module/az.securityinsights/new-azsentinelalertrule
#>
function New-AzSentinelAlertRule {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.AlertRule])]
    [CmdletBinding(DefaultParameterSetName = 'FusionMLTI', PositionalBinding = $false, SupportsShouldProcess, ConfirmImpact = 'Medium')]
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
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [System.String]
        # The name of the workspace.
        ${WorkspaceName},

        [Parameter()]
        #[Alias('RuleId')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.DefaultInfo(Script = '(New-Guid).Guid')]
        [System.String]
        # The Id of the Rule.
        ${RuleId},

        [Parameter(Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertRuleKind])]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertRuleKind]
        # Kind of the the data connection
        ${Kind},

        [Parameter(ParameterSetName = 'FusionMLTI', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${AlertRuleTemplate},

        [Parameter(ParameterSetName = 'MicrosoftSecurityIncidentCreation')]
        [Parameter(ParameterSetName = 'NRT')]
        [Parameter(ParameterSetName = 'Scheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${AlertRuleTemplateName},
        
        [Parameter(ParameterSetName = 'FusionMLTI')]
        [Parameter(ParameterSetName = 'MicrosoftSecurityIncidentCreation')]
        [Parameter(ParameterSetName = 'NRT')]
        [Parameter(ParameterSetName = 'Scheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Switch]
        ${Enabled},

        [Parameter(ParameterSetName = 'FusionMLTI')]
        [Parameter(ParameterSetName = 'MicrosoftSecurityIncidentCreation')]
        [Parameter(ParameterSetName = 'NRT')]
        [Parameter(ParameterSetName = 'Scheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Switch]
        ${Disabled},

        [Parameter(ParameterSetName = 'MicrosoftSecurityIncidentCreation')]
        [Parameter(ParameterSetName = 'NRT')]
        [Parameter(ParameterSetName = 'Scheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${Description},

        [Parameter(ParameterSetName = 'MicrosoftSecurityIncidentCreation')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${DisplayNamesFilter},

        [Parameter(ParameterSetName = 'MicrosoftSecurityIncidentCreation')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${DisplayNamesExcludeFilter},


        [Parameter(ParameterSetName = 'MicrosoftSecurityIncidentCreation', Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.MicrosoftSecurityProductName])]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.MicrosoftSecurityProductName]
        ${ProductFilter},
            
        [Parameter(ParameterSetName = 'MicrosoftSecurityIncidentCreation')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertSeverity[]]
        #High, Medium, Low, Informational
        ${SeveritiesFilter},

        [Parameter(ParameterSetName = 'NRT', Mandatory)]
        [Parameter(ParameterSetName = 'Scheduled', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${Query},
        
        [Parameter(ParameterSetName = 'NRT', Mandatory)]
        [Parameter(ParameterSetName = 'Scheduled', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${DisplayName},

        [Parameter(ParameterSetName = 'NRT')]
        [Parameter(ParameterSetName = 'Scheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.DefaultInfo(Script = 'New-TimeSpan -Hours 5')]
        [System.TimeSpan]
        ${SuppressionDuration},

        [Parameter(ParameterSetName = 'NRT')]
        [Parameter(ParameterSetName = 'Scheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Switch]
        ${SuppressionEnabled},

        [Parameter(ParameterSetName = 'NRT', Mandatory)]
        [Parameter(ParameterSetName = 'Scheduled', Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertSeverity])]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertSeverity]
        ${Severity},

        [Parameter(ParameterSetName = 'NRT')]
        [Parameter(ParameterSetName = 'Scheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        #[Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AttackTactic]
        [System.String]
        #InitialAccess, Execution, Persistence, PrivilegeEscalation, DefenseEvasion, CredentialAccess, Discovery, LateralMovement, Collection, Exfiltration, CommandAndControl, Impact, PreAttack
        ${Tactic},
        
        [Parameter(ParameterSetName = 'NRT')]
        [Parameter(ParameterSetName = 'Scheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Switch]
        ${IncidentConfigurationCreateIncident},

        [Parameter(ParameterSetName = 'NRT')]
        [Parameter(ParameterSetName = 'Scheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Switch]
        ${GroupingConfigurationEnabled},

        [Parameter(ParameterSetName = 'NRT')]
        [Parameter(ParameterSetName = 'Scheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Switch]
        ${GroupingConfigurationReOpenClosedIncident},

        [Parameter(ParameterSetName = 'NRT')]
        [Parameter(ParameterSetName = 'Scheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.DefaultInfo(Script = 'New-TimeSpan -Hours 5')]
        [System.TimeSpan]
        ${GroupingConfigurationLookbackDuration},

        [Parameter(ParameterSetName = 'NRT')]
        [Parameter(ParameterSetName = 'Scheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Runtime.DefaultInfo(Script = '"AllEntities"')]
        [ValidateSet('AllEntities', 'AnyAlert', 'Selected')]
        [System.String]
        ${GroupingConfigurationMatchingMethod},
            
        
        [Parameter(ParameterSetName = 'NRT')]
        [Parameter(ParameterSetName = 'Scheduled')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertDetail])]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.AlertDetail]
        ${GroupingConfigurationGroupByAlertDetail}, 
        
        [Parameter(ParameterSetName = 'NRT')]
        [Parameter(ParameterSetName = 'Scheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [string[]] 
        ${GroupingConfigurationGroupByCustomDetail},
        
        [Parameter(ParameterSetName = 'NRT')]
        [Parameter(ParameterSetName = 'Scheduled')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EntityMappingType])]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.EntityMappingType]
        ${GroupingConfigurationGroupByEntity},
    
        
        [Parameter(ParameterSetName = 'NRT')]
        [Parameter(ParameterSetName = 'Scheduled')]
        #'Account', 'Host', 'IP', 'Malware', 'File', 'Process', 'CloudApplication', 'DNS', 'AzureResource', 'FileHash', 'RegistryKey', 'RegistryValue', 'SecurityGroup', 'URL', 'Mailbox', 'MailCluster', 'MailMessage', 'SubmissionMail'
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.EntityMapping]
        ${EntityMapping},

        [Parameter(ParameterSetName = 'NRT')]
        [Parameter(ParameterSetName = 'Scheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${AlertDetailOverrideAlertDescriptionFormat},

        [Parameter(ParameterSetName = 'NRT')]
        [Parameter(ParameterSetName = 'Scheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${AlertDetailOverrideAlertDisplayNameFormat},

        [Parameter(ParameterSetName = 'NRT')]
        [Parameter(ParameterSetName = 'Scheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${AlertDetailOverrideAlertSeverityColumnName},

        [Parameter(ParameterSetName = 'NRT')]
        [Parameter(ParameterSetName = 'Scheduled')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.String]
        ${AlertDetailOverrideAlertTacticsColumnName},


        [Parameter(ParameterSetName = 'Scheduled', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.TimeSpan]
        ${QueryFrequency},

        [Parameter(ParameterSetName = 'Scheduled', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [System.TimeSpan]
        ${QueryPeriod},

        [Parameter(ParameterSetName = 'Scheduled', Mandatory)]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.TriggerOperator])]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.TriggerOperator]
        ${TriggerOperator},
        
        [Parameter(ParameterSetName = 'Scheduled', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Category('Body')]
        [int]
        ${TriggerThreshold},

        [Parameter(ParameterSetName = 'Scheduled')]
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
            #Fusion
            if ($PSBoundParameters['Kind'] -eq 'Fusion'){
                $AlertRule = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.FusionAlertRule]::new()
                
                $AlertRule.AlertRuleTemplateName = $PSBoundParameters['AlertRuleTemplate']
                $null = $PSBoundParameters.Remove('AlertRuleTemplate')
                
                If($PSBoundParameters['Enabled']){
                    $AlertRule.Enabled = $PSBoundParameters['Enabled']
                    $null = $PSBoundParameters.Remove('Enabled')
                }
                
                If($PSBoundParameters['Disabled']){
                    $AlertRule.Enabled = $PSBoundParameters['Disabled']
                    $null = $PSBoundParameters.Remove('Disabled')
                }
            }
            #MSIC
            if($PSBoundParameters['Kind'] -eq 'MicrosoftSecurityIncidentCreation'){
                $AlertRule = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.MicrosoftSecurityIncidentCreationAlertRule]::new()
                
                If($PSBoundParameters['AlertRuleTemplateName']){
                    $AlertRule.AlertRuleTemplateName = $PSBoundParameters['AlertRuleTemplateName']
                    $null = $PSBoundParameters.Remove('AlertRuleTemplateName')
                }
                
                If($PSBoundParameters['Enabled']){
                    $AlertRule.Enabled = $PSBoundParameters['Enabled']
                    $null = $PSBoundParameters.Remove('Enabled')
                }
                
                If($PSBoundParameters['Disabled']){
                    $AlertRule.Enabled = $PSBoundParameters['Disabled']
                    $null = $PSBoundParameters.Remove('Disabled')
                }
                
                If($PSBoundParameters['Description']){
                    $AlertRule.Enabled = $PSBoundParameters['Description']
                    $null = $PSBoundParameters.Remove('Description')
                }
                
                If($PSBoundParameters['DisplayNamesFilter']){
                    $AlertRule.Enabled = $PSBoundParameters['DisplayNamesFilter']
                    $null = $PSBoundParameters.Remove('DisplayNamesFilter')
                }
                
                If($PSBoundParameters['DisplayNamesExcludeFilter']){
                    $AlertRule.Enabled = $PSBoundParameters['DisplayNamesExcludeFilter']
                    $null = $PSBoundParameters.Remove('DisplayNamesExcludeFilter')
                }
                
                $AlertRule.ProductFilter = $PSBoundParameters['ProductFilter']
                $null = $PSBoundParameters.Remove('ProductFilter')

                If($PSBoundParameters['SeveritiesFilter']){
                    $AlertRule.Enabled = $PSBoundParameters['SeveritiesFilter']
                    $null = $PSBoundParameters.Remove('SeveritiesFilter')
                }
            }
            #ML
            if ($PSBoundParameters['Kind'] -eq 'MLBehaviorAnalytics'){
                $AlertRule = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.MlBehaviorAnalyticsAlertRule]::new()
                
                $AlertRule.AlertRuleTemplateName = $PSBoundParameters['AlertRuleTemplate']
                $null = $PSBoundParameters.Remove('AlertRuleTemplate')
                
                If($PSBoundParameters['Enabled']){
                    $AlertRule.Enabled = $PSBoundParameters['Enabled']
                    $null = $PSBoundParameters.Remove('Enabled')
                }
                
                If($PSBoundParameters['Disabled']){
                    $AlertRule.Enabled = $PSBoundParameters['Disabled']
                    $null = $PSBoundParameters.Remove('Disabled')
                }
            }

            #NRT
            if($PSBoundParameters['Kind'] -eq 'NRT'){
                $AlertRule = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.NrtAlertRule]::new()
                
                If($PSBoundParameters['AlertRuleTemplateName']){
                    $AlertRule.AlertRuleTemplateName = $PSBoundParameters['AlertRuleTemplateName']
                    $null = $PSBoundParameters.Remove('AlertRuleTemplateName')
                }
                
                If($PSBoundParameters['Enabled']){
                    $AlertRule.Enabled = $PSBoundParameters['Enabled']
                    $null = $PSBoundParameters.Remove('Enabled')
                }
                
                If($PSBoundParameters['Disabled']){
                    $AlertRule.Enabled = $PSBoundParameters['Disabled']
                    $null = $PSBoundParameters.Remove('Disabled')
                }
                
                If($PSBoundParameters['Description']){
                    $AlertRule.Enabled = $PSBoundParameters['Description']
                    $null = $PSBoundParameters.Remove('Description')
                }
                
                $AlertRule.Query = $PSBoundParameters['Query']
                $null = $PSBoundParameters.Remove('Query')
                
                $AlertRule.DisplayName = $PSBoundParameters['DisplayName']
                $null = $PSBoundParameters.Remove('DisplayName')
                
                $AlertRule.SuppressionDuration = $PSBoundParameters['SuppressionDuration']
                $null = $PSBoundParameters.Remove('SuppressionDuration')
                
                If($PSBoundParameters['SuppressionEnabled']){
                    $AlertRule.SuppressionEnabled = $PSBoundParameters['SuppressionEnabled']
                    $null = $PSBoundParameters.Remove('SuppressionEnabled')
                }
                else{
                    $AlertRule.SuppressionEnabled = $false
                }
                
                $AlertRule.Severity = $PSBoundParameters['Severity']
                $null = $PSBoundParameters.Remove('Severity')
                
                If($PSBoundParameters['Tactic']){
                    $AlertRule.Tactic = $PSBoundParameters['Tactic']
                    $null = $PSBoundParameters.Remove('Tactic')
                }
                
                If($PSBoundParameters['IncidentConfigurationCreateIncident']){
                    $AlertRule.IncidentConfigurationCreateIncident = $PSBoundParameters['IncidentConfigurationCreateIncident']
                    $null = $PSBoundParameters.Remove('IncidentConfigurationCreateIncident')
                }
                else{
                    $AlertRule.IncidentConfigurationCreateIncident = $false
                }
                
                If($PSBoundParameters['GroupingConfigurationEnabled']){
                    $AlertRule.GroupingConfigurationEnabled = $PSBoundParameters['GroupingConfigurationEnabled']
                    $null = $PSBoundParameters.Remove('GroupingConfigurationEnabled')
                }
                else{
                    $AlertRule.GroupingConfigurationEnabled = $false
                }
                
                If($PSBoundParameters['GroupingConfigurationReOpenClosedIncident']){
                    $AlertRule.GroupingConfigurationReOpenClosedIncident = $PSBoundParameters['GroupingConfigurationReOpenClosedIncident']
                    $null = $PSBoundParameters.Remove('GroupingConfigurationReOpenClosedIncident')
                }
                else{
                    $AlertRule.GroupingConfigurationReOpenClosedIncident = $false
                }
                
                $AlertRule.GroupingConfigurationLookbackDuration = $PSBoundParameters['GroupingConfigurationLookbackDuration']
                $null = $PSBoundParameters.Remove('GroupingConfigurationLookbackDuration')
                
                $AlertRule.GroupingConfigurationMatchingMethod = $PSBoundParameters['GroupingConfigurationMatchingMethod']
                $null = $PSBoundParameters.Remove('GroupingConfigurationMatchingMethod')
                
                If($PSBoundParameters['GroupingConfigurationGroupByAlertDetail']){
                    $AlertRule.GroupingConfigurationGroupByAlertDetail = $PSBoundParameters['GroupingConfigurationGroupByAlertDetail']
                    $null = $PSBoundParameters.Remove('GroupingConfigurationGroupByAlertDetail')
                }

                If($PSBoundParameters['GroupingConfigurationGroupByCustomDetail']){
                    $AlertRule.GroupingConfigurationGroupByCustomDetail = $PSBoundParameters['GroupingConfigurationGroupByCustomDetail']
                    $null = $PSBoundParameters.Remove('GroupingConfigurationGroupByCustomDetail')
                }
                
                If($PSBoundParameters['GroupingConfigurationGroupByEntity']){
                    $AlertRule.GroupingConfigurationGroupByEntity = $PSBoundParameters['GroupingConfigurationGroupByEntity']
                    $null = $PSBoundParameters.Remove('GroupingConfigurationGroupByEntity')
                }

                If($PSBoundParameters['EntityMapping']){
                    $AlertRule.EntityMapping = $PSBoundParameters['EntityMapping']
                    $null = $PSBoundParameters.Remove('EntityMapping')
                }

                If($PSBoundParameters['AlertDetailOverrideAlertDescriptionFormat']){
                    $AlertRule.AlertDetailOverrideAlertDescriptionFormat = $PSBoundParameters['AlertDetailOverrideAlertDescriptionFormat']
                    $null = $PSBoundParameters.Remove('AlertDetailOverrideAlertDescriptionFormat')
                }

                If($PSBoundParameters['AlertDetailOverrideAlertDisplayNameFormat']){
                    $AlertRule.AlertDetailOverrideAlertDisplayNameFormat = $PSBoundParameters['AlertDetailOverrideAlertDisplayNameFormat']
                    $null = $PSBoundParameters.Remove('AlertDetailOverrideAlertDisplayNameFormat')
                }

                If($PSBoundParameters['AlertDetailOverrideAlertSeverityColumnName']){
                    $AlertRule.AlertDetailOverrideAlertSeverityColumnName = $PSBoundParameters['AlertDetailOverrideAlertSeverityColumnName']
                    $null = $PSBoundParameters.Remove('AlertDetailOverrideAlertSeverityColumnName')
                }

                If($PSBoundParameters['AlertDetailOverrideAlertTacticsColumnName']){
                    $AlertRule.AlertDetailOverrideAlertTacticsColumnName = $PSBoundParameters['AlertDetailOverrideAlertTacticsColumnName']
                    $null = $PSBoundParameters.Remove('AlertDetailOverrideAlertTacticsColumnName')
                }
                
            }
            #Scheduled
            if ($PSBoundParameters['Kind'] -eq 'Scheduled'){
                $AlertRule = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.ScheduledAlertRule]::new()
                
                If($PSBoundParameters['AlertRuleTemplateName']){
                    $AlertRule.AlertRuleTemplateName = $PSBoundParameters['AlertRuleTemplateName']
                    $null = $PSBoundParameters.Remove('AlertRuleTemplateName')
                }
                
                If($PSBoundParameters['Enabled']){
                    $AlertRule.Enabled = $PSBoundParameters['Enabled']
                    $null = $PSBoundParameters.Remove('Enabled')
                }
                
                If($PSBoundParameters['Disabled']){
                    $AlertRule.Enabled = $PSBoundParameters['Disabled']
                    $null = $PSBoundParameters.Remove('Disabled')
                }
                
                If($PSBoundParameters['Description']){
                    $AlertRule.Description = $PSBoundParameters['Description']
                    $null = $PSBoundParameters.Remove('Description')
                }
                
                $AlertRule.Query = $PSBoundParameters['Query']
                $null = $PSBoundParameters.Remove('Query')
                
                $AlertRule.DisplayName = $PSBoundParameters['DisplayName']
                $null = $PSBoundParameters.Remove('DisplayName')
                
                $AlertRule.SuppressionDuration = $PSBoundParameters['SuppressionDuration']
                $null = $PSBoundParameters.Remove('SuppressionDuration')
                
                If($PSBoundParameters['SuppressionEnabled']){
                    $AlertRule.SuppressionEnabled = $PSBoundParameters['SuppressionEnabled']
                    $null = $PSBoundParameters.Remove('SuppressionEnabled')
                }
                else{
                    $AlertRule.SuppressionEnabled = $false
                }
                
                $AlertRule.Severity = $PSBoundParameters['Severity']
                $null = $PSBoundParameters.Remove('Severity')
                
                If($PSBoundParameters['Tactic']){
                    $AlertRule.Tactic = $PSBoundParameters['Tactic']
                    $null = $PSBoundParameters.Remove('Tactic')
                }
                
                If($PSBoundParameters['IncidentConfigurationCreateIncident']){
                    $AlertRule.IncidentConfigurationCreateIncident = $PSBoundParameters['IncidentConfigurationCreateIncident']
                    $null = $PSBoundParameters.Remove('IncidentConfigurationCreateIncident')
                }
                else{
                    $AlertRule.IncidentConfigurationCreateIncident = $false
                }
                
                If($PSBoundParameters['GroupingConfigurationEnabled']){
                    $AlertRule.GroupingConfigurationEnabled = $PSBoundParameters['GroupingConfigurationEnabled']
                    $null = $PSBoundParameters.Remove('GroupingConfigurationEnabled')
                }
                else{
                    $AlertRule.GroupingConfigurationEnabled = $false
                }
                
                If($PSBoundParameters['GroupingConfigurationReOpenClosedIncident']){
                    $AlertRule.GroupingConfigurationReOpenClosedIncident = $PSBoundParameters['GroupingConfigurationReOpenClosedIncident']
                    $null = $PSBoundParameters.Remove('GroupingConfigurationReOpenClosedIncident')
                }
                else{
                    $AlertRule.GroupingConfigurationReOpenClosedIncident = $false
                }
                
                $AlertRule.GroupingConfigurationLookbackDuration = $PSBoundParameters['GroupingConfigurationLookbackDuration']
                $null = $PSBoundParameters.Remove('GroupingConfigurationLookbackDuration')
                
                $AlertRule.GroupingConfigurationMatchingMethod = $PSBoundParameters['GroupingConfigurationMatchingMethod']
                $null = $PSBoundParameters.Remove('GroupingConfigurationMatchingMethod')
                
                If($PSBoundParameters['GroupingConfigurationGroupByAlertDetail']){
                    $AlertRule.GroupingConfigurationGroupByAlertDetail = $PSBoundParameters['GroupingConfigurationGroupByAlertDetail']
                    $null = $PSBoundParameters.Remove('GroupingConfigurationGroupByAlertDetail')
                }

                If($PSBoundParameters['GroupingConfigurationGroupByCustomDetail']){
                    $AlertRule.GroupingConfigurationGroupByCustomDetail = $PSBoundParameters['GroupingConfigurationGroupByCustomDetail']
                    $null = $PSBoundParameters.Remove('GroupingConfigurationGroupByCustomDetail')
                }
                
                If($PSBoundParameters['GroupingConfigurationGroupByEntity']){
                    $AlertRule.GroupingConfigurationGroupByEntity = $PSBoundParameters['GroupingConfigurationGroupByEntity']
                    $null = $PSBoundParameters.Remove('GroupingConfigurationGroupByEntity')
                }

                If($PSBoundParameters['EntityMapping']){
                    $AlertRule.EntityMapping = $PSBoundParameters['EntityMapping']
                    $null = $PSBoundParameters.Remove('EntityMapping')
                }

                If($PSBoundParameters['AlertDetailOverrideAlertDescriptionFormat']){
                    $AlertRule.AlertDetailOverrideAlertDescriptionFormat = $PSBoundParameters['AlertDetailOverrideAlertDescriptionFormat']
                    $null = $PSBoundParameters.Remove('AlertDetailOverrideAlertDescriptionFormat')
                }

                If($PSBoundParameters['AlertDetailOverrideAlertDisplayNameFormat']){
                    $AlertRule.AlertDetailOverrideAlertDisplayNameFormat = $PSBoundParameters['AlertDetailOverrideAlertDisplayNameFormat']
                    $null = $PSBoundParameters.Remove('AlertDetailOverrideAlertDisplayNameFormat')
                }

                If($PSBoundParameters['AlertDetailOverrideAlertSeverityColumnName']){
                    $AlertRule.AlertDetailOverrideAlertSeverityColumnName = $PSBoundParameters['AlertDetailOverrideAlertSeverityColumnName']
                    $null = $PSBoundParameters.Remove('AlertDetailOverrideAlertSeverityColumnName')
                }

                If($PSBoundParameters['AlertDetailOverrideAlertTacticsColumnName']){
                    $AlertRule.AlertDetailOverrideAlertTacticsColumnName = $PSBoundParameters['AlertDetailOverrideAlertTacticsColumnName']
                    $null = $PSBoundParameters.Remove('AlertDetailOverrideAlertTacticsColumnName')
                }

                $AlertRule.QueryFrequency = $PSBoundParameters['QueryFrequency']
                $null = $PSBoundParameters.Remove('QueryFrequency')

                $AlertRule.QueryPeriod = $PSBoundParameters['QueryPeriod']
                $null = $PSBoundParameters.Remove('QueryPeriod')

                $AlertRule.TriggerOperator = $PSBoundParameters['TriggerOperator']
                $null = $PSBoundParameters.Remove('TriggerOperator')

                $AlertRule.TriggerThreshold = $PSBoundParameters['TriggerThreshold']
                $null = $PSBoundParameters.Remove('TriggerThreshold')

                If($PSBoundParameters['EventGroupingSettingAggregationKind']){
                    $AlertRule.EventGroupingSettingAggregationKind = $PSBoundParameters['EventGroupingSettingAggregationKind']
                    $null = $PSBoundParameters.Remove('EventGroupingSettingAggregationKind')
                }
            }
            #TI
            if ($PSBoundParameters['Kind'] -eq 'ThreatIntelligence'){
                $AlertRule = [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.ThreatIntelligenceAlertRule]::new()
                
                $AlertRule.AlertRuleTemplateName = $PSBoundParameters['AlertRuleTemplate']
                $null = $PSBoundParameters.Remove('AlertRuleTemplate')
                
                If($PSBoundParameters['Enabled']){
                    $AlertRule.Enabled = $PSBoundParameters['Enabled']
                    $null = $PSBoundParameters.Remove('Enabled')
                }
                If($PSBoundParameters['Disabled']){
                    $AlertRule.Enabled = $PSBoundParameters['Disabled']
                    $null = $PSBoundParameters.Remove('Disabled')
                }
            }
            
            $null = $PSBoundParameters.Remove('FusionMLTI')

            $AlertRule.Kind = $PSBoundParameters['Kind']
            $null = $PSBoundParameters.Remove('Kind')

            $null = $PSBoundParameters.Add('AlertRule', $AlertRule) 

            Az.SecurityInsights.internal\New-AzSentinelAlertRule @PSBoundParameters
        }
        catch {
            throw
        }
    }
}