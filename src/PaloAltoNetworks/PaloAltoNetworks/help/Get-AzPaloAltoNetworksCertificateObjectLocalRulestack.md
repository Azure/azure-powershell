---
external help file: Az.PaloAltoNetworks-help.xml
Module Name: Az.PaloAltoNetworks
online version: https://learn.microsoft.com/powershell/module/az.paloaltonetworks/get-azpaloaltonetworkscertificateobjectlocalrulestack
schema: 2.0.0
---

# Get-AzPaloAltoNetworksCertificateObjectLocalRulestack

## SYNOPSIS
Get a CertificateObjectLocalRulestackResource

## SYNTAX

### List (Default)
```
Get-AzPaloAltoNetworksCertificateObjectLocalRulestack -LocalRulestackName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzPaloAltoNetworksCertificateObjectLocalRulestack -LocalRulestackName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityLocalRulestack
```
Get-AzPaloAltoNetworksCertificateObjectLocalRulestack -Name <String>
 -LocalRulestackInputObject <IPaloAltoNetworksIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPaloAltoNetworksCertificateObjectLocalRulestack -InputObject <IPaloAltoNetworksIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a CertificateObjectLocalRulestackResource

## EXAMPLES

### Example 1: List CertificateObjectLocalRulestackResource by LocalRulestackName.
```powershell
Get-AzPaloAltoNetworksCertificateObjectLocalRulestack -ResourceGroupName azps_test_group_pan -LocalRulestackName azps-panlr
```

```output
CertificateSelfSigned Name        ProvisioningState ResourceGroupName
--------------------- ----        ----------------- -----------------
TRUE                  azps-pancor Succeeded         azps_test_group_pan
```

List CertificateObjectLocalRulestackResource by LocalRulestackName.

### Example 2: Get a CertificateObjectLocalRulestackResource by name.
```powershell
Get-AzPaloAltoNetworksCertificateObjectLocalRulestack -ResourceGroupName azps_test_group_pan -LocalRulestackName azps-panlr -Name azps-pancor
```

```output
CertificateSelfSigned Name        ProvisioningState ResourceGroupName
--------------------- ----        ----------------- -----------------
TRUE                  azps-pancor Succeeded         azps_test_group_pan
```

Get a CertificateObjectLocalRulestackResource by name.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IPaloAltoNetworksIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LocalRulestackInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IPaloAltoNetworksIdentity
Parameter Sets: GetViaIdentityLocalRulestack
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LocalRulestackName
LocalRulestack resource name

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
certificate name

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityLocalRulestack
Aliases:

Required: True
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
Parameter Sets: List, Get
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
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IPaloAltoNetworksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.ICertificateObjectLocalRulestackResource

## NOTES

## RELATED LINKS
