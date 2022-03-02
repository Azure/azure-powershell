function Get-AzFrontDoorCdnProfile {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IProfile])]
    [CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
    param(
        [Parameter(ParameterSetName='Get', Mandatory)]
        [Alias('ProfileName')]
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Category('Path')]
        [System.String]
        # Name of the Azure Front Door Standard or Azure Front Door Premium or CDN profile which is unique within the resource group.
        ${Name},

        [Parameter(ParameterSetName='Get', Mandatory)]
        [Parameter(ParameterSetName='List1', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Category('Path')]
        [System.String]
        # Name of the Resource group within the Azure subscription.
        ${ResourceGroupName},

        [Parameter(ParameterSetName='Get')]
        [Parameter(ParameterSetName='List')]
        [Parameter(ParameterSetName='List1')]
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String[]]
        # Azure Subscription ID.
        ${SubscriptionId}
    )

    process {
        $internalProfiles = Az.Cdn.internal\Get-AzCdnProfile @PSBoundParameters
        if ($null -eq $internalProfiles )
        {
            $profiles = $null
        }else
        {
            if($internalProfiles -is [array]){
                $profiles = @()
                foreach ($oneInternalProfile in $internalProfiles)
                {
                    if(ISFrontDoorCdnProfile($oneInternalProfile.SkuName))
                    {
                        $profiles += $oneInternalProfile
                    }
                }
            }else
            {
                $oneInternalProfile = $internalProfiles
                if(ISFrontDoorCdnProfile($oneInternalProfile.SkuName))
                {
                    $profiles = $oneInternalProfile
                }else{
                    $profiles = $null
                }
            }
        } 

        Write-Output $profiles
    }
}