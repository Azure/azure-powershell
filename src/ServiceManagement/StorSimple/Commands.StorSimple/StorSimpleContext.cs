using System;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public static class StorSimpleContext
    {
        public static string SubscriptionId { get; set; }
        public static Uri ServiceEndPoint { get; set; }
        public static string ResourceId { get; set; }
        public static string StampId { get; set; }
        public static string CloudServiceName { get; set; }
        public static string ResourceProviderNameSpace { get; set; }
        public static string ResourceType { get; set; }
        public static string ResourceName { get; set; }
    }
}
