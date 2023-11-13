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
    It 'PatchExpanded' {
        $currentDate = Get-Date
        $dateIn8Months = $currentDate.AddMonths(8)

        $updatedEnvironment = Update-AzDevCenterUserEnvironment -Endpoint $env.endpoint10 -EnvironmentName $env.envName10 -ProjectName $env.projectName10 -ExpirationDate $dateIn8Months
        $updatedEnvironment.ExpirationDate | Should -Be $dateIn8Months.ToUniversalTime()
        }


    It 'PatchViaIdentityExpanded' {
        $envInput = @{"UserId" = "me"; "ProjectName" = $env.projectName10; "EnvironmentName" = $env.envName10 }
        $currentDate = Get-Date
        $dateIn9Months = $currentDate.AddMonths(9)

        $updatedEnvironment = Update-AzDevCenterUserEnvironment -Endpoint $env.endpoint10 -InputObject $envInput -ExpirationDate $dateIn9Months
        $updatedEnvironment.ExpirationDate | Should -Be $dateIn9Months.ToUniversalTime()

    }
}
