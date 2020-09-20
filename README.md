The attached project is a poorly written products API.

Your job, should you choose to accept it, is to make changes to this project to make it better. Simple. There are no rules, changes are not limited to pure refactors.

There is no time limit (we all work at different speed!), but as a guideline, we recommend spending between 2-4 hours on the exercise. 

Please consider all aspects of good software engineering (including but not limited to design, reliability, readability, extensibility, quality) and show us how you'll make it #beautiful.

Once completed, send back your solution in a zip file (source code only please to keep the zip small) and include a new README describing the improvements you have made and the rationale behind those decisions. 

Good luck!

## Instructions

To set up the project:

* Open project in VS.
* Restore nuget packages and rebuild.
* Run the project.

There should be these endpoints:

1. `GET /products` - gets all products.
2. `GET /products?name={name}` - finds all products matching the specified name.
3. `GET /products/{id}` - gets the project that matches the specified ID - ID is a GUID.
4. `POST /products` - creates a new product.
5. `PUT /products/{id}` - updates a product.
6. `DELETE /products/{id}` - deletes a product and its options.
7. `GET /products/{id}/options` - finds all options for a specified product.
8. `GET /products/{id}/options/{optionId}` - finds the specified product option for the specified product.
9. `POST /products/{id}/options` - adds a new product option to the specified product.
10. `PUT /products/{id}/options/{optionId}` - updates the specified product option.
11. `DELETE /products/{id}/options/{optionId}` - deletes the specified product option.

All models are specified in the `/Models` folder, but should conform to:

**Product:**
```
{
  "Id": "01234567-89ab-cdef-0123-456789abcdef",
  "Name": "Product name",
  "Description": "Product description",
  "Price": 123.45,
  "DeliveryPrice": 12.34
}
```

**Products:**
```
{
  "Items": [
    {
      // product
    },
    {
      // product
    }
  ]
}
```

**Product Option:**
```
{
  "Id": "01234567-89ab-cdef-0123-456789abcdef",
  "Name": "Product name",
  "Description": "Product description"
}
```

**Product Options:**
```
{
  "Items": [
    {
      // product option
    },
    {
      // product option
    }
  ]
}
```
