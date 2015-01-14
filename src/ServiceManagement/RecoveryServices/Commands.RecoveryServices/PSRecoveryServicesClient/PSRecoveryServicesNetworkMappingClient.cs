// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Management.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Target network type.
    /// </summary>
    public enum TargetNetworkType
    {
        /// <summary>
        /// Target type of the network is Server.
        /// </summary>
        Server = 0,

        /// <summary>
        /// Target type of the network is Azure.
        /// </summary>
        Azure,
    }

    /// <summary>
    /// Helper around serialization/deserialization of objects. This one is a thin wrapper around
    /// DataContractUtils template class which is the one doing the heavy lifting.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    public static class DataContractUtils
    {
        /// <summary>
        /// Serializes the supplied object to the string.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="obj">Object to serialize</param>
        /// <returns>Serialized string.</returns>
        public static string Serialize<T>(T obj)
        {
            return DataContractUtils<T>.Serialize(obj);
        }

        /// <summary>
        /// Deserialize the string to the expected object type.
        /// </summary>
        /// <typeparam name="T">The object type</typeparam>
        /// <param name="xmlString">Serialized string</param>
        /// <param name="result">Deserialized object</param>
        public static void Deserialize<T>(string xmlString, out T result)
        {
            result = DataContractUtils<T>.Deserialize(xmlString);
        }
    }

    /// <summary>
    /// Template class for DataContractUtils.
    /// </summary>
    /// <typeparam name="T">The object type</typeparam>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    public static class DataContractUtils<T>
    {
        /// <summary>
        /// Serializes the propertyBagContainer to the string. 
        /// </summary>
        /// <param name="propertyBagContainer">Property bag</param>
        /// <returns>Serialized string </returns>
        public static string Serialize(T propertyBagContainer)
        {
            var serializer = new DataContractSerializer(typeof(T));
            string xmlString;
            StringWriter sw = null;
            try
            {
                sw = new StringWriter();
                using (var writer = new XmlTextWriter(sw))
                {
                    // Indent the XML so it's human readable.
                    writer.Formatting = Formatting.Indented;
                    serializer.WriteObject(writer, propertyBagContainer);
                    writer.Flush();
                    xmlString = sw.ToString();
                }
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }

            return xmlString;
        }

        /// <summary>
        /// Deserialize the string to the propertyBagContainer.
        /// </summary>
        /// <param name="xmlString">Serialized string</param>
        /// <returns>Deserialized object</returns>
        public static T Deserialize(string xmlString)
        {
            T propertyBagContainer;
            using (Stream stream = new MemoryStream())
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(xmlString);
                stream.Write(data, 0, data.Length);
                stream.Position = 0;
                DataContractSerializer deserializer = new DataContractSerializer(typeof(T));
                propertyBagContainer = (T)deserializer.ReadObject(stream);
            }

            return propertyBagContainer;
        }
    }

    /// <summary>
    /// Create network mapping input.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class CreateNetworkMappingInput
    {
        /// <summary>
        /// Gets or sets Primary Server Id.
        /// </summary>
        [DataMember(Order = 1)]
        public string PrimaryServerId { get; set; }

        /// <summary>
        /// Gets or sets Primary Network Id.
        /// </summary>
        [DataMember(Order = 2)]
        public string PrimaryNetworkId { get; set; }

        /// <summary>
        /// Gets or sets Recovery Server Id.
        /// </summary>
        [DataMember(Order = 3)]
        public string RecoveryServerId { get; set; }

        /// <summary>
        /// Gets or sets Recovery Network Id.
        /// </summary>
        [DataMember(Order = 4)]
        public string RecoveryNetworkId { get; set; }
    }

    /// <summary>
    /// Create Azure network mapping input.
    /// </summary>
    [SuppressMessage(
       "Microsoft.StyleCop.CSharp.MaintainabilityRules",
       "SA1402:FileMayOnlyContainASingleClass",
       Justification = "Keeping all contracts together.")]
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class CreateAzureNetworkMappingInput
    {
        /// <summary>
        /// Gets or sets Primary Server Id.
        /// </summary>
        [DataMember(Order = 1)]
        public string PrimaryServerId { get; set; }

        /// <summary>
        /// Gets or sets Primary Network Id.
        /// </summary>
        [DataMember(Order = 2)]
        public string PrimaryNetworkId { get; set; }

        /// <summary>
        /// Gets or sets Azure VM Network Id.
        /// </summary>
        [DataMember(Order = 3)]
        public string AzureVMNetworkId { get; set; }

        /// <summary>
        /// Gets or sets Azure VM Network name.
        /// </summary>
        [DataMember(Order = 4)]
        public string AzureVMNetworkName { get; set; }
    }

    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Gets Azure Site Recovery Network mappings.
        /// </summary>
        /// <param name="primaryServerId">Primary server ID</param>
        /// <param name="recoveryServerId">Recovery server ID</param>
        /// <returns>Network mapping list response</returns>
        public NetworkMappingListResponse GetAzureSiteRecoveryNetworkMappings(
            string primaryServerId, 
            string recoveryServerId)
        {
            return this.GetSiteRecoveryClient()
                .NetworkMappings
                .List(primaryServerId, recoveryServerId, this.GetRequestHeaders());
        }

        /// <summary>
        /// Create Azure Site Recovery Network Mapping.
        /// </summary>
        /// <param name="primaryServerId">Primary server Id</param>
        /// <param name="primaryNetworkId">Primary network Id</param>
        /// <param name="recoveryServerId">Recovery server Id</param>
        /// <param name="recoveryNetworkId">Recovery network Id</param>
        /// <returns>Job response</returns>
        public JobResponse NewAzureSiteRecoveryNetworkMapping(
            string primaryServerId,
            string primaryNetworkId,
            string recoveryServerId,
            string recoveryNetworkId)
        {
            CreateNetworkMappingInput createNetworkMappingInput =
                new CreateNetworkMappingInput();
            createNetworkMappingInput.PrimaryServerId = primaryServerId;
            createNetworkMappingInput.PrimaryNetworkId = primaryNetworkId;
            createNetworkMappingInput.RecoveryServerId = recoveryServerId;
            createNetworkMappingInput.RecoveryNetworkId = recoveryNetworkId;

            NetworkMappingInput networkMappingInput = new NetworkMappingInput();
            networkMappingInput.TargetNetworkType = TargetNetworkType.Server.ToString();
            networkMappingInput.CreateNetworkMappingInput =
                DataContractUtils.Serialize<CreateNetworkMappingInput>(createNetworkMappingInput);
            return this.GetSiteRecoveryClient()
                .NetworkMappings
                .Create(networkMappingInput, this.GetRequestHeaders());
        }

        /// <summary>
        /// Create Azure Site Recovery Azure Network Mapping.
        /// </summary>
        /// <param name="primaryServerId">Primary server Id</param>
        /// <param name="primaryNetworkId">Primary network Id</param>
        /// <param name="recoveryNetworkName">Recovery server Id</param>
        /// <param name="recoveryNetworkId">Recovery network Id</param>
        /// <returns>Job response</returns>
        public JobResponse NewAzureSiteRecoveryAzureNetworkMapping(
            string primaryServerId,
            string primaryNetworkId,
            string recoveryNetworkName,
            string recoveryNetworkId)
        {
            CreateAzureNetworkMappingInput createAzureNetworkMappingInput =
                new CreateAzureNetworkMappingInput();
            createAzureNetworkMappingInput.PrimaryServerId = primaryServerId;
            createAzureNetworkMappingInput.PrimaryNetworkId = primaryNetworkId;
            createAzureNetworkMappingInput.AzureVMNetworkName = recoveryNetworkName;
            createAzureNetworkMappingInput.AzureVMNetworkId = recoveryNetworkId;

            NetworkMappingInput networkMappingInput = new NetworkMappingInput();
            networkMappingInput.TargetNetworkType = TargetNetworkType.Azure.ToString();
            networkMappingInput.CreateNetworkMappingInput =
                DataContractUtils.Serialize<CreateAzureNetworkMappingInput>(createAzureNetworkMappingInput);
            return this.GetSiteRecoveryClient()
                .NetworkMappings
                .Create(networkMappingInput, this.GetRequestHeaders());
        }

        /// <summary>
        /// Validates whether the Azure VM Network is associated with the subscription or not.
        /// </summary>
        /// <param name="subscriptionId">Subscription Id</param>
        /// <param name="azureNetworkId">Azure Network Id</param>
        public void ValidateVMNetworkSubscriptionAssociation(string subscriptionId, string azureNetworkId)
        {
            /*
            NetworkManagementClient networkClient =
                AzureSession.ClientFactory.CreateClient<NetworkManagementClient>(AzureSession.CurrentContext.Subscription, AzureEnvironment.Endpoint.ServiceManagement);
            var response = this.networkClient.Networks.List();
            var sites = response.VirtualNetworkSites;
            */
        }

        /// <summary>
        /// Delete Azure Site Recovery Network Mapping.
        /// </summary>
        /// <param name="primaryServerId">Primary server Id</param>
        /// <param name="primaryNetworkId">Primary network Id</param>
        /// <param name="recoveryServerId">Recovery server Id</param>
        /// <returns>Job response</returns>
        public JobResponse RemoveAzureSiteRecoveryNetworkMapping(
            string primaryServerId,
            string primaryNetworkId,
            string recoveryServerId)
        {
            NetworkUnMappingInput networkUnMappingInput = new NetworkUnMappingInput();
            networkUnMappingInput.PrimaryServerId = primaryServerId;
            networkUnMappingInput.PrimaryNetworkId = primaryNetworkId;
            networkUnMappingInput.RecoveryServerId = recoveryServerId;

            return this.GetSiteRecoveryClient()
                .NetworkMappings
                .Delete(networkUnMappingInput, this.GetRequestHeaders());
        }
    }
}