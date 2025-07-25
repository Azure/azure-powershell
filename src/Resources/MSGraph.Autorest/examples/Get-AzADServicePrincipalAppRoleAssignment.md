### Example 1: List assigned app roles
```powershell
Get-AzADServicePrincipalAppRoleAssignment -ServicePrincipalId 71beb965-8347-495d-a589-c21cdde7a722
```

```output
Id                                          AppRoleId                            PrincipalDisplayName PrincipalId                          CreatedDateTime
--                                          ---------                            -------------------- -----------                          ---------------
Zbm-cUeDXUmlicIc3eenIkgIm8kv9kJPj4MFhepACNE 649ae968-bdf9-4f22-bb2c-2aa1b4af0a83 funapp1214           71beb965-8347-495d-a589-c21cdde7a722 12/14/2023 7:04:28 AM
Zbm-cUeDXUmlicIc3eenIhHyPMkzw2VEh76fTc0bGtM e799a9e2-acac-4960-9ba0-6a17661fa16a funapp1214           71beb965-8347-495d-a589-c21cdde7a722 12/14/2023 6:56:52 AM
```

List assigned app roles.

### Example 2: Get by AppRoleAssignmentId
```powershell
Get-AzADServicePrincipalAppRoleAssignment -ServicePrincipalId 71beb965-8347-495d-a589-c21cdde7a722 -AppRoleAssignmentId Zbm-cUeDXUmlicIc3eenIkgIm8kv9kJPj4MFhepACNE
```

```output
Id                                          AppRoleId                            PrincipalDisplayName PrincipalId                          CreatedDateTime
--                                          ---------                            -------------------- -----------                          ---------------
Zbm-cUeDXUmlicIc3eenIkgIm8kv9kJPj4MFhepACNE 649ae968-bdf9-4f22-bb2c-2aa1b4af0a83 funapp1214           71beb965-8347-495d-a589-c21cdde7a722 12/14/2023 7:04:28 AM
```

Get an assigned app role by Id.

