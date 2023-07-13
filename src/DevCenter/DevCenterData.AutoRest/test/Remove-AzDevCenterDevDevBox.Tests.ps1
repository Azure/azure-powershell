if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzDevCenterDevDevBox'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDevCenterDevDevBox.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzDevCenterDevDevBox' {
    It 'Delete' -skip {
        Remove-AzDevCenterDevDevBox -Endpoint $env.endpoint -Name "devbox1" -ProjectName $env.projectName
        { Get-AzDevCenterDevDevBox -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name "devbox1" } | Should -Throw

        Remove-AzDevCenterDevDevBox -DevCenter $env.devCenterName -Name "devbox2" -ProjectName $env.projectName
        { Get-AzDevCenterDevDevBox -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name "devbox2" } | Should -Throw

        }

    It 'DeleteViaIdentity' -skip {
        $devBoxInput = @{"ProjectName" = $env.projectName; "UserId" = "me"; "DevBoxName" = "devbox3" }
        $devBoxInput2 = @{"ProjectName" = $env.projectName; "UserId" = "me"; "DevBoxName" = "devbox4" }

        Remove-AzDevCenterDevDevBox -Endpoint $env.endpoint -InputObject $devBoxInput 
        { Get-AzDevCenterDevDevBox -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name "devbox3" } | Should -Throw

        Remove-AzDevCenterDevDevBox -DevCenter $env.devCenterName -InputObject $devBoxInput2
        { Get-AzDevCenterDevDevBox -Endpoint $env.endpoint -ProjectName $env.projectName -UserId "me" -Name "devbox4" } | Should -Throw
       }
}
