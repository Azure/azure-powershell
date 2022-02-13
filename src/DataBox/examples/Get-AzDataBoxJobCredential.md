### Example 1: Get databoxHeavy job credential
```powershell
PS C:\> Get-AzDataBoxJobCredential -Name "DtbxPowershell" -ResourceGroupName "resourceGroupName"

PS C:\> $obj = Get-AzDataBoxJobCredential -Name TJy-637522091284252285 -ResourceGroupName bvttoolrg12-Wednesday
PS C:\> $obj | Format-List

AdditionalInfo                          :
Code                                    :
DcAccessSecurityCodeForwardDcAccessCode :
DcAccessSecurityCodeReverseDcAccessCode :
Detail                                  :
JobName                                 : DtbxPowershell
JobSecret                               : Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DataBoxHeavyJobSecrets
JobSecretJobSecretsType                 : DataBoxHeavy
Message                                 :
Target                                  :


PS C:\> $obj.JobSecret | Format-List

AdditionalInfo                          :
CabinetPodSecret                        : {, }
Code                                    :
DcAccessSecurityCode                    : Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.DcAccessSecurityCode
DcAccessSecurityCodeForwardDcAccessCode :
DcAccessSecurityCodeReverseDcAccessCode :
Detail                                  :
Error                                   : Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20210301.CloudError
Message                                 :
Target                                  :
Type                                    : DataBoxHeavy

PS C:\> $cabinetJobSecret = $obj.JobSecret.CabinetPodSecret | Format-List
```

Get databoxHeavy job credential 