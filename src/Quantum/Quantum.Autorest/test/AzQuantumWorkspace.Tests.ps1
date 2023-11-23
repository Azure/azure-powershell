if(($null -eq $TestName) -or ($TestName -contains 'AzQuantumWorkspace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzQuantumWorkspace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzQuantumWorkspace' {
    It 'CreateExpanded' {
        {
            $object = New-AzQuantumProviderObject -Id "ionq" -Sku "pay-as-you-go-cred"
            $config = New-AzQuantumWorkspace -Name $env.quantumWorkspaceName -ResourceGroupName $env.resourceGroup -Location $env.location -IdentityType 'SystemAssigned' -Provider $object -StorageAccount "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Storage/storageAccounts/azpssa"
            $config.Name | Should -Be $env.quantumWorkspaceName
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzQuantumWorkspace
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzQuantumWorkspace -ResourceGroupName $env.resourceGroup -Name $env.quantumWorkspaceName
            $config.Name | Should -Be $env.quantumWorkspaceName
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzQuantumWorkspace -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        {
            $config = Get-AzQuantumOffering -LocationName $env.location
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzQuantumWorkspace -ResourceGroupName $env.resourceGroup -Name $env.quantumWorkspaceName -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.quantumWorkspaceName
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentity' {
        {
            $config = Get-AzQuantumWorkspace -ResourceGroupName $env.resourceGroup -Name $env.quantumWorkspaceName
            $config = Update-AzQuantumWorkspace -InputObject $config -Tag @{"abc"="123"}
            $config.Name | Should -Be $env.quantumWorkspaceName
        } | Should -Not -Throw
    }

    It 'CheckExpanded' {
        {
            $config = Test-AzQuantumWorkspaceNameAvailability -LocationName eastus -Name sample-workspace-name -Type "Microsoft.Quantum/Workspaces"
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzQuantumWorkspace -ResourceGroupName $env.resourceGroup -Name $env.quantumWorkspaceName
        } | Should -Not -Throw
    }
}
