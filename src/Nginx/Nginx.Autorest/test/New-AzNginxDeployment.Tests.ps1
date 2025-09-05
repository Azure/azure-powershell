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
    It "CreateRemove" {
        {
            $publicIp = New-AzNginxPublicIPAddressObject -Id $env.PublicIPAddress
            $networkProfile = New-AzNginxNetworkProfileObject -FrontEndIPConfiguration @{PublicIPAddress = @($publicIp) } -NetworkInterfaceConfiguration @{SubnetId = "/subscriptions/$($env.subscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/$($env.vnet)/subnets/$($env.subnet)" }
            New-AzNginxDeployment -Name 'newazpwshnginx' -ResourceGroupName $env.resourceGroup -Location $env.location -SkuName standardv2_Monthly_gmz7xq9ge3py -UserAssignedIdentity $env.UserAssignedIdentity -NetworkProfile $networkProfile
            Remove-AzNginxDeployment -Name 'newazpwshnginx' -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}
