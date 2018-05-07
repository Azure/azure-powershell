namespace Microsoft.Azure.Commands.KeyVault.Provider
{
    using Common.Authentication;
    using Common.Authentication.Abstractions;
    using System;
    using System.IO;
    using System.Management.Automation;
    using System.Management.Automation.Provider;
    using Models;
    using Management.Internal.Resources;
    using Management.Internal.Resources.Utilities;
    using System.Linq;
    using Management.Internal.Resources.Models;
    using Management.KeyVault.Models;
    using System.Collections;
    using System.Security;
    using Azure.ActiveDirectory.GraphClient;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Azure.KeyVault.Models;
    using Azure.KeyVault.WebKey;
    using Rest.Azure;
    using ResourceManager.Common.Tags;
    using Management.KeyVault;
    using System.Linq.Expressions;
    using System.Security.Cryptography.X509Certificates;
    using Management.Internal.Resources.Utilities.Models;

    #region KeyVaultProvider

    [CmdletProvider("KeyVault", ProviderCapabilities.ExpandWildcards)]
    public class KeyVaultProvider : NavigationCmdletProvider, IContentCmdletProvider
    {
        #region Private Properties

        /// The separator used in path statements.
        private string pathSeparator = "\\";

        protected readonly string[] DefaultPermissionsToKeys =
        {
            KeyPermissions.Get,
            KeyPermissions.Create,
            KeyPermissions.Delete,
            KeyPermissions.List,
            KeyPermissions.Update,
            KeyPermissions.Import,
            KeyPermissions.Backup,
            KeyPermissions.Restore,
            KeyPermissions.Recover
        };

        protected readonly string[] DefaultPermissionsToSecrets =
        {
            SecretPermissions.Get,
            SecretPermissions.List,
            SecretPermissions.Set,
            SecretPermissions.Delete,
            SecretPermissions.Backup,
            SecretPermissions.Restore,
            SecretPermissions.Recover
        };

        protected readonly string[] DefaultPermissionsToCertificates =
        {
            CertificatePermissions.Get,
            CertificatePermissions.Delete,
            CertificatePermissions.List,
            CertificatePermissions.Create,
            CertificatePermissions.Import,
            CertificatePermissions.Update,
            CertificatePermissions.Deleteissuers,
            CertificatePermissions.Getissuers,
            CertificatePermissions.Listissuers,
            CertificatePermissions.Managecontacts,
            CertificatePermissions.Manageissuers,
            CertificatePermissions.Setissuers,
            CertificatePermissions.Recover
        };

        protected readonly string[] DefaultPermissionsToStorage =
        {
            StoragePermissions.Delete,
            StoragePermissions.Deletesas,
            StoragePermissions.Get,
            StoragePermissions.Getsas,
            StoragePermissions.List,
            StoragePermissions.Listsas,
            StoragePermissions.Regeneratekey,
            StoragePermissions.Set,
            StoragePermissions.Setsas,
            StoragePermissions.Update,
        };

        protected readonly string DefaultSkuFamily = "A";
        protected readonly string DefaultSkuName = "Standard";

        #endregion Private Properties

        #region Drive Manipulation

        /// The Windows PowerShell engine calls this method when the 
        /// New-PSDrive cmdlet is run and the path to this provider is 
        /// specified. This method creates a connection to the database 
        /// file and sets the Connection property of the PSDriveInfo object.
        protected override PSDriveInfo NewDrive(PSDriveInfo drive)
        {
            if (drive == null)
            {
                WriteError(new ErrorRecord(
                           new ArgumentNullException("drive"),
                           "NullDrive",
                           ErrorCategory.InvalidArgument,
                           null));

                return null;
            }
            if (String.IsNullOrEmpty(drive.Root) || File.Exists(drive.Root))
            {
                WriteError(new ErrorRecord(
                           new ArgumentException("drive.Root"),
                           "NoRoot",
                           ErrorCategory.InvalidArgument,
                           drive));

                return null;
            }

            KVDriveInfo kvDriveInfo = new KVDriveInfo(drive);
            isLoggedIn();

            return kvDriveInfo;
        }

        /// The Windows PowerShell engine calls this method when the 
        /// Remove-PSDrive cmdlet is run and the path to this provider is 
        /// specified. This method closes the ODBC connection of the drive.
        protected override PSDriveInfo RemoveDrive(PSDriveInfo drive)
        {
            if (drive == null)
            {
                WriteError(new ErrorRecord(
                           new ArgumentNullException("drive"),
                           "NullDrive",
                           ErrorCategory.InvalidArgument,
                           drive));

                return null;
            }

            KVDriveInfo kvDriveInfo = drive as KVDriveInfo;

            if (kvDriveInfo == null)
            {
                return null;
            }

            return kvDriveInfo;
        }

        #endregion Drive Manipulation

        #region DriveHelperMethods

        private void isLoggedIn()
        {
            var profile = AzureRmProfileProvider.Instance.Profile;
            if (profile == null || profile.DefaultContext == null || profile.DefaultContext.Account == null)
            {
                WriteError(new ErrorRecord(
                           new ArgumentException("You are not logged into Azure. Please run Connect-AzureRmAccount before creating a drive for this Azure Provider."),
                           "NotLoggedIn",
                           ErrorCategory.SecurityError,
                           profile));
            }
        }

        #endregion DriveHelperMethods

        #region Item Methods

        /// The Windows PowerShell engine calls this method when the 
        /// Get-Item cmdlet is run and the path to this provider is 
        /// specified. This method retrieves an item using the specified path.
        protected override void GetItem(string path)
        {
            isLoggedIn();

            // Check to see if the path represents a valid drive.
            if (this.PathIsDrive(path))
            {
                WriteItemObject(this.PSDriveInfo, path, true);
                return;
            }

            if (!ItemExists(path))
            {
                throw new ItemNotFoundException(string.Format("Cannot find path {0} because it does not exist.", path));
            }

            var namesFromPath = ChunkPath(path);

            KVDriveInfo kvDriveInfo = this.PSDriveInfo as KVDriveInfo;

            var resourceGroupName = this.GetResourceGroupName(namesFromPath[0]);
            PSKeyVault vault = null;
            if (resourceGroupName != null)
            {
                vault = kvDriveInfo.KeyVaultClient.GetVault(namesFromPath[0], resourceGroupName, kvDriveInfo.ActiveDirectoryClient);
            }
            if (vault != null)
            {
                if (namesFromPath.Length == 1 || (namesFromPath.Length == 2 && namesFromPath[1].Equals("")))
                {
                    WriteItemObject(vault, path, true);
                }
                else if (namesFromPath.Length == 2 || (namesFromPath.Length == 3 && namesFromPath[2].Equals("")))
                {
                    if (namesFromPath[1].Equals("Secrets") || namesFromPath[1].Equals("Certificates") || namesFromPath[1].Equals("Keys") || namesFromPath[1].Equals("AccessPolicies"))
                    {
                        DirectoryInfo directory = new DirectoryInfo(path);
                        WriteItemObject(directory, path, true);
                    }
                }
                else if (namesFromPath.Length == 3)
                {
                    var dynamicParameters = DynamicParameters as GetItemSecCertKeyDynamicParameters;
                    bool includeVersions = dynamicParameters.IncludeVersions;
                    var version = dynamicParameters.Version == null ? string.Empty : dynamicParameters.Version;
                    if (includeVersions && version != string.Empty)
                    {
                        throw new Exception("-Version and -IncludeVersions cannot both be specified.");
                    }

                    if (namesFromPath[1] == "Secrets")
                    {
                        var secret = kvDriveInfo.KeyVaultDataServiceClient.GetSecret(namesFromPath[0], namesFromPath[2], version);
                        if (includeVersions)
                        {
                            if (secret != null)
                            {
                                secret.SecretValue = null;
                                WriteWarning("Run Get-Content to obtain the SecretValue of this secret.");
                                WriteItemObject(secret, path, false);
                                GetAndWriteObjects(new KeyVaultObjectFilterOptions
                                {
                                    VaultName = secret.VaultName,
                                    Name = secret.Name,
                                    NextLink = null
                                },
                                (options) => kvDriveInfo.KeyVaultDataServiceClient.GetSecretVersions(options).Where(s => s.Version != secret.Version), path);
                            }
                        }
                        else if (secret != null)
                        {
                            WriteWarning("Run Get-Content to obtain the SecretValue of this secret.");
                            secret.SecretValue = null;
                            WriteItemObject(secret, path, false);
                        }
                    }
                    else if (namesFromPath[1] == "Certificates")
                    {
                        PSKeyVaultCertificate certificate = kvDriveInfo.KeyVaultDataServiceClient.GetCertificate(namesFromPath[0], namesFromPath[2], version);
                        if (certificate != null && includeVersions)
                        {
                            WriteWarning("Run Get-Content to obtain the X509Certificate2 for this certificate.");
                            certificate.Certificate = null;
                            WriteItemObject(certificate, path, false);
                            KeyVaultObjectFilterOptions options = new KeyVaultObjectFilterOptions
                            {
                                VaultName = certificate.VaultName,
                                NextLink = null,
                                Name = certificate.Name
                            };

                            do
                            {
                                var pageResults = kvDriveInfo.KeyVaultDataServiceClient.GetCertificateVersions(options).Where(k => k.Version != certificate.Version);
                                foreach (var pageResult in pageResults)
                                {
                                    WriteItemObject(pageResult, path, false);
                                }
                            } while (!string.IsNullOrEmpty(options.NextLink));
                        }
                        else if (certificate != null)
                        {
                            WriteWarning("Run Get-Content to obtain the X509Certificate2 for this certificate.");
                            certificate.Certificate = null;
                            WriteItemObject(certificate, path, false);
                        }
                    }
                    else if (namesFromPath[1] == "Keys")
                    {
                        var key = kvDriveInfo.KeyVaultDataServiceClient.GetKey(namesFromPath[0], namesFromPath[2], version);
                        if (key != null && includeVersions)
                        {
                            WriteWarning("Run Get-Content to obtain the JsonWebKey for this key.");
                            key.Key = null;
                            WriteItemObject(key, path, false);
                            GetAndWriteObjects(new KeyVaultObjectFilterOptions
                            {
                                VaultName = key.VaultName,
                                NextLink = null,
                                Name = key.Name
                            },
                            (options) => kvDriveInfo.KeyVaultDataServiceClient.GetKeyVersions(options).Where(k => k.Version != key.Version), path);
                        }
                        else if (key != null)
                        {
                            WriteWarning("Run Get-Content to obtain the JsonWebKey for this key.");
                            key.Key = null;
                            WriteItemObject(key, path, false);
                        }
                    }
                    else if (namesFromPath[1] == "AccessPolicies")
                    {
                        foreach (var accessPolicy in vault.AccessPolicies)
                        {
                            if (accessPolicy.ObjectId.Equals(namesFromPath[2]))
                            {
                                WriteItemObject(accessPolicy, path, false);
                            }
                        }
                    }
                }
            }
        }

        /// The Windows PowerShell engine calls this method when the 
        /// Set-Item cmdlet is run and the path to this provider is 
        /// specified. This method sets the columns of a row using the 
        /// data specified by the values parameter.
        protected override void SetItem(string path, object values)
        {
            isLoggedIn();

            if (this.PathIsDrive(path))
            {
                throw new PSNotSupportedException();
            }

            if (!ItemExists(path))
            {
                throw new ItemNotFoundException(string.Format("Cannot find path {0} because it does not exist.", path));
            }

            var namesFromPath = ChunkPath(path);

            KVDriveInfo kvDriveInfo = this.PSDriveInfo as KVDriveInfo;

            var resourceGroupName = this.GetResourceGroupName(namesFromPath[0]);
            PSKeyVault vault = null;
            if (resourceGroupName != null)
            {
                vault = kvDriveInfo.KeyVaultClient.GetVault(namesFromPath[0], resourceGroupName, kvDriveInfo.ActiveDirectoryClient);
            }
            if (vault != null)
            {
                if (namesFromPath.Length == 1 || (namesFromPath.Length == 2 && namesFromPath[1].Equals("")))
                {
                    var dynamicParameters = DynamicParameters as SetItemVaultDynamicParameters;
                    bool? enabledForDeployment = dynamicParameters.EnabledForDeployment;
                    bool? enabledForTemplateDeployment = dynamicParameters.EnabledForTemplateDeployment;
                    bool? enabledForDiskEncryption = dynamicParameters.EnabledForDiskEncryption;
                    PSKeyVault parsedValues = null;
                    try
                    {
                        parsedValues = LanguagePrimitives.ConvertTo(values, typeof(PSKeyVault)) as PSKeyVault;
                        if (parsedValues != null)
                        {
                            enabledForDeployment = enabledForDeployment == null ? parsedValues.EnabledForDeployment : enabledForDeployment;
                            enabledForTemplateDeployment = enabledForTemplateDeployment == null ? parsedValues.EnabledForTemplateDeployment : enabledForTemplateDeployment;
                            enabledForDiskEncryption = enabledForDiskEncryption == null ? parsedValues.EnabledForDiskEncryption : enabledForDiskEncryption;
                        }
                    }
                    catch { }

                    var parsedHashTableValues = values as Hashtable;
                    if (parsedHashTableValues != null)
                    {
                        enabledForDeployment = enabledForDeployment == null ? parsedHashTableValues["EnabledForDeployment"] as bool? : enabledForDeployment;
                        enabledForTemplateDeployment = enabledForTemplateDeployment == null ? parsedHashTableValues["EnabledForTemplateDeployment"] as bool? : enabledForTemplateDeployment;
                        enabledForDiskEncryption = enabledForDiskEncryption == null ? parsedHashTableValues["EnabledForDiskEncryption"] as bool? : enabledForDiskEncryption;
                    }

                    if (values != null && parsedValues == null && parsedHashTableValues == null)
                    {
                        WriteWarning("-Value must be of type PSKeyVaultSecret or HashTable, values from -Value will not be used");
                    }
                    
                    var newVault = kvDriveInfo.KeyVaultClient.UpdateVault(vault, vault.AccessPolicies.ToArray(), enabledForDeployment, enabledForTemplateDeployment, 
                        enabledForDiskEncryption, vault.EnableSoftDelete, vault.EnablePurgeProtection, vault.NetworkAcls);

                    WriteItemObject(newVault, path, true);
                }
                else if (namesFromPath.Length == 2 || (namesFromPath.Length == 3 && namesFromPath[2].Equals("")))
                {
                    if (namesFromPath[1].Equals("Secrets") || namesFromPath[1].Equals("Certificates") || namesFromPath[1].Equals("Keys"))
                    {
                        throw new PSNotSupportedException();
                    }
                }
                else if (namesFromPath.Length == 3)
                {
                    if (namesFromPath[1] == "Secrets")
                    {
                        var dynamicParameters = DynamicParameters as SetItemSecretDynamicParameters;
                        var version = dynamicParameters.Version != null ? dynamicParameters.Version : string.Empty;
                        var enable = dynamicParameters.Enable;
                        var expires = dynamicParameters.Expires;
                        var notBefore = dynamicParameters.NotBefore;
                        var contentType = dynamicParameters.ContentType;
                        var tag = dynamicParameters.Tag;
                        PSKeyVaultSecretIdentityItem parsedValues = null;
                        try
                        {
                            parsedValues = LanguagePrimitives.ConvertTo(values, typeof(PSKeyVaultSecretIdentityItem)) as PSKeyVaultSecretIdentityItem;
                            if (parsedValues != null)
                            {
                                enable = enable == null ? parsedValues.Enabled : enable;
                                expires = expires == null ? parsedValues.Expires : expires;
                                notBefore = notBefore == null ? parsedValues.NotBefore : notBefore;
                                contentType = contentType == null ? parsedValues.ContentType : contentType;
                                tag = tag == null ? parsedValues.Tags : tag;
                            }
                        }
                        catch { }
                        
                        var parsedHashTableValues = values as Hashtable;
                        if (parsedHashTableValues != null)
                        {
                            version = version != string.Empty ? parsedHashTableValues["Version"] as string : version;
                            enable = enable == null ? parsedHashTableValues["Enable"] as bool? : enable;
                            expires = expires == null ? parsedHashTableValues["Expires"] as DateTime? : expires;
                            notBefore = notBefore == null ? parsedHashTableValues["NotBefore"] as DateTime? : notBefore;
                            contentType = contentType == null ? parsedHashTableValues["ContentType"] as string : contentType;
                            tag = tag == null ? parsedHashTableValues["Tag"] as Hashtable : tag;
                        }

                        if (values != null && parsedValues == null && parsedHashTableValues == null)
                        {
                            WriteWarning("-Value must be of type PSKeyVaultSecret or HashTable, values from -Value will not be used");
                        }

                        var newSecret = kvDriveInfo.KeyVaultDataServiceClient.UpdateSecret(vault.VaultName, namesFromPath[2], version, 
                            new PSKeyVaultSecretAttributes(enable, expires, notBefore, contentType, tag));

                        WriteItemObject(newSecret, path, false);
                    }
                    else if (namesFromPath[1] == "Certificates")
                    {
                        var dynamicParameters = DynamicParameters as SetItemCertificateDynamicParameters;
                        var version = dynamicParameters.Version != null ? dynamicParameters.Version : string.Empty;
                        var enable = dynamicParameters.Enable;
                        var tag = dynamicParameters.Tag;
                        PSKeyVaultCertificateIdentityItem parsedValues = null;
                        try
                        {
                            parsedValues = LanguagePrimitives.ConvertTo(values, typeof(PSKeyVaultCertificateIdentityItem)) as PSKeyVaultCertificateIdentityItem;
                            if (parsedValues != null)
                            {
                                enable = enable == null ? parsedValues.Enabled : enable;
                                tag = tag == null ? parsedValues.Tags : tag;
                            }
                        }
                        catch { }

                        var parsedHashTableValues = values as Hashtable;
                        if (parsedHashTableValues != null)
                        {
                            version = version != string.Empty ? parsedHashTableValues["Version"] as string : version;
                            enable = enable == null ? parsedHashTableValues["Enable"] as bool? : enable;
                            tag = tag == null ? parsedHashTableValues["Tag"] as Hashtable : tag;
                        }

                        if (values != null && parsedValues == null && parsedHashTableValues == null)
                        {
                            WriteWarning("-Value must be of type PSKeyVaultCertificate or HashTable, values from -Value will not be used");
                        }

                        var newCertificate = kvDriveInfo.KeyVaultDataServiceClient.UpdateCertificate(vault.VaultName, namesFromPath[2], version, 
                            new CertificateAttributes { Enabled = enable }, tag == null ? null : tag.ConvertToDictionary());

                        WriteItemObject(newCertificate, path, false);
                    }
                    else if (namesFromPath[1] == "Keys")
                    {
                        var dynamicParameters = DynamicParameters as SetItemKeyDynamicParameters;
                        var version = dynamicParameters.Version != null ? dynamicParameters.Version : string.Empty;
                        var enable = dynamicParameters.Enable;
                        var expires = dynamicParameters.Expires;
                        var notBefore = dynamicParameters.NotBefore;
                        var keyOps = dynamicParameters.KeyOps;
                        var tag = dynamicParameters.Tag;
                        PSKeyVaultKey parsedValues = null;
                        try
                        {
                            parsedValues = LanguagePrimitives.ConvertTo(values, typeof(PSKeyVaultKey)) as PSKeyVaultKey;
                            if (parsedValues != null)
                            {
                                enable = enable == null ? parsedValues.Enabled : enable;
                                expires = expires == null ? parsedValues.Expires : expires;
                                notBefore = notBefore == null ? parsedValues.NotBefore : notBefore;
                                keyOps = keyOps == null ? parsedValues.Attributes.KeyOps : keyOps;
                                tag = tag == null ? parsedValues.Tags : tag;
                            }
                        }
                        catch { }

                        var parsedHashTableValues = values as Hashtable;
                        if (parsedHashTableValues != null)
                        {
                            version = version != string.Empty ? parsedHashTableValues["Version"] as string : version;
                            enable = enable == null ? parsedHashTableValues["Enable"] as bool? : enable;
                            expires = expires == null ? parsedHashTableValues["Expires"] as DateTime? : expires;
                            notBefore = notBefore == null ? parsedHashTableValues["NotBefore"] as DateTime? : notBefore;
                            if ((parsedHashTableValues["KeyOps"] as object[]) != null)
                            {
                                keyOps = keyOps == null ?
                                    Array.ConvertAll((parsedHashTableValues["KeyOps"] as object[]), x => x.ToString()) : keyOps;
                            }
                            else if ((parsedHashTableValues["KeyOps"] as object) != null)
                            {
                                keyOps = keyOps == null ? new string[] { parsedHashTableValues["KeyOps"] as string } : keyOps;
                            }
                            tag = tag == null ? parsedHashTableValues["Tag"] as Hashtable : tag;
                        }

                        if (values != null && parsedValues == null && parsedHashTableValues == null)
                        {
                            WriteWarning("-Value must be of type PSKeyVaultKey or HashTable, values from -Value will not be used");
                        }

                        var newKey = kvDriveInfo.KeyVaultDataServiceClient.UpdateKey(vault.VaultName, namesFromPath[2], version,
                            new PSKeyVaultKeyAttributes(enable, expires, notBefore, null, keyOps, tag));

                        WriteItemObject(newKey, path, false);
                    }
                    else if (namesFromPath[1] == "AccessPolicies")
                    {
                        var dynamicParameters = DynamicParameters as SetItemAccessPolicyDynamicParameters;
                        var permissionsToKeys = dynamicParameters.PermissionsToKeys;
                        var permissionsToSecrets = dynamicParameters.PermissionsToSecrets;
                        var permissionsToCertificates = dynamicParameters.PermissionsToCertificates;
                        var permissionsToStorage = dynamicParameters.PermissionsToStorage;
                        PSKeyVaultAccessPolicy parsedValues = null;
                        try
                        {
                            parsedValues = LanguagePrimitives.ConvertTo(values, typeof(PSKeyVaultAccessPolicy)) as PSKeyVaultAccessPolicy;
                            if (parsedValues != null)
                            {
                                permissionsToKeys = permissionsToKeys == null ? parsedValues.PermissionsToKeys.ToArray() : permissionsToKeys;
                                permissionsToSecrets = permissionsToSecrets == null ? parsedValues.PermissionsToSecrets.ToArray() : permissionsToSecrets;
                                permissionsToCertificates = permissionsToCertificates == null ? parsedValues.PermissionsToCertificates.ToArray() : permissionsToCertificates;
                                permissionsToStorage = permissionsToStorage == null ? parsedValues.PermissionsToStorage.ToArray() : permissionsToStorage;
                            }
                        }
                        catch { }

                        var parsedHashTableValues = values as Hashtable;
                        if (parsedHashTableValues != null)
                        {
                            if ((parsedHashTableValues["PermissionsToKeys"] as object[]) != null)
                            {
                                permissionsToKeys = permissionsToKeys == null ?
                                    Array.ConvertAll((parsedHashTableValues["PermissionsToKeys"] as object[]), x => x.ToString()) : permissionsToKeys;
                            }
                            else if ((parsedHashTableValues["PermissionsToKeys"] as object) != null)
                            {
                                permissionsToKeys = permissionsToKeys == null ? new string[] { parsedHashTableValues["PermissionsToKeys"] as string } : permissionsToKeys;
                            }

                            if ((parsedHashTableValues["PermissionsToSecrets"] as object[]) != null)
                            {
                                permissionsToSecrets = permissionsToSecrets == null ?
                                    Array.ConvertAll((parsedHashTableValues["PermissionsToSecrets"] as object[]), x => x.ToString()) : permissionsToSecrets;
                            }
                            else if ((parsedHashTableValues["PermissionsToSecrets"] as object) != null)
                            {
                                permissionsToSecrets = permissionsToSecrets == null ? new string[] { parsedHashTableValues["PermissionsToSecrets"] as string } : permissionsToSecrets;
                            }

                            if ((parsedHashTableValues["PermissionsToCertificates"] as object[]) != null)
                            {
                                permissionsToCertificates = permissionsToCertificates == null ?
                                    Array.ConvertAll((parsedHashTableValues["PermissionsToCertificates"] as object[]), x => x.ToString()) : permissionsToCertificates;
                            }
                            else if ((parsedHashTableValues["PermissionsToCertificates"] as object) != null)
                            {
                                permissionsToCertificates = permissionsToCertificates == null ? new string[] { parsedHashTableValues["PermissionsToCertificates"] as string } : permissionsToCertificates;
                            }

                            if ((parsedHashTableValues["PermissionsToStorage"] as object[]) != null)
                            {
                                permissionsToStorage = permissionsToStorage == null ?
                                    Array.ConvertAll((parsedHashTableValues["PermissionsToStorage"] as object[]), x => x.ToString()) : permissionsToStorage;
                            }
                            else if ((parsedHashTableValues["PermissionsToStorage"] as object) != null)
                            {
                                permissionsToStorage = permissionsToStorage == null ? new string[] { parsedHashTableValues["PermissionsToStorage"] as string } : permissionsToStorage;
                            }
                        }

                        if (values != null && parsedValues == null && parsedHashTableValues == null)
                        {
                            WriteWarning("-Value must be of type PSKeyVaultAccessPolicy or HashTable, values from -Value will not be used");
                        }

                        PSKeyVaultAccessPolicy[] updatedListOfAccessPolicies = vault.AccessPolicies;
                        var existingPolicy = vault.AccessPolicies.FirstOrDefault(ap => MatchVaultAccessPolicyIdentity(ap, namesFromPath[2], null));

                        //New policy will have permission arrays that are either from cmdlet input
                        //or if that's null, then from the old policy for this object ID if one existed
                        var keys = permissionsToKeys ?? (existingPolicy != null && existingPolicy.PermissionsToKeys != null ?
                            existingPolicy.PermissionsToKeys.ToArray() : null);

                        var secrets = permissionsToSecrets ?? (existingPolicy != null && existingPolicy.PermissionsToSecrets != null ?
                            existingPolicy.PermissionsToSecrets.ToArray() : null);

                        var certificates = permissionsToCertificates ?? (existingPolicy != null && existingPolicy.PermissionsToCertificates != null ?
                            existingPolicy.PermissionsToCertificates.ToArray() : null);

                        var managedStorage = permissionsToStorage ?? (existingPolicy != null && existingPolicy.PermissionsToStorage != null ?
                            existingPolicy.PermissionsToStorage.ToArray() : null);

                        PSKeyVaultAccessPolicy policy = null;

                        //Remove old policies for this policy identity and add a new one with the right permissions, iff there were some non-empty permissions
                        updatedListOfAccessPolicies = vault.AccessPolicies.Where(ap => !MatchVaultAccessPolicyIdentity(ap, namesFromPath[2], null)).ToArray();
                        if ((keys != null && keys.Length > 0) || (secrets != null && secrets.Length > 0) || (certificates != null && certificates.Length > 0) || 
                            (managedStorage != null && managedStorage.Length > 0))
                        {
                            policy = new PSKeyVaultAccessPolicy(vault.TenantId, namesFromPath[2], null, keys, secrets, certificates, managedStorage);
                            updatedListOfAccessPolicies = updatedListOfAccessPolicies.Concat(new[] { policy }).ToArray();
                        }

                        var updatedVault = kvDriveInfo.KeyVaultClient.UpdateVault(vault, updatedListOfAccessPolicies, vault.EnabledForDeployment, 
                            vault.EnabledForTemplateDeployment, vault.EnabledForDiskEncryption, vault.EnableSoftDelete, vault.EnablePurgeProtection, 
                            vault.NetworkAcls, kvDriveInfo.ActiveDirectoryClient);

                        foreach (var accesspolicy in updatedVault.AccessPolicies)
                        {
                            if (accesspolicy.ObjectId.Equals(namesFromPath[2]))
                            {
                                WriteItemObject(accesspolicy, path, false);
                            }
                        }
                    }
                }
            }
        }

        /// Tests to see if the specified item exists.
        protected override bool ItemExists(string path)
        {
            isLoggedIn();

            // Check if the path represented is a drive
            if (this.PathIsDrive(path))
            {
                return true;
            }

            var namesFromPath = ChunkPath(path);

            KVDriveInfo kvDriveInfo = this.PSDriveInfo as KVDriveInfo;

            var resourceGroupName = this.GetResourceGroupName(namesFromPath[0]);
            if (resourceGroupName == null)
            {
                return false;
            }
            var vault = kvDriveInfo.KeyVaultClient.GetVault(namesFromPath[0], resourceGroupName);
            if (vault != null)
            {
                if (namesFromPath.Length == 1 || (namesFromPath.Length == 2 && namesFromPath[1].Equals("")))
                {
                    return true;
                }
                else if (namesFromPath.Length == 2 || (namesFromPath.Length == 3 && namesFromPath[2].Equals("")))
                {
                    if (namesFromPath[1].Equals("Secrets") || namesFromPath[1].Equals("Certificates") || namesFromPath[1].Equals("Keys") || namesFromPath[1].Equals("AccessPolicies"))
                    {
                        return true;
                    }
                    return false;
                }
                else if (namesFromPath.Length == 3)
                {
                    if (namesFromPath[1] == "Secrets")
                    {
                        var secrets = kvDriveInfo.KeyVaultDataServiceClient.GetSecrets(
                            new KeyVaultObjectFilterOptions { VaultName = namesFromPath[0], NextLink = null });
                        foreach (var secret in secrets)
                        {
                            if (secret.Name.Equals(namesFromPath[2]))
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                    else if (namesFromPath[1] == "Certificates")
                    {
                        if (kvDriveInfo.KeyVaultDataServiceClient.GetCertificate(namesFromPath[0], namesFromPath[2], string.Empty) != null)
                        {
                            return true;
                        }
                        return false;
                    }
                    else if (namesFromPath[1] == "Keys")
                    {
                        if (kvDriveInfo.KeyVaultDataServiceClient.GetKey(namesFromPath[0], namesFromPath[2], string.Empty) != null)
                        {
                            return true;
                        }
                        return false;
                    }
                    else if (namesFromPath[1].Equals("AccessPolicies"))
                    {
                        foreach (var accesspolicy in vault.AccessPolicies)
                        {
                            if (accesspolicy.ObjectId.Equals(namesFromPath[2]))
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                }
            }
            return false;
        }

        /// Tests to see if the specified path is syntactically valid.
        protected override bool IsValidPath(string path)
        {
            isLoggedIn();

            bool result = true;

            // Check to see if the path is null or empty.
            if (String.IsNullOrEmpty(path))
            {
                result = false;
            }

            string[] pathChunks = ChunkPath(path);

            foreach (string pathChunk in pathChunks)
            {
                if (pathChunk.Length == 0)
                {
                    result = false;
                }
            }

            return result;
        }

        #endregion Item Overloads

        #region ItemHelperMethods

        /// Checks to see if a given path is actually a drive name.
        private bool PathIsDrive(string path)
        {
            // Remove the drive name and first path separator.  If the 
            // path is reduced to nothing, it is a drive. Also, if it is
            // just a drive then there will not be any path separators.
            if (String.IsNullOrEmpty(
                         path.Replace(this.PSDriveInfo.Root, string.Empty)) ||
                         String.IsNullOrEmpty(
                         path.Replace(this.PSDriveInfo.Root + this.pathSeparator, string.Empty)) ||
                         String.IsNullOrEmpty(
                         path.Replace(NormalizePath(this.PSDriveInfo.Root), string.Empty)) ||
                         String.IsNullOrEmpty(
                         path.Replace(NormalizePath(this.PSDriveInfo.Root + this.pathSeparator), string.Empty)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// Breaks up the path into individual elements.
        private string[] ChunkPath(string path)
        {
            // Normalize the path before splitting
            string normalPath = this.NormalizePath(path);

            // Return the path with the drive name and first path 
            // separator character removed, split by the path separator.
            string pathNoDrive = normalPath.Replace(
                                       this.PSDriveInfo.Root + this.pathSeparator,
                                       string.Empty);
            pathNoDrive = normalPath.Replace(
                                       this.PSDriveInfo.Root,
                                       string.Empty);
            pathNoDrive = normalPath.Replace(
                                       NormalizePath(this.PSDriveInfo.Root + this.pathSeparator),
                                       string.Empty);
            pathNoDrive = normalPath.Replace(
                                       NormalizePath(this.PSDriveInfo.Root),
                                       string.Empty);
            return pathNoDrive.Split(this.pathSeparator.ToCharArray());
        }

        /// Modifies the path ensuring that the correct path separator
        /// character is used.
        private string NormalizePath(string path)
        {
            string result = path;

            if (!String.IsNullOrEmpty(path))
            {
                result = path.Replace("/", this.pathSeparator);
            }

            return result;
        }

        protected string GetResourceGroupName(string vaultName)
        {
            KVDriveInfo kvDriveInfo = this.PSDriveInfo as KVDriveInfo;

            string rg = null;
            var resourcesByName = kvDriveInfo.ResourcesClient.FilterResources(new Management.Internal.Resources.Utilities.Models.FilterResourcesOptions()
            {
                ResourceType = "Microsoft.KeyVault/vaults"
            });

            if (resourcesByName != null && resourcesByName.Count > 0)
            {
                var vault = resourcesByName.FirstOrDefault(r => r.Name.Equals(vaultName, StringComparison.OrdinalIgnoreCase));
                if (vault != null)
                    rg = new ResourceIdentifier(vault.Id).ResourceGroupName;
            }

            return rg;
        }

        protected void GetAndWriteObjects<TObject>(KeyVaultObjectFilterOptions options, Func<KeyVaultObjectFilterOptions, IEnumerable<TObject>> getObjects, string path)
        {
            do
            {
                var pageResults = getObjects(options);
                foreach(var pageResult in pageResults)
                {
                    WriteItemObject(pageResult, path, false);
                }
            } while (!string.IsNullOrEmpty(options.NextLink));
        }

        private bool MatchVaultAccessPolicyIdentity(PSKeyVaultAccessPolicy ap, string objectId, Guid? applicationId)
        {
            return ap.ApplicationId == applicationId && string.Equals(ap.ObjectId, objectId, StringComparison.OrdinalIgnoreCase);
        }

        #endregion Helper Methods

        #region Container Methods

        /// <summary>
        /// The Windows PowerShell engine calls this method when the Get-ChildItem 
        /// cmdlet is run. This provider returns either the tables in the database 
        /// or the rows of the table.
        /// </summary>
        /// <param name="path">The path to the parent item.</param>
        /// <param name="recurse">A Boolean value that indicates true to return all 
        /// child items recursively.
        /// </param>
        protected override void GetChildItems(string path, bool recurse)
        {
            isLoggedIn();

            KVDriveInfo kvDriveInfo = this.PSDriveInfo as KVDriveInfo;

            // Check if the path represented is a drive
            if (this.PathIsDrive(path))
            {
                var dynamicParameters = DynamicParameters as GetChildItemsVaultDynamicParameters;
                var tag = dynamicParameters.Tag;
                var allVaults = ListVaults(null, tag);
                foreach (var keyvault in allVaults)
                {
                    WriteItemObject(keyvault, path + pathSeparator + keyvault.VaultName, true);
                    if (recurse)
                    {
                        GetChildItems(path + keyvault.VaultName, true);
                    }
                }
                return;
            }

            if (!ItemExists(path))
            {
                throw new ItemNotFoundException(string.Format("Cannot find path {0} because it does not exist.", path));
            }

            var namesFromPath = ChunkPath(path);

            var resourceGroupName = this.GetResourceGroupName(namesFromPath[0]);
            PSKeyVault vault = null;
            if (resourceGroupName != null)
            {
                vault = kvDriveInfo.KeyVaultClient.GetVault(namesFromPath[0], resourceGroupName, kvDriveInfo.ActiveDirectoryClient);
            }
            if (vault != null)
            {
                if (namesFromPath.Length == 1 || (namesFromPath.Length == 2 && namesFromPath[1].Equals("")))
                {
                    WriteItemObject("Secrets", path + pathSeparator + "Secrets", true);
                    if (recurse)
                    {
                        GetChildItems(path + pathSeparator + "Secrets", true);
                    }
                    WriteItemObject("Certificates", path + pathSeparator + "Certificates", true);
                    if (recurse)
                    {
                        GetChildItems(path + pathSeparator + "Certificates", true);
                    }
                    WriteItemObject("Keys", path + pathSeparator + "Keys", true);
                    if (recurse)
                    {
                        GetChildItems(path + pathSeparator + "Keys", true);
                    }
                    WriteItemObject("AccessPolicies", path + pathSeparator + "AccessPolicies", true);
                    if (recurse)
                    {
                        GetChildItems(path + pathSeparator + "AccessPolicies", true);
                    }
                }
                else if (namesFromPath.Length == 2 || (namesFromPath.Length == 3 && namesFromPath[2].Equals("")))
                {
                    if (namesFromPath[1] == "Secrets")
                    {
                        var secrets = kvDriveInfo.KeyVaultDataServiceClient.GetSecrets(
                            new KeyVaultObjectFilterOptions { VaultName = namesFromPath[0], NextLink = null });
                        foreach (var secret in secrets)
                        {
                            WriteItemObject(secret, path + pathSeparator + secret.Name, false);
                        }
                    }
                    else if (namesFromPath[1] == "Certificates")
                    {
                        var certificates = kvDriveInfo.KeyVaultDataServiceClient.GetCertificates(
                            new KeyVaultObjectFilterOptions { VaultName = namesFromPath[0], NextLink = null });
                        foreach (var certificate in certificates)
                        {
                            WriteItemObject(certificate, path + pathSeparator + certificate.Name, false);
                        }
                    }
                    else if (namesFromPath[1] == "Keys")
                    {
                        var keys = kvDriveInfo.KeyVaultDataServiceClient.GetKeys(
                            new KeyVaultObjectFilterOptions { VaultName = namesFromPath[0], NextLink = null });
                        foreach (var key in keys)
                        {
                            WriteItemObject(key, path + pathSeparator + key.Name, false);
                        }
                    }
                    else if (namesFromPath[1] == "AccessPolicies")
                    {
                        var accessPolicies = vault.AccessPolicies;
                        foreach (var accessPolicy in accessPolicies)
                        {
                            WriteItemObject(accessPolicy, path + pathSeparator + accessPolicy.ObjectId, false);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Returns the names of all the child items.
        /// </summary>
        /// <param name="path">The root path.</param>
        /// <param name="returnContainers">Parameter not used.</param>
        protected override void GetChildNames(
                                              string path,
                                              ReturnContainers returnContainers)
        {
            isLoggedIn();

            KVDriveInfo kvDriveInfo = this.PSDriveInfo as KVDriveInfo;

            // Check if the path represented is a drive
            if (this.PathIsDrive(path))
            {
                var allVaults = kvDriveInfo.ResourcesClient.Resources.List(new Rest.Azure.OData.ODataQuery<GenericResourceFilter>(
                        r => r.ResourceType == "Microsoft.KeyVault/vaults"));
                foreach (var keyvault in allVaults)
                {
                    WriteItemObject(keyvault.Name, path + pathSeparator + keyvault.Name, true);
                }
                return;
            }

            if (!ItemExists(path))
            {
                throw new ItemNotFoundException(string.Format("Cannot find path {0} because it does not exist.", path));
            }

            var namesFromPath = ChunkPath(path);

            var resourceGroupName = this.GetResourceGroupName(namesFromPath[0]);
            PSKeyVault vault = null;
            if (resourceGroupName != null)
            {
                vault = kvDriveInfo.KeyVaultClient.GetVault(namesFromPath[0], resourceGroupName, kvDriveInfo.ActiveDirectoryClient);
            }
            if (vault != null)
            {
                if (namesFromPath.Length == 1 || (namesFromPath.Length == 2 && namesFromPath[1].Equals("")))
                {
                    WriteItemObject("Secrets", path + pathSeparator + "Secrets", true);
                    WriteItemObject("Certificates", path + pathSeparator + "Secrets", true);
                    WriteItemObject("Keys", path + pathSeparator + "Secrets", true);
                    WriteItemObject("AccessPolicies", path + pathSeparator + "AccessPolicies", true);
                }
                else if (namesFromPath.Length == 2 || (namesFromPath.Length == 3 && namesFromPath[2].Equals("")))
                {
                    if (namesFromPath[1] == "Secrets")
                    {
                        var secrets = kvDriveInfo.KeyVaultDataServiceClient.GetSecrets(
                            new KeyVaultObjectFilterOptions { VaultName = namesFromPath[0], NextLink = null });
                        foreach (var secret in secrets)
                        {
                            WriteItemObject(secret.Name, path + pathSeparator + secret.Name, false);
                        }
                    }
                    else if (namesFromPath[1] == "Certificates")
                    {
                        var certificates = kvDriveInfo.KeyVaultDataServiceClient.GetCertificates(
                            new KeyVaultObjectFilterOptions { VaultName = namesFromPath[0], NextLink = null });
                        foreach (var certificate in certificates)
                        {
                            WriteItemObject(certificate.Name, path + pathSeparator + certificate.Name, false);
                        }
                    }
                    else if (namesFromPath[1] == "Keys")
                    {
                        var keys = kvDriveInfo.KeyVaultDataServiceClient.GetKeys(
                            new KeyVaultObjectFilterOptions { VaultName = namesFromPath[0], NextLink = null });
                        foreach (var key in keys)
                        {
                            WriteItemObject(key.Name, path + pathSeparator + key.Name, false);
                        }
                    }
                    else if (namesFromPath[1] == "AccessPolicies")
                    {
                        var accessPolicies = vault.AccessPolicies;
                        foreach (var accessPolicy in accessPolicies)
                        {
                            WriteItemObject(accessPolicy.ObjectId, path + pathSeparator + accessPolicy.ObjectId, false);
                        }
                    }
                }
            }
        }

        /// Determines if the specified path has child items.
        protected override bool HasChildItems(string path)
        {
            isLoggedIn();

            KVDriveInfo kvDriveInfo = this.PSDriveInfo as KVDriveInfo;

            // Check if the path represented is a drive
            if (this.PathIsDrive(path))
            {
                var allVaults = kvDriveInfo.ResourcesClient.Resources.List(new Rest.Azure.OData.ODataQuery<GenericResourceFilter>(
                        r => r.ResourceType == "Microsoft.KeyVault/vaults"));
                if (allVaults.Count() == 0)
                {
                    return false;
                }
                return true;
            }

            var namesFromPath = ChunkPath(path);

            var resourceGroupName = this.GetResourceGroupName(namesFromPath[0]);
            PSKeyVault vault = null;
            if (resourceGroupName != null)
            {
                vault = kvDriveInfo.KeyVaultClient.GetVault(namesFromPath[0], resourceGroupName, kvDriveInfo.ActiveDirectoryClient);
            }
            if (vault != null)
            {
                if (namesFromPath.Length == 1 || (namesFromPath.Length == 2 && namesFromPath[1].Equals("")))
                {
                    return true;
                }
                else if (namesFromPath.Length == 2 || (namesFromPath.Length == 3 && namesFromPath[2].Equals("")))
                {
                    if (namesFromPath[1] == "Secrets")
                    {
                        var secrets = kvDriveInfo.KeyVaultDataServiceClient.GetSecrets(
                            new KeyVaultObjectFilterOptions { VaultName = namesFromPath[0], NextLink = null });
                        if (secrets.Count() == 0)
                        {
                            return false;
                        }
                        return true;
                    }
                    else if (namesFromPath[1] == "Certificates")
                    {
                        var certificates = kvDriveInfo.KeyVaultDataServiceClient.GetCertificates(
                            new KeyVaultObjectFilterOptions { VaultName = namesFromPath[0], NextLink = null });
                        if (certificates.Count() == 0)
                        {
                            return false;
                        }
                        return true;
                    }
                    else if (namesFromPath[1] == "Keys")
                    {
                        var keys = kvDriveInfo.KeyVaultDataServiceClient.GetKeys(
                            new KeyVaultObjectFilterOptions { VaultName = namesFromPath[0], NextLink = null });
                        if (keys.Count() == 0)
                        {
                            return false;
                        }
                        return true;
                    }
                    else if (namesFromPath[1] == "AccessPolicies")
                    {
                        if (vault.AccessPolicies.Count() == 0)
                        {
                            return false;
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        protected override string[] ExpandPath(string path)
        {
            isLoggedIn();

            // Check to see if the path represents a valid drive.
            if (this.PathIsDrive(path))
            {
                return new string[] { path };
            }

            if (!path.EndsWith("*"))
            {
                return new string[] { path };
            }

            var namesFromPath = ChunkPath(path);

            KVDriveInfo kvDriveInfo = this.PSDriveInfo as KVDriveInfo;

            if (namesFromPath.Length == 1)
            {
                var filter = namesFromPath[0].TrimEnd('*');
                var filteredVaults = new List<string>();
                var allVaults = kvDriveInfo.ResourcesClient.Resources.List(new Rest.Azure.OData.ODataQuery<GenericResourceFilter>(
                        r => r.ResourceType == "Microsoft.KeyVault/vaults"));

                foreach (var vaultItem in allVaults)
                {
                    if (vaultItem.Name.StartsWith(filter))
                    {
                        int separatorIndex = path.LastIndexOf(pathSeparator);
                        var trimmedPath = path.Substring(0, separatorIndex);
                        filteredVaults.Add(trimmedPath + pathSeparator + vaultItem.Name);
                    }    
                }
                return filteredVaults.ToArray();
            }

            var resourceGroupName = this.GetResourceGroupName(namesFromPath[0]);
            if (resourceGroupName == null)
            {
                return new string[] { path };
            }
            var vault = kvDriveInfo.KeyVaultClient.GetVault(namesFromPath[0], resourceGroupName);
            if (vault != null)
            {
                if (namesFromPath.Length == 2)
                {
                    var filter = namesFromPath[1].TrimEnd('*');
                    var filteredPaths = new List<string>();
                    var allStrings = new String[] { "Secrets", "Keys", "Certificates", "AccessPolicies" };

                    foreach (var stringItem in allStrings)
                    {
                        if (stringItem.StartsWith(filter))
                        {
                            int separatorIndex = path.LastIndexOf(pathSeparator);
                            var trimmedPath = path.Substring(0, separatorIndex);
                            filteredPaths.Add(trimmedPath + pathSeparator + stringItem);
                        }
                    }
                    return filteredPaths.ToArray();
                }
                else if (namesFromPath.Length == 3)
                {
                    if (namesFromPath[1] == "Secrets")
                    {
                        var filter = namesFromPath[2].TrimEnd('*');
                        var filteredPaths = new List<string>();
                        var allStrings = kvDriveInfo.KeyVaultDataServiceClient.GetSecrets(
                            new KeyVaultObjectFilterOptions { VaultName = namesFromPath[0], NextLink = null });

                        foreach (var stringItem in allStrings)
                        {
                            if (stringItem.Name.StartsWith(filter))
                            {
                                int separatorIndex = path.LastIndexOf(pathSeparator);
                                var trimmedPath = path.Substring(0, separatorIndex);
                                filteredPaths.Add(trimmedPath + pathSeparator + stringItem.Name);
                            }
                        }
                        return filteredPaths.ToArray();
                    }
                    else if (namesFromPath[1] == "Certificates")
                    {
                        var filter = namesFromPath[2].TrimEnd('*');
                        var filteredPaths = new List<string>();
                        var allStrings = kvDriveInfo.KeyVaultDataServiceClient.GetCertificates(
                            new KeyVaultObjectFilterOptions { VaultName = namesFromPath[0], NextLink = null });

                        foreach (var stringItem in allStrings)
                        {
                            if (stringItem.Name.StartsWith(filter))
                            {
                                int separatorIndex = path.LastIndexOf(pathSeparator);
                                var trimmedPath = path.Substring(0, separatorIndex);
                                filteredPaths.Add(trimmedPath + pathSeparator + stringItem.Name);
                            }
                        }
                        return filteredPaths.ToArray();
                    }
                    else if (namesFromPath[1] == "Keys")
                    {
                        var filter = namesFromPath[2].TrimEnd('*');
                        var filteredPaths = new List<string>();
                        var allStrings = kvDriveInfo.KeyVaultDataServiceClient.GetKeys(
                            new KeyVaultObjectFilterOptions { VaultName = namesFromPath[0], NextLink = null });

                        foreach (var stringItem in allStrings)
                        {
                            if (stringItem.Name.StartsWith(filter))
                            {
                                int separatorIndex = path.LastIndexOf(pathSeparator);
                                var trimmedPath = path.Substring(0, separatorIndex);
                                filteredPaths.Add(trimmedPath + pathSeparator + stringItem.Name);
                            }
                        }
                        return filteredPaths.ToArray();
                    }
                    else if (namesFromPath[1] == "AccessPolicies")
                    {
                        var filter = namesFromPath[2].TrimEnd('*');
                        var filteredPaths = new List<string>();
                        var allStrings = vault.AccessPolicies;

                        foreach (var stringItem in allStrings)
                        {
                            if (stringItem.ObjectId.StartsWith(filter))
                            {
                                int separatorIndex = path.LastIndexOf(pathSeparator);
                                var trimmedPath = path.Substring(0, separatorIndex);
                                filteredPaths.Add(trimmedPath + pathSeparator + stringItem.ObjectId);
                            }
                        }
                        return filteredPaths.ToArray();
                    }
                }
            }
            return new string[] { path };
        }

        /// The Windows PowerShell engine calls this method when the New-Item 
        /// cmdlet is run. This method creates a new item at the specified path.
        protected override void NewItem(string path, string type, object newItemValue)
        {
            isLoggedIn();

            if (type != null && (!type.Equals("vault", StringComparison.CurrentCultureIgnoreCase) && !type.Equals("secret", StringComparison.CurrentCultureIgnoreCase) 
                && !type.Equals("certificate", StringComparison.CurrentCultureIgnoreCase) && !type.Equals("key", StringComparison.CurrentCultureIgnoreCase) &&
                !type.Equals("AccessPolicy", StringComparison.CurrentCultureIgnoreCase)))
            {
                throw new PSNotSupportedException("New-Item only supports creating types 'Vault', 'Secret', 'Certificate', 'Key', and 'AccessPolicy'");
            }

            if (DynamicParameters == null)
            {
                throw new ArgumentException("Please provide the -ItemType parameter. Valid types are: 'Vault', 'Secret', 'Certificate', 'Key', and 'AccessPolicy'");
            }

            // Check if the path represented is a drive
            if (this.PathIsDrive(path))
            {
                throw new PSNotSupportedException();
            }

            var namesFromPath = ChunkPath(path);

            KVDriveInfo kvDriveInfo = this.PSDriveInfo as KVDriveInfo;

            if (namesFromPath.Length == 1 || (namesFromPath.Length == 2 && namesFromPath[1].Equals("")))
            {
                if (type != null && !type.Equals("vault", StringComparison.CurrentCultureIgnoreCase))
                {
                    throw new PSNotSupportedException(string.Format("Creating type '{0}' at location '{1}' is not suppported.", type, path));
                }

                var resourceGroup = this.GetResourceGroupName(namesFromPath[0]);
                if (resourceGroup != null && kvDriveInfo.KeyVaultClient.GetVault(namesFromPath[0], resourceGroup) != null)
                {
                    throw new Exception(string.Format("Vault '{0}' already exists", namesFromPath[0]));
                }

                var deletedVaults = kvDriveInfo.KeyVaultClient.ListDeletedVaults();
                foreach (var deletedVault in deletedVaults)
                {
                    if (deletedVault.VaultName.Equals(namesFromPath[0]))
                    {
                        throw new Exception("Existing soft deleted vault with the name name.");
                    }
                }

                if (ShouldProcess(namesFromPath[0]))
                {
                    var dynamicParameters = DynamicParameters as NewItemVaultDynamicParameters;
                    var resourceGroupName = dynamicParameters.ResourceGroupName;
                    var location = dynamicParameters.Location;
                    bool? enabledForDeployment = dynamicParameters.EnabledForDeployment;
                    bool? enabledForTemplateDeployment = dynamicParameters.EnabledForTemplateDeployment;
                    bool? enabledForDiskEncryption = dynamicParameters.EnabledForDiskEncryption;
                    bool? enableSoftDelete = dynamicParameters.EnableSoftDelete;
                    var sku = dynamicParameters.Sku.ToString();
                    var tag = dynamicParameters.Tag;
                    List<AccessPolicyEntry> accessPolicy = new List<AccessPolicyEntry>();

                    var parsedHashTableValues = newItemValue as Hashtable;
                    PSKeyVault parsedValues = null;
                    if (parsedHashTableValues != null)
                    {
                        resourceGroupName = resourceGroupName == null ? parsedHashTableValues["ResourceGroupName"] as string : resourceGroupName;
                        location = location == null ? parsedHashTableValues["Location"] as string : location;
                        enabledForDeployment = enabledForDeployment == false ? parsedHashTableValues["EnabledForDeployment"] as string == "true" : enabledForDeployment;
                        enabledForTemplateDeployment = enabledForTemplateDeployment == false ? parsedHashTableValues["EnabledForTemplateDeployement"] as string == "true" : enabledForTemplateDeployment;
                        enabledForDiskEncryption = enabledForDiskEncryption == false ? parsedHashTableValues["EnabledForDiskEncryption"] as string == "true" : enabledForDiskEncryption;
                        enableSoftDelete = enableSoftDelete == false ? parsedHashTableValues["EnableSoftDelete"] as string == "true" : enableSoftDelete;
                        sku = sku == null ? parsedHashTableValues["Sku"] as string : sku;
                        tag = tag == null ? parsedHashTableValues["Tag"] as Hashtable : tag;
                    }
                    else
                    {
                        try
                        {
                            parsedValues = LanguagePrimitives.ConvertTo(newItemValue, typeof(PSKeyVault)) as PSKeyVault;
                            if (parsedValues != null)
                            {
                                resourceGroupName = resourceGroupName == null ? parsedValues.ResourceGroupName : resourceGroupName;
                                location = location == null ? parsedValues.Location : location;
                                enabledForDeployment = enabledForDeployment == false ? parsedValues.EnabledForDeployment : enabledForDeployment;
                                enabledForTemplateDeployment = enabledForTemplateDeployment == false ? parsedValues.EnabledForTemplateDeployment : enabledForTemplateDeployment;
                                enabledForDiskEncryption = enabledForDiskEncryption == false ? parsedValues.EnabledForDiskEncryption : enabledForDiskEncryption;
                                enableSoftDelete = enableSoftDelete == false ? parsedValues.EnableSoftDelete : enableSoftDelete;
                                sku = sku == null ? parsedValues.Sku : sku;
                                tag = tag == null ? parsedValues.Tags : tag;
                                foreach (var policy in parsedValues.AccessPolicies)
                                {
                                    accessPolicy.Add(new AccessPolicyEntry(policy.TenantId, policy.ObjectId,
                                        new Permissions(policy.PermissionsToKeys, policy.PermissionsToSecrets, policy.PermissionsToCertificates, policy.PermissionsToStorage)));
                                }
                            }
                        }
                        catch { }
                    }

                    if (newItemValue != null && parsedValues == null && parsedHashTableValues == null)
                    {
                        WriteWarning("-Value must be of type PSKeyVault or HashTable, values from -Value will not be used");
                    }

                    AccessPolicyEntry newAccessPolicy = null;

                    if (accessPolicy.Count > 0)
                    {
                        newAccessPolicy = accessPolicy[0];
                    }
                    else
                    {
                        var userObjectId = string.Empty;

                        try
                        {
                            userObjectId = GetCurrentUsersObjectId();
                        }
                        catch (Exception ex)
                        {
                            WriteWarning(ex.Message);
                        }

                        if (!string.IsNullOrWhiteSpace(userObjectId))
                        {
                            newAccessPolicy = new AccessPolicyEntry()
                            {
                                TenantId = GetTenantId(),
                                ObjectId = userObjectId,
                                Permissions = new Permissions
                                {
                                    Keys = DefaultPermissionsToKeys,
                                    Secrets = DefaultPermissionsToSecrets,
                                    Certificates = DefaultPermissionsToCertificates,
                                    Storage = DefaultPermissionsToStorage
                                }
                            };
                        }
                    }

                    if (resourceGroupName == null || location == null)
                    {
                        throw new Exception("-ResourceGroupName and -Location parameters are required to create a vault");
                    }

                    var newVault = kvDriveInfo.KeyVaultClient.CreateNewVault(new VaultCreationParameters()
                    {
                        VaultName = namesFromPath[0],
                        ResourceGroupName = resourceGroupName,
                        Location = location,
                        EnabledForDeployment = enabledForDeployment.Value,
                        EnabledForTemplateDeployment = enabledForTemplateDeployment.Value,
                        EnabledForDiskEncryption = enabledForDiskEncryption.Value,
                        EnableSoftDelete = enableSoftDelete.Value,
                        SkuFamilyName = DefaultSkuFamily,
                        SkuName = (SkuName) Enum.Parse(typeof(SkuName), sku, true),
                        TenantId = GetTenantId(),
                        AccessPolicy = newAccessPolicy,
                        Tags = tag
                    });

                    if (accessPolicy.Count > 1)
                    {
                        var psAccessPolicy = new List<PSKeyVaultAccessPolicy>();
                        foreach (var policy in accessPolicy)
                        {
                            psAccessPolicy.Add(new PSKeyVaultAccessPolicy(policy, kvDriveInfo.ActiveDirectoryClient));
                        }
                        newVault = kvDriveInfo.KeyVaultClient.UpdateVault(newVault, psAccessPolicy.ToArray(), newVault.EnabledForDeployment, 
                            newVault.EnabledForTemplateDeployment, newVault.EnabledForDiskEncryption, newVault.EnableSoftDelete, newVault.EnablePurgeProtection,
                            newVault.NetworkAcls);
                    }

                    WriteItemObject(newVault, path, true);
                }
                return;
            }

            var rgName = this.GetResourceGroupName(namesFromPath[0]);
            PSKeyVault vault = null;
            if (rgName != null)
            {
                vault = kvDriveInfo.KeyVaultClient.GetVault(namesFromPath[0], rgName, kvDriveInfo.ActiveDirectoryClient);
            }
            if (vault != null)
            {
                if (namesFromPath.Length == 3 || (namesFromPath.Length == 2 && type != null))
                {
                    if (namesFromPath[1] == "Secrets" || (namesFromPath.Length == 2 && type.Equals("secret", StringComparison.CurrentCultureIgnoreCase)))
                    {
                        if (type != null && !type.Equals("secret", StringComparison.CurrentCultureIgnoreCase))
                        {
                            throw new PSNotSupportedException(string.Format("Creating type '{0}' at location '{1}' is not suppported.", type, path));
                        }

                        string name = namesFromPath[namesFromPath.Length - 1];

                        var allSecrets = kvDriveInfo.KeyVaultDataServiceClient.GetSecrets(new KeyVaultObjectFilterOptions() { VaultName = namesFromPath[0] });
                        var secretExists = false;
                        foreach (var secret in allSecrets)
                        {
                            if (secret.Name.Equals(name))
                            {
                                secretExists = true;
                            }
                        }
                        if (vault.EnableSoftDelete == true)
                        {
                            var deletedSecret = kvDriveInfo.KeyVaultDataServiceClient.GetDeletedSecret(namesFromPath[0], name);
                            if (deletedSecret != null)
                            {
                                throw new Exception("Existing soft deleted secret with the same name.");
                            }
                        }

                        if (!secretExists || Force || ShouldContinue(string.Format("Overwrite secret '{0}'?", name), "Overwrite item?"))
                        {
                            if (ShouldProcess(name))
                            {
                                var dynamicParameters = DynamicParameters as NewItemSecretDynamicParameters;
                                var secretValue = dynamicParameters.SecretValue;
                                bool? disable = dynamicParameters.Disable;
                                var expires = dynamicParameters.Expires;
                                var notBefore = dynamicParameters.NotBefore;
                                var contentType = dynamicParameters.ContentType;
                                var tag = dynamicParameters.Tag;

                                var parsedHashTableValues = newItemValue as Hashtable;
                                PSKeyVaultSecret parsedValues = null;
                                if (parsedHashTableValues != null)
                                {
                                    secretValue = secretValue == null ? parsedHashTableValues["SecretValue"] as SecureString : secretValue;
                                    disable = disable == false ? parsedHashTableValues["Disable"] as bool? == true : disable;
                                    expires = expires == null ? parsedHashTableValues["Expires"] as DateTime? : expires;
                                    notBefore = notBefore == null ? parsedHashTableValues["NotBefore"] as DateTime? : notBefore;
                                    contentType = contentType == null ? parsedHashTableValues["Sku"] as string : contentType;
                                    tag = tag == null ? parsedHashTableValues["Tag"] as Hashtable : tag;
                                }
                                else
                                {
                                    try
                                    {
                                        parsedValues = LanguagePrimitives.ConvertTo(newItemValue, typeof(PSKeyVaultSecret)) as PSKeyVaultSecret;
                                        if (parsedValues != null)
                                        {
                                            secretValue = secretValue == null ? parsedValues.SecretValue : secretValue;
                                            disable = disable == false ? !parsedValues.Enabled : disable;
                                            expires = expires == null ? parsedValues.Expires : expires;
                                            notBefore = notBefore == null ? parsedValues.NotBefore : notBefore;
                                            contentType = contentType == null ? parsedValues.ContentType : contentType;
                                            tag = tag == null ? parsedValues.Tags : tag;
                                        }
                                    }
                                    catch { }
                                }

                                if (newItemValue != null && parsedValues == null && parsedHashTableValues == null)
                                {
                                    WriteWarning("-Value must be of type PSKeyVaultSecret or HashTable, values from -Value will not be used");
                                }

                                if (secretValue == null)
                                {
                                    throw new Exception("-SecretValue parameter is required to create a new secret.");
                                }

                                var newSecret = kvDriveInfo.KeyVaultDataServiceClient.SetSecret(namesFromPath[0], name, secretValue,
                                    new PSKeyVaultSecretAttributes(!disable, expires, notBefore, contentType, tag));

                                WriteItemObject(newSecret, path, false);
                            }
                        }
                    }
                    else if (namesFromPath[1] == "Certificates" || (namesFromPath.Length == 2 && type.Equals("certificate", StringComparison.CurrentCultureIgnoreCase)))
                    {
                        if (type != null && !type.Equals("certificate", StringComparison.CurrentCultureIgnoreCase))
                        {
                            throw new PSNotSupportedException(string.Format("Creating type '{0}' at location '{1}' is not suppported.", type, path));
                        }

                        string name = namesFromPath[namesFromPath.Length - 1];

                        var existingCert = kvDriveInfo.KeyVaultDataServiceClient.GetCertificate(namesFromPath[0], name, string.Empty);
                        if (existingCert != null)
                        {
                            throw new Exception(string.Format("Cannot overwrite existing certificate '{0}'", name));
                        }
                        if (vault.EnableSoftDelete == true)
                        {
                            var deletedCert = kvDriveInfo.KeyVaultDataServiceClient.GetDeletedCertificate(namesFromPath[0], name);
                            if (deletedCert != null)
                            {
                                throw new Exception("Existing soft deleted certificate with the same name.");
                            }
                        }


                        if (ShouldProcess(name))
                        {
                            var dynamicParameters = DynamicParameters as NewItemCertificateDynamicParameters;
                            var certificatePolicy = dynamicParameters.CertificatePolicy;
                            var filePath = dynamicParameters.FilePath;
                            var password = dynamicParameters.Password;
                            var certificateString = dynamicParameters.CertificateString;
                            var certificateCollection = dynamicParameters.CertificateCollection;
                            var tag = dynamicParameters.Tag;

                            var parsedHashTableValues = newItemValue as Hashtable;
                            PSKeyVaultCertificate parsedValues = null;
                            if (parsedHashTableValues != null)
                            {
                                certificatePolicy = certificatePolicy == null ? parsedHashTableValues["CertificatePolicy"] as PSKeyVaultCertificatePolicy : certificatePolicy;
                                filePath = filePath == null ? parsedHashTableValues["FilePath"] as string : filePath;
                                password = password == null ? parsedHashTableValues["Password"] as SecureString : password;
                                certificateString = certificateString == null ? parsedHashTableValues["CertificateString"] as string : certificateString;
                                certificateCollection = certificateCollection == null ? parsedHashTableValues["CertificateCollection"] as X509Certificate2Collection : certificateCollection;
                                tag = tag == null ? parsedHashTableValues["Tag"] as Hashtable : tag;
                            }
                            else
                            {
                                try
                                {
                                    parsedValues = LanguagePrimitives.ConvertTo(newItemValue, typeof(PSKeyVaultCertificate)) as PSKeyVaultCertificate;
                                    if (parsedValues != null)
                                    {
                                        certificatePolicy = certificatePolicy == null ? parsedValues.Policy : certificatePolicy;
                                        tag = tag == null ? parsedValues.Tags : tag;
                                    }
                                }
                                catch { }
                            }

                            if (newItemValue != null && parsedValues == null && parsedHashTableValues == null)
                            {
                                WriteWarning("-Value must be of type PSKeyVaultSecret or HashTable, values from -Value will not be used");
                            }

                            if (certificatePolicy == null && filePath == null && certificateString == null && certificateCollection == null)
                            {
                                throw new Exception("Must provide one of: CertificatePolicy, FilePath, CertificateString, or CertificateCollection");
                            }

                            if (!OnlyOneOf(certificatePolicy, filePath, certificateString, certificateCollection))
                            {
                                throw new ArgumentException("Must provide only one of: CertificatePolicy, FilePath, CertificateString, or CertificateCollection.");
                            }

                            if (password != null && (filePath == null && certificateString == null))
                            {
                                throw new ArgumentException("Password can only be used with FilePath or CertificateString");
                            }
                            
                            if (certificatePolicy != null)
                            {
                                var newCert = kvDriveInfo.KeyVaultDataServiceClient.EnrollCertificate(namesFromPath[0], name,
                                    certificatePolicy == null ? null : certificatePolicy.ToCertificatePolicy(), tag == null ? null : tag.ConvertToDictionary());
                                WriteItemObject(newCert, path, false);
                            }
                            else if (filePath != null)
                            {
                                PSKeyVaultCertificate certBundle = null;
                                bool doImport = false;
                                X509Certificate2Collection userProvidedCertColl = InitializeCertificateCollection(filePath, password);

                                // look for at least one certificate which contains a private key
                                foreach (var cert in userProvidedCertColl)
                                {
                                    doImport |= cert.HasPrivateKey;
                                    if (doImport)
                                        break;
                                }

                                if (doImport)
                                {
                                    byte[] base64Bytes;

                                    if (password == null)
                                    {
                                        base64Bytes = userProvidedCertColl.Export(X509ContentType.Pfx);
                                    }
                                    else
                                    {
                                        base64Bytes = userProvidedCertColl.Export(X509ContentType.Pfx, password.ConvertToString());
                                    }

                                    string base64CertCollection = Convert.ToBase64String(base64Bytes);
                                    certBundle = kvDriveInfo.KeyVaultDataServiceClient.ImportCertificate(vault.VaultName, namesFromPath[2], base64CertCollection, password, tag == null ? null : tag.ConvertToDictionary());
                                }
                                else
                                {
                                    certBundle = kvDriveInfo.KeyVaultDataServiceClient.MergeCertificate(
                                        vault.VaultName, 
                                        namesFromPath[2],
                                        userProvidedCertColl,
                                        tag == null ? null : tag.ConvertToDictionary());
                                }
                                WriteItemObject(certBundle, path, false);
                            }
                            else if (certificateString != null)
                            {
                                PSKeyVaultCertificate certBundle = kvDriveInfo.KeyVaultDataServiceClient.ImportCertificate(vault.VaultName, namesFromPath[2], certificateString, password, tag == null ? null : tag.ConvertToDictionary());
                                WriteItemObject(certBundle, path, false);
                            }
                            else if (certificateCollection != null)
                            {
                                PSKeyVaultCertificate certBundle = kvDriveInfo.KeyVaultDataServiceClient.ImportCertificate(vault.VaultName, namesFromPath[2], certificateCollection, tag == null ? null : tag.ConvertToDictionary());
                                WriteItemObject(certBundle, path, false);
                            }
                        }
                    }
                    else if (namesFromPath[1] == "Keys" || (namesFromPath.Length == 2 && type.Equals("key", StringComparison.CurrentCultureIgnoreCase)))
                    {
                        if (type != null && !type.Equals("key", StringComparison.CurrentCultureIgnoreCase))
                        {
                            throw new PSNotSupportedException(string.Format("Creating type '{0}' at location '{1}' is not suppported.", type, path));
                        }

                        string name = namesFromPath[namesFromPath.Length - 1];

                        if (vault.EnableSoftDelete == true)
                        {
                            var deletedCert = kvDriveInfo.KeyVaultDataServiceClient.GetDeletedCertificate(namesFromPath[0], name);
                            if (deletedCert != null)
                            {
                                throw new Exception("Existing soft deleted certificate with the same name.");
                            }
                        }
                        var existingKey = kvDriveInfo.KeyVaultDataServiceClient.GetKey(namesFromPath[0], name, string.Empty);
                        if (existingKey == null || Force || ShouldContinue(string.Format("Overwrite key '{0}'?", name), "Overwrite item?"))
                        {
                            if (ShouldProcess(name))
                            {
                                var dynamicParameters = DynamicParameters as NewItemKeyDynamicParameters;
                                var destination = dynamicParameters.Destination;
                                var keyFilePath = dynamicParameters.KeyFilePath;
                                var keyFilePassword = dynamicParameters.KeyFilePassword;
                                bool? disable = dynamicParameters.Disable;
                                var keyOps = dynamicParameters.KeyOps;
                                var expires = dynamicParameters.Expires;
                                var notBefore = dynamicParameters.NotBefore;
                                var size = dynamicParameters.Size;
                                var tag = dynamicParameters.Tag;

                                var parsedHashTableValues = newItemValue as Hashtable;
                                PSKeyVaultKey parsedValues = null;
                                if (parsedHashTableValues != null)
                                {
                                    destination = destination == null ? parsedHashTableValues["Destination"] as string : destination;
                                    keyFilePath = keyFilePath == null ? parsedHashTableValues["KeyFilePath"] as string : keyFilePath;
                                    keyFilePassword = keyFilePassword == null ? parsedHashTableValues["KeyFilePassword"] as SecureString : keyFilePassword;
                                    disable = disable == false ? parsedHashTableValues["Disable"] as bool? == true : disable;
                                    if ((parsedHashTableValues["KeyOps"] as object[]) != null)
                                    {
                                        keyOps = keyOps == null ?
                                            Array.ConvertAll((parsedHashTableValues["KeyOps"] as object[]), x => x.ToString()) : keyOps;
                                    }
                                    else if ((parsedHashTableValues["KeyOps"] as object) != null)
                                    {
                                        keyOps = keyOps == null ? new string[] { parsedHashTableValues["KeyOps"] as string } : keyOps;
                                    }
                                    expires = expires == null ? parsedHashTableValues["Expires"] as DateTime? : expires;
                                    notBefore = notBefore == null ? parsedHashTableValues["NotBefore"] as DateTime? : notBefore;
                                    size = size == null ? parsedHashTableValues["Size"] as int? : size;
                                    tag = tag == null ? parsedHashTableValues["Tag"] as Hashtable : tag;
                                }
                                else
                                {
                                    try
                                    {
                                        parsedValues = LanguagePrimitives.ConvertTo(newItemValue, typeof(PSKeyVaultKey)) as PSKeyVaultKey;
                                        if (parsedValues != null)
                                        {
                                            destination = destination == null ? (parsedValues.Attributes.KeyType.Equals("RSA") ? "Software" : "HSM") : destination;
                                            disable = disable == false ? !parsedValues.Attributes.Enabled : disable;
                                            keyOps = keyOps == null ? parsedValues.Attributes.KeyOps : keyOps;
                                            expires = expires == null ? parsedValues.Attributes.Expires : expires;
                                            notBefore = notBefore == null ? parsedValues.Attributes.NotBefore : notBefore;
                                            tag = tag == null ? parsedValues.Tags : tag;
                                        }
                                    }
                                    catch { }
                                }

                                if (newItemValue != null && parsedValues == null && parsedHashTableValues == null)
                                {
                                    WriteWarning("-Value must be of type PSKeyVaultSecret or HashTable, values from -Value will not be used");
                                }

                                if (destination == null && keyFilePath == null)
                                {
                                    throw new Exception("The -Destination parameter or the -KeyFilePath parameter must be provided to create a key.");
                                }

                                var keyType = ("HSM".Equals(destination, StringComparison.OrdinalIgnoreCase)) ? JsonWebKeyType.RsaHsm : JsonWebKeyType.Rsa;
                                var newCert = kvDriveInfo.KeyVaultDataServiceClient.CreateKey(namesFromPath[0], name,
                                    new PSKeyVaultKeyAttributes(!disable, expires, notBefore, keyType, keyOps, tag), size);

                                WriteItemObject(newCert, path, false);
                            }
                        }
                    }
                    else if (namesFromPath[1] == "AccessPolicies" || (namesFromPath.Length == 2 && type.Equals("accesspolicy", StringComparison.CurrentCultureIgnoreCase)))
                    {
                        if (type != null && !type.Equals("accesspolicy", StringComparison.CurrentCultureIgnoreCase))
                        {
                            throw new PSNotSupportedException(string.Format("Creating type '{0}' at location '{1}' is not suppported.", type, path));
                        }

                        string name = namesFromPath[namesFromPath.Length - 1];

                        if (ShouldProcess(name))
                        {
                            var dynamicParameters = DynamicParameters as NewItemAccessPolicyParameters;
                            var userPrincipalName = dynamicParameters.UserPrincipalName;
                            var objectId = dynamicParameters.ObjectId;
                            var applicationId = dynamicParameters.ApplicationId;
                            bool? bypassObjectIdValidation = dynamicParameters.BypassObjectIdValidation;
                            var servicePrincipalName = dynamicParameters.ServicePrincipalName;
                            var emailAddress = dynamicParameters.EmailAddress;
                            var permissionsToKeys = dynamicParameters.PermissionsToKeys;
                            var permissionsToSecrets = dynamicParameters.PermissionsToSecrets;
                            var permissionsToCertificates = dynamicParameters.PermissionsToCertificates;
                            var permissionsToStorage = dynamicParameters.PermissionsToStorage;

                            var parsedHashTableValues = newItemValue as Hashtable;
                            PSKeyVaultAccessPolicy parsedValues = null;
                            if (parsedHashTableValues != null)
                            {
                                userPrincipalName = userPrincipalName == null ? parsedHashTableValues["UserPrincipalName"] as string : userPrincipalName;
                                objectId = objectId == null ? parsedHashTableValues["ObjectId"] as string : objectId;
                                applicationId = applicationId == null ? parsedHashTableValues["ApplicationId"] as Guid? : applicationId;
                                servicePrincipalName = servicePrincipalName == null ? parsedHashTableValues["ServicePrincipalName"] as string : servicePrincipalName;
                                emailAddress = emailAddress == null ? parsedHashTableValues["EmailAddress"] as string : emailAddress;
                                bypassObjectIdValidation = bypassObjectIdValidation == false ? parsedHashTableValues["BypassObjectIdValidation"] as bool? == true : bypassObjectIdValidation;
                                if ((parsedHashTableValues["PermissionsToKeys"] as object[]) != null)
                                {
                                    permissionsToKeys = permissionsToKeys == null ?
                                        Array.ConvertAll((parsedHashTableValues["PermissionsToKeys"] as object[]), x => x.ToString()) : permissionsToKeys;
                                }
                                else if ((parsedHashTableValues["PermissionsToKeys"] as object) != null)
                                {
                                    permissionsToKeys = permissionsToKeys == null ? new string[] { parsedHashTableValues["PermissionsToKeys"] as string } : permissionsToKeys;
                                }

                                if ((parsedHashTableValues["PermissionsToSecrets"] as object[]) != null)
                                {
                                    permissionsToSecrets = permissionsToSecrets == null ?
                                        Array.ConvertAll((parsedHashTableValues["PermissionsToSecrets"] as object[]), x => x.ToString()) : permissionsToSecrets;
                                }
                                else if ((parsedHashTableValues["PermissionsToSecrets"] as object) != null)
                                {
                                    permissionsToSecrets = permissionsToSecrets == null ? new string[] { parsedHashTableValues["PermissionsToSecrets"] as string } : permissionsToSecrets;
                                }

                                if ((parsedHashTableValues["PermissionsToCertificates"] as object[]) != null)
                                {
                                    permissionsToCertificates = permissionsToCertificates == null ?
                                        Array.ConvertAll((parsedHashTableValues["PermissionsToCertificates"] as object[]), x => x.ToString()) : permissionsToCertificates;
                                }
                                else if ((parsedHashTableValues["PermissionsToCertificates"] as object) != null)
                                {
                                    permissionsToCertificates = permissionsToCertificates == null ? new string[] { parsedHashTableValues["PermissionsToCertificates"] as string } : permissionsToCertificates;
                                }

                                if ((parsedHashTableValues["PermissionsToStorage"] as object[]) != null)
                                {
                                    permissionsToStorage = permissionsToStorage == null ?
                                        Array.ConvertAll((parsedHashTableValues["PermissionsToStorage"] as object[]), x => x.ToString()) : permissionsToStorage;
                                }
                                else if ((parsedHashTableValues["PermissionsToStorage"] as object) != null)
                                {
                                    permissionsToStorage = permissionsToStorage == null ? new string[] { parsedHashTableValues["PermissionsToStorage"] as string } : permissionsToStorage;
                                }
                            }
                            else
                            {
                                try
                                {
                                    parsedValues = LanguagePrimitives.ConvertTo(newItemValue, typeof(PSKeyVaultAccessPolicy)) as PSKeyVaultAccessPolicy;
                                    if (parsedValues != null)
                                    {
                                        objectId = objectId == null ? (parsedValues.ObjectId) : objectId;
                                        permissionsToKeys = permissionsToKeys == null ? parsedValues.PermissionsToKeys.ToArray() : permissionsToKeys;
                                        permissionsToSecrets = permissionsToSecrets == null ? parsedValues.PermissionsToSecrets.ToArray() : permissionsToSecrets;
                                        permissionsToCertificates = permissionsToCertificates == null ? parsedValues.PermissionsToCertificates.ToArray() : permissionsToCertificates;
                                        permissionsToStorage = permissionsToStorage == null ? parsedValues.PermissionsToStorage.ToArray() : permissionsToStorage;
                                    }
                                }
                                catch { }
                            }

                            if (objectId == null && userPrincipalName == null && emailAddress == null && servicePrincipalName == null)
                            {
                                throw new ArgumentException("Must provide one of: ObjectId, UserPrincipalName, EmailAddress, or ServicePrincipalName.");
                            }

                            if (applicationId != null && objectId == null)
                            {
                                throw new ArgumentException("ApplicationId can only be provided when using ObjectId.");
                            }

                            if (bypassObjectIdValidation == true && objectId == null)
                            {
                                throw new ArgumentException("ObjectId validation can only be bypassed when -ObjectId is provided.");
                            }

                            if (!OnlyOneOf(objectId, userPrincipalName, servicePrincipalName, emailAddress))
                            {
                                throw new ArgumentException("Must provide only one of: ObjectId, UserPrincipalName, EmailAddress, or ServicePrincipalName.");
                            }

                            var objId = objectId;
                            if (bypassObjectIdValidation != true)
                            {
                                objId = GetObjectId(objectId, userPrincipalName, emailAddress, servicePrincipalName);
                            }
                            WriteWarning(string.Format("Using objectId as the name of this Access Policy.  To retrieve this policy, run " +
                                "'Get-Item -Path {0}:/{1}/AccessPolicies/{2}'", kvDriveInfo.Name, namesFromPath[0], objId));

                            if (applicationId.HasValue && applicationId.Value == Guid.Empty)
                            {
                                throw new ArgumentException("Invalid application Id.");
                            }

                            //Is there an existing policy for this policy identity?
                            var existingPolicy = vault.AccessPolicies.FirstOrDefault(ap => MatchVaultAccessPolicyIdentity(ap, objId, applicationId));

                            //New policy will have permission arrays that are either from cmdlet input
                            //or if that's null, then from the old policy for this object ID if one existed
                            var keys = permissionsToKeys ?? (existingPolicy != null && existingPolicy.PermissionsToKeys != null ?
                                existingPolicy.PermissionsToKeys.ToArray() : null);

                            var secrets = permissionsToSecrets ?? (existingPolicy != null && existingPolicy.PermissionsToSecrets != null ?
                                existingPolicy.PermissionsToSecrets.ToArray() : null);

                            var certificates = permissionsToCertificates ?? (existingPolicy != null && existingPolicy.PermissionsToCertificates != null ?
                                existingPolicy.PermissionsToCertificates.ToArray() : null);

                            var managedStorage = permissionsToStorage ?? (existingPolicy != null && existingPolicy.PermissionsToStorage != null ?
                                existingPolicy.PermissionsToStorage.ToArray() : null);

                            PSKeyVaultAccessPolicy policy = null;
                            //Remove old policies for this policy identity and add a new one with the right permissions, iff there were some non-empty permissions
                            var updatedListOfAccessPolicies = vault.AccessPolicies.Where(ap => !MatchVaultAccessPolicyIdentity(ap, objId, applicationId)).ToArray();
                            if ((keys != null && keys.Length > 0) || (secrets != null && secrets.Length > 0) || (certificates != null && certificates.Length > 0) || (managedStorage != null && managedStorage.Length > 0))
                            {
                                policy = new PSKeyVaultAccessPolicy(vault.TenantId, objId, applicationId, keys, secrets, certificates, managedStorage);
                                updatedListOfAccessPolicies = updatedListOfAccessPolicies.Concat(new[] { policy }).ToArray();
                            }

                            var updatedVault = kvDriveInfo.KeyVaultClient.UpdateVault(vault, updatedListOfAccessPolicies, vault.EnabledForDeployment,
                                vault.EnabledForTemplateDeployment, vault.EnabledForDiskEncryption, vault.EnableSoftDelete, vault.EnablePurgeProtection,
                                vault.NetworkAcls, kvDriveInfo.ActiveDirectoryClient);

                            foreach (var accesspolicy in updatedVault.AccessPolicies)
                            {
                                if (accesspolicy.ObjectId.Equals(objId))
                                {
                                    WriteItemObject(accesspolicy, path, false);
                                }
                            }
                        }
                    }
                }
                else
                {
                    throw new PSNotSupportedException(string.Format("Creating type '{0}' at location '{1}' is not suppported.", type, path));
                }
            }
        }

        /// The Windows PowerShell engine calls this method when the Copy-Item 
        /// cmdlet is run. This method copies an item at the specified path to 
        /// the location specified.
        protected override void CopyItem(string path, string copyPath, bool recurse)
        {
            throw new NotImplementedException();
        }

        /// The Windows PowerShell engine calls this method when the Remove-Item 
        /// cmdlet is run. This method removes (deletes) the item at the specified 
        /// path.
        protected override void RemoveItem(string path, bool recurse)
        {
            isLoggedIn();

            KVDriveInfo kvDriveInfo = this.PSDriveInfo as KVDriveInfo;

            // Check if the path represented is a drive
            if (this.PathIsDrive(path))
            {
                throw new NotSupportedException("Removing all vaults in a subscription is not supported.");
            }

            if (!ItemExists(path))
            {
                throw new ItemNotFoundException(string.Format("Cannot find path {0} because it does not exist.", path));
            }

            var namesFromPath = ChunkPath(path);

            var resourceGroupName = this.GetResourceGroupName(namesFromPath[0]);
            PSKeyVault vault = null;
            if (resourceGroupName != null)
            {
                vault = kvDriveInfo.KeyVaultClient.GetVault(namesFromPath[0], resourceGroupName, kvDriveInfo.ActiveDirectoryClient);
            }
            if (vault != null)
            {
                if (namesFromPath.Length == 1 || (namesFromPath.Length == 2 && namesFromPath[1].Equals("")))
                {
                    if (Force || ShouldContinue(string.Format("Remove vault '{0}'?", vault.VaultName), "Remove item?"))
                    {
                        kvDriveInfo.KeyVaultClient.DeleteVault(vault.VaultName, vault.ResourceGroupName);
                    }
                }
                else if (namesFromPath.Length == 2 || (namesFromPath.Length == 3 && namesFromPath[2].Equals("")))
                {
                    if (namesFromPath[1] == "Secrets")
                    {
                        var secrets = kvDriveInfo.KeyVaultDataServiceClient.GetSecrets(
                            new KeyVaultObjectFilterOptions { VaultName = namesFromPath[0], NextLink = null });
                        foreach (var secret in secrets)
                        {
                            if (Force || ShouldContinue(string.Format("Remove secret '{0}' from vault '{1}'?", secret.Name, secret.VaultName), "Remove item?"))
                            {
                                try
                                {
                                    kvDriveInfo.KeyVaultDataServiceClient.DeleteSecret(secret.VaultName, secret.Name);
                                }
                                catch (Exception e)
                                {
                                    WriteError(new ErrorRecord(
                                         new ArgumentException(secret.Name + ": " + e.Message),
                                         "ServerException",
                                         ErrorCategory.InvalidOperation,
                                         secret.Name));
                                }
                            }
                        }
                    }
                    else if (namesFromPath[1] == "Certificates")
                    {
                        var certificates = kvDriveInfo.KeyVaultDataServiceClient.GetCertificates(
                            new KeyVaultObjectFilterOptions { VaultName = namesFromPath[0], NextLink = null });
                        foreach (var certificate in certificates)
                        {
                            if (Force || ShouldContinue(string.Format("Remove certificate '{0}' from vault '{1}'?", certificate.Name, certificate.VaultName), "Remove item?"))
                            {
                                try
                                {
                                    kvDriveInfo.KeyVaultDataServiceClient.DeleteCertificate(certificate.VaultName, certificate.Name);
                                }
                                catch (Exception e)
                                {
                                    WriteError(new ErrorRecord(
                                         new ArgumentException(certificate.Name + ": " + e.Message),
                                         "ServerException",
                                         ErrorCategory.InvalidOperation,
                                         certificate.Name));
                                }
                            }
                        }
                    }
                    else if (namesFromPath[1] == "Keys")
                    {
                        var keys = kvDriveInfo.KeyVaultDataServiceClient.GetKeys(
                            new KeyVaultObjectFilterOptions { VaultName = namesFromPath[0], NextLink = null });
                        foreach (var key in keys)
                        {
                            if (Force || ShouldContinue(string.Format("Remove key '{0}' from vault '{1}'?", key.Name, key.VaultName), "Remove item?"))
                            {
                                try
                                {
                                    kvDriveInfo.KeyVaultDataServiceClient.DeleteKey(key.VaultName, key.Name);
                                }
                                catch (Exception e)
                                {
                                    WriteError(new ErrorRecord(
                                         new ArgumentException(key.Name + ": " + e.Message),
                                         "ServerException",
                                         ErrorCategory.InvalidOperation,
                                         key.Name));
                                }
                            }
                        }
                    }
                    else if (namesFromPath[1] == "AccessPolicies")
                    {
                        var policies = vault.AccessPolicies;
                        foreach (var policy in policies)
                        {
                            if (Force || ShouldContinue(string.Format("Remove access policy '{0}' from vault '{1}'?", policy.ObjectId, vault.VaultName), "Remove item?"))
                            {
                                try
                                {
                                    var updatedPolicies = vault.AccessPolicies.Where(ap => !ShallBeRemoved(ap, policy.ObjectId, null)).ToArray();
                                    var updatedVault = kvDriveInfo.KeyVaultClient.UpdateVault(
                                        vault, updatedPolicies, vault.EnabledForDeployment, vault.EnabledForTemplateDeployment, vault.EnabledForDiskEncryption,
                                        vault.EnableSoftDelete, vault.EnablePurgeProtection, vault.NetworkAcls, kvDriveInfo.ActiveDirectoryClient);
                                }
                                catch (Exception e)
                                {
                                    WriteError(new ErrorRecord(
                                         new ArgumentException(policy.ObjectId + ": " + e.Message),
                                         "ServerException",
                                         ErrorCategory.InvalidOperation,
                                         policy.ObjectId));
                                }
                            }
                        }
                    }
                }
                else if (namesFromPath.Length == 3)
                {
                    if (namesFromPath[1] == "Secrets")
                    {
                        if (Force || ShouldContinue(string.Format("Remove secret '{0}' from vault '{1}'?", namesFromPath[2], namesFromPath[0]), "Remove item?"))
                        {
                            kvDriveInfo.KeyVaultDataServiceClient.DeleteSecret(namesFromPath[0], namesFromPath[2]);
                        }
                    }
                    else if (namesFromPath[1] == "Certificates")
                    {
                        if (Force || ShouldContinue(string.Format("Remove certificate '{0}' from vault '{1}'?", namesFromPath[2], namesFromPath[0]), "Remove item?"))
                        {
                            kvDriveInfo.KeyVaultDataServiceClient.DeleteCertificate(namesFromPath[0], namesFromPath[2]);
                        }
                    }
                    else if (namesFromPath[1] == "Keys")
                    {
                        if (Force || ShouldContinue(string.Format("Remove key '{0}' from vault '{1}'?", namesFromPath[2], namesFromPath[0]), "Remove item?"))
                        {
                            kvDriveInfo.KeyVaultDataServiceClient.DeleteKey(namesFromPath[0], namesFromPath[2]);
                        }
                    }
                    else if (namesFromPath[1] == "AccessPolicies")
                    {
                        if (Force || ShouldContinue(string.Format("Remove access policy '{0}' from vault '{1}'?", namesFromPath[2], namesFromPath[0]), "Remove item?"))
                        {
                            var updatedPolicies = vault.AccessPolicies.Where(ap => !ShallBeRemoved(ap, namesFromPath[2], null)).ToArray();
                            var updatedVault = kvDriveInfo.KeyVaultClient.UpdateVault(
                                vault, updatedPolicies, vault.EnabledForDeployment, vault.EnabledForTemplateDeployment, vault.EnabledForDiskEncryption,
                                vault.EnableSoftDelete, vault.EnablePurgeProtection, vault.NetworkAcls, kvDriveInfo.ActiveDirectoryClient);
                        }
                    }
                }
            }
        }

        #endregion Container Methods

        #region Container Helper Methods

        protected Guid GetTenantId()
        {
            if (AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant == null || AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.GetId() == Guid.Empty)
            {
                throw new InvalidOperationException("Invalid Azure environment");
            }

            return AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.GetId();
        }

        protected string GetCurrentUsersObjectId()
        {
            var kvDriveInfo = PSDriveInfo as KVDriveInfo;

            var DefaultContext = AzureRmProfileProvider.Instance.Profile.DefaultContext;
            if (DefaultContext.Subscription == null)
                throw new InvalidOperationException("Invalid Subscription selected");

            if (DefaultContext.Account == null)
                throw new InvalidOperationException("No default user selected");

            string objectId = null;
            if (DefaultContext.Account.Type == AzureAccount.AccountType.User)
            {
#if NETSTANDARD
                objectId = kvDriveInfo.ActiveDirectoryClient.GetObjectId(new ADObjectFilterOptions {UPN = DefaultContext.Account.Id}).ToString();
#else
                var userFetcher = kvDriveInfo.ActiveDirectoryClient.Me.ToUser();
                var user = userFetcher.ExecuteAsync().Result;
                objectId = user.ObjectId;
#endif
            }

            return objectId;
        }

        protected List<PSKeyVaultIdentityItem> ListVaults(string resourceGroupName, Hashtable tag)
        {
            KVDriveInfo kvDriveInfo = this.PSDriveInfo as KVDriveInfo;

            IResourceManagementClient armClient = kvDriveInfo.ResourcesClient;

            PSTagValuePair tagValuePair = new PSTagValuePair();
            if (tag != null && tag.Count > 0)
            {
                tagValuePair = TagsConversionHelper.Create(tag);
                if (tagValuePair == null)
                {
                    throw new ArgumentException("Invalid tag format. Expect @{Name = 'tagName'} or @{Name = 'tagName'; Value = 'tagValue'}");
                }
            }
            IPage<GenericResource> listResult = null;
            var resourceType = tag == null ? kvDriveInfo.KeyVaultClient.VaultsResourceType : null;
            if (resourceGroupName != null)
            {
                listResult = armClient.ResourceGroups.ListResources(resourceGroupName,
                    new Rest.Azure.OData.ODataQuery<GenericResourceFilter>(
                        r => r.ResourceType == resourceType &&
                             r.Tagname == tagValuePair.Name &&
                             r.Tagvalue == tagValuePair.Value));
            }
            else
            {
                listResult = armClient.Resources.List(
                    new Rest.Azure.OData.ODataQuery<GenericResourceFilter>(
                        r => r.ResourceType == resourceType &&
                             r.Tagname == tagValuePair.Name &&
                             r.Tagvalue == tagValuePair.Value));
            }

            List<PSKeyVaultIdentityItem> vaults = new List<PSKeyVaultIdentityItem>();
            if (listResult != null)
            {
                vaults.AddRange(listResult.Where(r => r.Type.Equals(kvDriveInfo.KeyVaultClient.VaultsResourceType, StringComparison.OrdinalIgnoreCase))
                    .Select(r => new PSKeyVaultIdentityItem(r)));
            }

            while (!string.IsNullOrEmpty(listResult.NextPageLink))
            {
                if (resourceGroupName != null)
                {
                    listResult = armClient.ResourceGroups.ListResourcesNext(listResult.NextPageLink);
                }
                else
                {
                    listResult = armClient.Resources.ListNext(listResult.NextPageLink);
                }

                if (listResult != null)
                {
                    vaults.AddRange(listResult.Select(r => new PSKeyVaultIdentityItem(r)));
                }
            }

            return vaults;
        }

        protected string GetObjectId(string objectId, string upn, string email, string spn)
        {
            KVDriveInfo kvDriveInfo = this.PSDriveInfo as KVDriveInfo;

            string objId = null;
            var objectFilter = objectId ?? string.Empty;

            if (!string.IsNullOrEmpty(objectId))
            {
                objId = ValidateObjectId(objectId) ? objectId : null;
            }
            else if (!string.IsNullOrEmpty(upn))
            {
                objId = GetObjectIdByUpn(upn);
            }
            else if (!string.IsNullOrEmpty(email))
            {
                objId = GetObjectIdByEmail(email);
            }
            else if (!string.IsNullOrEmpty(spn))
            {
                objId = GetObjectIdBySpn(spn);
            }

            if (string.IsNullOrWhiteSpace(objId))
                throw new ArgumentException(string.Format("Cannot find the Active Directory object '{0}' in tenant '{1}'. "+
                    "Please make sure that the user or application service principal you are authorizing is registered in the current subscription's Azure Active directory. "+
                    "The TenantID displayed by the cmdlet 'Get-AzureRmContext' is the current subscription's Azure Active directory.", objectFilter, string.Empty));

            return objId;
        }

        private bool ValidateObjectId(string objId)
        {
            KVDriveInfo kvDriveInfo = this.PSDriveInfo as KVDriveInfo;

            bool isValid = false;
            if (!string.IsNullOrWhiteSpace(objId))
            {
#if NETSTANDARD
                var objectCollection = kvDriveInfo.ActiveDirectoryClient.GetObjectsByObjectId(new List<string> { objId });
#else
                var objectCollection = kvDriveInfo.ActiveDirectoryClient.GetObjectsByObjectIdsAsync(new[] { objId }, new string[] { }).GetAwaiter().GetResult();
#endif
                if (objectCollection.Any())
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        private string GetObjectIdByUpn(string upn)
        {
            KVDriveInfo kvDriveInfo = this.PSDriveInfo as KVDriveInfo;

            string objId = null;
            if (!string.IsNullOrWhiteSpace(upn))
            {
#if NETSTANDARD
                var user = kvDriveInfo.ActiveDirectoryClient.FilterUsers(new ADObjectFilterOptions() { UPN = upn }).SingleOrDefault();
#else
                var user = kvDriveInfo.ActiveDirectoryClient.Users.Where(u => u.UserPrincipalName.Equals(upn, StringComparison.OrdinalIgnoreCase))
                     .ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult().CurrentPage.SingleOrDefault();
#endif
                if (user != null)
                {
#if NETSTANDARD
                    objId = user.Id.ToString();
#else
                    objId = user.ObjectId;
#endif
                }
            }
            return objId;
        }

        private string GetObjectIdBySpn(string spn)
        {
            KVDriveInfo kvDriveInfo = this.PSDriveInfo as KVDriveInfo;

            string objId = null;
            if (!string.IsNullOrWhiteSpace(spn))
            {
#if NETSTANDARD
                var servicePrincipal = kvDriveInfo.ActiveDirectoryClient.FilterServicePrincipals(new ADObjectFilterOptions() { SPN = spn }).SingleOrDefault();
                objId = servicePrincipal?.Id.ToString();
#else
                var servicePrincipal = kvDriveInfo.ActiveDirectoryClient.ServicePrincipals.Where(s =>
                    s.ServicePrincipalNames.Any(n => n.Equals(spn, StringComparison.OrdinalIgnoreCase)))
                     .ExecuteAsync().GetAwaiter().GetResult().CurrentPage.SingleOrDefault();
                objId = servicePrincipal?.ObjectId;
#endif
            }
            return objId;
        }

        private string GetObjectIdByEmail(string email)
        {
            KVDriveInfo kvDriveInfo = this.PSDriveInfo as KVDriveInfo;

            string objId = null;
            // In ADFS, Graph cannot handle this particular combination of filters.
            if (!AzureRmProfileProvider.Instance.Profile.DefaultContext.Environment.OnPremise && !string.IsNullOrWhiteSpace(email))
            {
#if NETSTANDARD
                var users = kvDriveInfo.ActiveDirectoryClient.FilterUsers(new ADObjectFilterOptions() { Mail = email });
                if (users != null)
                {
                    ThrowIfMultipleObjectIds(users, email);
                    var user = users.FirstOrDefault();
                    objId = user?.Id.ToString();
                }
#else
                var users = kvDriveInfo.ActiveDirectoryClient.Users.Where(FilterByEmail(email)).ExecuteAsync().GetAwaiter().GetResult().CurrentPage;
                if (users != null)
                {
                    ThrowIfMultipleObjectIds(users, email);
                    var user = users.FirstOrDefault();
                    objId = user?.ObjectId;
                }
#endif
            }
            return objId;
        }

#if !NETSTANDARD
        private Expression<Func<IUser, bool>> FilterByEmail(string email)
        {
            return u => u.Mail.Equals(email, StringComparison.OrdinalIgnoreCase) ||
                u.OtherMails.Any(m => m.Equals(email, StringComparison.OrdinalIgnoreCase));
        }
#endif
        private void ThrowIfMultipleObjectIds<AADType>(IEnumerable<AADType> principal, string objectFilter)
        {
            KVDriveInfo kvDriveInfo = this.PSDriveInfo as KVDriveInfo;

            // If there is a second element then there are too many.
            if (principal.ElementAtOrDefault(1) != null)
            {
                throw new ArgumentException(string.Format("The Email argument specified, '{1}', matches multiple objects in the Azure Active Directory tenant '{2}'."
                    + " Please use -UserPrincipalName to narrow down the filter to a single object. The TenantID displayed by the cmdlet 'Get-AzureRmContext' " +
                    "is the current subscription's Azure Active Directory.", objectFilter, string.Empty));
            }
        }

        private bool OnlyOneOf(object objectId, object userPrincipalName, object servicePrincipalName, object emailAddress)
        {
            var totalProvided = 0;
            if (objectId != null)
            {
                totalProvided++;
            }
            if (userPrincipalName != null)
            {
                totalProvided++;
            }
            if (servicePrincipalName != null)
            {
                totalProvided++;
            }
            if (emailAddress != null)
            {
                totalProvided++;
            }
            
            if (totalProvided == 1)
            {
                return true;
            }
            return false;
        }

        private bool ShallBeRemoved(PSKeyVaultAccessPolicy ap, string objectId, Guid? applicationId)
        {
            // If both object id and application id are specified, remove the compound identity policy only.
            // If only object id is specified, remove all policies refer to the object id including the compound identity policies.
            var sameObjectId = string.Equals(ap.ObjectId, objectId, StringComparison.OrdinalIgnoreCase);
            return applicationId.HasValue ? (ap.ApplicationId == applicationId && sameObjectId) : sameObjectId;
        }

        internal X509Certificate2Collection InitializeCertificateCollection(string filePath, SecureString password)
        {
            FileInfo certFile = new FileInfo(this.SessionState.Path.GetUnresolvedProviderPathFromPSPath(filePath));
            if (!certFile.Exists)
            {
                throw new FileNotFoundException(string.Format("Cannot find certificate file '{0}'.", filePath));
            }

            X509Certificate2Collection certificateCollection = new X509Certificate2Collection();

            if (null == password)
            {
                certificateCollection.Import(certFile.FullName);
            }
            else
            {
                certificateCollection.Import(certFile.FullName, password.ConvertToString(), X509KeyStorageFlags.Exportable);
            }

            return certificateCollection;
        }

        #endregion Container Helper Methods

        #region Navigation Methods

        protected override bool IsItemContainer(string path)
        {
            isLoggedIn();

            if (PathIsDrive(path))
            {
                return true;
            }

            var namesFromPath = ChunkPath(path);

            KVDriveInfo kvDriveInfo = this.PSDriveInfo as KVDriveInfo;

            var resourceGroupName = this.GetResourceGroupName(namesFromPath[0]);
            if (resourceGroupName == null)
            {
                return false;
            }

            var vault = kvDriveInfo.KeyVaultClient.GetVault(namesFromPath[0], resourceGroupName);
            if (vault != null)
            {
                if (namesFromPath.Length == 1 || (namesFromPath.Length == 2 && namesFromPath[1].Equals("")))
                {
                    return true;
                }
                else if (namesFromPath.Length == 2 || (namesFromPath.Length == 3 && namesFromPath[2].Equals("")))
                {
                    if (namesFromPath[1].Equals("Secrets") || namesFromPath[1].Equals("Certificates") || namesFromPath[1].Equals("Keys") || namesFromPath[1].Equals("AccessPolicies"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
        protected override string GetChildName(string path)
        {
            if (this.PathIsDrive(path))
            {
                return path;
            }

            int separatorIndex = path.LastIndexOf(pathSeparator);
            if (separatorIndex == -1)
            {
                return path;
            }

            return path.Substring(separatorIndex + 1);
        }

        protected override string GetParentPath(string path, string root)
        {
            path = NormalizePath(path);
            var rootPath = NormalizePath(root);

            if (!string.IsNullOrEmpty(rootPath))
            {
                if (!path.Contains(rootPath))
                {
                    return string.Empty;
                }
                else if (path.Equals(rootPath))
                {
                    return path;
                }
            }

            int separatorIndex = path.LastIndexOf(pathSeparator);
            if (separatorIndex == -1)
            {
                return string.Empty;
            }
            return path.Substring(0, separatorIndex);
        }

        protected override string MakePath(string parent, string child)
        {
            string result;

            string normalParent = NormalizePath(parent);
            normalParent = RemoveDriveFromPath(normalParent);
            string normalChild = NormalizePath(child);
            normalChild = RemoveDriveFromPath(normalChild);

            if (String.IsNullOrEmpty(normalParent) && String.IsNullOrEmpty(normalChild))
            {
                result = String.Empty;
            }
            else if (String.IsNullOrEmpty(normalParent) && !String.IsNullOrEmpty(normalChild))
            {
                result = normalChild;
            }
            else if (!String.IsNullOrEmpty(normalParent) && String.IsNullOrEmpty(normalChild))
            {
                if (normalParent.EndsWith(pathSeparator, StringComparison.OrdinalIgnoreCase))
                {
                    result = normalParent;
                }
                else
                {
                    result = normalParent + pathSeparator;
                }
            }
            else
            {
                if (!normalParent.Equals(String.Empty) &&
                    !normalParent.EndsWith(pathSeparator, StringComparison.OrdinalIgnoreCase))
                {
                    result = normalParent + pathSeparator;
                }
                else
                {
                    result = normalParent;
                }

                if (normalChild.StartsWith(pathSeparator, StringComparison.OrdinalIgnoreCase))
                {
                    result += normalChild.Substring(1);
                }
                else
                {
                    result += normalChild;
                }
            }

            return result;
        }

        protected override string NormalizeRelativePath(string path,
                                                            string basepath)
        {
            // Normalize the paths first
            string normalPath = NormalizePath(path);
            normalPath = RemoveDriveFromPath(normalPath);
            string normalBasePath = NormalizePath(basepath);
            normalBasePath = RemoveDriveFromPath(normalBasePath);

            if (String.IsNullOrEmpty(normalBasePath))
            {
                return normalPath;
            }
            else
            {
                if (!normalPath.Contains(normalBasePath))
                {
                    return null;
                }

                return normalPath.Substring(normalBasePath.Length + pathSeparator.Length);
            }
        }

        protected override void MoveItem(string path, string destination)
        {
            throw new NotImplementedException();
        }

        #endregion Navigation Methods

        #region Navigation Helper Methods

        private string RemoveDriveFromPath(string path)
        {
            string result = path;
            string name;

            if (this.PSDriveInfo == null)
            {
                name = String.Empty;
            }
            else
            {
                name = NormalizePath(this.PSDriveInfo.Name + ":");
            }

            if (result == null)
            {
                result = String.Empty;
            }

            if (result.Contains(name))
            {
                result = result.Substring(result.IndexOf(name, StringComparison.OrdinalIgnoreCase) + name.Length);
            }

            return result;
        }

        #endregion Navigation Helper Methods

        #region DynamicParameters

        protected override object GetChildItemsDynamicParameters(string path, bool recurse)
        {
            if (path != null)
            {
                if (this.PathIsDrive(path))
                {
                    return new GetChildItemsVaultDynamicParameters();
                }
            }
            return null;
        }

        public class GetChildItemsVaultDynamicParameters
        {
            [Parameter]
            public Hashtable Tag { get; set; }
        }

        protected override object GetItemDynamicParameters(string path)
        {
            if (path != null)
            {
                if (this.PathIsDrive(path))
                {
                    return null;
                }

                var namesFromPath = ChunkPath(path);
                if (namesFromPath.Length == 3)
                {
                    return new GetItemSecCertKeyDynamicParameters();
                }
            }
            return null;
        }

        public class GetItemSecCertKeyDynamicParameters
        {
            [Parameter]
            public string Version { get; set; }

            [Parameter]
            public SwitchParameter IncludeVersions { get; set; }
        }

        protected override object NewItemDynamicParameters(string path, string itemTypeName, object newItemValue)
        {
            if (itemTypeName != null)
            {
                if (itemTypeName.Equals("vault", StringComparison.CurrentCultureIgnoreCase))
                {
                    return new NewItemVaultDynamicParameters();
                }
                else if (itemTypeName.Equals("secret", StringComparison.CurrentCultureIgnoreCase))
                {
                    return new NewItemSecretDynamicParameters();
                }
                else if (itemTypeName.Equals("certificate", StringComparison.CurrentCultureIgnoreCase))
                {
                    return new NewItemCertificateDynamicParameters();
                }
                else if (itemTypeName.Equals("key", StringComparison.CurrentCultureIgnoreCase))
                {
                    return new NewItemKeyDynamicParameters();
                }
                else if (itemTypeName.Equals("accesspolicy", StringComparison.CurrentCultureIgnoreCase))
                {
                    return new NewItemAccessPolicyParameters();
                }
            }
            else if (path != null)
            {
                if (this.PathIsDrive(path))
                {
                    return null;
                }

                var namesFromPath = ChunkPath(path);
                if (namesFromPath.Length == 1 || (namesFromPath.Length == 2 && namesFromPath[1].Equals("")))
                {
                    return new NewItemVaultDynamicParameters();
                }
                else if ((namesFromPath.Length == 2 || (namesFromPath.Length == 3 && namesFromPath[2].Equals(""))) ||
                    (namesFromPath.Length == 3))
                {
                    if (namesFromPath[1].Equals("Secrets"))
                    {
                        return new NewItemSecretDynamicParameters();
                    }
                    else if (namesFromPath[1].Equals("Certificates"))
                    {
                        return new NewItemCertificateDynamicParameters();
                    }
                    else if (namesFromPath[1].Equals("Keys"))
                    {
                        return new NewItemKeyDynamicParameters();
                    }
                    else if (namesFromPath[1].Equals("AccessPolicies"))
                    {
                        return new NewItemAccessPolicyParameters();
                    }
                }
            }
            return null;
        }

        public class NewItemVaultDynamicParameters
        {
            [Parameter]
            public string ResourceGroupName { get; set; }

            [Parameter]
            public string Location { get; set; }

            [Parameter]
            public SwitchParameter EnabledForDeployment { get; set; }

            [Parameter]
            public SwitchParameter EnabledForTemplateDeployment { get; set; }

            [Parameter]
            public SwitchParameter EnabledForDiskEncryption { get; set; }

            [Parameter]
            public SwitchParameter EnableSoftDelete { get; set; }

            [Parameter]
            public SkuName Sku { get; set; }

            [Parameter]
            public Hashtable Tag { get; set; }
        }

        public class NewItemSecretDynamicParameters
        {
            [Parameter]
            public SecureString SecretValue { get; set; }

            [Parameter]
            public SwitchParameter Disable { get; set; }

            [Parameter]
            public DateTime? Expires { get; set; }

            [Parameter]
            public DateTime? NotBefore { get; set; }

            [Parameter]
            public string ContentType { get; set; }

            [Parameter]
            public Hashtable Tag { get; set; }
        }

        public class NewItemCertificateDynamicParameters
        {
            [Parameter]
            public PSKeyVaultCertificatePolicy CertificatePolicy { get; set; }

            [Parameter]
            public string FilePath { get; set; }

            [Parameter]
            public SecureString Password { get; set; }

            [Parameter]
            public string CertificateString { get; set; }

            [Parameter]
            public X509Certificate2Collection CertificateCollection { get; set; }

            [Parameter]
            public Hashtable Tag { get; set; }
        }

        public class NewItemKeyDynamicParameters
        {
            [Parameter]
            public string Destination { get; set; }

            [Parameter]
            public string KeyFilePath { get; set; }

            [Parameter]
            public SecureString KeyFilePassword { get; set; }

            [Parameter]
            public SwitchParameter Disable { get; set; }

            [Parameter]
            public string[] KeyOps { get; set; }

            [Parameter]
            public DateTime? Expires { get; set; }

            [Parameter]
            public DateTime? NotBefore { get; set; }

            [Parameter]
            public int? Size { get; set; }

            [Parameter]
            public Hashtable Tag { get; set; }
        }

        public class NewItemAccessPolicyParameters
        {
            [Parameter]
            public string UserPrincipalName { get; set; }

            [Parameter]
            public string ObjectId { get; set; }

            [Parameter]
            public string ServicePrincipalName { get; set; }

            [Parameter]
            public string EmailAddress { get; set; }

            [Parameter]
            public string[] PermissionsToKeys { get; set; }

            [Parameter]
            public string[] PermissionsToSecrets { get; set; }

            [Parameter]
            public string[] PermissionsToCertificates { get; set; }

            [Parameter]
            public string[] PermissionsToStorage { get; set; }

            [Parameter]
            public Guid? ApplicationId { get; set; }

            [Parameter]
            public SwitchParameter BypassObjectIdValidation { get; set; }
        }

        protected override object SetItemDynamicParameters(string path, object value)
        {
            if (path != null)
            {
                if (this.PathIsDrive(path))
                {
                    return null;
                }

                var namesFromPath = ChunkPath(path);
                if (namesFromPath.Length == 1 || (namesFromPath.Length == 2 && namesFromPath[1].Equals("")))
                {
                    return new SetItemVaultDynamicParameters();
                }
                else if (namesFromPath.Length == 3)
                {
                    if (namesFromPath[1].Equals("Secrets"))
                    {
                        return new SetItemSecretDynamicParameters();
                    }
                    else if (namesFromPath[1].Equals("Certificates"))
                    {
                        return new SetItemCertificateDynamicParameters();
                    }
                    else if (namesFromPath[1].Equals("Keys"))
                    {
                        return new SetItemKeyDynamicParameters();
                    }
                    else if (namesFromPath[1].Equals("AccessPolicies"))
                    {
                        return new SetItemAccessPolicyDynamicParameters();
                    }
                }
            }
            return null;
        }

        public class SetItemVaultDynamicParameters
        {
            [Parameter]
            public bool? EnabledForDeployment { get; set; }

            [Parameter]
            public bool? EnabledForTemplateDeployment { get; set; }

            [Parameter]
            public bool? EnabledForDiskEncryption { get; set; }
        }

        public class SetItemSecretDynamicParameters
        {
            [Parameter]
            public string Version { get; set; }
            
            [Parameter]
            public bool? Enable { get; set; }

            [Parameter]
            public DateTime? Expires { get; set; }

            [Parameter]
            public DateTime? NotBefore { get; set; }

            [Parameter]
            public string ContentType { get; set; }

            [Parameter]
            public Hashtable Tag { get; set; }
        }

        public class SetItemCertificateDynamicParameters
        {
            [Parameter]
            public string Version { get; set; }

            [Parameter]
            public bool? Enable { get; set; }

            [Parameter]
            public Hashtable Tag { get; set; }
        }

        public class SetItemKeyDynamicParameters
        {
            [Parameter]
            public string Version { get; set; }
            
            [Parameter]
            public bool? Enable { get; set; }

            [Parameter]
            public DateTime? Expires { get; set; }

            [Parameter]
            public DateTime? NotBefore { get; set; }

            [Parameter]
            public string[] KeyOps { get; set; }

            [Parameter]
            public Hashtable Tag { get; set;}
        }

        public class SetItemAccessPolicyDynamicParameters
        {
            [Parameter]
            public string[] PermissionsToKeys { get; set; }

            [Parameter]
            public string[] PermissionsToSecrets { get; set; }

            [Parameter]
            public string[] PermissionsToCertificates { get; set; }

            [Parameter]
            public string[] PermissionsToStorage { get; set; }
        }

        #endregion DynamicParameters

        #region Content Methods

        public IContentReader GetContentReader(string path)
        {
            isLoggedIn();

            if (!ItemExists(path))
            {
                throw new ArgumentException(string.Format("Item does not exist at path '{0}'", path));
            }

            // Check to see if the path represents a valid drive.
            if (this.PathIsDrive(path))
            {
                throw new NotImplementedException();
            }

            var namesFromPath = ChunkPath(path);

            KVDriveInfo kvDriveInfo = this.PSDriveInfo as KVDriveInfo;

            var resourceGroupName = this.GetResourceGroupName(namesFromPath[0]);
            PSKeyVault vault = null;
            if (resourceGroupName != null)
            {
                vault = kvDriveInfo.KeyVaultClient.GetVault(namesFromPath[0], resourceGroupName, kvDriveInfo.ActiveDirectoryClient);
            }
            if (vault != null)
                if (vault != null)
            {
                if (namesFromPath.Length == 3)
                {
                    if (namesFromPath[1] == "Secrets")
                    {
                        return new KVReader(kvDriveInfo, namesFromPath[0], "secret", namesFromPath[2]);
                    }
                    else if (namesFromPath[1] == "Certificates")
                    {
                        return new KVReader(kvDriveInfo, namesFromPath[0], "certificate", namesFromPath[2]);
                    }
                    else if (namesFromPath[1] == "Keys")
                    {
                        return new KVReader(kvDriveInfo, namesFromPath[0], "key", namesFromPath[2]);
                    }
                }
            }
            throw new NotImplementedException();
        }

        public object GetContentReaderDynamicParameters(string path)
        {
            return null;
        }

        public IContentWriter GetContentWriter(string path)
        {
            isLoggedIn();

            // Check to see if the path represents a valid drive.
            if (this.PathIsDrive(path))
            {
                throw new NotImplementedException();
            }

            if (!ItemExists(path))
            {
                throw new ItemNotFoundException(string.Format("Cannot find path {0} because it does not exist.", path));
            }

            var namesFromPath = ChunkPath(path);

            KVDriveInfo kvDriveInfo = this.PSDriveInfo as KVDriveInfo;

            var resourceGroupName = this.GetResourceGroupName(namesFromPath[0]);
            PSKeyVault vault = null;
            if (resourceGroupName != null)
            {
                vault = kvDriveInfo.KeyVaultClient.GetVault(namesFromPath[0], resourceGroupName, kvDriveInfo.ActiveDirectoryClient);
            }
            if (vault != null)
                if (vault != null)
            {
                if (namesFromPath.Length == 3)
                {
                    if (namesFromPath[1] == "Secrets")
                    {
                        return new KVWriter(kvDriveInfo, namesFromPath[0], "secret", namesFromPath[2]);
                    }
                }
            }
            throw new NotImplementedException();
        }

        public object GetContentWriterDynamicParameters(string path)
        {
            return null;
        }

        public void ClearContent(string path)
        {
        }

        public object ClearContentDynamicParameters(string path)
        {
            throw new NotImplementedException();
        }

        public class KVReader : IContentReader
        {
            private string _vaultName;
            private string _type;
            private string _name;
            private KVDriveInfo _kvDriveInfo;
            private bool _hasBeenRead;
            public KVReader(PSDriveInfo kvDriveInfo, string vaultName, string type, string name)
            {
                _vaultName = vaultName;
                _type = type;
                _name = name;
                _kvDriveInfo = kvDriveInfo as KVDriveInfo;
                _hasBeenRead = false;
            }

            public void Close()
            {
            }

            public void Dispose()
            {
            }

            public IList Read(long readCount)
            {
                if (_hasBeenRead)
                {
                    return new List<string> { };
                }

                _hasBeenRead = true;
                if (_type.Equals("secret"))
                {
                    var secret = _kvDriveInfo.KeyVaultDataServiceClient.GetSecret(_vaultName, _name, string.Empty);
                    var secretValue = secret.SecretValueText;
                    return new List<string> { secretValue };
                }
                else if (_type.Equals("certificate"))
                {
                    PSKeyVaultCertificate certificate = _kvDriveInfo.KeyVaultDataServiceClient.GetCertificate(_vaultName, _name, string.Empty);
                    var certificateBundle = certificate.Certificate;
                    return new List<System.Security.Cryptography.X509Certificates.X509Certificate2> { certificateBundle };
                }
                else if (_type.Equals("key"))
                {
                    var key = _kvDriveInfo.KeyVaultDataServiceClient.GetKey(_vaultName, _name, string.Empty);
                    var keyBundle = key.Key;
                    return new List<JsonWebKey> { keyBundle };
                }
                return new List<string> { };
            }

            public void Seek(long offset, SeekOrigin origin)
            {
            }
        }

        public class KVWriter : IContentWriter
        {
            private string _vaultName;
            private string _type;
            private string _name;
            private KVDriveInfo _kvDriveInfo;
            public KVWriter(PSDriveInfo kvDriveInfo, string vaultName, string type, string name)
            {
                _vaultName = vaultName;
                _type = type;
                _name = name;
                _kvDriveInfo = kvDriveInfo as KVDriveInfo;
            }

            public void Close()
            {
            }

            public void Dispose()
            {
            }

            public void Seek(long offset, SeekOrigin origin)
            {
            }

            public IList Write(IList content)
            {
                if (_type.Equals("secret") && content.Count == 1)
                {
                    var secretvalue = LanguagePrimitives.ConvertTo(content[0], typeof(SecureString)) as SecureString;
                    if (secretvalue == null)
                    {
                        throw new ArgumentException("Value type must be equal to string");
                    }
                    var secret = _kvDriveInfo.KeyVaultDataServiceClient.GetSecret(_vaultName, _name, string.Empty);
                    var newSecret = _kvDriveInfo.KeyVaultDataServiceClient.SetSecret(_vaultName, _name, secretvalue,
                        new PSKeyVaultSecretAttributes(secret.Enabled, secret.Expires, secret.NotBefore, secret.ContentType, secret.Tags));
                    return new List<PSKeyVaultSecret> { newSecret };
                }
                return new List<string> { };
            }
        }

        #endregion
    }

    #endregion KeyVaultProvider

    #region KVPSDriveInfo

    /// Any state associated with the drive is held here.
    internal class KVDriveInfo : PSDriveInfo
    {

        public KVDriveInfo(PSDriveInfo driveInfo)
               : base(driveInfo)
        {
        }

        public VaultManagementClient KeyVaultClient
        {
            get
            {
                var context = AzureRmProfileProvider.Instance.Profile.DefaultContext;
                return new VaultManagementClient(context);
            }
        }

        public KeyVaultDataServiceClient KeyVaultDataServiceClient
        {
            get
            {
                var context = AzureRmProfileProvider.Instance.Profile.DefaultContext;
                return new KeyVaultDataServiceClient(AzureSession.Instance.AuthenticationFactory, context);
            }
        }

        public ResourceManagementClient ResourcesClient
        {
            get
            {
                var context = AzureRmProfileProvider.Instance.Profile.DefaultContext;
                var resourcesClient = AzureSession.Instance.ClientFactory.CreateCustomArmClient<ResourceManagementClient>(
                                    context.Environment.GetEndpointAsUri(AzureEnvironment.Endpoint.ResourceManager),
                                    AzureSession.Instance.AuthenticationFactory.GetServiceClientCredentials(context, AzureEnvironment.Endpoint.ResourceManager),
                                    AzureSession.Instance.ClientFactory.GetCustomHandlers());
                resourcesClient.SubscriptionId = context.Subscription.Id;
                return resourcesClient;
            }
        }

        public ActiveDirectoryClient ActiveDirectoryClient
        {
            get
            {

                var _dataServiceCredential = new DataServiceCredential(AzureSession.Instance.AuthenticationFactory, AzureRmProfileProvider.Instance.Profile.DefaultContext, AzureEnvironment.Endpoint.Graph);
#if NETSTANDARD
                var activeDirectoryClient = new ActiveDirectoryClient(AzureRmProfileProvider.Instance.Profile.DefaultContext);
#else
                var activeDirectoryClient = new ActiveDirectoryClient(new Uri(string.Format("{0}/{1}",
                AzureRmProfileProvider.Instance.Profile.DefaultContext.Environment.GetEndpoint(AzureEnvironment.Endpoint.Graph), _dataServiceCredential.TenantId)),
                () => Task.FromResult(_dataServiceCredential.GetToken()));
#endif
                return activeDirectoryClient;
            }
        }
    }

    #endregion KVPSDriveInfo
}