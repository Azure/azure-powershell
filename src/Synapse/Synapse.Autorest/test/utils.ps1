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
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
	Write-Host "sub id = " $env.SubscriptionId
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.
    # Generate some random strings for use in the test.
    $rstr1 = RandomString -allChars $false -len 6	
    $rstr2 = RandomString -allChars $false -len 6
    $rstr3 = RandomString -allChars $false -len 6
    # Follow random strings will be used in the test directly, so add it to $env
    $rstr4 = RandomString -allChars $false -len 6
    $rstr5 = RandomString -allChars $false -len 6
    $rstr6 = RandomString -allChars $false -len 6
    $null = $env.Add("rstr4", $rstr4)
    $null = $env.Add("rstr5", $rstr5)
    $null = $env.Add("rstr6", $rstr6)

    # Some constants
    $constants = Get-Content .\test\constants.json | ConvertFrom-Json
    $constants.psobject.Properties | ForEach-Object { $env[$_.Name] = $_.Value }

    # Create the test group
    $resourceGroupName = "testgroup" + $rstr1
    Write-Host "Start to create test resource group" $resourceGroupName
    $null = $env.Add("resourceGroupName", $resourceGroupName)
    New-AzResourceGroup -Name $resourceGroupName -Location $env.location

    # Create Storage Account and Workspace
    $storageName = "storage" + $rstr1
    $fileSystemName = "filesystem" + $rstr1
    $workspaceName = "workspace" + $rstr1
    Write-Host "Start to create Workspace" $workspaceName
    $null = $env.Add("storageName", $storageName)
    $null = $env.Add("fileSystemName", $fileSystemName)
    $null = $env.Add("workspaceName", $workspaceName)
    $workspaceParams = Get-Content .\test\deployment-templates\workspace\parameters.json | ConvertFrom-Json
    $workspaceParams.parameters.defaultDataLakeStorageAccountName.value = $storageName
    $workspaceParams.parameters.defaultDataLakeStorageFilesystemName.value = $fileSystemName
    $workspaceParams.parameters.workspaceName.value = $workspaceName
    set-content -Path .\test\deployment-templates\workspace\parameters.json -Value (ConvertTo-Json $workspaceParams)
    New-AzDeployment -Mode Incremental -TemplateFile .\test\deployment-templates\workspace\template.json -TemplateParameterFile .\test\deployment-templates\workspace\parameters.json -Name workspace -ResourceGroupName $resourceGroupName
    
    # Deploy kusto pool
    $kustoPoolName = "testkustopool" + $rstr1
    Write-Host "Start to create a Kusto pool" $kustoPoolName
    $null = $env.Add("kustopoolName", $kustoPoolName)
    New-AzSynapseKustoPool -ResourceGroupName $resourceGroupName -WorkspaceName $workspaceName -Name $kustoPoolName -Location $env.location -SkuName $env.skuName -SkuSize $env.skuSize
    
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzSynapseKustoPool -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -Name $env.kustoPoolName
    Remove-AzResourceGroup -Name $env.resourceGroupName
}

