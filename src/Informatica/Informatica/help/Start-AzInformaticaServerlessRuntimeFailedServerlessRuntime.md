---
external help file: Az.Informatica-help.xml
Module Name: Az.Informatica
online version: https://learn.microsoft.com/powershell/module/az.informatica/start-azinformaticaserverlessruntimefailedserverlessruntime
schema: 2.0.0
---

# Start-AzInformaticaServerlessRuntimeFailedServerlessRuntime

## SYNOPSIS
Starts a failed runtime resource

## SYNTAX

### Start (Default)
```
Start-AzInformaticaServerlessRuntimeFailedServerlessRuntime -OrganizationName <String>
 -ResourceGroupName <String> -ServerlessRuntimeName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### StartViaIdentityOrganization
```
Start-AzInformaticaServerlessRuntimeFailedServerlessRuntime -ServerlessRuntimeName <String>
 -OrganizationInputObject <IInformaticaIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### StartViaIdentity
```
Start-AzInformaticaServerlessRuntimeFailedServerlessRuntime -InputObject <IInformaticaIdentity>
 [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Starts a failed runtime resource

## EXAMPLES

### Example 1: Start Informatica Serverless Runtime Failed Serverless Runtime
```powershell
Start-AzInformaticaServerlessRuntimeFailedServerlessRuntime -OrganizationName "Demo-Org" -ResourceGroupName "InformaticaTestRg" -ServerlessRuntimeName "serverlessRuntimeDemo"
```

```output
Start-AzInformaticaServerlessRuntimeFailedServerlessRuntime: Status: OK
```

This command will start an Informatica Serverless Runtime that is in a failed state.

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
Parameter Sets: StartViaIdentity
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
Parameter Sets: StartViaIdentityOrganization
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
Parameter Sets: Start
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
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
Parameter Sets: Start
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
Parameter Sets: Start, StartViaIdentityOrganization
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
Parameter Sets: Start
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

### System.Boolean

## NOTES

## RELATED LINKS
