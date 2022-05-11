#This script converts securestring to plaintext

function Transform-ResourceUri {
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        $PSBoundParameters
    )
    if($PSBoundParameters.ContainsKey("ResourceUri") ){
        # todo: validate resourceUri
        return $PSBoundParameters
    }
    $subscription = $PSBoundParameters['SubscriptionId']
    $ResourceGroupName = $PSBoundParameters['ResourceGroupName']
    if($PSBoundParameters.ContainsKey("WebApp") ){
        $WebApp = $PSBoundParameters['WebApp']
        $resourceId = "/subscriptions/$subscription/resourceGroups/$ResourceGroupName/providers/Microsoft.Web/sites/$WebApp"
        $PSBoundParameters['ResourceUri'] = $resourceId
        $null = $PSBoundParameters.Remove("WebApp")
    }
    elseif($PSBoundParameters.ContainsKey("ServiceName") )
    {
        $service = $PSBoundParameters['ServiceName']
        $app = $PSBoundParameters['AppName']
        $deployment=$PSBoundParameters['DeploymentName']
        
        $resourceId = "/subscriptions/$subscription/resourceGroups/$ResourceGroupName/providers/Microsoft.AppPlatform/Spring/$service/apps/$app/deployments/$deployment"
        $PSBoundParameters['ResourceUri'] = $resourceId
        $null = $PSBoundParameters.Remove("ServiceName")
        $null = $PSBoundParameters.Remove("AppName")
        $null = $PSBoundParameters.Remove("DeploymentName")
    }elseif($PSBoundParameters.ContainsKey("ContainerApp") )
    {
        $containerapp = $PSBoundParameters['ContainerApp']
        
        $resourceId = "/subscriptions/$subscription/resourceGroups/$ResourceGroupName/providers/Microsoft.App/containerApps/$containerapp"
        $PSBoundParameters['ResourceUri'] = $resourceId
        $null = $PSBoundParameters.Remove("ContainerApp")
    }
   
    $null = $PSBoundParameters.Remove("ResourceGroupName")
    $null = $PSBoundParameters.Remove("SubscriptionId")
    return $PSBoundParameters
}

function Set-Header {
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        $PSBoundParameters
    )
    $Pattern = "/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/(?<resourceProvider>[^/]+)(/(?<resourceType>[^/]+)/(?<resourceName>[^/]+))+"
    if($TargetService.Type -eq "AzureResource"  -And ($TargetService.Id -match $Pattern)) {
        $provider=$Matches.resourceProvider.ToLower()
        $resourceType=$Matches.resourceType.ToLower()
        if($PSBoundParameters.ContainsKey("VNetSolutionType") -Or $PSBoundParameters.ContainsKey("SecretStoreKeyVaultId") `
            -Or $provider -eq "microsoft.keyvault" -Or $resourceType -eq "flexibleservers") {
            if(-Not $PSBoundParameters.ContainsKey('XmsServiceconnectorUserToken')){
                $PSBoundParameters['XmsServiceconnectorUserToken'] = (Get-AzAccessToken).Token
            }
        }
    } 
    return $PSBoundParameters
}