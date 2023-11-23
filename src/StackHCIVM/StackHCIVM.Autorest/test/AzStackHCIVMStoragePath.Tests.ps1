if(($null -eq $TestName) -or ($TestName -contains 'AzStackHCIVMStoragePath'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzStackHCIVMStoragePath.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzStackHCIVMStoragePath' {
    It 'Create Storage Path '  {
        New-AzStackHCIVMStoragePath  -Name $env.storagePathName -SubscriptionId $env.subscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -Path "C:\\ClusterStorage\\Volume1\\testPath1106" | Select-Object -Property ProvisioningState | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }

    It 'List'  {
        {
            $config = Get-AzStackHCIVMStoragePath -ResourceGroupName $env.resourceGroupName
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get'  {
        {
            $config = Get-AzStackHCIVMStoragePath -Name  $env.storagePathName -ResourceGroupName $env.resourceGroupName 
            $config.Name | Should -Be  $env.storagePathName
        } | Should -Not -Throw
    }


    It 'Delete'{
        {
            Remove-AzStackHCIVMStoragePath -Name  $env.storagePathName -ResourceGroupName $env.resourceGroupName -Force
            $config = Get-AzStackHCIVMStoragePath -Name  $env.storagePathName -ResourceGroupName $env.resourceGroupName 
            $config | Should -Be $null
        } | Should -Throw
    }

} 