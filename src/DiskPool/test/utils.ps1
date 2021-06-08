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
    $env.Tenant = (Get-AzContext).Tenant.Id
    # For any resources you created for test, you should add it to $env here.

    # Create the test group
    Write-Host "Creating test resource group..."
    $resourceGroup = 'storagepool-rg-test'
    $location = 'westeurope'
    $null = $env.Add("resourceGroup", $resourceGroup)
    $null = $env.Add("location", $location)

    New-AzResourceGroup -Name $resourceGroup -Location $location

     # Create 1 vnet for all tests
     Write-Host "Creating Disk Pool Virtual Network..."
     $vnetParams = Get-Content .\test\deployment-templates\virtual-network\parameters.json | ConvertFrom-Json
     $vnetParams.parameters.vnetName.value = "disk-pool-vnet"

     $null = $env.Add("diskPoolVnetName", $vnetParams.parameters.vnetName.value)
 
     Set-Content -Path .\test\deployment-templates\virtual-network\parameters.json -Value (ConvertTo-Json $vnetParams)
     New-AzDeployment -Mode Incremental `
         -TemplateFile .\test\deployment-templates\virtual-network\template.json `
         -TemplateParameterFile .\test\deployment-templates\virtual-network\parameters.json `
         -Name diskPoolVnet `
         -ResourceGroupName $resourceGroup
     Write-Host -ForegroundColor Green "Virtual Network deployment completed."
 
     $virtualNetwork =  Get-AzVirtualNetwork -Name $vnetParams.parameters.vnetName.value
     $subnetId = $virtualNetwork.id + "/subnets/default"
     $null = $env.Add("diskPoolSubnetId", $subnetId)

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

    $disk1 = Get-AzDisk -Name $diskParams.parameters.name.value -ResourceGroupName $resourceGroup
    $null = $env.Add("diskId1", $disk1.id)

    # # Create Disk 2
    $diskParams = Get-Content .\test\deployment-templates\disk\parameters.json | ConvertFrom-Json
    $diskParams.parameters.name.value = "disk-pool-disk-2"

    Set-Content -Path .\test\deployment-templates\disk\parameters.json -Value (ConvertTo-Json $diskParams)
    New-AzDeployment -Mode Incremental `
        -TemplateFile .\test\deployment-templates\disk\template.json `
        -TemplateParameterFile .\test\deployment-templates\disk\parameters.json `
        -Name diskPoolDisk `
        -ResourceGroupName $resourceGroup
    Write-Host -ForegroundColor Green "Disk 2 deployment completed."

    $disk2 = Get-AzDisk -Name $diskParams.parameters.name.value -ResourceGroupName $resourceGroup
    $null = $env.Add("diskId2", $disk2.id)

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

    $disk3 = Get-AzDisk -Name $diskParams.parameters.name.value -ResourceGroupName $resourceGroup
    $null = $env.Add("diskId3", $disk3.id)

    Write-Host "Creating 2 Disk Pools..."
    $diskPoolParams = Get-Content .\test\deployment-templates\disk-pool\parameters.json | ConvertFrom-Json
    $diskPoolParams.parameters.subnetId.value = $subnetId
    $diskPoolParams.parameters.diskPoolName.value = "disk-pool-1"

    Set-Content -Path .\test\deployment-templates\disk-pool\parameters.json -Value (ConvertTo-Json $diskPoolParams)
    New-AzDeployment -Mode Incremental `
        -TemplateFile .\test\deployment-templates\disk-pool\template.json `
        -TemplateParameterFile .\test\deployment-templates\disk-pool\parameters.json `
        -Name diskPool `
        -ResourceGroupName $resourceGroup
    Write-Host -ForegroundColor Green "Disk Pool 1 deployment completed" 

    $disks = @($disk1.id)
    Update-AzDiskPool -Name 'disk-pool-1' -ResourceGroupName $resourceGroup -DiskId $disks

    $diskPoolParams.parameters.diskPoolName.value = "disk-pool-5"
    Set-Content -Path .\test\deployment-templates\disk-pool\parameters.json -Value (ConvertTo-Json $diskPoolParams)
    New-AzDeployment -Mode Incremental `
        -TemplateFile .\test\deployment-templates\disk-pool\template.json `
        -TemplateParameterFile .\test\deployment-templates\disk-pool\parameters.json `
        -Name diskPool `
        -ResourceGroupName $resourceGroup
    $disks = @($disk2.id,$disk3.id)
    Update-AzDiskPool -Name 'disk-pool-5' -ResourceGroupName $resourceGroup -DiskId $disks
    Write-Host -ForegroundColor Green "Disk Pool 5 deployment completed" 

    $null = $env.Add("diskPool1", "disk-pool-1")
    $null = $env.Add("diskPool5", "disk-pool-5")

    Write-Host "Creating 1 target1..."
    $target0 = "target0"
    $null = $env.Add("target0", "target0")
    $null = $env.Add("target1", "target1")

    $iscsiTargetParams = Get-Content .\test\deployment-templates\iscsi-target\parameters.json | ConvertFrom-Json
    $iscsiTargetParams.parameters.diskPoolName.value = $env.diskPool5
    $iscsiTargetParams.parameters.targetName.value = $target0
    $iscsiTargetParams.parameters.subnetId.value = $subnetId

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

