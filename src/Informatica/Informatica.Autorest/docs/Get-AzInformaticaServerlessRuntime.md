---
external help file:
Module Name: Az.Informatica
online version: https://learn.microsoft.com/powershell/module/az.informatica/get-azinformaticaserverlessruntime
schema: 2.0.0
---

# Get-AzInformaticaServerlessRuntime

## SYNOPSIS
Get a InformaticaServerlessRuntimeResource

## SYNTAX

### List (Default)
```
Get-AzInformaticaServerlessRuntime -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzInformaticaServerlessRuntime -Name <String> -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzInformaticaServerlessRuntime -InputObject <IInformaticaIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityOrganization
```
Get-AzInformaticaServerlessRuntime -Name <String> -OrganizationInputObject <IInformaticaIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a InformaticaServerlessRuntimeResource

## EXAMPLES

### Example 1: Get Serverless Runtime for an Informatica Organization
```powershell
Get-AzInformaticaOrganizationServerlessRuntime -OrganizationName "Demo-Org" -ResourceGroupName "InformaticaTestRg"
```

```output
Id                                         : /subscriptions/ce37d538-dfa3-49c3-b3cd-149b4b7db48a/resourceGroups/InformaticaTestRg/providers/Informatica.DataManagement/organizations/Demo-Org/serverlessRuntimes/serverlessRuntimeDemo,
Name                                       : serverlessRuntimeDemo,
Type                                       : Informatica.Datamanagement/organizations/serverlessRuntimes,
Location                                   : westus2,
Tags                                       : {},
NetworkInterfaceConfigurationVnetId        : /subscriptions/ce37d538-dfa3-49c3-b3cd-149b4b7db48a/resourceGroups/InformaticaTestRg/providers/Microsoft.Network/virtualNetworks/liftr-vnet-serverless,
NetworkInterfaceConfigurationSubnetId      : /subscriptions/ce37d538-dfa3-49c3-b3cd-149b4b7db48a/resourceGroups/InformaticaTestRg/providers/Microsoft.Network/virtualNetworks/liftr-vnet-serverless/subnets/default,
ServerlessAccountLocation                  : westus2,
Platform                                   : AZURE,
ApplicationType                            : CDI,
ExecutionTimeout                           : 3600,
ComputeUnits                               : 4,
ServerlessRuntimeConfigCdieConfigProp                       : { EngineName: Data_Integration_Server, EngineVersion: 68.0, ApplicationConfigs: [{ Type: TOMCAT_CFG, Name: INFA_DTM_STAGING_ENABLED_CONNECTORS, Value: '', Platform: all, Customized: false, DefaultValue: '' }] }

```

This command will get serverless runtime details for an Informatica organization.

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
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Serverless Runtime resource

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityOrganization
Aliases: ServerlessRuntimeName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrganizationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IInformaticaIdentity
Parameter Sets: GetViaIdentityOrganization
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
Parameter Sets: Get, List
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
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IInformaticaIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Informatica.Models.IInformaticaServerlessRuntimeResource

## NOTES

## RELATED LINKS

