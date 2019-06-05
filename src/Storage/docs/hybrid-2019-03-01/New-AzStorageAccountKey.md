---
external help file:
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/new-azstorageaccountkey
schema: 2.0.0
---

# New-AzStorageAccountKey

## SYNOPSIS
Regenerates one of the access keys for the specified storage account.

## SYNTAX

### Regenerate1 (Default)
```
New-AzStorageAccountKey -AccountName <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-RegenerateKey <IStorageAccountRegenerateKeyParameters>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RegenerateExpanded1
```
New-AzStorageAccountKey -AccountName <String> -ResourceGroupName <String> -SubscriptionId <String>
 -KeyName <String> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RegenerateViaIdentityExpanded1
```
New-AzStorageAccountKey -InputObject <IStorageIdentity> -KeyName <String> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RegenerateViaIdentity1
```
New-AzStorageAccountKey -InputObject <IStorageIdentity>
 [-RegenerateKey <IStorageAccountRegenerateKeyParameters>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Regenerates one of the access keys for the specified storage account.

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
Parameter Sets: Regenerate1, RegenerateExpanded1
Aliases:

Required: True
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
Parameter Sets: RegenerateViaIdentityExpanded1, RegenerateViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -KeyName
The name of storage keys that want to be regenerated, possible values are key1, key2.

```yaml
Type: System.String
Parameter Sets: RegenerateExpanded1, RegenerateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RegenerateKey
The parameters used to regenerate the storage account key.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IStorageAccountRegenerateKeyParameters
Parameter Sets: Regenerate1, RegenerateViaIdentity1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group within the user's subscription.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Regenerate1, RegenerateExpanded1
Aliases:

Required: True
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
Type: System.String
Parameter Sets: Regenerate1, RegenerateExpanded1
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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IStorageAccountRegenerateKeyParameters

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20171001.IStorageAccountKey

## ALIASES

## RELATED LINKS

