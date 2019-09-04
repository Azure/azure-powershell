function New-AzADServicePrincipalPasswordCredential {
    [OutputType('System.Boolean')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Description('Adds a new password credential to a service principal.')]
    param(
        [Parameter(Mandatory, HelpMessage='Service principal object ID.')]
        [System.String]
        # Service principal object ID.
        ${ObjectId},

        [Parameter(Mandatory, HelpMessage='The tenant ID.')]
        [System.String]
        # The tenant ID.
        ${TenantId},

        [Parameter(HelpMessage='The value for the password credential to be associated with the given service principal.')]
        [System.Security.SecureString]
        # The value for the password credential to be associated with the given service principal.
        ${Password},

        [Parameter(HelpMessage='The start date after which the password would be valid. If no value is provided, the current time is used.')]
        [System.DateTime]
        # The start date after which the password would be valid. If no value is provided, the current time is used.
        ${StartDate},

        [Parameter(HelpMessage='The end date until which the password is valid. If no value is provided, one year after the start date is used.')]
        [System.DateTime]
        # The end date until which the password is valid. If no value is provided, one year after the start date is used.
        ${EndDate},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(HelpMessage='Returns true when the command succeeds')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Returns true when the command succeeds
        ${PassThru},

        [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        if (!$PSBoundParameters.ContainsKey("StartDate"))
        {
            $StartDate = [System.DateTime]::UtcNow
        }

        if (!$PSBoundParameters.ContainsKey("EndDate"))
        {
            $EndDate = $StartDate.AddYears(1)
        }

        $DecodedPassword = ConvertFrom-SecureString -SecureString $Password
        $PasswordCredential = [Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IPasswordCredential]@{
            StartDate = $StartDate
            EndDate = $EndDate
            KeyId = [System.Guid]::NewGuid().ToString()
            Value = $DecodedPassword
        }

        if ($PSBoundParameters.ContainsKey("StartDate"))
        {
            $null = $PSBoundParameters.Remove("StartDate")
        }

        if ($PSBoundParameters.ContainsKey("EndDate"))
        {
            $null = $PSBoundParameters.Remove("EndDate")
        }

        $null = $PSBoundParameters.Remove("Password")
        $ExistingCredentials = Az.Resources\Get-AzADServicePrincipalPasswordCredential -TenantId $TenantId -ObjectId $ObjectId
        if ($null -eq $ExistingCredentials)
        {
            $ExistingCredentials = @()
        }
        elseif (1 -eq ($ExistingCredentials | Measure-Object).Count)
        {
            $ExistingCredentials = @( $ExistingCredentials )
        }

        $ExistingCredentials += $PasswordCredential
        $null = $PSBoundParameters.Add("Value", $ExistingCredentials)
        Az.Resources.internal\Update-AzADServicePrincipalPasswordCredential @PSBoundParameters
    }
}