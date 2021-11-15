using System.Text.RegularExpressions;
using System.Collections;

namespace Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview
{
    internal static class ResourceHelper
    {
        private static readonly Regex s_subscriptionIdRegex = new Regex(@"(?:\/subscriptions\/)([-\w\._\(\)]+){1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex s_resourceGroupRegex = new Regex(@"(?:\/resourceGroups\/)([-\w\._\(\)]+){1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex s_labPlanRegex = new Regex(@"(?:\/LabPlans\/)([^\/]+){1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex s_labRegex = new Regex(@"(?:\/labs\/)([^\/]+){1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex s_virtualMachineRegex = new Regex(@"(?:\/virtualMachines\/)([^\/]+){1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex s_scheduleRegex = new Regex(@"(?:\/schedules\/)([^\/]+){1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex s_userRegex = new Regex(@"(?:\/users\/)([^\/]+){1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex s_imageRegex = new Regex(@"(?:\/images\/)([^\/]+){1}", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static string ExtractSubscriptionFromId(string id) => s_subscriptionIdRegex.Match(id).Groups[1].Value;
        public static string ExtractResourceGroupFromId(string id) => s_resourceGroupRegex.Match(id).Groups[1].Value;
        public static string ExtractLabPlanFromId(string id) => s_labPlanRegex.Match(id).Groups[1].Value;
        public static string ExtractLabFromId(string id) => s_labRegex.Match(id).Groups[1].Value;
        public static string ExtractVirtualMachineFromId(string id) => s_virtualMachineRegex.Match(id).Groups[1].Value;
        public static string ExtractScheduleFromId(string id) => s_scheduleRegex.Match(id).Groups[1].Value;
        public static string ExtractUserFromId(string id) => s_userRegex.Match(id).Groups[1].Value;
        public static string ExtractImageFromId(string id) => s_imageRegex.Match(id).Groups[1].Value;
    }

    public partial class LabPlan
    {
        private string SubscriptionId => ResourceHelper.ExtractSubscriptionFromId(this.Id);
        private string ResourceGroup => ResourceHelper.ExtractResourceGroupFromId(this.Id);

        public Hashtable BindResourceParameters(Hashtable boundParameters)
        {
            boundParameters["SubscriptionId"] = this.SubscriptionId;
            boundParameters["ResourceGroupName"] = this.ResourceGroup;
            boundParameters["LabPlanName"] = this.Name;

            boundParameters.Remove("LabPlanObject");

            return boundParameters;
        }
    }

    public partial class Lab
    {
        private string SubscriptionId => ResourceHelper.ExtractSubscriptionFromId(this.Id);
        private string ResourceGroup => ResourceHelper.ExtractResourceGroupFromId(this.Id);
        private string LabPlan => ResourceHelper.ExtractLabPlanFromId(this.Id);

        public Hashtable BindResourceParameters(Hashtable boundParameters)
        {
            boundParameters["SubscriptionId"] = this.SubscriptionId;
            boundParameters["ResourceGroupName"] = this.ResourceGroup;
            boundParameters["LabName"] = this.Name;

            boundParameters.Remove("LabObject");

            return boundParameters;
        }
    }

    public partial class VirtualMachine
    {
        private string SubscriptionId => ResourceHelper.ExtractSubscriptionFromId(this.Id);
        private string ResourceGroup => ResourceHelper.ExtractResourceGroupFromId(this.Id);
        private string Lab => ResourceHelper.ExtractLabFromId(this.Id);

        public Hashtable BindResourceParameters(Hashtable boundParameters)
        {
            boundParameters["SubscriptionId"] = this.SubscriptionId;
            boundParameters["ResourceGroupName"] = this.ResourceGroup;
            boundParameters["LabName"] = this.Lab;
            boundParameters["VirtualMachineName"] = this.Name;

            boundParameters.Remove("VirtualMachineObject");

            return boundParameters;
        }
    }

    public partial class Schedule
    {
        private string SubscriptionId => ResourceHelper.ExtractSubscriptionFromId(this.Id);
        private string ResourceGroup => ResourceHelper.ExtractResourceGroupFromId(this.Id);
        private string Lab => ResourceHelper.ExtractLabFromId(this.Id);

        public Hashtable BindResourceParameters(Hashtable boundParameters)
        {
            boundParameters["SubscriptionId"] = this.SubscriptionId;
            boundParameters["ResourceGroupName"] = this.ResourceGroup;
            boundParameters["LabName"] = this.Lab;
            boundParameters["ScheduleName"] = this.Name;

            boundParameters.Remove("ScheduleObject");

            return boundParameters;
        }
    }

    public partial class User
    {
        private string SubscriptionId => ResourceHelper.ExtractSubscriptionFromId(this.Id);
        private string ResourceGroup => ResourceHelper.ExtractResourceGroupFromId(this.Id);
        private string Lab => ResourceHelper.ExtractLabFromId(this.Id);

        public Hashtable BindResourceParameters(Hashtable boundParameters)
        {
            boundParameters["SubscriptionId"] = this.SubscriptionId;
            boundParameters["ResourceGroupName"] = this.ResourceGroup;
            boundParameters["LabName"] = this.Lab;
            boundParameters["UserName"] = this.Name;

            boundParameters.Remove("UserObject");

            return boundParameters;
        }
    }

    public partial class Image
    {
        private string SubscriptionId => ResourceHelper.ExtractSubscriptionFromId(this.Id);
        private string ResourceGroup => ResourceHelper.ExtractResourceGroupFromId(this.Id);
        private string LabPlan => ResourceHelper.ExtractLabPlanFromId(this.Id);

        public Hashtable BindResourceParameters(Hashtable boundParameters)
        {
            boundParameters["SubscriptionId"] = this.SubscriptionId;
            boundParameters["ResourceGroupName"] = this.ResourceGroup;
            boundParameters["LabPlanName"] = this.LabPlan;
            boundParameters["ImageName"] = this.Name;

            boundParameters.Remove("ImageObject");

            return boundParameters;
        }
    }
}
