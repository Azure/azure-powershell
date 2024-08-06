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

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }

    $env.region = 'eastus'
    $env.DataGroupName = 'ml-test'
    $env.TestGroupName = 'ml-psh-test'
    $env.mainWorkspace = 'mlworkspace-test1'
    $env.computeWorkspace = 'mlworkspace-test2'
    $env.hubWorkspace = 'mlworkspace-testhub1'
    $env.projWorkspace = 'mlworkspace-testproj1'

    $env.ManualStorageAccount = 'mltestaccount02'
    # $ManualKeyVaultName = 'mltestkey02'

    $uniquename1 = '0722'
    $KeyVaultName1 = "key"+ $uniquename1 +"ml"
    $StorageAccountName1 = 'storageaccount'+ $uniquename1 +'ml'
    $env.StorageAccountName1 = $StorageAccountName1

    $env.insightsName = 'mlinsights'

    $env.onlineEndpoint = 'online-pwsh01'
    $env.onlineDeployment = 'online-pwsh01-blue01'

    $env.batchEndpoint = 'batchenpoint01'
    $env.batchDeployment = 'batchdeploy01'

    $env.batchClusterName = 'batch-cluster'
    $env.computeinstance = 'jiajicompute1'

    $env.codedatastoreName = 'workspaceblobstore'
    $env.datacontainer = 'dataset001-work2'
    $env.datastoreName = 'datastore01'
    $env.componentName = 'component-pwsh01'
    $env.modeldatastore = 'modelstore'
    $env.codename = 'batch-code'
    $env.scorecodename = 'online-code'

    $env.commandJob01 = 'commandjob01'
    $env.commandJob02 = 'commandJob02'
    
    # manual step: 1. Create Data Group, key vault and storage account
    #   $Key1 = New-AzKeyVault -Name mltestkey2 -ResourceGroupName ml-test -Location eastus
    # Write-Host 'Get key vault' $ManualKeyVaultName 'in' $env.DataGroupName
    #   $key1 = (Get-AzKeyVault -Name mltestkey2 -ResourceGroupName ml-test).ResourceId       
    
    #   $StorageAccount = New-AzStorageAccount -SkuName "Standard_LRS" -Kind StorageV2 -ResourceGroupName ml-test -Name mltestaccount02 -Location eastus
    #   $sa1 = (Get-AzStorageAccount -Name mltestaccount02 -ResourceGroupName ml-test).Id
    #   $insight = (Get-AzApplicationInsights -Name mlinsight002 -ResourceGroupName ml-test).Id
    Write-Host 'Get test storage account' $env.ManualStorageAccount 'in' $env.DataGroupName
    $storageAccount2 = Get-AzStorageAccount -Name $env.ManualStorageAccount -ResourceGroupName $env.DataGroupName
    # manual step: 2. Create a workspace in data group
    # New-AzMLWorkspace -ResourceGroupName ml-test -Name mlworkspace-test2 -Location eastus -Kind 'Default' -StorageAccountId $sa1 -KeyVaultId $key1 -ApplicationInsightId $insight -IdentityType 'SystemAssigned'

    # manual step: 3. Workspace Storage Container Name, use to store model file
    $env.storageContainer = 'azureml-blobstore-8fb755b9-c4c8-490a-a83d-a4df8f862d9e'
    $env.onlinestorageContainer = 'azureml-blobstore-8fb755b9-c4c8-490a-a83d-a4df8f862d9e' #Online can be the same with batch storage
    $env.codestore = 'heart-classifier-mlflow'
    $env.OnlineStore = 'Online'
    # manual step: 4. Clone azureml example, Upload model and score script batch_driver.py to workspace blob store storage container and select 'Upload to folder' option, folder name 'heart-classifier-mlflow'
    # It will create data store for model creation. The code is under folder 'ScriptCodeExample'.
    # manual step: 5. Create a environment named "openmpi4_1_0-ubuntu22_04" with conda file which under ScriptCodeExample/online folder

    # Step 1: Create test group
    Write-Host 'Start to create test resource group' $env.TestGroupName
    try {
        $null = Get-AzResourceGroup -Name $env.TestGroupName -ErrorAction Stop
        Write-Host 'Get created group, go ahead'
    } catch {
        New-AzResourceGroup -Name $env.TestGroupName -Location $env.region
    }

    # Step 2: Create key vault, storage account and so on

    Write-Host 'Start to create storage account' $StorageAccountName1 'in' $env.DataGroupName
    try {
        $storageAccount1 = Get-AzStorageAccount -Name $StorageAccountName1 -ResourceGroupName $env.DataGroupName -ErrorAction Stop
        Write-Host 'Get storage account, go ahead'
    } catch {
        # Must be public newwork access to use
        $storageAccount1 = New-AzStorageAccount -SkuName "Standard_LRS" -Kind StorageV2 -ResourceGroupName $env.DataGroupName -Name $StorageAccountName1 -Location $env.region
    }

    Write-Host 'Start to create key vault' $KeyVaultName1 'in' $env.DataGroupName
    $KeyVault1 = Get-AzKeyVault -VaultName $KeyVaultName1 -ResourceGroupName $env.DataGroupName

    if ($KeyVault1.ResourceId) {
        Write-Host 'Get key vault, go ahead'
    } else {
        $KeyVault1 = New-AzKeyVault -Name $KeyVaultName1 -ResourceGroupName $env.DataGroupName -Location $env.region
    }
    
    Write-Host 'Start to create app insight' + $env.insightsName + 'in' + $env.DataGroupName
    try {
        $insight = Get-AzApplicationInsights -Name $env.insightsName -ResourceGroupName $env.DataGroupName -ErrorAction Stop
        Write-Host 'Get key vault, go ahead'
    } catch {
        $insight = New-AzApplicationInsights -Name $env.insightsName -ResourceGroupName $env.DataGroupName -Location $env.region
    }

    $env.KeyVaultID = $KeyVault1.ResourceId
    $env.InsightsID1 =  $insight.Id
    
    $env.StorageAccountID = $storageAccount1.Id
    $env.StorageAccountID2 = $storageAccount2.Id

    # $env.KeyVaultID = "/subscriptions/"+$env.SubscriptionId+"/resourceGroups/"+$env.DataGroupName+"/providers/Microsoft.KeyVault/vaults/"+$env.KeyVaultName1
    # $env.InsightsID1 =  "/subscriptions/"+$env.SubscriptionId+"/resourceGroups/"+$env.DataGroupName+"/providers/microsoft.insights/components/"+$env.insightsName
    # $env.StorageAccountID = "/subscriptions/"+$env.SubscriptionId+"/resourceGroups/"+$env.DataGroupName+"/providers/Microsoft.Storage/storageAccounts/"+$env.StorageAccountName1
    # $env.StorageAccountID2 = "/subscriptions/"+$env.SubscriptionId+"/resourceGroups/"+$env.DataGroupName+"/providers/Microsoft.Storage/storageAccounts/"+$env.ManualStorageAccount

    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

