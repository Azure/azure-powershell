<#
.Synopsis
Checks whether the configuration store name is available for use.
.Description
Checks whether the configuration store name is available for use.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.appconfiguration/test-azappconfigurationstorenameavailability
#>
function Test-AzAppConfigurationStoreNameAvailability {
[OutputType('Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20190201Preview.INameAvailabilityStatus')]
[CmdletBinding(DefaultParameterSetName='NoType', SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='NoType', DontShow)]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(ParameterSetName='NoType')]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(ParameterSetName='NoType', DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(ParameterSetName='NoType', DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(ParameterSetName='NoType', Mandatory)]
    [System.String]
    # The name to check for availability.
    ${Name},

    [Parameter(ParameterSetName='NoType', DontShow)]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(ParameterSetName='NoType', DontShow)]
    [ValidateNotNull()]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(ParameterSetName='NoType', DontShow)]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials},

    [Parameter(ParameterSetName='NoType')]
    [System.String]
    # The Microsoft Azure subscription ID.
    ${SubscriptionId}
)

process {
    try {
        Az.AppConfiguration\Test-AzAppConfigurationStoreNameAvailability -Type ([Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.ConfigurationResourceType]::MicrosoftAppConfigurationConfigurationStores) @PSBoundParameters
    } catch {
        throw
    }
}
}
