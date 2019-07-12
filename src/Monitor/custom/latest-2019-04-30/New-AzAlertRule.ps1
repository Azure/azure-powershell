<#
.Synopsis
Creates or updates an alert rule.
.Description
Creates or updates an alert rule.
.Example
To view examples, please use the -Online parameter with Get-Help or navigate to: https://docs.microsoft.com/en-us/powershell/module/az.monitor/new-azalertrule
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20160301.IAlertRuleResource
.Notes
COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

ACTION <IRuleAction[]>: the array of actions that are performed when the alert rule becomes active, and when an alert condition is resolved.
  OdataType <String>: specifies the type of the action. There are two types of actions: RuleEmailAction and RuleWebhookAction.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.monitor/new-azalertrule
#>
function New-AzAlertRule {
[Alias('Add-AzMetricAlertRule')]
[OutputType('Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20160301.IAlertRuleResource')]
[CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Profile('latest-2019-04-30')]
[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Description('Creates or updates an alert rule.')]
param(
    [Parameter(Mandatory, HelpMessage='The name of the rule.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='ruleName', Required, PossibleTypes=([System.String]), Description='The name of the rule.')]
    [System.String]
    # The name of the rule.
    ${Name},

    [Parameter(Mandatory, HelpMessage='The name of the resource group.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='resourceGroupName', Required, PossibleTypes=([System.String]), Description='The name of the resource group.')]
    [System.String]
    # The name of the resource group.
    ${ResourceGroupName},

    [Parameter(Mandatory, HelpMessage='The Azure subscription Id.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='subscriptionId', Required, PossibleTypes=([System.String]), Description='The Azure subscription Id.')]
    [System.String]
    # The Azure subscription Id.
    ${SubscriptionId},

    #[Parameter(Mandatory, HelpMessage='specifies the type of condition. This can be one of three types: ManagementEventRuleCondition (occurrences of management events), LocationThresholdRuleCondition (based on the number of failures of a web test), and ThresholdRuleCondition (based on the threshold of a metric).')]
    #[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    #[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='odata.type', Required, PossibleTypes=([System.String]), Description='specifies the type of condition. This can be one of three types: ManagementEventRuleCondition (occurrences of management events), LocationThresholdRuleCondition (based on the number of failures of a web test), and ThresholdRuleCondition (based on the threshold of a metric).')]
    #[System.String]
    # specifies the type of condition. This can be one of three types: ManagementEventRuleCondition (occurrences of management events), LocationThresholdRuleCondition (based on the number of failures of a web test), and ThresholdRuleCondition (based on the threshold of a metric).
    #${ConditionOdataType},

    [Parameter(HelpMessage='The window size for rule.')]
    [System.TimeSpan]
    ${WindowSize},

    [Parameter(HelpMessage = "The aggregation operation used to roll up multiple metric values across the window interval.")]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Monitor.Support.TimeAggregationOperator])]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Support.TimeAggregationOperator]
    ${TimeAggregationOperator},

    [Parameter(Mandatory, HelpMessage = "The threshold for rule condition.")]
    [System.Double]
    ${Threshold},

    [Parameter(Mandatory, HelpMessage = "The rule condition operator.")]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Monitor.Support.ConditionOperator])]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Support.ConditionOperator]
    ${Operator},

    [Parameter(Mandatory, HelpMessage='the flag that indicates whether the alert rule is enabled.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='isEnabled', Required, PossibleTypes=([System.Management.Automation.SwitchParameter]), Description='the flag that indicates whether the alert rule is enabled.')]
    [System.Management.Automation.SwitchParameter]
    # the flag that indicates whether the alert rule is enabled.
    ${IsEnabled},

    [Parameter(Mandatory, HelpMessage='Resource location')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='location', Required, PossibleTypes=([System.String]), Description='Resource location')]
    [System.String]
    # Resource location
    ${Location},

    [Parameter(HelpMessage='the array of actions that are performed when the alert rule becomes active, and when an alert condition is resolved. To construct, see NOTES section for ACTION properties and create a hash table.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='actions', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20160301.IRuleAction]), Description='the array of actions that are performed when the alert rule becomes active, and when an alert condition is resolved.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20160301.IRuleAction[]]
    # the array of actions that are performed when the alert rule becomes active, and when an alert condition is resolved.
    # To construct, see NOTES section for ACTION properties and create a hash table.
    ${Action},

    #[Parameter(HelpMessage='specifies the type of data source. There are two types of rule data sources: RuleMetricDataSource and RuleManagementEventDataSource')]
    #[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    #[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='odata.type', PossibleTypes=([System.String]), Description='specifies the type of data source. There are two types of rule data sources: RuleMetricDataSource and RuleManagementEventDataSource')]
    #[System.String]
    ## specifies the type of data source. There are two types of rule data sources: RuleMetricDataSource and RuleManagementEventDataSource
    #${DataSourceOdataType},
    #
    #[Parameter(HelpMessage='the resource identifier of the resource the rule monitors. **NOTE**: this property cannot be updated for an existing rule.')]
    #[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    #[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='resourceUri', PossibleTypes=([System.String]), Description='the resource identifier of the resource the rule monitors. **NOTE**: this property cannot be updated for an existing rule.')]
    #[System.String]
    ## the resource identifier of the resource the rule monitors. **NOTE**: this property cannot be updated for an existing rule.
    #${DataSourceResourceUri},

    [Parameter(HelpMessage='the description of the alert rule that will be included in the alert email.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='description', PossibleTypes=([System.String]), Description='the description of the alert rule that will be included in the alert email.')]
    [System.String]
    # the description of the alert rule that will be included in the alert email.
    ${Description},

    [Parameter(HelpMessage='Resource tags')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='tags', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20150401.IResourceTags]), Description='Resource tags')]
    [System.Collections.Hashtable]
    # Resource tags
    ${Tag},

    [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

process {
    $null = $PSBoundParameters.Add("PropertiesName", $PSBoundParameters["Name"])

    $null = $PSBoundParameters.Add("DataSourceOdataType", "Microsoft.Azure.Management.Insights.Models.ThresholdRuleCondition")

    Az.Monitor.internal\New-AzAlertRule @PSBoundParameters
}

}
