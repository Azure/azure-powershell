---
external help file: Az.CustomLocation-help.xml
Module Name: Az.CustomLocation
online version: https://learn.microsoft.com/powershell/module/az.customlocation/update-azcustomlocation
schema: 2.0.0
---

# Update-AzCustomLocation

## SYNOPSIS
Updates a Custom Location with the specified Resource Name in the specified Resource Group and Subscription.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzCustomLocation -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AuthenticationType <String>] [-AuthenticationValue <String>] [-ClusterExtensionId <String[]>]
 [-DisplayName <String>] [-HostResourceId <String>] [-IdentityType <String>] [-Namespace <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzCustomLocation -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzCustomLocation -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzCustomLocation -InputObject <ICustomLocationIdentity> [-AuthenticationType <String>]
 [-AuthenticationValue <String>] [-ClusterExtensionId <String[]>] [-DisplayName <String>]
 [-HostResourceId <String>] [-IdentityType <String>] [-Namespace <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates a Custom Location with the specified Resource Name in the specified Resource Group and Subscription.

## EXAMPLES

### Example 1: Updates a Custom Location with the specified Resource Name in the specified Resource Group and Subscription.
```powershell
$HostResourceId = (Get-AzConnectedKubernetes -ClusterName azps-connect -ResourceGroupName azps_test_cluster).Id
$ClusterExtensionId = (Get-AzKubernetesExtension -ClusterName azps-connect -ClusterType ConnectedClusters -ResourceGroupName azps_test_cluster -Name azps-extension).Id
Update-AzCustomLocation -ResourceGroupName azps_test_cluster -Name azps-customlocation -ClusterExtensionId $ClusterExtensionId -HostResourceId $HostResourceId -Namespace azps-namespace -Tag @{"Key1"="Value1"}
```

```output
Location Name                Namespace      ResourceGroupName
-------- ----                ---------      -----------------
eastus   azps-customlocation azps-namespace azps_test_cluster
```

Updates a Custom Location with the specified Resource Name in the specified Resource Group and Subscription.

### Example 2: Updates a Custom Location.
```powershell
$obj = Get-AzCustomLocation -ResourceGroupName azps_test_cluster -Name azps-customlocation
Update-AzCustomLocation -InputObject $obj -Tag @{"Key1"="Value1"}
```

```output
Location Name                Namespace      ResourceGroupName
-------- ----                ---------      -----------------
eastus   azps-customlocation azps-namespace azps_test_cluster
```

Updates a Custom Location.

## PARAMETERS

### -AuthenticationType
ThetypeoftheCustomLocationsauthentication

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthenticationValue
Thekubeconfigvalue.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterExtensionId
Containsthereferencetotheadd-onthatcontainschartstodeployCRDsandoperators.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
TheDefaultProfileparameterisnotfunctional.UsetheSubscriptionIdparameterwhenavailableifexecutingthecmdletagainstadifferentsubscription.

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

### -DisplayName
DisplaynamefortheCustomLocationslocation.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostResourceId
ConnectedClusterorAKSCluster.TheCustomLocationsRPwillperformacheckAccessAPIforlistAdminCredentialspermissions.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
Theidentitytype.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
IdentityParameterToconstruct,seeNOTESsectionforINPUTOBJECTpropertiesandcreateahashtable.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomLocation.Models.ICustomLocationIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
PathofJsonfilesuppliedtotheUpdateoperation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
JsonstringsuppliedtotheUpdateoperation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
CustomLocationsname.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Namespace
Kubernetesnamespacethatwillbecreatedonthespecifiedcluster.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Thenameoftheresourcegroup.Thenameiscaseinsensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
TheIDofthetargetsubscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resourcetags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.CustomLocation.Models.ICustomLocationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CustomLocation.Models.ICustomLocation

## NOTES

## RELATED LINKS
