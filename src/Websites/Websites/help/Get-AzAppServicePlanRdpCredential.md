---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Websites.dll-Help.xml
Module Name: Az.Websites
online version: https://learn.microsoft.com/powershell/module/az.websites/get-azappserviceplanrdpcredential
schema: 2.0.0
---

# Get-AzAppServicePlanRdpCredential

## SYNOPSIS
Gets secure RDP credentials for a Managed Instance App Service plan.

## SYNTAX

### S1 (Default)
```
Get-AzAppServicePlanRdpCredential [-ResourceGroupName] <String> [-Name] <String>
 [-DefaultProfile <IAzureContextContainer>] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

### S2
```
Get-AzAppServicePlanRdpCredential [-AppServicePlan] <PSAppServicePlan>
 [-DefaultProfile <IAzureContextContainer>] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzAppServicePlanRdpCredential** cmdlet retrieves Remote Desktop Protocol (RDP) credentials for a Managed Instance plan with RDP enabled.
It returns a PSCredential object with the Administrator user name and the password stored as a SecureString.
The password is not written to the console or clipboard.
An error is returned if the service does not provide a password.

Use **Get-AzAppServicePlanManagedInstance** to retrieve the worker IP address, and use the credential with your configured Azure Bastion or RDP client.
This cmdlet does not create a Bastion tunnel or launch a desktop client.

## EXAMPLES

### Example 1: Retrieve secure RDP credentials
```powershell
$credential = Get-AzAppServicePlanRdpCredential -ResourceGroupName "ContosoRG" -Name "ContosoManagedPlan"
```

This command stores the plan's RDP credentials without displaying the password.
Enable RDP first with `Set-AzAppServicePlan -ResourceGroupName "ContosoRG" -Name "ContosoManagedPlan" -RdpEnabled $true`.

### Example 2: Retrieve credentials from a plan in the pipeline
```powershell
$credential = Get-AzAppServicePlan -ResourceGroupName "ContosoRG" -Name "ContosoManagedPlan" |
    Get-AzAppServicePlanRdpCredential
$instance = Get-AzAppServicePlanManagedInstance -ResourceGroupName "ContosoRG" -Name "ContosoManagedPlan" -InstanceName "WORKER1"
```

Use the instance's IPAddress property and the credential with your configured connection client.
Treat the credential as sensitive information and retrieve a new credential if the service-issued password expires.

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

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

### -AppServicePlan
The Managed Instance App Service plan object whose RDP credentials are retrieved.
Use **Get-AzAppServicePlan** to retrieve the object.

```yaml
Type: Microsoft.Azure.Commands.WebApps.Models.WebApp.PSAppServicePlan
Parameter Sets: S2
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ChangeReference
The change reference resource ID for this resource operation.

```yaml
Type: System.String
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
The name of the Managed Instance App Service plan with RDP enabled.

```yaml
Type: System.String
Parameter Sets: S1
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group containing the Managed Instance App Service plan.

```yaml
Type: System.String
Parameter Sets: S1
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.WebApps.Models.WebApp.PSAppServicePlan

## OUTPUTS

### System.Management.Automation.PSCredential

## NOTES

## RELATED LINKS

[Get-AzAppServicePlanManagedInstance](./Get-AzAppServicePlanManagedInstance.md)

[Set-AzAppServicePlan](./Set-AzAppServicePlan.md)
