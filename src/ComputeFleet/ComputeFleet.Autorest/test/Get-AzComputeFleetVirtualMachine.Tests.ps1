if(($null -eq $TestName) -or ($TestName -contains 'Get-AzComputeFleetVirtualMachine'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzComputeFleetVirtualMachine.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzComputeFleetVirtualMachine' {
    BeforeAll {
        $resourceGroupName = "fleet-vm-list-test-rg"
        $vnetName = "vnet"
        $nsgName = "nsg"
        $vmNamePrefix = "fleetvm"
        $launchFleetName = "launch-fleet-vm"

        $result = New-TestResourceGroup -ResourceGroupName $resourceGroupName `
            -Location $env.Location -VNetName $vnetName -NsgName $nsgName
        $subnetId = $result.SubnetId
        $nsgId = $result.NsgId

        $vmProfile = New-TestVmProfile -SubnetId $subnetId -NsgId $nsgId -VmNamePrefix $vmNamePrefix

        $vmSize1 = [Microsoft.Azure.PowerShell.Cmdlets.ComputeFleet.Models.VMSizeProfile]::new()
        $vmSize1.Name = "Standard_D2s_v3"

        New-AzComputeFleet -Name $launchFleetName `
            -ResourceGroupName $resourceGroupName `
            -SubscriptionId $env.SubscriptionId `
            -Location $env.Location `
            -ComputeProfileBaseVirtualMachineProfile $vmProfile `
            -ComputeProfileComputeApiVersion "2024-03-01" `
            -VMSizesProfile @($vmSize1) `
            -RegularPriorityProfileCapacity 2 `
            -RegularPriorityProfileMinCapacity 1 `
            -RegularPriorityProfileAllocationStrategy "LowestPrice" `
            -Mode "Launch" `
            -VMNamePrefix $vmNamePrefix `
            -Tag @{ environment = "test" }

        # Wait for VMs to be provisioned
        Start-Sleep -Seconds 60
    }

    It 'List' {
        {
            $vmList = Get-AzComputeFleetVirtualMachine -Name $launchFleetName `
                -ResourceGroupName $resourceGroupName `
                -SubscriptionId $env.SubscriptionId

            $vmList.Count | Should -BeGreaterOrEqual 1
        } | Should -Not -Throw
    }

    AfterAll {
        Remove-AzResourceGroup -Name $resourceGroupName -ErrorAction SilentlyContinue -Confirm:$false
    }
}
