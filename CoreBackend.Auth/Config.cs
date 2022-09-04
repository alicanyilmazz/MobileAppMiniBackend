// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace CoreBackend.Auth
{
    public static class Config
    {
        public static IEnumerable<ApiResource> apiResources => new ApiResource[]
        {
             new ApiResource("resource_movie_api")
             {
                 Scopes = { "api_movie_fullpermission" }
             },
             new ApiResource("resource_photo_api")
             {
                 Scopes = { "api_photo_fullpermission" }
             },
             new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("api_movie_fullpermission","Movie API has all permissions."),
                new ApiScope("api_photo_fullpermission","Photo API has all permissions."),
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
            };
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            { 
              new IdentityResources.Email(),
              new IdentityResources.OpenId(),
              new IdentityResources.Profile(),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "MobileClient_CC",
                    ClientName = "Mobile Client Credentials",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedScopes = { IdentityServerConstants.LocalApi.ScopeName }
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "MobileClient_CICSEP",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    //RedirectUris = { "https://localhost:44300/signin-oidc" },
                    //FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    //PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                    // AccessToken ile RefreshToken in da donmesini istiyorsak True olarak Set etmeliyiz.
                    AllowOfflineAccess = true, 
                    // Token almak için email , Id , Profile , gibi hangi izinlerin gerektiğini tanımladık. Kısaca bu Client hangi izinlere sahip olacak onu belirledik.
                    AllowedScopes = { IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile, "api_movie_fullpermission", "api_photo_fullpermission",IdentityServerConstants.StandardScopes.OfflineAccess},
                    // AccessToken ın ömrünü verdik.
                    AccessTokenLifetime = 600,
                    // Mesela RefreshToken ın ömrünü 2 ay belirtmişsem bunu 2 ay boyunca kullanabileyim. (ReUse)
                    // Eğerki bir kere kullanmak istiyorsam OneTimeOnly olarak belirtmeliyiz.
                    RefreshTokenUsage = TokenUsage.ReUse,

                    RefreshTokenExpiration = TokenExpiration.Absolute, // .Sliding olarak da verebiliriz -- Aşağıda ise süre tanımlamalarını yapıyoruz.
                    //SlidingRefreshTokenLifetime = (int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds, // 2 aylık süre içerisinde her RefreshToken aldıgınızda RefreshToken ın ömrünü 2 ay daha uzatır.
                    AbsoluteRefreshTokenLifetime = (int)(DateTime.Now.AddDays(60)-DateTime.Now).TotalSeconds,  // 2 aylık süre belirlediysek bu süre sonunda RefreshToken gecerliliği biter.                 
                },
            };
    }
}