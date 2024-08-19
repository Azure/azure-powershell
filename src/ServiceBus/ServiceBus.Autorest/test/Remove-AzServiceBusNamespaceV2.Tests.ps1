if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzServiceBusNamespaceV2'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzServiceBusNamespaceV2.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzServiceBusNamespaceV2' {
    It 'Delete' {
        $serviceBusNamespace = New-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV7 -SkuName Standard -Location $env.location    
        Remove-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV7
        { Get-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV7 -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity' { 
        $serviceBusNamespace = New-AzServiceBusNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV8 -SkuName Standard -Location $env.location
        Remove-AzServiceBusNamespaceV2 -InputObject $serviceBusNamespace
        { Get-AzServiceBusNamespaceV2 -InputObject $serviceBusNamespace -ErrorAction Stop } | Should -Throw
    }
}
