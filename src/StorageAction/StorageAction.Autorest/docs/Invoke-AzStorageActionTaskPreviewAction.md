---
external help file:
Module Name: Az.StorageAction
online version: https://learn.microsoft.com/powershell/module/az.storageaction/invoke-azstorageactiontaskpreviewaction
schema: 2.0.0
---

# Invoke-AzStorageActionTaskPreviewAction

## SYNOPSIS
Runs the input conditions against input object metadata properties and designates matched objects in response.

## SYNTAX

### Preview (Default)
```
Invoke-AzStorageActionTaskPreviewAction -Location <String> -Parameter <IStorageTaskPreviewAction>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PreviewExpanded
```
Invoke-AzStorageActionTaskPreviewAction -Location <String> -ActionElseBlockExist
 -Blob <IStorageTaskPreviewBlobProperties[]> [-SubscriptionId <String>]
 [-ContainerMetadata <IStorageTaskPreviewKeyValueProperties[]>] [-ContainerName <String>]
 [-IfCondition <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PreviewViaIdentity
```
Invoke-AzStorageActionTaskPreviewAction -InputObject <IStorageActionIdentity>
 -Parameter <IStorageTaskPreviewAction> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PreviewViaIdentityExpanded
```
Invoke-AzStorageActionTaskPreviewAction -InputObject <IStorageActionIdentity> -ActionElseBlockExist
 -Blob <IStorageTaskPreviewBlobProperties[]> [-ContainerMetadata <IStorageTaskPreviewKeyValueProperties[]>]
 [-ContainerName <String>] [-IfCondition <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### PreviewViaJsonFilePath
```
Invoke-AzStorageActionTaskPreviewAction -Location <String> -JsonFilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PreviewViaJsonString
```
Invoke-AzStorageActionTaskPreviewAction -Location <String> -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Runs the input conditions against input object metadata properties and designates matched objects in response.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -ActionElseBlockExist
Specify whether the else block is present in the condition.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PreviewExpanded, PreviewViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Blob
Preview action container properties to be tested for a match with the provided condition.
To construct, see NOTES section for BLOB properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTaskPreviewBlobProperties[]
Parameter Sets: PreviewExpanded, PreviewViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerMetadata
metadata key value pairs to be tested for a match against the provided condition.
To construct, see NOTES section for CONTAINERMETADATA properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTaskPreviewKeyValueProperties[]
Parameter Sets: PreviewExpanded, PreviewViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerName
property for the container name.

```yaml
Type: System.String
Parameter Sets: PreviewExpanded, PreviewViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -IfCondition
Storage task condition to bes tested for a match.

```yaml
Type: System.String
Parameter Sets: PreviewExpanded, PreviewViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageActionIdentity
Parameter Sets: PreviewViaIdentity, PreviewViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Preview operation

```yaml
Type: System.String
Parameter Sets: PreviewViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Preview operation

```yaml
Type: System.String
Parameter Sets: PreviewViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location to perform preview of the actions.

```yaml
Type: System.String
Parameter Sets: Preview, PreviewExpanded, PreviewViaJsonFilePath, PreviewViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Storage Task Preview Action.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTaskPreviewAction
Parameter Sets: Preview, PreviewViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Preview, PreviewExpanded, PreviewViaJsonFilePath, PreviewViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageActionIdentity

### Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTaskPreviewAction

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorageAction.Models.IStorageTaskPreviewAction

## NOTES

## RELATED LINKS

