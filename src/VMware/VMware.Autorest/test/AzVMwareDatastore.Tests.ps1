if(($null -eq $TestName) -or ($TestName -contains 'AzVMwareDatastore'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzVMwareDatastore.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzVMwareDatastore' {
    It 'CreateExpanded' {
        {
            $config = New-AzVMwareDatastore -ClusterName $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -Name "datastore1" -NetAppVolumeId "/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/ResourceGroup1/providers/Microsoft.NetApp/netAppAccounts/NetAppAccount1/capacityPools/CapacityPool1/volumes/NFSVol1"
            $config.Name | Should -Be "datastore1"
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzVMwareDatastore -ClusterName $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -Name "datastore1"
            $config.Name | Should -Be "datastore1"
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzVMwareDatastore -ClusterName $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzVMwareDatastore -ClusterName $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -Name "datastore1"
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzVMwareDatastore -ClusterName $env.rstr1 -PrivateCloudName $env.privateCloudName1 -ResourceGroupName $env.resourceGroup1 -Name "datastore1"
            Remove-AzVMwareDatastore -InputObject $config
        } | Should -Not -Throw
    }
}
