function New-AzWvdAppAttachPackage_ImageObject {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20231004preview.IAppAttachPackage])]
    [CmdletBinding(PositionalBinding=$false, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [Alias('AppAttachPackageName')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [System.String]
        # The name of the App Attach package arm object
        ${Name},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [System.String]
        # The name of the resource group.
        # The name is case insensitive.
        ${ResourceGroupName},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Body')]
        [System.String]
        # The geo-location where the resource lives
        ${Location},

        [Parameter()]
        [Alias("DisplayName")]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Body')]
        [System.String]
        # User friendly Name to be displayed in the portal.
        ${ImageDisplayName},

        [Parameter(Mandatory, Position = 0, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20231004preview.AppAttachPackage]
        # App Attach Package object that can be the output of import-azwvdappattachpackageinfo
        ${AppAttachPackage},

        [Parameter()]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.FailHealthCheckOnStagingFailure])]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.FailHealthCheckOnStagingFailure]
        # Parameter indicating how the health check should behave if this package fails staging
        ${FailHealthCheckOnStagingFailure},

        [Parameter()]
        [AllowEmptyCollection()]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Body')]
        [System.String[]]
        # List of Hostpool resource Ids.
        ${HostPoolReference},

        [Parameter()]
        [Alias("IsActive")]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Make this version of the package the active one across the hostpool.
        ${ImageIsActive},

        [Parameter()]
        [Alias("IsRegularRegistration", "IsLogonBlocking")]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Specifies how to register Package in feed.
        ${ImageIsRegularRegistration},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Specifies if the package should be returned
        ${PassThru},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Body')]
        [System.String]
        # URL of keyvault location to store certificate
        ${KeyVaultUrl},

        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The DefaultProfile parameter is not functional.
        # Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.
        ${DefaultProfile},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
    )

    process {

        $finalParameters = @{}

        $cmd = Get-Command New-AzWvdAppAttachPackage
        $params = $cmd.ParameterSets.Where({$_.Name -eq $cmd.DefaultParameterSet}).Parameters.Name

        # Add all properties from image object, since this is an app attach package it should match the parameters
        foreach($property in $AppAttachPackage.psobject.properties.name) {
            if ($params -contains $property -and $null -ne $AppAttachPackage.$property) {
                # convert tags to a hashtable because unlike all other parameters it goes in a hashtable and comes out tags
                if ($property -eq 'Tag') {
                    $ht = @{}
                    $names = $AppAttachPackage.Tag | get-member -MemberType properties | select-object -expandproperty name
                    foreach ($name in $names) {
                        $ht[$name] = $AppAttachPackage.Tag.$name
                    }
                    $finalParameters[$property] = $ht
                }
                else {
                    $finalParameters[$property] = $AppAttachPackage.$property
                }
            }
        }

        # Add only the parameters that match the standard create app attach package input from cmdlet's input
        foreach ($key in $PSBoundParameters.Keys) {
            if ($params -contains $key) {
                $finalParameters[$key] = $PSBoundParameters[$key]
            }
        }
        $appAttachPackage = New-AzWvdAppAttachPackage @finalParameters

        if ($PassThru) {
            return $appAttachPackage
        }
    }
}