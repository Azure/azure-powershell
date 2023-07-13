if(($null -eq $TestName) -or ($TestName -contains 'Start-AzDevCenterDevDevBox'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzDevCenterDevDevBox.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzDevCenterDevDevBox' {
    It 'Start' -skip {
        Start-AzDevCenterDevDevBox -Endpoint $env.endpoint -Name $env.devBoxName -ProjectName $env.projectName
        Start-AzDevCenterDevDevBox -DevCenter $env.devCenterName -Name $env.devBoxName -ProjectName $env.projectName 
       }

    It 'StartViaIdentity' -skip {
        $devBoxInput = @{"DevBoxName" = $env.devBoxName; "UserId" = "me"; "ProjectName" = $env.projectName}

        Start-AzDevCenterDevDevBox -Endpoint $env.endpoint -InputObject $devBoxInput
        Start-AzDevCenterDevDevBox -DevCenter $env.devCenterName -InputObject $devBoxInput
        }
}
