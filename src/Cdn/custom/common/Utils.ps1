function ISFrontDoorCdnProfile([string]$SkuName) {
    if ($SkuName -eq [System.String]::PremiumAzureFrontDoor -or
        $SkuName -eq [System.String]::StandardAzureFrontDoor) {
        return $true
    }else{
        return $false
    }
}
