
function Get-AzStackHCIVMNetworkInterface {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.Api20221215Preview.INetworkInterfaces])]
[CmdletBinding( PositionalBinding=$false)]

param(
    
    [Parameter(ParameterSetName='ByResourceId', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
    [System.String]
    # The ID of the target subscription.
    ${ResourceId},

  
    [Parameter(ParameterSetName='ByResourceId')]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile}

)
  process {
       
        if ($ResourceId -match $nicRegex){
            
            $subscriptionId = $($Matches['subscriptionId'])
            $resourceGroupName = $($Matches['resourceGroupName'])
            $resourceName = $($Matches['nicName'])
            $null = $PSBoundParameters.Remove("ResourceId")
            $PSBoundParameters.Add("Name", $resourceName)
            $PSBoundParameters.Add("ResourceGroupName", $resourceGroupName)
            $null = $PSBoundParameters.Remove("SubscriptionId")
            $PSBoundParameters.Add("SubscriptionId", $subscriptionId)

            return  Az.StackHCIVM\Get-AzStackHCIVMNetworkInterface @PSBoundParameters

        } else {             
            Write-Error "Resource ID is invalid: $ResourceId"
        }
    
    }
}