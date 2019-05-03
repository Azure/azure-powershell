---
external help file: Az.Network-help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/test-azdnsnameavailability
schema: 2.0.0
---

# Test-AzDnsNameAvailability

## SYNOPSIS
Checks whether a domain name in the cloudapp.azure.com zone is available for use.

## SYNTAX

### CheckSubscriptionIdViaHost (Default)
```
Test-AzDnsNameAvailability -Location <String> -DomainNameLabel <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Check
```
Test-AzDnsNameAvailability -Location <String> -SubscriptionId <String> -DomainNameLabel <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Checks whether a domain name in the cloudapp.azure.com zone is available for use.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

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

### -DomainNameLabel
The domain name to be verified.
It must conform to the following regular expression: ^\[a-z\]\[a-z0-9-\]{1,61}\[a-z0-9\]$.

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

### -Location
The location of the domain name.

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

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Check
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Boolean
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/test-azdnsnameavailability](https://docs.microsoft.com/en-us/powershell/module/az.network/test-azdnsnameavailability)

