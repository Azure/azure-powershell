namespace Microsoft.Azure.Commands.Network.ApplicationGateway.Model
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Security.Cryptography.X509Certificates;

    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class ApplicationGatewayCertificate
    {
        [DataMember(Order = 1, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Order = 2, EmitDefaultValue = false)]
        public string SubjectName { get; set; }

        [DataMember(Order = 3, EmitDefaultValue = false)]
        public string Thumbprint { get; set; }

        [DataMember(Order = 4, EmitDefaultValue = false)]
        public string ThumbprintAlgo { get; set; }

        [DataMember(Order = 5, EmitDefaultValue = false)]
        public string State { get; set; }

        //public static void ShowDetails(ApplicationGatewayCertificate cert)
        //{
        //    X509Certificate2 certObject = new X509Certificate2(Convert.FromBase64String(cert.Data));

        //    Console.WriteLine("Name:{0}", cert.Name);
        //    Console.WriteLine("SubjectName:{0}", certObject.SubjectName.Name);
        //    Console.WriteLine("Thumbprint:{0}", certObject.Thumbprint);
        //    Console.WriteLine("ThumbprintAlgo:{0}", certObject.SignatureAlgorithm.FriendlyName);
        //    Console.WriteLine("State:{0}", cert.State);
        //}
    }

    [CollectionDataContract(Name = "ApplicationGatewayCertificates", Namespace = "http://schemas.microsoft.com/windowsazure")]
    public class ApplicationGatewayCertificateCollection : List<ApplicationGatewayCertificate>
    {
    }

    /// <summary>
    /// Represents the provisioning state of an Application Gateway Certificate
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/windowsazure")]
    public enum ApplicationGatewayCertificateState
    {
        [EnumMember]
        Provisioning,

        [EnumMember]
        Provisioned,

        [EnumMember]
        Deleting,

        [EnumMember]
        Unknown
    }
}
