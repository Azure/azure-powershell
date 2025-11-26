---
external help file: Microsoft.Azure.PowerShell.Cmdlets.TestModule.dll-Help.xml
Module Name: Az.TestModule
online version: https://learn.microsoft.com/powershell/module/az.testmodule/get-testresource
schema: 2.0.0
---

# Get-TestResource

## SYNOPSIS
Retrieves test resources from Azure.

## SYNTAX

### ListByResourceGroup (Default)
```
Get-TestResource [-ResourceGroupName] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### GetByNameAndResourceGroup
```
Get-TestResource [-ResourceGroupName] <String> [-Name] <String> [-IncludeDetails]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-TestResource cmdlet retrieves one or more test resources from your Azure subscription. You can retrieve all resources in a resource group, or get a specific resource by providing its name. Use the IncludeDetails parameter to retrieve extended properties and configuration details.

## EXAMPLES

### Example 1: Get all test resources in a resource group
```powershell
Get-TestResource -ResourceGroupName "MyResourceGroup"
```

This command retrieves all test resources that exist within the specified resource group "MyResourceGroup". The output includes basic properties such as name, location, and provisioning state for each resource.

### Example 2: Get a specific test resource
```powershell
Get-TestResource -ResourceGroupName "MyResourceGroup" -Name "MyTestResource"
```

Gets detailed information about the test resource named "MyTestResource" in the resource group "MyResourceGroup".

### Example 3
```powershell
Get-TestResource -ResourceGroupName "MyResourceGroup" -Name "MyTestResource" -IncludeDetails
```

Does something.

## PARAMETERS

### -ResourceGroupName
Specifies the name of the Azure resource group that contains the test resources. This parameter is required and accepts a string value representing a valid resource group name in your subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Name.

```yaml
Type: System.String
Parameter Sets: GetByNameAndResourceGroup
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IncludeDetails
Help message.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetByNameAndResourceGroup
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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.TestModule.Models.PSTestResource

## NOTES

## RELATED LINKS
