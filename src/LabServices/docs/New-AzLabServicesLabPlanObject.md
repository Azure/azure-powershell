---
external help file:
Module Name: Az.LabServices
online version: https://docs.microsoft.com/powershell/module/az.LabServices/new-AzLabServicesLabPlanObject
schema: 2.0.0
---

# New-AzLabServicesLabPlanObject

## SYNOPSIS
Create a in-memory object for Lab Services Lab Plan.

## SYNTAX

```
New-AzLabServicesLabPlanObject -AllowedRegion <String[]>
 -DefaultConnectionProfileClientRdpAccess <ConnectionType>
 -DefaultConnectionProfileClientSshAccess <ConnectionType>
 -DefaultConnectionProfileWebRdpAccess <ConnectionType> -DefaultConnectionProfileWebSshAccess <ConnectionType>
 -Location <String> [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for Lab Services Lab Plan.

## EXAMPLES

### Example 1: Create new lab plan body.
```powershell
PS C:\> $body = New-AzLabServicesLabPlanObject -AllowedRegion @("westus2") -Location "westus2" `
    -DefaultConnectionProfileClientRDPAccess "Public" `
    -DefaultConnectionProfileClientSSHAccess "None" `
    -DefaultConnectionProfileWebSSHAccess "None" `
    -DefaultConnectionProfileWebRDPAccess "None" 
PS C:\> New-AzLabServicesLabPlan -Name "testplan" -ResourceGroupName "Group Name" -Body $body


Location Name
-------- ----
westus2  testplan
```

This cmdlet creates the minimum information to create a lab plan using the body parameter.
Defaulting to not setting shutdown options.

## PARAMETERS

### -AllowedRegion


```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultConnectionProfileClientRdpAccess


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultConnectionProfileClientSshAccess


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultConnectionProfileWebRdpAccess


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultConnectionProfileWebSshAccess


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.ConnectionType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location


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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ILabPlan

## NOTES

ALIASES

## RELATED LINKS

