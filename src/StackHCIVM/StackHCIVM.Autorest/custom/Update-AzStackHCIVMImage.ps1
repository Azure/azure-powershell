<#
.Synopsis
The operation to update an image.

.Description
The operation to update an image.
Please note some properties can be set only during image creation.

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IGalleryImages
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImages
.Link
https://learn.microsoft.com/powershell/module/az.stackhcivm/update-azstackhcivmimage
#>

function Update-AzStackHCIVMImage{
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IMarketplaceGalleryImages],ParameterSetName='Marketplace' )]
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IGalleryImages],ParameterSetName='GalleryImage' )]
    [CmdletBinding(DefaultParameterSetName='GalleryImage', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
   
  param(
    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
    [System.String]
    # Name of the gallery image
    ${Name},

    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='ByName')]
    [Parameter(ParameterSetName='ByResourceId')] 
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='ByResourceId', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
    [System.String]
    # The ARM Resource ID of the image.
    ${ResourceId},

    [Parameter(ParameterSetName='ByName')]
    [Parameter(ParameterSetName='ByResourceId')] 
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.IGalleryImagesUpdateRequestTags]))]
    [System.Collections.Hashtable]
    # Resource tags
    ${Tag},

    
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

    process {
        if ($PSCmdlet.ParameterSetName -eq "ByName"){

            $isGalleryImage = $false
            $isMarketplaceGalleryImage = $false

            
            $galImage = Az.StackHCIVM.internal\Get-AzStackHCIVMGalleryImage -Name $Name -ResourceGroupName $ResourceGroupName -SubscriptionId $SubscriptionId -ErrorAction SilentlyContinue
            if ($galImage -ne $null){
                $isGalleryImage = $true 
            } else {
                $marketplaceGalImage = Az.StackHCIVM.internal\Get-AzStackHCIVMMarketplaceGalleryImage -Name $Name -ResourceGroupName $ResourceGroupName -SubscriptionId $SubscriptionId -ErrorAction SilentlyContinue
                if ($marketplaceGalImage -ne $null){
                    $isMarketplaceGalleryImage = $true 
                }else{
                    Write-Error "An Image with name: $Name does not exist in Resource Group: $ResourceGroupName" -ErrorAction Stop
                }
            }
        

            if ($isGalleryImage){
                try{
                    Az.StackHCIVM.internal\Update-AzStackHCIVMGalleryImage -ErrorAction Stop @PSBoundParameters 
                } catch {
                    $e = $_
                    if ($e.FullyQualifiedErrorId -match "MissingAzureKubernetesMapping" ){
                        Write-Error "An older version of the Arc VM cluster extension is installed on your cluster. Please downgrade the Az.StackHCIVm version to 1.0.1 to proceed." -ErrorAction Stop
                    } else {
                        Write-Error $e.Exception.Message -ErrorAction Stop
                    }
                }
            } 

            if ($isMarketplaceGalleryImage){
                try{
                    Az.StackHCIVM.internal\Update-AzStackHCIVMMarketplaceGalleryImage -ErrorAction Stop @PSBoundParameters 
                } catch {
                    $e = $_
                    if ($e.FullyQualifiedErrorId -match "MissingAzureKubernetesMapping" ){
                        Write-Error "An older version of the Arc VM cluster extension is installed on your cluster. Please downgrade the Az.StackHCIVm version to 1.0.1 to proceed." -ErrorAction Stop
                    } else {
                        Write-Error $e.Exception.Message -ErrorAction Stop
                    }
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

                    try{
                        Az.StackHCIVM.internal\Update-AzStackHCIVMGalleryImage -ErrorAction Stop @PSBoundParameters 
                    } catch {
                        $e = $_
                        if ($e.FullyQualifiedErrorId -match "MissingAzureKubernetesMapping" ){
                            Write-Error "An older version of the Arc VM cluster extension is installed on your cluster. Please downgrade the Az.StackHCIVm version to 1.0.1 to proceed." -ErrorAction Stop
                        } else {
                            Write-Error $e.Exception.Message -ErrorAction Stop
                        }
                    }
                    
                } elseif ($ResourceId -match $marketplaceGalImageRegex){
                    $subscriptionId = $($Matches['subscriptionId'])
                    $resourceGroupName = $($Matches['resourceGroupName'])
                    $resourceName = $($Matches['imageName'])
                    $null = $PSBoundParameters.Remove("ResourceId")
                    $PSBoundParameters.Add("Name", $resourceName)
                    $PSBoundParameters.Add("ResourceGroupName", $resourceGroupName)
                    $null = $PSBoundParameters.Remove("SubscriptionId")
                    $PSBoundParameters.Add("SubscriptionId", $subscriptionId)
                    try{
                        Az.StackHCIVM.internal\Update-AzStackHCIVMMarketplaceGalleryImage -ErrorAction Stop @PSBoundParameters 
                    } catch {
                        $e = $_
                        if ($e.FullyQualifiedErrorId -match "MissingAzureKubernetesMapping" ){
                            Write-Error "An older version of the Arc VM cluster extension is installed on your cluster. Please downgrade the Az.StackHCIVm version to 1.0.1 to proceed." -ErrorAction Stop
                        } else {
                            Write-Error $e.Exception.Message -ErrorAction Stop
                        }
                    }

                } else {
                    Write-Error "Resource ID is invalid: $ResourceId"
                }
        }    
    }
} 