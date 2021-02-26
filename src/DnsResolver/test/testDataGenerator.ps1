function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}

function RandomResolverName([bool]$allChars, [int32]$len) {
    return "dnsresolver00" + (RandomString -allChars $false -len 6)
}

function GetNrpMockVirtualNetwork([String]$subscriptionId, [String]$resourceGroupName, [String]$virtualNetworkName, [String]$NrpSimulatorRootUri) {
    $contentType3 = "application/json"
    $relativeRequestUri = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName/providers/Microsoft.Network/virtualNetworks/$virtualNetworkName"
    $completeVirtualNetworkRequestUri = $NrpSimulatorRootUri + $relativeRequestUri

    $data = [ordered]@{
        location = "westus2"
        properties = @{
          addressSpace = @{
            addressPrefixes = @({"2.2"}, {"1.1"})
         }
        } 
        tags = @{"tag1" = "value1"}
    }
    $json = $data | ConvertTo-Json -Depth 3 -Compress
    $Result = Invoke-RestMethod -Uri $completeVirtualNetworkRequestUri -Method PUT  -Body $json -ContentType $contentType3
    return $Result
}