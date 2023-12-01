---
external help file:
Module Name: Az.Support
online version: https://learn.microsoft.com/powershell/module/az.support/invoke-azsupportuploadfilesnosubscription
schema: 2.0.0
---

# Invoke-AzSupportUploadFilesNoSubscription

## SYNOPSIS
This API allows you to upload content to a file

## SYNTAX

### UploadExpanded (Default)
```
Invoke-AzSupportUploadFilesNoSubscription -FileName <String> -FileWorkspaceName <String>
 [-ChunkIndex <Single>] [-Content <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Upload
```
Invoke-AzSupportUploadFilesNoSubscription -FileName <String> -FileWorkspaceName <String>
 -UploadFile <IUploadFile> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UploadViaIdentity
```
Invoke-AzSupportUploadFilesNoSubscription -InputObject <ISupportIdentity> -UploadFile <IUploadFile>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UploadViaIdentityExpanded
```
Invoke-AzSupportUploadFilesNoSubscription -InputObject <ISupportIdentity> [-ChunkIndex <Single>]
 [-Content <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UploadViaIdentityFileWorkspace
```
Invoke-AzSupportUploadFilesNoSubscription -FileName <String> -FileWorkspaceInputObject <ISupportIdentity>
 -UploadFile <IUploadFile> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UploadViaIdentityFileWorkspaceExpanded
```
Invoke-AzSupportUploadFilesNoSubscription -FileName <String> -FileWorkspaceInputObject <ISupportIdentity>
 [-ChunkIndex <Single>] [-Content <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UploadViaJsonFilePath
```
Invoke-AzSupportUploadFilesNoSubscription -FileName <String> -FileWorkspaceName <String>
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UploadViaJsonString
```
Invoke-AzSupportUploadFilesNoSubscription -FileName <String> -FileWorkspaceName <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
This API allows you to upload content to a file

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

### -ChunkIndex
Index of the uploaded chunk (Index starts at 0)

```yaml
Type: System.Single
Parameter Sets: UploadExpanded, UploadViaIdentityExpanded, UploadViaIdentityFileWorkspaceExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Content
File Content in base64 encoded format

```yaml
Type: System.String
Parameter Sets: UploadExpanded, UploadViaIdentityExpanded, UploadViaIdentityFileWorkspaceExpanded
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

### -FileName
File Name

```yaml
Type: System.String
Parameter Sets: Upload, UploadExpanded, UploadViaIdentityFileWorkspace, UploadViaIdentityFileWorkspaceExpanded, UploadViaJsonFilePath, UploadViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileWorkspaceInputObject
Identity Parameter
To construct, see NOTES section for FILEWORKSPACEINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity
Parameter Sets: UploadViaIdentityFileWorkspace, UploadViaIdentityFileWorkspaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -FileWorkspaceName
File WorkspaceName

```yaml
Type: System.String
Parameter Sets: Upload, UploadExpanded, UploadViaJsonFilePath, UploadViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity
Parameter Sets: UploadViaIdentity, UploadViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Upload operation

```yaml
Type: System.String
Parameter Sets: UploadViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Upload operation

```yaml
Type: System.String
Parameter Sets: UploadViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -UploadFile
File content associated with the file under a workspace.
To construct, see NOTES section for UPLOADFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Models.IUploadFile
Parameter Sets: Upload, UploadViaIdentity, UploadViaIdentityFileWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.IUploadFile

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

