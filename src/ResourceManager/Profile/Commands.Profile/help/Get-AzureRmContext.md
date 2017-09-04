---
external help file: Microsoft.Azure.Commands.Profile.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmContext

## SYNOPSIS
Gets the metadata used to authenticate Azure Resource Manager requests.

## SYNTAX

### GetSingleContext (Default)
```
Get-AzureRmContext [-DefaultProfile <IAzureContextContainer>] [-Name <String>] [<CommonParameters>]
```

### ListAllContexts
```
Get-AzureRmContext [-ListAvailable] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzureRmContext cmdlet gets the current metadata used to authenticate Azure Resource Manager requests.

This cmdlet gets the Active Directory account, Active Directory tenant, Azure subscription, and the targeted Azure environment.
Azure Resource Manager cmdlets use these settings by default when making Azure Resource Manager requests.

## EXAMPLES

### Example 1: Getting the current context
```
PS C:\> Add-AzureRmAccount
PS C:\> Get-AzureRmContext

Environment           : AzureCloud
Account               : test@outlook.com
TenantId              : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
SubscriptionId        : yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
SubscriptionName      : Test Subscription
CurrentStorageAccount :
```

In this example we are logging into our account with an Azure subscription using Add-AzureRmAccount, and then we are getting the context of the current session by calling Get-AzureRmContext.

## PARAMETERS

### -DefaultProfile
The credeetnails, tenant and subscription used for communication with azure```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ListAvailable
List all available contexts in the current session.```yaml
Type: SwitchParameter
Parameter Sets: ListAllContexts
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the context```yaml
Type: String
Parameter Sets: GetSingleContext
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### PSAzureContext
This cmdlet returns the account, tenant, and subscription used by Azure Resource Manager cmdlets.

## NOTES

## RELATED LINKS

[Set-AzureRMContext](./Set-AzureRMContext.md)

