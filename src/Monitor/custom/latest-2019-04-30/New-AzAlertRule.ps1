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
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The Azure subscription Id.
    ${SubscriptionId},

    # CUSTOM
    [Parameter(Mandatory, HelpMessage='The window size for rule.')]
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

    [Parameter(Mandatory, HelpMessage = "The metric name for rule.")]
    [System.String]
    ${MetricName},

    [Parameter(Mandatory, HelpMessage = "The target resource id for rule.")]
    [System.String]
    ${TargetResourceId},
    # END CUSTOM

    [Parameter(Mandatory, HelpMessage='the flag that indicates whether the alert rule is enabled.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='isEnabled', Required, PossibleTypes=([System.Management.Automation.SwitchParameter]), Description='the flag that indicates whether the alert rule is enabled.')]
    [System.Management.Automation.SwitchParameter]
    # the flag that indicates whether the alert rule is enabled.
    ${Enabled},

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
    $PSBoundParameters["PropertiesName"] = $PSBoundParameters["Name"]
    
    $PSBoundParameters["Condition"] = [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20160301.ThresholdRuleCondition]@{
                                            odatatype="Microsoft.Azure.Management.Insights.Models.ThresholdRuleCondition"
                                            threshold=$PSBoundParameters["Threshold"]
                                            operator=$PSBoundParameters["Operator"]
                                            windowSize=$PSBoundParameters["WindowSize"]
                                            datasource=[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20160301.RuleMetricDataSource]@{
                                                    odatatype="Microsoft.Azure.Management.Insights.Models.RuleMetricDataSource"
                                                    MetricName=$PSBoundParameters["MetricName"]
                                                    ResourceUri=$PSBoundParameters["TargetResourceId"]
                                            }
                                        }

    if ($PSBoundParameters.ContainsKey("TimeAggregationOperator")) {
        $PSBoundParameters["Condition"].TimeAggregation = $PSBoundParameters["TimeAggregationOperator"]
    }

    $null = $PSBoundParameters.Remove("Threshold")
    $null = $PSBoundParameters.Remove("Operator")
    $null = $PSBoundParameters.Remove("WindowSize")
    $null = $PSBoundParameters.Remove("TimeAggregationOperator")
    $null = $PSBoundParameters.Remove("MetricName")
    $null = $PSBoundParameters.Remove("TargetResourceId")

    Az.Monitor.internal\New-AzAlertRule @PSBoundParameters
}

}
