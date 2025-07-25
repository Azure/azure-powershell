if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzConnectedReconcileNetworkSecurityPerimeterConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzConnectedReconcileNetworkSecurityPerimeterConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzConnectedReconcileNetworkSecurityPerimeterConfiguration' {
    It 'Reconcile' {
        Invoke-AzConnectedReconcileNetworkSecurityPerimeterConfiguration -PerimeterName $env.PerimeterName -ResourceGroupName $env.ResourceGroupName -ScopeName $env.PrivateLinkScopeName
    }

    It 'ReconcileViaIdentityPrivateLinkScope' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReconcileViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
