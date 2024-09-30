---
external help file:
Module Name: Az.Attestation
online version: https://learn.microsoft.com/powershell/module/az.attestation/new-azattestationprovider
schema: 2.0.0
---

# New-AzAttestationProvider

## SYNOPSIS
Creates a new Attestation Provider.

## SYNTAX

```
New-AzAttestationProvider -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-PolicySigningCertificateKeyPath <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new Attestation Provider.

## EXAMPLES

### Example 1: Create a new Attestation Provider
```powershell
New-AzAttestationProvider -Name testprovider1 -ResourceGroupName test-rg -Location "eastus"
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
eastus  testprovider1 test-rg
```

This command creates a new Attestation Provider named `testprovider1` in resource group `test-rg`.

### Example 2: Create a new Attestation Provider with trusted signing keys
```powershell
New-AzAttestationProvider -Name testprovider2 -ResourceGroupName test-rg -Location "eastus" -PolicySigningCertificateKeyPath .\cert1.pem
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
eastus  testprovider2 test-rg
```

This command creates a new Attestation Provider named `testprovider2` with trusted signing keys in resource group `test-rg`.

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

### -Location
The supported Azure location where the attestation provider should be created.

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

### -Name
Name of the attestation provider.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ProviderName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PolicySigningCertificateKeyPath
Specifies the set of trusted signing keys for issuance policy in a single certificate file.
The value of the "keys" parameter is an array of JWK values.
Bydefault, the order of the JWK values within the array does not implyan order of preference among them, although applications of JWK Setscan choose to assign a meaning to the order for their purposes, ifdesired.
To construct, see NOTES section for POLICYSIGNINGCERTIFICATEKEY properties and create a hash table.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The tags that will be assigned to the attestation provider.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Attestation.Models.Api20201001.IAttestationProvider

## NOTES

## RELATED LINKS

