---
external help file:
Module Name: Az.ServiceLinker
online version: https://docs.microsoft.com/powershell/module/az.servicelinker/test-azservicelinkerforspringcloud
schema: 2.0.0
---

# Test-AzServiceLinkerForSpringCloud

## SYNOPSIS
Validate a link in spring cloud.

## SYNTAX

### Validate (Default)
```
Test-AzServiceLinkerForSpringCloud -Name <String> -AppName <String> -ResourceGroupName <String>
 -ServiceName <String> [-ResourceUri <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-DeploymentName <String>] [-NoWait] [-SubscriptionId <String>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentity
```
Test-AzServiceLinkerForSpringCloud -InputObject <IServiceLinkerIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-SubscriptionId <String>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Validate a link in spring cloud.

## EXAMPLES

### Example 1: Test Linker
```powershell
Test-AzServiceLinkerForSpringCloud -ServiceName servicelinker-springcloud -AppName appconfiguration -DeploymentName "default" -ResourceGroupName servicelinker-test-group -Name postgresql_connection  | Format-List
```

```output
AuthType              : 
IsConnectionAvailable : True
LinkerName            : storagetable_404e8
ReportEndTimeUtc      : 5/6/2022 8:32:26 AM
ReportStartTimeUtc    : 5/6/2022 8:32:24 AM
ResourceId            : /subscriptions/d82d7763-8e12-4f39-a7b6-496a983ec2f4/resourceGroups/servicelinke 
                        r-test-group/providers/Microsoft.AppPlatform/Spring/servicelinker-springcloud/apps/appconfiguration/deployments/default/providers/Mi 
                        crosoft.ServiceLinker/linkers/storagetable_404e8
SourceId              :
Status                : Succeeded
TargetId              : /subscriptions/937bc588-a144-4083-8612-5f9ffbbddb14/resourceGroups/servicelinke 
                        r-test-linux-group/providers/Microsoft.Storage/storageAccounts/servicelinkersto 
                        rage/tableServices/default
ValidationDetail      : {The target existence is validated, The target service firewall is validated,   
                        The configured values is validated}
```

Test Linker

## PARAMETERS

### -AppName
The app Name of spring cloud service to be connected.

```yaml
Type: System.String
Parameter Sets: Validate
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

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

### -DeploymentName
The deployment Name of spring cloud app to be connected.

```yaml
Type: System.String
Parameter Sets: Validate
Aliases:

Required: True
Position: Named
Default value: "default"
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.IServiceLinkerIdentity
Parameter Sets: ValidateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name Linker resource.

```yaml
Type: System.String
Parameter Sets: Validate
Aliases: LinkerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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
The resource group of the resource to be connected.

```yaml
Type: System.String
Parameter Sets: Validate
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceUri
The fully qualified Azure Resource manager identifier of the resource to be connected.

```yaml
Type: System.String
Parameter Sets: Validate
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceName
The Name of spring cloud service to be connected.

```yaml
Type: System.String
Parameter Sets: Validate
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.IServiceLinkerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.Api20220501.IValidateResult

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<IServiceLinkerIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[LinkerName <String>]`: The name Linker resource.
  - `[ResourceUri <String>]`: The fully qualified Azure Resource manager identifier of the resource to be connected.

## RELATED LINKS

