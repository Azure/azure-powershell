---
external help file:
Module Name: Az.ServiceLinker
online version: https://docs.microsoft.com/powershell/module/az.servicelinker/test-azservicelinkerforwebapp
schema: 2.0.0
---

# Test-AzServiceLinkerForWebapp

## SYNOPSIS
Validate a link.

## SYNTAX

### Validate (Default)
```
Test-AzServiceLinkerForWebapp -Name <String> -ResourceGroupName <String> -Webapp <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentity
```
Test-AzServiceLinkerForWebapp -InputObject <IServiceLinkerIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Validate a link.

## EXAMPLES

### Example 1: Test Linker
```powershell
Test-AzServiceLinkerForWebapp -Webapp servicelinker-webapp -ResourceGroupName servicelinker-test-group -Name postgresql_connection  | fl
```

```output
EndTime    : 2022-04-28T10:08:48.3853396Z
Message    : {"ConnectionName":"postgresql_connection","IsConnectionAvailable":true,"ValidationDetail":
             [{"Name":"The target existence is validated","Description":null,"Result":0},{"Name":"The       
             target service firewall is validated","Description":null,"Result":0},{"Name":"The
             configured values (except username/password) is validated","Description":null,"Result":0}] 
             ,"ReportStartTimeUtc":"2022-04-28T10:08:45.018802Z","ReportEndTimeUtc":"2022-04-28T10:08:4 
             8.254394Z","SourceId":null,"TargetId":"/subscriptions/937bc588-a144-4083-8612-5f9ffbbddb14 
             /resourceGroups/servicelinker-test-group/providers/Microsoft.DBforPostgreSQL/servers 
             /test-postgresql/databases/testdb","AuthType":4}
ResourceId : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/servicelinker-test-grou
             p/providers/Microsoft.Web/sites/servicelinker-webapp/providers/Microsoft.ServiceLinker/lin
             kers/postgresql_connection
StartTime  : 2022-04-28T10:08:43.7039493Z
Status     : Succeeded
```

Test Linker

## PARAMETERS

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

### -Webapp
The Name of webapp of the resource to be connected.

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


INPUTOBJECT <IServiceLinkerIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[LinkerName <String>]`: The name Linker resource.
  - `[ResourceUri <String>]`: The fully qualified Azure Resource manager identifier of the resource to be connected.

## RELATED LINKS

