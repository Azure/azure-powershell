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

using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Common.CustomAttributes.Test
{
    public class VerbNameHolder
    {
        public const string CmdletNameVerb = VerbsCommon.Get;
    }

    [CmdletDeprecation(ReplacementCmdletName = "Get-AzureRMTestCmdlet2")]
    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithCmdletDeprecationMarkerAttribute.CmdletName)]
    class AzureRMTestCmdletWithCmdletDeprecationMarkerAttribute : AzureRMCmdlet
    {
        public const string CmdletName = "CmdletA0";
    }

    [CmdletDeprecation("5.0.0.0", "12/03/2018")]
    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithCmdletDeprecationMarkerAttributeNoReplacement.CmdletName)]
    class AzureRMTestCmdletWithCmdletDeprecationMarkerAttributeNoReplacement : AzureRMCmdlet
    {
        public const string CmdletName = "CmdletA1";
    }

    [CmdletDeprecation(ReplacementCmdletName = AzureRMTestCmdletWithCmdletDeprecationMarkerAttributeAndDescription.ReplacementName,
        ChangeDescription = AzureRMTestCmdletWithCmdletDeprecationMarkerAttributeAndDescription.Description)]
    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithCmdletDeprecationMarkerAttributeAndDescription.CmdletName)]
    class AzureRMTestCmdletWithCmdletDeprecationMarkerAttributeAndDescription : AzureRMCmdlet
    {
        public const string CmdletName = "CmdletA2";
        public const string ReplacementName = "CmdletA21";
        public const string Description = "CmdletA2 is being replaced by CmdletA21";
    }

    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithCmdletWithOutputTypeDropped.CmdletName)]
    [OutputType(typeof(string))]
    [CmdletOutputBreakingChange(typeof(string))]
    class AzureRMTestCmdletWithCmdletWithOutputTypeDropped : AzureRMCmdlet
    {
        public const string CmdletName = "CmdletB0";
    }

    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithCmdletWithOutputTypeChange.CmdletName)]
    [OutputType(typeof(string))]
    [CmdletOutputBreakingChange(typeof(string), "5.0.0.0", ReplacementCmdletOutputTypeName ="List<string>")]
    class AzureRMTestCmdletWithCmdletWithOutputTypeChange : AzureRMCmdlet
    {
        public const string CmdletName = "CmdletB1";
    }

    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithCmdletWithOutputDeprecatedProperties.CmdletName)]
    [OutputType(typeof(Object))]
    [CmdletOutputBreakingChange(typeof(Object), DeprecatedOutputProperties = new string[] { "Prop1", "Prop2" })]
    class AzureRMTestCmdletWithCmdletWithOutputDeprecatedProperties : AzureRMCmdlet
    {
        public const string CmdletName = "CmdletB2";
    }

    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithCmdletWithOutputNewProperties.CmdletName)]
    [OutputType(typeof(Object))]
    [CmdletOutputBreakingChange(typeof(Object), NewOutputProperties = new string[] { "Prop1A", "Prop2A" })]
    class AzureRMTestCmdletWithCmdletWithOutputNewProperties : AzureRMCmdlet
    {
        public const string CmdletName = "CmdletB3";
    }

    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithDeprecatedParam.CmdletName)]
    class AzureRMTestCmdletWithDeprecatedParam
    {
        public const string CmdletName = "CmdletC1";
        public const string ChangeDesc = "Parameter is being deprecated without being replaced";
        //This deprecation marker should not have the OldWay=x New way=y printed as New way is not specified
        [CmdletParameterBreakingChange("Param1", ChangeDescription = ChangeDesc)]
        [Parameter(Mandatory = false)]
        public string Param1;
    }

    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithParamTypeChange.CmdletName)]
    class AzureRMTestCmdletWithParamTypeChange
    {
        public const string CmdletName = "CmdletC1A";
        //This deprecation marker should not have the OldWay=x New way=y printed as New way is not specified
        [CmdletParameterBreakingChange("Param1", OldParamaterType = typeof(string), NewParameterTypeName = "List<string>")]
        [Parameter(Mandatory = false)]
        public string Param1;
    }

    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithReplacedParam.CmdletName)]
    class AzureRMTestCmdletWithReplacedParam
    {
        public const string CmdletName = "CmdletC2";
        //This deprecation marker should not have the OldWay=x New way=y printed as New way is not specified
        [CmdletParameterBreakingChange("Param1", ReplaceMentCmdletParameterName ="Param1Replace")]
        [Parameter(Mandatory = false)]
        public string Param1;
    }

    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithReplacedMandatoryParam.CmdletName)]
    class AzureRMTestCmdletWithReplacedMandatoryParam
    {
        public const string CmdletName = "CmdletC3";
        //This deprecation marker should not have the OldWay=x New way=y printed as New way is not specified
        [CmdletParameterBreakingChange("Param1", ReplaceMentCmdletParameterName = "Param1Replace", IsBecomingMandatory = true)]
        [Parameter(Mandatory = false)]
        public string Param1;
    }

    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithParameterBecomingMandatory.CmdletName)]
    class AzureRMTestCmdletWithParameterBecomingMandatory
    {
        public const string CmdletName = "CmdletC4";
        [Parameter(Mandatory = true)]
        public string Param1;
        //this deprecation marker should print the old way and new way of calling the cmdlet.
        [CmdletParameterBreakingChange("Param2", IsBecomingMandatory = true, OldWay = "Get-AzureRMTestCmdlet2 -Param1=\"blah\"", NewWay = "Get-AzureRMTestCmdlet2 -Param1=\"blah\" -Param2=\"Yo Yo\"")]
        [Parameter(Mandatory = false)]
        public string Param2;
    }

    //Multiple attributes test where one attrib is on the class the other on a property
    [GenericBreakingChange(AzureRMTestCmdletWithParameterMetadataChangeAndAGenericChange.GenericChangeDesc, "5.0.0.0")]
    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithParameterMetadataChangeAndAGenericChange.CmdletName)]
    class AzureRMTestCmdletWithParameterMetadataChangeAndAGenericChange
    {
        public const string GenericChangeDesc = "Random change description";
        public const string ParamChangeDesc = "The type is changing from List<string> to HashSet<string>";
        public const string CmdletName = "CmdletD";
        [Parameter(Mandatory = true)]
        public string Param1;
        [CmdletParameterBreakingChange("ParamX", ChangeDescription = ParamChangeDesc)]
        [Parameter(Mandatory = false)]
        public List<string> ParamX;
    }
}
