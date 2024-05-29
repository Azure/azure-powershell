---
external help file:
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/get-aznetworkfabricexternalnetwork
schema: 2.0.0
---

# Get-AzNetworkFabricExternalNetwork

## SYNOPSIS
Implements ExternalNetworks GET method.

## SYNTAX

### List (Default)
```
Get-AzNetworkFabricExternalNetwork -L3IsolationDomainName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkFabricExternalNetwork -L3IsolationDomainName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkFabricExternalNetwork -InputObject <IManagedNetworkFabricIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityL3IsolationDomain
```
Get-AzNetworkFabricExternalNetwork -L3IsolationDomainInputObject <IManagedNetworkFabricIdentity>
 -Name <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Implements ExternalNetworks GET method.

## EXAMPLES

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

### -L3IsolationDomainInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: GetViaIdentityL3IsolationDomain
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -L3IsolationDomainName
Name of the L3 Isolation Domain.

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

### -Name
Name of the External Network.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityL3IsolationDomain
Aliases: ExternalNetworkName

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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IExternalNetwork

## NOTES

## RELATED LINKS

