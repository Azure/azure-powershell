if(($null -eq $TestName) -or ($TestName -contains 'New-AzSqlVirtualMachineMultiSubnetIPConfigurationObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSqlVirtualMachineMultiSubnetIPConfigurationObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSqlVirtualMachineMultiSubnetIPConfigurationObject' {
    It '__AllParameterSets' -skip {
        {
            $msconfig1 = New-AzSqlVirtualMachineMultiSubnetIPConfigurationObject -PrivateIPAddressSubnetResourceId $env.SubnetId1 -PrivateIPAddressIpaddress $env.IPAddress2 -SqlVirtualMachineInstance $env.SqlVMName_HA1Id
            $msconfig2 = New-AzSqlVirtualMachineMultiSubnetIPConfigurationObject -PrivateIPAddressSubnetResourceId $env.SubnetId2 -PrivateIPAddressIpaddress $env.IPAddress3 -SqlVirtualMachineInstance $env.SqlVMName_HA2Id
        } | Should -Not -Throw
    }
}
