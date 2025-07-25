if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzEventHub'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzEventHub.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzEventHub' {
    It 'Delete'  {
        New-AzEventHub -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name eh1
        Remove-AzEventHub -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name eh1
        { Get-AzEventHub -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name eh1 -ErrorAction Stop } | Should -Throw
    }

    It 'DeleteViaIdentity'  {
        $eventhub = New-AzEventHub -ResourceGroupName $env.resourceGroup -NamespaceName $env.namespace -Name eh1
        Remove-AzEventHub -InputObject $eventhub
        { Get-AzEventHub -InputObject $eventhub -ErrorAction Stop } | Should -Throw
    }
}
