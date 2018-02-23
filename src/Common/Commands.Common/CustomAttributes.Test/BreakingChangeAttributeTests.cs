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
        public void testForCmdletDeprecationAttribute()
        {
            List<BreakingChangeBaseAttribute> attribs = BreakingChangeAttributeHelper.getAllBreakingChangeAttributesInType(typeof(AzureRMTestCmdletWithCmdletDeprecationMarkerAttribute));

            Assert.Equal(1, attribs.Count);
            Assert.False(attribs[0].ChangeInEfectByDateSet);
            Assert.False(attribs[0].DeprecateByVersionSet);

            String pat = @"(The cmdlet ')(.*)(' is replacing the cmdlet ')(.)*";
            Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            List<String> messages = BreakingChangeAttributeHelper.getBreakingChangeMessagesForType(typeof(AzureRMTestCmdletWithCmdletDeprecationMarkerAttribute));
            Assert.Equal(1, messages.Count);
            Assert.True(reg.IsMatch(messages[0]));
            Assert.False(messages[0].Contains("This change will take effect on '"));
            Assert.False(messages[0].Contains("The change is expected to take effect from the version"));
            Assert.False(messages[0].Contains("powershell\n# Old"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void testForCmdletDeprecationAttributeNoReplacement()
        {
            List<BreakingChangeBaseAttribute> attribs = BreakingChangeAttributeHelper.getAllBreakingChangeAttributesInType(typeof(AzureRMTestCmdletWithCmdletDeprecationMarkerAttributeNoReplacement));

            Assert.Equal(1, attribs.Count);
            Assert.False(attribs[0].ChangeInEfectByDateSet);
            Assert.False(attribs[0].DeprecateByVersionSet);

            String pat = @"(The cmdlet ')(.*)(' is being deprecated. There will be no replacement for it.)";
            Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            List<String> messages = BreakingChangeAttributeHelper.getBreakingChangeMessagesForType(typeof(AzureRMTestCmdletWithCmdletDeprecationMarkerAttributeNoReplacement));
            Assert.Equal(1, messages.Count);
            Assert.True(reg.IsMatch(messages[0]));
            Assert.False(messages[0].Contains("This change will take effect on '"));
            Assert.False(messages[0].Contains("The change is expected to take effect from the version"));
            Assert.False(messages[0].Contains("powershell\n# Old"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void testForCmdletOutputTypeDeprecation()
        {
            List<BreakingChangeBaseAttribute> attribs = BreakingChangeAttributeHelper.getAllBreakingChangeAttributesInType(typeof(AzureRMTestCmdletWithCmdletWithOutputTypeChange));

            Assert.Equal(1, attribs.Count);
            Assert.False(attribs[0].ChangeInEfectByDateSet);
            Assert.False(attribs[0].DeprecateByVersionSet);

            String pat = @"(The cmdlet ')(.*)('s output type is changing from : ')(.*)(' to ')(.)*";
            Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            List<String> messages = BreakingChangeAttributeHelper.getBreakingChangeMessagesForType(typeof(AzureRMTestCmdletWithCmdletWithOutputTypeChange));
            Assert.Equal(1, messages.Count);
            Assert.True(reg.IsMatch(messages[0]));
            Assert.False(messages[0].Contains("This change will take effect on '"));
            Assert.False(messages[0].Contains("The change is expected to take effect from the version"));
            Assert.False(messages[0].Contains("powershell\n# Old"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void testForCmdletMetadataChange()
        {
            List<BreakingChangeBaseAttribute> attribs = BreakingChangeAttributeHelper.getAllBreakingChangeAttributesInType(typeof(AzureRMTestCmdletWithMetadataChangeAttribute));

            Assert.Equal(1, attribs.Count);
            Assert.False(attribs[0].ChangeInEfectByDateSet);
            Assert.True(attribs[0].DeprecateByVersionSet);

            String pat = @"(The cmdlet ')(.*)(' has the following change to the metadata ').*";
            Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            List<String> messages = BreakingChangeAttributeHelper.getBreakingChangeMessagesForType(typeof(AzureRMTestCmdletWithMetadataChangeAttribute));
            Assert.Equal(1, messages.Count);
            Assert.True(reg.IsMatch(messages[0]));
            Assert.False(messages[0].Contains("This change will take effect on '"));
            Assert.True(messages[0].Contains("The change is expected to take effect from the version"));
            Assert.False(messages[0].Contains("powershell\n# Old"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void testForCmdletWithOutputTypePropertyChanges()
        {
            List<BreakingChangeBaseAttribute> attribs = BreakingChangeAttributeHelper.getAllBreakingChangeAttributesInType(typeof(AzureRMTEstCmdletWithOutputPropertyChanges));
            Assert.Equal(1, attribs.Count);
            Assert.True(attribs[0].ChangeInEfectByDateSet);
            Assert.True(attribs[0].DeprecateByVersionSet);

            String pat = @"(The following properties in the output type ')(.*)(' in the cmdlet ')(.*)(' are changing :).*";
            Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            List<String> messages = BreakingChangeAttributeHelper.getBreakingChangeMessagesForType(typeof(AzureRMTEstCmdletWithOutputPropertyChanges));
            Assert.Equal(1, messages.Count);
            Assert.True(reg.IsMatch(messages[0]));
            Assert.True(messages[0].Contains("This change will take effect on '"));
            Assert.True(messages[0].Contains("The change is expected to take effect from the version"));
            Assert.False(messages[0].Contains("powershell\n# Old"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void testForCmdletWithParamDeprecated()
        {
            List<BreakingChangeBaseAttribute> attribs = BreakingChangeAttributeHelper.getAllBreakingChangeAttributesInType(typeof(AzureRMTestCmdletWithDeprecatedParam));
            Assert.Equal(1, attribs.Count);
            Assert.False(attribs[0].ChangeInEfectByDateSet);
            Assert.False(attribs[0].DeprecateByVersionSet);

            String pat = @"(The parameter ')(.*)(' is replacing ')(.*)(' in cmdlet ').*";
            Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            List<String> messages = BreakingChangeAttributeHelper.getBreakingChangeMessagesForType(typeof(AzureRMTestCmdletWithDeprecatedParam));
            Assert.Equal(1, messages.Count);
            Assert.True(reg.IsMatch(messages[0]));
            Assert.False(messages[0].Contains("This change will take effect on '"));
            Assert.False(messages[0].Contains("The change is expected to take effect from the version"));
            Assert.False(messages[0].Contains("powershell\n# Old"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void testForCmdletWithParamBecomesMandatory()
        {
            List<BreakingChangeBaseAttribute> attribs = BreakingChangeAttributeHelper.getAllBreakingChangeAttributesInType(typeof(AzureRMTestCmdletWithParameterBecomingMandatory));
            Assert.Equal(1, attribs.Count);
            Assert.False(attribs[0].ChangeInEfectByDateSet);
            Assert.False(attribs[0].DeprecateByVersionSet);

            String pat = @"(The parameter ')(.*)(' in cmdlet ')(.*)(' became mandatory now).*";
            Regex reg = new Regex(pat, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            List<String> messages = BreakingChangeAttributeHelper.getBreakingChangeMessagesForType(typeof(AzureRMTestCmdletWithParameterBecomingMandatory));
            Assert.Equal(1, messages.Count);
            Assert.True(reg.IsMatch(messages[0]));
            Assert.False(messages[0].Contains("This change will take effect on '"));
            Assert.False(messages[0].Contains("The change is expected to take effect from the version"));
            Assert.True(messages[0].Contains("powershell\n# Old"));
        }

        //Multi attribute test where one attrib is on the class and the other on a property
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void testAzureRMTestCmdletWithParameterMetadataChangeAndOrderChange()
        {
            List<BreakingChangeBaseAttribute> attribs = BreakingChangeAttributeHelper.getAllBreakingChangeAttributesInType(typeof(AzureRMTestCmdletWithParameterMetadataChangeAndOrderChange));
            Assert.Equal(2, attribs.Count);

            //This gets in the weeds here a lil too much, we get two different types of attributes, we will try and cast one to each type and then check if
            //the messages look good on each
            CmdLetParameterOrderChangeAttribute orderAttrib = null;
            CmdletParameterMetadataChangeMarkerAttribute paramMetaAttrib = null;

            try
            {
                orderAttrib = (CmdLetParameterOrderChangeAttribute)attribs[0];
            } catch (InvalidCastException)
            {
                try
                {
                    orderAttrib = (CmdLetParameterOrderChangeAttribute)attribs[1];
                } catch (InvalidCastException)
                {
                    //this is an exception that should not happen, one of these should be of the type we are tryin to get
                    Assert.False(true);
                }
            }

            try
            {
                paramMetaAttrib = (CmdletParameterMetadataChangeMarkerAttribute)attribs[0];
            }
            catch (InvalidCastException)
            {
                try
                {
                    paramMetaAttrib = (CmdletParameterMetadataChangeMarkerAttribute)attribs[1];
                }
                catch (InvalidCastException)
                {
                    //this is an exception that should not happen, one of these should be of the type we are tryin to get
                    Assert.False(true);
                }
            }

            Assert.NotNull(orderAttrib);
            Assert.NotNull(paramMetaAttrib);

            String pat1 = @"(The parameter ')(.*)(' in cmdlet ')(.*)(' has the following change to the metadata ')";
            Regex reg1 = new Regex(pat1, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            String pat2 = @"(The position of the following positional parameters has changed in the cmdlet '(.*)(' From :))";
            Regex reg2 = new Regex(pat2, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            List<String> messages = BreakingChangeAttributeHelper.getBreakingChangeMessagesForType(typeof(AzureRMTestCmdletWithParameterMetadataChangeAndOrderChange));
            Assert.Equal(2, messages.Count);

            //We need to check if the patterns we are looking for are both present in messages
            Assert.True((reg1.IsMatch(messages[0]) || reg1.IsMatch(messages[1])) && (reg2.IsMatch(messages[0]) || reg2.IsMatch(messages[1])));

            //The below check confirms that the pattterns exist in different messages 
            Assert.False(reg1.IsMatch(messages[0]) && reg1.IsMatch(messages[1]));
            Assert.False(reg2.IsMatch(messages[0]) && reg2.IsMatch(messages[1]));

            Assert.False(messages[0].Contains("This change will take effect on '"));
            Assert.False(messages[0].Contains("The change is expected to take effect from the version"));
            Assert.False(messages[0].Contains("powershell\n# Old"));

            Assert.False(messages[1].Contains("This change will take effect on '"));
            Assert.False(messages[1].Contains("The change is expected to take effect from the version"));
            Assert.False(messages[1].Contains("powershell\n# Old"));
        }

        //Multi attribute test where both the attributes are on the property
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void testAzureRMTestCmdletWithParamTypeChangeAndMandatoryChange()
        {
            List<BreakingChangeBaseAttribute> attribs = BreakingChangeAttributeHelper.getAllBreakingChangeAttributesInType(typeof(AzureRMTestCmdletWithParamTypeChangeAndMandatoryChange));
            Assert.Equal(2, attribs.Count);

            //This gets in the weeds here a lil too much, we get two different types of attributes, we will try and cast one to each type and then check if
            //the messages look good on each
            CmdletParameterTypeChangeMarkerAttribute paramTypeChangeAttrib = null;
            CmdletParameterMandatoryStatusChangeAttribute paramMandatoryStatusChange = null;

            try
            {
                paramTypeChangeAttrib = (CmdletParameterTypeChangeMarkerAttribute)attribs[0];
            }
            catch (InvalidCastException)
            {
                try
                {
                    paramTypeChangeAttrib = (CmdletParameterTypeChangeMarkerAttribute)attribs[1];
                }
                catch (InvalidCastException)
                {
                    //this is an exception that should not happen, one of these should be of the type we are tryin to get
                    Assert.False(true);
                }
            }

            try
            {
                paramMandatoryStatusChange = (CmdletParameterMandatoryStatusChangeAttribute)attribs[0];
            }
            catch (InvalidCastException)
            {
                try
                {
                    paramMandatoryStatusChange = (CmdletParameterMandatoryStatusChangeAttribute)attribs[1];
                }
                catch (InvalidCastException)
                {
                    //this is an exception that should not happen, one of these should be of the type we are tryin to get
                    Assert.False(true);
                }
            }

            Assert.NotNull(paramTypeChangeAttrib);
            Assert.NotNull(paramMandatoryStatusChange);

            String pat1 = @"(The parameter )(.*)('s type is changing from ')(.*)(' to ')(.*)(' in cmdlet ')";
            Regex reg1 = new Regex(pat1, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            String pat2 = @"(The parameter ')(.*)(' in cmdlet ')(.*)(' became mandatory now).*";
            Regex reg2 = new Regex(pat2, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            List<String> messages = BreakingChangeAttributeHelper.getBreakingChangeMessagesForType(typeof(AzureRMTestCmdletWithParamTypeChangeAndMandatoryChange));
            Assert.Equal(2, messages.Count);

            //We need to check if the patterns we are looking for are both present in messages
            Assert.True((reg1.IsMatch(messages[0]) || reg1.IsMatch(messages[1])) && (reg2.IsMatch(messages[0]) || reg2.IsMatch(messages[1])));

            //The below check confirms that the pattterns exist in different messages 
            Assert.False(reg1.IsMatch(messages[0]) && reg1.IsMatch(messages[1]));
            Assert.False(reg2.IsMatch(messages[0]) && reg2.IsMatch(messages[1]));

            foreach (String message in messages)
            {
                bool expected = false;
                //only the mandatory status change attrib had the version and date specified, check for that
                if (reg2.IsMatch(message)) {
                    expected = true;
                }

                Assert.Equal(expected, message.Contains("This change will take effect on '"));
                Assert.Equal(expected, message.Contains("The change is expected to take effect from the version"));

                //this should be false for both
                Assert.False(message.Contains("powershell\n# Old"));
            }
        }
    }
}
