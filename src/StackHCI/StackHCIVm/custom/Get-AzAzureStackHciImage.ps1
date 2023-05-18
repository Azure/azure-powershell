function Get-AzAzureStackHciImage{    
    [CmdletBinding(DefaultParameterSetName='BySubscription', PositionalBinding=$false)]

    param(
    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Path')]
    [System.String]
    # Name of the gallery image
    ${Name},

    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Parameter(ParameterSetName='ByResourceGroup', Mandatory)]
    [Parameter(ParameterSetName='ListAllSupportedImages', Mandatory)]
    [Parameter(ParameterSetName='ListImagesByOffer', Mandatory)]
    [Parameter(ParameterSetName='ListImagesByPublisher', Mandatory)]
    [Parameter(ParameterSetName='ListImagesBySku', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Path')]
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
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The ID of the target subscription.
    ${SubscriptionId},

 
    [Parameter(ParameterSetName='ByResourceId', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Path')]
    [System.String]
    # The ID of the target subscription.
    ${ResourceId},

    [Parameter(ParameterSetName='ListAllSupportedImages', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Path')]
    [System.Management.Automation.SwitchParameter]
    # The ID of the target subscription.
    ${SupportedImages},

    [Parameter(ParameterSetName='ListAllSupportedImages', Mandatory)]
    [Parameter(ParameterSetName='ListImagesByOffer', Mandatory)]
    [Parameter(ParameterSetName='ListImagesByPublisher', Mandatory)]
    [Parameter(ParameterSetName='ListImagesBySku', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Path')]
    [System.String]
    # The ID of the target subscription.
    ${ClusterName},
    
    [Parameter(ParameterSetName='ListImagesByOffer', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Path')]
    [System.String]
    # The ID of the target subscription.
    ${Offer},

    [Parameter(ParameterSetName='ListImagesByPublisher', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Path')]
    [System.String]
    # The ID of the target subscription.
    ${Publisher},

    [Parameter(ParameterSetName='ListImagesBySku', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Path')]
    [System.String]
    # The ID of the target subscription.
    ${Sku}, 

    [Parameter(ParameterSetName='ByName')]
    [Parameter(ParameterSetName='ByResourceGroup')]
    [Parameter(ParameterSetName='ByResourceId')]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile}
)

    process {

        if ($PSCmdlet.ParameterSetName -eq "ByName"){
            $isGalleryImage = $false
            $isMarketplaceGalleryImage = $false

            try {
                $galImage = Az.AzureStackHci\Get-AzAzureStackHciGalleryImage @PSBoundParameters
                $isGalleryImage = $true 
            }
            catch {
                try {
                    $marketplaceGalImage = Az.AzureStackHci\Get-AzAzureStackHciMarketplaceGalleryImage @PSBoundParameters
                    $isMarketplaceGalleryImage = $true 
                }
                catch {
                    Write-Error "An Image with name: $Name does not exist in Resource Group: $ResourceGroupName"
                }
            }

            if ($isGalleryImage){
                return  $galImage
            } 

            if ($isMarketplaceGalleryImage){
                return  $marketplaceGalImage
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

                    return  Az.AzureStackHci\Get-AzAzureStackHciGalleryImage @PSBoundParameters
                } elseif ($ResourceId -match $marketplaceGalImageRegex){
                    $subscriptionId = $($Matches['subscriptionId'])
                    $resourceGroupName = $($Matches['resourceGroupName'])
                    $resourceName = $($Matches['imageName'])
                    $null = $PSBoundParameters.Remove("ResourceId")
                    $PSBoundParameters.Add("Name", $resourceName)
                    $PSBoundParameters.Add("ResourceGroupName", $resourceGroupName)
                    $null = $PSBoundParameters.Remove("SubscriptionId")
                    $PSBoundParameters.Add("SubscriptionId", $subscriptionId)

                    return  Az.AzureStackHci\Get-AzAzureStackHciMarketplaceGalleryImage @PSBoundParameters
                } else {
                    Write-Error "Resource ID is invalid: $ResourceId"
                }

        } elseif ($PSCmdlet.ParameterSetName -eq "ByResourceGroup"){
            $allImages = @()
            $galImages = Az.AzureStackHci\Get-AzAzureStackHciGalleryImage @PSBoundParameters
            $marketplaceGalImages =  Az.AzureStackHci\Get-AzAzureStackHciMarketplaceGalleryImage @PSBoundParameters
            $allImages = $allImages + $galImages
            $allImages = $allImages + $marketplaceGalImages
            return $allImages
        }

       <#  if ($SupportedImages){

            return  Az.AzureStackHci\Get-AzAzureStackHciOffer -ClusterName $ClusterName -ResourceGroupName $ResourceGroupName -SubscriptionId $SubscriptionID

        } elseif ($PSCmdlet.ParameterSetName -eq "ListImagesByOffer"){
            
            return  Az.AzureStackHci\Get-AzAzureStackHciOffer -ClusterName $ClusterName -Name $Offer -ResourceGroupName $ResourceGroupName -SubscriptionId $SubscriptionID
            
        } elseif ($PSCmdlet.ParameterSetName -eq "ListImagesByPublisher"){

            return  Az.AzureStackHci\Get-AzAzureStackHciPublisher -ClusterName $ClusterName -Name $Publisher -ResourceGroupName $ResourceGroupName -SubscriptionId $SubscriptionID

        } elseif ($PSCmdlet.ParameterSetName -eq "ListImagesBySku"){

            return  Az.AzureStackHci\Get-AzAzureStackHciSku -ClusterName $ClusterName -Name $Sku -ResourceGroupName $ResourceGroupName -SubscriptionId $SubscriptionID

        } #>

        $allImages = @()
        $galImages = Az.AzureStackHci\Get-AzAzureStackHciGalleryImage @PSBoundParameters
        $marketplaceGalImages =  Az.AzureStackHci\Get-AzAzureStackHciMarketplaceGalleryImage @PSBoundParameters
        $allImages = $allImages + $galImages
        $allImages = $allImages + $marketplaceGalImages
        return $allImages
      
    }
}  