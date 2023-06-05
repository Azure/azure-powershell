function Remove-AzStackHCIVMImage{
    [OutputType([System.Boolean])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
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
    # The ID of the target subscription.
    ${ResourceId},

    [Parameter(ParameterSetName='ByName')]
    [Parameter(ParameterSetName='ByResourceId')]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile}
    )

    process {

        if ($PSCmdlet.ParameterSetName -eq "ByName"){
            $isGalleryImage = $false
            $isMarketplaceGalleryImage = $false

            try {
                $galImage = Az.StackHCIVM\Get-AzStackHCIVMGalleryImage @PSBoundParameters 
                $isGalleryImage = $true 
            }
            catch {
                try {
                    $marketplaceGalImage = Az.StackHCIVM\Get-AzStackHCIVMMarketplaceGalleryImage @PSBoundParameters
                    $isMarketplaceGalleryImage = $true 
                }
                catch {
                    Write-Error "An Image with name: $Name does not exist in Resource Group: $ResourceGroupName"
                }
            }

            if ($isMarketplaceGalleryImage)
            {
                return Az.StackHCIVM\Remove-AzStackHCIVMMarketplaceGalleryImage @PSBoundParameters
            }

            if ($isGalleryImage)
            {
                return Az.StackHCIVM\Remove-AzStackHCIVMGalleryImage @PSBoundParameters
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

                    return  Az.StackHCIVM\Remove-AzStackHCIVMGalleryImage @PSBoundParameters

                } elseif ($ResourceId -match $marketplaceGalImageRegex){
                    $subscriptionId = $($Matches['subscriptionId'])
                    $resourceGroupName = $($Matches['resourceGroupName'])
                    $resourceName = $($Matches['imageName'])
                    $null = $PSBoundParameters.Remove("ResourceId")
                    $PSBoundParameters.Add("Name", $resourceName)
                    $PSBoundParameters.Add("ResourceGroupName", $resourceGroupName)
                    $null = $PSBoundParameters.Remove("SubscriptionId")
                    $PSBoundParameters.Add("SubscriptionId", $subscriptionId)

                    return  Az.StackHCIVM\Remove-AzStackHCIVMMarketplaceGalleryImage @PSBoundParameters
                } else {
                    Write-Error "Resource ID is invalid: $ResourceId"
                }
        } 

       
      
    }
} 