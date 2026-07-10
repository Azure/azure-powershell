if(($null -eq $TestName) -or ($TestName -contains 'Test-AzFrontDoorCdnProfileMigration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzFrontDoorCdnProfileMigration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzFrontDoorCdnProfileMigration' {
    It 'CanExpanded' {
        $subId = $env.SubscriptionId
        $canMigrate = Test-AzFrontDoorCdnProfileMigration -SubscriptionId $subId -ResourceGroupName $env.ResourceGroupName -ClassicResourceReferenceId $env.ClassicResourceId03
    
        $canMigrate.CanMigrate | Should -Be "True"
    }
}
