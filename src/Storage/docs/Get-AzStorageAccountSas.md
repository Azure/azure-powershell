---
external help file: Az.Storage-help.xml
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/get-azstorageaccountsas
schema: 2.0.0
---

# Get-AzStorageAccountSas

## SYNOPSIS
List SAS credentials of a storage account.

## SYNTAX

### List (Default)
```
Get-AzStorageAccountSas -AccountName <String> -ResourceGroupName <String> -SubscriptionId <String[]>
 [-Parameter <IAccountSasParameters>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ListExpanded
```
Get-AzStorageAccountSas -AccountName <String> -ResourceGroupName <String> -SubscriptionId <String[]>
 [-IPAddressOrRange <String>] [-KeyToSign <String>] -Permission <Permissions> [-Protocol <HttpProtocol>]
 -ResourceType <SignedResourceTypes> -Service <Services> -SharedAccessExpiryTime <DateTime>
 [-SharedAccessStartTime <DateTime>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
List SAS credentials of a storage account.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

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
```

### -IPAddressOrRange
An IP address or a range of IP addresses from which to accept requests.

```yaml
Type: System.String
Parameter Sets: ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyToSign
The key to sign the account SAS token with.

```yaml
Type: System.String
Parameter Sets: ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
The parameters to list SAS credentials of a storage account.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IAccountSasParameters
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Permission
The signed permissions for the account SAS.
Possible values include: Read (r), Write (w), Delete (d), List (l), Add (a), Create (c), Update (u) and Process (p).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Permissions
Parameter Sets: ListExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Protocol
The protocol permitted for a request made with the account SAS.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.HttpProtocol
Parameter Sets: ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -ResourceType
The signed resource types that are accessible with the account SAS.
Service (s): Access to service-level APIs; Container (c): Access to container-level APIs; Object (o): Access to object-level APIs for blobs, queue messages, table entities, and files.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.SignedResourceTypes
Parameter Sets: ListExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Service
The signed services accessible with the account SAS.
Possible values include: Blob (b), Queue (q), Table (t), File (f).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Support.Services
Parameter Sets: ListExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharedAccessExpiryTime
The time at which the shared access signature becomes invalid.

```yaml
Type: System.DateTime
Parameter Sets: ListExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharedAccessStartTime
The time at which the SAS becomes valid.

```yaml
Type: System.DateTime
Parameter Sets: ListExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

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

### System.String
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.storage/get-azstorageaccountsas](https://docs.microsoft.com/en-us/powershell/module/az.storage/get-azstorageaccountsas)

