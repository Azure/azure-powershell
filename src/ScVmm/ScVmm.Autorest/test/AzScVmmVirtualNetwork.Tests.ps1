if(($null -eq $TestName) -or ($TestName -contains 'AzScVmmVirtualNetwork'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzScVmmVirtualNetwork.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzScVmmVirtualNetwork' -Tag 'LiveOnly'{
    It 'CreateExpanded' {
        {
            $result = New-AzScVmmVirtualNetwork -Name $env.VirtualNetworkName -ResourceGroupName $env.ResourceGroupEnableInvTest -VmmServerName $env.VmmServerName -InventoryUuid $env.VirtualNetworkUuid -Location $env.location
            $result.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }
    
    It 'ListBySubscription - List' {
        {
            $result = Get-AzScVmmVirtualNetwork
            $result.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'ListByResourceGroup - List1' {
        {
            $result = Get-AzScVmmVirtualNetwork -ResourceGroupName $env.ResourceGroupEnableInvTest
            $result.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Update' {
        $result = Update-AzScVmmVirtualNetwork -ResourceGroupName $env.ResourceGroupEnableInvTest -Name $env.VirtualNetworkName -Tag @{tag1="value1"}
        $result.ProvisioningState | Should -Be 'Succeeded' 
        $result.Tag['tag1'] | Should -Be 'value1'
    }

    It 'Get' {
        {
            $result = Get-AzScVmmVirtualNetwork -ResourceGroupName $env.ResourceGroupEnableInvTest -Name $env.VirtualNetworkName
            $result.Name | Should -Be $env.VirtualNetworkName
        } | Should -Not -Throw
    }

    It 'Remove' {
        {
            Remove-AzScVmmVirtualNetwork -ResourceGroupName $env.ResourceGroupEnableInvTest -Name $env.VirtualNetworkName
        } | Should -Not -Throw
    }

    It 'CreateExpandedId' {
        {
            $InvId = $env.VmmServerEnableInvTestId + "/InventoryItems/" + $env.VirtualNetworkUuid
            $result = New-AzScVmmVirtualNetwork -Name $env.VirtualNetworkName -ResourceGroupName $env.ResourceGroupEnableInvTest -InventoryItemId $InvId -VmmServerId $env.VmmServerEnableInvTestId -CustomLocationId $env.CustomLocationEnableInvTest -Location $env.location
            $result.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'Remove' {
        {
            Remove-AzScVmmVirtualNetwork -ResourceGroupName $env.ResourceGroupEnableInvTest -Name $env.VirtualNetworkName
        } | Should -Not -Throw
    }
}
