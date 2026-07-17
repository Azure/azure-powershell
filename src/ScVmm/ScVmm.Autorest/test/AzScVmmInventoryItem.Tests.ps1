if(($null -eq $TestName) -or ($TestName -contains 'AzScVmmInventoryItem'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzScVmmInventoryItem.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzScVmmInventoryItem' {
    It 'List' {
        {
            $result = Get-AzScVmmInventoryItem -ResourceGroupName $env.ResourceGroupEnableInvTest -VmmServerName $env.VmmServerName
            $result.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get-Cloud' {
        {
            $result = Get-AzScVmmInventoryItem -ResourceGroupName $env.ResourceGroupEnableInvTest -VmmServerName $env.VmmServerName -Name $env.CloudUuid
            $result.InventoryItemName | Should -Be $env.CloudName
        } | Should -Not -Throw
    }

    It 'Get-VirtualNetwork' {
        {
            $result = Get-AzScVmmInventoryItem -ResourceGroupName $env.ResourceGroupEnableInvTest -VmmServerName $env.VmmServerName -Name $env.VirtualNetworkUuid
            $result.InventoryItemName | Should -Be $env.VirtualNetworkName
        } | Should -Not -Throw
    }

    It 'Get-VMTemplate' {
        {
            $result = Get-AzScVmmInventoryItem -ResourceGroupName $env.ResourceGroupEnableInvTest -VmmServerName $env.VmmServerName -Name $env.VmTemplateUuid
            $result.InventoryItemName | Should -Be $env.VmTemplateName
        } | Should -Not -Throw
    }
}
