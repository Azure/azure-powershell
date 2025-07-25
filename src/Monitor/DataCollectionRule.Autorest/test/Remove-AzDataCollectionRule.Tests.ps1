if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDataCollectionRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDataCollectionRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDataCollectionRule' {
    It 'Delete' {
        {
            Remove-AzDataCollectionRule -ResourceGroupName $env.resourceGroup -Name $env.testCollectionRule3
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $rule = Get-AzDataCollectionRule -ResourceGroupName $env.resourceGroup -Name $env.testCollectionRule4
            Remove-AzDataCollectionRule -InputObject $rule
        } | Should -Not -Throw
    }
}
