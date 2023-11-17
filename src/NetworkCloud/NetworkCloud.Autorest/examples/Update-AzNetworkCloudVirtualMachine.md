### Example 1: Update virtual machine
```powershell
$tagUpdatedHash = @{
    tag1 = "tag1"
    tag2 = "tag1Update"
}
$registryPassword = ConvertTo-SecureString "password" -asplaintext -force

Update-AzNetworkCloudVirtualMachine -Name vmName -ResourceGroupName resourceGroup -Tag $tagUpdatedHash -VMImageRepositoryCredentialsRegistryUrl registryUrl -VMImageRepositoryCredentialsUsername registryUsername -VMImageRepositoryCredentialsPassword $registryPassword
```

```output
Location Name    SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataL
                                                                                                                                                  astModified
                                                                                                                                                  ByType
-------- ----    ------------------- -------------------    ----------------------- ------------------------ ------------------------             -----------
eastus   default 07/07/2023 21:29:03 <user>                 User                    07/07/2023 21:32:41      <identity>                           Application
```

This command updates properties of a virtual machine.
