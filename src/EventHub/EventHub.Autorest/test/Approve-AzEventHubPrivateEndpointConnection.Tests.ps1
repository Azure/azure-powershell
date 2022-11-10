if(($null -eq $TestName) -or ($TestName -contains 'Approve-AzEventHubPrivateEndpointConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Approve-AzEventHubPrivateEndpointConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Approve-AzEventHubPrivateEndpointConnection' {
    $privateEndpoint = Get-AzEventHubPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
    
    It 'SetExpanded' {
        $privateEndpoint[0].ConnectionState | Should -Be "Pending"
        $privateEndpoint[0].Description | Should -Be "Hello"

        $firstPrivateEndpoint = Approve-AzEventHubPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $privateEndpoint[0].Name
        $firstPrivateEndpoint.ConnectionState | Should -Be "Approved"
        $firstPrivateEndpoint.Description | Should -Be ""

        while($firstPrivateEndpoint.ProvisioningState -ne "Succeeded"){
            $firstPrivateEndpoint = Get-AzEventHubPrivateEndpointConnection -Name $privateEndpoint[0].Name -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
            if ($TestMode -ne 'playback') {
                Start-Sleep 10
            }
        }
    }

    It 'SetViaIdentityExpanded' {
        $secondPrivateEndpoint = Get-AzEventHubPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $privateEndpoint[1].Name

        $secondPrivateEndpoint = Approve-AzEventHubPrivateEndpointConnection -InputObject $secondPrivateEndpoint -Description "Bye"
        $secondPrivateEndpoint.ConnectionState | Should -Be "Approved"
        $secondPrivateEndpoint.Description | Should -Be "Bye"

        while($secondPrivateEndpoint.ProvisioningState -ne "Succeeded"){
            $secondPrivateEndpoint = Get-AzEventHubPrivateEndpointConnection -Name $privateEndpoint[1].Name -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
            if ($TestMode -ne 'playback') {
                Start-Sleep 10
            }
        }
    }
}
