Below are the improvements I made in the project.

1. Implemented a Repository pattern in Web API  which is intended to create the abstraction layer between Data Acess and Business logic layer.
2. Developed the Data Access layer based on a predefined data model with the Entity framework approach. With the entity framework, I retrieved all products
   in the POCO model i.e product and Product option model
   tracks changes within these models and save the changes asynchronously with saveChangesAsync method
3. Introduced a Dependency injection framework which helped to achieve the loosely coupled dependencies of repository a service layers. 
   Used Autofac container to manage dependencies between classes which helps applications stay easy to change as they grow in size and complexity.
4. Performed unit testing for service layer by mocking repository using Moq and NUnit frameworks
5. Moved the connection string to config file i.e Web.config which helps to change the connection string properties as per the environment