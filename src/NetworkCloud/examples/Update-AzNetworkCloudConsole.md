### Example 1: Update virtual machine's console
```powershell
$tagUpdatedHash = @{
    tag1 = "tag1"
    tag2 = "tag1Update"
}

Update-AzNetworkCloudConsole -ResourceGroupName resourceGroupName -VirtualMachineName virtualMachineName -Name "default" -Tag $tagUpdatedHash -Expiration "2023-07-02T01:27:03.008Z" -SshPublicKeyData "sshPublicKey"
```

```output
Location Name    SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataL
                                                                                                                                                  astModified
                                                                                                                                                  ByType
-------- ----    ------------------- -------------------    ----------------------- ------------------------ ------------------------             -----------
eastus   default 06/27/2023 21:32:03 <user>                 User                    06/27/2023 21:32:41      <identity>                           Application
```

This command updates properties of a virtual machine's console.
