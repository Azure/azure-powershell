function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    Write-Host -ForegroundColor Yellow "Required Az.OperationalInsights and Az.KeyVault, please check if Az.OperationalInsights and Az.KeyVault installed"

    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.location = 'uksouth'
    # For any resources you created for test, you should add it to $env here.
    $env.sapMonitor01 = 'sapMonitor-' + (RandomString -allChars $false -len 6) + '-test'
    $env.sapMonitor02 = 'sapMonitor-' + (RandomString -allChars $false -len 6) + '-test'
    $env.sapMonitor03 = 'sapMonitor-' + (RandomString -allChars $false -len 6) + '-test'
    $env.sapIns01 = 'sapInstance-' + (RandomString -allChars $false -len 6)
    $env.sapIns02 = 'sapInstance-' + (RandomString -allChars $false -len 6)
    $env.sapIns03 = 'sapInstance-' + (RandomString -allChars $false -len 6)
    $env.sapIns04 = 'sapInstance-' + (RandomString -allChars $false -len 6)
    $env.sapIns05 = 'sapInstance-' + (RandomString -allChars $false -len 6)

    Write-Host -ForegroundColor Green "Create test group..."
    $costResourceGroup = 'costmanagement-rg-' + (RandomString -allChars $false -len 6)
    New-AzResourceGroup -Name $costResourceGroup -Location $env.location
    $null = $env.Add('costResourceGroup', $costResourceGroup)
    Write-Host -ForegroundColor Green 'The test group create completed.'

    Write-Host -ForegroundColor Green "Using donaliu-HN1 resource group.The resource group included HANA VM, Cann't remove."
    $env.resourceGroup = 'donaliu-HN1' # The resource group deployed HANA VM, Because very difficult to deploy a HANA VM.

    Write-Host -ForegroundColor Green 'Deploying operational insights workspace'
    $env.workspacesName01 = 'monitoringworkspace-' + (RandomString -allChars $false -len 6)
    $env.workspacesName02 = 'monitoringworkspace-' + (RandomString -allChars $false -len 6)
    # Cannot deploy template file using the New-AzDeployment, Because the all resource type cannot be exported and are not included in the template.
    $workspace01 = New-AzOperationalInsightsWorkspace -ResourceGroupName $env.costResourceGroup -Name $env.workspacesName01  -Location $env.location -Sku "Standard"
    $workspace02 = New-AzOperationalInsightsWorkspace -ResourceGroupName $env.costResourceGroup -Name $env.workspacesName02 -Location $env.location -Sku "Standard"
    $workspace01Keys = Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName $env.costResourceGroup -Name $env.workspacesName01
    $workspace02Keys = Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName $env.costResourceGroup -Name $env.workspacesName01
    $null = $env.Add('workspaceResourceId01', $workspace01.ResourceId)
    $null = $env.Add('workspaceResourceId02', $workspace02.ResourceId)
    $null = $env.Add('workspace01Key', $workspace01Keys.PrimarySharedKey)
    $null = $env.Add('workspace02Key', $workspace02Keys.PrimarySharedKey)
    $null = $env.Add('workspace01Id', $workspace01.CustomerId)
    $null = $env.Add('workspace02Id', $workspace02Id.CustomerId)
    Write-Host -ForegroundColor Green 'The operational insights workspace deployed successfully'

    Write-Host -ForegroundColor Green 'Deploying key valut...'
    $kvName = 'kv-' + (RandomString -allChars $false -len 6) + '-test'
    $keyValut = New-AzKeyVault -VaultName $kvName -ResourceGroupName $env.costResourceGroup -Location $env.location
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    $hanaDbPasswordSecret = Set-AzKeyVaultSecret -VaultName $kvName -Name 'hanaPassword' -SecretValue (ConvertTo-SecureString "Manager1" -AsPlainText -Force)
    $env.hanaDbPasswordKvResourceId = $keyValut.ResourceId
    $env.hanaDbPasswordSecretId = $hanaDbPasswordSecret.Id 
    Write-Host -ForegroundColor Green 'The key valut deployed successfully'
    
    # Virtual network
    # HANA Vm subnet
    $env.MonitorSubnet = "/subscriptions/c4106f40-4f28-442e-b67f-a24d892bf7ad/resourceGroups/tniek-all/providers/Microsoft.Network/virtualNetworks/vnet-all/subnets/sapmon"
    # hostName and port may need to be changed based on the env when running live/record test
    $hostName = '10.1.2.6'
    $port = 30113
    $null = $env.Add('hostName', $hostName)
    $null = $env.Add('port', $port)
    $null = $env.Add('prometheusUrl', 'http://10.3.1.6:9100/metrics')

    # Create SAP monitor
    Write-Host -ForegroundColor Green 'create SAP monitor for test...'
    New-AzSapMonitor -Name $env.sapMonitor01 -ResourceGroupName $env.resourceGroup -Location $env.location -EnableCustomerAnalytic `
    -MonitorSubnet $env.MonitorSubnet `
    -LogAnalyticsWorkspaceSharedKey $env.workspace01Key `
    -LogAnalyticsWorkspaceId $env.workspace01Id `
    -LogAnalyticsWorkspaceResourceId $env.workspaceResourceId01
    Write-Host -ForegroundColor Green 'The SAP monitor created successfully'

    Write-Host -ForegroundColor Green 'create SAP instance for test...'
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    New-AzSapMonitorProviderInstance -ResourceGroupName $env.resourceGroup -Name $env.sapIns01 -SapMonitorName $env.sapMonitor01 -ProviderType SapHana -HanaHostname $hostName -HanaDatabaseName 'SYSTEMDB' -HanaDatabaseSqlPort $port -HanaDatabaseUsername SYSTEM -HanaDatabasePassword (ConvertTo-SecureString "Manager1" -AsPlainText -Force)
    New-AzSapMonitorProviderInstance -ResourceGroupName $env.resourceGroup -Name $env.sapIns02 -SapMonitorName $env.sapMonitor01 -ProviderType SapHana -HanaHostname $hostName -HanaDatabaseName 'SYSTEMDB' -HanaDatabaseSqlPort $port -HanaDatabaseUsername SYSTEM -HanaDatabasePasswordSecretId $env.hanaDbPasswordSecretId -HanaDatabasePasswordKeyVaultResourceId $env.hanaDbPasswordKvResourceId
    Write-Host -ForegroundColor Green 'The SAP instance created successfully'

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.costResourceGroup
}

