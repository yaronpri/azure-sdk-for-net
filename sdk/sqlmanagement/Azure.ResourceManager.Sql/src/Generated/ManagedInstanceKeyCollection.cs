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

namespace Azure.ResourceManager.Sql
{
    /// <summary> A class representing collection of ManagedInstanceKey and their operations over its parent. </summary>
    public partial class ManagedInstanceKeyCollection : ArmCollection, IEnumerable<ManagedInstanceKey>, IAsyncEnumerable<ManagedInstanceKey>
    {
        private readonly ClientDiagnostics _managedInstanceKeyClientDiagnostics;
        private readonly ManagedInstanceKeysRestOperations _managedInstanceKeyRestClient;

        /// <summary> Initializes a new instance of the <see cref="ManagedInstanceKeyCollection"/> class for mocking. </summary>
        protected ManagedInstanceKeyCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ManagedInstanceKeyCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ManagedInstanceKeyCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _managedInstanceKeyClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ManagedInstanceKey.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ManagedInstanceKey.ResourceType, out string managedInstanceKeyApiVersion);
            _managedInstanceKeyRestClient = new ManagedInstanceKeysRestOperations(_managedInstanceKeyClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, managedInstanceKeyApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ManagedInstance.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ManagedInstance.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates a managed instance key.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/keys/{keyName}
        /// Operation Id: ManagedInstanceKeys_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="keyName"> The name of the managed instance key to be operated on (updated or created). </param>
        /// <param name="parameters"> The requested managed instance key resource state. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<ManagedInstanceKey>> CreateOrUpdateAsync(bool waitForCompletion, string keyName, ManagedInstanceKeyData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyName, nameof(keyName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _managedInstanceKeyClientDiagnostics.CreateScope("ManagedInstanceKeyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _managedInstanceKeyRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, keyName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<ManagedInstanceKey>(new ManagedInstanceKeyOperationSource(Client), _managedInstanceKeyClientDiagnostics, Pipeline, _managedInstanceKeyRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, keyName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Creates or updates a managed instance key.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/keys/{keyName}
        /// Operation Id: ManagedInstanceKeys_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="keyName"> The name of the managed instance key to be operated on (updated or created). </param>
        /// <param name="parameters"> The requested managed instance key resource state. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<ManagedInstanceKey> CreateOrUpdate(bool waitForCompletion, string keyName, ManagedInstanceKeyData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyName, nameof(keyName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _managedInstanceKeyClientDiagnostics.CreateScope("ManagedInstanceKeyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _managedInstanceKeyRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, keyName, parameters, cancellationToken);
                var operation = new SqlArmOperation<ManagedInstanceKey>(new ManagedInstanceKeyOperationSource(Client), _managedInstanceKeyClientDiagnostics, Pipeline, _managedInstanceKeyRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, keyName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Gets a managed instance key.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/keys/{keyName}
        /// Operation Id: ManagedInstanceKeys_Get
        /// </summary>
        /// <param name="keyName"> The name of the managed instance key to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyName"/> is null. </exception>
        public async virtual Task<Response<ManagedInstanceKey>> GetAsync(string keyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyName, nameof(keyName));

            using var scope = _managedInstanceKeyClientDiagnostics.CreateScope("ManagedInstanceKeyCollection.Get");
            scope.Start();
            try
            {
                var response = await _managedInstanceKeyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, keyName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _managedInstanceKeyClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ManagedInstanceKey(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a managed instance key.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/keys/{keyName}
        /// Operation Id: ManagedInstanceKeys_Get
        /// </summary>
        /// <param name="keyName"> The name of the managed instance key to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyName"/> is null. </exception>
        public virtual Response<ManagedInstanceKey> Get(string keyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyName, nameof(keyName));

            using var scope = _managedInstanceKeyClientDiagnostics.CreateScope("ManagedInstanceKeyCollection.Get");
            scope.Start();
            try
            {
                var response = _managedInstanceKeyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, keyName, cancellationToken);
                if (response.Value == null)
                    throw _managedInstanceKeyClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ManagedInstanceKey(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of managed instance keys.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/keys
        /// Operation Id: ManagedInstanceKeys_ListByInstance
        /// </summary>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ManagedInstanceKey" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ManagedInstanceKey> GetAllAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ManagedInstanceKey>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedInstanceKeyClientDiagnostics.CreateScope("ManagedInstanceKeyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _managedInstanceKeyRestClient.ListByInstanceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedInstanceKey(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ManagedInstanceKey>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedInstanceKeyClientDiagnostics.CreateScope("ManagedInstanceKeyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _managedInstanceKeyRestClient.ListByInstanceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedInstanceKey(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets a list of managed instance keys.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/keys
        /// Operation Id: ManagedInstanceKeys_ListByInstance
        /// </summary>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ManagedInstanceKey" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ManagedInstanceKey> GetAll(string filter = null, CancellationToken cancellationToken = default)
        {
            Page<ManagedInstanceKey> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _managedInstanceKeyClientDiagnostics.CreateScope("ManagedInstanceKeyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _managedInstanceKeyRestClient.ListByInstance(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedInstanceKey(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ManagedInstanceKey> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _managedInstanceKeyClientDiagnostics.CreateScope("ManagedInstanceKeyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _managedInstanceKeyRestClient.ListByInstanceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ManagedInstanceKey(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/keys/{keyName}
        /// Operation Id: ManagedInstanceKeys_Get
        /// </summary>
        /// <param name="keyName"> The name of the managed instance key to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string keyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyName, nameof(keyName));

            using var scope = _managedInstanceKeyClientDiagnostics.CreateScope("ManagedInstanceKeyCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(keyName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/keys/{keyName}
        /// Operation Id: ManagedInstanceKeys_Get
        /// </summary>
        /// <param name="keyName"> The name of the managed instance key to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyName"/> is null. </exception>
        public virtual Response<bool> Exists(string keyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyName, nameof(keyName));

            using var scope = _managedInstanceKeyClientDiagnostics.CreateScope("ManagedInstanceKeyCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(keyName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/keys/{keyName}
        /// Operation Id: ManagedInstanceKeys_Get
        /// </summary>
        /// <param name="keyName"> The name of the managed instance key to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyName"/> is null. </exception>
        public async virtual Task<Response<ManagedInstanceKey>> GetIfExistsAsync(string keyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyName, nameof(keyName));

            using var scope = _managedInstanceKeyClientDiagnostics.CreateScope("ManagedInstanceKeyCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _managedInstanceKeyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, keyName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ManagedInstanceKey>(null, response.GetRawResponse());
                return Response.FromValue(new ManagedInstanceKey(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/keys/{keyName}
        /// Operation Id: ManagedInstanceKeys_Get
        /// </summary>
        /// <param name="keyName"> The name of the managed instance key to be retrieved. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="keyName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="keyName"/> is null. </exception>
        public virtual Response<ManagedInstanceKey> GetIfExists(string keyName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(keyName, nameof(keyName));

            using var scope = _managedInstanceKeyClientDiagnostics.CreateScope("ManagedInstanceKeyCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _managedInstanceKeyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, keyName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ManagedInstanceKey>(null, response.GetRawResponse());
                return Response.FromValue(new ManagedInstanceKey(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ManagedInstanceKey> IEnumerable<ManagedInstanceKey>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ManagedInstanceKey> IAsyncEnumerable<ManagedInstanceKey>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
