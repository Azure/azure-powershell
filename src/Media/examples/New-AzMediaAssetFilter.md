### Example 1: Creates or updates an Asset Filter associated with the specified Asset.
```powershell
$filterTrackProperty = New-AzMediaFilterTrackPropertyConditionObject -Operation 'Equal' -Property 'Type' -Value "Audio"
$filterTrackSelection = New-AzMediaFilterTrackSelectionObject -TrackSelection $filterTrackProperty

New-AzMediaAssetFilter -AccountName azpsms -AssetName azpsms-asset -FilterName azpsms-asset-filter -ResourceGroupName azps_test_group -FirstQualityBitrate '720' -PresentationTimeRangeEndTimestamp '200000' -PresentationTimeRangeForceEndTimestamp:$False -PresentationTimeRangeLiveBackoffDuration '60' -PresentationTimeRangePresentationWindowDuration '600000' -PresentationTimeRangeStartTimestamp '100000' -PresentationTimeRangeTimescale '1000' -Track $filterTrackSelection
```

```output
Name                ResourceGroupName
----                -----------------
azpsms-asset-filter azps_test_group
```

Creates or updates an Asset Filter associated with the specified Asset.