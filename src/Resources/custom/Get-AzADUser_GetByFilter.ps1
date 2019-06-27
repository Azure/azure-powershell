function Get-AzADUser_GetByFilter {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IUser')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile("latest-2019-04-30")]
    [CmdletBinding(PositionalBinding = $false)]
    param(
        [Parameter(Mandatory, HelpMessage='The tenant ID.')]
        [System.String]
        ${TenantId},

        [Parameter(ParameterSetName='GetByDisplayName', HelpMessage='The display name of the user.')]
        [System.String]
        ${DisplayName},

        [Parameter(ParameterSetName='GetByDisplayNamePrefix', Mandatory, HelpMessage='The prefix of the display name of the user.')]
        [System.String]
        ${StartsWith},

        [Parameter(ParameterSetName='GetByDisplayName', HelpMessage='The primary email address of the user.')]
        [Parameter(ParameterSetName='GetByDisplayNamePrefix', HelpMessage='The primary email address of the user.')]
        [System.String]
        ${Mail},

        [Parameter(ParameterSetName='GetByDisplayName', HelpMessage='The mail alias for the user.')]
        [Parameter(ParameterSetName='GetByDisplayNamePrefix', HelpMessage='The mail alias for the user.')]
        [System.String]
        ${MailNickname},

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
        $Filter = ""
        $FilterStarted = $false
        if ($PSBoundParameters.ContainsKey("DisplayName"))
        {
            $FilterStarted = $true
            $Filter += "displayname eq '$DisplayName'"
            $PSBoundParameters.Remove("DisplayName") | Out-Null
        }

        if ($PSBoundParameters.ContainsKey("StartsWith"))
        {
            $FilterStarted = $true
            $Filter += "startsWith(displayName, '$StartsWith')"
            $PSBoundParameters.Remove("StartsWith") | Out-Null
        }

        if ($PSBoundParameters.ContainsKey("Mail"))
        {
            if ($FilterStarted)
            {
                $Filter += " and "
            }

            $FilterStarted = $true
            $Filter += "mail eq '$Mail'"
            $PSBoundParameters.Remove("Mail") | Out-Null
        }

        if ($PSBoundParameters.ContainsKey("MailNickname"))
        {
            if ($FilterStarted)
            {
                $Filter += " and "
            }

            $FilterStarted = $true
            $Filter += "mailNickname eq '$MailNickname'"
            $PSBoundParameters.Remove("MailNickname") | Out-Null
        }

        $PSBoundParameters.Add("Filter", $Filter) | Out-Null
        Az.Resources\Get-AzADUser @PSBoundParameters
    }
}