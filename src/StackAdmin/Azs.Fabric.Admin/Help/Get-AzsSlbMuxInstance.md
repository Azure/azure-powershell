---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Get-AzsSlbMuxInstance

## SYNOPSIS
Get software load balanacer multiplexer instances at a certain location.

## SYNTAX

### SlbMuxInstances_List (Default)
```
Get-AzsSlbMuxInstance [-Filter <String>] [-Skip <Int32>] -Location <String> [-Top <Int32>] [<CommonParameters>]
```

### SlbMuxInstances_Get
```
Get-AzsSlbMuxInstance -SlbMuxInstance <String> -Location <String> [<CommonParameters>]
```

## DESCRIPTION
Get software load balanacer multiplexer instances at a certain location.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzsSlbMuxInstance -Location "local"

BgpPeers                 ConfigurationState Type                                                   VirtualServer Name
--------                 ------------------ ----                                                   ------------- ----
{BGPGateway-64000-64001} Success            Microsoft.Fabric.Admin/fabricLocations/slbMuxInstances AzS-SLB01     AzS-SLB01
{BGPGateway-64000-64001} Success            Microsoft.Fabric.Admin/fabricLocations/slbMuxInstances AzS-SLB02     AzS-SLB02
```

Get all software load balancer multiplexer instance at a location.

### Example 2
```
PS C:\> Get-AzsSlbMuxInstance -Location "local" -SlbMuxInstance "AzS-SLB01"

BgpPeers                 ConfigurationState Type                                                   VirtualServer Name
--------                 ------------------ ----                                                   ------------- ----
{BGPGateway-64000-64001} Success            Microsoft.Fabric.Admin/fabricLocations/slbMuxInstances AzS-SLB01     AzS-SLB01
```

Get a specific software load balancer multiplexer instance at a location given a name.

## PARAMETERS

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: SlbMuxInstances_List
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location of the resource.

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

### -Skip
Skip the first N items as specified by the parameter value.

```yaml
Type: Int32
Parameter Sets: SlbMuxInstances_List
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### -SlbMuxInstance
Name of a SLB Mux instance.

```yaml
Type: String
Parameter Sets: SlbMuxInstances_Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Return the top N items as specified by the parameter value.
Applies after the -Skip parameter.

```yaml
Type: Int32
Parameter Sets: SlbMuxInstances_List
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Fabric.Admin.Models.SlbMuxInstance

## NOTES

## RELATED LINKS

