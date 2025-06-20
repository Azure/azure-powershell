### Example 1: Create NetworkSecurityPerimeter Profile
```powershell
New-AzNetworkSecurityPerimeterProfile -Name profile-test-1 -ResourceGroupName rg-test-1 -SecurityPerimeterName nsp-test-1
```

```output
AccessRulesVersion           : 0
DiagnosticSettingsVersion    : 0
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/rg-test-1/providers
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

Creates NetworkSecurityPerimeter Profile