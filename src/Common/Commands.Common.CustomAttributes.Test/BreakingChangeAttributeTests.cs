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

using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Common.CustomAttributes.Test
{
    public class BreakingChangeAttributeTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestForCmdletDeprecationAttribute()
        {
            List<GenericBreakingChangeAttribute> attribs = new List<GenericBreakingChangeAttribute>(BreakingChangeAttributeHelper.GetAllBreakingChangeAttributesInType(typeof(AzureRMTestCmdletWithCmdletDeprecationMarkerAttribute), null));

            Assert.Equal(1, attribs.Count);
            Assert.False(attribs[0].ChangeInEfectByDateSet);
            Assert.False(attribs[0].DeprecateByVersionSet);

            string pat = @"(The cmdlet ')(.*)(' is replacing this cmdlet)";
            Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            List<string> messages = BreakingChangeAttributeHelper.GetBreakingChangeMessagesForType(typeof(AzureRMTestCmdletWithCmdletDeprecationMarkerAttribute));
            Assert.Equal(1, messages.Count);
            Assert.True(reg.IsMatch(messages[0]));
            Assert.True(messages[0].Contains(" - Cmdlet : '" + VerbNameHolder.CmdletNameVerb + "-" + AzureRMTestCmdletWithCmdletDeprecationMarkerAttribute.CmdletName));
            Assert.False(messages[0].Contains("This change will take effect on '"));
            Assert.False(messages[0].Contains("Change description : "));
            Assert.False(messages[0].Contains("The change is expected to take effect from the version"));
            Assert.False(messages[0].Contains("powershell\r\n# Old"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestForCmdletDeprecationAttributeNoReplacement()
        {
            List<GenericBreakingChangeAttribute> attribs = new List<GenericBreakingChangeAttribute>(BreakingChangeAttributeHelper.GetAllBreakingChangeAttributesInType(typeof(AzureRMTestCmdletWithCmdletDeprecationMarkerAttributeNoReplacement), null));

            Assert.Equal(1, attribs.Count);
            Assert.True(attribs[0].ChangeInEfectByDateSet);
            Assert.True(attribs[0].DeprecateByVersionSet);

            string pat = @"(The cmdlet is being deprecated. There will be no replacement for it.)";
            Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            List<string> messages = BreakingChangeAttributeHelper.GetBreakingChangeMessagesForType(typeof(AzureRMTestCmdletWithCmdletDeprecationMarkerAttributeNoReplacement));
            Assert.Equal(1, messages.Count);
            Assert.True(reg.IsMatch(messages[0]));
            Assert.True(messages[0].Contains(" - Cmdlet : '" + VerbNameHolder.CmdletNameVerb + "-" + AzureRMTestCmdletWithCmdletDeprecationMarkerAttributeNoReplacement.CmdletName));
            Assert.True(messages[0].Contains("This change will take effect on '"));
            Assert.False(messages[0].Contains("Change description : "));
            Assert.True(messages[0].Contains("The change is expected to take effect from the version"));
            Assert.False(messages[0].Contains("powershell\r\n# Old"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestForCmdletDeprecationAttributeWithDescription()
        {
            List<GenericBreakingChangeAttribute> attribs = new List<GenericBreakingChangeAttribute>(BreakingChangeAttributeHelper.GetAllBreakingChangeAttributesInType(typeof(AzureRMTestCmdletWithCmdletDeprecationMarkerAttributeAndDescription), null));

            Assert.Equal(1, attribs.Count);
            Assert.False(attribs[0].ChangeInEfectByDateSet);
            Assert.False(attribs[0].DeprecateByVersionSet);

            string pat = @"(The cmdlet ')(.*)(' is replacing this cmdlet)";
            Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            List<string> messages = BreakingChangeAttributeHelper.GetBreakingChangeMessagesForType(typeof(AzureRMTestCmdletWithCmdletDeprecationMarkerAttributeAndDescription));
            Assert.Equal(1, messages.Count);
            Assert.True(reg.IsMatch(messages[0]));
            Assert.True(messages[0].Contains(" - Cmdlet : '" + VerbNameHolder.CmdletNameVerb + "-" + AzureRMTestCmdletWithCmdletDeprecationMarkerAttributeAndDescription.CmdletName));
            Assert.False(messages[0].Contains("This change will take effect on '"));
            Assert.True(messages[0].Contains("Change description : " + AzureRMTestCmdletWithCmdletDeprecationMarkerAttributeAndDescription.Description));
            Assert.False(messages[0].Contains("The change is expected to take effect from the version"));
            Assert.False(messages[0].Contains("powershell\r\n# Old"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestForCmdletOutputTypeDropped()
        {
            List<GenericBreakingChangeAttribute> attribs = new List<GenericBreakingChangeAttribute>(BreakingChangeAttributeHelper.GetAllBreakingChangeAttributesInType(typeof(AzureRMTestCmdletWithCmdletWithOutputTypeDropped), null));

            Assert.Equal(1, attribs.Count);
            Assert.False(attribs[0].ChangeInEfectByDateSet);
            Assert.False(attribs[0].DeprecateByVersionSet);

            string pat = @"(The output type ')(.*)(' is being deprecated without a replacement.)";
            Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            List<string> messages = BreakingChangeAttributeHelper.GetBreakingChangeMessagesForType(typeof(AzureRMTestCmdletWithCmdletWithOutputTypeDropped));
            Assert.Equal(1, messages.Count);
            Assert.True(reg.IsMatch(messages[0]));
            Assert.True(messages[0].Contains(" - Cmdlet : '" + VerbNameHolder.CmdletNameVerb + "-" + AzureRMTestCmdletWithCmdletWithOutputTypeDropped.CmdletName));
            Assert.False(messages[0].Contains("This change will take effect on '"));
            Assert.False(messages[0].Contains("Change description : "));
            Assert.False(messages[0].Contains("The change is expected to take effect from the version"));
            Assert.False(messages[0].Contains("powershell\r\n# Old"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestForCmdletOutputTypeDeprecation()
        {
            List<GenericBreakingChangeAttribute> attribs = new List<GenericBreakingChangeAttribute>(BreakingChangeAttributeHelper.GetAllBreakingChangeAttributesInType(typeof(AzureRMTestCmdletWithCmdletWithOutputTypeChange), null));

            Assert.Equal(1, attribs.Count);
            Assert.False(attribs[0].ChangeInEfectByDateSet);
            Assert.True(attribs[0].DeprecateByVersionSet);

            string pat = @"(The output type is changing from the existing type :')(.*)(' to the new type :')(.*)(')";
            Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            List<string> messages = BreakingChangeAttributeHelper.GetBreakingChangeMessagesForType(typeof(AzureRMTestCmdletWithCmdletWithOutputTypeChange));
            Assert.Equal(1, messages.Count);
            Assert.True(reg.IsMatch(messages[0]));
            Assert.True(messages[0].Contains(" - Cmdlet : '" + VerbNameHolder.CmdletNameVerb + "-" + AzureRMTestCmdletWithCmdletWithOutputTypeChange.CmdletName));
            Assert.False(messages[0].Contains("This change will take effect on '"));
            Assert.False(messages[0].Contains("Change description : "));
            Assert.True(messages[0].Contains("The change is expected to take effect from the version"));
            Assert.False(messages[0].Contains("powershell\r\n# Old"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestForCmdletWithOutputTypeRemovedProperties()
        {
            List<GenericBreakingChangeAttribute> attribs = new List<GenericBreakingChangeAttribute>(BreakingChangeAttributeHelper.GetAllBreakingChangeAttributesInType(typeof(AzureRMTestCmdletWithCmdletWithOutputDeprecatedProperties), null));
            Assert.Equal(1, attribs.Count);
            Assert.False(attribs[0].ChangeInEfectByDateSet);
            Assert.False(attribs[0].DeprecateByVersionSet);

            string pat = @"(The output type ')(.*)(' is changing).*";
            Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            List<string> messages = BreakingChangeAttributeHelper.GetBreakingChangeMessagesForType(typeof(AzureRMTestCmdletWithCmdletWithOutputDeprecatedProperties));
            Assert.Equal(1, messages.Count);
            Assert.True(reg.IsMatch(messages[0]));
            Assert.True(messages[0].Contains(" - Cmdlet : '" + VerbNameHolder.CmdletNameVerb + "-" + AzureRMTestCmdletWithCmdletWithOutputDeprecatedProperties.CmdletName));
            Assert.True(messages[0].Contains("The following properties in the output type are being deprecated :"));
            Assert.False(messages[0].Contains("The following properties are being added to the output type :"));
            Assert.False(messages[0].Contains("This change will take effect on '"));
            Assert.False(messages[0].Contains("Change description : "));
            Assert.False(messages[0].Contains("The change is expected to take effect from the version"));
            Assert.False(messages[0].Contains("powershell\r\n# Old"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestForCmdletWithOutputTypeAddedProperties()
        {
            List<GenericBreakingChangeAttribute> attribs = new List<GenericBreakingChangeAttribute>(BreakingChangeAttributeHelper.GetAllBreakingChangeAttributesInType(typeof(AzureRMTestCmdletWithCmdletWithOutputNewProperties), null));
            Assert.Equal(1, attribs.Count);
            Assert.False(attribs[0].ChangeInEfectByDateSet);
            Assert.False(attribs[0].DeprecateByVersionSet);

            string pat = @"(The output type ')(.*)(' is changing).*";
            Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            List<string> messages = BreakingChangeAttributeHelper.GetBreakingChangeMessagesForType(typeof(AzureRMTestCmdletWithCmdletWithOutputNewProperties));
            Assert.Equal(1, messages.Count);
            Assert.True(messages[0].Contains(" - Cmdlet : '" + VerbNameHolder.CmdletNameVerb + "-" + AzureRMTestCmdletWithCmdletWithOutputNewProperties.CmdletName));
            Assert.True(reg.IsMatch(messages[0]));
            Assert.True(messages[0].Contains("The following properties are being added to the output type :"));
            Assert.False(messages[0].Contains("The following properties in the output type are being deprecated :"));
            Assert.False(messages[0].Contains("This change will take effect on '"));
            Assert.False(messages[0].Contains("Change description : "));
            Assert.False(messages[0].Contains("The change is expected to take effect from the version"));
            Assert.False(messages[0].Contains("powershell\r\n# Old"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestForCmdletWithParamDeprecatedNoReplacement()
        {
            List<GenericBreakingChangeAttribute> attribs = new List<GenericBreakingChangeAttribute>(BreakingChangeAttributeHelper.GetAllBreakingChangeAttributesInType(typeof(AzureRMTestCmdletWithDeprecatedParam), null));
            Assert.Equal(1, attribs.Count);
            Assert.False(attribs[0].ChangeInEfectByDateSet);
            Assert.False(attribs[0].DeprecateByVersionSet);

            string pat = @"(The parameter : ')(.*)(' is changing)";
            Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            List<string> messages = BreakingChangeAttributeHelper.GetBreakingChangeMessagesForType(typeof(AzureRMTestCmdletWithDeprecatedParam));
            Assert.Equal(1, messages.Count);
            Assert.True(reg.IsMatch(messages[0]));
            Assert.True(messages[0].Contains(" - Cmdlet : '" + VerbNameHolder.CmdletNameVerb + "-" + AzureRMTestCmdletWithDeprecatedParam.CmdletName));
            Assert.False(messages[0].Contains("This change will take effect on '"));
            Assert.False(messages[0].Contains("The change is expected to take effect from the version"));
            Assert.False(messages[0].Contains("powershell\r\n# Old"));
            Assert.True(messages[0].Contains("Change description : " + AzureRMTestCmdletWithDeprecatedParam.ChangeDesc));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestForCmdletWithParamTypeChange()
        {
            List<GenericBreakingChangeAttribute> attribs = new List<GenericBreakingChangeAttribute>(BreakingChangeAttributeHelper.GetAllBreakingChangeAttributesInType(typeof(AzureRMTestCmdletWithParamTypeChange), null));
            Assert.Equal(1, attribs.Count);
            Assert.False(attribs[0].ChangeInEfectByDateSet);
            Assert.False(attribs[0].DeprecateByVersionSet);

            string pat = @"(The parameter : ')(.*)(' is changing)";
            string pat1 = @"(The type of the parameter is changing from ')(.*)(' to ')(.*)('.)";
            Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Regex reg1 = new Regex(pat1, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            List<string> messages = BreakingChangeAttributeHelper.GetBreakingChangeMessagesForType(typeof(AzureRMTestCmdletWithParamTypeChange));
            Assert.Equal(1, messages.Count);
            Assert.True(reg.IsMatch(messages[0]));
            Assert.True(reg1.IsMatch(messages[0]));
            Assert.True(messages[0].Contains(" - Cmdlet : '" + VerbNameHolder.CmdletNameVerb + "-" + AzureRMTestCmdletWithParamTypeChange.CmdletName));
            Assert.False(messages[0].Contains("This change will take effect on '"));
            Assert.False(messages[0].Contains("The change is expected to take effect from the version"));
            Assert.False(messages[0].Contains("powershell\r\n# Old"));
            Assert.False(messages[0].Contains("Change description : "));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestForCmdletWithParamDeprecatedWithReplacement()
        {
            List<GenericBreakingChangeAttribute> attribs = new List<GenericBreakingChangeAttribute>(BreakingChangeAttributeHelper.GetAllBreakingChangeAttributesInType(typeof(AzureRMTestCmdletWithReplacedParam), null));
            Assert.Equal(1, attribs.Count);
            Assert.False(attribs[0].ChangeInEfectByDateSet);
            Assert.False(attribs[0].DeprecateByVersionSet);

            string pat = @"(The parameter : ')(.*)(' is being replaced by parameter : ')(.*)(')";
            Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            List<string> messages = BreakingChangeAttributeHelper.GetBreakingChangeMessagesForType(typeof(AzureRMTestCmdletWithReplacedParam));
            Assert.Equal(1, messages.Count);
            Assert.True(messages[0].Contains(" - Cmdlet : '" + VerbNameHolder.CmdletNameVerb + "-" + AzureRMTestCmdletWithReplacedParam.CmdletName));
            Assert.True(reg.IsMatch(messages[0]));
            Assert.False(messages[0].Contains("This change will take effect on '"));
            Assert.False(messages[0].Contains("The change is expected to take effect from the version"));
            Assert.False(messages[0].Contains("powershell\r\n# Old"));
            Assert.False(messages[0].Contains("Change description : "));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestForCmdletWithParamDeprecatedWithMandatoryReplacement()
        {
            List<GenericBreakingChangeAttribute> attribs = new List<GenericBreakingChangeAttribute>(BreakingChangeAttributeHelper.GetAllBreakingChangeAttributesInType(typeof(AzureRMTestCmdletWithReplacedMandatoryParam), null));
            Assert.Equal(1, attribs.Count);
            Assert.False(attribs[0].ChangeInEfectByDateSet);
            Assert.False(attribs[0].DeprecateByVersionSet);

            string pat = @"(The parameter : ')(.*)(' is being replaced by mandatory parameter : ')(.*)(')";
            Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            List<string> messages = BreakingChangeAttributeHelper.GetBreakingChangeMessagesForType(typeof(AzureRMTestCmdletWithReplacedMandatoryParam));
            Assert.Equal(1, messages.Count);
            Assert.True(messages[0].Contains(" - Cmdlet : '" + VerbNameHolder.CmdletNameVerb + "-" + AzureRMTestCmdletWithReplacedMandatoryParam.CmdletName));
            Assert.True(reg.IsMatch(messages[0]));
            Assert.False(messages[0].Contains("This change will take effect on '"));
            Assert.False(messages[0].Contains("The change is expected to take effect from the version"));
            Assert.False(messages[0].Contains("powershell\r\n# Old"));
            Assert.False(messages[0].Contains("Change description : "));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestForCmdletWithParamBecomingMandatory()
        {
            List<GenericBreakingChangeAttribute> attribs = new List<GenericBreakingChangeAttribute>(BreakingChangeAttributeHelper.GetAllBreakingChangeAttributesInType(typeof(AzureRMTestCmdletWithParameterBecomingMandatory), null));
            Assert.Equal(1, attribs.Count);
            Assert.False(attribs[0].ChangeInEfectByDateSet);
            Assert.False(attribs[0].DeprecateByVersionSet);

            string pat = @"(The parameter : ')(.*)(' is becoming mandatory)";
            Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            List<string> messages = BreakingChangeAttributeHelper.GetBreakingChangeMessagesForType(typeof(AzureRMTestCmdletWithParameterBecomingMandatory));
            Assert.Equal(1, messages.Count);
            Assert.True(messages[0].Contains(" - Cmdlet : '" + VerbNameHolder.CmdletNameVerb + "-" + AzureRMTestCmdletWithParameterBecomingMandatory.CmdletName));
            Assert.True(reg.IsMatch(messages[0]));
            Assert.False(messages[0].Contains("This change will take effect on '"));
            Assert.False(messages[0].Contains("The change is expected to take effect from the version"));
            Assert.True(messages[0].Contains("powershell\r\n# Old"));
            Assert.False(messages[0].Contains("Change description : "));
        }

        //Multi attribute test where one attrib is on the class and the other on a property
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureRMTestCmdletWithParameterMetadataChangeAndOrderChange()
        {
            List<GenericBreakingChangeAttribute> attribs = new List<GenericBreakingChangeAttribute>(BreakingChangeAttributeHelper.GetAllBreakingChangeAttributesInType(typeof(AzureRMTestCmdletWithParameterMetadataChangeAndAGenericChange), null));
            Assert.Equal(2, attribs.Count);

            //This gets in the weeds here a lil too much, we get two different types of attributes, we will try and cast one to each type and then check if
            //the messages look good on each
            GenericBreakingChangeAttribute genericAttrib = null;
            CmdletParameterBreakingChangeAttribute paramMetaAttrib = null;

            try
            {
                genericAttrib = (GenericBreakingChangeAttribute)attribs[0];
            } catch (InvalidCastException)
            {
                try
                {
                    genericAttrib = (GenericBreakingChangeAttribute)attribs[1];
                } catch (InvalidCastException)
                {
                    //this is an exception that should not happen, one of these should be of the type we are tryin to get
                    Assert.False(true);
                }
            }

            try
            {
                paramMetaAttrib = (CmdletParameterBreakingChangeAttribute)attribs[0];
            }
            catch (InvalidCastException)
            {
                try
                {
                    paramMetaAttrib = (CmdletParameterBreakingChangeAttribute)attribs[1];
                }
                catch (InvalidCastException)
                {
                    //this is an exception that should not happen, one of these should be of the type we are tryin to get
                    Assert.False(true);
                }
            }

            Assert.NotNull(genericAttrib);
            Assert.NotNull(paramMetaAttrib);

            string pat1 = @"(" + AzureRMTestCmdletWithParameterMetadataChangeAndAGenericChange.GenericChangeDesc + ")";
            Regex reg1 = new Regex(pat1, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            string pat2 = @"(The parameter : ')(.*)(' is changing')";
            Regex reg2 = new Regex(pat2, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            List<string> messages = BreakingChangeAttributeHelper.GetBreakingChangeMessagesForType(typeof(AzureRMTestCmdletWithParameterMetadataChangeAndAGenericChange));
            Assert.Equal(2, messages.Count);

            string genericMessage = null;
            string paramMessage = null;

            if (reg1.IsMatch(messages[0]))
            {
                genericMessage = messages[0];
                paramMessage = messages[1];
            } else
            {
                genericMessage = messages[1];
                paramMessage = messages[0];
            }

            Assert.NotNull(genericMessage);
            Assert.NotNull(paramMessage);

            //The below check confirms that the pattterns exist in different messages 
            Assert.False(reg1.IsMatch(paramMessage));
            Assert.False(reg2.IsMatch(genericMessage));

            Assert.False(genericMessage.Contains("This change will take effect on '"));
            Assert.True(genericMessage.Contains("The change is expected to take effect from the version"));
            Assert.False(genericMessage.Contains("powershell\r\n# Old"));
            Assert.True(genericMessage.Contains(" - Cmdlet : '" + VerbNameHolder.CmdletNameVerb + "-" + AzureRMTestCmdletWithParameterMetadataChangeAndAGenericChange.CmdletName));
            Assert.False(genericMessage.Contains("Change description : "));

            Assert.False(paramMessage.Contains("This change will take effect on '"));
            Assert.True(paramMessage.Contains(" - Cmdlet : '" + VerbNameHolder.CmdletNameVerb + "-" + AzureRMTestCmdletWithParameterMetadataChangeAndAGenericChange.CmdletName));
            Assert.False(paramMessage.Contains("The change is expected to take effect from the version"));
            Assert.False(paramMessage.Contains("powershell\r\n# Old"));
            Assert.True(paramMessage.Contains("Change description : " + AzureRMTestCmdletWithParameterMetadataChangeAndAGenericChange.ParamChangeDesc));
        }

    }
}
