function Get-AzStackHciVMImage{    
    [CmdletBinding(DefaultParameterSetName='BySubscription', PositionalBinding=$false)]

    param(
    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # Name of the image
    ${Name},

    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Parameter(ParameterSetName='ByResourceGroup', Mandatory)]
    [Parameter(ParameterSetName='ListAllSupportedImages', Mandatory)]
    [Parameter(ParameterSetName='ListImagesByOffer', Mandatory)]
    [Parameter(ParameterSetName='ListImagesByPublisher', Mandatory)]
    [Parameter(ParameterSetName='ListImagesBySku', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='ByName')]
    [Parameter(ParameterSetName='ByResourceGroup')]
    [Parameter(ParameterSetName='ByResourceId')]
    [Parameter(ParameterSetName='BySubscription')]
    [Parameter(ParameterSetName='ListAllSupportedImages')]
    [Parameter(ParameterSetName='ListImagesByOffer')]
    [Parameter(ParameterSetName='ListImagesByPublisher')]
    [Parameter(ParameterSetName='ListImagesBySku')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The ID of the target subscription.
    ${SubscriptionId},

 
    [Parameter(ParameterSetName='ByResourceId', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # The ARM Resource Id of the Image 
    ${ResourceId},

<#     [Parameter(ParameterSetName='ListAllSupportedImages', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.Management.Automation.SwitchParameter]
    # The ID of the target subscription.
    ${SupportedImages},

    [Parameter(ParameterSetName='ListAllSupportedImages', Mandatory)]
    [Parameter(ParameterSetName='ListImagesByOffer', Mandatory)]
    [Parameter(ParameterSetName='ListImagesByPublisher', Mandatory)]
    [Parameter(ParameterSetName='ListImagesBySku', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # The ID of the target subscription.
    ${ClusterName},
    
    [Parameter(ParameterSetName='ListImagesByOffer', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # The ID of the target subscription.
    ${Offer},

    [Parameter(ParameterSetName='ListImagesByPublisher', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # The ID of the target subscription.
    ${Publisher},

    [Parameter(ParameterSetName='ListImagesBySku', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # The ID of the target subscription.
    ${Sku},  #>

    [Parameter(ParameterSetName='ByName')]
    [Parameter(ParameterSetName='ByResourceGroup')]
    [Parameter(ParameterSetName='ByResourceId')]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile}
)

    process {

        if ($PSCmdlet.ParameterSetName -eq "ByName"){
            $isGalleryImage = $false
            $isMarketplaceGalleryImage = $false

            
            $galImage = Az.StackHciVM\Get-AzStackHciVMGalleryImage @PSBoundParameters -ErrorAction SilentlyContinue
            if ($galImage -ne $null){
                $isGalleryImage = $true 
            } else {
                $marketplaceGalImage = Az.StackHciVM\Get-AzStackHciVMMarketplaceGalleryImage @PSBoundParameters
                if ($marketplaceGalImage -ne $null){
                    $isMarketplaceGalleryImage = $true 
                }
            }
        
            if ($isGalleryImage){
                return  $galImage
            } 

            if ($isMarketplaceGalleryImage){
                return  $marketplaceGalImage
            }

            Write-Error "An Image with name: $Name does not exist in Resource Group: $ResourceGroupName" -ErrorAction Stop

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

                    return  Az.StackHciVM\Get-AzStackHciVMGalleryImage @PSBoundParameters
                } elseif ($ResourceId -match $marketplaceGalImageRegex){
                    $subscriptionId = $($Matches['subscriptionId'])
                    $resourceGroupName = $($Matches['resourceGroupName'])
                    $resourceName = $($Matches['imageName'])
                    $null = $PSBoundParameters.Remove("ResourceId")
                    $PSBoundParameters.Add("Name", $resourceName)
                    $PSBoundParameters.Add("ResourceGroupName", $resourceGroupName)
                    $null = $PSBoundParameters.Remove("SubscriptionId")
                    $PSBoundParameters.Add("SubscriptionId", $subscriptionId)

                    return  Az.StackHciVM\Get-AzStackHciVMMarketplaceGalleryImage @PSBoundParameters
                } else {
                    Write-Error "Resource ID is invalid: $ResourceId"
                }

        } elseif ($PSCmdlet.ParameterSetName -eq "ByResourceGroup"){
            $allImages = @()
            $galImages = Az.StackHciVM\Get-AzStackHciVMGalleryImage @PSBoundParameters
            $marketplaceGalImages =  Az.StackHciVM\Get-AzStackHciVMMarketplaceGalleryImage @PSBoundParameters
            $allImages = $allImages + $galImages
            $allImages = $allImages + $marketplaceGalImages
            return $allImages
        }

        $allImages = @()
        $galImages = Az.StackHciVM\Get-AzStackHciVMGalleryImage @PSBoundParameters
        $marketplaceGalImages =  Az.StackHciVM\Get-AzStackHciVMMarketplaceGalleryImage @PSBoundParameters
        $allImages = $allImages + $galImages
        $allImages = $allImages + $marketplaceGalImages
        return $allImages
      
    }
}  