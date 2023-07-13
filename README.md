# CoreBackend

The file where we make all the settings in our Identity Project is our `Config.cs` file.

In `Config.cs`,

`public static IEnumerable<Client> Clients =>` How many Clients will use these APIs.


`public static IEnumerable<IdentityResource> IdentityResources =>` Here we determine what information about the user will be in the token.


`public static IEnumerable<ApiScope> ApiScopes =>` This is where we define permissions such as read and write.


 We also have APIResources, which will be the place where we can define the authorizations related to these APIs if there are how many APIs there are.
 There will be 2 APIs in this project, so we defined 2 API Resources.

[`http://localhost:5001/.well-known/openid-configuration` ]

`

    "issuer": "http://localhost:5001",
    
    "jwks_uri": "http://localhost:5001/.well-known/openid-configuration/jwks",
    
    "authorization_endpoint": "http://localhost:5001/connect/authorize",
    
    "token_endpoint": "http://localhost:5001/connect/token",
    
    "userinfo_endpoint": "http://localhost:5001/connect/userinfo",
    
    "end_session_endpoint": "http://localhost:5001/connect/endsession",
    
    "check_session_iframe": "http://localhost:5001/connect/checksession",
    
    "revocation_endpoint": "http://localhost:5001/connect/revocation",
    
    "introspection_endpoint": "http://localhost:5001/connect/introspect",
    
    "device_authorization_endpoint": "http://localhost:5001/connect/deviceauthorization",


` 
https://github.com/FluentValidation/FluentValidation/issues/1965




`` 
