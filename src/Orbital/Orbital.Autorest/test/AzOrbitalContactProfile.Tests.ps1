if(($null -eq $TestName) -or ($TestName -contains 'AzOrbitalContactProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzOrbitalContactProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzOrbitalContactProfile' {
    It 'CreateExpanded' {
        {
            $linkChannel = New-AzOrbitalContactProfileLinkChannelObject -BandwidthMHz 15 -CenterFrequencyMHz 8160 -EndPointIPAddress 10.0.1.0 -EndPointName AQUA_command -EndPointPort 55555 -EndPointProtocol TCP -Name channel1 -DecodingConfiguration na -DemodulationConfiguration na -EncodingConfiguration AQUA_CMD_CCSDS -ModulationConfiguration AQUA_UPLINK_BPSK

            $profileLink = New-AzOrbitalContactProfileLinkObject -Channel $linkChannel -Direction Downlink -Name RHCP_Downlink -Polarization RHCP -EirpdBw 45 -GainOverTemperature 0

            $config = New-AzOrbitalContactProfile -Name $env.contactProfile -ResourceGroupName $env.resourceGroup -Location $env.location -SubscriptionId $env.SubscriptionId -AutoTrackingConfiguration xBand -EventHubUri "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.EventHub/namespaces/$($env.eventhub)" -Link $profileLink -MinimumElevationDegree 10 -MinimumViableContactDuration PT1M -NetworkConfigurationSubnetId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/$($env.virtualnetwork)/subnets/$($env.virtualnetworkSubnets)"
            $config.Name | Should -Be $env.contactProfile
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzOrbitalContactProfile
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzOrbitalContactProfile -ResourceGroupName $env.resourceGroup -Name $env.contactProfile
            $config.Name | Should -Be $env.contactProfile
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzOrbitalContactProfile -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzOrbitalContactProfile -ResourceGroupName $env.resourceGroup -Name $env.contactProfile -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.contactProfile
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzOrbitalContactProfile -ResourceGroupName $env.resourceGroup -Name $env.contactProfile
            $config = Update-AzOrbitalContactProfile -InputObject $config -Tag @{"123"="abc"}
            $config.Name | Should -Be $env.contactProfile
        } | Should -Not -Throw
    }
}
