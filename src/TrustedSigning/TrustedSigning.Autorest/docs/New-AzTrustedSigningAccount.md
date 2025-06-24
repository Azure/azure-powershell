---
external help file:
Module Name: Az.TrustedSigning
online version: https://learn.microsoft.com/powershell/module/az.trustedsigning/new-aztrustedsigningaccount
schema: 2.0.0
---

# New-AzTrustedSigningAccount

## SYNOPSIS
create a trusted Signing Account.

## SYNTAX

### CreateExpanded (Default)
```
New-AzTrustedSigningAccount -AccountName <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-SkuName <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzTrustedSigningAccount -AccountName <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzTrustedSigningAccount -AccountName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
create a trusted Signing Account.

## EXAMPLES

### Example 1: Create A New Trusted Signing Account With A Basic Sku
```powershell
New-AzTrustedSigningAccount -AccountName test -ResourceGroupName rg-test -Location eastus -SkuName Basic
```

```output
AccountUri                         Id                                                                                                                                    Location Name   ProvisioningState ResourceGroupName RetryAfter SkuName SystemDataCreatedAt  SystemDataCreatedBy
----------                         --                                                                                                                                    -------- ----   ----------------- ----------------- ---------- ------- -------------------  -------------------
https://eus.codesigning.azure.net/ /subscriptions/66dc869d-771b-4f60-84c1-4964b5f4f5f2/resourceGroups/rg-test/providers/Microsoft.CodeSigning/codeSigningAccounts/test   eastus   test   Succeeded         rg-test                      Basic   2/3/2025 10:35:58 PM test@example.com
```

This command creates a new trusted signing account with a Basic SKU

### Example 2: Create A New Trusted Signing Account With A Premium Sku
```powershell
New-AzTrustedSigningAccount -AccountName test -ResourceGroupName rg-test -Location eastus -SkuName Premium
```

```output
AccountUri                         Id                                                                                                                                    Location Name   ProvisioningState ResourceGroupName RetryAfter SkuName SystemDataCreatedAt  SystemDataCreatedBy
----------                         --                                                                                                                                    -------- ----   ----------------- ----------------- ---------- ------- -------------------  -------------------
https://eus.codesigning.azure.net/ /subscriptions/66dc869d-771b-4f60-84c1-4964b5f4f5f2/resourceGroups/rg-test/providers/Microsoft.CodeSigning/codeSigningAccounts/test   eastus   test   Succeeded         rg-test                      Premium 2/3/2025 10:35:58 PM test@example.com
```

This command creates a new trusted signing account with a Premium SKU

## PARAMETERS

### -AccountName
Trusted Signing account name.

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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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

### -ResourceGroupName
The name of the resource group.
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

### -SkuName
Name of the SKU.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.TrustedSigning.Models.ICodeSigningAccount

## NOTES

## RELATED LINKS

