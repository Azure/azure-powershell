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

#region ParameterWithPluralNoun
namespace StaticAnalysis.Test.CmdletTest.Signature.ParameterWithSingularNoun
{
    using System.Management.Automation;

    /// <summary>
    /// Verify if a parameter has a singular noun in its name.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "SampleFoo")]
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
#endregion