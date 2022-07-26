### Example 1: Creates or updates a contact profile.
```powershell
$linkChannel = New-AzOrbitalContactProfileLinkChannelObject -BandwidthMHz 15 -CenterFrequencyMHz 8160 -EndPointIPAddress 10.0.1.0 -EndPointName AQUA_command -EndPointPort 55555 -EndPointProtocol TCP -Name channel1 -DecodingConfiguration na -DemodulationConfiguration na -EncodingConfiguration AQUA_CMD_CCSDS -ModulationConfiguration AQUA_UPLINK_BPSK

$profileLink = New-AzOrbitalContactProfileLinkObject -Channel $linkChannel -Direction Downlink -Name RHCP_UL -Polarization RHCP -EirpdBw 45 -GainOverTemperature 0

New-AzOrbitalContactProfile -Name azps-orbital-contactprofile -ResourceGroupName azpstest-gp -Location westus2 -SubscriptionId 9e223dbe-3399-4e19-88eb-0975f02ac87f -AutoTrackingConfiguration xBand -EventHubUri /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azpstest-gp/providers/Microsoft.EventHub/namespaces/eventhub-test -Link $profileLink -MinimumElevationDegree 10 -MinimumViableContactDuration PT1M -NetworkConfigurationSubnetId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azpstest-gp/providers/Microsoft.Network/virtualNetworks/orbital-virtualnetwork/subnets/orbital-vn
```

```output
Name                        Location ProvisioningState ResourceGroupName
----                        -------- ----------------- -----------------
azps-orbital-contactprofile westus2  succeeded         azpstest-gp
```

Creates or updates a contact profile.