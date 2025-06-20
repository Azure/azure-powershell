### Example 1: List NetworkSecurityPerimeter Profiles
```powershell
Get-AzNetworkSecurityPerimeterProfile -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
```

```output
Name                ResourceGroupName
----                -----------------
profile-test-1      rg-test-1
profile-test-2      rg-test-1
```

List NetworkSecurityPerimeter Profiles

### Example 2: Get NetworkSecurityPerimeter Profile by Name
```powershell
Get-AzNetworkSecurityPerimeterProfile -Name profile-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
```

```output
AccessRulesVersion           : 5
DiagnosticSettingsVersion    : 0
Id                           : /subscriptions/0000000-4afa-47ee-8ea4-1c8449c8c8d9/resourceGroups/rg-test-1/providers
                                /Microsoft.Network/networkSecurityPerimeters/nsp-test-1/profiles/profile-test-1
Name                         : profile-test-1
ResourceGroupName            : rg-test-1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Network/networkSecurityPerimeters/profiles
```

Get NetworkSecurityPerimeter Profile by Name

### Example 3: Get NetworkSecurityPerimeter Profile by Identity (using pipe)
```powershell
$GETObj = Get-AzNetworkSecurityPerimeterProfile -Name profile-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
Get-AzNetworkSecurityPerimeterProfile -InputObject $GETObj
```

```output
AccessRulesVersion           : 5
DiagnosticSettingsVersion    : 0
Id                           : /subscriptions/0000000-4afa-47ee-8ea4-1c8449c8c8d9/resourceGroups/rg-test-1/providers
                                /Microsoft.Network/networkSecurityPerimeters/nsp-test-1/profiles/profile-test-1
Name                         : profile-test-1
ResourceGroupName            : rg-test-1
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Network/networkSecurityPerimeters/profiles
```

Get NetworkSecurityPerimeter Profile by Identity (using pipe)
