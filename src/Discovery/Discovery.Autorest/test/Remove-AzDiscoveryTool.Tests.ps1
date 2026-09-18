if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDiscoveryTool'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDiscoveryTool.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDiscoveryTool' {
    It 'Delete' {
        Remove-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName `
            -Name $env.ToolNameForDel -SubscriptionId $env.SubscriptionId -Confirm:$false
        { Get-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName `
            -Name $env.ToolNameForDel -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }

    It 'DeleteViaIdentity' {
        $identity = Get-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName `
            -Name $env.ToolNameForDelViaId -SubscriptionId $env.SubscriptionId -ErrorAction Stop
        $identity | Remove-AzDiscoveryTool -Confirm:$false
        { Get-AzDiscoveryTool -ResourceGroupName $env.ResourceGroupName `
            -Name $env.ToolNameForDelViaId -SubscriptionId $env.SubscriptionId } | Should -Throw -ErrorAction Stop
    }
}
