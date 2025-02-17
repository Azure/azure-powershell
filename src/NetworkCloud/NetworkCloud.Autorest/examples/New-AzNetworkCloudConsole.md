### Example 1: Create virtual machine's console
```powershell
New-AzNetworkCloudConsole -ResourceGroupName resourceGroupName -Location location -ExtendedLocationName "/subscriptions/subscriptionId/resourcegroups/clusterManagerHostedResourceGroup/providers/microsoft.extendedlocation/customlocations/clusterManagerExtendedLocation" -ExtendedLocationType "CustomLocation" -SubscriptionId subscriptionId -Tag @{tags="tag1"} -Enabled ConsoleEnabled.True -VirtualMachineName virtualMachineName -SshPublicKeyData "ssh-rsa StNw+/C+g0tOZLT9OKK6YTovOn= fakekey@vm" -Expiration "2024-07-01T01:27:03.008Z"
```

```output
Location Name    SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataL
                                                                                                                                                  astModified
                                                                                                                                                  ByType
-------- ----    ------------------- -------------------    ----------------------- ------------------------ ------------------------             -----------
eastus   default 06/27/2023 21:32:03 <user>                 User                    06/27/2023 21:32:41      <identity>                           Application
```

This command creates a virtual machine console.
