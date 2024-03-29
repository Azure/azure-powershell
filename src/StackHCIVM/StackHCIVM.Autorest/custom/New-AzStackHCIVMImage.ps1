
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
The operation to create an image.
Please note some properties can be set only during  image creation.
.Description
The operation to create an image.
Please note some properties can be set only during image creation.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}


.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IGalleryImages
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImages
.Notes
COMPLEX PARAMETER PROPERTIES

.Link
https://learn.microsoft.com/powershell/module/az.stackhcivm/new-azstackhcivmimage
#>
function New-AzStackHCIVMImage{
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImages],ParameterSetName='Marketplace' )]
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImages],ParameterSetName='MarketplaceURN' )]
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IGalleryImages],ParameterSetName='GalleryImage' )]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Parameter(ParameterSetName='GalleryImage', Mandatory)]
    [Parameter(ParameterSetName='MarketplaceURN',Mandatory)]
    [Alias('ImageName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
    [System.String]
    # Name of the Image
    #The name must start and end with an alphanumeric character and must contain all alphanumeric characters or ‘-‘, ‘.’, or ‘_’. The max length can be 80 characters and the minimum length is 1 character.
    ${Name},

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Parameter(ParameterSetName='GalleryImage', Mandatory)]
    [Parameter(ParameterSetName='MarketplaceURN', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Marketplace')]
    [Parameter(ParameterSetName='GalleryImage')]
    [Parameter(ParameterSetName='MarketplaceURN')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Parameter(ParameterSetName='GalleryImage', Mandatory)]
    [Parameter(ParameterSetName='MarketplaceURN', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String]
    # The geo-location where the resource lives
    ${Location},

    [Parameter(ParameterSetName='Marketplace')]
    [Parameter(ParameterSetName='GalleryImage')]
    [Parameter(ParameterSetName='MarketplaceURN')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.PSArgumentCompleterAttribute("NoCloud", "Azure")]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String]
    # Datasource for the gallery image when provisioning with cloud-init [NoCloud, Azure]
    ${CloudInitDataSource},


    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Parameter(ParameterSetName='GalleryImage', Mandatory)]
    [Parameter(ParameterSetName='MarketplaceURN', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String]
    # The ARM Id of the extended location to create image resource in.
    ${CustomLocationId},

    [Parameter(ParameterSetName='GalleryImage', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String]
    # Local path of image that the image should be created from. 
    # This parameter is required for non marketplace images. 
    ${ImagePath},

    [Parameter(ParameterSetName='GalleryImage', Mandatory)]
    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Parameter(ParameterSetName='MarketplaceURN', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.PSArgumentCompleterAttribute("Windows", "Linux")]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')] 
    # Operating system type that the gallery image uses [Windows, Linux]
    ${OSType},

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String]
    # The name of the marketplae gallery image definition offer.
    ${Offer},

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String]
    # The name of the marketplace gallery image definition publisher.
    ${Publisher},

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String]
    # The name of the marketplace gallery image definition SKU.
    ${Sku},

    [Parameter(ParameterSetName='Marketplace')]
    [Parameter(ParameterSetName='GalleryImage')]
    [Parameter(ParameterSetName='MarketplaceURN')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String]
    # Storage Container Name of the storage container to be used for gallery image
    ${StoragePathName},

    [Parameter(ParameterSetName='Marketplace')]
    [Parameter(ParameterSetName='GalleryImage')]
    [Parameter(ParameterSetName='MarketplaceURN')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String]
    # Resource Group of the Storage Path. The Default value is the Resource Group of the Image. 
    ${StoragePathResourceGroup},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String]
    # Storage ContainerID of the storage container to be used for gallery image
    ${StoragePathId},

    [Parameter(ParameterSetName='GalleryImage')]
    [Parameter(ParameterSetName='Marketplace')]
    [Parameter(ParameterSetName='MarketplaceURN')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.ITrackedResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

    [Parameter(ParameterSetName='MarketplaceURN', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String]
    # The URN of the marketplace gallery image.
    ${URN},

    [Parameter(ParameterSetName='Marketplace', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String]
    # The version of the marketplace gallery image.
    ${Version},
    
    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}

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
        
        if ($StoragePathName){
            if ($StoragePathResourceGroup){
                $StoragePathId = "/subscriptions/$SubscriptionId/resourceGroups/$StoragePathResourceGroup/providers/Microsoft.AzureStackHCI/storagecontainers/$StoragePathName"
            } else {
                $StoragePathId = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.AzureStackHCI/storagecontainers/$StoragePathName"
            }

            $PSBoundParameters.Add('StoragePathId', $StoragePathId)
            $null = $PSBoundParameters.Remove("StoragePathName")
            $null = $PSBoundParameters.Remove("StoragePathResourceGroup")
        }
        

        if ($PSCmdlet.ParameterSetName -eq "Marketplace")
        {
            $PSBoundParameters['NoWait'] = $true
            $PSBoundParameters['ErrorAction'] = 'Stop'
            try {
                Az.StackHCIVM.internal\New-AzStackHCIVMMarketplaceGalleryImage @PSBoundParameters
                Start-Sleep -Seconds 60
                $PercentCompleted = 0 
                Write-Progress -Activity "Download Percentage: " -Status "$PercentCompleted % Complete:" -PercentComplete $PercentCompleted
                $null = $PSBoundParameters.Remove("Version")
                $null = $PSBoundParameters.Remove("URN")
                $null = $PSBoundParameters.Remove("Tag")
                $null = $PSBoundParameters.Remove("StoragePathId")
                $null = $PSBoundParameters.Remove("Sku")
                $null = $PSBoundParameters.Remove("Publisher")
                $null = $PSBoundParameters.Remove("Offer")
                $null = $PSBoundParameters.Remove("OSType")
                $null = $PSBoundParameters.Remove("ImagePath")
                $null = $PSBoundParameters.Remove("CustomLocationId")
                $null = $PSBoundParameters.Remove("CloudInitDataSource")
                $null = $PSBoundParameters.Remove("Location")
                $null = $PSBoundParameters.Remove("NoWait")
                while ($PercentCompleted -ne 100 ) {                  
                    $image = Az.StackHCIVM.internal\Get-AzStackHCIVMMarketplaceGalleryImage @PSBoundParameters
                    $PercentCompleted = $image.StatusProgressPercentage
                    if ($PercentCompleted -eq $null){
                        $PercentCompleted = 0
                    } 
                    Write-Progress -Activity "Download Percentage: " -Status "$PercentCompleted % Complete" -PercentComplete $PercentCompleted
                    Start-Sleep -Seconds 5    
                    if ($image.ProvisioningStatus -eq "Failed") {
                        Break
                    }           
                }
                if ($image.ProvisioningStatus -eq "Failed"){
                    Write-Error $image.StatusErrorMessage -ErrorAction Stop
                }
               
            } catch {
                $e = $_
                if ($e.FullyQualifiedErrorId -match "MissingAzureKubernetesMapping" ){
                    Write-Error "An older version of the Arc VM cluster extension is installed on your cluster. Please downgrade the Az.StackHCIVm version to 1.0.1 to proceed." -ErrorAction Stop
                } else {
                    Write-Error $e.Exception.Message -ErrorAction Stop
                }
            }

        
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
            
            $PSBoundParameters['NoWait'] = $true
            $PSBoundParameters['ErrorAction'] = 'Stop'
            try {
                Az.StackHCIVM.internal\New-AzStackHCIVMMarketplaceGalleryImage @PSBoundParameters
                Start-Sleep -Seconds 60
                $PercentCompleted = 0 
                Write-Progress -Activity "Download Percentage: " -Status "$PercentCompleted % Complete:" -PercentComplete $PercentCompleted
                $null = $PSBoundParameters.Remove("Version")
                $null = $PSBoundParameters.Remove("URN")
                $null = $PSBoundParameters.Remove("Tag")
                $null = $PSBoundParameters.Remove("StoragePathId")
                $null = $PSBoundParameters.Remove("Sku")
                $null = $PSBoundParameters.Remove("Publisher")
                $null = $PSBoundParameters.Remove("Offer")
                $null = $PSBoundParameters.Remove("OSType")
                $null = $PSBoundParameters.Remove("ImagePath")
                $null = $PSBoundParameters.Remove("CustomLocationId")
                $null = $PSBoundParameters.Remove("CloudInitDataSource")
                $null = $PSBoundParameters.Remove("Location")
                $null = $PSBoundParameters.Remove("NoWait")
                while ($PercentCompleted -ne 100 ) {                  
                    $image = Az.StackHCIVM.internal\Get-AzStackHCIVMMarketplaceGalleryImage @PSBoundParameters
                    $PercentCompleted = $image.StatusProgressPercentage
                    if ($PercentCompleted -eq $null){
                        $PercentCompleted = 0
                    } 
                    Write-Progress -Activity "Download Percentage: " -Status "$PercentCompleted % Complete" -PercentComplete $PercentCompleted
                    Start-Sleep -Seconds 5    
                    if ($image.ProvisioningStatus -eq "Failed") {
                        Break
                    }           
                }
                if ($image.ProvisioningStatus -eq "Failed"){
                    Write-Error $image.StatusErrorMessage -ErrorAction Stop
                }
               
            } catch {
                $e = $_
                if ($e.FullyQualifiedErrorId -match "MissingAzureKubernetesMapping" ){
                    Write-Error "An older version of the Arc VM cluster extension is installed on your cluster. Please downgrade the Az.StackHCIVm version to 1.0.1 to proceed." -ErrorAction Stop
                } else {
                    Write-Error $e.Exception.Message -ErrorAction Stop
                }
            }


        }

        if ($PSCmdlet.ParameterSetName -eq "GalleryImage")
        {
            try{
                Az.StackHCIVM.internal\New-AzStackHCIVMGalleryImage -ErrorAction Stop @PSBoundParameters 
            } catch {
                $e = $_
                if ($e.FullyQualifiedErrorId -match "MissingAzureKubernetesMapping" ){
                    Write-Error "An older version of the Arc VM cluster extension is installed on your cluster. Please downgrade the Az.StackHCIVm version to 1.0.1 to proceed." -ErrorAction Stop
                } else {
                    Write-Error $e.Exception.Message -ErrorAction Stop
                }
            }
        }

       
    
}