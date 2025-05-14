---
external help file:
Module Name: Az.Support
online version: https://learn.microsoft.com/powershell/module/az.support/new-azsupportfileandupload
schema: 2.0.0
---

# New-AzSupportFileAndUpload

## SYNOPSIS
Creates and uploads a new file under a workspace for the specified subscription.

## SYNTAX

```
New-AzSupportFileAndUpload -WorkspaceName <String> -FilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates and uploads a new file under a workspace for the specified subscription.

## EXAMPLES

### Example 1: Create and upload a file to a file workspace
```powershell
New-AzSupportFileAndUpload -WorkspaceName "testworkspace" -FilePath "C:\path\to\file\test.txt"
```

```output
ChunkSize                    : 4
CreatedOn                    : 2/9/2024 4:06:13 PM
FileSize                     : 4
Id                           : /subscriptions/3bb7379e-e102-4603-a59c-60f5ca39ec55/providers/Microsoft.Support/fileWorkspaces/testworkspace/files/test.txt
Name                         : test.txt
NumberOfChunk                : 1
ResourceGroupName            :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Support/files
```

Create a new file and upload content in a file workspace for an Azure subscription.

### Example 2: Create and upload a file to a support ticket
```powershell
New-AzSupportFileAndUpload -WorkspaceName "2402084010005835" -FilePath "C:\path\to\file\test.txt"
```

```output
ChunkSize                    : 4
CreatedOn                    : 2/9/2024 4:06:13 PM
FileSize                     : 4
Id                           : /subscriptions/3bb7379e-e102-4603-a59c-60f5ca39ec55/providers/Microsoft.Support/fileWorkspaces/2402084010005835/files/test.txt
Name                         : test.txt
NumberOfChunk                : 1
ResourceGroupName            :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Support/files
```

Create a new file and upload content to a support ticket in an Azure subscription.

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

### -FilePath
Path of the file to be uploaded

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure subscription Id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
File workspace name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: FileWorkspaceName

Required: True
Position: Named
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.IFileDetails

## NOTES

## RELATED LINKS

