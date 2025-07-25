if(($null -eq $TestName) -or ($TestName -contains 'New-AzRelayNamespace'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzRelayNamespace.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzRelayNamespace' {
    It 'CreateExpanded' {
        {
            New-AzRelayNamespace -ResourceGroupName $env.resourceGroupName  -Name $env.namespaceName02  -Location $env.location
            Get-AzRelayNamespace
            Get-AzRelayNamespace -ResourceGroupName $env.resourceGroupName 
            Get-AzRelayNamespace -ResourceGroupName $env.resourceGroupName  -Name $env.namespaceName02 
            Update-AzRelayNamespace -ResourceGroupName $env.resourceGroupName  -Name $env.namespaceName02  -Tag @{'k'='v'}
        } | Should -Not -Throw
    }
    It 'CreateExpanded2' {
        {
            $namespace = New-AzRelayNamespace -ResourceGroupName $env.resourceGroupName  -Name $env.namespaceName03  -Location $env.location
            Get-AzRelayNamespace -InputObject $namespace
            Update-AzRelayNamespace -InputObject $namespace -Tag @{'k'='v'}
        } | Should -Not -Throw
    }
}
