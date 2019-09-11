function Add-AzADApplicationOwner_AddByComponents {
    [OutputType('System.Boolean')]
    [CmdletBinding(DefaultParameterSetName='Add', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Description('Add an owner to an application.')]
    param(
        [Parameter(Mandatory, HelpMessage='The object ID of the application to which to add the owner.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='applicationObjectId', Required, PossibleTypes=([System.String]), Description='The object ID of the application to which to add the owner.')]
        [Alias('ApplicationObjectId')]
        [System.String]
        # The object ID of the application to which to add the owner.
        ${ObjectId},

        [Parameter(Mandatory, HelpMessage='The object ID of the owner of the application.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Alias('OwnerObjectId')]
        [System.String]
        # The object ID of the owner of the application.
        ${MemberObjectId},

        [Parameter(Mandatory, HelpMessage='The tenant ID.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='tenantID', Required, PossibleTypes=([System.String]), Description='The tenant ID.')]
        [System.String]
        # The tenant ID.
        ${TenantId},

        [Parameter(HelpMessage='Additional Parameters')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [System.Collections.Hashtable]
        # Additional Parameters
        ${AdditionalProperties},

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
        $GraphEndpoint = (Get-AzContext).Environment.GraphEndpointResourceId
        $Url = '{0}{1}/directoryObjects/{2}' -f $GraphEndpoint, $TenantId, $MemberObjectId
        $null = $PSBoundParameters.Remove("MemberObjectId")
        $null = $PSBoundParameters.Add("Url", $Url)
        Az.Resources\Add-AzADApplicationOwner @PSBoundParameters
    }
}