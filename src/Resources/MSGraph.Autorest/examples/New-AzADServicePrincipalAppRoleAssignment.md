### Example 1: ObjectIdWithResourceIdParameterSet
```powershell
New-AzADServicePrincipalAppRoleAssignment -ServicePrincipalId 71beb965-8347-495d-a589-c21cdde7a722 -ResourceId 351fa797-c81a-4998-9720-4c2ecb6c7abc -AppRoleId e799a9e2-acac-4960-9ba0-6a17661fa16a
```

```output
DeletedDateTime DisplayName Id                                          OdataId OdataType AppRoleId
--------------- ----------- --                                          ------- --------- ---------
                            Zbm-cUeDXUmlicIc3eenIoM3d5yo6ZxKpEV0rV0qwrs                   e799a9e2-acac-4960-9ba0-6a17661fa16a
```

Create an appRoleAssignment using ServicePrincipalId and ResourceId. 

### Example 2: SPNWithResourceDisplayNameParameterSet
```powershell
New-AzADServicePrincipalAppRoleAssignment  -ServicePrincipalDisplayName funapp1214 -ResourceDisplayName nori-sp -AppRoleId e799a9e2-acac-4960-9ba0-6a17661fa16a
```

```output
DeletedDateTime DisplayName Id                                          OdataId OdataType AppRoleId
--------------- ----------- --                                          ------- --------- ---------
                            Zbm-cUeDXUmlicIc3eenIlQUkQngl1xOj6KKuD5XA9k                   e799a9e2-acac-4960-9ba0-6a17661fa16a
```

Create an appRoleAssignment for service principal using ServicePrincipal DisplayName and Resource DisplayName. 

