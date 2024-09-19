using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TrustedSigning;
using Azure.ResourceManager.TrustedSigning.Models;
using Microsoft.Azure.Commands.CodeSigning.Helpers;
using Microsoft.Azure.Commands.CodeSigning.Models;
using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.CodeSigning.Commands.Account
{
    internal class NewAzureTrustedSigningAccount : CodeSigningCmdletBase
    {
        public string AccountName { get; set; }
        public string ResourceGroupName{ get; set; }
        public Guid SubscriptionId { get; set; }
        public TrustedSigningSkuName SkuName { get; set; }

        public override void ExecuteCmdlet()
        {
            // arm set up
            var credential = new DefaultAzureCredential();
            var ARM = new ArmClient(credential);

            // checking account uniqueness via the subscription resource...(why?)
            var subId = SubscriptionResource.CreateResourceIdentifier(SubscriptionId.ToString());
            var SUB = ARM.GetSubscriptionResource(subId);
            var uniqueReq = new TrustedSigningAccountNameAvailabilityContent(AccountName, new ResourceType("Microsoft.CodeSigning/codeSigningAccounts"));
            var result = SUB.CheckTrustedSigningAccountNameAvailability(uniqueReq);

            // throw error if it's not unique
            if(result.Value.IsNameAvailable == false)
                throw new TerminatingErrorException(new ArgumentException("Account name is not available"), System.Management.Automation.ErrorCategory.InvalidArgument);

            // create account
            var rgId = ResourceGroupResource.CreateResourceIdentifier(SubscriptionId.ToString(), ResourceGroupName);
            var RG = ARM.GetResourceGroupResource(rgId);

            // arrange account data, but does not include the account name.... (why?)
            var accountData = new TrustedSigningAccountData(RG.Data.Location) 
            { 
                SkuName = SkuName,
            };

            // have to get all accounts in RG to make a new one... (why?)
            var accounts = RG.GetTrustedSigningAccounts(); 
            var account = accounts.CreateOrUpdate(WaitUntil.Completed, AccountName, accountData);

            WriteObject(account.Value.Data);
        }
    }
}
