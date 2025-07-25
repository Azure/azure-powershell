
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
https://learn.microsoft.com/powershell/module/az.stackhcivm/remove-azstackhcivmimage
#>

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
    # The ARM Resource ID of the image.
    ${ResourceId},

    [Parameter(HelpMessage='Forces the cmdlet to remove the network interface without prompting for confirmation.')]
    [System.Management.Automation.SwitchParameter]
    ${Force},

    
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


    Write-Warning("Running this command will delete the image.")
    $isGalleryImage = $false
    $isMarketplaceGalleryImage = $false

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
            return Az.StackHCIVM.internal\Remove-AzStackHCIVMMarketplaceGalleryImage @PSBoundParameters
        }

        if ($isGalleryImage)
        {
            return Az.StackHCIVM.internal\Remove-AzStackHCIVMGalleryImage @PSBoundParameters
        }
    }

} 