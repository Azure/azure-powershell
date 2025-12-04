### Example 1: Create an in-memory object for IpAddressPool.

```powershell
New-AzNetworkCloudIpAddressPoolObject -Address @("198.51.102.0/24") -Name "pool1" -AutoAssign True -OnlyUseHostIP True 
```

```output
Address           AutoAssign Name  OnlyUseHostIP
-------           ---------- ----  -------------
{198.51.102.0/24} True       pool1 True
```

Create an in-memory object for IpAddressPool.
