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

function Wait-TestDiscoveryResource {
    param(
        [scriptblock] $GetScript,
        [string] $ResourceDescription,
        [string] $ExpectedProvisioningState = 'Succeeded',
        [int] $TimeoutMinutes = 60
    )

    $deadline = [DateTime]::UtcNow.AddMinutes($TimeoutMinutes)
    do {
        try {
            $resource = & $GetScript
        }
        catch {
            $resource = $null
        }
        if ($null -ne $resource) {
            if ([string]::IsNullOrEmpty($ExpectedProvisioningState) -or $resource.ProvisioningState -eq $ExpectedProvisioningState) {
                return $resource
            }
        }

        if ([DateTime]::UtcNow -ge $deadline) {
            break
        }

        Start-TestSleep -Seconds 30
    } while ($true)

    throw "Timed out waiting for $ResourceDescription to reach provisioning state '$ExpectedProvisioningState'."
}

function Wait-TestPrivateEndpointConnectionName {
    param(
        [scriptblock] $ListScript,
        [string[]] $ExistingNames,
        [string] $ResourceDescription,
        [int] $TimeoutMinutes = 20
    )

    if ($null -eq $ExistingNames) {
        $ExistingNames = @()
    }

    $deadline = [DateTime]::UtcNow.AddMinutes($TimeoutMinutes)
    do {
        try {
            $connections = @(& $ListScript)
        }
        catch {
            $connections = @()
        }
        $newConnection = $connections | Where-Object { $ExistingNames -notcontains $_.Name } | Select-Object -First 1
        if ($null -ne $newConnection) {
            return $newConnection.Name
        }

        if ([DateTime]::UtcNow -ge $deadline) {
            break
        }

        Start-TestSleep -Seconds 20
    } while ($true)

    throw "Timed out waiting for private endpoint connection for $ResourceDescription."
}

