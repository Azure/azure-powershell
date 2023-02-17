### Example 1: Create an in-memory object for ContentKeyPolicyOption.
```powershell
$filterTrackProperty = New-AzMediaFilterTrackPropertyConditionObject -Operation 'Equal' -Property 'Type' -Value "Audio"
New-AzMediaFilterTrackSelectionObject -TrackSelection $filterTrackProperty
```

```output
TrackSelection
--------------
{{…
```

Create an in-memory object for ContentKeyPolicyOption.