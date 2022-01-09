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
    # For any resources you created for test, you should add it to $env here.

    $subscriptionId = (Get-AzContext).Subscription.Id
    $resourceGroup = 'storagepool-rg-test'
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.SubscriptionId = $subscriptionId
    $env.resourceGroup = $resourceGroup
    $env.location = 'westeurope'
    $env.diskPoolSubnetId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroup/providers/Microsoft.Network/virtualNetworks/disk-pool-vnet/subnets/default"
    $env.target0 = 'target0'
    $env.target1 = 'target1'
    $env.diskPool1 = 'disk-pool-1'
    $env.diskPool5 = 'disk-pool-5'
    $env.diskId1 = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroup/providers/Microsoft.Compute/disks/disk-pool-disk-1"
    $env.diskId2 = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroup/providers/Microsoft.Compute/disks/disk-pool-disk-2"
    $env.diskId3 = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroup/providers/Microsoft.Compute/disks/disk-pool-disk-3"

    # Create the test group
    Write-Host "Creating test resource group..."
    New-AzResourceGroup -Name $resourceGroup -Location $env.location

    # Create 1 vnet for all tests
     Write-Host "Creating Disk Pool Virtual Network..."
     $vnetParams = Get-Content .\test\deployment-templates\virtual-network\parameters.json | ConvertFrom-Json
     $vnetParams.parameters.vnetName.value = "disk-pool-vnet"

     Set-Content -Path .\test\deployment-templates\virtual-network\parameters.json -Value (ConvertTo-Json $vnetParams)
     New-AzDeployment -Mode Incremental `
         -TemplateFile .\test\deployment-templates\virtual-network\template.json `
         -TemplateParameterFile .\test\deployment-templates\virtual-network\parameters.json `
         -Name diskPoolVnet `
         -ResourceGroupName $resourceGroup
     Write-Host -ForegroundColor Green "Virtual Network deployment completed."

    # create Disks
    Write-Host "Creating 3 Disks..."
    $diskParams = Get-Content .\test\deployment-templates\disk\parameters.json | ConvertFrom-Json
    $diskParams.parameters.name.value = "disk-pool-disk-1"

    # Create Disk 1
    Set-Content -Path .\test\deployment-templates\disk\parameters.json -Value (ConvertTo-Json $diskParams)
    New-AzDeployment -Mode Incremental `
        -TemplateFile .\test\deployment-templates\disk\template.json `
        -TemplateParameterFile .\test\deployment-templates\disk\parameters.json `
        -Name diskPoolDisk `
        -ResourceGroupName $resourceGroup
    Write-Host -ForegroundColor Green "Disk 1 deployment completed."

    # Create Disk 2
    $diskParams = Get-Content .\test\deployment-templates\disk\parameters.json | ConvertFrom-Json
    $diskParams.parameters.name.value = "disk-pool-disk-2"

    Set-Content -Path .\test\deployment-templates\disk\parameters.json -Value (ConvertTo-Json $diskParams)
    New-AzDeployment -Mode Incremental `
        -TemplateFile .\test\deployment-templates\disk\template.json `
        -TemplateParameterFile .\test\deployment-templates\disk\parameters.json `
        -Name diskPoolDisk `
        -ResourceGroupName $resourceGroup
    Write-Host -ForegroundColor Green "Disk 2 deployment completed."

    # Create Disk 3
    $diskParams = Get-Content .\test\deployment-templates\disk\parameters.json | ConvertFrom-Json
    $diskParams.parameters.name.value = "disk-pool-disk-3" 

    Set-Content -Path .\test\deployment-templates\disk\parameters.json -Value (ConvertTo-Json $diskParams)
    New-AzDeployment -Mode Incremental `
        -TemplateFile .\test\deployment-templates\disk\template.json `
        -TemplateParameterFile .\test\deployment-templates\disk\parameters.json `
        -Name diskPoolDisk `
        -ResourceGroupName $resourceGroup
    Write-Host -ForegroundColor Green "Disk 3 deployment completed."

    Write-Host "Creating 2 Disk Pools..."
    $diskPoolParams = Get-Content .\test\deployment-templates\disk-pool\parameters.json | ConvertFrom-Json
    $diskPoolParams.parameters.subnetId.value = $env.diskPoolSubnetId
    $diskPoolParams.parameters.diskPoolName.value = "disk-pool-1"

    Set-Content -Path .\test\deployment-templates\disk-pool\parameters.json -Value (ConvertTo-Json $diskPoolParams)
    New-AzDeployment -Mode Incremental `
        -TemplateFile .\test\deployment-templates\disk-pool\template.json `
        -TemplateParameterFile .\test\deployment-templates\disk-pool\parameters.json `
        -Name diskPool `
        -ResourceGroupName $resourceGroup
    Write-Host -ForegroundColor Green "Disk Pool 1 deployment completed" 

    $disks = @($env.diskId1)
    Update-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName $resourceGroup -DiskId $disks

    $diskPoolParams.parameters.diskPoolName.value = "disk-pool-5"
    Set-Content -Path .\test\deployment-templates\disk-pool\parameters.json -Value (ConvertTo-Json $diskPoolParams)
    New-AzDeployment -Mode Incremental `
        -TemplateFile .\test\deployment-templates\disk-pool\template.json `
        -TemplateParameterFile .\test\deployment-templates\disk-pool\parameters.json `
        -Name diskPool `
        -ResourceGroupName $resourceGroup
    $disks = @($env.diskId2,$env.diskId3)
    Update-AzDiskPool -Name 'disk-pool-5' -ResourceGroupName $resourceGroup -DiskId $disks
    Write-Host -ForegroundColor Green "Disk Pool 5 deployment completed" 

    Write-Host "Creating 1 target1..."

    $iscsiTargetParams = Get-Content .\test\deployment-templates\iscsi-target\parameters.json | ConvertFrom-Json
    $iscsiTargetParams.parameters.diskPoolName.value = $env.diskPool5
    $iscsiTargetParams.parameters.targetName.value = $env.target0
    $iscsiTargetParams.parameters.subnetId.value = $env.diskPoolSubnetId

    Set-Content -Path .\test\deployment-templates\iscsi-target\parameters.json -Value (ConvertTo-Json $iscsiTargetParams)
    New-AzDeployment -Mode Incremental `
        -TemplateFile .\test\deployment-templates\iscsi-target\template.json `
        -TemplateParameterFile .\test\deployment-templates\iscsi-target\parameters.json `
        -Name iscsitarget1 `
        -ResourceGroupName $resourceGroup
    Write-Host -ForegroundColor Green "iSCSI target deployment completed"

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
    Remove-AzResourceGroup -Name $env.resourceGroup
}

