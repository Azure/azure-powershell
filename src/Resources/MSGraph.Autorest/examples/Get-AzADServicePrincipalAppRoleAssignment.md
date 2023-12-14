### Example 1: List assigned app roles
```powershell
Get-AzADServicePrincipalAppRoleAssignment -ServicePrincipalId 71beb965-8347-495d-a589-c21cdde7a722
```

```output
DeletedDateTime DisplayName Id                                          OdataId OdataType AppRoleId
--------------- ----------- --                                          ------- --------- ---------
                            Zbm-cUeDXUmlicIc3eenIlTWN1A5UVFMigS0D3ED-dk                   649ae968-bdf9-4f22-bb2c-2aa1b4af0a83
                            Zbm-cUeDXUmlicIc3eenIoFW9pZ_gRBIudKgu0gaMIw                   e799a9e2-acac-4960-9ba0-6a17661fa16a
```

List assigned app roles.

### Example 2: Get by AppRoleAssignmentId
```powershell
Get-AzADServicePrincipalAppRoleAssignment -ServicePrincipalId 71beb965-8347-495d-a589-c21cdde7a722 -AppRoleAssignmentId Zbm-cUeDXUmlicIc3eenIlTWN1A5UVFMigS0D3ED-dk
```

```output
DeletedDateTime DisplayName Id                                          OdataId OdataType AppRoleId
--------------- ----------- --                                          ------- --------- ---------
                            Zbm-cUeDXUmlicIc3eenIlTWN1A5UVFMigS0D3ED-dk                   649ae968-bdf9-4f22-bb2c-2aa1b4af0a83
```

Get an assigned app role by Id.

