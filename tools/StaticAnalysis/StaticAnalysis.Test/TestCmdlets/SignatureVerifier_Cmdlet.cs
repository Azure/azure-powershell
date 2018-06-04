//---------------------------------------------------------------------------------------------------------
// This class can be used to create test cmdLets that can be used as test cases for StaticAnalyzer
// Add cmdlets to this file, which will be compiled into TestCmdletsModule.dll
// These test will then pass the path to the dll to the static analysis tool .exe
//---------------------------------------------------------------------------------------------------------

#region Verb Cmdlets and SupportsShouldProcess
namespace StaticAnalysis.Test.CmdletTest.Signature.AddVerbWithoutSupportsShouldProcessParameter
{
    using System.Management.Automation;

    /// <summary>
    /// Check if a cmdlet that has Verbs that require ShouldProcess has ShouldProcess parameter
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AddVerbWithoutSupportsShouldProcessParameter")]
    [OutputType(typeof(bool))]
    public class AddVerbWithoutSupportsShouldProcessParameter : Cmdlet
    {
        /// <summary>
        ///
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///
        /// </summary>
        protected override void BeginProcessing()
        {
            WriteObject("TestCmdLet BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.Signature.AddVerbWithSupportsShouldProcessParameter
{
    using System.Management.Automation;

    /// <summary>
    /// Check if a cmdlet that has Verbs that require ShouldProcess has ShouldProcess parameter
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AddVerbWithSupportsShouldProcessParameter", SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class AddVerbWithSupportsShouldProcessParameter : Cmdlet
    {
        /// <summary>
        ///
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///
        /// </summary>
        protected override void BeginProcessing()
        {
            WriteObject("TestCmdLet BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}
#endregion

#region ForceSwitch and SupportsShouldProcess
namespace StaticAnalysis.Test.CmdletTest.Signature.ForceParameterWithoutSupportsShouldProcess
{
    using System.Management.Automation;

    /// <summary>
    /// Verify if cmdlet that has Force parameter should also define SupportsShouldProcess parameter
    /// </summary>
    [Cmdlet(VerbsDiagnostic.Test, "ForceParameterWithoutSupportsShouldProcess")]
    [OutputType(typeof(bool))]
    public class ForceParameterWithoutSupportsShouldProcess : Cmdlet
    {
        /// <summary>
        ///
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Parameter(Position = 1, Mandatory = false, HelpMessage = "Confirm deletion of vault")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        ///
        /// </summary>
        protected override void BeginProcessing()
        {
            WriteObject("TestCmdLet BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.Signature.ForceParameterWithSupportsShouldProcess
{
    using System.Management.Automation;

    /// <summary>
    /// Verify if cmdlet that has Force parameter should also define SupportsShouldProcess parameter
    /// </summary>
    [Cmdlet(VerbsDiagnostic.Test, "ForceParameterWithSupportsShouldProcess", SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class ForceParameterWithSupportsShouldProcess : Cmdlet
    {
        /// <summary>
        ///
        /// </summary>
        [Parameter(Position = 1, HelpMessage = "Confirm deletion of vault")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        ///
        /// </summary>
        protected override void BeginProcessing()
        {
            WriteObject("TestCmdLet BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}
#endregion

#region ConfirmImpact and SupportsShouldProcess
namespace StaticAnalysis.Test.CmdletTest.Signature.ConfirmImpactWithoutSupportsShouldProcess
{
    using System.Management.Automation;

    /// <summary>
    /// Verify if cmdlet that has Force parameter should also define SupportsShouldProcess parameter
    /// </summary>
    [Cmdlet(VerbsDiagnostic.Test, "ConfirmImpactWithoutSupportsShouldProcess", ConfirmImpact = ConfirmImpact.High)]
    [OutputType(typeof(bool))]
    public class ConfirmImpactWithoutSupportsShouldProcess : Cmdlet
    {
        /// <summary>
        ///
        /// </summary>
        protected override void BeginProcessing()
        {
            WriteObject("TestCmdLet BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.Signature.ConfirmImpactWithSupportsShouldProcess
{
    using System.Management.Automation;

    /// <summary>
    /// Verify if cmdlet that has Force parameter should also define SupportsShouldProcess parameter
    /// </summary>
    [Cmdlet(VerbsDiagnostic.Test, "ConfirmImpactWithSupportsShouldProcess", ConfirmImpact = ConfirmImpact.Medium, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class ConfirmImpactWithSupportsShouldProcess : Cmdlet
    {
        /// <summary>
        ///
        /// </summary>
        [Parameter(Position = 1, HelpMessage = "Confirm deletion of vault")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        ///
        /// </summary>
        protected override void BeginProcessing()
        {
            WriteObject("TestCmdLet BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}
#endregion

#region IsShouldContinueVerb and ForceSwitch
namespace StaticAnalysis.Test.CmdletTest.Signature.ShouldContinueVerbWithForceSwitch
{
    using System.Management.Automation;

    /// <summary>
    /// Verify if cmdlet that has Force parameter should also define SupportsShouldProcess parameter
    /// </summary>
    [Cmdlet(VerbsCommon.Copy, "ShouldContinueVerbWithForceSwitch", SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class ShouldContinueVerbWithForceSwitch : Cmdlet
    {
        /// <summary>
        ///
        /// </summary>
        [Parameter(Position = 1, Mandatory = false, HelpMessage = "Confirm deletion of vault")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        ///
        /// </summary>
        protected override void BeginProcessing()
        {
            WriteObject("TestCmdLet BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}
#endregion

#region CmdletWithUnapprovedVerb
namespace StaticAnalysis.Test.CmdletTest.Signature.CmdletWithApprovedVerb
{
    using System.Management.Automation;

    /// <summary>
    /// Verify if a cmdlet has an approved verb in its name.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SampleCmdlet")]
    [OutputType(typeof(bool))]
    public class CmdletWithApprovedVerb : Cmdlet
    {
        /// <summary>
        /// Begin processing the cmdlet.
        /// </summary>
        protected override void BeginProcessing()
        {
            WriteObject("Get-SampleCmdlet BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.Signature.CmdletWithUnapprovedVerb
{
    using System.Management.Automation;

    /// <summary>
    /// Verify if a cmdlet has an approved verb in its name.
    /// </summary>
    [Cmdlet("Prepare", "SampleCmdlet")]
    [OutputType(typeof(bool))]
    public class CmdletWithUnapprovedVerb : Cmdlet
    {
        /// <summary>
        /// Begin processing the cmdlet.
        /// </summary>
        protected override void BeginProcessing()
        {
            WriteObject("Prepare-SampleCmdlet BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}
#endregion

#region CmdletWithPluralNoun
namespace StaticAnalysis.Test.CmdletTest.Signature.CmdletWithSingularNoun
{
    using System.Management.Automation;

    /// <summary>
    /// Verify if a cmdlet has a singular noun in its name.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SampleKey")]
    [OutputType(typeof(bool))]
    public class CmdletGetSampleKey : Cmdlet
    {
        /// <summary>
        /// Begin processing the cmdlet.
        /// </summary>
        protected override void BeginProcessing()
        {
            WriteObject("Get-SampleKey BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.Signature.CmdletWithPluralNoun
{
    using System.Management.Automation;

    /// <summary>
    /// Verify if a cmdlet has a plural noun in its name.
    /// </summary>
    [Cmdlet("Get", "SampleKeys")]
    [OutputType(typeof(bool))]
    public class CmdletGetSampleKeys : Cmdlet
    {
        /// <summary>
        /// Begin processing the cmdlet.
        /// </summary>
        protected override void BeginProcessing()
        {
            WriteObject("Get-SampleKeys BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}
#endregion

#region OutputChecks
namespace StaticAnalysis.Test.CmdletTest.Signature.CmdletWithNoOutput
{
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Get, "CmdletWithNoOutput")]
    public class CmdletGetCmdletWithNoOutput : Cmdlet
    {
        protected override void BeginProcessing()
        {
            WriteObject("Get-CmdletWithNoOutput BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

#endregion

#region ParameterSetChecks
namespace StaticAnalysis.Test.CmdletTest.Signature.ParameterSetNameWithSpace
{
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Get, "ParameterSetNameWithSpace", DefaultParameterSetName = "GetFoo")]
    [OutputType(typeof(bool))]
    public class CmdletGetParameterSetNameWithSpace : Cmdlet
    {
        [Parameter(ParameterSetName = "GetFoo")]
        public string Foo { get; set; }

        [Parameter(ParameterSetName = "Get Bar")]
        public string Bar { get; set; }

        protected override void BeginProcessing()
        {
            WriteObject("Get-ParameterSetNameWithSpace BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.Signature.MultipleParameterSetsWithNoDefault
{
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Get, "MultipleParameterSetsWithNoDefault")]
    [OutputType(typeof(bool))]
    public class CmdletGetMultipleParameterSetsWithNoDefault : Cmdlet
    {
        [Parameter(ParameterSetName = "GetFoo")]
        public string Foo { get; set; }

        [Parameter(ParameterSetName = "GetBar")]
        public string Bar { get; set; }

        protected override void BeginProcessing()
        {
            WriteObject("Get-MultipleParameterSetsWithNoDefault BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

#endregion

#region ParameterChecks
namespace StaticAnalysis.Test.CmdletTest.Signature.ParameterWithSingularNoun
{
    using System.Management.Automation;

    /// <summary>
    /// Verify if a parameter has a singular noun in its name.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SampleFoo")]
    [OutputType(typeof(bool))]
    public class CmdletGetSampleFoo : Cmdlet
    {
        [Parameter(Mandatory = false)]
        public string Foo { get; set; }

        /// <summary>
        /// Begin processing the cmdlet.
        /// </summary>
        protected override void BeginProcessing()
        {
            WriteObject("Get-SampleFoo BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.Signature.ParameterWithPluralNoun
{
    using System.Management.Automation;

    /// <summary>
    /// Verify if a parameter has a plural noun in its name.
    /// </summary>
    [Cmdlet("Get", "SampleBar")]
    [OutputType(typeof(bool))]
    public class CmdletGetSampleBar : Cmdlet
    {
        [Parameter(Mandatory = false)]
        public string Bars { get; set; }

        /// <summary>
        /// Begin processing the cmdlet.
        /// </summary>
        protected override void BeginProcessing()
        {
            WriteObject("Get-SampleBar BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.Signature.CmdletAndParameterWithSingularNounInList
{
    using System.Management.Automation;

    /// <summary>
    /// Verify if a cmdlet and parameter have a singular noun in the list of
    /// accepted nouns ending with "s".
    /// </summary>
    [Cmdlet("Get", "SampleAddress")]
    [OutputType(typeof(bool))]
    public class CmdletGetSampleAddress : Cmdlet
    {
        [Parameter(Mandatory = false)]
        public string Address { get; set; }

        /// <summary>
        /// Begin processing the cmdlet.
        /// </summary>
        protected override void BeginProcessing()
        {
            WriteObject("Get-SampleAddress BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

namespace StaticAnalysis.Test.CmdletTest.Signature.ParameterWithOutOfRangePosition
{
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Get, "ParameterWithOutOfRangePosition")]
    [OutputType(typeof(bool))]
    public class CmdletGetParameterWithOutOfRangePosition : Cmdlet
    {
        [Parameter(Position = 0)]
        public string FirstParameter { get; set; }

        [Parameter(Position = 1)]
        public string SecondParameter { get; set; }

        [Parameter(Position = 2)]
        public string ThirdParameter { get; set; }

        [Parameter(Position = 3)]
        public string FourthParameter { get; set; }

        [Parameter(Position = 4)]
        public string FifthParameter { get; set; }

        protected override void BeginProcessing()
        {
            WriteObject("Get-ParameterWithOutOfRangePosition BeginProcessing()");
            WriteInformation("Info", null);
        }
    }
}

#endregion