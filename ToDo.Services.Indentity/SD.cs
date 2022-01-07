using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace ToDo.Services.Indentity
{
    public static class SD
    {
        public const string Administration = "Admin";
        public const string User = "User";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =
            new List<ApiScope>
            {
                //new ApiScope("todo", "ToDo Server"),
                new ApiScope("userManagement", "User Management Server"),
                new ApiScope(name:"read", displayName:"Read your data."),
                new ApiScope(name:"write", displayName:"Write your data."),
                new ApiScope(name:"delete", displayName:"Delete your data.")
            };

        public static IEnumerable<Client> Clients =
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"read","write","profile"}
                },
                // new Client
                //{
                //    ClientId = "todo",
                //    ClientSecrets = {new Secret("secret".Sha256())},
                //    AllowedGrantTypes = GrantTypes.Code,                  
                //    RedirectUris={ "https://localhost:7096/signin-oidc" },
                //    PostLogoutRedirectUris = { "https://localhost:7096/signout-callback-oidc" },
                //    AllowedScopes = new List<string>
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Email,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "todo"
                //    }
                //},
                 new Client
                 {
                    ClientId = "userManagement",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris={ "https://localhost:7096/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:7096/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        "userManagement"
                    }
                 }
            };

    }
}
