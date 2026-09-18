if(($null -eq $TestName) -or ($TestName -contains 'AzScVmmVM'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzScVmmVM.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzScVmmVM' -Tag 'LiveOnly' {

    # Enable Existing Inventory VM

    # New-AzScVmmVM: CreateByName
    It 'Enable Inventory VM - CreateByName' {
        {
            # Remove Machine resource for VM enabled in SetupEnv()
            Remove-AzScVmmVM -ResourceGroupName $env.ResourceGroupVmTest -Name $env.VmName -DeleteMachine

            $result = New-AzScVmmVM -Name $env.VmName -ResourceGroupName $env.ResourceGroupVmTest -VmmServerName $env.VmmServerName -InventoryUuid $env.vmNameUuid -Location $env.location
            $result.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    # Remove-AzScVmmVM -DeleteMachine
    It 'Remove -DeleteMachine' {
        {
            Remove-AzScVmmVM -ResourceGroupName $env.ResourceGroupVmTest -Name $env.VmName -DeleteMachine
        } | Should -Not -Throw
    }

    # New-AzScVmmVM: CreateById
    It 'Enable Inventory VM - CreateById' {
        {
            $result = New-AzScVmmVM -Name $env.VmName -ResourceGroupName $env.ResourceGroupVmTest -VmmServerId $env.vmmServerVmTestId -CustomLocationId $env.CustomLocationVmTest -InventoryId $env.vmNameInvId -Location $env.location
            $result.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    # Create New VM

    # New-AzScVmmVM: CreateExpandedByName

    It 'CreateExpandedByName' {
        {
            $guestSecurePassword = ConvertTo-SecureString -String $env.GuestPassword -AsPlainText -Force
            $result = New-AzScVmmVM -Name $env.VmNameVmTest -ResourceGroupName $env.ResourceGroupVmTest -VmmServerName $env.VmmServerName -CloudName $env.CloudName -TemplateName $env.VmTemplateName -AvailabilitySetName @($env.AvailabilitySetName) -CpuCount 4 -MemoryMb 4096 -AdminPassword $guestSecurePassword -Generation 2 -Location $env.location
            $result.ProvisioningState | Should -Be 'Succeeded'
            $result.NetworkProfileNetworkInterface.Count | Should -Be 1
            $result.StorageProfileDisk.Count | Should -Be 1
            $result.HardwareProfileCpuCount | Should -Be 4
            $result.HardwareProfileMemoryMb | Should -Be 4096
        } | Should -Not -Throw
    }

    # Get-AzScVmmVM

    It 'Get' {
        {
            $result = Get-AzScVmmVM -Name $env.VmNameVmTest -ResourceGroupName $env.ResourceGroupVmTest
            $result.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    # Restart-AzScVmmVM 

    It 'Restart VM - Restart-AzScVmmVM' {
        {
            Restart-AzScVmmVM -Name $env.VmNameVmTest -ResourceGroupName $env.ResourceGroupVmTest
        } | Should -Not -Throw
    }

    Start-TestSleep -Seconds 15

    # Stop-AzScVmmVM

    It 'Stop VM - Stop-AzScVmmVM' {
        {
            Stop-AzScVmmVM -Name $env.VmNameVmTest -ResourceGroupName $env.ResourceGroupVmTest
        } | Should -Not -Throw
    }

    # Update-AzScVmmVM

    It 'Update VM - Update-AzScVmmVM' {
        {
            $result = Update-AzScVmmVM -ResourceGroupName $env.ResourceGroupVmTest -Name $env.VmNameVmTest -CpuCount 2 -MemoryMb 2048
            $result.ProvisioningState | Should -Be 'Succeeded'
            $result.HardwareProfileCpuCount | Should -Be 2
            $result.HardwareProfileMemoryMb | Should -Be 2048
        } | Should -Not -Throw
    }

    # Start-AzScVmmVM

    It 'Start VM - Start-AzScVmmVM' {
        {
            Start-AzScVmmVM -Name $env.VmNameVmTest -ResourceGroupName $env.ResourceGroupVmTest
        } | Should -Not -Throw
    }

    It 'Remove -DeleteFromHost -DeleteMachine' {
        {
            Remove-AzScVmmVM -ResourceGroupName $env.ResourceGroupVmTest -Name $env.VmNameVmTest -DeleteFromHost -DeleteMachine
        } | Should -Not -Throw
    }
}
