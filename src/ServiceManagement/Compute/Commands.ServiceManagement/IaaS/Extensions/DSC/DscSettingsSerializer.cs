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
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions.DSC
{
    public class DscSettingsSerializer
    {
        /// <summary>
        /// Serialize DscPublicSettings to string.
        /// </summary>
        /// <param name="publicSettings"></param>
        /// <returns></returns>
        public static string SerializePublicSettings(DscPublicSettings publicSettings)
        {
            return JsonConvert.SerializeObject(publicSettings);
        }

        /// <summary>
        /// Serialize DscPrivateSettings to string.
        /// </summary>
        /// <param name="privateSettings"></param>
        /// <returns></returns>
        public static string SerializePrivateSettings(DscPrivateSettings privateSettings)
        {
            return JsonConvert.SerializeObject(privateSettings);
        }

        public static DscPublicSettings DeserializePublicSettings(string publicSettingsString)
        {
            DscPublicSettings publicSettings = null;
            try
            {
                publicSettings = string.IsNullOrEmpty(publicSettingsString)
                                     ? null
                                     : JsonConvert.DeserializeObject<DscPublicSettings>(publicSettingsString);
            }
            catch (JsonException)
            {
                // Try deserialize as version 1.0
                try
                {
                    DscPublicSettings.Version1 publicSettingsV1 =
                        JsonConvert.DeserializeObject<DscPublicSettings.Version1>(publicSettingsString);
                    publicSettings = publicSettingsV1.ToCurrentVersion();
                }
                catch (JsonException e)
                {
                    throw e;
                } 
            }
            return publicSettings;
        }

         /// <summary>
        /// Convert hashtable of public settings into two parts:
        /// 1) Array of public settings in format:
        /// [
        ///             {
        ///                 "Name":  "String Parameter",
        ///                 "Value":  "String Value",
        ///                 "TypeName":  "System.String"
        ///             }
        /// ]
        /// 2) Private settings hashtable. We extract all sensitive information (like password from PSCredential)
        ///    and store it in private settings. Public settings will reference them in form:
        ///             {
        ///                 "Name":  "AdminCredential",
        ///                 "Value":  
        ///                 {
        ///                     "Password" : "PrivateSettings:28AC4D36-A99B-41DE-8421-2BCC1C7C1A3B"
        ///                     "UserName" : "DOMAIN\LOGIN"
        ///                 },
        ///                 "TypeName":  "System.Management.Automation.PSCredential"
        ///             }
        /// and private hashtable will look like that:
        /// {
        ///     "28AC4D36-A99B-41DE-8421-2BCC1C7C1A3B" : "password"
        /// }
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns>tuple of array (public settings) and hashtable (private settings)</returns>
        public static Tuple<DscPublicSettings.Property[], Hashtable> SeparatePrivateItems(Hashtable arguments)
        {
            var publicSettings = new List<DscPublicSettings.Property>();
            var privateSettings = new Hashtable();
            if (arguments != null)
            {
                foreach (DictionaryEntry argument in arguments)
                {
                    object entryValue = argument.Value;
                    string entryType = argument.Value == null ? "null" : argument.Value.GetType().ToString();
                    string entryName = argument.Key.ToString();
                    // Special case for PSCredential
                    PSCredential credential = argument.Value as PSCredential;
                    if (credential == null)
                    {
                        PSObject psObject = argument.Value as PSObject;
                        if (psObject != null)
                        {
                            credential = psObject.BaseObject as PSCredential;
                        }
                    }
                    if (credential != null)
                    {
                        // plainTextPassword is a string object with sensitive information  in plain text. 
                        // We pass it to 3rd party serializer which may create copies of the string.
                        string plainTextPassword = ConvertToUnsecureString(credential.Password);
                        string userName = credential.UserName;
                        string passwordRef = Guid.NewGuid().ToString();
                        privateSettings.Add(passwordRef, plainTextPassword);
                        var newValue = new Hashtable();
                        newValue["UserName"] = String.Format(CultureInfo.InvariantCulture, userName);
                        newValue["Password"] = String.Format(CultureInfo.InvariantCulture, "PrivateSettingsRef:{0}",
                            passwordRef);
                        entryValue = newValue;
                        entryType = typeof (PSCredential).ToString();
                    }

                    var entry = new DscPublicSettings.Property()
                    {
                        Name = entryName,
                        TypeName = entryType,
                        Value = entryValue,
                    };
                    publicSettings.Add(entry);
                }
            }
            return new Tuple<DscPublicSettings.Property[], Hashtable>(publicSettings.ToArray(), privateSettings);
        }

        /// <summary>
        /// Converte SecureString to String.
        /// </summary>
        /// <remarks>
        /// This method creates a managed object with sensitive information and undetermined lifecycle.
        /// </remarks>
        /// <param name="source"></param>
        /// <returns></returns>
        private static string ConvertToUnsecureString(SecureString source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(source);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

    }
}
