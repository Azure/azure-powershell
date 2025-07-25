### Example 1: ObjectIdWithResourceIdParameterSet
```powershell
New-AzADServicePrincipalAppRoleAssignment -ServicePrincipalId 71beb965-8347-495d-a589-c21cdde7a722 -ResourceId 351fa797-c81a-4998-9720-4c2ecb6c7abc -AppRoleId 649ae968-bdf9-4f22-bb2c-2aa1b4af0a83
```

```output
Id                                          AppRoleId                            PrincipalDisplayName PrincipalId                          CreatedDateTime
--                                          ---------                            -------------------- -----------                          ---------------
Zbm-cUeDXUmlicIc3eenIkgIm8kv9kJPj4MFhepACNE 649ae968-bdf9-4f22-bb2c-2aa1b4af0a83 funapp1214           71beb965-8347-495d-a589-c21cdde7a722 12/14/2023 7:04:28 AM
```

Create an appRoleAssignment using ServicePrincipalId and ResourceId. 

### Example 2: SPNWithResourceDisplayNameParameterSet
```powershell
New-AzADServicePrincipalAppRoleAssignment -ServicePrincipalDisplayName funapp1214 -ResourceDisplayName nori-sp -AppRoleId 649ae968-bdf9-4f22-bb2c-2aa1b4af0a83
```

```output
Id                                          AppRoleId                            PrincipalDisplayName PrincipalId                          CreatedDateTime
--                                          ---------                            -------------------- -----------                          ---------------
Zbm-cUeDXUmlicIc3eenIlqgWRlWp2hFrXIJiqP2j78 649ae968-bdf9-4f22-bb2c-2aa1b4af0a83 funapp1214           71beb965-8347-495d-a589-c21cdde7a722 12/14/2023 7:07:16 AM
```

Create an appRoleAssignment for service principal using ServicePrincipal DisplayName and Resource DisplayName. 

