function Set-AzPolicyDefinition_UpdateById {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicyDefinition')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    param(
        [Parameter(HelpMessage='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String[]]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='The ID of the policy definition.')]
        [Alias('ResourceId')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [System.String]
        ${Id},

        [Parameter(HelpMessage='The policy definition description.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String]
        ${Description},

        [Parameter(HelpMessage='The display name of the policy definition.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.String]
        ${DisplayName},

        [Parameter(HelpMessage='The policy definition metadata.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20161201.IPolicyDefinitionPropertiesMetadata]
        ${Metadata},

        [Parameter(HelpMessage='The policy definition mode. Possible values are NotSpecified, Indexed, and All.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.PolicyMode])]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.PolicyMode]
        ${Mode},

        [Parameter(HelpMessage='The policy rule.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20161201.IPolicyDefinitionPropertiesPolicyRule]
        ${PolicyRule},

        [Parameter(HelpMessage='The type of policy definition. Possible values are NotSpecified, BuiltIn, and Custom.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.PolicyType])]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.PolicyType]
        ${PolicyType},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Azure')]
        [System.Management.Automation.PSObject]
        ${DefaultProfile},

        [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${Break},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.SendAsyncStep[]]
        ${HttpPipelineAppend},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.SendAsyncStep[]]
        ${HttpPipelinePrepend},

        [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Uri]
        ${Proxy},

        [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        ${ProxyCredential},

        [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        ${ProxyUseDefaultCredentials}
    )

    process {
        $Tokens = $Id.Split("/", [System.StringSplitOptions]::RemoveEmptyEntries)
        if ($Tokens[0] -eq "subscriptions")
        {
            $PSBoundParameters.Add("SubscriptionId", $Tokens[1]) | Out-Null
            $PSBoundParameters.Add("Name", $Tokens[5]) | Out-Null
        }
        else
        {
            $PSBoundParameters.Add("ManagementGroupName", $Tokens[3]) | Out-Null
            $PSBoundParameters.Add("Name", $Tokens[7]) | Out-Null
        }

        $PSBoundParameters.Remove("Id") | Out-Null
        Az.Resources\Set-AzPolicyDefinition @PSBoundParameters
    }
}