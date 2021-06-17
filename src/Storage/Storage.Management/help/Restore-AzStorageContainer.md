---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
online version: https://docs.microsoft.com/powershell/module/az.storage/restore-azstoragecontainer
schema: 2.0.0
---

# Restore-AzStorageContainer

## SYNOPSIS
Restores a previously deleted Azure storage blob container.

## SYNTAX

```
Restore-AzStorageContainer [-Name] <String> [-VersionId] <String> [-Context <IStorageContext>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Restore-AzStorageContainer** cmdlet restores a previously deleted Azure storage blob container.
This cmdlet only works after enabled Container softdelete with Enable-AzStorageBlobDeleteRetentionPolicy.

## EXAMPLES

### Example 1: List containers include deleted containers, and restore all deleted containers with pipeline
```
PS C:\> Get-AzStorageContainer -IncludeDeleted -Context $ctx | ? { $_.IsDeleted } | Restore-AzStorageContainer

   Storage Account Name: storageaccountname

Name                 PublicAccess         LastModified                   IsDeleted  VersionId                                                                                                                                                                                                                                                         
----                 ------------         ------------                   ---------  ---------                                                                                                                                                                    
container1           Off
container2           Off
```

This command lists all containers include deleted containers, filter out all the deleted containers, then restore all deleted container to the same container name with pipeline.

### Example 2: Restore a single deleted container
```
PS C:\> Get-AzStorageContainer -IncludeDeleted -Context $ctx | ? { $_.IsDeleted } 

   Storage Account Name: storageaccountname

Name                 PublicAccess         LastModified                   IsDeleted  VersionId                                                                                                                                                                                                                                                      
----                 ------------         ------------                   ---------  ---------                                                                                                                                                                   
container1                                8/28/2020 10:18:13 AM +00:00   True       01D685BC91A88F22                                                                                                                                                                                                                                                                
container2                                9/4/2020 12:52:37 PM +00:00    True       01D67D248986B6DA  

PS C:\> Restore-AzStorageContainer -Name container1 -VersionId 01D685BC91A88F22 -Context $ctx

   Storage Account Name: storageaccountname

Name                 PublicAccess         LastModified                   IsDeleted  VersionId                                                                                                                                                                                                                                                     
----                 ------------         ------------                   ---------  ---------                                                                                                                                                                                                                                                        
container1           Off
```

This first command lists all containers and filter out deleted containers.
The secondary command restores a deleted container by manually input the parameters.

## PARAMETERS

### -Context
Azure Storage Context Object

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the previously deleted container.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: N, Container, DeletedContainerName

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -VersionId
The version of the previously deleted container.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DeletedContainerVersion, 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
