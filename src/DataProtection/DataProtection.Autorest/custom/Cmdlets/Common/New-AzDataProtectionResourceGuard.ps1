

function New-AzDataProtectionResourceGuard
{   
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IResourceGuardResource')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Creates a resource guard under a resource group')]

    param(
        [Parameter(ParameterSetName="CreateResourceGuard", Mandatory=$false, HelpMessage='Subscription Id of the resource guard')]
        [System.String]
        ${SubscriptionId},

        [Parameter(ParameterSetName="CreateResourceGuard", Mandatory, HelpMessage='Resource Group name of the resource guard')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(ParameterSetName="CreateResourceGuard", Mandatory, HelpMessage='Name of the resource guard')]
        [System.String]
        ${Name},

        [Parameter(ParameterSetName="CreateResourceGuard", Mandatory=$false, HelpMessage='Optional ETag')]
        [System.String]
        ${ETag},

        [Parameter(ParameterSetName="CreateResourceGuard", Mandatory=$false, HelpMessage='This parameter is no longer in use and will be depricated')]
        [System.String]
        ${IdentityType},
                
        [Parameter(ParameterSetName="CreateResourceGuard", Mandatory, HelpMessage='Location of the resource guard')]
        [System.String]
        ${Location},

        [Parameter(ParameterSetName="CreateResourceGuard", Mandatory=$false, HelpMessage='Resource tags')]        
        [Hashtable]
        ${Tag},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},
    
        [Parameter(DontShow)]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter(DontShow)]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
            
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process
    {
        if($PSBoundParameters.ContainsKey("IdentityType"))
        {
            $null = $PSBoundParameters.Remove("IdentityType")

            # TODO : need to move this to parameter level 
            Write-Warning "Parameter IdentityType is no longer in use and will be depricated in upcoming breaking change release"
        }
        Az.DataProtection.Internal\New-AzDataProtectionResourceGuard @PSBoundParameters
    }
}