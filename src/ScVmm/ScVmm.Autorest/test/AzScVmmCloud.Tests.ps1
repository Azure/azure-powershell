if(($null -eq $TestName) -or ($TestName -contains 'AzScVmmCloud'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzScVmmCloud.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzScVmmCloud' -Tag 'LiveOnly' {
    It 'CreateExpanded' {
        {
            $result = New-AzScVmmCloud -Name $env.CloudName -ResourceGroupName $env.ResourceGroupEnableInvTest -VmmServerName $env.VmmServerName -InventoryUuid $env.CloudUuid -Location $env.location
            $result.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }
    
    It 'ListBySubscription - List' {
        {
            $result = Get-AzScVmmCloud
            $result.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'ListByResourceGroup - List1' {
        {
            $result = Get-AzScVmmCloud -ResourceGroupName $env.ResourceGroupEnableInvTest
            $result.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Update' {
        $result = Update-AzScVmmCloud -ResourceGroupName $env.ResourceGroupEnableInvTest -Name $env.CloudName -Tag @{tag1="value1"}
        $result.ProvisioningState | Should -Be 'Succeeded' 
        $result.Tag['tag1'] | Should -Be 'value1'
    }

    It 'Get' {
        {
            $result = Get-AzScVmmCloud -ResourceGroupName $env.ResourceGroupEnableInvTest -Name $env.CloudName
            $result.Name | Should -Be $env.CloudName
        } | Should -Not -Throw
    }

    It 'Remove' {
        {
            Remove-AzScVmmCloud -ResourceGroupName $env.ResourceGroupEnableInvTest -Name $env.CloudName
        } | Should -Not -Throw
    }

    It 'CreateExpandedId' {
        {
            $InvId = $env.VmmServerEnableInvTestId + "/InventoryItems/" + $env.CloudUuid
            $result = New-AzScVmmCloud -Name $env.CloudName -ResourceGroupName $env.ResourceGroupEnableInvTest -InventoryItemId $InvId -VmmServerId $env.VmmServerEnableInvTestId -CustomLocationId $env.CustomLocationEnableInvTest -Location $env.location
            $result.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'Remove' {
        {
            Remove-AzScVmmCloud -ResourceGroupName $env.ResourceGroupEnableInvTest -Name $env.CloudName
        } | Should -Not -Throw
    }
}