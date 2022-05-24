function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}

$env = @{}
if ($UsePreviousConfigForRecord) {
    $previousEnv = Get-Content (Join-Path $PSScriptRoot 'env.json') | ConvertFrom-Json
    $previousEnv.psobject.properties | Foreach-Object { $env[$_.Name] = $_.Value }
}
# Add script method called AddWithCache to $env, when useCache is set true, it will try to get the value from the $env first.
# example: $val = $env.AddWithCache('key', $val, $true)
$env | Add-Member -Type ScriptMethod -Value { param( [string]$key, [object]$val, [bool]$useCache) if ($this.Contains($key) -and $useCache) { return $this[$key] } else { $this[$key] = $val; return $val } } -Name 'AddWithCache'
function setupEnv() {
     #Preload subscriptionId and tenant from context, which will be used in test
    #as default. You could change them if needed.
    $subscriptionId = (Get-AzContext).Subscription.Id
    $env.SubscriptionId = $subscriptionId
    $env.Tenant = (Get-AzContext).Tenant.Id
    $resourceGroup = 'databox-pwsh-rg-' + (RandomString -allChars $false -len 2)
    New-AzResourceGroup -Name $resourceGroup -Location EastUs
    Write-Host "RG created"

    #Create job for all other operation except New
    $AddressName = "pwAddress" + (RandomString -allChars $false -len 4)
    $OrderItemName = "powershellItem" + (RandomString -allChars $false -len 4)
    $OrderName = "powershellOrder" + (RandomString -allChars $false -len 4)
    $env.Add("ResourceGroup",$resourceGroup)
    $OrderId = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $resourceGroup +"/providers/Microsoft.EdgeOrder/locations/eastus/orders/" + $OrderName
    
    $contactDetail = New-AzEdgeOrderContactDetailsObject -ContactName "random" -EmailList @("dhja@microsoft.com") -Phone "1234567891"
    $ShippingDetails = New-AzEdgeOrderShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"

    $HierarchyInformation=New-AzEdgeOrderHierarchyInformationObject -ProductFamilyName "azurestackedge" -ProductLineName "azurestackedge" -ProductName "azurestackedgegpu" -ConfigurationName "EdgeP_High"

    $details = New-AzEdgeOrderOrderItemDetailsObject -OrderItemType "Purchase"  -ProductDetail  @{"HierarchyInformation"=$HierarchyInformation}
    
    $resource = New-AzEdgeOrderItem -Name $OrderItemName -ResourceGroupName $resourceGroup -ForwardAddressContactDetail $contactDetail -Location "eastus" -OrderId $OrderId -OrderItemDetail $details -SubscriptionId $subscriptionId -ForwardShippingAddress $ShippingDetails

    Write-Host -ForegroundColor Green "Create completed" $AddressName 
    Write-Host -ForegroundColor Green "Create completed" $resourceGroup
    Write-Host -ForegroundColor Green "Create completed" $contactDetail
    Write-Host -ForegroundColor Green "Create completed" $subscriptionId
    
  
    # $addressResource = New-AzEdgeOrderAddress -Name $AddressName -ResourceGroupName $resourceGroup -ContactDetail $contactDetail
    # -Location "eastus"  -SubscriptionId $subscriptionId -ShippingAddress $ShippingDetails -Debug

    Write-Host -ForegroundColor Green "Create completed" 

    $AddressNameTest = "pwAddTest" + (RandomString -allChars $false -len 4)
    $OrderItemNameTest = "powershellItemTest" + (RandomString -allChars $false -len 4)
    $OrderNameTest = "powershellOrderTest" + (RandomString -allChars $false -len 4)

    $OrderIdTest = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $resourceGroup +"/providers/Microsoft.EdgeOrder/locations/eastus/orders/" + $OrderNameTest

    $env.Add("AddressName",$AddressName)
    $env.Add("OrderItemName",$OrderItemName)
    $env.Add("OrderName",$OrderName)
    $env.Add("AddressNameTest",$AddressNameTest)
    $env.Add("OrderItemNameTest", $OrderItemNameTest)
    $env.Add("OrderNameTest", $OrderNameTest)
    $env.Add("OrderIdTest", $OrderIdTest)


    $env.Add("ContactName", "random")
    $env.Add("EmailList", @("dhja@microsoft.com"))
    $env.Add("Phone", "1234567891")

    $env.Add("StreetAddress1", "101 TOWNSEND ST")
    $env.Add("City", "San Francisco")
    $env.Add("StateOrProvince", "CA")
    $env.Add("Country", "US")
    $env.Add("AddressType", "Commercial")
    $env.Add("PostalCode", "94107")

    #For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    Write-Host -ForegroundColor Green "Just did " + $env.ResourceGroup
    Remove-AzResourceGroup -Name $env.ResourceGroup
    # Clean resources you create for testing
}

