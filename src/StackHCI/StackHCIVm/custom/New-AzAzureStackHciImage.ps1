function New-AzAzureStackHciImage{
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Models.Api20221215Preview.IMarketplaceGalleryImages],ParameterSetName='Marketplace' )]
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Models.Api20221215Preview.IGalleryImages],ParameterSetName='GalleryImage' )]
    [CmdletBinding(PositionalBinding=$false)]
   
    param(

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Parameter(ParameterSetName='GalleryImage', Mandatory)]
    [Alias('ImageName')]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Path')]
    [System.String]
    # Name of the gallery image
    ${Name},

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Parameter(ParameterSetName='GalleryImage', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Marketplace')]
    [Parameter(ParameterSetName='GalleryImage')]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Parameter(ParameterSetName='GalleryImage', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Body')]
    [System.String]
    # The geo-location where the resource lives
    ${Location},

    [Parameter(ParameterSetName='Marketplace')]
    [Parameter(ParameterSetName='GalleryImage')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Support.CloudInitDataSource])]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Support.CloudInitDataSource]
    # Datasource for the gallery image when provisioning with cloud-init [NoCloud, Azure]
    ${CloudInitDataSource},

    [Parameter(ParameterSetName='Marketplace')]
    [Parameter(ParameterSetName='GalleryImage')]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Body')]
    [System.String]
    # Container Name for storage container
    ${ContainerName},

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Parameter(ParameterSetName='GalleryImage', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Body')]
    [System.String]
    # The name of the extended location.
    ${CustomLocationId},

    [Parameter(ParameterSetName='Marketplace')]
    [Parameter(ParameterSetName='GalleryImage')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Support.HyperVGeneration])]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Support.HyperVGeneration]
    # The hypervisor generation of the Virtual Machine [V1, V2]
    ${HyperVGeneration},

    [Parameter(ParameterSetName='GalleryImage', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Body')]
    [System.String]
    # location of the image the gallery image should be created from
    ${ImagePath},

    [Parameter(ParameterSetName='GalleryImage', Mandatory)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Support.OperatingSystemTypes])]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Support.OperatingSystemTypes]
    # Operating system type that the gallery image uses [Windows, Linux]
    ${OSType},

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Body')]
    [System.String]
    # The name of the gallery image definition offer.
    ${Offer},

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Body')]
    [System.String]
    # The name of the gallery image definition publisher.
    ${Publisher},

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Body')]
    [System.String]
    # The name of the gallery image definition SKU.
    ${Sku},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Models.Api30.ITrackedResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Body')]
    [System.String]
    # This is the version of the gallery image.
    ${Version},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile}

    )

    process {
        if (-Not ($name -match $imageNameRegex )) {
            Write-Error "Invalid name for image provided: $name"
        }

        if ($CustomLocationId -notmatch $customLocationRegex){
            Write-Error "Invalid CustomLocationId: $CustomLocationId" -ErrorAction Stop
        }

        if ($OsType.ToString().ToLower() -eq "windows"){
            $PSBoundParameters['OsType'] = 'Windows'

        }
        elseif ($OsType.ToString().ToLower() -eq "linux"){
            $PSBoundParameters['OsType'] = 'Linux'
        }
        else {
            Write-Error "Invalid OsType provided: $OsType. Expected values are 'Windows' or 'Linux'."
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
                Write-Error "Invalid CloudInitDataSource provided: $CloudInitDataSource. Expected values are 'NoCloud' or 'Azure'."
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
                Write-Error "Invalid HyperVGeneration provided: $HyperVGeneration. Expected values are 'V1' or 'V2'."
            }

        }
        

        if ($PSCmdlet.ParameterSetName -eq "Marketplace")
        {
            return Az.AzureStackHci\New-AzAzureStackHciMarketplaceGalleryImage @PSBoundParameters
        }

        if ($PSCmdlet.ParameterSetName -eq "GalleryImage")
        {
           <#  if (-not (Test-Path -path $ImagePath)){
                Write-Error "Invalid ImagePath provided: $ImagePath. Please specify a valid path."
            } #>
            return Az.AzureStackHci\New-AzAzureStackHciGalleryImage @PSBoundParameters
        }

       
    }
}