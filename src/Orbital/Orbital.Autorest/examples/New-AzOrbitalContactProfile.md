### Example 1: Creates or updates a contact profile.
```powershell
$linkChannel = New-AzOrbitalContactProfileLinkChannelObject -BandwidthMHz 15 -CenterFrequencyMHz 8160 -EndPointIPAddress 10.0.1.0 -EndPointName AQUA_VM -EndPointPort 51103 -EndPointProtocol TCP -Name channel1 -DecodingConfiguration na -DemodulationConfiguration na -EncodingConfiguration na -ModulationConfiguration aqua_direct_broadcast

$profileLink = New-AzOrbitalContactProfileLinkObject -Channel $linkChannel -Direction Downlink -Name RHCP_Downlink -Polarization RHCP -EirpdBw 0 -GainOverTemperature 0

New-AzOrbitalContactProfile -Name azps-orbital-contactprofile -ResourceGroupName azpstest-gp -Location westus2 -AutoTrackingConfiguration xBand -EventHubUri /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/azpstest-gp/providers/Microsoft.EventHub/namespaces/eventhub-test -Link $profileLink -MinimumElevationDegree 5 -MinimumViableContactDuration PT1M -NetworkConfigurationSubnetId /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/azpstest-gp/providers/Microsoft.Network/virtualNetworks/orbital-virtualnetwork/subnets/orbital-vn
```

```output
Name                        Location ProvisioningState ResourceGroupName
----                        -------- ----------------- -----------------
azps-orbital-contactprofile westus2  succeeded         azpstest-gp
```

Creates or updates a contact profile.