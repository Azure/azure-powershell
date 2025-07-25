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
        $dateString = "2024-07-13T05:02:04.3117922Z"
        $dateTime = [DateTime]::ParseExact($dateString, "yyyy-MM-ddTHH:mm:ss.fffffffZ", [System.Globalization.CultureInfo]::InvariantCulture, [System.Globalization.DateTimeStyles]::AssumeUniversal)


        $updatedEnvironment = Update-AzDevCenterUserEnvironment -Endpoint $env.endpoint10 -EnvironmentName $env.envName10 -ProjectName $env.projectName10 -ExpirationDate $dateTime
        $updatedEnvironment.ExpirationDate | Should -Be $dateTime.ToUniversalTime()
        }


    It 'PatchViaIdentityExpanded' {
        $envInput = @{"UserId" = "me"; "ProjectName" = $env.projectName10; "EnvironmentName" = $env.envName10 }

        $dateString = "2024-08-13T05:02:04.7642679Z"
        $dateTime = [DateTime]::ParseExact($dateString, "yyyy-MM-ddTHH:mm:ss.fffffffZ", [System.Globalization.CultureInfo]::InvariantCulture, [System.Globalization.DateTimeStyles]::AssumeUniversal)

        $updatedEnvironment = Update-AzDevCenterUserEnvironment -Endpoint $env.endpoint10 -InputObject $envInput -ExpirationDate $dateTime
        $updatedEnvironment.ExpirationDate | Should -Be $dateTime.ToUniversalTime()

    }
}
