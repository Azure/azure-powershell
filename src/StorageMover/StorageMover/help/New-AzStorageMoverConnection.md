---
external help file: Az.StorageMover-help.xml
Module Name: Az.StorageMover
online version: https://learn.microsoft.com/powershell/module/az.storagemover/new-azstoragemoverconnection
schema: 2.0.0
---

# New-AzStorageMoverConnection

## SYNOPSIS
Create a Connection resource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzStorageMoverConnection -Name <String> -ResourceGroupName <String> -StorageMoverName <String>
 -PrivateLinkServiceId <String> [-SubscriptionId <String>] [-Description <String>] [-JobList <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityStorageMoverExpanded
```
New-AzStorageMoverConnection -Name <String> -StorageMoverInputObject <IStorageMoverIdentity>
 -PrivateLinkServiceId <String> [-Description <String>] [-JobList <String[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzStorageMoverConnection -Name <String> -ResourceGroupName <String> -StorageMoverName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzStorageMoverConnection -Name <String> -ResourceGroupName <String> -StorageMoverName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a Connection resource.

## EXAMPLES

### Example 1: Create a connection
```powershell
New-AzStorageMoverConnection -Name "example-connection" -ResourceGroupName "examples-rg" -StorageMoverName "examples-storageMoverName" -PrivateLinkServiceId "/subscriptions/60bcfc77-6589-4da2-b7fd-f9ec9322cf95/resourceGroups/examples-rg/providers/Microsoft.Network/privateLinkServices/example-pls" -Description "Example Connection Description"
```

```output
Id                           : /subscriptions/60bcfc77-6589-4da2-b7fd-f9ec9322cf95/resourceGroups/examples-rg/providers/Microsoft.StorageMover/storageMovers/examples-storageMoverName/connections/example-connection
Name                         : example-connection
Property                     : {
                                 "description": "Example Connection Description",
                                 "privateLinkServiceId": "/subscriptions/60bcfc77-6589-4da2-b7fd-f9ec9322cf95/resourceGroups/examples-rg/providers/Microsoft.Network/privateLinkServices/example-pls",
                                 "connectionStatus": "Pending Approval"
                               }
SystemDataCreatedAt          : 7/1/2023 1:01:01 AM
SystemDataCreatedBy          : user@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 7/1/2023 2:01:01 AM
SystemDataLastModifiedBy     : user@example.com
SystemDataLastModifiedByType : User
Type                         : microsoft.storagemover/storagemovers/connections
```

This command creates a connection for a Storage mover.

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

### -Description
A description for the Connection.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityStorageMoverExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobList
List of job definitions associated with this connection.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityStorageMoverExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Connection resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ConnectionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkServiceId
The PrivateLinkServiceId for the connection.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityStorageMoverExpanded
Aliases:

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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageMoverInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity
Parameter Sets: CreateViaIdentityStorageMoverExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StorageMoverName
The name of the Storage Mover resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IStorageMoverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.IConnection

## NOTES

## RELATED LINKS

