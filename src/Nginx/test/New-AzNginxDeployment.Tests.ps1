if(($null -eq $TestName) -or ($TestName -contains 'New-AzNginxDeployment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNginxDeployment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNginxDeployment' {
    It 'CreateExpanded' {
        $publicIp = New-AzNginxPublicIPAddressObject -Id /subscriptions/e3853e83-0d02-4fb3-b88f-05b5fd21aee2/resourceGroups/limgu_rg/providers/Microsoft.Network/publicIPAddresses/test91922-ip
        $networkProfile = New-AzNginxNetworkProfileObject -FrontEndIPConfiguration @{PublicIPAddress=@($publicIp)} -NetworkInterfaceConfiguration @{SubnetId='/subscriptions/e3853e83-0d02-4fb3-b88f-05b5fd21aee2/resourceGroups/limgu_rg/providers/Microsoft.Network/virtualNetworks/test91922-vnet/subnets/default'}
        $nginxDeployment = New-AzNginxDeployment -Name $env.nginxDeployment2 -ResourceGroupName $env.resourceGroup -Location westcentralus -NetworkProfile $networkProfile -SkuName preview_Monthly_gmz7xq9ge3py
        $nginxDeployment.ProvisioningState | Should -Be 'Succeeded'
        $nginxDeployment.Name | Should -Be $env.nginxDeployment2
    }
}
