---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Support.dll-Help.xml
Module Name: Az.Support
online version:
schema: 2.0.0
---

# Get-AzSupportProblemClassification

## SYNOPSIS
Get problem classifications for the service specified.

## SYNTAX

### GetByNameParameterSet (Default)
```
Get-AzSupportProblemClassification -ServiceName <String> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByParentObjectParameterSet
```
Get-AzSupportProblemClassification [-Name <String>] -ServiceObject <PSSupportService>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByResourceIdParameterSet
```
Get-AzSupportProblemClassification -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets problem classifications for the service specified. These are the problems or issue types for the service for which support is available.

## EXAMPLES

### Example 1: Get all problem classificaitons for a service using service name parameter
```powershell
PS C:\> Get-AzSupportProblemClassification -ServiceName {service_guid} | Select-Object -First 2 | fl Id, DisplayName 

Id          : /providers/Microsoft.Support/services/{service_guid}/problemClassifications/{problemClassification_guid}
DisplayName : I cannot configure Export of Activity Log / Configuring export in Azure Portal

Id          : /providers/Microsoft.Support/services/{service_guid}/problemClassifications/{problemClassification_guid}
DisplayName : I cannot configure Export of Activity Log / Configuring export using PowerShell or CLI
```

### Example 2: Get all problem classificaitons for a service using parent service object
```powershell
PS C:\> Get-AzSupportService -Name {service_guid} | Get-AzSupportProblemClassification | Select-Object -First 2 | fl Id, DisplayName  

Id          : /providers/Microsoft.Support/services/{service_guid}/problemClassifications/{problemClassification_guid}
DisplayName : I cannot configure Export of Activity Log / Configuring export in Azure Portal

Id          : /providers/Microsoft.Support/services/{service_guid}/problemClassifications/{problemClassification_guid}
DisplayName : I cannot configure Export of Activity Log / Configuring export using PowerShell or CLI
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of ProblemClassification resource that this cmdlet gets.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet, GetByParentObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Arm ResourceId of ProblemClassification resource that this cmdlet gets.

```yaml
Type: System.String
Parameter Sets: GetByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceName
Name of Service resouce for which ProblemClassification resources are retrieved.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceObject
Service resource object for which ProblemClassificaiton resources are retrieved.

```yaml
Type: Microsoft.Azure.Commands.Support.Models.PSSupportService
Parameter Sets: GetByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Support.Models.PSSupportService

## OUTPUTS

### Microsoft.Azure.Commands.Support.Models.PSSupportProblemClassification

## NOTES

## RELATED LINKS
