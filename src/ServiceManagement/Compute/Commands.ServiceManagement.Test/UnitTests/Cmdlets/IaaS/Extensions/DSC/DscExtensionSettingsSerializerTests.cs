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
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Security;
using Microsoft.WindowsAzure.Commands.Common.Extensions.DSC;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test;
using Xunit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.WindowsAzure.Commands.Common.Test.Extensions.DSC
{
    /// <summary>
    /// Tests for <see cref="DscExtensionSettingsSerializer"/> class.
    /// </summary>
    public class DscExtensionSettingsSerializerTests
    {
        [Fact]
        [Trait(Category.Functional, Category.BVT)]
        public void TestPsCredential()
        {
            const string userName = "user";
            const string password = "password";
            const string credentialParameterName = "cred";
            Hashtable configurationArguments = new Hashtable();
            configurationArguments.Add(credentialParameterName, new PSCredential(userName, String2SecureString(password)));
            
            DscExtensionPrivateSettings privateSettings;
            var publicSettings = GetPublicPrivateAfterDeseriazlization(configurationArguments, out privateSettings);

            Assert.Equal(1, publicSettings.Properties.Count());
            Assert.Equal(credentialParameterName, publicSettings.Properties[0].Name);
            Assert.Equal(typeof(PSCredential).ToString(), publicSettings.Properties[0].TypeName);
            var deserializedPsCredential = publicSettings.Properties[0].Value as JObject;
            Assert.NotNull(deserializedPsCredential);

            Assert.Equal(userName, deserializedPsCredential["UserName"]);
            string passwordRef = deserializedPsCredential["Password"].ToString();
            Assert.NotNull(passwordRef);

            Assert.True(passwordRef.StartsWith("PrivateSettingsRef:"));
            passwordRef = passwordRef.Substring("PrivateSettingsRef:".Length);

            Assert.Equal(1, privateSettings.Items.Count);
            // There is only one, so it's fine to check it in foreach.
            foreach (DictionaryEntry argument in privateSettings.Items)
            {
                Assert.Equal(password, argument.Value);
                Assert.Equal(passwordRef, argument.Key);
            }
        }

        [Fact]
        [Trait(Category.Functional, Category.BVT)]
        public void TestString()
        {
            const string arg = "argument";
            const string value = "value";
            Hashtable configurationArguments = new Hashtable();
            configurationArguments.Add(arg, value);

            DscExtensionPrivateSettings privateSettings;
            var publicSettings = GetPublicPrivateAfterDeseriazlization(configurationArguments, out privateSettings);

            Assert.Equal(1, publicSettings.Properties.Count());
            Assert.Equal(arg, publicSettings.Properties[0].Name);
            Assert.Equal(typeof(string).ToString(), publicSettings.Properties[0].TypeName);
            var deserializedValue = publicSettings.Properties[0].Value;
            Assert.Equal(value, deserializedValue);
        }

        [Fact]
        [Trait(Category.Functional, Category.BVT)]
        public void TestInt()
        {
            const string arg = "argument";
            var value = 100500;
            Hashtable configurationArguments = new Hashtable();
            configurationArguments.Add(arg, value);

            DscExtensionPrivateSettings privateSettings;
            var publicSettings = GetPublicPrivateAfterDeseriazlization(configurationArguments, out privateSettings);

            Assert.Equal(1, publicSettings.Properties.Count());
            Assert.Equal(arg, publicSettings.Properties[0].Name);
            Assert.Equal(typeof(int).ToString(), publicSettings.Properties[0].TypeName);
            var deserializedValue = publicSettings.Properties[0].Value;
            Assert.Equal(value.ToString(CultureInfo.InvariantCulture), deserializedValue.ToString());
        }

        [Fact]
        [Trait(Category.Functional, Category.BVT)]
        public void TestBool()
        {
            const string arg = "argument";
            const bool value = true;
            var configurationArguments = new Hashtable {{arg, true}};

            DscExtensionPrivateSettings privateSettings;
            var publicSettings = GetPublicPrivateAfterDeseriazlization(configurationArguments, out privateSettings);

            Assert.Equal(1, publicSettings.Properties.Count());
            Assert.Equal(arg, publicSettings.Properties[0].Name);
            Assert.Equal(typeof(bool).ToString(), publicSettings.Properties[0].TypeName);
            var deserializedValue = publicSettings.Properties[0].Value;
            Assert.Equal(value, deserializedValue);
        }

        [Fact]
        [Trait(Category.Functional, Category.BVT)]
        public void TestChar()
        {
            const string arg = "argument";
            var value = 'z';
            Hashtable configurationArguments = new Hashtable();
            configurationArguments.Add(arg, value);

            DscExtensionPrivateSettings privateSettings;
            var publicSettings = GetPublicPrivateAfterDeseriazlization(configurationArguments, out privateSettings);

            Assert.Equal(1, publicSettings.Properties.Count());
            Assert.Equal(arg, publicSettings.Properties[0].Name);
            Assert.Equal(typeof(char).ToString(), publicSettings.Properties[0].TypeName);
            var deserializedValue = publicSettings.Properties[0].Value;
            Assert.Equal(value.ToString(CultureInfo.InvariantCulture), deserializedValue.ToString());
        }

        /// <summary>
        /// Helper function for tests.
        /// </summary>
        /// <param name="configurationArguments"></param>
        /// <param name="privateSettings"></param>
        /// <returns></returns>
        private static DscExtensionPublicSettings GetPublicPrivateAfterDeseriazlization(
            Hashtable configurationArguments,
            out DscExtensionPrivateSettings privateSettings)
        {
            Tuple<DscExtensionPublicSettings.Property[], Hashtable> separatedSettings =
                DscExtensionSettingsSerializer.SeparatePrivateItems(configurationArguments);
            DscExtensionPublicSettings extensionPublicSettings = new DscExtensionPublicSettings();
            privateSettings = new DscExtensionPrivateSettings();
            extensionPublicSettings.Properties = separatedSettings.Item1;
            privateSettings.Items = separatedSettings.Item2;

            string serializedPublic = DscExtensionSettingsSerializer.SerializePublicSettings(extensionPublicSettings);
            string serializedPrivate = DscExtensionSettingsSerializer.SerializePrivateSettings(privateSettings);

            extensionPublicSettings = DscExtensionSettingsSerializer.DeserializePublicSettings(serializedPublic);
            privateSettings = DeserializePrivateSettings(serializedPrivate);
            return extensionPublicSettings;
        }

        /// <summary>
        /// Convert string to SecureString.
        /// </summary>
        /// <remarks>
        /// This implementation is unsecure and can be used only for tests.
        /// </remarks>
        static private SecureString String2SecureString(string s)
        {
            var secureString = new SecureString();
            foreach (char c in s)
            {
                secureString.AppendChar(c);
            }
            return secureString;
        }

        /// <summary>
        /// We use this method for test purposes only.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static private DscExtensionPrivateSettings DeserializePrivateSettings(string s)
        {
            return JsonConvert.DeserializeObject<DscExtensionPrivateSettings>(s);
        }
    }
}
