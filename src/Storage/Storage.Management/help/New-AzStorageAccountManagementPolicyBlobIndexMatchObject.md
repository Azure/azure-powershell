---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.Management.dll-Help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/Az.storage/new-Azstorageaccountmanagementpolicyblobindexmatchobject
schema: 2.0.0
---

# New-AzStorageAccountManagementPolicyBlobIndexMatchObject

## SYNOPSIS
Creates a ManagementPolicy BlobIndexMatch object, which can be used in New-AzStorageAccountManagementPolicyFilter.

## SYNTAX

```
New-AzStorageAccountManagementPolicyBlobIndexMatchObject [-Name <String>] [-Value <String>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzStorageAccountManagementPolicyBlobIndexMatchObject** cmdlet creates a ManagementPolicy BlobIndexMatch object, which can be used in New-AzStorageAccountManagementPolicyFilter.

## EXAMPLES

### Example 1: Creates 2 ManagementPolicy BlobIndexMatch object3, then add them to a management policy rule filter
<!-- Skip: Output cannot be splitted from code -->


```
$blobindexmatch1 = New-AzStorageAccountManagementPolicyBlobIndexMatchObject -Name "tag1" -Value "value1"
$blobindexmatch1

Name Op Value 
---- -- ----- 
tag1 == value1

$blobindexmatch2 = New-AzStorageAccountManagementPolicyBlobIndexMatchObject -Name "tag2" -Value "value2"

New-AzStorageAccountManagementPolicyFilter -PrefixMatch prefix1,prefix2 -BlobType blockBlob `
        -BlobIndexMatch $blobindexmatch1,$blobindexmatch2

PrefixMatch        BlobTypes   BlobIndexMatch
-----------        ---------   --------------
{prefix1, prefix2} {blockBlob} {tag1, tag2}
```

This command creates 2 ManagementPolicy BlobIndexMatch objects, then add themto a management policy rule filter.

## PARAMETERS

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
Gets or sets this is the filter tag name, it can have 1 - 128 characters

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
Gets or sets this is the filter tag value field used for tag based filtering, it can have 0 - 256 characters.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSTagFilter

## NOTES

## RELATED LINKS
