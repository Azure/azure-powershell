if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterUserDevBoxOperation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterUserDevBoxOperation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}
Describe 'Get-AzDevCenterUserDevBoxOperation' {
    It 'List' {
        $listOfOperations = Get-AzDevCenterUserDevBoxOperation -Endpoint $env.endpoint -ProjectName $env.projectName -DevBoxName $env.devboxName
        $listOfOperations.Count | Should -BeGreaterOrEqual 1

        if ($Record -or $Live) {
            $listOfOperations = Get-AzDevCenterUserDevBoxAction -DevCenterName $env.devCenterName -DevBoxName $env.devboxName -ProjectName $env.projectName
            $listOfOperations.Count | Should -BeGreaterOrEqual 1
        }

    }

    It 'Get' {
        $operation = Get-AzDevCenterUserDevBoxOperation -Endpoint $env.endpoint -ProjectName $env.projectName -DevBoxName $env.devboxName -OperationId "d0954a94-3550-4919-bcbe-1c94ed79e0cd"
        $operation.Kind | Should -Be "Repair"
        $operation.ResultRepairOutcome | Should -Be "NoIssuesDetected"
        $operation.Status | Should -Be "Succeeded"
    }

    It 'GetViaIdentity' {
        $devBoxInput = @{"DevBoxName" = $env.devBoxName; "UserId" = "me"; "ProjectName" = $env.projectName; "OperationId" = "d0954a94-3550-4919-bcbe-1c94ed79e0cd" }
        $operation = Get-AzDevCenterUserDevBoxOperation -Endpoint $env.endpoint -InputObject $devBoxInput
        $operation.Kind | Should -Be "Repair"
        $operation.ResultRepairOutcome | Should -Be "NoIssuesDetected"
        $operation.Status | Should -Be "Succeeded"
    }
}
