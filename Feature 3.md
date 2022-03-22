# Authorization in .Net 6

## Option 1

The first option that can be used to add authorization to our api and its endpoint is to take the local approach. This would involve storing any user information, like username and password, in a user table with PostgreSQL. We could then check the id of the current user against our database in order to determine whether they should have access to our program. 

## Option 2

While we could store the more sensitive user information ourselves, it is always a better option to use a service like Auth0 in order to better secure this data. In this case we use an access token given to the user on them logging into Auth0's service in order to determine their access permissions for our api. By adding the Authorize attribute to our controllers' endpoints and adding some authentication to our launch pipeline (in Program.cs) we can ensure that only users we wish to have access can use these features.