---
external help file: Microsoft.Azure.Commands.PolicyInsights.dll-Help.xml
Module Name: AzureRM.PolicyInsights
online version:
schema: 2.0.0
---

# Get-AzureRmPolicyRemediationDeployment

## SYNOPSIS
Gets the status of the deployments for a policy remediation.

## SYNTAX

### ByName (Default)
```
Get-AzureRmPolicyRemediationDeployment -Name <String> [-Scope <String>] [-ManagementGroupName <String>]
 [-ResourceGroupName <String>] [-Top <Int32>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByResourceId
```
Get-AzureRmPolicyRemediationDeployment -ResourceId <String> [-Top <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByInputObject
```
Get-AzureRmPolicyRemediationDeployment -InputObject <PSRemediation> [-Top <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmPolicyRemediationDeployment** cmdlet gets the status of the deployments for a particular remediation. These deployments are used to bring non-compliant resources back into compliance with a policy assignment.

## EXAMPLES

### Example 1: Get all deployments for a policy remediation
```
PS C:\> Get-AzureRmPolicyRemediationDeployment -Name "remediation1"
```

This command gets the status of all the deployments created for a remediation named 'remediation1' in the current subscription.

### Example 2: Get 5 deployments for a policy remediation at management group scope
```
PS C:\> Get-AzureRmPolicyRemediationDeployment -ManagementGroupName "mg1" -Name "remediation1" -Top 5
```

This command gets the status of 5 of the deployments created for a remediation named 'remediation1' in management group 'mg1'.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The Remediation object.

```yaml
Type: PSRemediation
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagementGroupName
Management group ID.

```yaml
Type: String
Parameter Sets: ByName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Resource name.

```yaml
Type: String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group name.

```yaml
Type: String
Parameter Sets: ByName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Resource ID.

```yaml
Type: String
Parameter Sets: ByResourceId
Aliases: Id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Scope
Scope of the resource. For example, '/subscriptions/{subscriptionId}/resourceGroups/{rgName}'.

```yaml
Type: String
Parameter Sets: ByName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Top
Maximum number of records to return.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.PolicyInsights.Models.Remediation.PSRemediation

## OUTPUTS

### Microsoft.Azure.Commands.PolicyInsights.Models.Remediation.PSRemediationDeployment

## NOTES

## RELATED LINKS
