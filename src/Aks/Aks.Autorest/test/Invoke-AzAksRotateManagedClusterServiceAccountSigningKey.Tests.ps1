if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzAksRotateManagedClusterServiceAccountSigningKey'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzAksRotateManagedClusterServiceAccountSigningKey.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzAksRotateManagedClusterServiceAccountSigningKey' {
    It 'Rotate' {
        Invoke-AzAksRotateManagedClusterServiceAccountSigningKey -ResourceGroupName $env.ResourceGroupName -ResourceName $env.AksName
    }

    It 'RotateViaIdentity' {
        $aks = @{Id="/subscriptions/$($env.SubscriptionId)/resourcegroups/$($env.ResourceGroupName)/providers/Microsoft.ContainerService/managedClusters/$($env.AksName)"}
        Invoke-AzAksRotateManagedClusterServiceAccountSigningKey -InputObject $aks
    }
}
