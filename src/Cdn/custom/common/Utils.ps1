function ISFrontDoorCdnProfile([string]$SkuName) {
    if ($SkuName -eq [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.SkuName]::PremiumAzureFrontDoor -or
        $SkuName -eq [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.SkuName]::StandardAzureFrontDoor) {
        return $true
    }else{
        return $false
    }
}
