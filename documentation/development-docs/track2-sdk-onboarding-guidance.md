# Track 2 SDK Onboarding Guidance
This guildance is used to help Azure Service Team to switch from track 1 SDK to track 2 SDK. Full content takes the implementation of Az.KeyVault as example to demonstrate the details of onboarding track 2 SDK. Generally, onborading track 2 SDK includes steps below: 

- [Track 2 Management Client Creation](#track-2-management-client-creation) 
- [Cmdlet Implementation by Track 2 SDK](#cmdlet-implementation-by-track-2-sdk)
- [Updating Wrapped SDK Types between PowerShell Model and Track 2 SDK Model](#updating-wrapped-sdk-types-between-powershell-model-and-track-2-sdk-model)
- [Breaking change detection](#breaking-change-detection)
- [Test Recording](#test-recording)

## Track 2 Management Client Creation
Firstly, we need to switch track 1 management client to track 2 management client.

Before: 
```c#
    public class VaultManagementClient 
    { 
        private IKeyVaultManagementClient KeyVaultManagementClient
        { 
            get;
            set;
        } 

        public VaultManagementClient(IAzureContext context) 
        { 
            KeyVaultManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<KeyVaultManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager); 
        } 
    } 
```
After: 
```c#
    internal class Track2KeyVaultManagementClient 
    { 
        private ArmClient _armClient; 

        private string _subscription; 

        private IClientFactory _clientFactory;  

        public Track2KeyVaultManagementClient(IClientFactory clientFactory, IAzureContext context) 
        { 
            _clientFactory = clientFactory; 

            _armClient = _clientFactory.CreateArmClient(context, AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId); 

            _subscription = context.Subscription.Id; 
        } 
} 
```

## Cmdlet Implementation by Track 2 SDK

When key vault switches to track 2 SDK, 12 cmdlets will be affected: 

- New/Get/Remove/Update-AzKeyVault
- Undo-AzKeyVaultRemoval
- New/Get/Remove/Update-AzKeyVaultManagedHsm
- Add/Update/Remove-AzKeyVaultAccessPolicy 

Their implementations should be adapted according to the track 2 SDK APIs. Taking the implementation of getting specific key vault as example: 

Before: 
```c#
    public class VaultManagementClient 
    { 
        … 

        public PSKeyVault GetVault(string vaultName, string resourceGroupName, IMicrosoftGraphClient graphClient = null) 
        { 
            if (string.IsNullOrWhiteSpace(vaultName)) 
                throw new ArgumentNullException("vaultName"); 

            if (string.IsNullOrWhiteSpace(resourceGroupName)) 
                throw new ArgumentNullException("resourceGroupName");   

            try 
            { 
                var response = KeyVaultManagementClient.Vaults.Get(resourceGroupName, vaultName); 
                return new PSKeyVault(response, graphClient); 
            } 

            catch (CloudException ce) 
            { 
                if (ce.Response.StatusCode == HttpStatusCode.NotFound) 
                { 
                    return null; 
                } 
                throw; 
            } 
        } 
} 
```
After: 
```c#
    internal class Track2KeyVaultManagementClient 
    { 
        ...       
        public Vault GetVault(string resourcegroup, string vaultName) => 
            _armClient.GetVault(Vault.CreateResourceIdentifier(_subscription, resourcegroup, vaultName)); 
    } 
```
## Updating Wrapped SDK Types between PowerShell Model and Track 2 SDK Model

Azure PowerShell team recommends wrapping SDK models with PS models to avoid breaking change. So PS model should adapt track 2 SDK. Take PSKeyVault, the output of cmdlet Get-AzKeyVault, as instance, the following code demonstrates how we wrap a SDK model with a PS model: 

Before: 
```c#
        public PSKeyVault(Vault vault, IMicrosoftGraphClient graphClient) 
        { 
            var vaultTenantDisplayName = ModelExtensions.GetDisplayNameForTenant(vault.Properties.TenantId, graphClient); 
            VaultName = vault.Name; 
            Location = vault.Location; 
            ResourceId = vault.Id; 
            ResourceGroupName = (new ResourceIdentifier(vault.Id)).ResourceGroupName; 
            Tags = TagsConversionHelper.CreateTagHashtable(vault.Tags); 
            Sku = vault.Properties.Sku.Name.ToString(); 
            TenantId = vault.Properties.TenantId; 
            TenantName = vaultTenantDisplayName; 
            VaultUri = vault.Properties.VaultUri; 
            EnabledForDeployment = vault.Properties.EnabledForDeployment ?? false; 
            EnabledForTemplateDeployment = vault.Properties.EnabledForTemplateDeployment; 
            EnabledForDiskEncryption = vault.Properties.EnabledForDiskEncryption; 
            EnableSoftDelete = vault.Properties.EnableSoftDelete; 
            EnablePurgeProtection = vault.Properties.EnablePurgeProtection; 
            EnableRbacAuthorization = vault.Properties.EnableRbacAuthorization; 
            SoftDeleteRetentionInDays = vault.Properties.SoftDeleteRetentionInDays; 
            AccessPolicies = vault.Properties.AccessPolicies.Select(s => new PSKeyVaultAccessPolicy(s, graphClient)).ToArray(); 
            NetworkAcls = InitNetworkRuleSet(vault.Properties); 
            OriginalVault = vault; 
        } 
```
After: 
```c#
        public PSKeyVault(Track2ManagementSdk.Vault vault, IMicrosoftGraphClient graphClient) 
        { 
            if (!vault.HasData)  
            { 
                vault = vault.Get(); 
            }  

            VaultName = vault.Data.Name; 
            Location = vault.Data.Location; 
            ResourceId = vault.Data.Id; 
            ResourceGroupName = new ResourceIdentifier(ResourceId).ResourceGroupName; 
            Tags = TagsConversionHelper.CreateTagHashtable(vault.Data.Tags.ToDictionary(pair => pair.Key, pair => pair.Value)); 
            Sku = vault.Data.Properties.Sku.Name.ToString(); 
            TenantId = vault.Data.Properties.TenantId; 
            var vaultTenantDisplayName = ModelExtensions.GetDisplayNameForTenant(vault.Data.Properties.TenantId, graphClient); 
            TenantName = vaultTenantDisplayName; 
            VaultUri = vault.Data.Properties.VaultUri; 
            EnabledForDeployment = vault.Data.Properties.EnabledForDeployment ?? false; 
            EnabledForTemplateDeployment = vault.Data.Properties.EnabledForTemplateDeployment; 
            EnabledForDiskEncryption = vault.Data.Properties.EnabledForDiskEncryption; 
            EnableSoftDelete = vault.Data.Properties.EnableSoftDelete; 
            EnablePurgeProtection = vault.Data.Properties.EnablePurgeProtection; 
            EnableRbacAuthorization = vault.Data.Properties.EnableRbacAuthorization; 
            SoftDeleteRetentionInDays = vault.Data.Properties.SoftDeleteRetentionInDays; 
            AccessPolicies = vault.Data.Properties.AccessPolicies.Select(ap => new PSKeyVaultAccessPolicy(ap.ToTrack1AccessPolicyEntry(), graphClient)).ToArray(); 
            NetworkAcls = InitNetworkRuleSet(vault.Data.Properties.ToTrack1VaultProperties()); 
            OriginalVault = vault; 
        } 
```
## Breaking change detection

To detect whether breaking change will be introduced. Service teams need to pay attention to the following points: 

- If API version used by track 1 and track 2 SDK are same, check SDK object whether was exposed directly as cmdlet input and output. In this case, breaking change warning message should be pre-announced in advance. For instance, PSKeyVault contains a property called OriginalVault. It is from track 1 SDK. It should be replaced with track 2 model or be removed. A breaking change message should be added for this. 

```c#
    [CmdletOutputBreakingChange(typeof(PSKeyVault), ChangeDescription = "The type of property OriginalVault is changing from Microsoft.Azure.Management.KeyVault.Models.Vault to Azure.ResourceManager.KeyVault.Vault")] 
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KeyVault", DefaultParameterSetName = GetVaultParameterSet)] 
    [OutputType(typeof(PSKeyVault), typeof(PSKeyVaultIdentityItem), typeof(PSDeletedKeyVault))] 
    public class GetAzureKeyVault : KeyVaultManagementCmdletBase 
    {…} 
```

- If API version used by track 1 and track 2 SDK are different, check the swagger definition to see if there is any property in returned model removed, or any parameter changes to required or removes. In this case, please see [breaking change guideline](https://eng.ms/docs/cloud-ai-platform/azure/azure-core-compute/control-plane-bburns/azure-cli-tools-azure-cli-powershell-and-terraform/azure-cli-tools/teams_docs/azps_docs/breakingchange_release_process).

## Test Recording

Investigating 
