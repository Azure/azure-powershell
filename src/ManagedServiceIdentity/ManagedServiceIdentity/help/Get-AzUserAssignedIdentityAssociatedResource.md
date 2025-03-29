---
external help file: Az.ManagedServiceIdentity-help.xml
Module Name: Az.ManagedServiceIdentity
online version: https://learn.microsoft.com/powershell/module/az.managedserviceidentity/get-azuserassignedidentityassociatedresource
schema: 2.0.0
---

# Get-AzUserAssignedIdentityAssociatedResource

## SYNOPSIS
Lists the associated resources for this identity.

## SYNTAX

```
Get-AzUserAssignedIdentityAssociatedResource -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Filter <String>] [-Orderby <String>] [-Skip <Int32>] [-Skiptoken <String>]
 [-Top <Int32>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Lists the associated resources for this identity.

## EXAMPLES

### Example 1: List all azure resources associated with given identity.
```powershell
Get-AzUserAssignedIdentityAssociatedResource -ResourceGroupName azure-rg-test -Name uai-pwsh01
```

```output
Name             ResourceGroup     SubscriptionDisplayName               SubscriptionId                       ResourceType
----             -------------     -----------------------               --------------                       ------------
appServicej6ocml identity-xcsbyfid Visual Studio Enterprise Subscription 0336439f-0e9d-44ec-975e-62accb9b3901 microsoft.web/sites
default          test-resources    Visual Studio Enterprise Subscription 0336439f-0e9d-44ec-975e-62accb9b3901 microsoft.compute/virtualmachines
```

This command lists all azure resources associated with given identity.

### Example 2: List azure resources associated with given identity with OData expression that allows to filter by: name, type, resourceGroup, subscriptionId, subscriptionDisplayName
```powershell
Get-AzUserAssignedIdentityAssociatedResource -ResourceGroupName azure-rg-test -Name uai-pwsh01 `
    -Filter "type eq 'microsoft.compute/virtualmachines' and contains(name, 'default')"
```

```output
Name    ResourceGroup  SubscriptionDisplayName               SubscriptionId                       ResourceType
----    -------------  -----------------------               --------------                       ------------
default test-resources Visual Studio Enterprise Subscription 0336439f-0e9d-44ec-975e-62accb9b3901 microsoft.compute/virtualmachines
```

This command lists azure resources associated with given identity with OData expression that allows to filter by: name, type, resourceGroup, subscriptionId, subscriptionDisplayName

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

### -Filter
OData filter expression to apply to the query.

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

### -Name
The name of the identity resource.

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

### -Orderby
OData orderBy expression to apply to the query.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the Resource Group to which the identity belongs.

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

### -Skiptoken
A skip token is used to continue retrieving items after an operation returns a partial result.
If a previous response contains a nextLink element, the value of the nextLink element will include a skipToken parameter that specifies a starting point to use for subsequent calls.

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

### -SubscriptionId
The Id of the Subscription to which the identity belongs.

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

### -Top
Number of records to return.

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

### -Skip
Number of records to skip.

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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.Api20220131Preview.IAzureResource

## NOTES

## RELATED LINKS
