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
        public const String CmdletNameVerb = VerbsCommon.Get;
    }

    [CmdletDeprecationMarker(ReplacementCmdletName = "Get-AzureRMTestCmdlet2")]
    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithCmdletDeprecationMarkerAttribute.CmdletName)]
    class AzureRMTestCmdletWithCmdletDeprecationMarkerAttribute : AzureRMCmdlet
    {
        public const String CmdletName = "CmdletA0";
    }

    [CmdletDeprecationMarker("5.0.0.0", "12/03/2018")]
    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithCmdletDeprecationMarkerAttributeNoReplacement.CmdletName)]
    class AzureRMTestCmdletWithCmdletDeprecationMarkerAttributeNoReplacement : AzureRMCmdlet
    {
        public const String CmdletName = "CmdletA1";
    }

    [CmdletDeprecationMarker(ReplacementCmdletName = AzureRMTestCmdletWithCmdletDeprecationMarkerAttributeAndDescription.ReplacementName,
        ChangeDescription = AzureRMTestCmdletWithCmdletDeprecationMarkerAttributeAndDescription.Description)]
    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithCmdletDeprecationMarkerAttributeAndDescription.CmdletName)]
    class AzureRMTestCmdletWithCmdletDeprecationMarkerAttributeAndDescription : AzureRMCmdlet
    {
        public const String CmdletName = "CmdletA2";
        public const String ReplacementName = "CmdletA21";
        public const String Description = "CmdletA2 is being replaced by CmdletA21";
    }

    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithCmdletWithOutputTypeChange.CmdletName)]
    [OutputType(typeof(String))]
    [CmdletOutputBreakingChangeMarker("String", "5.0.0.0", ReplacementCmdletOutputTypeName ="List<String>")]
    class AzureRMTestCmdletWithCmdletWithOutputTypeChange : AzureRMCmdlet
    {
        public const String CmdletName = "CmdletB1";
    }

    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithCmdletWithOutputDeprecatedProperties.CmdletName)]
    [OutputType(typeof(Object))]
    [CmdletOutputBreakingChangeMarker("Object", DeprecatedOutputProperties = new String[] { "Prop1", "Prop2" })]
    class AzureRMTestCmdletWithCmdletWithOutputDeprecatedProperties : AzureRMCmdlet
    {
        public const String CmdletName = "CmdletB2";
    }

    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithCmdletWithOutputNewProperties.CmdletName)]
    [OutputType(typeof(Object))]
    [CmdletOutputBreakingChangeMarker("Object", NewOutputProperties = new String[] { "Prop1A", "Prop2A" })]
    class AzureRMTestCmdletWithCmdletWithOutputNewProperties : AzureRMCmdlet
    {
        public const String CmdletName = "CmdletB3";
    }

    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithDeprecatedParam.CmdletName)]
    class AzureRMTestCmdletWithDeprecatedParam
    {
        public const String CmdletName = "CmdletC1";
        public const String ChangeDesc = "Parameter is being deprecated without being replaced";
        //This deprecation marker should not have the OldWay=x New way=y printed as New way is not specified
        [CmdletParameterBreakingChangeMarker("Param1", ChangeDescription = ChangeDesc)]
        [Parameter(Mandatory = false)]
        public String Param1;
    }

    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithReplacedParam.CmdletName)]
    class AzureRMTestCmdletWithReplacedParam
    {
        public const String CmdletName = "CmdletC2";
        //This deprecation marker should not have the OldWay=x New way=y printed as New way is not specified
        [CmdletParameterBreakingChangeMarker("Param1", ReplaceMentCmdletParameterName ="Param1Replace")]
        [Parameter(Mandatory = false)]
        public String Param1;
    }

    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithReplacedMandatoryParam.CmdletName)]
    class AzureRMTestCmdletWithReplacedMandatoryParam
    {
        public const String CmdletName = "CmdletC3";
        //This deprecation marker should not have the OldWay=x New way=y printed as New way is not specified
        [CmdletParameterBreakingChangeMarker("Param1", ReplaceMentCmdletParameterName = "Param1Replace", IsBecomingMandatory = true)]
        [Parameter(Mandatory = false)]
        public String Param1;
    }

    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithParameterBecomingMandatory.CmdletName)]
    class AzureRMTestCmdletWithParameterBecomingMandatory
    {
        public const String CmdletName = "CmdletC4";
        [Parameter(Mandatory = true)]
        public String Param1;
        //this deprecation marker should print the old way and new way of calling the cmdlet.
        [CmdletParameterBreakingChangeMarker("Param2", IsBecomingMandatory = true, OldWay = "Get-AzureRMTestCmdlet2 -Param1=\"blah\"", NewWay = "Get-AzureRMTestCmdlet2 -Param1=\"blah\" -Param2=\"Yo Yo\"")]
        [Parameter(Mandatory = false)]
        public String Param2;
    }

    //Multiple attributes test where one attrib is on the class the other on a property
    [GenericBreakingChange(AzureRMTestCmdletWithParameterMetadataChangeAndAGenericChange.GenericChangeDesc, "5.0.0.0")]
    [Cmdlet(VerbNameHolder.CmdletNameVerb, AzureRMTestCmdletWithParameterMetadataChangeAndAGenericChange.CmdletName)]
    class AzureRMTestCmdletWithParameterMetadataChangeAndAGenericChange
    {
        public const String GenericChangeDesc = "Random change description";
        public const String ParamChangeDesc = "The type is changing from List<String> to HashSet<String>";
        public const String CmdletName = "CmdletD";
        [Parameter(Mandatory = true)]
        public String Param1;
        [CmdletParameterBreakingChangeMarker("ParamX", ChangeDescription = ParamChangeDesc)]
        [Parameter(Mandatory = false)]
        public List<String> ParamX;
    }
}
