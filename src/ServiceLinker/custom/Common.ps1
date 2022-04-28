#This script converts securestring to plaintext

function Transform-WebappUri {
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        $PSBoundParameters
    )

    $subscription = (Get-AzContext).Subscription.Id
    $ResourceGroupName = $PSBoundParameters['ResourceGroupName']
    $Webapp = $PSBoundParameters['Webapp']
    $resourceId = "/subscriptions/$subscription/resourceGroups/$ResourceGroupName/providers/Microsoft.Web/sites/$Webapp"
    $PSBoundParameters['ResourceUri'] = $resourceId
    $null = $PSBoundParameters.Remove("ResourceGroupName")
    $null = $PSBoundParameters.Remove("Webapp")

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
        if($PSBoundParameters.ContainsKey("VNetSolutionType") ){
            $PSBoundParameters['XmsServiceconnectorUserToken'] = (Get-AzAccessToken).Token
        }elseif ($PSBoundParameters.ContainsKey("SecretStoreKeyVaultId")) {
            $PSBoundParameters['XmsServiceconnectorUserToken'] = (Get-AzAccessToken).Token
        }elseif($provider -eq "microsoft.keyvault" -Or $resourceType -eq "flexibleservers"){
            $PSBoundParameters['XmsServiceconnectorUserToken'] = (Get-AzAccessToken).Token
        }
    } 
    return $PSBoundParameters
}