// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Network
{
    /// <summary> A Class representing a OutboundRule along with the instance operations that can be performed on it. </summary>
    public partial class OutboundRule : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="OutboundRule"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string loadBalancerName, string outboundRuleName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}/outboundRules/{outboundRuleName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _outboundRuleLoadBalancerOutboundRulesClientDiagnostics;
        private readonly LoadBalancerOutboundRulesRestOperations _outboundRuleLoadBalancerOutboundRulesRestClient;
        private readonly OutboundRuleData _data;

        /// <summary> Initializes a new instance of the <see cref="OutboundRule"/> class for mocking. </summary>
        protected OutboundRule()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "OutboundRule"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal OutboundRule(ArmClient client, OutboundRuleData data) : this(client, new ResourceIdentifier(data.Id))
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="OutboundRule"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal OutboundRule(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _outboundRuleLoadBalancerOutboundRulesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string outboundRuleLoadBalancerOutboundRulesApiVersion);
            _outboundRuleLoadBalancerOutboundRulesRestClient = new LoadBalancerOutboundRulesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, outboundRuleLoadBalancerOutboundRulesApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/loadBalancers/outboundRules";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual OutboundRuleData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets the specified load balancer outbound rule.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}/outboundRules/{outboundRuleName}
        /// Operation Id: LoadBalancerOutboundRules_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<OutboundRule>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _outboundRuleLoadBalancerOutboundRulesClientDiagnostics.CreateScope("OutboundRule.Get");
            scope.Start();
            try
            {
                var response = await _outboundRuleLoadBalancerOutboundRulesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new OutboundRule(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified load balancer outbound rule.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}/outboundRules/{outboundRuleName}
        /// Operation Id: LoadBalancerOutboundRules_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<OutboundRule> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _outboundRuleLoadBalancerOutboundRulesClientDiagnostics.CreateScope("OutboundRule.Get");
            scope.Start();
            try
            {
                var response = _outboundRuleLoadBalancerOutboundRulesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new OutboundRule(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
