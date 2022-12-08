if(($null -eq $TestName) -or ($TestName -contains 'New-AzVoiceServicesCommunicationsGateway'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVoiceServicesCommunicationsGateway.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzVoiceServicesCommunicationsGateway' {
    It 'CreateExpanded' {
        { 
            $region = @()
            $region += New-AzVoiceServicesCommunicationsGatewayServiceRegionObject -Name useast -PrimaryRegionOperatorAddress '198.51.100.1'
            $region += New-AzVoiceServicesCommunicationsGatewayServiceRegionObject -Name useast2 -PrimaryRegionOperatorAddress '198.51.100.2'

            New-AzVoiceServicesCommunicationsGateway -ResourceGroupName $env.resourceGroup -Name $env.gatewayName02 -Location $env.location -Codec 'PCMA' -E911Type 'Standard' -Platform 'OperatorConnect' -ServiceLocation $region 
            Get-AzVoiceServicesCommunicationsGateway -ResourceGroupName $env.resourceGroup -Name $env.gatewayName02
            Update-AzVoiceServicesCommunicationsGateway -ResourceGroupName $env.resourceGroup -Name $env.gatewayName02 -Tag @{'key1'='value1'}
            Remove-AzVoiceServicesCommunicationsGateway -ResourceGroupName $env.resourceGroup -Name $env.gatewayName02
        } | Should -Not -Throw
    }
    It 'CreateExpandedViaIdentity' {
        { 
            $region = @()
            $region += New-AzVoiceServicesCommunicationsGatewayServiceRegionObject -Name useast -PrimaryRegionOperatorAddress '198.51.100.1'
            $region += New-AzVoiceServicesCommunicationsGatewayServiceRegionObject -Name useast2 -PrimaryRegionOperatorAddress '198.51.100.2'

            $gateway = New-AzVoiceServicesCommunicationsGateway -ResourceGroupName $env.resourceGroup -Name $env.gatewayName03 -Location $env.location -Codec 'PCMA' -E911Type 'Standard' -Platform 'OperatorConnect' -ServiceLocation $region 
            Get-AzVoiceServicesCommunicationsGateway -InputObject $gateway
            Update-AzVoiceServicesCommunicationsGateway -InputObject $gateway -Tag @{'key1'='value1'}
            Remove-AzVoiceServicesCommunicationsGateway -InputObject $gateway
        } | Should -Not -Throw
    }
}
