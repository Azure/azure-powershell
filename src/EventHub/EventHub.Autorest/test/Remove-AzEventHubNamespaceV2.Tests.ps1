if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzEventHubNamespaceV2'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzEventHubNamespaceV2.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzEventHubNamespaceV2' {
    It 'Delete' {
        $eventhubnamespace = New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2 -SkuName Standard -Location eastus    
        Remove-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2
        { Get-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2  } | Should -Throw
    }

    It 'DeleteViaIdentity' { 
        $eventhubnamespace = New-AzEventHubNamespaceV2 -ResourceGroupName $env.resourceGroup -Name $env.namespaceV2 -SkuName Standard -Location eastus
        Remove-AzEventHubNamespaceV2 -InputObject $eventhubnamespace
        { Get-AzEventHubNamespaceV2 -InputObject $eventhubnamespace } | Should -Throw
    }
}
