if(($null -eq $TestName) -or ($TestName -contains 'Enable-AzFrontDoorCdnProfileMigration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Enable-AzFrontDoorCdnProfileMigration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Enable-AzFrontDoorCdnProfileMigration' -Tag 'LiveOnly' {
    It 'Commit' {
        $profileSku = "Standard_AzureFrontDoor"
        $migratedProfileName = 'migrated-pstest010'

        Start-AzFrontDoorCdnProfilePrepareMigration -ResourceGroupName $env.ResourceGroupName -ClassicResourceReferenceId $env.ClassicResourceId01 -ProfileName $migratedProfileName -SkuName $profileSku 
        Enable-AzFrontDoorCdnProfileMigration -ProfileName $migratedProfileName -ResourceGroupName $env.ResourceGroupName
    }
}