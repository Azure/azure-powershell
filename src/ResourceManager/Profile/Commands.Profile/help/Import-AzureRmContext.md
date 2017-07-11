---
external help file: Microsoft.Azure.Commands.Profile.dll-Help.xml
online version: 
schema: 2.0.0
---

# Import-AzureRmContext

## SYNOPSIS
Loads Azure authentication information from a file.

## SYNTAX

### InMemoryProfile
```
Import-AzureRmContext [-AzureContext] <AzureRMProfile> [-WhatIf] [-Confirm]
```

### ProfileFromDisk
```
Import-AzureRmContext [-Path] <String> [-WhatIf] [-Confirm]
```

## DESCRIPTION
The Import-AzureRmContext cmdlet loads authentication information from a file to set the Azure environment and context.
Cmdlets that you run in the current session use this information to authenticate requests to Azure Resource Manager.

## EXAMPLES

### Example 1: Importing a context from a AzureRmProfile
```
PS C:\> Import-AzureRmContext -AzureContext (Add-AzureRmAccount)

Environment           : AzureCloud
Account               : test@outlook.com
TenantId              : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SubscriptionId        : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SubscriptionName      : Test Subscription
CurrentStorageAccount :
```

This example imports a context from a PSAzureProfile that is passed through to the cmdlet.

### Example 2: Importing a context from a JSON file
```
PS C:\> Import-AzureRmContext -Path C:\test.json

Environment           : AzureCloud
Account               : test@outlook.com
TenantId              : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SubscriptionId        : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SubscriptionName      : Test Subscription
CurrentStorageAccount :
```

This example selects a context from a JSON file that is passed through to the cmdlet. This JSON file can be created from Save-AzureRmContext.

## PARAMETERS

### -AzureContext
Specifies the Azure context from which this cmdlet reads.
If you do not specify a context, this cmdlet reads from the local default context.

```yaml
Type: AzureRMProfile
Parameter Sets: InMemoryProfile
Aliases: Profile

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Path
Specifies the path to context information saved by using Save-AzureRMContext.

```yaml
Type: String
Parameter Sets: ProfileFromDisk
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### Microsoft.Azure.Commands.Common.Authentication.Models.AzureRMProfile
System.String


## OUTPUTS

### Microsoft.Azure.Commands.Profile.Models.PSAzureProfile


## NOTES

## RELATED LINKS

