### Example 1: Get all OS versions in a location
```powershell
Get-AzCloudServiceOSVersion -location 'westus2'
```

```output
Name                        Label                                            IsDefault IsActive Family FamilyLabel
----                        -----                                            --------- -------- ------ -----------
WA-GUEST-OS-6.7_201905-01   Windows Azure Guest OS 6.7 (Release 201905-01)   False     False    6      Windows Server 2019
WA-GUEST-OS-3.21_201411-01  Windows Azure Guest OS 3.21 (Release 201411-01)  False     False    3      Windows Server 2012
WA-GUEST-OS-3.34_201512-01  Windows Azure Guest OS 3.34 (Release 201512-01)  False     False    3      Windows Server 2012
WA-GUEST-OS-3.26_201504-01  Windows Azure Guest OS 3.26 (Release 201504-01)  False     False    3      Windows Server 2012
WA-GUEST-OS-2.46_201512-01  Windows Azure Guest OS 2.46 (Release 201512-01)  False     False    2      Windows Server 2008 R2
```

This command gets all OS versions in location westus2

### Example 2: Get OS version
```powershell
Get-AzCloudServiceOSVersion -location 'westus2' -OSVersionName 'WA-GUEST-OS-6.7_201905-01'
```

```output
Name                      Label                                          IsDefault IsActive Family FamilyLabel
----                      -----                                          --------- -------- ------ -----------
WA-GUEST-OS-6.7_201905-01 Windows Azure Guest OS 6.7 (Release 201905-01) False     False    6      Windows Server 2019
```

This command gets OS version named WA-GUEST-OS-6.7_201905-01 that is located in westus2.
