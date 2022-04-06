---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:
schema: 2.0.0
---

# New-AzPrivateEndpointIpConfiguration

## SYNOPSIS
Creates an IpConfiguration object for private endpoint.

## SYNTAX

```
New-AzPrivateEndpointIpConfiguration -Name <String> [-GroupId <String>] [-MemberName <String>]
 -PrivateIpAddress <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzPrivateEndpointIpConfiguration** cmdlet creates an IpConfiguration object for private endpoint.

## EXAMPLES

### Example 1
```powershell
New-AzPrivateEndpointIpConfiguration -Name "IpConfigurationForPrivateEndpoint" -PrivateIPAddress "10.0.0.10"
```

This example creates an IpConfiguration object used for private endpoint.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GroupId
The ID of a group that the private endpoint connects to.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MemberName
The member name of a group that the private endpoint connects to.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the private endpoint IP configuration.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateIpAddress
The private ip address of the private endpoint's subnet.

```yaml
Type: String
Parameter Sets: (All)
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSPrivateEndpointIPConfiguration

## NOTES

## RELATED LINKS
