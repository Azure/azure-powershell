if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDevCenterUserEnvironment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDevCenterUserEnvironment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDevCenterUserEnvironment' {
    It 'PatchExpanded' -skip {
        $environment = Get-AzDevCenterUserEnvironment -Endpoint $env.endpoint10 -EnvironmentName $env.envName10 -ProjectName $env.projectName10 -UserId "me"
        $newExpirationTime = $environment.ExpirationDate + $delayTime

        $updatedEnvironment = Update-AzDevCenterUserEnvironment -Endpoint $env.endpoint10 -EnvironmentName $env.envName10 -ProjectName $env.projectName10 -ExpirationDate $newExpirationTime
        $updatedEnvironment.ExpirationDate | Should -Be $newExpirationTime
        }


    It 'PatchViaIdentityExpanded' -skip {
        $envInput = @{"UserId" = "me"; "ProjectName" = $env.projectName10; "EnvironmentName" = $env.envName10 }
        $environment = Get-AzDevCenterUserEnvironment -Endpoint $env.endpoint10 -EnvironmentName $env.envName10 -ProjectName $env.projectName10 -UserId "me"
        $newExpirationTime = $environment.ExpirationDate + $delayTime

        $updatedEnvironment = Update-AzDevCenterUserEnvironment -Endpoint $env.endpoint10 -InputObject $envInput -ExpirationDate $newExpirationTime
        $updatedEnvironment.ExpirationDate | Should -Be $newExpirationTime

    }
}
