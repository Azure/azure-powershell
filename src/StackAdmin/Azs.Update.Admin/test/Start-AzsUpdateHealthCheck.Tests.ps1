if(($null -eq $TestName) -or ($TestName -contains 'Start-AzsUpdateHealthCheck'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzsUpdateHealthCheck.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzsUpdateHealthCheck' {
    It 'TestStartAzsUpdateHealthCheck' -skip:$('TestStartAzsUpdateHealthCheck' -in $global:SkippedTests) {
        $global:TestName = 'TestStartAzsUpdateHealthCheck'
        $updates = Get-AzsUpdate | Where-Object -Property State -in "PreparationFailed","Ready","HealthCheckFailed"

        if($updates -ne $null){
            Start-AzsUpdateHealthCheck -Name $updates[0].Name
            $updaterun = Get-AzsUpdateRun -UpdateName $updates[0].Name
            $updaterun | Should Not Be $null 
        }
    }
}
