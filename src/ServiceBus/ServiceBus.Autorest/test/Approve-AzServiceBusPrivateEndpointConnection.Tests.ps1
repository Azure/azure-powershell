if(($null -eq $TestName) -or ($TestName -contains 'Approve-AzServiceBusPrivateEndpointConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Approve-AzServiceBusPrivateEndpointConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Approve-AzServiceBusPrivateEndpointConnection' {
    $privateEndpoint = Get-AzServiceBusPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
    
    It 'SetExpanded' {
        $privateEndpoint[0].ConnectionState | Should -Be "Pending"
        $privateEndpoint[0].Description | Should -Be "Hello"

        $firstPrivateEndpoint = Approve-AzServiceBusPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $privateEndpoint[0].Name
        $firstPrivateEndpoint.ConnectionState | Should -Be "Approved"
        $firstPrivateEndpoint.Description | Should -Be ""

        while($firstPrivateEndpoint.ProvisioningState -ne "Succeeded"){
            $firstPrivateEndpoint = Get-AzServiceBusPrivateEndpointConnection -Name $privateEndpoint[0].Name -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
            Start-Sleep 10
        }
    }

    It 'SetViaIdentityExpanded' {
        $secondPrivateEndpoint = Get-AzServiceBusPrivateEndpointConnection -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name $privateEndpoint[1].Name

        $secondPrivateEndpoint = Approve-AzServiceBusPrivateEndpointConnection -InputObject $secondPrivateEndpoint -Description "Bye"
        $secondPrivateEndpoint.ConnectionState | Should -Be "Approved"
        $secondPrivateEndpoint.Description | Should -Be "Bye"

        while($secondPrivateEndpoint.ProvisioningState -ne "Succeeded"){
            $secondPrivateEndpoint = Get-AzServiceBusPrivateEndpointConnection -Name $privateEndpoint[1].Name -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace
            Start-Sleep 10
        }
    }
}
