if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzDevCenterDevDevBox'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzDevCenterDevDevBox.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Stop-AzDevCenterDevDevBox' {
    It 'Stop' -skip {
        $stopAction = Stop-AzDevCenterDevDevBox -Endpoint $env.endpoint -Name $env.devBoxName -ProjectName $env.projectName
        $stopAction.Status | Should -Be "Succeeded"
        $devBox = Get-AzDevCenterDevDevBox -Endpoint $env.endpoint -Name $env.devBoxName -ProjectName $env.projectName -UserId "me"
        $devBox.ActionState | Should -Be "Stopped"
        $devBox.PowerState | Should -Be "Hibernated"

        $stopAction = Stop-AzDevCenterDevDevBox -DevCenter $env.devCenterName -Name $env.devBoxName -ProjectName $env.projectName  
        $devBox = Get-AzDevCenterDevDevBox -Endpoint $env.endpoint -Name $env.devBoxName -ProjectName $env.projectName -UserId "me"
        $devBox.ActionState | Should -Be "Stopped"
        $devBox.PowerState | Should -Be "Hibernated"
   
    }

    It 'StopViaIdentity' -skip {
        $devBoxInput = @{"DevBoxName" = $env.devBoxName; "UserId" = "me"; "ProjectName" = $env.projectName}

        $stopAction = Stop-AzDevCenterDevDevBox -Endpoint $env.endpoint -InputObject $devBoxInput
        $stopAction.Status | Should -Be "Succeeded"
        $devBox = Get-AzDevCenterDevDevBox -Endpoint $env.endpoint -Name $env.devBoxName -ProjectName $env.projectName -UserId "me"
        $devBox.ActionState | Should -Be "Stopped"
        $devBox.PowerState | Should -Be "Hibernated"

        $stopAction = Stop-AzDevCenterDevDevBox -DevCenter $env.devCenterName -InputObject $devBoxInput 
        $stopAction.Status | Should -Be "Succeeded"
        $devBox = Get-AzDevCenterDevDevBox -Endpoint $env.endpoint -Name $env.devBoxName -ProjectName $env.projectName -UserId "me"
        $devBox.ActionState | Should -Be "Stopped"
        $devBox.PowerState | Should -Be "Hibernated"
 
      }
}
