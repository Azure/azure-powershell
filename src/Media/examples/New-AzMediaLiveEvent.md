### Example 1: A live event is in StandBy state after allocation completes, and is ready to start.
```powershell
$ipRange = New-AzMediaIPRangeObject -Address "0.0.0.0" -Name AllowAll -SubnetPrefixLength 0

New-AzMediaLiveEvent -AccountName azpsms -Name azpsms-event -ResourceGroupName azps_test_group -Location eastus -InputAccessControlIPAllow $ipRange -InputKeyFrameIntervalDuration "PT2S" -InputStreamingProtocol 'RTMP' -PreviewAccessControlIPAllow $ipRange
```

```output
Location Name         ResourceGroupName
-------- ----         -----------------
East US  azpsms-event azps_test_group
```

A live event is in StandBy state after allocation completes, and is ready to start.