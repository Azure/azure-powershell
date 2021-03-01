
."$PSScriptRoot\testDataGenerator.ps1"
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

function CreateVirtualNetwork([String]$SubscriptionId, [String]$ResourceGroupName, [String]$VirtualNetworkName){
    $nrpSimulatorUri = $env.NRP_SIMULATOR_URI

    write-host "nrpSimulatorUri is = "  $nrpSimulatorUri

    if($nrpSimulatorUri -eq $null){
        return CreateNrpVirtualNetwork -ResourceGroupName $ResourceGroupName  -Location $env.LocationForVirtualNetwork -VirtualNetworkName $VirtualNetworkName AddressPrefix $env.AddressPrefix
    }else {
        return CreateNrpMockVirtualNetwork -SubscriptionId  $SubscriptionId -ResourceGroupName $ResourceGroupName -VirtualNetworkName $VirtualNetworkName -NrpSimulatorUri $nrpSimulatorUri
    }

}

function CreateNrpVirtualNetwork([String]$ResourceGroupName, [String]$Location, [String]$VirtualNetworkName, [String]$AddressPrefix){
    $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $ResourceGroupName -Location $Location -Name $VirtualNetworkName  -AddressPrefix $AddressPrefix
    return $virtualNetwork
}

function CreateNrpMockVirtualNetwork([String]$SubscriptionId, [String]$ResourceGroupName, [String]$VirtualNetworkName, [String]$NrpSimulatorUri) {
    $contentType3 = "application/json"
    $relativeRequestUri = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.Network/virtualNetworks/$VirtualNetworkName"
    $completeVirtualNetworkRequestUri = $NrpSimulatorUri + $relativeRequestUri
    write-host "completeVirtualNetworkRequestUri is = "  $completeVirtualNetworkRequestUri

    $data = [ordered]@{
        location = "westus2"
        properties = @{
          addressSpace = @{
            addressPrefixes = @({"40.121.0.0/16 "})
         }
        } 
        tags = GetRandomHashtable -size 2
    }
    $json = $data | ConvertTo-Json -Depth 3 -Compress
    $Result = Invoke-RestMethod -Uri $completeVirtualNetworkRequestUri -Method PUT  -Body $json -ContentType $contentType3
    return $Result
}

