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

namespace StaticAnalysis.Test.CmdletTest.Signature.ShouldContinueVerbWithoutForceSwitch
{
    using System.Management.Automation;

    /// <summary>
    /// Verify if cmdlet that has Force parameter should also define SupportsShouldProcess parameter
    /// </summary>
    [Cmdlet(VerbsData.Export, "ShouldContinueVerbWithoutForceSwitch")]
    public class ShouldContinueVerbWithoutForceSwitch : Cmdlet
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
#endregion