function Get-AzCloudServicePublicIPAddress {
    param(
        [string] $SubscriptionId,

        [Parameter(Mandatory=$true, ParameterSetName="CloudServiceName")]
        [string] $ResourceGroupName,
        
        [Parameter(Mandatory=$true, ParameterSetName="CloudServiceName")]
        [string] $CloudServiceName,

        [Parameter(Mandatory=$true, ParameterSetName="CloudService")]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20201001Preview.CloudService] $CloudService,

        [Parameter(DontShow)]
        [string] $ApiVersion = "2020-06-01"

    )
    process {

        if (-not $PSBoundParameters.ContainsKey("SubscriptionId")) 
        {
            $SubscriptionId = (Get-AzContext).Subscription.Id
        }

        if ($PSBoundParameters.ContainsKey("CloudService"))
        {
            $elements = $CloudService.Id.Split("/")
            $SubscriptionId = $elements[2]
            $ResourceGroupName = $elements[4]
            $CloudServiceName = $CloudService.Name
        }

        # Create the URI as per the input
        $uriToInvoke = "/subscriptions/" + $SubscriptionId + "/resourceGroups/" + $ResourceGroupName + "/providers/Microsoft.Compute/cloudServices/" + $CloudServiceName + "/publicIPAddresses?api-version=" + $ApiVersion

        # Invoke and display the information
        $result = Az.Accounts\Invoke-AzRestMethod -Method GET -Path $uriToInvoke
        $result.Content
    }
}
