function New-AzWvdMsixPackage_PackageAlias {

    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20201102Preview.IMsixPackage')]
    [CmdletBinding( PositionalBinding = $false, ConfirmImpact = 'Medium')]
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
 
        # Required to run the command with a specified alias 
        [Parameter(Mandatory, HelpMessage = 'Subscription Id')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Runtime.DefaultInfo(Script = '(Get-AzContext).Subscription.Id')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage = 'Resource Group Name')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage = 'HostPool Name')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [System.String]
        ${HostPoolName},

        [Parameter(Mandatory, HelpMessage = 'Package Alias from extract MSIX Image')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [System.String]
        ${PackageAlias},

        [Parameter(HelpMessage = 'Is Active')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [System.Management.Automation.SwitchParameter]
        ${IsActive},

        [Parameter(HelpMessage = 'Is Regular Registration')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [System.Management.Automation.SwitchParameter]
        ${IsRegularRegistration},

        [Parameter(HelpMessage = 'Package Display Name')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [System.String]
        ${DisplayName},

        # needed to run Expand MSIX Image
        [Parameter(HelpMessage = 'Image Path to CIM/VHD')]
        [Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Category('Path')]
        [System.String]
        ${ImagePath}
    )

    process {
        $saveHostPoolName = $null
        if ($PSBoundParameters.ContainsKey("HostPoolName")) {
            $saveHostPoolName = $PSBoundParameters["HostPoolName"]
        }
        $saveResourceGroupName = $null
        if ($PSBoundParameters.ContainsKey("ResourceGroupName")) {
            $saveResourceGroupName = $PSBoundParameters["ResourceGroupName"]
        }
        $saveSubscriptionId = $null
        if ($PSBoundParameters.ContainsKey("SubscriptionId")) {
            $saveSubscriptionId = $PSBoundParameters["SubscriptionId"]
        }
        $savePackageAlias = $null
        if ($PSBoundParameters.ContainsKey("PackageAlias")) {
            $savePackageAlias = $PSBoundParameters["PackageAlias"]
        }
        $saveImagePath = $null
        if ($PSBoundParameters.ContainsKey("ImagePath")) {
            $saveImagePath = $PSBoundParameters["ImagePath"]
        }
   
        $saveDisplayName = $null
        if ($PSBoundParameters.ContainsKey("DisplayName")) {
            $saveDisplayName = $PSBoundParameters["DisplayName"]
        }

        # clear 
        $null = $PSBoundParameters.Remove("HostPoolName")
        $null = $PSBoundParameters.Remove("ResourceGroupName")
        $null = $PSBoundParameters.Remove("SubscriptionId")
        $null = $PSBoundParameters.Remove("ImagePath")
        $null = $PSBoundParameters.Remove("PackageAlias")
        $null = $PSBoundParameters.Remove("DisplayName")
        $null = $PSBoundParameters.Remove("IsActive")
        $null = $PSBoundParameters.Remove("IsRegularRegistration")
       
        $extractPackage = Az.DesktopVirtualization\Expand-AzWvdMsixImage @PSBoundParameters -HostPoolName $saveHostPoolName `
            -ResourceGroupName  $saveResourceGroupName `
            -SubscriptionId  $saveSubscriptionId `
            -Uri $saveImagePath `
        | Where-Object { $_.PackageAlias -eq $savePackageAlias }
      
        $null = $PSBoundParameters.Add("ResourceGroupName", $saveResourceGroupName)
        $null = $PSBoundParameters.Add("SubscriptionId", $saveSubscriptionId)
        $null = $PSBoundParameters.Add('FullName', $extractPackage.PackageFullName)
        $null = $PSBoundParameters.Add("IsActive", $IsActive)
        $null = $PSBoundParameters.Add("IsRegularRegistration", $IsRegularRegistration)

        $package = New-AzWvdMsixPackage @PSBoundParameters -HostPoolName $saveHostPoolName `
            -ImagePath  $extractPackage.ImagePath `
            -PackageName  $extractPackage.PackageName `
            -PackageFamilyName  $extractPackage.PackageFamilyName `
            -PackageRelativePath  $extractPackage.PackageRelativePath `
            -PackageDependency $extractPackage.PackageDependencies `
            -Version  $extractPackage.Version `
            -LastUpdated  $extractPackage.LastUpdated `
            -PackageApplication $extractPackage.PackageApplication `
            -DisplayName  $saveDisplayName `

    }
}