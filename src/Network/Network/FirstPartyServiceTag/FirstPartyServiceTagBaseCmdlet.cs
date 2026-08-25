// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class FirstPartyServiceTagBaseCmdlet : NetworkBaseCmdlet
    {
        public IFirstPartyServiceTagsOperations FirstPartyServiceTagsClient =>
            NetworkClient.NetworkManagementClient.FirstPartyServiceTags;

        public bool IsFirstPartyServiceTagPresent(string resourceGroupName, string name)
        {
            try
            {
                GetFirstPartyServiceTag(resourceGroupName, name);
            }
            catch (ErrorException ex)
            {
                if (ex.Response?.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
            catch (Rest.Azure.CloudException ex)
            {
                if (ex.Response?.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }

            return true;
        }

        public PSFirstPartyServiceTag GetFirstPartyServiceTag(string resourceGroupName, string name)
        {
            return ToPSFirstPartyServiceTag(
                FirstPartyServiceTagsClient.Get(resourceGroupName, name),
                resourceGroupName);
        }

        public PSFirstPartyServiceTag ToPSFirstPartyServiceTag(FirstPartyServiceTag serviceTag, string resourceGroupName = null)
        {
            return new PSFirstPartyServiceTag
            {
                Id = serviceTag.Id,
                Name = serviceTag.Name,
                Type = serviceTag.Type,
                Location = serviceTag.Location,
                ResourceGroupName = resourceGroupName ?? NetworkBaseCmdlet.GetResourceGroup(serviceTag.Id),
                Tag = TagsConversionHelper.CreateTagHashtable(serviceTag.Tags),
                Etag = serviceTag.Etag,
                Value = serviceTag.Properties?.Value,
                FailedReason = serviceTag.Properties?.FailedReason,
                ResourceGuid = serviceTag.ResourceGuid,
                ProvisioningState = serviceTag.Properties?.ProvisioningState
            };
        }

        public FirstPartyServiceTag ToSdkFirstPartyServiceTag(PSFirstPartyServiceTag serviceTag)
        {
            return new FirstPartyServiceTag
            {
                Location = serviceTag.Location,
                Tags = TagsConversionHelper.CreateTagDictionary(serviceTag.Tag, validate: true),
                Properties = new FirstPartyServiceTagPropertiesFormat(serviceTag.Value)
            };
        }
    }
}
