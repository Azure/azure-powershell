if(($null -eq $TestName) -or ($TestName -contains 'Get-AzManagedServicesAssignment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzManagedServicesAssignment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzManagedServicesAssignment' {
    It 'List' -skip {
        $assignments = Get-AzManagedServicesAssignment | Format-List -Property Id, Name, Type, RegistrationDefinitionId, ProvisioningState
        $assignments.Count | Should -Be 2
    }

    It 'Get' -skip {
        $assignment = Get-AzManagedServicesAssignment -Name $env.AssignmentId
        $assignment.Name | Should -Be $env.AssignmentId
    }

    It 'GetViaIdentity' -skip {
        $assignment = Get-AzManagedServicesAssignment -Name $env.AssignmentId
        $assignment = Get-AzManagedServicesAssignment -InputObject $assignment
        $assignment.Name | Should -Be $env.AssignmentId
    }
}
