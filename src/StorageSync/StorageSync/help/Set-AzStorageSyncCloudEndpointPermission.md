---
external help file: Microsoft.Azure.PowerShell.Cmdlets.StorageSync.dll-Help.xml
Module Name: Az.StorageSync
online version: https://learn.microsoft.com/powershell/module/Az.storagesync/set-Azstoragesynccloudendpointpermission
schema: 2.0.0
---

# Set-AzStorageSyncCloudEndpointPermission

## SYNOPSIS
This command sets RBAC permission required for an Azure File Sync cloud endpoint in a sync group.

## SYNTAX

### StringParameterSet (Default)
```
Set-AzStorageSyncCloudEndpointPermission [-ResourceGroupName] <String> [-StorageSyncServiceName] <String>
 [-SyncGroupName] <String> -Name <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ObjectParameterSet
```
Set-AzStorageSyncCloudEndpointPermission [-ParentObject] <PSSyncGroup> -Name <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ParentStringParameterSet
```
Set-AzStorageSyncCloudEndpointPermission [-ParentResourceId] <String> -Name <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
This command sets RBAC permission required for an Azure File Sync cloud endpoint in a sync group. This permission allow Azure file sync to access storage account and azure file share for performing sync operations.

## EXAMPLES

### Example 1
```powershell
Set-AzStorageSyncCloudEndpointPermission -ResourceGroupName "myResourceGroup" -StorageSyncServiceName "myStorageSyncServiceName" -SyncGroupName "mySyncGroupName" -Name "myCloudEndpointName" 
```

A cloud endpoint permission is an integral access requirement for a sync group, this is an example of ensuring all required permissions required for existing sync group called "mySyncGroupName".

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the cloud endpoint. When created through the Azure portal, Name is set to the name of the Azure file share it references.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: CloudEndpointName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentObject
SyncGroup Object, normally passed through the parameter.

```yaml
Type: Microsoft.Azure.Commands.StorageSync.Models.PSSyncGroup
Parameter Sets: ObjectParameterSet
Aliases: SyncGroup

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ParentResourceId
SyncGroup Parent Resource Id

```yaml
Type: System.String
Parameter Sets: ParentStringParameterSet
Aliases: SyncGroupId

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: System.String
Parameter Sets: StringParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageSyncServiceName
Name of the StorageSyncService.

```yaml
Type: System.String
Parameter Sets: StringParameterSet
Aliases: ParentName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SyncGroupName
Name of the SyncGroup.

```yaml
Type: System.String
Parameter Sets: StringParameterSet
Aliases:

Required: True
Position: 2
Default value: None
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.StorageSync.Models.PSSyncGroup

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.StorageSync.Models.PSCloudEndpoint

## NOTES

## RELATED LINKS
