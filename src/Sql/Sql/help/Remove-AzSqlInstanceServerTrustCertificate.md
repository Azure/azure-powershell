---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/remove-azsqlinstanceservertrustcertificate
schema: 2.0.0
---

# Remove-AzSqlInstanceServerTrustCertificate

## SYNOPSIS
Removes a server trust certificate.

## SYNTAX

### DeleteByNameParameterSet (Default)
```
Remove-AzSqlInstanceServerTrustCertificate [-ResourceGroupName] <String> [-InstanceName] <String>
 [-Name] <String> [-AsJob] [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### DeleteByParentObjectParameterSet
```
Remove-AzSqlInstanceServerTrustCertificate [-Name] <String> [-InstanceObject] <AzureSqlManagedInstanceModel>
 [-AsJob] [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteByInputObjectParameterSet
```
Remove-AzSqlInstanceServerTrustCertificate [-InputObject] <AzureSqlInstanceServerTrustCertificateModel>
 [-AsJob] [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteByResourceIdParameterSet
```
Remove-AzSqlInstanceServerTrustCertificate [-ResourceId] <String> [-AsJob] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
**Remove-AzSqlInstanceServerTrustCertificate** cmdlet removes a server trust certificate from Azure SQL Managed Instance

## EXAMPLES

### Example 1: Remove a server trust certificate
```powershell
Remove-AzSqlInstanceServerTrustCertificate -ResourceGroupName "ResourceGroup01" -InstanceName "ManagedInstance01" -Name "Certificate01"
```

This command removes the server trust certificate "Certificate01" from managed instance "ManagedInstance01" and resource group "ResourceGroup1"

### Example 2: Remove a server trust certificate by its resource identifier
```powershell
Remove-AzSqlInstanceServerTrustCertificate -ResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01/serverTrustCertificates/Certificate01"
```

This command removes the server trust certificate with specified resource ID.

### Example 3: Remove a server trust certificate by its PowerShell object
```powershell
$serverTrustCertificate = Get-AzSqlInstanceServerTrustCertificate -ResourceGroupName "ResourceGroup01" -InstanceName "ManagedInstance01" -Name "Certificate01" 
Remove-AzSqlInstanceServerTrustCertificate -InputObject $serverTrustCertificate
```

This command removes the server trust certificate specified by certificate object.

### Example 4: Remove a server trust certificate by its parent instance object
```powershell
$instance = Get-AzSqlInstance -ResourceGroupName "ResourceGroup01" -Name "ManagedInstance01" 
Remove-AzSqlInstanceServerTrustCertificate -InstanceObject $instance -Name "Certificate01"
```

This command removes the server trust certificate "Certificate01" from the managed instance specified by the instance object.

### Example 5: Remove a server trust certificate using positional parameters
```powershell
Remove-AzSqlInstanceServerTrustCertificate "ResourceGroup01" "ManagedInstance01" "Certificate01"
```

This command removes the server trust certificate "Certificate01" from the managed instance "ManagedInstance01" using positional parameters.

### Example 6: Remove all server trust certificate from its parent instance
```powershell
$instance = Get-AzSqlInstance -ResourceGroupName "ResourceGroup01" -Name "ManagedInstance01" 
$instance | Get-AzSqlInstanceServerTrustCertificate | Remove-AzSqlInstanceServerTrustCertificate
```

This command removes all server trust certificates from instance "ManagedInstance01".

### Example 7: Remove a server trust certificate and outputs the deleted certificate object
```powershell
Remove-AzSqlInstanceServerTrustCertificate "ResourceGroup01" "ManagedInstance01" "Certificate01" -PassThru
```

```output
ResourceGroupName : ResourceGroup01
InstanceName      : ManagedInstance01
Id                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ResourceGroup01/providers/Microsoft.Sql/managedInstances/ManagedInstance01/serverTrustCertificates/Certificate01
Type              : Microsoft.Sql/managedInstances/serverTrustCertificates
Name              : Certificate01
Thumbprint        : 0x7D989DF34BD0FD0D2F9F6B3B6A7096856F5AB004
PublicKey         : 0x1C8E3F85BCD8A2C1D082CE42D7A1E8112651A906B15F5F244134142C53B050FCBF2571965C522EBB86B4F1B790F3AD31E689950EE909B87C25A1BB51DA328BEEB1BB0FD44AB3CB774B8CC9F72B486476DEB8B1C95210B84C4A0F18310CD83F299CAF0D567EBCE2DD008581622D72499F8EC9A686BA526916E7F78DCA90BA0ADD8C2E5F601017D374E2FBD0818458BFC11C8268BC21383613323153163C0F33E09D03586A3BBFDA3628F0358FBADE41602BD05C4E47CDB67A9914F35B315B7844C2F2D1352034B56D6B155D38415B816247779E7A0EB3431765D9A48F4649E647CCD2EA8F38E8B5D415833BA8337BA00FED2F00D9066B9CAEF7BAA8C553F7B8787BCEF63AC98E05372981520BD5A598356590736B547F3B300F1D710EC3003D398AEB94589E196C42C5F6A1873D6138D9F666A2D6F24DAFB12FBD6B0124B2CFFAD51EF67032832900A9E113625BE4C4FB012923BB9886B52B733A5F8BFF04122A2474828F2EE5FC66154D9EBA92A21F0BFD6E8AAEE7DCC45BB3883A410E603C9D98A5BB913853D1B7543E694FF74F8CA9174BE152A96530803DD03C15BC258E77925877BCAF748CA85230ABBF90789F4856200166D110D369FB03B6593339CCE498CDA69016289056F4638E761B9904129DB36B6B4CD17D49567C27FF11059C0569ABF48C438CB6128F2B2F245BDB066B6BF1155BCA11E9D6B0BD8A1607F2F5BB42AF7498D1B8410AA1E5E3E23A3CA6FB933D3894C8D1A2162E735CFCB7BEDFB3318DAE32AE9E24900B9B0F472ABD563550C9E696836889123F0ED2E7A9A4B90C2C617C8ADCF088CE2A7EC8AB97A80C00F3296241C7B320118A1182E327919007930417004A301249EAACF139D611D9C30DAFDF8672F5347C488250F46D45E7D7E9BF3BE99ECD1C60A046FC80EB1DC473FD2E1A7672235F8A834338A4810E32CB24C9C24D09234995A3D038D70379B900E6C9217EF19062775B050CF7CA52D3D72E294E2315AA544247B436D46AD08D55957B9688C576E35760B527B7F7EB71E6209301C59B6643C921F2FB182D237E81DC6205BF6740C8EDC48C65DAB0546C1098C2DCBF0E3B31A47868A721942022E0B5DBFFFBBC4767699C7F0ABD6DEBE7D5FB91
```

This command removes all instance links from the managed instance "ManagedInstance01" and outputs the deleted instance link object.

## PARAMETERS

### -AsJob
Run cmdlet in the background

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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Certificate input object.

```yaml
Type: Microsoft.Azure.Commands.Sql.ServerTrustCertificate.Model.AzureSqlInstanceServerTrustCertificateModel
Parameter Sets: DeleteByInputObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InstanceName
Name of Azure SQL Managed Instance.

```yaml
Type: System.String
Parameter Sets: DeleteByNameParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstanceObject
Instance input object.

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel
Parameter Sets: DeleteByParentObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the certificate.

```yaml
Type: System.String
Parameter Sets: DeleteByNameParameterSet, DeleteByParentObjectParameterSet
Aliases: CertificateName

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Defines whether to return the removed Server Trust Certificate

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
Name of the resource group.

```yaml
Type: System.String
Parameter Sets: DeleteByNameParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Certificate resource ID.

```yaml
Type: System.String
Parameter Sets: DeleteByResourceIdParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel

### Microsoft.Azure.Commands.Sql.ServerTrustCertificate.Model.AzureSqlInstanceServerTrustCertificateModel

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ServerTrustCertificate.Model.AzureSqlInstanceServerTrustCertificateModel

## NOTES

## RELATED LINKS

[Get-AzSqlInstanceServerTrustCertificate](./Get-AzSqlInstanceServerTrustCertificate.md)

[New-AzSqlInstanceServerTrustCertificate](./New-AzSqlInstanceServerTrustCertificate.md)
