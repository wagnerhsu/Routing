﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Http;
using System;

namespace Microsoft.AspNetCore.Routing
{
    /// <summary>
    /// Extension methods for using <see cref="LinkGenerator"/> with <see cref="RouteValuesAddress"/>.
    /// </summary>
    public static class LinkGeneratorRouteValuesAddressExtensions
    {
        /// <summary>
        /// Generates a URI with an absolute path based on the provided values.
        /// </summary>
        /// <param name="generator">The <see cref="LinkGenerator"/>.</param>
        /// <param name="httpContext">The <see cref="HttpContext"/> associated with the current request.</param>
        /// <param name="routeName">The route name. Used to resolve endpoints. Optional.</param>
        /// <param name="values">The route values. Used to resolve endpoints and expand parameters in the route template. Optional.</param>
        /// <param name="fragment">An optional URI fragment. Appended to the resulting URI.</param>
        /// <param name="options">
        /// An optional <see cref="LinkOptions"/>. Settings on provided object override the settings with matching
        /// names from <c>RouteOptions</c>.
        /// </param>
        /// <returns>A URI with an absolute path, or <c>null</c>.</returns>
        public static string GetPathByRouteValues(
            this LinkGenerator generator,
            HttpContext httpContext,
            string routeName,
            object values,
            FragmentString fragment = default,
            LinkOptions options = default)
        {
            if (generator == null)
            {
                throw new ArgumentNullException(nameof(generator));
            }

            var address = CreateAddress(httpContext, routeName, values);
            return generator.GetPathByAddress<RouteValuesAddress>(httpContext, address, address.ExplicitValues, fragment, options);
        }

        /// <summary>
        /// Generates a URI with an absolute path based on the provided values.
        /// </summary>
        /// <param name="generator">The <see cref="LinkGenerator"/>.</param>
        /// <param name="routeName">The route name. Used to resolve endpoints. Optional.</param>
        /// <param name="values">The route values. Used to resolve endpoints and expand parameters in the route template. Optional.</param>
        /// <param name="pathBase">An optional URI path base. Prepended to the path in the resulting URI.</param>
        /// <param name="fragment">An optional URI fragment. Appended to the resulting URI.</param>
        /// <param name="options">
        /// An optional <see cref="LinkOptions"/>. Settings on provided object override the settings with matching
        /// names from <c>RouteOptions</c>.
        /// </param>
        /// <returns>A URI with an absolute path, or <c>null</c>.</returns>
        public static string GetPathByRouteValues(
            this LinkGenerator generator,
            string routeName,
            object values,
            PathString pathBase = default,
            FragmentString fragment = default,
            LinkOptions options = default)
        {
            if (generator == null)
            {
                throw new ArgumentNullException(nameof(generator));
            }

            var address = CreateAddress(httpContext: null, routeName, values);
            return generator.GetPathByAddress<RouteValuesAddress>(address, address.ExplicitValues, pathBase, fragment, options);
        }

        /// <summary>
        /// Generates an absolute URI based on the provided values.
        /// </summary>
        /// <param name="generator">The <see cref="LinkGenerator"/>.</param>
        /// <param name="httpContext">The <see cref="HttpContext"/> associated with the current request.</param>
        /// <param name="routeName">The route name. Used to resolve endpoints. Optional.</param>
        /// <param name="values">The route values. Used to resolve endpoints and expand parameters in the route template. Optional.</param>
        /// <param name="fragment">An optional URI fragment. Appended to the resulting URI.</param>
        /// <param name="options">
        /// An optional <see cref="LinkOptions"/>. Settings on provided object override the settings with matching
        /// names from <c>RouteOptions</c>.
        /// </param>
        /// <returns>A URI with an absolute path, or <c>null</c>.</returns>
        public static string GetUriByRouteValues(
            this LinkGenerator generator,
            HttpContext httpContext,
            string routeName,
            object values,
            FragmentString fragment = default,
            LinkOptions options = default)
        {
            if (generator == null)
            {
                throw new ArgumentNullException(nameof(generator));
            }

            var address = CreateAddress(httpContext: null, routeName, values);
            return generator.GetUriByAddress<RouteValuesAddress>(httpContext, address, address.ExplicitValues, fragment, options);
        }

        /// <summary>
        /// Generates an absolute URI based on the provided values.
        /// </summary>
        /// <param name="generator">The <see cref="LinkGenerator"/>.</param>
        /// <param name="routeName">The route name. Used to resolve endpoints. Optional.</param>
        /// <param name="values">The route values. Used to resolve endpoints and expand parameters in the route template. Optional.</param>
        /// <param name="scheme">The URI scheme, applied to the resulting URI.</param>
        /// <param name="host">The URI host/authority, applied to the resulting URI.</param>
        /// <param name="pathBase">An optional URI path base. Prepended to the path in the resulting URI.</param>
        /// <param name="fragment">An optional URI fragment. Appended to the resulting URI.</param>
        /// <param name="options">
        /// An optional <see cref="LinkOptions"/>. Settings on provided object override the settings with matching
        /// names from <c>RouteOptions</c>.
        /// </param>
        /// <returns>An absolute URI, or <c>null</c>.</returns>
        public static string GetUriByRouteValues(
            this LinkGenerator generator,
            string routeName,
            object values,
            string scheme,
            HostString host,
            PathString pathBase = default,
            FragmentString fragment = default,
            LinkOptions options = default)
        {
            if (generator == null)
            {
                throw new ArgumentNullException(nameof(generator));
            }

            var address = CreateAddress(httpContext: null, routeName, values);
            return generator.GetUriByAddress<RouteValuesAddress>(address, address.ExplicitValues, scheme, host, pathBase, fragment, options);
        }

        /// <summary>
        /// Gets a <see cref="LinkGenerationTemplate"/> based on the provided <paramref name="routeName"/> and <paramref name="values"/>.
        /// </summary>
        /// <param name="generator">The <see cref="LinkGenerator"/>.</param>
        /// <param name="routeName">The route name. Used to resolve endpoints. Optional.</param>
        /// <param name="values">The route values. Used to resolve endpoints and expand parameters in the route template. Optional.</param>
        /// <returns>
        /// A <see cref="LinkGenerationTemplate"/> if one or more endpoints matching the address can be found, otherwise <c>null</c>.
        /// </returns>
        public static LinkGenerationTemplate GetTemplateByRouteValues(
            this LinkGenerator generator,
            string routeName,
            object values)
        {
            if (generator == null)
            {
                throw new ArgumentNullException(nameof(generator));
            }

            var address = CreateAddress(httpContext: null, routeName, values);
            return generator.GetTemplateByAddress<RouteValuesAddress>(address);
        }
        
        private static RouteValuesAddress CreateAddress(HttpContext httpContext, string routeName, object values)
        {
            return new RouteValuesAddress()
            {
                AmbientValues = DefaultLinkGenerator.GetAmbientValues(httpContext),
                ExplicitValues = new RouteValueDictionary(values),
                RouteName = routeName,
            };
        }
    }
}
