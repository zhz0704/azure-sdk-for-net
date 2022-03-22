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

namespace Azure.ResourceManager.AppService
{
    /// <summary> A class representing collection of SiteSlotConfigAppSetting and their operations over its parent. </summary>
    public partial class SiteSlotConfigAppSettingCollection : ArmCollection, IEnumerable<SiteSlotConfigAppSetting>, IAsyncEnumerable<SiteSlotConfigAppSetting>
    {
        private readonly ClientDiagnostics _siteSlotConfigAppSettingWebAppsClientDiagnostics;
        private readonly WebAppsRestOperations _siteSlotConfigAppSettingWebAppsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SiteSlotConfigAppSettingCollection"/> class for mocking. </summary>
        protected SiteSlotConfigAppSettingCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SiteSlotConfigAppSettingCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SiteSlotConfigAppSettingCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _siteSlotConfigAppSettingWebAppsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", SiteSlotConfigAppSetting.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SiteSlotConfigAppSetting.ResourceType, out string siteSlotConfigAppSettingWebAppsApiVersion);
            _siteSlotConfigAppSettingWebAppsRestClient = new WebAppsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, siteSlotConfigAppSettingWebAppsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SiteSlot.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SiteSlot.ResourceType), nameof(id));
        }

        /// <summary>
        /// Description for Gets the config reference and status of an app
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/configreferences/appsettings/{appSettingKey}
        /// Operation Id: WebApps_GetAppSettingKeyVaultReferenceSlot
        /// </summary>
        /// <param name="appSettingKey"> App Setting key name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="appSettingKey"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="appSettingKey"/> is null. </exception>
        public virtual async Task<Response<SiteSlotConfigAppSetting>> GetAsync(string appSettingKey, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(appSettingKey, nameof(appSettingKey));

            using var scope = _siteSlotConfigAppSettingWebAppsClientDiagnostics.CreateScope("SiteSlotConfigAppSettingCollection.Get");
            scope.Start();
            try
            {
                var response = await _siteSlotConfigAppSettingWebAppsRestClient.GetAppSettingKeyVaultReferenceSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, appSettingKey, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteSlotConfigAppSetting(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Gets the config reference and status of an app
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/configreferences/appsettings/{appSettingKey}
        /// Operation Id: WebApps_GetAppSettingKeyVaultReferenceSlot
        /// </summary>
        /// <param name="appSettingKey"> App Setting key name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="appSettingKey"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="appSettingKey"/> is null. </exception>
        public virtual Response<SiteSlotConfigAppSetting> Get(string appSettingKey, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(appSettingKey, nameof(appSettingKey));

            using var scope = _siteSlotConfigAppSettingWebAppsClientDiagnostics.CreateScope("SiteSlotConfigAppSettingCollection.Get");
            scope.Start();
            try
            {
                var response = _siteSlotConfigAppSettingWebAppsRestClient.GetAppSettingKeyVaultReferenceSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, appSettingKey, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteSlotConfigAppSetting(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Gets the config reference app settings and status of an app
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/configreferences/appsettings
        /// Operation Id: WebApps_GetAppSettingsKeyVaultReferencesSlot
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SiteSlotConfigAppSetting" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SiteSlotConfigAppSetting> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SiteSlotConfigAppSetting>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteSlotConfigAppSettingWebAppsClientDiagnostics.CreateScope("SiteSlotConfigAppSettingCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _siteSlotConfigAppSettingWebAppsRestClient.GetAppSettingsKeyVaultReferencesSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteSlotConfigAppSetting(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SiteSlotConfigAppSetting>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteSlotConfigAppSettingWebAppsClientDiagnostics.CreateScope("SiteSlotConfigAppSettingCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _siteSlotConfigAppSettingWebAppsRestClient.GetAppSettingsKeyVaultReferencesSlotNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteSlotConfigAppSetting(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Description for Gets the config reference app settings and status of an app
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/configreferences/appsettings
        /// Operation Id: WebApps_GetAppSettingsKeyVaultReferencesSlot
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SiteSlotConfigAppSetting" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SiteSlotConfigAppSetting> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SiteSlotConfigAppSetting> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteSlotConfigAppSettingWebAppsClientDiagnostics.CreateScope("SiteSlotConfigAppSettingCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _siteSlotConfigAppSettingWebAppsRestClient.GetAppSettingsKeyVaultReferencesSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteSlotConfigAppSetting(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SiteSlotConfigAppSetting> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteSlotConfigAppSettingWebAppsClientDiagnostics.CreateScope("SiteSlotConfigAppSettingCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _siteSlotConfigAppSettingWebAppsRestClient.GetAppSettingsKeyVaultReferencesSlotNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteSlotConfigAppSetting(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/configreferences/appsettings/{appSettingKey}
        /// Operation Id: WebApps_GetAppSettingKeyVaultReferenceSlot
        /// </summary>
        /// <param name="appSettingKey"> App Setting key name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="appSettingKey"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="appSettingKey"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string appSettingKey, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(appSettingKey, nameof(appSettingKey));

            using var scope = _siteSlotConfigAppSettingWebAppsClientDiagnostics.CreateScope("SiteSlotConfigAppSettingCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(appSettingKey, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/configreferences/appsettings/{appSettingKey}
        /// Operation Id: WebApps_GetAppSettingKeyVaultReferenceSlot
        /// </summary>
        /// <param name="appSettingKey"> App Setting key name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="appSettingKey"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="appSettingKey"/> is null. </exception>
        public virtual Response<bool> Exists(string appSettingKey, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(appSettingKey, nameof(appSettingKey));

            using var scope = _siteSlotConfigAppSettingWebAppsClientDiagnostics.CreateScope("SiteSlotConfigAppSettingCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(appSettingKey, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/configreferences/appsettings/{appSettingKey}
        /// Operation Id: WebApps_GetAppSettingKeyVaultReferenceSlot
        /// </summary>
        /// <param name="appSettingKey"> App Setting key name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="appSettingKey"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="appSettingKey"/> is null. </exception>
        public virtual async Task<Response<SiteSlotConfigAppSetting>> GetIfExistsAsync(string appSettingKey, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(appSettingKey, nameof(appSettingKey));

            using var scope = _siteSlotConfigAppSettingWebAppsClientDiagnostics.CreateScope("SiteSlotConfigAppSettingCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _siteSlotConfigAppSettingWebAppsRestClient.GetAppSettingKeyVaultReferenceSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, appSettingKey, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SiteSlotConfigAppSetting>(null, response.GetRawResponse());
                return Response.FromValue(new SiteSlotConfigAppSetting(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/config/configreferences/appsettings/{appSettingKey}
        /// Operation Id: WebApps_GetAppSettingKeyVaultReferenceSlot
        /// </summary>
        /// <param name="appSettingKey"> App Setting key name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="appSettingKey"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="appSettingKey"/> is null. </exception>
        public virtual Response<SiteSlotConfigAppSetting> GetIfExists(string appSettingKey, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(appSettingKey, nameof(appSettingKey));

            using var scope = _siteSlotConfigAppSettingWebAppsClientDiagnostics.CreateScope("SiteSlotConfigAppSettingCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _siteSlotConfigAppSettingWebAppsRestClient.GetAppSettingKeyVaultReferenceSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, appSettingKey, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SiteSlotConfigAppSetting>(null, response.GetRawResponse());
                return Response.FromValue(new SiteSlotConfigAppSetting(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SiteSlotConfigAppSetting> IEnumerable<SiteSlotConfigAppSetting>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SiteSlotConfigAppSetting> IAsyncEnumerable<SiteSlotConfigAppSetting>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
