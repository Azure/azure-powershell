### Example 1: List External Networks
```powershell
Get-AzNetworkFabricExternalNetwork -L3IsolationDomainName $l3name -ResourceGroupName $resourceGroupName
```

```output
Name                 SystemDataCreatedAt SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType ResourceGroupNam
                                                                                                                                                                             e
----                 ------------------- -------------------        ----------------------- ------------------------ ------------------------   ---------------------------- ----------------
externalNetworkName  09/25/2023 05:26:03 <identity>                 User                    09/25/2023 05:26:03      <identity>                User                         nfa-tool-ts-pow…
externalNetworkName1 09/25/2023 05:26:37 <identity>                 User                    09/25/2023 05:26:37      <identity>                User                         nfa-tool-ts-pow…
```

This command lists all the External Networks.
### Example 2: Get External Network
```powershell
Get-AzNetworkFabricExternalNetwork -L3IsolationDomainName $l3name -Name $name -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation ConfigurationState ExportRoutePolicy
------------------- ---------- ------------------ -----------------
Enabled                                           
```

This command gets details of the given External Network.

