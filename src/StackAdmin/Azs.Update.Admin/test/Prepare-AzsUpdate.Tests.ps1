if(($null -eq $TestName) -or ($TestName -contains 'Prepare-AzsUpdate'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Prepare-AzsUpdate.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Prepare-AzsUpdate' {
    It 'TestPrepareAzsUpdate' -skip:$('TestPrepareAzsUpdate' -in $global:SkippedTests) {
        $global:TestName = 'TestPrepareAzsUpdate'
        $updates = Get-AzsUpdate | Where-Object -Property State -in "PreparationFailed","Ready","HealthCheckFailed","DownloadFailed"
        if($updates -ne $null){
            Prepare-AzsUpdate -Name $updates.Name
            $updaterun = Get-AzsUpdateRun -UpdateName $updates.Name
            $updaterun | Should Not Be $null 
        }
    }
}
