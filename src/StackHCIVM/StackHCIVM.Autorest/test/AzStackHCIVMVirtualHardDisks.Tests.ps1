if(($null -eq $TestName) -or ($TestName -contains 'AzStackHCIVMVirtualHardDisks'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzStackHCIVMVirtualHardDisks.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzStackHCIVMVirtualHardDisks' {
    It 'Create'  {
        New-AzStackHCIVMVirtualHardDisk -Name $env.vhdName -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.resourceGroupName -CustomLocationId $env.customLocationId -Location $env.location -SizeGb $env.sizeGb | Select-Object -Property ProvisioningState  | Should -BeExactly "@{ProvisioningState=Succeeded}"
    }

    It 'List'  {
        {
            $config = Get-AzStackHCIVMVirtualHardDisk -ResourceGroupName $env.resourceGroupName
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get'  {
        {
            $config =  Get-AzStackHCIVMVirtualHardDisk -Name $env.vhdName -ResourceGroupName $env.resourceGroupName 
            $config.Name | Should -Be $env.vhdName
        } | Should -Not -Throw
    }


    It 'Delete'{
        {
            Remove-AzStackHCIVMVirtualHardDisk -Name $env.vhdName -ResourceGroupName $env.resourceGroupName -Force
            $config =  Get-AzStackHCIVMVirtualHardDisk -Name $env.vhdName -ResourceGroupName $env.resourceGroupName 
            $config | Should -Be $null

        } | Should  -Throw
    }

} 