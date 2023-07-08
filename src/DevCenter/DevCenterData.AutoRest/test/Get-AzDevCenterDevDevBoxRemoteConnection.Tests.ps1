if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterDevDevBoxRemoteConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterDevDevBoxRemoteConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterDevDevBoxRemoteConnection' {
    It 'Get' -skip {
        $connection = Get-AzDevCenterDevDevBoxRemoteConnection -Endpoint $env.endpoint -DevBoxName $env.devboxName -ProjectName $env.projectName

        $connection.RdpConnectionUrl | Should -Not -BeNullOrEmpty
        $connection.WebUrl | Should -Not -BeNullOrEmpty

        $connection = Get-AzDevCenterDevDevBoxRemoteConnection -DevCenter $env.devCenterName -DevBoxName $env.devboxName -ProjectName $env.projectName
        $connection.RdpConnectionUrl | Should -Not -BeNullOrEmpty
        $connection.WebUrl | Should -Not -BeNullOrEmpty

        }

    It 'GetViaIdentity' -skip {
        $devBoxInput = @{"DevBoxName" = $env.devBoxName; "UserId" = "me"; "ProjectName" = $env.projectName;}

        $connection = Get-AzDevCenterDevDevBoxRemoteConnection -Endpoint $env.endpoint -InputObject $devBoxInput
        $connection.RdpConnectionUrl | Should -Not -BeNullOrEmpty
        $connection.WebUrl | Should -Not -BeNullOrEmpty

        $connection = Get-AzDevCenterDevDevBoxRemoteConnection -DevCenter $env.devCenterName -InputObject $devBoxInput
        $connection.RdpConnectionUrl | Should -Not -BeNullOrEmpty
        $connection.WebUrl | Should -Not -BeNullOrEmpty
    }
}
