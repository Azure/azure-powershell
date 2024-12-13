function Get-VaultIdentity {
    
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
    param (
        [Parameter(Mandatory=$true)]
        [System.Object] $vault,

        [Parameter(Mandatory=$false)]
        [System.String] $UserAssignedIdentityARMId
    )

    #Determine the vault MSI to be used
    $vaultIdentity = $null
    if ($UserAssignedIdentityARMId) {        
        $vaultIdentity = $vault.Identity.UserAssignedIdentity[$UserAssignedIdentityARMId].PrincipalID
        Write-Host "Using Vault UAMI with ARMId: $UserAssignedIdentityARMId with Principal ID: $vaultIdentity"
    } else {
        $vaultIdentity = $vault.Identity.PrincipalId
        Write-Host "Using system-assigned identity with Principal ID: $vaultIdentity"
    }

    if (-not $vaultIdentity) {
        throw "Vault identity could not be determined. Please check the UserAssignedIdentityARMId or the vault configuration."
    }

    return $vaultIdentity
}

function Set-AzDataProtectionMSIPermission {
    [OutputType('System.Object')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact = 'High')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Grants required permissions to the backup vault and other resources for configure backup and restore scenarios')]

    param(
        [Parameter(ParameterSetName="SetPermissionsForBackup", Mandatory, HelpMessage='Backup instance request object which will be used to configure backup')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IBackupInstanceResource]
        ${BackupInstance},
        
        [Parameter(ParameterSetName="SetPermissionsForBackup", Mandatory=$false, HelpMessage='ID of the keyvault')]
        [ValidatePattern("/subscriptions/([A-z0-9\-]+)/resourceGroups/(?<rg>.+)/(?<id>.+)")]
        [System.String]
        ${KeyVaultId},

        [Parameter(ParameterSetName="SetPermissionsForRestore", Mandatory=$false, HelpMessage='Subscription Id of the backup vault')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='Resource group of the backup vault')]
        [Alias('ResourceGroupName')]
        [System.String]
        ${VaultResourceGroup},
        
        [Parameter(Mandatory, HelpMessage='Name of the backup vault')]
        [System.String]
        ${VaultName},

        [Parameter(Mandatory, HelpMessage='Scope at which the permissions need to be granted')]
        [System.String]
        [ValidateSet("Resource","ResourceGroup","Subscription")]
        ${PermissionsScope},

        [Parameter(ParameterSetName="SetPermissionsForRestore", Mandatory=$false, HelpMessage='Datasource Type')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.DatasourceTypes]
        ${DatasourceType},

        [Parameter(ParameterSetName="SetPermissionsForRestore", Mandatory, HelpMessage='Restore request object which will be used for restore')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IAzureBackupRestoreRequest]
        ${RestoreRequest},

        [Parameter(ParameterSetName="SetPermissionsForRestore", Mandatory=$false, HelpMessage='Sanpshot Resource Group')]
        [System.String]
        [ValidatePattern("/subscriptions/([A-z0-9\-]+)/resourceGroups/(?<rg>.+)")]
        ${SnapshotResourceGroupId},

        [Parameter(ParameterSetName="SetPermissionsForRestore", Mandatory=$false, HelpMessage='Target storage account ARM Id. Use this parameter for DatasourceType AzureDatabaseForMySQL, AzureDatabaseForPGFlexServer.')]
        [System.String]
        ${StorageAccountARMId},

        [Parameter(Mandatory=$false, HelpMessage='User Assigned Identity ARM ID of the backup vault to be used for assigning permissions')]
        [Alias('AssignUserIdentity')]
        [System.String]
        ${UserAssignedIdentityARMId}
    )

    process {
          CheckResourcesModuleDependency
          
          $OriginalWarningPreference = $WarningPreference
          $WarningPreference = 'SilentlyContinue'
          
          $MissingRolesInitially = $false

          if($PsCmdlet.ParameterSetName -eq "SetPermissionsForRestore"){
                            
              $DatasourceId = $RestoreRequest.RestoreTargetInfo.DatasourceInfo.ResourceId

              $DatasourceTypeInternal = ""
              $subscriptionIdInternal = ""
              if($DataSourceId -ne $null){
                  $DatasourceTypeInternal =  GetClientDatasourceType -ServiceDatasourceType $RestoreRequest.RestoreTargetInfo.DatasourceInfo.Type
                  
                  $ResourceArray = $DataSourceId.Split("/")
                  $ResourceRG = GetResourceGroupIdFromArmId -Id $DataSourceId
                  $SubscriptionName = GetSubscriptionNameFromArmId -Id $DataSourceId
                  $subscriptionIdInternal = $ResourceArray[2]

                  if($DatasourceType -ne $null -and $DatasourceTypeInternal -ne $DatasourceType){
                      throw "DatasourceType is not compatible with the RestoreRequest"
                  }
              }
              elseif($DatasourceType -ne $null){
                  $DatasourceTypeInternal = $DatasourceType

                  if($SubscriptionId -eq ""){
                      
                      $err = "SubscriptionId can't be identified. Please provide the value for parameter SubscriptionId"
                      throw $err
                  }
                  else{
                      $subscriptionIdInternal = $SubscriptionId
                  }
              }
              else{
                  $err = "DatasourceType can't be identified since DataSourceInfo is null. Please provide the value for parameter DatasourceType"
                  throw $err
              }

              $manifest = LoadManifest -DatasourceType $DatasourceTypeInternal.ToString()              
              
              $vault = Az.DataProtection\Get-AzDataProtectionBackupVault -VaultName $VaultName -ResourceGroupName $VaultResourceGroup -SubscriptionId $subscriptionIdInternal
              $vaultIdentity = Get-VaultIdentity -vault $vault -UserAssignedIdentityARMId $UserAssignedIdentityARMId
                            
              if(-not $manifest.supportRestoreGrantPermission){
                  $err = "Set permissions for restore is currently not supported for given DataSourceType"
                  throw $err
              }
                            
              if(($manifest.dataSourceOverSnapshotRGPermissions.Length -gt 0 -or $manifest.snapshotRGPermissions.Length -gt 0) -and $SnapshotResourceGroupId -eq ""){
                  $warning = "SnapshotResourceGroupId parameter is required to assign permissions over snapshot resource group, skipping"
                  Write-Warning $warning
              }
              else{
                  foreach($Permission in $manifest.dataSourceOverSnapshotRGPermissions)
                  {
                      if($DatasourceTypeInternal -eq "AzureKubernetesService"){
                          CheckAksModuleDependency
                                    
                          $aksCluster = Get-AzAksCluster -Id $RestoreRequest.RestoreTargetInfo.DataSourceInfo.ResourceId -SubscriptionId $subscriptionIdInternal

                          $dataSourceMSI = ""
                          if($aksCluster.Identity.Type -match "UserAssigned"){
                              $UAMIKey = $aksCluster.Identity.UserAssignedIdentities.Keys[0]

                              if($UAMIKey -eq "" -or $UAMIKey -eq $null){
                                  Write-Error "User assigned identity not found for AKS cluster."
                              }
                              $dataSourceMSI = $aksCluster.Identity.UserAssignedIdentities[$UAMIKey].PrincipalId
                          }
                          else{
                              $dataSourceMSI = $aksCluster.Identity.PrincipalId
                          }

                          $dataSourceMSIRoles = Az.Resources\Get-AzRoleAssignment -ObjectId $dataSourceMSI
                      }

                      # CSR: $SubscriptionName might be different when we add cross subscription restore
                      $CheckPermission = $dataSourceMSIRoles | Where-Object { ($_.Scope -eq $SnapshotResourceGroupId -or $_.Scope -eq $SubscriptionName)  -and $_.RoleDefinitionName -eq $Permission}

                      if($CheckPermission -ne $null)
                      {
                          Write-Host "Required permission $($Permission) is already assigned to target resource with Id $($RestoreRequest.RestoreTargetInfo.DataSourceInfo.ResourceId) over snapshot resource group with Id $($SnapshotResourceGroupId)"
                      }
                      else
                      {
                          # can add snapshot resource group name in allow statement
                          if ($PSCmdlet.ShouldProcess("$($RestoreRequest.RestoreTargetInfo.DataSourceInfo.ResourceId)","Allow $($Permission) permission over snapshot resource group"))
                          {
                              $MissingRolesInitially = $true
                              
                              AssignMissingRoles -ObjectId $dataSourceMSI -Permission $Permission -PermissionsScope $PermissionsScope -Resource $SnapshotResourceGroupId -ResourceGroup $SnapshotResourceGroupId -Subscription $SubscriptionName
  
                              Write-Host "Assigned $($Permission) permission to target resource with Id $($RestoreRequest.RestoreTargetInfo.DataSourceInfo.ResourceId) over snapshot resource group with Id $($SnapshotResourceGroupId)"
                          }
                      }
                  }

                  foreach($Permission in $manifest.snapshotRGPermissions)
                  {
                      $AllRoles = Az.Resources\Get-AzRoleAssignment -ObjectId $vaultIdentity

                      # CSR: $SubscriptionName might be different when we add cross subscription restore
                      $CheckPermission = $AllRoles | Where-Object { ($_.Scope -eq $SnapshotResourceGroupId -or $_.Scope -eq $SubscriptionName) -and $_.RoleDefinitionName -eq $Permission}

                      if($CheckPermission -ne $null)
                      {
                          Write-Host "Required permission $($Permission) is already assigned to backup vault over snapshot resource group with Id $($SnapshotResourceGroupId)"
                      }

                      else
                      {
                          $MissingRolesInitially = $true

                          AssignMissingRoles -ObjectId $vaultIdentity -Permission $Permission -PermissionsScope $PermissionsScope -Resource $SnapshotResourceGroupId -ResourceGroup $SnapshotResourceGroupId -Subscription $SubscriptionName
  
                          Write-Host "Assigned $($Permission) permission to the backup vault over snapshot resource group with Id $($SnapshotResourceGroupId)"
                      }
                  }
              }

              foreach($Permission in $manifest.datasourcePermissionsForRestore)
              {
                  # set context to the subscription where ObjectId is present
                  $AllRoles = Az.Resources\Get-AzRoleAssignment -ObjectId $vaultIdentity

                  $CheckPermission = $AllRoles | Where-Object { ($_.Scope -eq $DataSourceId -or $_.Scope -eq $ResourceRG -or  $_.Scope -eq $SubscriptionName) -and $_.RoleDefinitionName -eq $Permission}

                  if($CheckPermission -ne $null)
                  {   
                      Write-Host "Required permission $($Permission) is already assigned to backup vault over DataSource with Id $($DataSourceId)"
                  }

                  else
                  {
                      $MissingRolesInitially = $true
                   
                      AssignMissingRoles -ObjectId $vaultIdentity -Permission $Permission -PermissionsScope $PermissionsScope -Resource $DataSourceId -ResourceGroup $ResourceRG -Subscription $SubscriptionName

                      Write-Host "Assigned $($Permission) permission to the backup vault over DataSource with Id $($DataSourceId)"
                  }
              }

              foreach($Permission in $manifest.storageAccountPermissionsForRestore)
              {
                  # set context to the subscription where ObjectId is present
                  $AllRoles = Az.Resources\Get-AzRoleAssignment -ObjectId $vaultIdentity

                  $targetResourceArmId = $restoreRequest.RestoreTargetInfo.TargetDetail.TargetResourceArmId

                  if($targetResourceArmId -ne $null -and $targetResourceArmId -ne ""){
                      if(-not $targetResourceArmId.Contains("/blobServices/")){
                          $err = "restoreRequest.RestoreTargetInfo.TargetDetail.TargetResourceArmId is not in the correct format"
                          throw $err
                      }

                      $storageAccId = ($targetResourceArmId -split "/blobServices/")[0]
                      $storageAccResourceGroupId = ($targetResourceArmId -split "/providers/")[0]
                      $storageAccountSubId = ($targetResourceArmId -split "/resourceGroups/")[0]
                  }
                  else{
                      if($StorageAccountARMId -eq ""){
                          $err = "Permissions can't be assigned to target storage account. Please input parameter StorageAccountARMId"
                          throw $err
                      }

                      # storage Account subscription and resource group
                      $storageAccountSubId = ($StorageAccountARMId -split "/resourceGroups/")[0]
                      $storageAccResourceGroupId = ($StorageAccountARMId -split "/providers/")[0]

                      # storage Account ID
                      $storageAccId = $StorageAccountARMId                      
                  }
                                    
                  $CheckPermission = $AllRoles | Where-Object { ($_.Scope -eq $storageAccId -or $_.Scope -eq $storageAccResourceGroupId -or  $_.Scope -eq $storageAccountSubId) -and $_.RoleDefinitionName -eq $Permission}

                  if($CheckPermission -ne $null)
                  {   
                      Write-Host "Required permission $($Permission) is already assigned to backup vault over storage account with Id $($storageAccId)"
                  }

                  else
                  {
                      $MissingRolesInitially = $true
                   
                      AssignMissingRoles -ObjectId $vaultIdentity -Permission $Permission -PermissionsScope $PermissionsScope -Resource $storageAccId -ResourceGroup $storageAccResourceGroupId -Subscription $storageAccountSubId

                      Write-Host "Assigned $($Permission) permission to the backup vault over  storage account with Id $($storageAccId)"
                  }
              }
          }

          elseif($PsCmdlet.ParameterSetName -eq "SetPermissionsForBackup"){
              $DatasourceId = $BackupInstance.Property.DataSourceInfo.ResourceId
              $DatasourceType =  GetClientDatasourceType -ServiceDatasourceType $BackupInstance.Property.DataSourceInfo.Type 
              $manifest = LoadManifest -DatasourceType $DatasourceType.ToString()

              $ResourceArray = $DataSourceId.Split("/")
              $ResourceRG = GetResourceGroupIdFromArmId -Id $DataSourceId
              $SubscriptionName = GetSubscriptionNameFromArmId -Id $DataSourceId
              $subscriptionId = $ResourceArray[2]

              $vault = Az.DataProtection\Get-AzDataProtectionBackupVault -VaultName $VaultName -ResourceGroupName $VaultResourceGroup -SubscriptionId $ResourceArray[2]
              $vaultIdentity = Get-VaultIdentity -vault $vault -UserAssignedIdentityARMId $UserAssignedIdentityARMId
              
              $AllRoles = Az.Resources\Get-AzRoleAssignment -ObjectId $vaultIdentity

              # If more DataSourceTypes support this then we can make it manifest driven
              if($DatasourceType -eq "AzureDatabaseForPostgreSQL")
              {
                  CheckPostgreSqlModuleDependency
                  CheckKeyVaultModuleDependency

                  if($KeyVaultId -eq "" -or $KeyVaultId -eq $null)
                  {
                      Write-Error "KeyVaultId not provided. Please provide the KeyVaultId parameter to successfully assign the permissions on the keyvault"
                  }

                  $KeyvaultName = GetResourceNameFromArmId -Id $KeyVaultId
                  $KeyvaultRGName = GetResourceGroupNameFromArmId -Id $KeyVaultId
                  $ServerName = GetResourceNameFromArmId -Id $DataSourceId
                  $ServerRG = GetResourceGroupNameFromArmId -Id $DataSourceId
                
                  $KeyvaultArray = $KeyVaultId.Split("/")
                  $KeyvaultRG = GetResourceGroupIdFromArmId -Id $KeyVaultId
                  $KeyvaultSubscriptionName = GetSubscriptionNameFromArmId -Id $KeyVaultId

                  if ($PSCmdlet.ShouldProcess("KeyVault: $($KeyvaultName) and PostgreSQLServer: $($ServerName)","
                              1.'Allow All Azure services' under network connectivity in the Postgres Server
                              2.'Allow Trusted Azure services' under network connectivity in the Key vault")) 
                  {                    
                      Update-AzPostgreSqlServer -ResourceGroupName $ServerRG -ServerName $ServerName -PublicNetworkAccess Enabled| Out-Null
                      New-AzPostgreSqlFirewallRule -Name AllowAllAzureIps -ResourceGroupName $ServerRG -ServerName $ServerName -EndIPAddress 0.0.0.0 -StartIPAddress 0.0.0.0 | Out-Null
                     
                      $SecretsList = ""
                      try{$SecretsList =  Get-AzKeyVaultSecret -VaultName $KeyvaultName}
                      catch{
                          $err = $_
                          throw $err
                      }
              
                      $SecretValid = $false
                      $GivenSecretUri = $BackupInstance.Property.DatasourceAuthCredentials.SecretStoreResource.Uri
              
                      foreach($Secret in $SecretsList)
                      {
                          $SecretArray = $Secret.Id.Split("/")
                          $SecretArray[2] = $SecretArray[2] -replace "....$"
                          $SecretUri = $SecretArray[0] + "/" + $SecretArray[1] + "/"+  $SecretArray[2] + "/" +  $SecretArray[3] + "/" + $SecretArray[4] 
                              
                          if($Secret.Enabled -eq "true" -and $SecretUri -eq $GivenSecretUri)
                          {
                              $SecretValid = $true
                          }
                      }

                      if($SecretValid -eq $false)
                      {
                          $err = "The Secret URI provided in the backup instance is not associated with the keyvault Id provided. Please provide a valid combination of Secret URI and keyvault Id"
                          throw $err
                      }

                      if($KeyVault.PublicNetworkAccess -eq "Disabled")
                      {
                          $err = "Keyvault needs to have public network access enabled"
                          throw $err
                      }
            
                      try{$KeyVault = Get-AzKeyVault -VaultName $KeyvaultName}
                      catch{
                          $err = $_
                          throw $err
                      }    
            
                      try{Update-AzKeyVaultNetworkRuleSet -VaultName $KeyvaultName -Bypass AzureServices -Confirm:$False}
                      catch{
                          $err = $_
                          throw $err
                      }
                  }
              }

              foreach($Permission in $manifest.keyVaultPermissions)
              {
                  if($KeyVault.EnableRbacAuthorization -eq $false )
                  {
                     try{                    
                          $KeyVault = Get-AzKeyVault -VaultName $KeyvaultName 
                          $KeyVaultAccessPolicies = $KeyVault.AccessPolicies

                          $KeyVaultAccessPolicy =  $KeyVaultAccessPolicies | Where-Object {$_.ObjectID -eq $vaultIdentity}

                          if($KeyVaultAccessPolicy -eq $null)
                          {                         
                            Set-AzKeyVaultAccessPolicy -VaultName $KeyvaultName -ObjectId $vaultIdentity -PermissionsToSecrets Get,List -Confirm:$False 
                            break
                          }

                          $KeyvaultAccessPolicyPermissions = $KeyVaultAccessPolicy."PermissionsToSecrets"
                          $KeyvaultAccessPolicyPermissions+="Get"
                          $KeyvaultAccessPolicyPermissions+="List"
                          [String[]]$FinalKeyvaultAccessPolicyPermissions = $KeyvaultAccessPolicyPermissions
                          $FinalKeyvaultAccessPolicyPermissions = $FinalKeyvaultAccessPolicyPermissions | select -uniq                      
                      
                          Set-AzKeyVaultAccessPolicy -VaultName $KeyvaultName -ObjectId $vaultIdentity -PermissionsToSecrets $FinalKeyvaultAccessPolicyPermissions -Confirm:$False 
                     }
                     catch{
                         $err = $_
                         throw $err
                     }
                  }

                  else
                  {
                      $CheckPermission = $AllRoles | Where-Object { ($_.Scope -eq $KeyVaultId -or $_.Scope -eq $KeyvaultRG -or  $_.Scope -eq $KeyvaultSubscription) -and $_.RoleDefinitionName -eq $Permission}

                      if($CheckPermission -ne $null)
                      {
                          Write-Host "Required permission $($Permission) is already assigned to backup vault over KeyVault with Id $($KeyVaultId)"
                      }

                      else
                      {
                          $MissingRolesInitially = $true
                                                    
                          AssignMissingRoles -ObjectId $vaultIdentity -Permission $Permission -PermissionsScope $PermissionsScope -Resource $KeyVaultId -ResourceGroup $KeyvaultRG -Subscription $KeyvaultSubscriptionName

                          Write-Host "Assigned $($Permission) permission to the backup vault over key vault with Id $($KeyVaultId)"
                      }
                  }
              }
              
              foreach($Permission in $manifest.dataSourceOverSnapshotRGPermissions)
              {
                  $SnapshotResourceGroupId = $BackupInstance.Property.PolicyInfo.PolicyParameter.DataStoreParametersList[0].ResourceGroupId              
              
                  if($DatasourceType -eq "AzureKubernetesService"){                  
                      CheckAksModuleDependency
                                    
                      $aksCluster = Get-AzAksCluster -Id $BackupInstance.Property.DataSourceInfo.ResourceId -SubscriptionId $subscriptionId

                      $dataSourceMSI = ""
                      if($aksCluster.Identity.Type -match "UserAssigned"){
                          $UAMIKey = $aksCluster.Identity.UserAssignedIdentities.Keys[0]

                          if($UAMIKey -eq "" -or $UAMIKey -eq $null){
                              Write-Error "User assigned identity not found for AKS cluster."
                          }
                          $dataSourceMSI = $aksCluster.Identity.UserAssignedIdentities[$UAMIKey].PrincipalId
                      }
                      else{
                          $dataSourceMSI = $aksCluster.Identity.PrincipalId
                      }
                      
                      $dataSourceMSIRoles = Az.Resources\Get-AzRoleAssignment -ObjectId $dataSourceMSI
                  }

                  # CSR: $SubscriptionName might be different when we add cross subscription restore
                  $CheckPermission = $dataSourceMSIRoles | Where-Object { ($_.Scope -eq $SnapshotResourceGroupId -or $_.Scope -eq $SubscriptionName) -and $_.RoleDefinitionName -eq $Permission}

                  if($CheckPermission -ne $null)
                  {
                      Write-Host "Required permission $($Permission) is already assigned to DataSource with Id $($BackupInstance.Property.DataSourceInfo.ResourceId) over snapshot resource group with Id $($SnapshotResourceGroupId)"
                  }

                  else
                  {   
                      # can add snapshot resource group name in allow statement
                      if ($PSCmdlet.ShouldProcess("$($BackupInstance.Property.DataSourceInfo.ResourceId)","Allow $($Permission) permission over snapshot resource group"))
                      {
                          $MissingRolesInitially = $true
                          
                          AssignMissingRoles -ObjectId $dataSourceMSI -Permission $Permission -PermissionsScope $PermissionsScope -Resource $SnapshotResourceGroupId -ResourceGroup $SnapshotResourceGroupId -Subscription $SubscriptionName
  
                          Write-Host "Assigned $($Permission) permission to DataSource with Id $($BackupInstance.Property.DataSourceInfo.ResourceId) over snapshot resource group with Id $($SnapshotResourceGroupId)"
                      }                  
                  }
              }

              foreach($Permission in $manifest.snapshotRGPermissions)
              {
                  $SnapshotResourceGroupId = $BackupInstance.Property.PolicyInfo.PolicyParameter.DataStoreParametersList[0].ResourceGroupId
              
                  # CSR: $SubscriptionName might be different when we add cross subscription restore
                  $AllRoles = Az.Resources\Get-AzRoleAssignment -ObjectId $vaultIdentity
                  $CheckPermission = $AllRoles | Where-Object { ($_.Scope -eq $SnapshotResourceGroupId -or $_.Scope -eq $SubscriptionName)  -and $_.RoleDefinitionName -eq $Permission}

                  if($CheckPermission -ne $null)
                  {
                      Write-Host "Required permission $($Permission) is already assigned to backup vault over snapshot resource group with Id $($SnapshotResourceGroupId)"
                  }

                  else
                  {
                      $MissingRolesInitially = $true

                      AssignMissingRoles -ObjectId $vaultIdentity -Permission $Permission -PermissionsScope $PermissionsScope -Resource $SnapshotResourceGroupId -ResourceGroup $SnapshotResourceGroupId -Subscription $SubscriptionName
  
                      Write-Host "Assigned $($Permission) permission to the backup vault over snapshot resource group with Id $($SnapshotResourceGroupId)"
                  }
              }

              foreach($Permission in $manifest.datasourcePermissions)
              {
                  $AllRoles = Az.Resources\Get-AzRoleAssignment -ObjectId $vaultIdentity
                  $CheckPermission = $AllRoles | Where-Object { ($_.Scope -eq $DataSourceId -or $_.Scope -eq $ResourceRG -or  $_.Scope -eq $SubscriptionName) -and $_.RoleDefinitionName -eq $Permission}
              
                  if($CheckPermission -ne $null)
                  {
                      Write-Host "Required permission $($Permission) is already assigned to backup vault over DataSource with Id $($DataSourceId)"
                  }

                  else
                  {
                      $MissingRolesInitially = $true
                                            
                      AssignMissingRoles -ObjectId $vaultIdentity -Permission $Permission -PermissionsScope $PermissionsScope -Resource $DataSourceId -ResourceGroup $ResourceRG -Subscription $SubscriptionName

                      Write-Host "Assigned $($Permission) permission to the backup vault over DataSource with Id $($DataSourceId)"
                  }
              }

              foreach($Permission in $manifest.datasourceRGPermissions)
              {
                  $AllRoles = Az.Resources\Get-AzRoleAssignment -ObjectId $vaultIdentity
                  $CheckPermission = $AllRoles | Where-Object { ($_.Scope -eq $ResourceRG -or  $_.Scope -eq $SubscriptionName) -and $_.RoleDefinitionName -eq $Permission}
              
                  if($CheckPermission -ne $null)
                  {
                      Write-Host "Required permission $($Permission) is already assigned to backup vault over DataSource resource group with name $($ResourceRG)"
                  }

                  else
                  {
                      $MissingRolesInitially = $true
                      
                      # "Resource","ResourceGroup","Subscription"
                      $DatasourceRGScope = $PermissionsScope
                      if($PermissionsScope -eq "Resource"){
                          $DatasourceRGScope = "ResourceGroup"
                      }

                      AssignMissingRoles -ObjectId $vaultIdentity -Permission $Permission -PermissionsScope $DatasourceRGScope -Resource $DataSourceId -ResourceGroup $ResourceRG -Subscription $SubscriptionName

                      Write-Host "Assigned $($Permission) permission to the backup vault over DataSource resource group with name $($ResourceRG)"
                  }
              }
          }

          if($MissingRolesInitially -eq $true)
          {
              Write-Host "Waiting for 60 seconds for roles to propagate"
              Start-Sleep -Seconds 60
          }
          
          $WarningPreference = $OriginalWarningPreference          
    }
}