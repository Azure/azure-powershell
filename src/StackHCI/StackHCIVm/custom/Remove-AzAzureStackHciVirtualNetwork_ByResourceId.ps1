function Remove-AzAzureStackHciVirtualNetwork_ByResourceId {
[OutputType([System.Boolean])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='ByResourceId', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Path')]
    [System.String]
    # The ID of the target subscription.
    ${ResourceId},

  
    [Parameter(ParameterSetName='ByResourceId')]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile}
)

    process {

         if ($ResourceId -match $vnetRegex){
        
            $subscriptionId = $($Matches['subscriptionId'])
            $resourceGroupName = $($Matches['resourceGroupName'])
            $resourceName = $($Matches['virtualNetworkName'])
            $null = $PSBoundParameters.Remove("ResourceId")
            $PSBoundParameters.Add("Name", $resourceName)
            $PSBoundParameters.Add("ResourceGroupName", $resourceGroupName)
            $null = $PSBoundParameters.Remove("SubscriptionId")
            $PSBoundParameters.Add("SubscriptionId", $subscriptionId)
            return  Az.AzureStackHCI\Remove-AzAzureStackHciVirtualNetwork @PSBoundParameters

        } else {             
            Write-Error "Resource ID is invalid: $ResourceId"
        }
        
    }
}