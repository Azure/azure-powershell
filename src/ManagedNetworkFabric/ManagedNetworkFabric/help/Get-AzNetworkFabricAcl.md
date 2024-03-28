---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/get-aznetworkfabricacl
schema: 2.0.0
---

# Get-AzNetworkFabricAcl

## SYNOPSIS
Implements Access Control List GET method.

## SYNTAX

### List1 (Default)
```
Get-AzNetworkFabricAcl [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzNetworkFabricAcl -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzNetworkFabricAcl -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkFabricAcl -InputObject <IManagedNetworkFabricIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Implements Access Control List GET method.

## EXAMPLES

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

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Access Control List.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: AccessControlListName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List1, Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IAccessControlList

## NOTES

## RELATED LINKS
