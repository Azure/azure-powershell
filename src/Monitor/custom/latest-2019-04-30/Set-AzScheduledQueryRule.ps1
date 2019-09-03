function Set-AzScheduledQueryRule {
[OutputType('Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20180416.ILogSearchRuleResource')]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Profile('latest-2019-04-30')]
[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Description('Creates or updates an log search rule.')]
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
    [Parameter(Mandatory, HelpMessage='The scheduled query rule Alerting Action.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(Required, PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20180416.AlertingAction]), Description='The scheduled query rule Alerting Action.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20180416.AlertingAction]
    ${AlertingAction},
    # END CUSTOM

    [Parameter(Mandatory, HelpMessage='Resource location')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='location', Required, PossibleTypes=([System.String]), Description='Resource location')]
    [System.String]
    # Resource location
    ${Location},

    [Parameter(Mandatory, HelpMessage='The resource uri over which log search query is to be run.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='dataSourceId', Required, PossibleTypes=([System.String]), Description='The resource uri over which log search query is to be run.')]
    [System.String]
    # The resource uri over which log search query is to be run.
    ${SourceDataSourceId},

    [Parameter(HelpMessage='The description of the Log Search rule.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='description', PossibleTypes=([System.String]), Description='The description of the Log Search rule.')]
    [System.String]
    # The description of the Log Search rule.
    ${Description},

    # Customization START
    [Parameter(HelpMessage='The flag which indicates whether the Log Search rule is enabled or not.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # The flag which indicates whether the Log Search rule is enabled or not.
    ${Enabled},
    # Customization END

    [Parameter(HelpMessage='frequency (in minutes) at which rule condition should be evaluated.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='frequencyInMinutes', PossibleTypes=([System.Int32]), Description='frequency (in minutes) at which rule condition should be evaluated.')]
    [System.Int32]
    # frequency (in minutes) at which rule condition should be evaluated.
    ${ScheduleFrequencyInMinute},

    [Parameter(HelpMessage='Time window for which data needs to be fetched for query (should be greater than or equal to frequencyInMinutes).')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='timeWindowInMinutes', PossibleTypes=([System.Int32]), Description='Time window for which data needs to be fetched for query (should be greater than or equal to frequencyInMinutes).')]
    [System.Int32]
    # Time window for which data needs to be fetched for query (should be greater than or equal to frequencyInMinutes).
    ${ScheduleTimeWindowInMinute},

    [Parameter(HelpMessage='List of Resource referred into query')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='authorizedResources', PossibleTypes=([System.String]), Description='List of Resource referred into query')]
    [System.String[]]
    # List of Resource referred into query
    ${SourceAuthorizedResource},

    [Parameter(HelpMessage='Log search query. Required for action type - AlertingAction')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='query', PossibleTypes=([System.String]), Description='Log search query. Required for action type - AlertingAction')]
    [System.String]
    # Log search query. Required for action type - AlertingAction
    ${SourceQuery},

    [Parameter(HelpMessage='Set value to ''ResultCount'' .')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Monitor.Support.QueryType])]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='queryType', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Monitor.Support.QueryType]), Description='Set value to ''ResultCount'' .')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Support.QueryType]
    # Set value to 'ResultCount' .
    ${SourceQueryType},

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
    if ($PSBoundParameters.ContainsKey("Enabled") -and ($PSBoundParameters["Enabled"] -eq $true)) {
        $PSBoundParameters["Enabled"] = "true"
    } else {
        $PSBoundParameters["Enabled"] = "false"
    }

    $PSBoundParameters["AlertingAction"].Odatatype = "Microsoft.WindowsAzure.Management.Monitoring.Alerts.Models.Microsoft.AppInsights.Nexus.DataContracts.Resources.ScheduledQueryRules.AlertingAction"
    $PSBoundParameters["Action"] = $PSBoundParameters["AlertingAction"]
    $null = $PSBoundParameters.Remove("AlertingAction")

    Az.Monitor.internal\Set-AzScheduledQueryRule @PSBoundParameters
}
}
