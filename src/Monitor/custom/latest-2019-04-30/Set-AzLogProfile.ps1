function Set-AzLogProfile {
[OutputType('Microsoft.Azure.PowerShell.Cmdlets.Monitor.Models.Api20160301.ILogProfileResource')]
[CmdletBinding(DefaultParameterSetName="UpdateExpanded", PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Profile('latest-2019-04-30')]
[Microsoft.Azure.PowerShell.Cmdlets.Monitor.Description('Create or update a log profile in Azure Monitoring REST API.')]
param(
    [Parameter(Mandatory, HelpMessage='The name of the log profile.')]
    [Alias('LogProfileName')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='logProfileName', Required, PossibleTypes=([System.String]), Description='The name of the log profile.')]
    [System.String]
    # The name of the log profile.
    ${Name},

    [Parameter(Mandatory, HelpMessage='The Azure subscription Id.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='subscriptionId', Required, PossibleTypes=([System.String]), Description='The Azure subscription Id.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The Azure subscription Id.
    ${SubscriptionId},

    [Parameter(Mandatory, HelpMessage='the categories of the logs. These categories are created as is convenient to the user. Some values are: ''Write'', ''Delete'', and/or ''Action.''')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='categories', Required, PossibleTypes=([System.String]), Description='the categories of the logs. These categories are created as is convenient to the user. Some values are: ''Write'', ''Delete'', and/or ''Action.''')]
    [System.String[]]
    # the categories of the logs. These categories are created as is convenient to the user. Some values are: 'Write', 'Delete', and/or 'Action.'
    ${Category},

    [Parameter(Mandatory, HelpMessage='Resource location')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='location', Required, PossibleTypes=([System.String]), Description='Resource location')]
    [System.String]
    # Resource location
    ${Location},

    [Parameter(Mandatory, HelpMessage='List of regions for which Activity Log events should be stored or streamed. It is a comma separated list of valid ARM locations including the ''global'' location.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='locations', Required, PossibleTypes=([System.String]), Description='List of regions for which Activity Log events should be stored or streamed. It is a comma separated list of valid ARM locations including the ''global'' location.')]
    [System.String[]]
    # List of regions for which Activity Log events should be stored or streamed. It is a comma separated list of valid ARM locations including the 'global' location.
    ${PropertiesLocations},

    [Parameter(HelpMessage='the number of days for the retention in days. A value of 0 will retain the events indefinitely.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='days', PossibleTypes=([System.Int32]), Description='the number of days for the retention in days. A value of 0 will retain the events indefinitely.')]
    [System.Int32]
    # the number of days for the retention in days. A value of 0 will retain the events indefinitely.
    ${RetentionPolicyInDays},

    [Parameter(HelpMessage='The service bus rule ID of the service bus namespace in which you would like to have Event Hubs created for streaming the Activity Log. The rule ID is of the format: ''{service bus resource ID}/authorizationrules/{key name}''.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='serviceBusRuleId', PossibleTypes=([System.String]), Description='The service bus rule ID of the service bus namespace in which you would like to have Event Hubs created for streaming the Activity Log. The rule ID is of the format: ''{service bus resource ID}/authorizationrules/{key name}''.')]
    [System.String]
    # The service bus rule ID of the service bus namespace in which you would like to have Event Hubs created for streaming the Activity Log. The rule ID is of the format: '{service bus resource ID}/authorizationrules/{key name}'.
    ${ServiceBusRuleId},

    [Parameter(HelpMessage='the resource id of the storage account to which you would like to send the Activity Log.')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.Monitor.Runtime.Info(SerializedName='storageAccountId', PossibleTypes=([System.String]), Description='the resource id of the storage account to which you would like to send the Activity Log.')]
    [System.String]
    # the resource id of the storage account to which you would like to send the Activity Log.
    ${StorageAccountId},

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
    if ($PSBoundParameters.ContainsKey("RetentionPolicyInDays")) {
        $null = $PSBoundParameters.Add("RetentionPolicyEnabled", $true)
    } else {
        $null = $PSBoundParameters.Add("RetentionPolicyInDays", 0)
        $null = $PSBoundParameters.Add("RetentionPolicyEnabled", $false)
    }

    Az.Monitor.internal\Set-AzLogProfile @PSBoundParameters
}

}
