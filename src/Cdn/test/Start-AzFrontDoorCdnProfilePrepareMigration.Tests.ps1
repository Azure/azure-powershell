if(($null -eq $TestName) -or ($TestName -contains 'Start-AzFrontDoorCdnProfilePrepareMigration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzFrontDoorCdnProfilePrepareMigration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzFrontDoorCdnProfilePrepareMigration'  -Tag 'LiveOnly' {
    It 'MigrateExpanded' {
        $profileSku = "Standard_AzureFrontDoor"
        $migratedProfileName = 'migrated-pstest011'

        $migrateLocation = Start-AzFrontDoorCdnProfilePrepareMigration -ResourceGroupName $env.ResourceGroupName -ClassicResourceReferenceId $env.ClassicResourceId02 -ProfileName $migratedProfileName -SkuName $profileSku 
        $migrateLocation.Location | Should -BeNullOrEmpty
    }
}
