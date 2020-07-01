// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace Idp
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("api1.weather.scope"),
                new ApiScope("api1.test.scope"),
                //new ApiScope("scope2"),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("api1","#api1")
                {
                    //!!!重要
                    Scopes = { "api1.weather.scope", "api1.test.scope" }
                },
                //new ApiResource("api2","#api2")
                //{
                //    //!!!重要
                //    Scopes = { "scope2"}
                //},
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "postman client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("postman secret".Sha256()) },

                    AllowedScopes = { "api1.weather.scope", "api1.test.scope" }
                },
            };
    }
}