---
external help file: Microsoft.Azure.Commands.AzureStack.Registration.dll-Help.xml
Module Name: AzureRM.AzureStack.Registration
online version:
schema: 2.0.0
---

# Get-AzureRmAzureStackCustomerSubscription

## SYNOPSIS
Get a customer subscription or list customer subscriptions of an Azure Stack registration.

## SYNTAX

```
Get-AzureRmAzureStackCustomerSubscription [-ResourceGroupName <String>] [-RegistrationName <String>]
 [-CustomerSubscriptionName <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Get the customer subscription of an Azure Stack registration by the registration name and the subscription name, or list the customer subscriptions of an Azure Stack registration by the registration name.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzureRmAzureStackCustomerSubscription -ResourceGroupName "TestResourceGroup" -Name "TestAzureStackRegistration"
```

List the customer subscriptions of an Azure Stack registration by its registration name.

## PARAMETERS

### -CustomerSubscriptionName
Name of Azure Stack customer subscription.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
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

Required: False
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

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
