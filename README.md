# CoreBackend

The file where we make all the settings in our Identity Project is our `Config.cs` file.

In `Config.cs`,

`public static IEnumerable<Client> Clients =>` How many Clients will use these APIs.


`public static IEnumerable<IdentityResource> IdentityResources =>` Here we determine what information about the user will be in the token.


`public static IEnumerable<ApiScope> ApiScopes =>` This is where we define permissions such as read and write.


 We also have APIResources, which will be the place where we can define the authorizations related to these APIs if there are how many APIs there are.
 There will be 2 APIs in this project, so we defined 2 API Resources.

`` 
