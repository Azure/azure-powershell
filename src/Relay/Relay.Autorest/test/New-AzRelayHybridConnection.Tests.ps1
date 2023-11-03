if(($null -eq $TestName) -or ($TestName -contains 'New-AzRelayHybridConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzRelayHybridConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzRelayHybridConnection' {
    It 'CreateExpanded' {
        {
            New-AzRelayHybridConnection -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -Name $env.hybridConnectionName02 -UserMetadata "test 01"
            Get-AzRelayHybridConnection -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01
            Get-AzRelayHybridConnection -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -Name $env.hybridConnectionName02
            $connection = Set-AzRelayHybridConnection -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -Name $env.hybridConnectionName02 -UserMetadata "Test UserMetadata updated"
            $connection.UserMetadata | Should -Be "Test UserMetadata updated"
            Remove-AzRelayHybridConnection -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -Name $env.hybridConnectionName02
        } | Should -Not -Throw
    }

    It 'Create' {
        {
            $connection = New-AzRelayHybridConnection -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -Name $env.hybridConnectionName03 -UserMetadata "test 01"
            $connection = New-AzRelayHybridConnection -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -Name $env.hybridConnectionName03 -InputObject $connection
            $connection = Get-AzRelayHybridConnection -InputObject $connection
            $connection.UserMetadata = "testHybirdConnection"
            $newconnection = Set-AzRelayHybridConnection -ResourceGroupName $env.resourceGroupName -Namespace $env.namespaceName01 -Name $env.hybridConnectionName03 -InputObject $connection
            $newconnection.UserMetadata | Should -Be "testHybirdConnection"
            Remove-AzRelayHybridConnection -InputObject $newconnection
        } | Should -Not -Throw
    }
}
