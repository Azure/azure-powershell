---
external help file:
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/get-azstorageaccountservicesas
schema: 2.0.0
---

# Get-AzStorageAccountServiceSas

## SYNOPSIS
List service SAS credentials of a specific resource.

## SYNTAX

### List1 (Default)
```
Get-AzStorageAccountServiceSas -AccountName <String> -ResourceGroupName <String> -SubscriptionId <String[]>
 [-Parameter <IServiceSasParameters>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ListExpanded1
```
Get-AzStorageAccountServiceSas -AccountName <String> -ResourceGroupName <String> -SubscriptionId <String[]>
 [-CacheControl <String>] [-CanonicalizedResource <String>] [-ContentDisposition <String>]
 [-ContentEncoding <String>] [-ContentLanguage <String>] [-ContentType <String>] [-IPAddressOrRange <String>]
 [-Identifier <String>] [-KeyToSign <String>] [-PartitionKeyEnd <String>] [-PartitionKeyStart <String>]
 [-Permission <Permissions>] [-Protocol <HttpProtocol>] [-Resource <SignedResource>] [-RowKeyEnd <String>]
 [-RowKeyStart <String>] [-SharedAccessExpiryTime <DateTime>] [-SharedAccessStartTime <DateTime>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
List service SAS credentials of a specific resource.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CacheControl
The response header override for cache control.

```yaml
Type: System.String
Parameter Sets: ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CanonicalizedResource
The canonical path to the signed resource.

```yaml
Type: System.String
Parameter Sets: ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContentDisposition
The response header override for content disposition.

```yaml
Type: System.String
Parameter Sets: ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContentEncoding
The response header override for content encoding.

```yaml
Type: System.String
Parameter Sets: ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContentLanguage
The response header override for content language.

```yaml
Type: System.String
Parameter Sets: ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ContentType
The response header override for content type.

```yaml
Type: System.String
Parameter Sets: ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Identifier
A unique value up to 64 characters in length that correlates to an access policy specified for the container, queue, or table.

```yaml
Type: System.String
Parameter Sets: ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPAddressOrRange
An IP address or a range of IP addresses from which to accept requests.

```yaml
Type: System.String
Parameter Sets: ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyToSign
The key to sign the account SAS token with.

```yaml
Type: System.String
Parameter Sets: ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
The parameters to list service SAS credentials of a specific resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IServiceSasParameters
Parameter Sets: List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -PartitionKeyEnd
The end of partition key.

```yaml
Type: System.String
Parameter Sets: ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PartitionKeyStart
The start of partition key.

```yaml
Type: System.String
Parameter Sets: ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Permission
The signed permissions for the service SAS.
Possible values include: Read (r), Write (w), Delete (d), List (l), Add (a), Create (c), Update (u) and Process (p).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Permissions
Parameter Sets: ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Protocol
The protocol permitted for a request made with the account SAS.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.HttpProtocol
Parameter Sets: ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Resource
The signed services accessible with the service SAS.
Possible values include: Blob (b), Container (c), File (f), Share (s).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.SignedResource
Parameter Sets: ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group within the user's subscription.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RowKeyEnd
The end of row key.

```yaml
Type: System.String
Parameter Sets: ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RowKeyStart
The start of row key.

```yaml
Type: System.String
Parameter Sets: ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SharedAccessExpiryTime
The time at which the shared access signature becomes invalid.

```yaml
Type: System.DateTime
Parameter Sets: ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SharedAccessStartTime
The time at which the SAS becomes valid.

```yaml
Type: System.DateTime
Parameter Sets: ListExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Gets subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IServiceSasParameters

## OUTPUTS

### System.String

## ALIASES

## RELATED LINKS

