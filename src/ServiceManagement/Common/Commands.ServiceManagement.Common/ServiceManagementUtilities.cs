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

using System.ServiceModel.Channels;
using System.Text;
using System.Xml;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.WindowsAzure.Commands.Common
{
    public static class ServiceManagementUtilities
    {
        public static string ReadMessageBody(ref Message originalMessage)
        {
            StringBuilder strBuilder = new StringBuilder();

            using (MessageBuffer messageBuffer = originalMessage.CreateBufferedCopy(int.MaxValue))
            {
                Message message = messageBuffer.CreateMessage();
                XmlWriter writer = XmlWriter.Create(strBuilder);
                using (XmlDictionaryWriter dictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer))
                {
                    message.WriteBodyContents(dictionaryWriter);
                }

                originalMessage = messageBuffer.CreateMessage();
            }

            return XmlUtilities.Beautify(strBuilder.ToString());
        }

        /// <summary>
        /// Ensure the default profile directory exists
        /// </summary>
        public static void EnsureDefaultProfileDirectoryExists()
        {
            if (!AzureSession.DataStore.DirectoryExists(AzureSession.ProfileDirectory))
            {
                AzureSession.DataStore.CreateDirectory(AzureSession.ProfileDirectory);
            }
        }

        /// <summary>
        /// Clear the current storage account from the context - guarantees that only one storage account will be active 
        /// at a time.
        /// </summary>
        public static void ClearCurrentStorageAccount()
        {
            //TODO: Move to RM
            //var RMProfile = AzureRmProfileProvider.Instance.Profile;
            //if (RMProfile != null && RMProfile.Context != null && 
            //    RMProfile.Context.Subscription != null && RMProfile.Context.Subscription.IsPropertySet(AzureSubscription.Property.StorageAccount))
            //{
            //    RMProfile.Context.Subscription.SetProperty(AzureSubscription.Property.StorageAccount, null);
            //}

            var SMProfile = AzureSMProfileProvider.Instance.Profile;
            if (SMProfile != null && SMProfile.Context != null 
                && SMProfile.Context.Subscription != null &&
                SMProfile.Context.Subscription.IsPropertySet(
                AzureSubscription.Property.StorageAccount))
            {
                SMProfile.Context.Subscription.SetProperty(
                    AzureSubscription.Property.StorageAccount, null);
            }
        }
    }
}
