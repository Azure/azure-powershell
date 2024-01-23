### Example 1: List Access Control Lists by Subscription
```powershell
Get-AzNetworkFabricAcl -SubscriptionId $subscriptionId
```

```output
Location    Name                          SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy    SystemDataLastModifiedByType
--------    ----                          ------------------- -------------------     ----------------------- ------------------------ ------------------------    ----
eastus2euap L3ISd-optA-Ingress-acl-patch  09/22/2023 06:51:09 <identity>              User                    09/22/2023 08:02:58      <identity>                  App…
eastus2euap L3ISd-optA-Ingress-acl2-patch 09/22/2023 08:59:42 <identity>              User                    09/25/2023 09:14:49      <identity>                  User
eastus2euap egress-acl-1                  09/21/2023 10:41:14 <identity>              Application             09/21/2023 10:58:51      <identity>                  App…
eastus2euap ingress-acl-1                 09/21/2023 10:41:31 <identity>              Application             09/21/2023 10:58:51      <identity>                  App…
eastus      aclName                       09/22/2023 09:17:51 <identity>              User                    09/22/2023 11:31:26      <identity>                  App…
```

This command lists all the Access Control Lists under the given Subscription

### Example 2: List Access Control Lists by Resource Group
```powershell
Get-AzNetworkFabricAcl -ResourceGroupName $resourceGroupName
```

```output
AclsUrl AdministrativeState Annotation ConfigurationState ConfigurationType DefaultAction DynamicMatchConfiguration
------- ------------------- ---------- ------------------ ----------------- ------------- -------------------------
        Disabled                       Succeeded          Inline            Permit        
```

This command lists all the Access Control Lists under the given Resource Group.

### Example 3: Get Access Control List
```powershell
Get-AzNetworkFabricAcl -Name $name -ResourceGroupName $resourceGroupName
```

```output
AclsUrl AdministrativeState Annotation ConfigurationState ConfigurationType DefaultAction DynamicMatchConfiguration
------- ------------------- ---------- ------------------ ----------------- ------------- -------------------------
        Disabled                       Succeeded          Inline            Permit        
```

This command gets details of the given Access Control List.