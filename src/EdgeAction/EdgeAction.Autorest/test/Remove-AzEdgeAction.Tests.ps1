if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzEdgeAction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzEdgeAction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzEdgeAction' {
    It 'Delete' {
        # Test deleting edge action
        $resourceGroupName = "powershelltests"
        $edgeActionName = "eadeletefixed01"
        
        # Create edge action to delete
        New-AzEdgeAction -ResourceGroupName $resourceGroupName `
            -Name $edgeActionName `
            -SkuName "Standard" `
            -SkuTier "Standard" `
            -Location "global"
        
        # Delete the edge action
        { Remove-AzEdgeAction -ResourceGroupName $resourceGroupName `
            -Name $edgeActionName } | Should -Not -Throw
        
        # Verify it's deleted
        { Get-AzEdgeAction -ResourceGroupName $resourceGroupName `
            -Name $edgeActionName -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
