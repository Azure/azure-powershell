---
external help file: Microsoft.Azure.Commands.ServiceBus.dll-Help.xml
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.servicebus/test-azurermservicebusname
schema: 2.0.0
---

# Test-AzureRmServiceBusName

## SYNOPSIS
Checks the Availability of the given NameSpace Name

## SYNTAX

```
Test-AzureRmServiceBusName [-Namespace] <String>
```

## DESCRIPTION
The **Test-AzureRmServiceBusName** Cmdlet Check Availability of the NameSpace Name

## EXAMPLES

### Example 1
```
PS C:\> Test-AzureRmServiceBusName -Namespace TestingtheAvailability
```

### Example 2
```
PS C:\> Test-AzureRmServiceBusName -Namespace Testi
```

### Example 3
```
PS C:\> Test-AzureRmServiceBusName -Namespace Test123
```

Returns the status on availability of the namespace name

## PARAMETERS

### -Namespace
ServiceBus Namespace Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```
### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### -Namespace
 System.String

## OUTPUTS

### [Microsoft.Azure.Commands.ServiceBus.Models.CheckNameAvailabilityResultAttributes, Microsoft.Azure.Commands.ServiceBus, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null]

### Example 1
NameAvailable Reason Message
------------- ------ -------
         True   None

### Example 2
NameAvailable      Reason Message
-------------      ------ -------
        False InvalidName The specified service namespace is invalid.

### Example 3
NameAvailable    Reason Message
-------------    ------ -------
        False NameInUse The specified service namespace is not available.

## NOTES

## RELATED LINKS
