// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary> A class to add extension methods to Tenant. </summary>
    public static partial class TenantExtensions
    {
        private static TenantExtensionClient GetExtensionClient(Tenant tenant)
        {
            return tenant.GetCachedClient((client) =>
            {
                return new TenantExtensionClient(client, tenant.Id);
            }
            );
        }

        /// <summary> Gets a collection of Deployments in the Deployment. </summary>
        /// <param name="tenant"> The <see cref="Tenant" /> instance the method will execute against. </param>
        /// <returns> An object representing collection of Deployments and their operations over a Deployment. </returns>
        public static DeploymentCollection GetDeployments(this Tenant tenant)
        {
            return GetExtensionClient(tenant).GetDeployments();
        }

        /// <summary>
        /// Calculate the hash of the given template.
        /// Request Path: /providers/Microsoft.Resources/calculateTemplateHash
        /// Operation Id: Deployments_CalculateTemplateHash
        /// </summary>
        /// <param name="tenant"> The <see cref="Tenant" /> instance the method will execute against. </param>
        /// <param name="template"> The template provided to calculate hash. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="template"/> is null. </exception>
        public async static Task<Response<TemplateHashResult>> CalculateTemplateHashDeploymentAsync(this Tenant tenant, object template, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(template, nameof(template));

            return await GetExtensionClient(tenant).CalculateTemplateHashDeploymentAsync(template, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Calculate the hash of the given template.
        /// Request Path: /providers/Microsoft.Resources/calculateTemplateHash
        /// Operation Id: Deployments_CalculateTemplateHash
        /// </summary>
        /// <param name="tenant"> The <see cref="Tenant" /> instance the method will execute against. </param>
        /// <param name="template"> The template provided to calculate hash. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="template"/> is null. </exception>
        public static Response<TemplateHashResult> CalculateTemplateHashDeployment(this Tenant tenant, object template, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(template, nameof(template));

            return GetExtensionClient(tenant).CalculateTemplateHashDeployment(template, cancellationToken);
        }
    }
}
