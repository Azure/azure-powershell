---
external help file: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.dll-Help.xml
Module Name: Az.HealthcareApis
online version: https://docs.microsoft.com/en-us/powershell/module/az.healthcareApis/new-azhealthcareapisservice
schema: 2.0.0
---
# Remove-AzHealthcareApisService

## SYNOPSIS
Deletes a service instance.

## SYNTAX

###ServiceNameParameterSet
```
Remove-AzHealthcareApisService -Name <String> [-ResourceGroupName <String>] [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

###ResourceIdParameterSet
```
Remove-AzHealthcareApisService -ResourceId <String> [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

###InputObjectParameterSet
```
Remove-AzHealthcareApisService -InputObject <PSHealthcareApisFhirService> [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Deletes a service instance.

## EXAMPLES

### Example 1
```powershell
PS C:\> Remove-AzHealthcareApisFhirService -Name MyService -ResourceGroupName MyResourceGroup

ResourceGroupName Name 
----------------- ----------- 
MyResourceGroup   MyService
```
Deletes the existing HealthcareApis service with the provided name within a provided resourcegroup.

### Example 2
```powershell
PS C:\> Remove-AzHealthcareApisFhirService -ResourceId myResourceId

```
Deletes the existing HealthcareApis service with the provided ResourceId.

### Example 3
```powershell
PS C:\> Remove-AzHealthcareApisFhirService -InputObject PSHealthcareApisService
```
Deletes the provided HealthcareApis service object.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```
### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```


### -PassThru
When specified, PassThru will force the cmdlet return a 'bool' given that there isn't a return type by default.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```


### -Name
The name of the service instance.


```yaml
Type: System.String
Parameter Sets: ServiceNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group that contains the service instance.

``yaml
Type: System.String
Parameter Sets: ServiceNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```


### -ResourceId
ResourceId of the service instance

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthCare.Models.PSHealthcareApisService
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Type: Microsoft.Azure.PowerShell.Cmdlets.HealthCare.Models.PSHealthcareApisService


## OUTPUTS

###System.Boolean

## NOTES

## RELATED LINKS

