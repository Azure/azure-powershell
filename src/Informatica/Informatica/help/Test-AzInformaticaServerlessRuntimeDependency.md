---
external help file: Az.Informatica-help.xml
Module Name: Az.Informatica
online version: https://learn.microsoft.com/powershell/module/az.informatica/test-azinformaticaserverlessruntimedependency
schema: 2.0.0
---

# Test-AzInformaticaServerlessRuntimeDependency

## SYNOPSIS
Checks all dependencies for a serverless runtime resource

## SYNTAX

### Check (Default)
```
Test-AzInformaticaServerlessRuntimeDependency -OrganizationName <String> -ResourceGroupName <String>
 -ServerlessRuntimeName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaIdentityOrganization
```
Test-AzInformaticaServerlessRuntimeDependency -ServerlessRuntimeName <String>
 -OrganizationInputObject <IInformaticaIdentity> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzInformaticaServerlessRuntimeDependency -InputObject <IInformaticaIdentity> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Checks all dependencies for a serverless runtime resource

## EXAMPLES

### Example 1: Test Informatica Serverless Runtime Dependency
```powershell
Test-AzInformaticaServerlessRuntimeDependency -OrganizationName "Demo-Org" -ResourceGroupName "InformaticaTestRg" -ServerlessRuntimeName "serverlessRuntimeDemo"
```

```output
Test-AzInformaticaServerlessRuntimeDependency: Status: OK
```

This command will test the Informatica Serverless Runtime dependency.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IInformaticaIdentity
Parameter Sets: CheckViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OrganizationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IInformaticaIdentity
Parameter Sets: CheckViaIdentityOrganization
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OrganizationName
Name of the Organizations resource

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -ServerlessRuntimeName
Name of the Serverless Runtime resource

```yaml
Type: System.String
Parameter Sets: Check, CheckViaIdentityOrganization
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
Parameter Sets: Check
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

### Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IInformaticaIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.ICheckDependenciesResponse

## NOTES

## RELATED LINKS
