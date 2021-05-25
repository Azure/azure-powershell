using System;
using System.IO;
using System.Text;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SshKey")]
    [OutputType(typeof(PSSshPublicKeyResource))]
    public partial class NewAzureSshKey : ComputeAutomationBaseCmdlet
    {

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Compute/SshPublicKeys", "ResourceGroupName")]
        [SupportsWildcards]
        [Alias("sshkeyName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public string PublicKey { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroupName = this.ResourceGroupName;
                string sshKeyName = this.Name;
                SshPublicKeyResource result;


                if (this.IsParameterBound(c => c.PublicKey))
                {
                    SshPublicKeyResource sshkey = new SshPublicKeyResource();
                    sshkey.Location = "westus";
                    sshkey.PublicKey = this.PublicKey;
                    result = SshPublicKeyClient.Create(resourceGroupName, sshKeyName, sshkey);
                }
                else
                {
                    WriteDebug("No public key is provided. A key pair is being generated for you.");
                    
                    SshPublicKeyResource sshkey = new SshPublicKeyResource();
                    sshkey.Location = "westus";
                    result = SshPublicKeyClient.Create(resourceGroupName, sshKeyName, sshkey);
                    SshPublicKeyGenerateKeyPairResult keypair = SshPublicKeyClient.GenerateKeyPair(resourceGroupName, sshKeyName);
                    result.PublicKey = keypair.PublicKey;

                    string sshFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\.ssh\";
                    if (!Directory.Exists(sshFolder))
                    {
                        Directory.CreateDirectory(sshFolder);
                    }

                    DateTimeOffset now = DateTimeOffset.UtcNow;
                    string privateKeyFileName = now.ToUnixTimeSeconds().ToString();
                    string publicKeyFileName = now.ToUnixTimeSeconds().ToString() + ".pub";

                    using (StreamWriter writer = new StreamWriter(sshFolder + privateKeyFileName))
                    {
                        writer.WriteLine(keypair.PrivateKey);
                    }
                    Console.WriteLine("Private key is saved to " + sshFolder + privateKeyFileName);
                    
                    using (StreamWriter writer = new StreamWriter(sshFolder + publicKeyFileName))
                    {
                        writer.WriteLine(keypair.PublicKey);
                    }
                    Console.WriteLine("Public key is saved to " + sshFolder + publicKeyFileName);
                }

                var psObject = new PSSshPublicKeyResource();
                ComputeAutomationAutoMapperProfile.Mapper.Map<SshPublicKeyResource, PSSshPublicKeyResource>(result, psObject);
                WriteObject(psObject);
            });
        }
    }
}
