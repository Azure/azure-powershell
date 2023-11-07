
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
The operation to delete an image.
.Description
The operation to delete an image.

.Outputs
System.Boolean

.Link
https://learn.microsoft.com/powershell/module/az.stackhci/remove-azstackhcivmimage
#>

function Remove-AzStackHCIVmImage{
    [OutputType([System.Boolean])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
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

        
        $galImage = Az.StackHCIVm.internal\Get-AzStackHCIVmGalleryImage -Name $Name -ResourceGroupName $ResourceGroupName -ErrorAction SilentlyContinue
        if ($galImage -ne $null){
            $isGalleryImage = $true 
        } else {
            $marketplaceGalImage = Az.StackHCIVm.internal\Get-AzStackHCIVmMarketplaceGalleryImage -Name $Name -ResourceGroupName $ResourceGroupName -ErrorAction SilentlyContinue 
            if ($marketplaceGalImage -ne $null){
                $isMarketplaceGalleryImage = $true 
            }
        }
    
        if (!$isGalleryImage -and !$isMarketplaceGalleryImage ){
            Write-Error "An Image with name: $Name does not exist in Resource Group: $ResourceGroupName" -ErrorAction Stop
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
                Write-Error "Resource ID is invalid: $ResourceId" -ErrorAction Stop
            }
    } 

    if ($PSCmdlet.ShouldProcess($PSBoundParameters['Name']) -and ($Force -or $PSCmdlet.ShouldContinue("Delete this image?", "Confirm")))
    {
        if ($PSBoundParameters.ContainsKey("Force")) {
            $null = $PSBoundParameters.Remove("Force")
        }

        if ($isMarketplaceGalleryImage)
        {
            return Az.StackHCIVm.internal\Remove-AzStackHCIVmMarketplaceGalleryImage @PSBoundParameters
        }

        if ($isGalleryImage)
        {
            return Az.StackHCIVm.internal\Remove-AzStackHCIVmGalleryImage @PSBoundParameters
        }
    }

} 