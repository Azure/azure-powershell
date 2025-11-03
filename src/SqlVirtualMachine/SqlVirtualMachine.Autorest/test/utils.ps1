function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
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
	$env.Location = "centralus"
    $env.ResourceGroupName2 = "azpstest-sqlvm-gp"
    $env.ResourceGroupName = "sqlvmtest-gp"
    $env.SqlVMName = "azpstest-sqlvm"
    $env.SqlVMName_HA1 = "azpstestsql1"
    $env.SqlVMName_HA2 = "azpstestsql2"
    $env.SqlVMGroupName = "azpssqlcluster"
    $env.SqlVMGroupListnerName = "azpssqlcluster"
    $env.SqlVMGroupName1 = "ag1"
    $env.SqlVMGroupName2 = "ag2"
    $env.LoadBalancerName = "azpstestlb"
    $env.IPAddress1 = "192.168.1.77"
    $env.IPAddress2 = "192.168.1.99"
    $env.IPAddress3 = "192.168.2.99"
    $env.VirtualNetworkName = "sqldcvnet"
    $env.SubnetName1 = "vm-subnet1"
    $env.SubnetName2 = "vm-subnet2"
    $env.ProbePort = "7777"
    $env.SqlVMGroupLoadBalancerListnerName = "aglblistener"
    $env.SqlVMGroupMultiSubnetIPListnerName = "agmslistener"
    $env.SqlImageOffer = "SQL2019-WS2019"
    $env.SqlImageSku = "Enterprise"
    $env.DomainFqdn = "corp.azpstestsql.com"
    $env.SqlVMName_HA1Id = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/$($env.SqlVMName_HA1)"
    $env.SqlVMName_HA2Id = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/$($env.SqlVMName_HA2)"
    $env.SQLVMNameID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName2)/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/$($env.SQLVMName)"
    $env.SqlVMGroupId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachineGroups/$($env.SqlVMGroupName)"
    $env.LoadBalancerResourceId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Network/loadBalancers/$($env.LoadBalancerName)"
    $env.SubnetId1 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Network/virtualNetworks/$($env.VirtualNetworkName)/subnets/$($env.SubnetName1)"
    $env.SubnetId2 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Network/virtualNetworks/$($env.VirtualNetworkName)/subnets/$($env.SubnetName2)"
    $env.SqlVMGroupLoadBalancerListnerId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachineGroups/$($env.SqlVMGroupName)/availabilityGroupListeners/$($env.SqlVMGroupLoadBalancerListnerName)"
    $env.SqlVMGroupMultiSubnetIPListnerId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachineGroups/$($env.SqlVMGroupName)/availabilityGroupListeners/$($env.SqlVMGroupMultiSubnetIPListnerName)"
    $env.StorageAccountUrl = "https://azpstestsqlvmstorage01.blob.core.windows.net/"
    
    # https://learn.microsoft.com/en-us/azure/azure-sql/virtual-machines/windows/availability-group-azure-portal-configure?view=azuresql&tabs=azure-powershell
    # 1.Create Vnet azpstestsqlvnet
    # New-AzVirtualNetwork -ResourceGroupName sqlvmtest-gp -Name azpstestsqlvnet -Location centralus -AddressPrefix "192.168.0.0/16"
    # New-AzVirtualNetworkSubnetConfig -Name "DC-subnet" -AddressPrefix "192.168.0.0/24" -VirtualNetwork $vnet
    # New-AzVirtualNetworkSubnetConfig -Name "vm-subnet1" -AddressPrefix "192.168.1.0/24" -VirtualNetwork $vnet
    # New-AzVirtualNetworkSubnetConfig -Name "vm-subnet2" -AddressPrefix "192.168.2.0/24" -VirtualNetwork $vnet
    # 2. Create a Windows Server 20xx DataCenter VM 'sqldcvm-01' with Vnet azpstestsqlvnet DC-subnet
    # 3. Configure the domain controller: https://learn.microsoft.com/en-us/azure/azure-sql/virtual-machines/windows/availability-group-manually-configure-prerequisites-tutorial-multi-subnet?view=azuresql#configure-the-domain-controller
    # 4. Set static IP for the VM
    # 5. Install AD DS role and promote it to a domain controller azpstestsql.com, or corp.azpstestsql.com
    # 6. Set VM Static IP into Vnet DNS
    # 7. Set up Inbound rules of NSG, Port: DNS(UDP), 135, 5022, DynamicsPorts(49152-65535), LDAP(389), Kerberos(88)
    # 8. Set Firewall rules
    # New-NetFirewallRule -DisplayName "Allow DNS" -Direction Inbound -Protocol UDP -LocalPort 53 -Action Allow
    # New-NetFirewallRule -DisplayName "Allow Kerberos" -Direction Inbound -Protocol TCP -LocalPort 88 -Action Allow
    # New-NetFirewallRule -DisplayName "Allow LDAP" -Direction Inbound -Protocol TCP -LocalPort 389 -Action Allow
    # New-NetFirewallRule -DisplayName "Allow RPC" -Direction Inbound -Protocol TCP -LocalPort 135 -Action Allow
    # New-NetFirewallRule -DisplayName "Allow RPC Dynamic" -Direction Inbound -Protocol TCP -LocalPort 49152-65535 -Action Allow
    # New-NetFirewallRule -DisplayName "Allow SMB" -Direction Inbound -Protocol TCP -LocalPort 445 -Action Allow
    # New-NetFirewallRule -DisplayName "Allow HADR" -Direction Inbound -Protocol TCP -LocalPort 5022 -Action Allow
    
    # sqlvmtest-gp Group
    # Create two SQL VMs azpstestsql1, azpstestsql2 using Sql VM E2ds with High availability, User azureadmin, 
    # Vnet azpstestsqlvnet, subnet 1 and 2, listener IP 192.168.1.7, 192.168.2.7
    # WSFC Cluster azpssqlcluster, Storage Account azpstestsqlstorage1, 
    # Domain FQDN azpstestsql.com or corp.azpstestsql.com, Availability Group azpssqlcluster, Listener sqlaglistener
    # azpstest-sqlvm-gp Group Create VM azpstest-sqlvm and storage account azpstestsqlvmstorage01
    
    # Failed to clean up AAD User: Get-ADComputer -Identity "azpssqlcluster"

    # $storageAccountPrimaryKey=ConvertTo-SecureString -String 'storage access keys' -AsPlainText
    # New-azSqlVMGroup -ResourceGroupName sqlvmtest-gp -Name azpssqlcluster -Location centralus -Offer "SQL2019-WS2019" -Sku "Enterprise" -DomainFqdn 'azpstestsql.com' -StorageAccountPrimaryKey $storageAccountPrimaryKey -ClusterSubnetType MultiSubnet -ClusterBootstrapAccount 'azureadmin@azpstestsql.com' -SqlServiceAccount 'azureadmin' -StorageAccountUrl "https://azpstestsqlstorage01.blob.core.windows.net/" -ClusterOperatorAccount 'azureadmin@azpstestsql.com'

    # $SubscriptionId = (Get-AzContext).Subscription.Id
    # $groupid = "/subscriptions/$($SubscriptionId)/resourceGroups/sqlvmtest-gp/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachineGroups/azpssqlcluster"
    # $sqlvmha1 = "/subscriptions/$($SubscriptionId)/resourceGroups/sqlvmtest-gp/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/azpstestsql1"
    # $sqlvmha2 = "/subscriptions/$($SubscriptionId)/resourceGroups/sqlvmtest-gp/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/azpstestsql2"
    # $sqlvm = "/subscriptions/$($SubscriptionId)/resourceGroups/azpstest-sqlvm-gp/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/azpstest-sqlvm"
    # $subnet1 = "/subscriptions/$($SubscriptionId)/resourceGroups/sqlvmtest-gp/providers/Microsoft.Network/virtualNetworks/sqldcvnet/subnets/vm-subnet1"
    # New-AzAvailabilityGroupListener -ResourceGroupName sqlvmtest-gp -SqlVMGroupName azpssqlcluster -Name aglblistener -AvailabilityGroupName ag1 -IpAddress "192.168.1.77" -LoadBalancerResourceId "/subscriptions/$($SubscriptionId)/resourceGroups/sqlvmtest-gp/providers/Microsoft.Network/loadBalancers/azpstestlb" -SubnetId $subnet1 -ProbePort '7777' -SqlVirtualMachineId $sqlvmha1, $sqlvmha2
    # $msconfig2 = New-AzSqlVirtualMachineMultiSubnetIPConfigurationObject -PrivateIPAddressSubnetResourceId "/subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/sqlvmtest-gp/providers/Microsoft.Network/virtualNetworks/sqldcvnet/subnets/vm-subnet2" -PrivateIPAddressIpaddress "192.168.2.99" -SqlVirtualMachineInstance "/subscriptions/0E745469-49F8-48C9-873B-24CA87143DB1/resourceGroups/sqlvmtest-gp/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/azpstestsql2"
    # $msconfig1 = New-AzSqlVirtualMachineMultiSubnetIPConfigurationObject -PrivateIPAddressSubnetResourceId "/subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/sqlvmtest-gp/providers/Microsoft.Network/virtualNetworks/sqldcvnet/subnets/vm-subnet1" -PrivateIPAddressIpaddress "192.168.1.99" -SqlVirtualMachineInstance "/subscriptions/0E745469-49F8-48C9-873B-24CA87143DB1/resourceGroups/sqlvmtest-gp/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/azpstestsql1"
    # New-AzAvailabilityGroupListener -ResourceGroupName sqlvmtest-gp -Name agmslistener -SqlVMGroupName azpssqlcluster -AvailabilityGroupName azpssqlcluster -Port 1433 -MultiSubnetIPConfiguration $msconfig1,$msconfig2


    
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

