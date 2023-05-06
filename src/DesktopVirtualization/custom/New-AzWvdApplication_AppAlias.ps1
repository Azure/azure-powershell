function New-AzWvdApplication_AppAlias {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api202209.IApplication')]
    [CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter()]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
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
        ${ProxyUseDefaultCredentials},

        [Parameter(Mandatory, HelpMessage='Subscription Id')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='Resource Group Name')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='Application Group Name')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [System.String]
        ${GroupName},

        [Parameter(Mandatory, HelpMessage='App Alias from start menu item')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [System.String]
        ${AppAlias},

        [Parameter(Mandatory, HelpMessage='Application Name')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [System.String]
        ${Name},

        [Parameter(HelpMessage='Friendly Name')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [System.String]
        ${FriendlyName},

        [Parameter(HelpMessage='Description')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [System.String]
        ${Description},

        [Parameter(Mandatory, HelpMessage='Command Line Setting')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.Info(SerializedName='CommandLineSetting',
            PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.CommandLineSetting]),
            Description='Specifies the Azure subscr')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.CommandLineSetting]
        ${CommandLineSetting},

        [Parameter(HelpMessage='Show In Portal')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [System.Management.Automation.SwitchParameter]
        ${ShowInPortal}
    )

    process {
        $saveGroupName = $null
        if ($PSBoundParameters.ContainsKey("GroupName")) {
            $saveGroupName = $PSBoundParameters["GroupName"]
        }
        $saveAppAlias = $null
        if ($PSBoundParameters.ContainsKey("AppAlias")) {
            $saveAppAlias = $PSBoundParameters["AppAlias"]
        }
        $saveName = $null
        if ($PSBoundParameters.ContainsKey("Name")) {
            $saveName = $PSBoundParameters["Name"]
        }
        $saveFriendlyName = $null
        if ($PSBoundParameters.ContainsKey("FriendlyName")) {
            $saveFriendlyName = $PSBoundParameters["FriendlyName"]
        }
        $saveDescription = $null
        if ($PSBoundParameters.ContainsKey("Description")) {
            $saveDescription = $PSBoundParameters["Description"]
        }
        $saveCommandLineSetting = $null
        if ($PSBoundParameters.ContainsKey("CommandLineSetting")) {
            $saveCommandLineSetting = $PSBoundParameters["CommandLineSetting"]
        }
        $saveShowInPortal = $null
        if ($PSBoundParameters.ContainsKey("ShowInPortal")) {
            $saveShowInPortal = $PSBoundParameters["ShowInPortal"]
        }
        $null = $PSBoundParameters.Remove("GroupName")
        $null = $PSBoundParameters.Remove("AppAlias")
        $null = $PSBoundParameters.Remove("Name")
        $null = $PSBoundParameters.Remove("FriendlyName")
        $null = $PSBoundParameters.Remove("Description")
        $null = $PSBoundParameters.Remove("CommandLineSetting")
        $null = $PSBoundParameters.Remove("ShowInPortal")

        $startMenuItem = Az.DesktopVirtualization\Get-AzWvdStartMenuItem @PSBoundParameters -ApplicationGroupName $saveGroupName `
                                    | Where-Object -Property AppAlias -Match $saveAppAlias
        $null = $PSBoundParameters.Add("Name", $saveName)
        $null = $PSBoundParameters.Add("FriendlyName", $saveFriendlyName)
        $null = $PSBoundParameters.Add("Description", $Description)
        $null = $PSBoundParameters.Add("CommandLineSetting", $CommandLineSetting)
        $null = $PSBoundParameters.Add("ShowInPortal", $ShowInPortal)
        $application = Az.DesktopVirtualization\New-AzWvdApplication @PSBoundParameters -GroupName $saveGroupName `
            -FilePath $startMenuItem.FilePath `
            -IconIndex $startMenuItem.IconIndex `
            -IconPath $startMenuItem.IconPath
    }
}