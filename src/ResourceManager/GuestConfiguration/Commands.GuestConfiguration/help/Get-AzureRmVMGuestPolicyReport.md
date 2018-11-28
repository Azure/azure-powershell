---
external help file: Microsoft.Azure.Commands.GuestConfiguration.dll-Help.xml
Module Name: AzureRM.GuestConfiguration
online version: https://github.com/Azure/azure-powershell/blob/preview/src/ResourceManager/GuestConfiguration/Commands.GuestConfiguration/help/Get-AzureRmVMGuestPolicyReport.md
schema: 2.0.0
---

# Get-AzureRmVMGuestPolicyReport

## SYNOPSIS
Gets guest configuration policy reports for an initiative of type "Guest Configuration" that is assigned to a VM. An initiative is a policy of definition type "Initiative".

## SYNTAX

### VmScope (Default)
```
Get-AzureRmVMGuestPolicyReport [-ResourceGroupName] <String> [-VMName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### InitiativeIdScope
```
Get-AzureRmVMGuestPolicyReport [-ResourceGroupName] <String> [-VMName] <String> [-InitiativeId] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### InitiativeNameScope
```
Get-AzureRmVMGuestPolicyReport [-ResourceGroupName] <String> [-VMName] <String> [-InitiativeName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ReportIdScope
```
Get-AzureRmVMGuestPolicyReport [-ReportId] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The Get-AzureRmVMGuestPolicyReport cmdlet gets guest configuration policy reports for an initiative of type "Guest Configuration" that is assigned to a VM. An initiative is a policy of definition type "Initiative". This cmdlet gets compliance statuses of the VM, reports and reasons why it is non-compliant for the individual policies in the initiative.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzureRmVMGuestPolicyReport -ResourceGroupName "MyResourceGroupName" -VMName "MyVMName"
```
Get all latest guest configuration policy reports for a VM. The report includes compliance status of the VM for each policy in all initiatives of type "Guest Configuration", compliance reasons, start and end time of the compliance check, resource information which was checked for compliance. The results include latest reports, does not include previous historical reports.

### Example 2
```powershell
PS C:\> Get-AzureRmVMGuestPolicyReport -ResourceGroupName "MyResourceGroupName" -VMName "MyVMName" -InitiativeId "/providers/Microsoft.Authorization/policySetDefinitions/3fa7cbf5-c0a4-4a59-85a5-cca4d996d5af"
```
Get the latest guest configuration policy reports by initiative Id. The report includes compliance status of the VM for each policy in the initiative, compliance reasons, start and end time of the compliance check, resource information which was checked for compliance. The results does not include previous reports generated, it just includes latest report for each policy in the initiative.

### Example 3
```powershell
PS C:\> Get-AzureRmVMGuestPolicyReport -ResourceGroupName "MyResourceGroupName" -VMName "MyVMName" -InitiativeName "b5a822e0-ba98-4e54-9278-5d9833aa9b17"
```
Get the latest guest configuration policy reports by initiative name. The report includes compliance status of the VM for each policy in the initiative, compliance reasons, start and end time of the compliance check, resource information which was checked for compliance. The results does not include previous reports generatedl, it just includes latest report for each policy in the initiative.

### Example 4
```powershell
PS C:\> Get-AzureRmVMGuestPolicyReport -ReportId "/subscriptions/4e6c6ed2-0bf6-41d7-9d21-a452c2cc7920/resourceGroups/MyResourceGroupName/providers/Microsoft.Compute/virtualMachines/MyVMName/providers/Microsoft.GuestConfiguration/guestConfigurationAssignments/MaximumPasswordAge/reports/c271f845-2c0a-4456-a441-e48fc332d0ac"
```
Get guest configuration policy report by report Id. The report Id is the LatestReportId property that can be found in the results of Get-AzureRmVMGuestPolicyReport by initiativeId or Initiative name (please refer other examples)

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InitiativeId
Definition Id of a policy where definition type is Initiative and category is Guest Configuration

```yaml
Type: System.String
Parameter Sets: InitiativeIdScope
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InitiativeName
Name of a policy where definition type is Initiative and category is Guest Configuration

```yaml
Type: System.String
Parameter Sets: InitiativeNameScope
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReportId
Report Id of a Guest Configuration policy report.
A policy whose definition type is Initiative and category is Guest Configuration must be assigned to a scope to get reports.

```yaml
Type: System.String
Parameter Sets: ReportIdScope
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group name.

```yaml
Type: System.String
Parameter Sets: VmScope, InitiativeIdScope, InitiativeNameScope
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMName
VM name.

```yaml
Type: System.String
Parameter Sets: VmScope, InitiativeIdScope, InitiativeNameScope
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Management.Automation.SwitchParameter

## OUTPUTS

### System.Collections.Generic.IList`1[[Microsoft.Azure.Management.GuestConfiguration.Models.GuestConfigurationAssignment, Microsoft.Azure.Management.GuestConfiguration, Version=0.9.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]

### System.Collections.Generic.IList`1[[Microsoft.Azure.Management.GuestConfiguration.Models.GuestConfigurationAssignmentReport, Microsoft.Azure.Management.GuestConfiguration, Version=0.9.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]

## NOTES

## RELATED LINKS
