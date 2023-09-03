function Remove-AzStackHciVMImage{
    [OutputType([System.Boolean])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # Name of the gallery image
    ${Name},

    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='ByName')]
    [Parameter(ParameterSetName='ByResourceId')] 
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

 
    [Parameter(ParameterSetName='ByResourceId', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # The ARM Resource ID of the image.
    ${ResourceId},

    [Parameter(ParameterSetName='ByName')]
    [Parameter(ParameterSetName='ByResourceId')]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(HelpMessage='Forces the cmdlet to remove the network interface without prompting for confirmation.')]
    [System.Management.Automation.SwitchParameter]
    ${Force}
    )


    Write-Warning("Running this command will delete the image.")
    $isGalleryImage = $false
    $isMarketplaceGalleryImage = $false

    if ($PSCmdlet.ParameterSetName -eq "ByName"){
        $isGalleryImage = $false
        $isMarketplaceGalleryImage = $false

        try {
            $galImage = Az.StackHciVM.internal\Get-AzStackHciVMGalleryImage @PSBoundParameters 
            $isGalleryImage = $true 
        }
        catch {
            try {
                $marketplaceGalImage = Az.StackHciVM.internal\Get-AzStackHciVMMarketplaceGalleryImage @PSBoundParameters
                $isMarketplaceGalleryImage = $true 
            }
            catch {
                Write-Error "An Image with name: $Name does not exist in Resource Group: $ResourceGroupName"
            }
        }


    }  elseif ($PSCmdlet.ParameterSetName -eq "ByResourceId"){
    
            if ($ResourceId -match $galImageRegex){
            
                $subscriptionId = $($Matches['subscriptionId'])
                $resourceGroupName = $($Matches['resourceGroupName'])
                $resourceName = $($Matches['imageName'])
                $null = $PSBoundParameters.Remove("ResourceId")
                $PSBoundParameters.Add("Name", $resourceName)
                $PSBoundParameters.Add("ResourceGroupName", $resourceGroupName)
                $null = $PSBoundParameters.Remove("SubscriptionId")
                $PSBoundParameters.Add("SubscriptionId", $subscriptionId)

                $isGalleryImage = $true 

            } elseif ($ResourceId -match $marketplaceGalImageRegex){
                $subscriptionId = $($Matches['subscriptionId'])
                $resourceGroupName = $($Matches['resourceGroupName'])
                $resourceName = $($Matches['imageName'])
                $null = $PSBoundParameters.Remove("ResourceId")
                $PSBoundParameters.Add("Name", $resourceName)
                $PSBoundParameters.Add("ResourceGroupName", $resourceGroupName)
                $null = $PSBoundParameters.Remove("SubscriptionId")
                $PSBoundParameters.Add("SubscriptionId", $subscriptionId)

                $isMarketplaceGalleryImage = $true
            
            } else {
                Write-Error "Resource ID is invalid: $ResourceId"
            }
    } 

    if ($PSCmdlet.ShouldProcess($PSBoundParameters['Name']) -and ($Force -or $PSCmdlet.ShouldContinue("Delete this virtual machine?", "Confirm")))
    {
        if ($PSBoundParameters.ContainsKey("Force")) {
            $null = $PSBoundParameters.Remove("Force")
        }

        if ($isMarketplaceGalleryImage)
        {
            return Az.StackHciVM.internal\Remove-AzStackHciVMMarketplaceGalleryImage @PSBoundParameters
        }

        if ($isGalleryImage)
        {
            return Az.StackHciVM.internal\Remove-AzStackHciVMGalleryImage @PSBoundParameters
        }
    }

       
      
    
} 