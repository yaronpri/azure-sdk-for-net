// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.DesktopVirtualization
{
    /// <summary> A class representing collection of VirtualApplication and their operations over its parent. </summary>
    public partial class VirtualApplicationCollection : ArmCollection, IEnumerable<VirtualApplication>, IAsyncEnumerable<VirtualApplication>
    {
        private readonly ClientDiagnostics _virtualApplicationApplicationsClientDiagnostics;
        private readonly ApplicationsRestOperations _virtualApplicationApplicationsRestClient;

        /// <summary> Initializes a new instance of the <see cref="VirtualApplicationCollection"/> class for mocking. </summary>
        protected VirtualApplicationCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualApplicationCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal VirtualApplicationCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _virtualApplicationApplicationsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.DesktopVirtualization", VirtualApplication.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(VirtualApplication.ResourceType, out string virtualApplicationApplicationsApiVersion);
            _virtualApplicationApplicationsRestClient = new ApplicationsRestOperations(_virtualApplicationApplicationsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, virtualApplicationApplicationsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != VirtualApplicationGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, VirtualApplicationGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update an application.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}/applications/{applicationName}
        /// Operation Id: Applications_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="applicationName"> The name of the application within the specified application group. </param>
        /// <param name="application"> Object containing Application definitions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> or <paramref name="application"/> is null. </exception>
        public async virtual Task<ArmOperation<VirtualApplication>> CreateOrUpdateAsync(bool waitForCompletion, string applicationName, VirtualApplicationData application, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));
            Argument.AssertNotNull(application, nameof(application));

            using var scope = _virtualApplicationApplicationsClientDiagnostics.CreateScope("VirtualApplicationCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _virtualApplicationApplicationsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, applicationName, application, cancellationToken).ConfigureAwait(false);
                var operation = new DesktopVirtualizationArmOperation<VirtualApplication>(Response.FromValue(new VirtualApplication(Client, response), response.GetRawResponse()));
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update an application.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}/applications/{applicationName}
        /// Operation Id: Applications_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="applicationName"> The name of the application within the specified application group. </param>
        /// <param name="application"> Object containing Application definitions. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> or <paramref name="application"/> is null. </exception>
        public virtual ArmOperation<VirtualApplication> CreateOrUpdate(bool waitForCompletion, string applicationName, VirtualApplicationData application, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));
            Argument.AssertNotNull(application, nameof(application));

            using var scope = _virtualApplicationApplicationsClientDiagnostics.CreateScope("VirtualApplicationCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _virtualApplicationApplicationsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, applicationName, application, cancellationToken);
                var operation = new DesktopVirtualizationArmOperation<VirtualApplication>(Response.FromValue(new VirtualApplication(Client, response), response.GetRawResponse()));
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get an application.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}/applications/{applicationName}
        /// Operation Id: Applications_Get
        /// </summary>
        /// <param name="applicationName"> The name of the application within the specified application group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> is null. </exception>
        public async virtual Task<Response<VirtualApplication>> GetAsync(string applicationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));

            using var scope = _virtualApplicationApplicationsClientDiagnostics.CreateScope("VirtualApplicationCollection.Get");
            scope.Start();
            try
            {
                var response = await _virtualApplicationApplicationsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, applicationName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _virtualApplicationApplicationsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new VirtualApplication(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get an application.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}/applications/{applicationName}
        /// Operation Id: Applications_Get
        /// </summary>
        /// <param name="applicationName"> The name of the application within the specified application group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> is null. </exception>
        public virtual Response<VirtualApplication> Get(string applicationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));

            using var scope = _virtualApplicationApplicationsClientDiagnostics.CreateScope("VirtualApplicationCollection.Get");
            scope.Start();
            try
            {
                var response = _virtualApplicationApplicationsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, applicationName, cancellationToken);
                if (response.Value == null)
                    throw _virtualApplicationApplicationsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualApplication(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List applications.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}/applications
        /// Operation Id: Applications_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualApplication" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualApplication> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<VirtualApplication>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualApplicationApplicationsClientDiagnostics.CreateScope("VirtualApplicationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualApplicationApplicationsRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualApplication(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<VirtualApplication>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualApplicationApplicationsClientDiagnostics.CreateScope("VirtualApplicationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualApplicationApplicationsRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualApplication(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// List applications.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}/applications
        /// Operation Id: Applications_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualApplication" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualApplication> GetAll(CancellationToken cancellationToken = default)
        {
            Page<VirtualApplication> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualApplicationApplicationsClientDiagnostics.CreateScope("VirtualApplicationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualApplicationApplicationsRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualApplication(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<VirtualApplication> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualApplicationApplicationsClientDiagnostics.CreateScope("VirtualApplicationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualApplicationApplicationsRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualApplication(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}/applications/{applicationName}
        /// Operation Id: Applications_Get
        /// </summary>
        /// <param name="applicationName"> The name of the application within the specified application group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string applicationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));

            using var scope = _virtualApplicationApplicationsClientDiagnostics.CreateScope("VirtualApplicationCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(applicationName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}/applications/{applicationName}
        /// Operation Id: Applications_Get
        /// </summary>
        /// <param name="applicationName"> The name of the application within the specified application group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> is null. </exception>
        public virtual Response<bool> Exists(string applicationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));

            using var scope = _virtualApplicationApplicationsClientDiagnostics.CreateScope("VirtualApplicationCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(applicationName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}/applications/{applicationName}
        /// Operation Id: Applications_Get
        /// </summary>
        /// <param name="applicationName"> The name of the application within the specified application group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> is null. </exception>
        public async virtual Task<Response<VirtualApplication>> GetIfExistsAsync(string applicationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));

            using var scope = _virtualApplicationApplicationsClientDiagnostics.CreateScope("VirtualApplicationCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _virtualApplicationApplicationsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, applicationName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<VirtualApplication>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualApplication(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DesktopVirtualization/applicationGroups/{applicationGroupName}/applications/{applicationName}
        /// Operation Id: Applications_Get
        /// </summary>
        /// <param name="applicationName"> The name of the application within the specified application group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="applicationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="applicationName"/> is null. </exception>
        public virtual Response<VirtualApplication> GetIfExists(string applicationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(applicationName, nameof(applicationName));

            using var scope = _virtualApplicationApplicationsClientDiagnostics.CreateScope("VirtualApplicationCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _virtualApplicationApplicationsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, applicationName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<VirtualApplication>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualApplication(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<VirtualApplication> IEnumerable<VirtualApplication>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<VirtualApplication> IAsyncEnumerable<VirtualApplication>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
