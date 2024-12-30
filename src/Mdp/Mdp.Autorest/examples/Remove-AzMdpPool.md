### Example 1: Delete a Managed DevOps Pool 
```powershell
Remove-AzMdpPool -Name Contoso -ResourceGroupName testRg
```
This command deletes the Managed DevOps Pool named "Contoso" in the resource group "testRg".

### Example 2: Delete a Managed DevOps Pool using InputObject
```powershell
$pool = Get-AzMdpPool -ResourceGroupName testRg -Name Contoso

Remove-AzMdpPool -InputObject $pool
```
This command deletes the Managed DevOps Pool named "Contoso" in the resource group "testRg".
