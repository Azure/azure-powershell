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
        Invoke-AzConnectedReconcileNetworkSecurityPerimeterConfiguration -PerimeterName '90eb1fda-6016-40bb-8785-5974398f92aa.myScope-0ecf1e4b-93c4-4c6f-884e-7042acfeb87a' -ResourceGroupName $env.ResourceGroupName -ScopeName $env.PrivateLinkScopeName
    }

    It 'ReconcileViaIdentityPrivateLinkScope' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ReconcileViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
