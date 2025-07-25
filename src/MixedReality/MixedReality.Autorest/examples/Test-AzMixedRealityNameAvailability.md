### Example 1: Check Object Anchors Accounts Name Availability for local uniqueness.
```powershell
Test-AzMixedRealityNameAvailability -Location eastus -Name azpstest -Type "Microsoft.MixedReality/objectAnchorsAccounts"
```

```output
Message NameAvailable Reason
------- ------------- ------
        True
```

Check Object Anchors Accounts Name Availability for local uniqueness.

### Example 2: Check Remote Rendering Accounts Name Availability for local uniqueness.
```powershell
Test-AzMixedRealityNameAvailability -Location eastus -Name azpstest -Type "Microsoft.MixedReality/remoteRenderingAccounts"
```

```output
Message NameAvailable Reason
------- ------------- ------
        True
```

Check Remote Rendering Accounts Name Availability for local uniqueness.

### Example 3: Check Spatial Anchors Accounts Name Availability for local uniqueness.
```powershell
Test-AzMixedRealityNameAvailability -Location eastus -Name azpstest -Type "Microsoft.MixedReality/spatialAnchorsAccounts"
```

```output
Message NameAvailable Reason
------- ------------- ------
        True
```

Check Spatial Anchors Accounts Name Availability for local uniqueness.