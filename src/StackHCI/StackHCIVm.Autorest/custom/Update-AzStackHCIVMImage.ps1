<#
.Synopsis
The operation to update an image.

.Description
The operation to update an image.
Please note some properties can be set only during image creation.
.Example



.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImages
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMarketplaceGalleryImages
.Link
https://learn.microsoft.com/powershell/module/az.stackhci/new-azstackhcivmimage
#>

function Update-AzStackHCIVmImage{
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IMarketplaceGalleryImages],ParameterSetName='Marketplace' )]
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IGalleryImages],ParameterSetName='GalleryImage' )]
    [CmdletBinding(PositionalBinding=$false)]
   
  param(
    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
    [System.String]
    # Name of the gallery image
    ${Name},

    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='ByName')]
    [Parameter(ParameterSetName='ByResourceId')] 
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='ByResourceId', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Path')]
    [System.String]
    # The ARM Resource ID of the image.
    ${ResourceId},

    [Parameter(ParameterSetName='ByName')]
    [Parameter(ParameterSetName='ByResourceId')] 
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230901Preview.IGalleryImagesUpdateRequestTags]))]
    [System.Collections.Hashtable]
    # Resource tags
    ${Tags}

)

    process {
        if ($PSCmdlet.ParameterSetName -eq "ByName"){

            $isGalleryImage = $false
            $isMarketplaceGalleryImage = $false

            
            $galImage = Az.StackHCIVm.internal\Get-AzStackHCIVmGalleryImage -Name $Name -ResourceGroupName $ResourceGroupName -SubscriptionId $SubscriptionId -ErrorAction SilentlyContinue
            if ($galImage -ne $null){
                $isGalleryImage = $true 
            } else {
                $marketplaceGalImage = Az.StackHCIVm.internal\Get-AzStackHCIVmMarketplaceGalleryImage -Name $Name -ResourceGroupName $ResourceGroupName -SubscriptionId $SubscriptionId -ErrorAction SilentlyContinue
                if ($marketplaceGalImage -ne $null){
                    $isMarketplaceGalleryImage = $true 
                }else{
                    Write-Error "An Image with name: $Name does not exist in Resource Group: $ResourceGroupName" -ErrorAction Stop
                }
            }
        

            if ($isGalleryImage){
                return  Az.StackHCIVm.internal\Update-AzStackHCIVmGalleryImage @PSBoundParameters
            } 

            if ($isMarketplaceGalleryImage){
                return  Az.StackHCIVm.internal\Update-AzStackHCIVmMarketplaceGalleryImage @PSBoundParameters
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

                    return  Az.StackHCIVm.internal\Update-AzStackHCIVmGalleryImage @PSBoundParameters
                    
                } elseif ($ResourceId -match $marketplaceGalImageRegex){
                    $subscriptionId = $($Matches['subscriptionId'])
                    $resourceGroupName = $($Matches['resourceGroupName'])
                    $resourceName = $($Matches['imageName'])
                    $null = $PSBoundParameters.Remove("ResourceId")
                    $PSBoundParameters.Add("Name", $resourceName)
                    $PSBoundParameters.Add("ResourceGroupName", $resourceGroupName)
                    $null = $PSBoundParameters.Remove("SubscriptionId")
                    $PSBoundParameters.Add("SubscriptionId", $subscriptionId)

                    return  Az.StackHCIVm.internal\Update-AzStackHCIVmMarketplaceGalleryImage @PSBoundParameters

                } else {
                    Write-Error "Resource ID is invalid: $ResourceId"
                }
        }    
    }
} 