if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzStorageMoverReconcileJobDefinition'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzStorageMoverReconcileJobDefinition.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzStorageMoverReconcileJobDefinition' {
    It 'Reconcile' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReconcileViaIdentityStorageMover' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReconcileViaIdentityProject' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReconcileViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ParameterSets' {
        $command = Get-Command Invoke-AzStorageMoverReconcileJobDefinition
        foreach ($parameterSet in @('Reconcile', 'ReconcileViaIdentity', 'ReconcileViaIdentityProject', 'ReconcileViaIdentityStorageMover')) {
            $command.ParameterSets.Name | Should -Contain $parameterSet
        }
        $command.OutputType.Name | Should -Contain "Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IJobRunResourceId"
    }
}
