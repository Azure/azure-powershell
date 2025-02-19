---
external help file:
Module Name: Az.Support
online version: https://learn.microsoft.com/powershell/module/az.support/get-azsupportfile
schema: 2.0.0
---

# Get-AzSupportFile

## SYNOPSIS
Returns details of a specific file in a work space.

## SYNTAX

### List (Default)
```
Get-AzSupportFile -WorkspaceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzSupportFile -Name <String> -WorkspaceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSupportFile -InputObject <ISupportIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityFileWorkspace
```
Get-AzSupportFile -FileWorkspaceInputObject <ISupportIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns details of a specific file in a work space.

## EXAMPLES

### Example 1: List all files from a file workspace
```powershell
Get-AzSupportFile -WorkspaceName "testworkspace"
```

```output
Name      CreatedOn           ChunkSize FileSize
----      ---------           --------- --------
test.txt  2/9/2024 3:53:15 PM 4         4
test2.txt 2/9/2024 3:53:29 PM 4         4
```

Lists all the Files information under a workspace for an Azure subscription.

### Example 2: Get details of a file in a file workspace
```powershell
Get-AzSupportFile -Name "test.txt" -WorkspaceName "testworkspace"
```

```output
ChunkSize                    : 4
CreatedOn                    : 2/9/2024 3:53:15 PM
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

Returns details of a specific file in a workspace.

### Example 3: List all files from a support ticket
```powershell
Get-AzSupportFile -WorkspaceName "2402084010005835"
```

```output
Name      CreatedOn           ChunkSize FileSize
----      ---------           --------- --------
test.txt  2/9/2024 3:53:15 PM 4         4
test2.txt 2/9/2024 3:53:29 PM 4         4
```

Lists all the Files information under a support ticket for an Azure subscription.

### Example 2: Get details of a file under a support ticket
```powershell
Get-AzSupportFile -Name "test.txt" -WorkspaceName "2402084010005835"
```

```output
ChunkSize                    : 4
CreatedOn                    : 2/9/2024 3:53:15 PM
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

Returns details of a specific file under a support ticket.

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

### -FileWorkspaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity
Parameter Sets: GetViaIdentityFileWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
File Name

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityFileWorkspace
Aliases: FileName

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

### -WorkspaceName
File Workspace Name

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases: FileWorkspaceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.ISupportIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Support.Models.IFileDetails

## NOTES

## RELATED LINKS

