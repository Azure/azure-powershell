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
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
	$env.Location = "eastus"
    $env.ResourceGroupName = "azpstest-sqlvm-gp"
    $env.SqlVMName = "azpstest-sqlvm"
    $env.SqlVMName_HA1 = "azpstestsql1"
    $env.SqlVMName_HA2 = "azpstestsql2"
    $env.SqlVMGroupName = "azpssqlcluster"
    $env.SqlVMGroupListnerName = "azpssqlcluster"
    $env.SqlVMGroupName1 = "ag1"
    $env.SqlVMGroupName2 = "ag2"
    $env.LoadBalancerName = "azpstestlb"
    $env.IPAddress1 = "192.168.16.7"
    $env.IPAddress2 = "192.168.16.9"
    $env.IPAddress3 = "192.168.17.9"
    $env.VirtualNetworkName = "azpstestsqlvn"
    $env.SubnetName1 = "subnet1"
    $env.SubnetName2 = "subnet2"
    $env.ProbePort = "7777"
    $env.SqlVMGroupLoadBalancerListnerName = "aglblistener"
    $env.SqlVMGroupMultiSubnetIPListnerName = "agmslistener"
    $env.SqlVMName_HA1Id = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/$($env.SqlVMName_HA1)"
    $env.SqlVMName_HA2Id = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/$($env.SqlVMName_HA2)"
    $env.SqlVMGroupId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachineGroups/$($env.SqlVMGroupName)"
    $env.LoadBalancerResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Network/loadBalancers/$($env.LoadBalancerName)"
    $env.SubnetId1 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Network/virtualNetworks/$($env.VirtualNetworkName)/subnets/$($env.SubnetName1)"
    $env.SubnetId2 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Network/virtualNetworks/$($env.VirtualNetworkName)/subnets/$($env.SubnetName2)"
    $env.SqlVMGroupLoadBalancerListnerId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachineGroups/$($env.SqlVMGroupName)/availabilityGroupListeners/$($env.SqlVMGroupLoadBalancerListnerName)"
    $env.SqlVMGroupMultiSubnetIPListnerId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachineGroups/$($env.SqlVMGroupName)/availabilityGroupListeners/$($env.SqlVMGroupMultiSubnetIPListnerName)"

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

