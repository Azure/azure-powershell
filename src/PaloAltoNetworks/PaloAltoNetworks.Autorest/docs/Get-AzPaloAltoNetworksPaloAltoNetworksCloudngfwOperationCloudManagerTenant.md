---
external help file: Az.PaloAltoNetworks-help.xml
Module Name: Az.PaloAltoNetworks
online version: https://learn.microsoft.com/powershell/module/az.paloaltonetworks/get-azpaloaltonetworkspaloaltonetworkscloudngfwoperationcloudmanagertenant
schema: 2.0.0
---

# Get-AzPaloAltoNetworksPaloAltoNetworksCloudngfwOperationCloudManagerTenant

## SYNOPSIS
Get Cloud Manager Tenants for a subscription

## SYNTAX

```
Get-AzPaloAltoNetworksPaloAltoNetworksCloudngfwOperationCloudManagerTenant [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Get Cloud Manager Tenants for a subscription


## EXAMPLES

### Example 1: Get the list of Cloud Manager Tenants for a subscription
```powershell
Get-AzPaloAltoNetworksPaloAltoNetworksCloudngfwOperationCloudManagerTenant
```

```output
dbr-ess-3849213-tenant - Prisma Access (1157428280)
AWS-CNGFW-SO-V2-API-TESTING-5 - Prisma Access (1292604180)
3849213 - fwaasqadevclient - Prisma Access (1623817188)
scm-ess-demo - Prisma Access (1903043489)
AWS-CNGFW-SO-V2-API-TESTING-4 - Prisma Access (1128794313)
3849213 - fwaasqadevclient - 1 - Prisma Access (1605050033)
tsg-3849213 - Prisma Access (1075568041)
3849213 - fwaasqadevclient - 1 - Prisma Access (1749251292)
AWS-CNGFW-SO-V2-API-TESTING - Prisma Access (1576050749)
cNGFW-FUN-Azure_CSP3849213 - Prisma Access (1228258003)
PASLS_CNGFWAutomation - Prisma Access (1246880478)
dbr-ess-3849213-tenant - Prisma Access (1423354763)
SCMEssentialswithSLS-CNGFWAutomation - Prisma Access (1458605471)
SLS_CNFW_Automation - Prisma Access (1855302132)
AWS-CNGFW-SO-V2-API-TESTING-3 - Prisma Access (1532259055)
BrownfieldAutomation - Prisma Access (1983641518)
AWS-CNGFW-SO-V2-API-TESTING-2 - Prisma Access (1053540296)
```

Get the list of Cloud Manager Tenants for a subscription.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.ICloudManagerTenantList

## NOTES

## RELATED LINKS

