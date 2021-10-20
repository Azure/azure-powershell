---
external help file:
Module Name: Az.LabServices
online version: https://docs.microsoft.com/powershell/module/az.LabServices/new-AzLabServicesLabObject
schema: 2.0.0
---

# New-AzLabServicesLabObject

## SYNOPSIS
Create a in-memory object for Lab Services Lab.

## SYNTAX

```
New-AzLabServicesLabObject -AdditionalCapabilityInstallGpuDriver <EnableState>
 -AdminUserPassword <SecureString> -AdminUserUsername <String>
 -ConnectionProfileClientRdpAccess <ConnectionType> -ConnectionProfileClientSshAccess <ConnectionType>
 -ImageReferenceOffer <String> -ImageReferencePublisher <String> -ImageReferenceSku <String>
 -ImageReferenceVersion <String> -Location <String> -SecurityProfileOpenAccess <EnableState>
 -SkuCapacity <Int32> -SkuName <String> -Title <String> -VirtualMachineProfileCreateOption <CreateOption>
 -VirtualMachineProfileUseSharedPassword <EnableState> [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for Lab Services Lab.

## EXAMPLES

### Example 1: Create lab body.
```powershell
PS C:\> $labBody = New-AzLabServicesLabObject -Name "rbestALab" `
	-Location "westcentralus" `
	-Title "rbestALab Title"`
	-AdditionalCapabilityInstallGpuDriver "Disabled" `
	-AdminUserPassword $(ConvertTo-SecureString "P@ssW0rD!" -AsPlainText -Force) `
	-AdminUserUserName "testuser" `
	-ConnectionProfileClientRdpAccess "Public" `
	-ConnectionProfileClientSshAccess "None" `
	-ImageReferenceOffer "Windows-10" `
	-ImageReferencePublisher "MicrosoftWindowsDesktop" `
	-ImageReferenceSku "20h2-pro" `
	-ImageReferenceVersion "latest" `
	-SecurityProfileOpenAccess "Disabled" `
	-SkuCapacity "2" `
	-SkuName "Basic" `
	-VirtualMachineProfileCreateOption "TemplateVM" `
	-VirtualMachineProfileUseSharedPassword "Enabled"
PS C:\> New-AzLabServicesLab -Name "rbestBLab" -ResourceGroupName $rg -Body $labBody


Location Name
-------- ----
westus2  NewLab
```

This cmdlet creates the minimum information to a lab using the body parameter.

## PARAMETERS

### -AdditionalCapabilityInstallGpuDriver


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdminUserPassword


```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdminUserUsername


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

### -ConnectionProfileClientRdpAccess


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

### -ConnectionProfileClientSshAccess


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

### -ImageReferenceOffer


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

### -ImageReferencePublisher


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

### -ImageReferenceSku


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

### -ImageReferenceVersion


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

### -SecurityProfileOpenAccess


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity


```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName


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

### -Title


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

### -VirtualMachineProfileCreateOption


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.CreateOption
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualMachineProfileUseSharedPassword


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState
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

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ILab

## NOTES

ALIASES

## RELATED LINKS

