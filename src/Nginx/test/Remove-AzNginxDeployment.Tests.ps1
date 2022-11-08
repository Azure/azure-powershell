if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzNginxDeployment'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzNginxDeployment.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzNginxDeployment' {
    It 'Delete' {
        Remove-AzNginxDeployment -Name $env.nginxDeployment2 -ResourceGroupName $env.resourceGroup
        $deploymentList = Get-AzNginxDeployment -ResourceGroupName $env.resourceGroup
        $deploymentList.Name | Should -Not -Contain $env.nginxDeployment2
    }

    It 'DeleteViaIdentity' {
        $publicIp = New-AzNginxPublicIPAddressObject -Id /subscriptions/e3853e83-0d02-4fb3-b88f-05b5fd21aee2/resourceGroups/limgu_rg/providers/Microsoft.Network/publicIPAddresses/test91922-ip
        $networkProfile = New-AzNginxNetworkProfileObject -FrontEndIPConfiguration @{PublicIPAddress=@($publicIp)} -NetworkInterfaceConfiguration @{SubnetId='/subscriptions/e3853e83-0d02-4fb3-b88f-05b5fd21aee2/resourceGroups/limgu_rg/providers/Microsoft.Network/virtualNetworks/test91922-vnet/subnets/default'}
        $deployment = New-AzNginxDeployment -Name $env.nginxDeployment2 -ResourceGroupName $env.resourceGroup -Location westcentralus -NetworkProfile $networkProfile -SkuName preview_Monthly_gmz7xq9ge3py
        Remove-AzNginxDeployment -InputObject $deployment
        $deploymentList = Get-AzNginxDeployment -ResourceGroupName $env.resourceGroup
        $deploymentList.Name | Should -Not -Contain $env.nginxDeployment2
    }
}
