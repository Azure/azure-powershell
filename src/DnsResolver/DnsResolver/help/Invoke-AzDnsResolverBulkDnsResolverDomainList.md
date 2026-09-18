---
external help file: Az.DnsResolver-help.xml
Module Name: Az.DnsResolver
online version: https://learn.microsoft.com/powershell/module/az.dnsresolver/invoke-azdnsresolverbulkdnsresolverdomainlist
schema: 2.0.0
---

# Invoke-AzDnsResolverBulkDnsResolverDomainList

## SYNOPSIS
Uploads or downloads the list of domains for a DNS Resolver Domain List from a storage link.

## SYNTAX

### BulkExpanded (Default)
```
Invoke-AzDnsResolverBulkDnsResolverDomainList -DnsResolverDomainListName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] -Action <String> -StorageUrl <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### BulkViaJsonString
```
Invoke-AzDnsResolverBulkDnsResolverDomainList -DnsResolverDomainListName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### BulkViaJsonFilePath
```
Invoke-AzDnsResolverBulkDnsResolverDomainList -DnsResolverDomainListName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Bulk
```
Invoke-AzDnsResolverBulkDnsResolverDomainList -DnsResolverDomainListName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] -Parameter <IDnsResolverDomainListBulk>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### BulkViaIdentityExpanded
```
Invoke-AzDnsResolverBulkDnsResolverDomainList -InputObject <IDnsResolverIdentity> [-IfMatch <String>]
 [-IfNoneMatch <String>] -Action <String> -StorageUrl <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### BulkViaIdentity
```
Invoke-AzDnsResolverBulkDnsResolverDomainList -InputObject <IDnsResolverIdentity> [-IfMatch <String>]
 [-IfNoneMatch <String>] -Parameter <IDnsResolverDomainListBulk> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Uploads or downloads the list of domains for a DNS Resolver Domain List from a storage link.

## EXAMPLES

### Example 1: Bulk upload domains to a domain list from a storage blob
```powershell
Invoke-AzDnsResolverBulkDnsResolverDomainList -ResourceGroupName exampleResourceGroupName -DnsResolverDomainListName exampleDomainListName -Action "Upload" -StorageUrl "https://exampleStorageAccount.blob.core.windows.net/exampleContainerName/exampleFileName.txt?sp=r&st=2025-05-16T03:54:40Z&se=2025-05-16T11:54:40Z&spr=https&sv=2024-11-04&sr=b&sig={exampleSasToken}"
```

This cmdlet bulk uploads domains from a storage blob to a DNS resolver domain list.
The storage URL must include a valid SAS token with read permissions.

### Example 2: Bulk download domains from a domain list to a storage blob
```powershell
Invoke-AzDnsResolverBulkDnsResolverDomainList -ResourceGroupName exampleResourceGroupName -DnsResolverDomainListName exampleDomainListName -Action "Download" -StorageUrl "https://exampleStorageAccount.blob.core.windows.net/exampleContainerName/exampleFileName.txt?sp=w&st=2025-05-16T03:54:40Z&se=2025-05-16T11:54:40Z&spr=https&sv=2024-11-04&sr=b&sig={exampleSasToken}"
```

This cmdlet bulk downloads domains from a DNS resolver domain list to a storage blob.
The storage URL must include a valid SAS token with write permissions.
This action is only supported for storage-based domain lists.

## PARAMETERS

### -Action
The action to take in the request, Upload or Download.

```yaml
Type: System.String
Parameter Sets: BulkExpanded, BulkViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

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

### -DnsResolverDomainListName
The name of the DNS resolver domain list.

```yaml
Type: System.String
Parameter Sets: BulkExpanded, BulkViaJsonString, BulkViaJsonFilePath, Bulk
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfMatch
ETag of the resource.
Omit this value to always overwrite the current resource.
Specify the last-seen ETag value to prevent accidentally overwriting any concurrent changes.

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

### -IfNoneMatch
Set to '*' to allow a new resource to be created, but to prevent updating an existing resource.
Other values will be ignored.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.IDnsResolverIdentity
Parameter Sets: BulkViaIdentityExpanded, BulkViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Bulk operation

```yaml
Type: System.String
Parameter Sets: BulkViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Bulk operation

```yaml
Type: System.String
Parameter Sets: BulkViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -Parameter
Describes a DNS resolver domain list for bulk UPLOAD or DOWNLOAD operations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.IDnsResolverDomainListBulk
Parameter Sets: Bulk, BulkViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: BulkExpanded, BulkViaJsonString, BulkViaJsonFilePath, Bulk
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageUrl
The storage account blob file URL to be used in the bulk upload or download request of DNS resolver domain list.

```yaml
Type: System.String
Parameter Sets: BulkExpanded, BulkViaIdentityExpanded
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
Type: System.String
Parameter Sets: BulkExpanded, BulkViaJsonString, BulkViaJsonFilePath, Bulk
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

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.IDnsResolverDomainListBulk

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.IDnsResolverIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.IDnsResolverDomainList

## NOTES

## RELATED LINKS
