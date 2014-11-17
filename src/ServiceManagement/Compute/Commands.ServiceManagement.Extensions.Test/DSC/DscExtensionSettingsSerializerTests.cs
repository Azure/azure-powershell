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
using System.Linq;
using System.Management.Automation;
using System.Security;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions.DSC;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions.Test.DSC
{
    /// <summary>
    /// Tests for <see cref="DscSettingsSerializer"/> class.
    /// </summary>
    [TestClass]
    public class DscExtensionSettingsSerializerTests
    {
        [TestMethod]
        [TestCategory(Category.BVT)]
        public void TestPSCredential()
        {
            const string userName = "user";
            const string password = "password";
            const string credentialParameterName = "cred";
            Hashtable configurationArguments = new Hashtable();
            configurationArguments.Add(credentialParameterName, new PSCredential(userName, String2SecureString(password)));
            
            DscPrivateSettings privateSettings;
            var publicSettings = GetPublicPrivateAfterDeseriazlization(configurationArguments, out privateSettings);

            Assert.AreEqual(1, publicSettings.Properties.Count());
            Assert.AreEqual(credentialParameterName, publicSettings.Properties[0].Name);
            Assert.AreEqual(typeof(PSCredential).ToString(), publicSettings.Properties[0].TypeName);
            var deserializedPSCredential = publicSettings.Properties[0].Value as JObject;
            Assert.IsNotNull(deserializedPSCredential);

            Assert.AreEqual(userName, deserializedPSCredential["UserName"]);
            string passwordRef = deserializedPSCredential["Password"].ToString();
            Assert.IsNotNull(passwordRef);

            Assert.IsTrue(passwordRef.StartsWith("PrivateSettingsRef:"));
            passwordRef = passwordRef.Substring("PrivateSettingsRef:".Length);

            Assert.AreEqual(1, privateSettings.Items.Count);
            // There is only one, so it's fine to check it in foreach.
            foreach (DictionaryEntry argument in privateSettings.Items)
            {
                Assert.AreEqual(password, argument.Value);
                Assert.AreEqual(passwordRef, argument.Key);
            }
        }

        [TestMethod]
        [TestCategory(Category.BVT)]
        public void TestString()
        {
            const string arg = "argument";
            const string value = "value";
            Hashtable configurationArguments = new Hashtable();
            configurationArguments.Add(arg, value);

            DscPrivateSettings privateSettings;
            var publicSettings = GetPublicPrivateAfterDeseriazlization(configurationArguments, out privateSettings);

            Assert.AreEqual(1, publicSettings.Properties.Count());
            Assert.AreEqual(arg, publicSettings.Properties[0].Name);
            Assert.AreEqual(typeof(string).ToString(), publicSettings.Properties[0].TypeName);
            var deserializedValue = publicSettings.Properties[0].Value;
            Assert.AreEqual(value, deserializedValue);
        }

        [TestMethod]
        [TestCategory(Category.BVT)]
        public void TestInt()
        {
            const string arg = "argument";
            var value = 100500;
            Hashtable configurationArguments = new Hashtable();
            configurationArguments.Add(arg, value);

            DscPrivateSettings privateSettings;
            var publicSettings = GetPublicPrivateAfterDeseriazlization(configurationArguments, out privateSettings);

            Assert.AreEqual(1, publicSettings.Properties.Count());
            Assert.AreEqual(arg, publicSettings.Properties[0].Name);
            Assert.AreEqual(typeof(int).ToString(), publicSettings.Properties[0].TypeName);
            var deserializedValue = publicSettings.Properties[0].Value;
            Assert.AreEqual(value.ToString(), deserializedValue.ToString());
        }

        [TestMethod]
        [TestCategory(Category.BVT)]
        public void TestBool()
        {
            const string arg = "argument";
            var value = true;
            Hashtable configurationArguments = new Hashtable();
            configurationArguments.Add(arg, value);

            DscPrivateSettings privateSettings;
            var publicSettings = GetPublicPrivateAfterDeseriazlization(configurationArguments, out privateSettings);

            Assert.AreEqual(1, publicSettings.Properties.Count());
            Assert.AreEqual(arg, publicSettings.Properties[0].Name);
            Assert.AreEqual(typeof(bool).ToString(), publicSettings.Properties[0].TypeName);
            var deserializedValue = publicSettings.Properties[0].Value;
            Assert.AreEqual(value, deserializedValue);
        }

        [TestMethod]
        [TestCategory(Category.BVT)]
        public void TestChar()
        {
            const string arg = "argument";
            var value = 'z';
            Hashtable configurationArguments = new Hashtable();
            configurationArguments.Add(arg, value);

            DscPrivateSettings privateSettings;
            var publicSettings = GetPublicPrivateAfterDeseriazlization(configurationArguments, out privateSettings);

            Assert.AreEqual(1, publicSettings.Properties.Count());
            Assert.AreEqual(arg, publicSettings.Properties[0].Name);
            Assert.AreEqual(typeof(char).ToString(), publicSettings.Properties[0].TypeName);
            var deserializedValue = publicSettings.Properties[0].Value;
            Assert.AreEqual(value.ToString(), deserializedValue.ToString());
        }

        /// <summary>
        /// Helper function for tests.
        /// </summary>
        /// <param name="configurationArguments"></param>
        /// <param name="privateSettings"></param>
        /// <returns></returns>
        private static DscPublicSettings GetPublicPrivateAfterDeseriazlization(
            Hashtable configurationArguments,
            out DscPrivateSettings privateSettings)
        {
            Tuple<DscPublicSettings.Property[], Hashtable> separatedSettings =
                DscSettingsSerializer.SeparatePrivateItems(configurationArguments);
            DscPublicSettings publicSettings = new DscPublicSettings();
            privateSettings = new DscPrivateSettings();
            publicSettings.Properties = separatedSettings.Item1;
            privateSettings.Items = separatedSettings.Item2;

            string serializedPublic = DscSettingsSerializer.SerializePublicSettings(publicSettings);
            string serializedPrivate = DscSettingsSerializer.SerializePrivateSettings(privateSettings);

            publicSettings = DscSettingsSerializer.DeserializePublicSettings(serializedPublic);
            privateSettings = DeserializePrivateSettings(serializedPrivate);
            return publicSettings;
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
        static private DscPrivateSettings DeserializePrivateSettings(string s)
        {
            return JsonConvert.DeserializeObject<DscPrivateSettings>(s);
        }
    }
}
