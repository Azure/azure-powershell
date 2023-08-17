if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzEventHubApplicationGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzEventHubApplicationGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzEventHubApplicationGroup' {
    $t2 = New-AzEventHubThrottlingPolicyConfig -Name t2 -MetricId OutgoingBytes -RateLimitThreshold 20000

    It 'Delete'  {
        $b = New-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -name b -Rights @("Manage", "Send", "Listen")
        $SASKey = "NamespaceSASKeyName="+$b.Name
        New-AzEventHubApplicationGroup -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup -Name appGroup -ClientAppGroupIdentifier $SASKey -Policy $t2
        Remove-AzEventHubApplicationGroup -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup -Name appGroup
        { Get-AzEventHubApplicationGroup -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup -Name appGroup } | Should -Throw
    }

    It 'DeleteViaIdentity'  {
        $c = New-AzEventHubAuthorizationRule -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -name c -Rights @("Manage", "Send", "Listen")
        $SASKey = "NamespaceSASKeyName="+$c.Name
        $appGroup = New-AzEventHubApplicationGroup -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup -Name appGroup -ClientAppGroupIdentifier $SASKey -Policy $t2
        Remove-AzEventHubApplicationGroup -InputObject $appGroup
        { Get-AzEventHubApplicationGroup -NamespaceName $env.namespace -ResourceGroupName $env.resourceGroup -Name appGroup } | Should -Throw
    }
}
