function ISFrontDoorCdnProfile([string]$SkuName) {
    if ($SkuName -eq "Standard_AzureFrontDoor" -or
        $SkuName -eq "Premium_AzureFrontDoor") {
        return $true
    }else{
        return $false
    }
}
