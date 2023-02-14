using Azure.Security.KeyVault.Keys;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyReleasePolicy
    {
        // Summary:
        //     Gets or sets the content type and version of key release policy. The service
        //     default is "application/json; charset=utf-8".
        public string ContentType { get; set; } = "application/json; charset=utf-8";

        // Summary:
        //     Gets the policy rules under which the key can be released encoded based on the
        //     Azure.Security.KeyVault.Keys.KeyReleasePolicy.ContentType.
        private BinaryData EncodedPolicy;

        public string PolicyContent { get; set; }

        //
        // Summary:
        //     Gets or sets the mutability state of the policy. Once marked immutable, this
        //     flag cannot be reset and the policy cannot be changed under any circumstances.
        public bool? Immutable { get; set; }

        public PSKeyReleasePolicy() { }

        internal PSKeyReleasePolicy(string keyReleasePolicyPath)
        {
            // Assume File.Exists(keyReleasePolicyPath) is true
            this.PolicyContent = File.Exists(keyReleasePolicyPath) ? File.ReadAllText(keyReleasePolicyPath) : null;
        }

        internal PSKeyReleasePolicy(KeyReleasePolicy keyReleasePolicy)
        {
            this.ContentType = keyReleasePolicy?.ContentType;
            this.EncodedPolicy = keyReleasePolicy?.EncodedPolicy;
            this.PolicyContent = EncodedPolicy.ToString();
            this.Immutable = keyReleasePolicy?.Immutable;
        }

        internal KeyReleasePolicy ToKeyReleasePolicy()
        {
            this.EncodedPolicy = this.EncodedPolicy ?? (this.PolicyContent == null ? null : new BinaryData(this.PolicyContent));
            return new KeyReleasePolicy(this.EncodedPolicy)
            {
                ContentType = this.ContentType,
                Immutable = this.Immutable
            };
        }

        public override string ToString()
        {
            if (this == null) return string.Empty;

            var sb = new StringBuilder();
            sb.AppendLine(); 
            sb.AppendFormat("{0, -15}: {1}{2}", "Content Type", ContentType, Environment.NewLine);
            sb.AppendFormat("{0, -15}: {1}{2}", "Policy Content", PolicyContent, Environment.NewLine);
            sb.AppendFormat("{0, -15}: {1}{2}", "Immutable", Immutable, Environment.NewLine);
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
