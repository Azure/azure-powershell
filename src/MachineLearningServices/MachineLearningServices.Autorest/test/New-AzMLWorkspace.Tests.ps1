if(($null -eq $TestName) -or ($TestName -contains 'New-AzMLWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMLWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMLWorkspace' { #Moved
    It 'CreateExpanded' -Skip {
        {
            New-AzMLWorkspace -ResourceGroupName ml-rg-test01 -Name mlworkspace -Location eastus `
            -ApplicationInsightId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/ml-rg-test01/providers/microsoft.insights/components/mlworkspace7563533476" `
            -KeyVaultId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/ml-rg-test01/providers/microsoft.keyvault/vaults/mlworkspace2798527761" `
            -StorageAccountId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/ml-rg-test01/providers/microsoft.storage/storageaccounts/mlworkspace6620575898" `
            -IdentityType 'SystemAssigned' 
            Update-AzMLWorkspace -ResourceGroupName ml-rg-test01 -Name mlworkspace -Tag @{'key1' = 'value2'}
            Remove-AzMLWorkspace -ResourceGroupName ml-rg-test01 -Name mlworkspace
        } | Should -Not -Throw
    }
}
