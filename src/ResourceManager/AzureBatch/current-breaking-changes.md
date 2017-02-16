* Removed the `RunElevated` switch on the `New-AzureBatchTask` cmdlet. The `UserIdentity` parameter has been added to replace `RunElevated`, and the equivalent behavior can be achieved by constructing a `PSUserIdentity` as shown below:
    - $autoUser = New-Object Microsoft.Azure.Commands.Batch.Models.PSAutoUserSpecification -ArgumentList @("Task", "Admin")
    - $userIdentity = New-Object Microsoft.Azure.Commands.Batch.Models.PSUserIdentity $autoUser
* Removed the `RunElevated` property on `PSCloudTask`, `PSStartTask`, `PSJobManagerTask`, `PSJobPreparationTask`, and `PSJobReleaseTask`. The `UserIdentity` property has been added to replace `RunElevated`. Equivalent behavior to `RunElevated = $true` can be achieved by constructing a `PSUserIdentity` as shown below:
    - $autoUser = New-Object Microsoft.Azure.Commands.Batch.Models.PSAutoUserSpecification -ArgumentList @("Task", "Admin")
    - $userIdentity = New-Object Microsoft.Azure.Commands.Batch.Models.PSUserIdentity $autoUser
* Renamed the `Name` property on `PSNodeFile` to `Path`.