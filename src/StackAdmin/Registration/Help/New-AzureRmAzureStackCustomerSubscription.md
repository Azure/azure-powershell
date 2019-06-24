---
external help file: Microsoft.Azure.Commands.AzureStack.Registration.dll-Help.xml
Module Name: AzureRM.AzureStack.Registration
online version:
schema: 2.0.0
---

# New-AzureRmAzureStackCustomerSubscription

## SYNOPSIS
Create a customer subscription under an Azure Stack registration.

## SYNTAX

```
New-AzureRmAzureStackCustomerSubscription -ResourceGroupName <String> -RegistrationName <String>
 -CustomerSubscriptionName <String> -TenantId <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a customer subscription under an Azure Stack registration.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzureRmAzureStackCustomerSubscription -ResourceGroupName "TestResourceGroup" -Name "TestAzureStackRegistration" -CustomerSubscriptionName "TestUserSubscriptionName" -TenantId "00000000-0000-0000-0000-000000000000"
```

Create a link of customer subscription named `TestUserSubscriptionName` of tenant `00000000-0000-0000-0000-000000000000` with an Azure Stack registration `TestAzureStackRegistration` under resource group `TestResourceGroup`.

## PARAMETERS

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

### -CustomerSubscriptionName
Name of Azure Stack customer subscription.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistrationName
Name of Azure Stack registration.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of resource group where Azure Stack registration is created.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TenantId
Azure Stack tenant ID.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.AzureStack.Models.CustomerSubscriptionResult

## NOTES

## RELATED LINKS
