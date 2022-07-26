
."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\Constants.ps1"
$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

function CreateVirtualNetwork([String]$SubscriptionId, [String]$ResourceGroupName, [String]$VirtualNetworkName){
    if( $null -eq $NRP_SIMULATOR_URI){
        return CreateNrpVirtualNetwork -ResourceGroupName $ResourceGroupName  -Location $LOCATION -VirtualNetworkName $VirtualNetworkName AddressPrefix $env.AddressPrefix
    }else {
        return CreateNrpMockVirtualNetwork -SubscriptionId  $SubscriptionId -ResourceGroupName $ResourceGroupName -VirtualNetworkName $VirtualNetworkName
    }

}

function CreateNrpVirtualNetwork([String]$ResourceGroupName, [String]$Location, [String]$VirtualNetworkName, [String]$AddressPrefix){
    $virtualNetwork = New-AzVirtualNetwork -ResourceGroupName $ResourceGroupName -Location $Location -Name $VirtualNetworkName  -AddressPrefix $AddressPrefix
    return $virtualNetwork
}

function CreateNrpMockVirtualNetwork([String]$SubscriptionId, [String]$ResourceGroupName, [String]$VirtualNetworkName) {
    $contentType3 = "application/json"
    $relativeRequestUri = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.Network/virtualNetworks/$VirtualNetworkName"
    $completeVirtualNetworkRequestUri = $NRP_SIMULATOR_URI + $relativeRequestUri

    $data = [ordered]@{
        location = "eastus2"
        properties = @{
          addressSpace = @{
            addressPrefixes = @({"10.0.0.0/8"})
         }
        } 
        tags = GetRandomHashtable -size 2
    }
    $json = $data | ConvertTo-Json -Depth 3 -Compress
    $Result = Invoke-RestMethod -Uri $completeVirtualNetworkRequestUri -Method PUT  -Body $json -ContentType $contentType3
    return $Result
}

function CreateSubnet([String]$SubscriptionId, [String]$ResourceGroupName, [String]$VirtualNetworkName){
    if($null -eq $NRP_SIMULATOR_URI){
        throw [System.NotImplementedException]
    }else {
        return CreateNrpMockSubnet -SubscriptionId  $SubscriptionId -ResourceGroupName $ResourceGroupName -VirtualNetworkName $VirtualNetworkName
    }
}

function CreateNrpMockSubnet([String]$SubscriptionId, [String]$ResourceGroupName, [String]$VirtualNetworkName) {
    $contentType3 = "application/json"
    $relativeRequestUri = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.Network/virtualNetworks/$VirtualNetworkName/subnets/$SUBNET_NAME"
    $completeVirtualNetworkRequestUri = $NRP_SIMULATOR_URI + $relativeRequestUri
    $data = [ordered]@{
        properties = @{
            addressPrefix = "10.2.2.0/28"
        } 
        tags = GetRandomHashtable -size 2
    }
    $json = $data | ConvertTo-Json -Depth 2 -Compress
    $Result = Invoke-RestMethod -Uri $completeVirtualNetworkRequestUri -Method PUT  -Body $json -ContentType $contentType3
    return $Result
}