function setupEnv() {
    Write-Host -ForegroundColor Magenta "Setting up test environment"
    $env['SubscriptionId'] = (Get-AzContext).Subscription.Id
    $env['Tenant'] = (Get-AzContext).Tenant.Id
    $env['location'] = 'uksouth'

    # --- Same-subscription infrastructure (dev-uksouth-stamp3) ---
    $env['ResourceGroupName'] = 'pstest-discovery-uksouth'
    $env['InfraResourceGroupName'] = 'fixedrg-uksouth-dev3'
    $env['VNetName'] = 'vnet-dev-uksouth'
    $uamiId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.InfraResourceGroupName)/providers/Microsoft.ManagedIdentity/userAssignedIdentities/dev-uksouth-uami"
    $env['UamiId'] = $uamiId
    $env['UamiSwcId'] = $uamiId
    $env['UamiUksId'] = $uamiId
    $env['StorageAccountName'] = 'storageuksouthdev3'
    $env['StorageAccountId'] = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.InfraResourceGroupName)/providers/Microsoft.Storage/storageAccounts/$($env.StorageAccountName)"

    # Ensure test resource group exists
    Write-Host "Ensuring resource group $($env.ResourceGroupName) exists..."
    $existingRg = Get-AzResourceGroup -Name $env.ResourceGroupName -ErrorAction SilentlyContinue
    if (-not $existingRg) {
        New-AzResourceGroup -Name $env.ResourceGroupName -Location $env.location | Out-Null
    }

    # ======================================================================
    # Resource names for Get/Update tests (pre-created in setupEnv)
    # ======================================================================
    $env['SupercomputerNameForGet'] = 'pstest-sc-get01'
    $env['BookshelfNameForGet'] = 'pstest-bs-get01'
    $env['WorkspaceNameForGet'] = 'pstest-ws-get01'
    $env['StorageContainerNameForGet'] = 'pstestsconget01'
    $env['ToolNameForGet'] = 'pstest-tool-get01'
    $env['NodePoolNameForGet'] = 'psnpget01'
    $env['NodePoolSupercomputerName'] = 'pstest-sc-get01'
    $env['ProjectNameForGet'] = 'pstest-proj-get01'
    $env['ProjectWorkspaceName'] = 'pstest-ws-get01'
    $env['StorageAssetNameForGet'] = 'pstest-sa-get01'
    $env['StorageAssetContainerName'] = 'pstestsconget01'
    $env['ChatModelDeploymentNameForGet'] = 'pstest-chat-get01'
    $env['ChatModelDeploymentWorkspaceName'] = 'pstest-ws-get01'

    # Computed resource IDs
    $env['SupercomputerIdForGet'] = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Discovery/supercomputers/$($env.SupercomputerNameForGet)"
    $env['BookshelfIdForGet'] = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Discovery/bookshelves/$($env.BookshelfNameForGet)"
    $env['WorkspaceIdForGet'] = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Discovery/workspaces/$($env.WorkspaceNameForGet)"
    $env['SupercomputerIdForNew'] = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Discovery/supercomputers/pstest-sc-new01"
    $env['Ws2AgentSubnetName'] = 'pstest-ws2-agent-subnet'
    $env['Ws2SubnetName'] = 'pstest-ws2-subnet'
    $env['Ws2PepSubnetName'] = 'pstest-ws2-pep-subnet'
    $env['WorkspacePrivateLinkResourceName'] = 'workspace'
    $env['BookshelfPrivateLinkResourceName'] = 'bookshelf'
    $existingContainerId = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.ResourceGroupName)/providers/Microsoft.Discovery/storageContainers/$($env.StorageContainerNameForGet)"
    $env['ExistingStorageContainerId'] = $existingContainerId

    # ======================================================================
    # Resource names for New-* tests (tests CREATE these, setupEnv just defines names)
    # ======================================================================
    # Top-level: CreateExpanded uses ForNew, ViaJsonString uses ForNew, ViaJsonFilePath uses ForNewJsonFile, ViaJsonString uses ForNewJson
    $env['SupercomputerNameForNew'] = 'pstest-newsc01'
    $env['SupercomputerNameForNewJson'] = 'pstest-newsc02'
    $env['SupercomputerNameForNewJsonFile'] = 'pstest-newsc03'
    $env['BookshelfNameForNew'] = 'pstest-newbs01'
    $env['BookshelfNameForNewJson'] = 'pstest-newbs02'
    $env['BookshelfNameForNewJsonFile'] = 'pstest-newbs03'
    $env['WorkspaceNameForNew'] = 'pstest-newws01'
    $env['WorkspaceNameForNewJson'] = 'pstest-newws02'
    $env['WorkspaceNameForNewJsonFile'] = 'pstest-newws03'
    $env['StorageContainerNameForNew'] = 'pstestnewscon01'
    $env['StorageContainerNameForNewExpanded'] = 'pstestnewscon02'
    $env['StorageContainerNameForNewJsonFile'] = 'pstestnewscon03'
    $env['ToolNameForNew'] = 'pstest-newtool01'
    $env['ToolNameForNewExpanded'] = 'pstest-newtool02'
    $env['ToolNameForNewJsonFile'] = 'pstest-newtool03'
    # Child resources: CreateExpanded, ViaJsonString, ViaJsonFilePath, ViaIdentityParentExpanded
    $env['NodePoolNameForNew'] = 'psnpnew01'
    $env['NodePoolNameForNewJson'] = 'psnpnew02'
    $env['NodePoolNameForNewJsonFile'] = 'psnpnew03'
    $env['NodePoolNameForNewViaPar'] = 'psnpnew04'
    $env['ProjectNameForNew'] = 'pstest-newproj01'
    $env['ProjectNameForNewJson'] = 'pstest-newproj02'
    $env['ProjectNameForNewJsonFile'] = 'pstest-newproj03'
    $env['ProjectNameForNewViaPar'] = 'pstest-newproj04'
    $env['ChatModelDeploymentNameForNew'] = 'pstest-newchat01'
    $env['ChatModelDeploymentNameForNewJson'] = 'pstest-newchat02'
    $env['ChatModelDeploymentNameForNewJsonFile'] = 'pstest-newchat03'
    $env['ChatModelDeploymentNameForNewViaPar'] = 'pstest-newchat04'
    $env['StorageAssetNameForNew'] = 'pstest-newsa01'
    $env['StorageAssetNameForNewJson'] = 'pstest-newsa02'
    $env['StorageAssetNameForNewJsonFile'] = 'pstest-newsa03'
    $env['StorageAssetNameForNewViaPar'] = 'pstest-newsa04'

    # ======================================================================
    # Resource names for Remove-* tests (pre-created in setupEnv)
    # ======================================================================
    # Delete parameter set
    $env['ToolNameForDel'] = 'pstest-deltool01'
    $env['ToolNameForDelViaId'] = 'pstest-deltool02'
    $env['StorageContainerNameForDel'] = 'pstestdelscon01'
    $env['StorageContainerNameForDelViaId'] = 'pstestdelscon02'
    $env['StorageAssetNameForDel'] = 'pstest-delsa01'
    $env['StorageAssetNameForDelViaId'] = 'pstest-delsa02'
    $env['StorageAssetNameForDelViaPar'] = 'pstest-delsa03'
    $env['ProjectNameForDel'] = 'pstest-delproj01'
    $env['ProjectNameForDelViaId'] = 'pstest-delproj02'
    $env['ProjectNameForDelViaPar'] = 'pstest-delproj03'
    $env['ChatModelDeploymentNameForDel'] = 'pstest-delchat01'
    $env['ChatModelDeploymentNameForDelVia'] = 'pstest-delchat02'
    $env['ChatModelDeploymentNameForDelViaPar'] = 'pstest-delchat03'
    $env['NodePoolNameForDel'] = 'psnpdel01'
    $env['NodePoolNameForDelVia'] = 'psnpdel02'
    $env['NodePoolNameForDelViaPar'] = 'psnpdel03'
    # Top-level DeleteViaIdentity
    $env['SupercomputerNameForDel'] = 'pstest-delsc01'
    $env['SupercomputerNameForDelVia'] = 'pstest-delsc02'
    $env['BookshelfNameForDel'] = 'pstest-delbs01'
    $env['BookshelfNameForDelVia'] = 'pstest-delbs02'
    $env['WorkspaceNameForDel'] = 'pstest-delws01'
    $env['WorkspaceNameForDelVia'] = 'pstest-delws02'

    # ======================================================================
    # Subnet configuration (same-sub VNet: 10.0.0.0/16, high addresses to avoid conflicts)
    # ======================================================================
    $env['ScSubnetName'] = 'pstest-sc-subnet'
    $env['ScSubnetPrefix'] = '10.0.230.0/24'
    $env['ScMgmtSubnetName'] = 'pstest-sc-mgmt-subnet'
    $env['ScMgmtSubnetPrefix'] = '10.0.231.0/24'
    $env['NodePoolSubnetName'] = 'pstest-np-subnet'
    $env['NodePoolSubnetPrefix'] = '10.0.232.0/24'
    $env['BsPepSubnetName'] = 'pstest-bs-pep-subnet'
    $env['BsPepSubnetPrefix'] = '10.0.233.0/27'
    $env['BsSearchSubnetName'] = 'pstest-bs-search-subnet'
    $env['BsSearchSubnetPrefix'] = '10.0.233.32/27'
    $env['NewBsPepSubnetName'] = 'pstest-newbs-pep-subnet'
    $env['NewBsPepSubnetPrefix'] = '10.0.239.0/27'
    $env['NewBsSearchSubnetName'] = 'pstest-newbs-search-subnet'
    $env['NewBsSearchSubnetPrefix'] = '10.0.239.32/27'
    $env['WsAgentSubnetName'] = 'pstest-ws-agent-subnet'
    $env['WsAgentSubnetPrefix'] = '10.0.234.0/24'
    $env['WsSubnetName'] = 'pstest-ws-subnet'
    $env['WsSubnetPrefix'] = '10.0.235.0/27'
    $env['WsPepSubnetName'] = 'pstest-ws-pep-subnet'
    $env['WsPepSubnetPrefix'] = '10.0.235.32/27'
    $env['PeSubnetName'] = 'pstest-pe-subnet'
    $env['PeSubnetPrefix'] = '10.0.235.64/27'

    # ======================================================================
    # Private endpoint names
    # ======================================================================
    $env['WorkspacePrivateEndpointNameForGet'] = 'pstest-ws-pe01'
    $env['WorkspacePrivateEndpointNameForDel'] = 'pstest-ws-pe02'
    $env['WorkspacePrivateEndpointNameForDelVia'] = 'pstest-ws-pe03'
    $env['WorkspacePrivateEndpointNameForDelViaPar'] = 'pstest-ws-pe04'
    $env['BookshelfPrivateEndpointNameForGet'] = 'pstest-bs-pe01'
    $env['BookshelfPrivateEndpointNameForDel'] = 'pstest-bs-pe02'
    $env['BookshelfPrivateEndpointNameForDelVia'] = 'pstest-bs-pe03'
    $env['BookshelfPrivateEndpointNameForDelViaPar'] = 'pstest-bs-pe04'

    # ======================================================================
    # JSON bodies and hashtable definitions
    # ======================================================================
    $env['ToolCreateJson'] = '{"location":"uksouth","properties":{"version":"1.0.0","definitionContent":{"name":"pstest-tool","description":"PowerShell test tool","version":"1.0.0","category":"general","infra":[{"name":"worker","infra_type":"container","image":{"acr":"mcr.microsoft.com/azureml/minimal-ubuntu22.04-py39-cpu-inference:latest"},"compute":{"min_resources":{"cpu":"1","ram":"2Gi","gpu":"0","storage":"0"},"max_resources":{"cpu":"2","ram":"4Gi","storage":"0"},"recommended_sku":["Standard_D4s_v6"],"pool_type":"static","pool_size":1}}],"code_environments":[{"language":"python","command":"echo hello","description":"Test env","infra_node":"worker"}]}}}'
    $env['ToolDefinitionHashtable'] = @{
        name = 'pstest-tool'
        description = 'PowerShell test tool'
        version = '1.0.0'
        category = 'general'
        infra = @(@{
            name = 'worker'
            infra_type = 'container'
            image = @{ acr = 'mcr.microsoft.com/azureml/minimal-ubuntu22.04-py39-cpu-inference:latest' }
            compute = @{
                min_resources = @{ cpu = '1'; ram = '2Gi'; gpu = '0'; storage = '0' }
                max_resources = @{ cpu = '2'; ram = '4Gi'; storage = '0' }
                recommended_sku = @('Standard_D4s_v6')
                pool_type = 'static'
                pool_size = 1
            }
        })
        code_environments = @(@{
            language = 'python'
            command = 'echo hello'
            description = 'Test env'
            infra_node = 'worker'
        })
    }
    $env['StorageContainerCreateJson'] = '{"location":"uksouth","properties":{"storageStore":{"kind":"AzureStorageBlob","storageAccountId":"' + $env.StorageAccountId + '"}}}'

    # ======================================================================
    # Infrastructure setup: subnets in same-sub VNet
    # ======================================================================
    Write-Host -ForegroundColor Magenta "Setting up subnets..."
    $vnet = Get-AzVirtualNetwork -ResourceGroupName $env.InfraResourceGroupName -Name $env.VNetName
    $appEnvDelegation = New-AzDelegation -Name 'appEnvDelegation' -ServiceName 'Microsoft.App/environments'
    $storageEndpoint = New-AzVirtualNetworkSubnetConfig -Name '_tmp_' -AddressPrefix '10.255.255.0/24' -ServiceEndpoint 'Microsoft.Storage.Global' -WarningAction SilentlyContinue
    $storageServiceEndpoints = $storageEndpoint.ServiceEndpoints

    $subnetDefinitions = @(
        @{ Name = $env.ScSubnetName; Prefix = $env.ScSubnetPrefix; Delegation = $null; ServiceEndpoint = $null; PePolicy = $null }
        @{ Name = $env.ScMgmtSubnetName; Prefix = $env.ScMgmtSubnetPrefix; Delegation = $null; ServiceEndpoint = $null; PePolicy = $null }
        @{ Name = $env.NodePoolSubnetName; Prefix = $env.NodePoolSubnetPrefix; Delegation = $null; ServiceEndpoint = $null; PePolicy = $null }
        @{ Name = $env.BsPepSubnetName; Prefix = $env.BsPepSubnetPrefix; Delegation = $null; ServiceEndpoint = 'Microsoft.Storage.Global'; PePolicy = 'Disabled' }
        @{ Name = $env.BsSearchSubnetName; Prefix = $env.BsSearchSubnetPrefix; Delegation = $appEnvDelegation; ServiceEndpoint = 'Microsoft.Storage.Global'; PePolicy = $null }
        @{ Name = $env.NewBsPepSubnetName; Prefix = $env.NewBsPepSubnetPrefix; Delegation = $null; ServiceEndpoint = 'Microsoft.Storage.Global'; PePolicy = 'Disabled' }
        @{ Name = $env.NewBsSearchSubnetName; Prefix = $env.NewBsSearchSubnetPrefix; Delegation = $appEnvDelegation; ServiceEndpoint = 'Microsoft.Storage.Global'; PePolicy = $null }
        @{ Name = $env.WsAgentSubnetName; Prefix = $env.WsAgentSubnetPrefix; Delegation = $appEnvDelegation; ServiceEndpoint = 'Microsoft.Storage.Global'; PePolicy = $null }
        @{ Name = $env.WsSubnetName; Prefix = $env.WsSubnetPrefix; Delegation = $appEnvDelegation; ServiceEndpoint = 'Microsoft.Storage.Global'; PePolicy = $null }
        @{ Name = $env.WsPepSubnetName; Prefix = $env.WsPepSubnetPrefix; Delegation = $null; ServiceEndpoint = 'Microsoft.Storage.Global'; PePolicy = 'Disabled' }
        @{ Name = $env.PeSubnetName; Prefix = $env.PeSubnetPrefix; Delegation = $null; ServiceEndpoint = $null; PePolicy = 'Disabled' }
    )

    $vnetUpdated = $false
    foreach ($sd in $subnetDefinitions) {
        if (-not ($vnet.Subnets | Where-Object { $_.Name -eq $sd.Name })) {
            Write-Host "Creating subnet $($sd.Name) ($($sd.Prefix))..."
            $subnetParams = @{
                Name = $sd.Name
                VirtualNetwork = $vnet
                AddressPrefix = $sd.Prefix
            }
            if ($null -ne $sd.Delegation) { $subnetParams['Delegation'] = $sd.Delegation }
            if ($null -ne $sd.ServiceEndpoint) { $subnetParams['ServiceEndpoint'] = $sd.ServiceEndpoint }
            if ($null -ne $sd.PePolicy) { $subnetParams['PrivateEndpointNetworkPoliciesFlag'] = $sd.PePolicy }
            Add-AzVirtualNetworkSubnetConfig @subnetParams | Out-Null
            $vnetUpdated = $true
        }
    }
    if ($vnetUpdated) {
        $vnet | Set-AzVirtualNetwork | Out-Null
        $vnet = Get-AzVirtualNetwork -ResourceGroupName $env.InfraResourceGroupName -Name $env.VNetName
    }

    # Retrieve subnet IDs
    $env['ScSubnetId'] = (Get-AzVirtualNetworkSubnetConfig -Name $env.ScSubnetName -VirtualNetwork $vnet).Id
    $env['ScMgmtSubnetId'] = (Get-AzVirtualNetworkSubnetConfig -Name $env.ScMgmtSubnetName -VirtualNetwork $vnet).Id
    $env['NodePoolSubnetId'] = (Get-AzVirtualNetworkSubnetConfig -Name $env.NodePoolSubnetName -VirtualNetwork $vnet).Id
    $env['BsPepSubnetId'] = (Get-AzVirtualNetworkSubnetConfig -Name $env.BsPepSubnetName -VirtualNetwork $vnet).Id
    $env['BsSearchSubnetId'] = (Get-AzVirtualNetworkSubnetConfig -Name $env.BsSearchSubnetName -VirtualNetwork $vnet).Id
    $env['NewBsPepSubnetId'] = (Get-AzVirtualNetworkSubnetConfig -Name $env.NewBsPepSubnetName -VirtualNetwork $vnet).Id
    $env['NewBsSearchSubnetId'] = (Get-AzVirtualNetworkSubnetConfig -Name $env.NewBsSearchSubnetName -VirtualNetwork $vnet).Id
    $env['WsAgentSubnetId'] = (Get-AzVirtualNetworkSubnetConfig -Name $env.WsAgentSubnetName -VirtualNetwork $vnet).Id
    $env['WsSubnetId'] = (Get-AzVirtualNetworkSubnetConfig -Name $env.WsSubnetName -VirtualNetwork $vnet).Id
    $env['WsPepSubnetId'] = (Get-AzVirtualNetworkSubnetConfig -Name $env.WsPepSubnetName -VirtualNetwork $vnet).Id
    $env['PeSubnetId'] = (Get-AzVirtualNetworkSubnetConfig -Name $env.PeSubnetName -VirtualNetwork $vnet).Id
    $peSubnet = Get-AzVirtualNetworkSubnetConfig -Name $env.PeSubnetName -VirtualNetwork $vnet
    # WS2 subnet IDs (for New-Workspace test using SC2)
    $env['Ws2AgentSubnetId'] = (Get-AzVirtualNetworkSubnetConfig -Name $env.Ws2AgentSubnetName -VirtualNetwork $vnet).Id
    $env['Ws2SubnetId'] = (Get-AzVirtualNetworkSubnetConfig -Name $env.Ws2SubnetName -VirtualNetwork $vnet).Id
    $env['Ws2PepSubnetId'] = (Get-AzVirtualNetworkSubnetConfig -Name $env.Ws2PepSubnetName -VirtualNetwork $vnet).Id

    # Add workspace subnets to storage account network rules (required before workspace create)
    Write-Host "Adding workspace subnets to storage account network rules..."
    foreach ($wsSubnetId in @($env.WsAgentSubnetId, $env.WsSubnetId, $env.WsPepSubnetId)) {
        try {
            Add-AzStorageAccountNetworkRule -ResourceGroupName $env.InfraResourceGroupName `
                -AccountName $env.StorageAccountName -VirtualNetworkResourceId $wsSubnetId `
                -ErrorAction SilentlyContinue | Out-Null
        } catch { }
    }


    # ======================================================================
    # Create resources for Get/Update tests
    # ======================================================================
    Write-Host -ForegroundColor Magenta "Creating resources for Get/Update tests..."

    # --- Phase 1 resources (Tool, StorageContainer, StorageAsset) ---
    Write-Host "Creating StorageContainer $($env.StorageContainerNameForGet)..."
    New-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName `
        -Name $env.StorageContainerNameForGet -SubscriptionId $env.SubscriptionId `
        -JsonString $env.StorageContainerCreateJson -Confirm:$false | Out-Null
    Wait-TestDiscoveryResource -GetScript {
        Get-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $env.StorageContainerNameForGet -SubscriptionId $env.SubscriptionId
    } -ResourceDescription $env.StorageContainerNameForGet -TimeoutMinutes 30 | Out-Null

    Write-Host "Creating StorageAsset $($env.StorageAssetNameForGet)..."
    New-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName `
        -StorageContainerName $env.StorageContainerNameForGet `
        -Name $env.StorageAssetNameForGet -SubscriptionId $env.SubscriptionId `
        -JsonString '{"location":"uksouth","properties":{"description":"PS test storage asset","path":"testdata"}}' -Confirm:$false | Out-Null
    Wait-TestDiscoveryResource -GetScript {
        Get-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName -StorageContainerName $env.StorageContainerNameForGet -Name $env.StorageAssetNameForGet -SubscriptionId $env.SubscriptionId
    } -ResourceDescription $env.StorageAssetNameForGet -TimeoutMinutes 30 | Out-Null

    Write-Host "Creating Tool $($env.ToolNameForGet)..."
    New-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName `
        -Name $env.ToolNameForGet -SubscriptionId $env.SubscriptionId `
        -JsonString $env.ToolCreateJson -Confirm:$false | Out-Null
    Wait-TestDiscoveryResource -GetScript {
        Get-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName -Name $env.ToolNameForGet -SubscriptionId $env.SubscriptionId
    } -ResourceDescription $env.ToolNameForGet -TimeoutMinutes 30 | Out-Null

    # --- SC, WS, NP, ChatModel, Project resources ---
    # Supercomputer for Get/Update
    $existingSc = Get-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName -Name $env.SupercomputerNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction SilentlyContinue
    if (-not $existingSc -or $existingSc.ProvisioningState -ne 'Succeeded') {
        Write-Host "Creating Supercomputer $($env.SupercomputerNameForGet)..."
        New-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName `
            -Name $env.SupercomputerNameForGet -Location $env.location `
            -SubnetId $env.ScSubnetId `
            -ClusterIdentityId $env.UamiId -KubeletIdentityId $env.UamiId `
            -IdentityWorkloadIdentity @{$env.UamiId = @{}} `
            -OutboundType 'LoadBalancer' -SystemSku 'Standard_D4s_v6' `
            -Tag @{'test' = 'powershell'; 'SkipAssociateKeyVaultToNsp' = 'True'} -Confirm:$false | Out-Null
        Wait-TestDiscoveryResource -GetScript {
            Get-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName -Name $env.SupercomputerNameForGet -SubscriptionId $env.SubscriptionId
        } -ResourceDescription $env.SupercomputerNameForGet -TimeoutMinutes 60 | Out-Null
    } else { Write-Host "Supercomputer $($env.SupercomputerNameForGet) already exists, skipping." }

    # Workspace for Get/Update
    $existingWs = Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -Name $env.WorkspaceNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction SilentlyContinue
    if (-not $existingWs -or $existingWs.ProvisioningState -ne 'Succeeded') {
        Write-Host "Creating Workspace $($env.WorkspaceNameForGet)..."
        New-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName `
            -Name $env.WorkspaceNameForGet -Location $env.location `
            -SupercomputerId @($env.SupercomputerIdForGet) `
            -WorkspaceIdentityId $env.UamiId `
            -WorkspaceSubnetId $env.WsSubnetId `
            -AgentSubnetId $env.WsAgentSubnetId `
            -PrivateEndpointSubnetId $env.WsPepSubnetId `
            -Tag @{'test' = 'powershell'; 'SkipAssociateKeyVaultToNsp' = 'True'; 'networkIsolation' = 'true'} -Confirm:$false | Out-Null
        Wait-TestDiscoveryResource -GetScript {
            Get-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -Name $env.WorkspaceNameForGet -SubscriptionId $env.SubscriptionId
        } -ResourceDescription $env.WorkspaceNameForGet -TimeoutMinutes 60 | Out-Null
    } else { Write-Host "Workspace $($env.WorkspaceNameForGet) already exists, skipping." }

    # NodePool for Get/Update
    $existingNp = Get-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName -SupercomputerName $env.SupercomputerNameForGet -Name $env.NodePoolNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction SilentlyContinue
    if (-not $existingNp -or $existingNp.ProvisioningState -ne 'Succeeded') {
        Write-Host "Creating NodePool $($env.NodePoolNameForGet)..."
        New-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName `
            -SupercomputerName $env.SupercomputerNameForGet `
            -Name $env.NodePoolNameForGet -SubscriptionId $env.SubscriptionId `
            -Location $env.location `
            -SubnetId $env.NodePoolSubnetId `
            -VMSize 'Standard_D4s_v6' -MinNodeCount 0 -MaxNodeCount 1 `
            -OSDiskSizeGb 128 -ScaleSetPriority 'Regular' `
            -Confirm:$false | Out-Null
        Wait-TestDiscoveryResource -GetScript {
            Get-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName -SupercomputerName $env.SupercomputerNameForGet -Name $env.NodePoolNameForGet -SubscriptionId $env.SubscriptionId
        } -ResourceDescription $env.NodePoolNameForGet -TimeoutMinutes 60 | Out-Null
    } else { Write-Host "NodePool $($env.NodePoolNameForGet) already exists, skipping." }

    # ChatModelDeployment for Get/Update
    $existingChat = Get-AzDiscoveryChatModelDeployment -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.WorkspaceNameForGet -Name $env.ChatModelDeploymentNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction SilentlyContinue
    if (-not $existingChat -or $existingChat.ProvisioningState -ne 'Succeeded') {
        Write-Host "Creating ChatModelDeployment $($env.ChatModelDeploymentNameForGet)..."
        New-AzDiscoveryChatModelDeployment -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -Name $env.ChatModelDeploymentNameForGet -SubscriptionId $env.SubscriptionId `
            -Location $env.location `
            -ModelName 'gpt-4o' -ModelFormat 'OpenAI' `
            -SkuName 'GlobalStandard' -Capacity 1 `
            -Confirm:$false | Out-Null
        Wait-TestDiscoveryResource -GetScript {
            Get-AzDiscoveryChatModelDeployment -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.WorkspaceNameForGet -Name $env.ChatModelDeploymentNameForGet -SubscriptionId $env.SubscriptionId
        } -ResourceDescription $env.ChatModelDeploymentNameForGet -TimeoutMinutes 45 | Out-Null
    } else { Write-Host "ChatModelDeployment $($env.ChatModelDeploymentNameForGet) already exists, skipping." }

    # Project for Get/Update
    $existingProj = Get-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.WorkspaceNameForGet -Name $env.ProjectNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction SilentlyContinue
    if (-not $existingProj -or $existingProj.ProvisioningState -ne 'Succeeded') {
        Write-Host "Creating Project $($env.ProjectNameForGet)..."
        New-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet `
            -Name $env.ProjectNameForGet -SubscriptionId $env.SubscriptionId `
            -Location $env.location `
            -StorageContainerId @($existingContainerId) `
            -Confirm:$false | Out-Null
        Wait-TestDiscoveryResource -GetScript {
            Get-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.WorkspaceNameForGet -Name $env.ProjectNameForGet -SubscriptionId $env.SubscriptionId
        } -ResourceDescription $env.ProjectNameForGet -TimeoutMinutes 45 | Out-Null
    } else { Write-Host "Project $($env.ProjectNameForGet) already exists, skipping." }
    # --- Bookshelf for Get/Update ---
    $existingBs = Get-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName -Name $env.BookshelfNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction SilentlyContinue
    if (-not $existingBs -or $existingBs.ProvisioningState -ne 'Succeeded') {
        Write-Host "Creating Bookshelf $($env.BookshelfNameForGet)..."
        New-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName `
            -Name $env.BookshelfNameForGet -Location $env.location `
            -PrivateEndpointSubnetId $env.BsPepSubnetId `
            -SearchSubnetId $env.BsSearchSubnetId `
            -WorkloadIdentity @{$env.UamiId = @{}} `
            -Tag @{'test' = 'powershell'; 'SkipAssociateKeyVaultToNsp' = 'True'} -Confirm:$false | Out-Null
        Wait-TestDiscoveryResource -GetScript {
            Get-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName -Name $env.BookshelfNameForGet -SubscriptionId $env.SubscriptionId
        } -ResourceDescription $env.BookshelfNameForGet -TimeoutMinutes 45 | Out-Null
    } else { Write-Host "Bookshelf $($env.BookshelfNameForGet) already exists, skipping." }

    # ======================================================================
    # Create resources for Remove-* Delete tests
    # ======================================================================
    Write-Host -ForegroundColor Magenta "Creating resources for Remove tests..."

    # --- Tools (quick) ---
    foreach ($toolName in @($env.ToolNameForDel, $env.ToolNameForDelViaId)) {
        Write-Host "Creating Tool $toolName..."
        New-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName `
            -Name $toolName -SubscriptionId $env.SubscriptionId `
            -JsonString $env.ToolCreateJson -Confirm:$false | Out-Null
        Wait-TestDiscoveryResource -GetScript {
            Get-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName -Name $toolName -SubscriptionId $env.SubscriptionId
        } -ResourceDescription $toolName -TimeoutMinutes 30 | Out-Null
    }

    # --- StorageContainers ---
    foreach ($sconName in @($env.StorageContainerNameForDel, $env.StorageContainerNameForDelViaId)) {
        Write-Host "Creating StorageContainer $sconName..."
        New-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName `
            -Name $sconName -SubscriptionId $env.SubscriptionId `
            -JsonString $env.StorageContainerCreateJson -Confirm:$false | Out-Null
        Wait-TestDiscoveryResource -GetScript {
            Get-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $sconName -SubscriptionId $env.SubscriptionId
        } -ResourceDescription $sconName -TimeoutMinutes 30 | Out-Null
    }

    # --- StorageAssets (Delete, DeleteViaIdentity, DeleteViaIdentityParent) ---
    foreach ($saName in @($env.StorageAssetNameForDel, $env.StorageAssetNameForDelViaId, $env.StorageAssetNameForDelViaPar)) {
        Write-Host "Creating StorageAsset $saName..."
        New-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName `
            -StorageContainerName $env.StorageContainerNameForGet `
            -Name $saName -SubscriptionId $env.SubscriptionId `
            -JsonString '{"location":"uksouth","properties":{"description":"PS test storage asset for delete","path":"testdata"}}' -Confirm:$false | Out-Null
        Wait-TestDiscoveryResource -GetScript {
            Get-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName -StorageContainerName $env.StorageContainerNameForGet -Name $saName -SubscriptionId $env.SubscriptionId
        } -ResourceDescription $saName -TimeoutMinutes 30 | Out-Null
    }

    # --- Phase 2+ Remove resources ---
    # NOTE: Expensive resources (SC, WS, BS, NP, ChatModel, Project) for Remove tests
    # are created by the New-* test files (which run alphabetically before Remove-*).
    # No duplicate creation needed here — Remove tests target New-created resources.

    # ======================================================================
    # Create private endpoints for PEC tests
    # ======================================================================
    Write-Host -ForegroundColor Magenta "Creating private endpoints for PEC tests..."

    # Workspace PEs: ForGet, ForDel, ForDelVia, ForDelViaPar
    $wsPeNames = @(
        @{ PeName = $env.WorkspacePrivateEndpointNameForGet; PlsName = 'pstest-pls-ws-get'; EnvKey = 'WorkspacePrivateEndpointConnectionNameForGet' }
        @{ PeName = $env.WorkspacePrivateEndpointNameForDel; PlsName = 'pstest-pls-ws-del'; EnvKey = 'WorkspacePrivateEndpointConnectionNameForDel' }
        @{ PeName = $env.WorkspacePrivateEndpointNameForDelVia; PlsName = 'pstest-pls-ws-delvia'; EnvKey = 'WorkspacePrivateEndpointConnectionNameForDelVia' }
        @{ PeName = $env.WorkspacePrivateEndpointNameForDelViaPar; PlsName = 'pstest-pls-ws-delviapar'; EnvKey = 'WorkspacePrivateEndpointConnectionNameForDelViaPar' }
    )
    foreach ($pe in $wsPeNames) {
        $existingPe = Get-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroupName -Name $pe.PeName -ErrorAction SilentlyContinue
        if ($existingPe) {
            Write-Host "PE $($pe.PeName) already exists, resolving connection name..."
            $conns = Get-AzDiscoveryWorkspacePrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.WorkspaceNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction SilentlyContinue
            $matchConn = $conns | Where-Object { $_.PrivateEndpointId -like "*/$($pe.PeName)" }
            if ($matchConn) { $env[$pe.EnvKey] = $matchConn.Name; Write-Host "  Resolved: $($matchConn.Name)" }
            else { Write-Host "  WARNING: Could not resolve connection name for $($pe.PeName)" }
        } else {
            $existingWsConnNames = @((Get-AzDiscoveryWorkspacePrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.WorkspaceNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction SilentlyContinue | ForEach-Object Name))
            $plsConn = New-AzPrivateLinkServiceConnection -Name $pe.PlsName `
                -PrivateLinkServiceId $env.WorkspaceIdForGet -GroupId $env.WorkspacePrivateLinkResourceName
            Write-Host "Creating PE $($pe.PeName) for workspace..."
            New-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroupName `
                -Name $pe.PeName -Location $env.location `
                -Subnet $peSubnet -PrivateLinkServiceConnection $plsConn -Force | Out-Null
            $env[$pe.EnvKey] = Wait-TestPrivateEndpointConnectionName -ListScript {
                Get-AzDiscoveryWorkspacePrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName -WorkspaceName $env.WorkspaceNameForGet -SubscriptionId $env.SubscriptionId
            } -ExistingNames $existingWsConnNames -ResourceDescription $pe.PeName
        }
    }

    # Bookshelf PEs: ForGet, ForDel, ForDelVia, ForDelViaPar
    $bsPeNames = @(
        @{ PeName = $env.BookshelfPrivateEndpointNameForGet; PlsName = 'pstest-pls-bs-get'; EnvKey = 'BookshelfPrivateEndpointConnectionNameForGet' }
        @{ PeName = $env.BookshelfPrivateEndpointNameForDel; PlsName = 'pstest-pls-bs-del'; EnvKey = 'BookshelfPrivateEndpointConnectionNameForDel' }
        @{ PeName = $env.BookshelfPrivateEndpointNameForDelVia; PlsName = 'pstest-pls-bs-delvia'; EnvKey = 'BookshelfPrivateEndpointConnectionNameForDelVia' }
        @{ PeName = $env.BookshelfPrivateEndpointNameForDelViaPar; PlsName = 'pstest-pls-bs-delviapar'; EnvKey = 'BookshelfPrivateEndpointConnectionNameForDelViaPar' }
    )
    foreach ($pe in $bsPeNames) {
        $existingPe = Get-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroupName -Name $pe.PeName -ErrorAction SilentlyContinue
        if ($existingPe) {
            Write-Host "PE $($pe.PeName) already exists, resolving connection name..."
            $conns = Get-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName -BookshelfName $env.BookshelfNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction SilentlyContinue
            $matchConn = $conns | Where-Object { $_.PrivateEndpointId -like "*/$($pe.PeName)" }
            if ($matchConn) { $env[$pe.EnvKey] = $matchConn.Name; Write-Host "  Resolved: $($matchConn.Name)" }
            else { Write-Host "  WARNING: Could not resolve connection name for $($pe.PeName)" }
        } else {
            $existingBsConnNames = @((Get-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName -BookshelfName $env.BookshelfNameForGet -SubscriptionId $env.SubscriptionId -ErrorAction SilentlyContinue | ForEach-Object Name))
            $plsConn = New-AzPrivateLinkServiceConnection -Name $pe.PlsName `
                -PrivateLinkServiceId $env.BookshelfIdForGet -GroupId $env.BookshelfPrivateLinkResourceName
            Write-Host "Creating PE $($pe.PeName) for bookshelf..."
            New-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroupName `
                -Name $pe.PeName -Location $env.location `
                -Subnet $peSubnet -PrivateLinkServiceConnection $plsConn -Force | Out-Null
            $env[$pe.EnvKey] = Wait-TestPrivateEndpointConnectionName -ListScript {
                Get-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName -BookshelfName $env.BookshelfNameForGet -SubscriptionId $env.SubscriptionId
            } -ExistingNames $existingBsConnNames -ResourceDescription $pe.PeName
        }
    }

    Write-Host -ForegroundColor Magenta "Finished creating all resources"

    # ======================================================================
    # Write environment file
    # ======================================================================
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    Write-Host -ForegroundColor Magenta "Writing environment file $envFile with $($env.Count) entries"
    Set-Content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env -Depth 100)
}
function cleanupEnv() {
    # Prevent cleanup failures from masking test errors
    $ErrorActionPreference = 'Continue'
    Write-Host -ForegroundColor Magenta "Cleaning up test environment"

    # --- PECs and PEs cleanup ---
    foreach ($pecName in @(
        $env.WorkspacePrivateEndpointConnectionNameForGet,
        $env.WorkspacePrivateEndpointConnectionNameForDel,
        $env.WorkspacePrivateEndpointConnectionNameForDelVia,
        $env.WorkspacePrivateEndpointConnectionNameForDelViaPar
    )) {
        if ($pecName) {
            Remove-AzDiscoveryWorkspacePrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
                -WorkspaceName $env.WorkspaceNameForGet -PrivateEndpointConnectionName $pecName `
                -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
        }
    }
    foreach ($pecName in @(
        $env.BookshelfPrivateEndpointConnectionNameForGet,
        $env.BookshelfPrivateEndpointConnectionNameForDel,
        $env.BookshelfPrivateEndpointConnectionNameForDelVia,
        $env.BookshelfPrivateEndpointConnectionNameForDelViaPar
    )) {
        if ($pecName) {
            Remove-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName $env.ResourceGroupName `
                -BookshelfName $env.BookshelfNameForGet -PrivateEndpointConnectionName $pecName `
                -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
        }
    }
    foreach ($peName in @(
        $env.WorkspacePrivateEndpointNameForGet, $env.WorkspacePrivateEndpointNameForDel,
        $env.WorkspacePrivateEndpointNameForDelVia, $env.WorkspacePrivateEndpointNameForDelViaPar,
        $env.BookshelfPrivateEndpointNameForGet, $env.BookshelfPrivateEndpointNameForDel,
        $env.BookshelfPrivateEndpointNameForDelVia, $env.BookshelfPrivateEndpointNameForDelViaPar
    )) {
        if ($peName) {
            Remove-AzPrivateEndpoint -ResourceGroupName $env.ResourceGroupName -Name $peName `
                -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
        }
    }

    # --- Remove Tool and StorageAsset child resources from New-* tests ---
    foreach ($toolName in @($env.ToolNameForNew, $env.ToolNameForNewExpanded, $env.ToolNameForNewJsonFile)) {
        if ($toolName) {
            Remove-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName -Name $toolName `
                -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
        }
    }
    foreach ($saName in @($env.StorageAssetNameForNew, $env.StorageAssetNameForNewJson, $env.StorageAssetNameForNewJsonFile, $env.StorageAssetNameForNewViaPar)) {
        if ($saName) {
            Remove-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName `
                -StorageContainerName $env.StorageContainerNameForGet -Name $saName `
                -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
        }
    }

    # --- Cleanup: child resources from New-* tests ---
    foreach ($projName in @($env.ProjectNameForNew, $env.ProjectNameForNewJson, $env.ProjectNameForNewJsonFile, $env.ProjectNameForNewViaPar)) {
        Remove-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet -Name $projName `
            -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
    }
    foreach ($chatName in @($env.ChatModelDeploymentNameForNew, $env.ChatModelDeploymentNameForNewJson, $env.ChatModelDeploymentNameForNewJsonFile, $env.ChatModelDeploymentNameForNewViaPar)) {
        Remove-AzDiscoveryChatModelDeployment -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet -Name $chatName `
            -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
    }
    foreach ($npName in @($env.NodePoolNameForNew, $env.NodePoolNameForNewJson, $env.NodePoolNameForNewJsonFile, $env.NodePoolNameForNewViaPar)) {
        Remove-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName `
            -SupercomputerName $env.SupercomputerNameForGet -Name $npName `
            -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
    }

    # --- Phase 1 (always): Remove StorageContainer New-* resources ---
    foreach ($sconName in @($env.StorageContainerNameForNew, $env.StorageContainerNameForNewExpanded, $env.StorageContainerNameForNewJsonFile)) {
        Remove-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $sconName `
            -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
    }

    # --- Phase 1 (always): Remove Del/DelVia leftover resources (Tools, StorageAssets, StorageContainers) ---
    foreach ($toolName in @($env.ToolNameForDel, $env.ToolNameForDelViaId)) {
        Remove-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName -Name $toolName `
            -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
    }
    foreach ($saName in @($env.StorageAssetNameForDel, $env.StorageAssetNameForDelViaId, $env.StorageAssetNameForDelViaPar)) {
        Remove-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName `
            -StorageContainerName $env.StorageContainerNameForGet -Name $saName `
            -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
    }
    foreach ($sconName in @($env.StorageContainerNameForDel, $env.StorageContainerNameForDelViaId)) {
        Remove-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $sconName `
            -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
    }

    # --- Cleanup: leftover New-* child resources (not yet deleted by Remove-* tests) ---
    # New-* tests create these; Remove-* tests delete some. Clean up any remaining.
    foreach ($projName in @($env.ProjectNameForNew, $env.ProjectNameForNewJson, $env.ProjectNameForNewJsonFile, $env.ProjectNameForNewViaPar)) {
        Remove-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet -Name $projName `
            -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
    }
    foreach ($chatName in @($env.ChatModelDeploymentNameForNew, $env.ChatModelDeploymentNameForNewJson, $env.ChatModelDeploymentNameForNewJsonFile, $env.ChatModelDeploymentNameForNewViaPar)) {
        Remove-AzDiscoveryChatModelDeployment -ResourceGroupName $env.ResourceGroupName `
            -WorkspaceName $env.WorkspaceNameForGet -Name $chatName `
            -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
    }
    foreach ($npName in @($env.NodePoolNameForNew, $env.NodePoolNameForNewJson, $env.NodePoolNameForNewJsonFile, $env.NodePoolNameForNewViaPar)) {
        Remove-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName `
            -SupercomputerName $env.SupercomputerNameForGet -Name $npName `
            -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
    }

    # --- Cleanup: top-level New-* resources ---
    foreach ($wsName in @($env.WorkspaceNameForNew, $env.WorkspaceNameForNewJson, $env.WorkspaceNameForNewJsonFile)) {
        Remove-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -Name $wsName `
            -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
    }
    foreach ($scName in @($env.SupercomputerNameForNew, $env.SupercomputerNameForNewJson, $env.SupercomputerNameForNewJsonFile)) {
        Remove-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName -Name $scName `
            -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
    }

    # --- Bookshelf New-* cleanup ---
    foreach ($bsName in @($env.BookshelfNameForNew, $env.BookshelfNameForNewJson, $env.BookshelfNameForNewJsonFile)) {
        try {
            Remove-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName -Name $bsName `
                -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
        } catch { }
    }

    # --- Remove Get/Update resources ---
    Remove-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName -Name $env.ToolNameForGet `
        -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
    Remove-AzDiscoveryStorageAsset -ResourceGroupName $env.ResourceGroupName `
        -StorageContainerName $env.StorageContainerNameForGet -Name $env.StorageAssetNameForGet `
        -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
    Remove-AzDiscoveryStorageContainer -ResourceGroupName $env.ResourceGroupName -Name $env.StorageContainerNameForGet `
        -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null

    # --- Cleanup: Get/Update top-level resources ---
    Remove-AzDiscoveryChatModelDeployment -ResourceGroupName $env.ResourceGroupName `
        -WorkspaceName $env.WorkspaceNameForGet -Name $env.ChatModelDeploymentNameForGet `
        -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
    Remove-AzDiscoveryProject -ResourceGroupName $env.ResourceGroupName `
        -WorkspaceName $env.WorkspaceNameForGet -Name $env.ProjectNameForGet `
        -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
    Remove-AzDiscoveryNodePool -ResourceGroupName $env.ResourceGroupName `
        -SupercomputerName $env.SupercomputerNameForGet -Name $env.NodePoolNameForGet `
        -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
    Remove-AzDiscoveryWorkspace -ResourceGroupName $env.ResourceGroupName -Name $env.WorkspaceNameForGet `
        -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
    Remove-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName -Name $env.SupercomputerNameForGet `
        -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null

    # --- Get/Update Bookshelf cleanup ---
    try {
        Remove-AzDiscoveryBookshelf -ResourceGroupName $env.ResourceGroupName -Name $env.BookshelfNameForGet `
            -SubscriptionId $env.SubscriptionId -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
    } catch { }

    # --- Cleanup: subnets and storage network rules ---
    foreach ($wsSubnetId in @($env.WsAgentSubnetId, $env.WsSubnetId, $env.WsPepSubnetId)) {
        if ($wsSubnetId) {
            try {
                Remove-AzStorageAccountNetworkRule -ResourceGroupName $env.InfraResourceGroupName `
                    -AccountName $env.StorageAccountName -VirtualNetworkResourceId $wsSubnetId `
                    -ErrorAction SilentlyContinue | Out-Null
            } catch { }
        }
    }
    $vnet = Get-AzVirtualNetwork -ResourceGroupName $env.InfraResourceGroupName -Name $env.VNetName -ErrorAction SilentlyContinue
    if ($vnet) {
        foreach ($subnetName in @(
            $env.PeSubnetName,
            $env.WsPepSubnetName,
            $env.WsSubnetName,
            $env.WsAgentSubnetName,
            $env.BsSearchSubnetName,
            $env.BsPepSubnetName,
            $env.NodePoolSubnetName,
            $env.ScMgmtSubnetName,
            $env.ScSubnetName
        )) {
            if ($subnetName) {
                Remove-AzVirtualNetworkSubnetConfig -Name $subnetName -VirtualNetwork $vnet -ErrorAction SilentlyContinue | Out-Null
            }
        }
        try {
            $vnet | Set-AzVirtualNetwork -ErrorAction SilentlyContinue | Out-Null
        } catch { }
    }

    Write-Host -ForegroundColor Magenta "Finished cleaning up test environment"
}
