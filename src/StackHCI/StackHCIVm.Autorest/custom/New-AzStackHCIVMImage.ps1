<#
.Synopsis
The operation to create an image.
Please note some properties can be set only during  image creation.
.Description
The operation to create an image.
Please note some properties can be set only during image creation.
.Example
PS C:\> {{ New-AzStackHciVMImage -Name "test"  -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourceGroups/{resourceGroupName}/providers/Microsoft.ExtendedLocation/customLocations/{customLocationName}" -Location "eastus" -ImagePath "C:\testfolder\testimage.vhdx" }}

.Example
PS C:\> {{ New-AzStackHciVMImage -Name "testMarketplaceImage" -ResourceGroupName "test-rg" -CustomLocationId "/subscriptions/{subscriptionID}/resourcegroups/{resourceGroupName}/providers/microsoft.extendedlocation/customlocations/{customLocationName}" -Offer "windowsserver" -Publisher "MicrosoftWindowsServer" -Sku "2022-Datacenter" -Version "latest" -Location "eastus" }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IGalleryImages
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IMarketplaceGalleryImages
.Link
https://learn.microsoft.com/powershell/module/az.stackhcivm/new-azstackhcivmimage
#>


function New-AzStackHciVMImage{
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Models.Api20221215Preview.IMarketplaceGalleryImages],ParameterSetName='Marketplace' )]
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Models.Api20221215Preview.IMarketplaceGalleryImages],ParameterSetName='MarketplaceURN' )]
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Models.Api20221215Preview.IGalleryImages],ParameterSetName='GalleryImage' )]
    [CmdletBinding(PositionalBinding=$false)]
   
    param(

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Parameter(ParameterSetName='GalleryImage', Mandatory)]
    [Parameter(ParameterSetName='MarketplaceURN',Mandatory)]
    [Alias('ImageName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # Name of the Image
    #The name must start and end with an alphanumeric character and must contain all alphanumeric characters or ‘-‘, ‘.’, or ‘_’. The max length can be 80 characters and the minimum length is 1 character.
    ${Name},

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Parameter(ParameterSetName='GalleryImage', Mandatory)]
    [Parameter(ParameterSetName='MarketplaceURN', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # The name of the Resource Group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Marketplace')]
    [Parameter(ParameterSetName='GalleryImage')]
    [Parameter(ParameterSetName='MarketplaceURN')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Parameter(ParameterSetName='GalleryImage', Mandatory)]
    [Parameter(ParameterSetName='MarketplaceURN', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # The geo-location where the resource lives
    ${Location},

    [Parameter(ParameterSetName='Marketplace')]
    [Parameter(ParameterSetName='GalleryImage')]
    [Parameter(ParameterSetName='MarketplaceURN')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Support.CloudInitDataSource])]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Support.CloudInitDataSource]
    # Datasource for the gallery image when provisioning with cloud-init [NoCloud, Azure]
    ${CloudInitDataSource},

    [Parameter(ParameterSetName='Marketplace')]
    [Parameter(ParameterSetName='GalleryImage')]
    [Parameter(ParameterSetName='MarketplaceURN')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # Container Name for Storage Container to create image in. 
    ${ContainerName},

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Parameter(ParameterSetName='GalleryImage', Mandatory)]
    [Parameter(ParameterSetName='MarketplaceURN', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # The ARM Id of the extended location to create image resource in.
    ${CustomLocationId},

    [Parameter(ParameterSetName='GalleryImage', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # Local path of image that the image should be created from. 
    # This parameter is required for non marketplace images. 
    ${ImagePath},

    [Parameter(ParameterSetName='GalleryImage')]
    [Parameter(ParameterSetName='Marketplace')]
    [Parameter(ParameterSetName='MarketplaceURN')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Support.OperatingSystemTypes])]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Support.OperatingSystemTypes]
    # Operating system type that the gallery image uses [Windows, Linux]
    ${OSType},

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # The name of the marketplae gallery image definition offer.
    ${Offer},

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # The name of the marketplace gallery image definition publisher.
    ${Publisher},

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # The name of the marketplace gallery image definition SKU.
    ${Sku},

    [Parameter(ParameterSetName='GalleryImage')]
    [Parameter(ParameterSetName='Marketplace')]
    [Parameter(ParameterSetName='MarketplaceURN')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Models.Api30.ITrackedResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

    [Parameter(ParameterSetName='MarketplaceURN', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # The URN of the marketplace gallery image.
    ${URN},

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # The version of the marketplace gallery image.
    ${Version},

    [Parameter(ParameterSetName='GalleryImage')]
    [Parameter(ParameterSetName='Marketplace')]
    [Parameter(ParameterSetName='MarketplaceURN')]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile}

    )

        if (-Not ($name -match $imageNameRegex )) {
            Write-Error "Invalid Name for image provided: $name" -ErrorAction Stop
        }

        if ($CustomLocationId -notmatch $customLocationRegex){
            Write-Error "Invalid CustomLocationId: $CustomLocationId" -ErrorAction Stop
        }
        if ($OSType){
            if ($OSType.ToString().ToLower() -eq "windows"){
                $PSBoundParameters['OSType'] = 'Windows'

            }
            elseif ($OSType.ToString().ToLower() -eq "linux"){
                $PSBoundParameters['OSType'] = 'Linux'
            }
            else {
                Write-Error "Invalid OSType provided:  $OSType. Expected values are 'Windows' or 'Linux'." -ErrorAction Stop
            }
        }

        #cloudinitdatassouce 
        if ($CloudInitDataSource){
            if ($CloudInitDataSource.ToString().ToLower() -eq "nocloud"){
            $PSBoundParameters['CloudInitDataSource'] = 'NoCloud'

            }
            elseif ($CloudInitDataSource.ToString().ToLower() -eq "azure"){
                $PSBoundParameters['CloudInitDataSource'] = 'Azure'
            }
            else {
                Write-Error "Invalid CloudInitDataSource provided: $CloudInitDataSource. Expected values are 'NoCloud' or 'Azure'." -ErrorAction Stop
            }

        }
        
        if ($HyperVGeneration){
            if ($HyperVGeneration.ToString().ToLower() -eq "v1"){
                $PSBoundParameters['HyperVGeneration'] = 'V1'

            }
            elseif ($HyperVGeneration.ToString().ToLower() -eq "v2"){
                $PSBoundParameters['HyperVGeneration'] = 'V2'
            }
            else {
                Write-Error "Invalid HyperVGeneration provided: $HyperVGeneration. Expected values are 'V1' or 'V2'." -ErrorAction Stop
            }

        }
        

        if ($PSCmdlet.ParameterSetName -eq "Marketplace")
        {
            return Az.StackHciVM.internal\New-AzStackHciVMMarketplaceGalleryImage @PSBoundParameters

        } elseif ($PSCmdlet.ParameterSetName -eq "MarketplaceURN") {
            if ($URN -match $urnRegex){
                $publisher = $Matches.publisher.ToLower()
                $offer = $Matches.offer.ToLower()
                $sku = $Matches.sku.ToLower()
                $version = $Matches.version.ToLower()

                $null = $PSBoundParameters.Remove("URN")           
                $PSBoundParameters.Add('Publisher', $publisher)
                $PSBoundParameters.Add('Offer', $offer)
                $PSBoundParameters.Add('Sku', $sku)
                $PSBoundParameters.Add('Version', $version)
            } else {
                Write-Error "Invalid URN provided: $URN. Valid URN format is Publisher:Offer:Sku:Version ." -ErrorAction Stop
            }

            return Az.StackHciVM.internal\New-AzStackHciVMMarketplaceGalleryImage @PSBoundParameters

        }

        if ($PSCmdlet.ParameterSetName -eq "GalleryImage")
        {
            # if (-not (Test-Path $ImagePath -IsValid)){
            #     Write-Error "Invalid ImagePath provided: $ImagePath. Please specify a valid path." -ErrorAction Stop
            # } 
            return Az.StackHciVM.internal\New-AzStackHciVMGalleryImage @PSBoundParameters
        }

       
    
}