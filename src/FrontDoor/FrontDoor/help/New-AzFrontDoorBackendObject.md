---
external help file: Az.FrontDoor-help.xml
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/Az.FrontDoor/new-azfrontdoorbackendobject
schema: 2.0.0
---

# New-AzFrontDoorBackendObject

## SYNOPSIS
Create an in-memory object for Backend.

## SYNTAX

```
New-AzFrontDoorBackendObject [-Address <String>] [-BackendHostHeader <String>] [-EnabledState <String>]
 [-HttpPort <Int32>] [-HttpsPort <Int32>] [-Priority <Int32>] [-PrivateLinkAlias <String>]
 [-PrivateLinkApprovalMessage <String>] [-PrivateLinkLocation <String>] [-PrivateLinkResourceId <String>]
 [-Weight <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Backend.

## EXAMPLES

### Example 1
```powershell
New-AzFrontDoorBackendObject -Address "contoso1.azurewebsites.net"
```

```output
Address                    : contoso1.azurewebsites.net
BackendHostHeader          : contoso1.azurewebsites.net
EnabledState               : Enabled
HttpPort                   : 80
HttpsPort                  : 443
Priority                   : 1
PrivateEndpointStatus      :
PrivateLinkAlias           :
PrivateLinkApprovalMessage :
PrivateLinkLocation        :
PrivateLinkResourceId      :
Weight                     : 50
```

Create a PSBackend object for Front Door creation

## PARAMETERS

### -Address
Location of the backend (IP address or FQDN).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackendHostHeader
The value to use as the host header sent to the backend.
If blank or unspecified, this defaults to the incoming host.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnabledState
Whether to enable use of this backend.
Permitted values are 'Enabled' or 'Disabled'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpPort
The HTTP TCP port number.
Must be between 1 and 65535.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpsPort
The HTTPS TCP port number.
Must be between 1 and 65535.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Priority
Priority to use for load balancing.
Higher priorities will not be used for load balancing if any lower priority backend is healthy.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkAlias
The Alias of the Private Link resource.
Populating this optional field indicates that this backend is 'Private'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkApprovalMessage
A custom message to be included in the approval request to connect to the Private Link.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkLocation
The location of the Private Link resource.
Required only if 'privateLinkResourceId' is populated.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkResourceId
The Resource Id of the Private Link resource.
Populating this optional field indicates that this backend is 'Private'.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Weight
Weight of this endpoint for load balancing purposes.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.Backend

## NOTES

## RELATED LINKS
