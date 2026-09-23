
<#
.Synopsis
Swap the default version for an Edge Action.
.Description
A long-running resource action that swaps the default version for an Edge Action.
This operation makes the specified version the new default version.
.Example
PS C:\> Switch-AzEdgeActionVersionDefault -ResourceGroupName "myRG" -EdgeActionName "myAction" -Version "v2"

Makes version "v2" the default version for the Edge Action.

.Outputs
System.Boolean
#>
function Switch-AzEdgeActionVersionDefault {
    [OutputType([System.Boolean])]
    [CmdletBinding(DefaultParameterSetName='SwapCustom', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(ParameterSetName='SwapCustom', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Path')]
        [System.String]
        # The name of the Edge Action
        ${EdgeActionName},

        [Parameter(ParameterSetName='SwapCustom', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Path')]
        [System.String]
        # The name of the resource group. The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(ParameterSetName='SwapCustom')]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription. The value must be an UUID.
        ${SubscriptionId},

        [Parameter(ParameterSetName='SwapCustom', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Path')]
        [System.String]
        # The name of the Edge Action version to make the default
        ${Version},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Returns true when the command succeeds
        ${PassThru},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {
        try {
            if ($PSCmdlet.ShouldProcess("EdgeAction version '$Version'", "Switch default version")) {
                # Build parameters for the internal cmdlet
                $params = @{}
                
                # Copy all bound parameters
                foreach ($key in $PSBoundParameters.Keys) {
                    $params[$key] = $PSBoundParameters[$key]
                }

                # ARM POST operations require a body, even if empty.
                # The service uses ASP.NET pipeline which fails when no body is present.
                # Inject an empty JSON body {} via HttpPipelinePrepend.
                # SendAsyncStep signature: param($request, $callback, $next) where $next.SendAsync($request, $callback)
                $emptyBodyHandler = [Microsoft.Azure.PowerShell.Cmdlets.EdgeAction.Runtime.SendAsyncStep]{
                    param($request, $callback, $next)
                    
                    # Only add body if this is a POST request without a body
                    if ($request.Method -eq [System.Net.Http.HttpMethod]::Post -and $null -eq $request.Content) {
                        $request.Content = [System.Net.Http.StringContent]::new('{}', [System.Text.Encoding]::UTF8, 'application/json')
                    }
                    
                    return $next.SendAsync($request, $callback)
                }
                
                # Add the empty body handler to the pipeline
                if ($params.ContainsKey('HttpPipelinePrepend')) {
                    $params['HttpPipelinePrepend'] = @($emptyBodyHandler) + $params['HttpPipelinePrepend']
                } else {
                    $params['HttpPipelinePrepend'] = @($emptyBodyHandler)
                }

                Write-Verbose "Calling internal Switch-AzEdgeActionVersionDefault cmdlet"
                
                # Call the generated private cmdlet
                $result = Az.EdgeAction.private\Switch-AzEdgeActionVersionDefault_Swap @params
                
                return $result
            }
        } catch {
            throw
        }
    }
}
