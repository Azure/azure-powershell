---
external help file:
Module Name: Az.HealthcareApis
online version: https://learn.microsoft.com/powershell/module/az.healthcareapis/get-azhealthcaredicomservice
schema: 2.0.0
---

# Get-AzHealthcareDicomService

## SYNOPSIS
Gets the properties of the specified DICOM Service.

## SYNTAX

### List (Default)
```
Get-AzHealthcareDicomService -ResourceGroupName <String> -WorkspaceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzHealthcareDicomService -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzHealthcareDicomService -InputObject <IHealthcareApisIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the properties of the specified DICOM Service.

## EXAMPLES

### Example 1: List the properties of the specified workspace.
```powershell
Get-AzHealthcareDicomService -ResourceGroupName azps_test_group -WorkspaceName azpshcws
```

```output
Location Name               ResourceGroupName
-------- ----               -----------------
eastus2  azpshcws/azpsdicom azps_test_group
```

List the properties of the specified workspace.

### Example 2: Gets the properties of the specified DICOM Service.
```powershell
Get-AzHealthcareDicomService -Name azpsdicom -ResourceGroupName azps_test_group -WorkspaceName azpshcws
```

```output
Location Name               ResourceGroupName
-------- ----               -----------------
eastus2  azpshcws/azpsdicom azps_test_group
```

Gets the properties of the specified DICOM Service.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IHealthcareApisIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of DICOM Service resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: DicomServiceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the service instance.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription identifier.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
The name of workspace resource.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IHealthcareApisIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IDicomService

## NOTES

## RELATED LINKS

