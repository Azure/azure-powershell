if(($null -eq $TestName) -or ($TestName -contains 'Test-AzMigrateLocalEndToEnd'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzMigrateLocalEndToEnd.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzMigrateLocalEndToEnd' -Tag 'LiveOnly' {
    It 'DefaultUser' {
        $subscriptionId = $env.hciSubscriptionId
        $resourceGroupName = $env.hciMigResourceGroup
        $machineId = $env.hciSDSMachineId1
        $targetRgId = "/subscriptions/$($env.hciTargetRgSubId)/resourceGroups/$($env.hciMigResourceGroup)-target"
        $protectedItemId = $env.hciProtectedItem1

        # New-AzMigrateLocalServerReplication
        $newJob = New-AzMigrateLocalServerReplication `
            -MachineId $machineId `
            -SourceApplianceName $env.hciSourceApplianceName `
            -TargetApplianceName $env.hciTargetApplianceName `
            -TargetResourceGroupId $targetRgId `
            -TargetVMName $env.hciTgtVMName1 `
            -TargetStoragePathId $env.hciTgtStoragePathId `
            -TargetVirtualSwitchId $env.hciTgtVirtualSwitchId `
            -OSDiskID $env.hciDiskId1 `
            -SubscriptionId $subscriptionId `
            -IsDynamicMemoryEnabled "true"
        $newJob.Count | Should -BeGreaterOrEqual 1

        for ($i = 0; $i -le 3; $i++)
        {
            Start-Sleep -Seconds 30

            # Get-AzMigrateLocalServerReplication - GetByItemID
            $protectedItem = Get-AzMigrateLocalServerReplication -TargetObjectID $protectedItemId
            $protectedItem.Count | Should -BeGreaterOrEqual 1

            if ($protectedItem.Property.AllowedJob.Count -gt 0)
            {
                break
            }
        }

        # Get-AzMigrateLocalServerReplication - ListByName
        $protectedItem = Get-AzMigrateLocalServerReplication `
            -ProjectName $env.hciProjectName `
            -ResourceGroupName $resourceGroupName `
            -SubscriptionId $subscriptionId
        $protectedItem.Count | Should -BeGreaterOrEqual 1

        # Set-AzMigrateLocalServerReplication
        $updateJob = Set-AzMigrateLocalServerReplication `
            -TargetObjectID $protectedItemId `
            -SubscriptionId $subscriptionId `
            -IsDynamicMemoryEnabled "false"
        $updateJob.Count | Should -BeGreaterOrEqual 1

        # Wait for the replication job to update the protected item
        Start-Sleep -Seconds 30

        # Get-AzMigrateLocalServerReplication - GetByItemID
        $protectedItem = Get-AzMigrateLocalServerReplication -TargetObjectID $protectedItemId
        $protectedItem.Count | Should -BeGreaterOrEqual 1

        ## Get-AzMigrateLocalServerReplication - GetByInputObject
        $protectedItem = Get-AzMigrateLocalServerReplication -InputObject $protectedItem
        $protectedItem.Count | Should -BeGreaterOrEqual 1

        # Remove-AzMigrateLocalServerReplication
        $removeJob = Remove-AzMigrateLocalServerReplication -TargetObjectID $protectedItemId
        $removeJob.Count | Should -BeGreaterOrEqual 1
    }

    It 'PowerUser' {
        $subscriptionId = $env.hciSubscriptionId
        $resourceGroupName = $env.hciMigResourceGroup
        $machineId = $env.hciSDSMachineId2
        $targetRgId = "/subscriptions/$($env.hciTargetRgSubId)/resourceGroups/$($env.hciMigResourceGroup)-target"

        # New-AzMigrateLocalDiskMappingObject
        $diskToInclude = New-AzMigrateLocalDiskMappingObject `
            -DiskID $env.hciDiskId2 `
            -IsOSDisk "true" `
            -IsDynamic "true" `
            -Size 10 `
            -Format "VHDX"

        # New-AzMigrateLocalNicMappingObject
        $nicToInclude = New-AzMigrateLocalNicMappingObject `
            -NicID $env.hciNicId2 `
            -TargetVirtualSwitchId $env.hciTgtVirtualSwitchId

        # New-AzMigrateLocalServerReplication
        $newJob = New-AzMigrateLocalServerReplication `
            -MachineId $machineId `
            -SourceApplianceName $env.hciSourceApplianceName `
            -TargetApplianceName $env.hciTargetApplianceName `
            -TargetResourceGroupId $targetRgId `
            -TargetVMName $env.hciTgtVMName2 `
            -TargetStoragePathId $env.hciTgtStoragePathId `
            -DiskToInclude $diskToInclude `
            -NicToInclude $nicToInclude
        $newJob.Count | Should -BeGreaterOrEqual 1

        for ($i = 0; $i -le 3; $i++)
        {
            Start-Sleep -Seconds 30

            # Get-AzMigrateLocalServerReplication - GetBySDSID
            $obj = Get-AzMigrateLocalServerReplication -DiscoveredMachineId $machineId
            $obj.Count | Should -BeGreaterOrEqual 1

            if ($output.Property.AllowedJob.Count -gt 0)
            {
                break
            }
        }

        # Remove-AzMigrateLocalServerReplication
        $removeJob = Remove-AzMigrateLocalServerReplication -InputObject $obj
        $removeJob.Count | Should -BeGreaterOrEqual 1

        # Get-AzMigrateLocalJob - ListByName
        $job = Get-AzMigrateLocalJob `
            -ProjectName $env.hciProjectName `
            -ResourceGroupName $resourceGroupName `
            -SubscriptionId $subscriptionId
        $job.Count | Should -BeGreaterOrEqual 1

        # Get-AzMigrateLocalJob - GetByName
        $job = Get-AzMigrateLocalJob `
            -ProjectName $env.hciProjectName `
            -ResourceGroupName $resourceGroupName `
            -SubscriptionId $subscriptionId `
            -Name $removeJob.Name
        $job.Count | Should -BeGreaterOrEqual 1

        # Get-AzMigrateLocalJob - GetById
        $job = Get-AzMigrateLocalJob `
            -SubscriptionId $subscriptionId `
            -ID $removeJob.Id
        $job.Count | Should -BeGreaterOrEqual 1

        # Get-AzMigrateLocalJob - GetByInputObject
        $job = Get-AzMigrateLocalJob -InputObject $job
        $job.Count | Should -BeGreaterOrEqual 1
    }
}
