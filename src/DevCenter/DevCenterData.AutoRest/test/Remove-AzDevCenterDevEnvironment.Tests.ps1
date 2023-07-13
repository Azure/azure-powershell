if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDevCenterDevEnvironment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDevCenterDevEnvironment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDevCenterDevEnvironment' {
    It 'Delete' -skip {
        Remove-AzDevCenterDevEnvironment -Endpoint $env.endpoint -Name $env.envNameToDelete -ProjectName $env.projectName
        { Get-AzDevCenterDevEnvironment -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name $env.envNameToDelete } | Should -Throw

        Remove-AzDevCenterDevEnvironment -DevCenter $env.devCenterName  $env.envNameToDelete2  -ProjectName $env.projectName
        { Get-AzDevCenterDevEnvironment -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name $env.envNameToDelete2 } | Should -Throw

        }

    It 'DeleteViaIdentity' -skip {
        $envInput = @{"ProjectName" = $env.projectName; "UserId" = "me"; "EnvironmentName" = $env.envNameToDelete3 }
        $envInput2 = @{"ProjectName" = $env.projectName; "UserId" = "me"; "EnvironmentName" = $env.envNameToDelete4 }

        Remove-AzDevCenterDevEnvironment -Endpoint $env.endpoint -InputObject $envInput
        { Get-AzDevCenterDevEnvironment -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name $env.envNameToDelete3 } | Should -Throw

        Remove-AzDevCenterDevEnvironment -DevCenter $env.devCenterName  -InputObject $envInput2
        { Get-AzDevCenterDevEnvironment -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name $env.envNameToDelete4 } | Should -Throw

        }
}
