# MovieRental

# Create a C# class

##	Name: Customer
###	Namespace: Developer.Interview.Coding
###	Purpose:
            Represents a customer
            Demonstrates your ability to code a simple class
            Hint: use the stored procedures you created before
###	Imports:
            System
            System.Data
            System.Data.SqlClient
## 	Class Characteristics
	Cannot be inherited
	Class must implement IDisposable

##  Properties
	LastName – string – read-only
	FirstName – string – read-only
	Id - int – read-only

##	Attributes
	LName – string – protected
	FName - string – protected
	_connection – SqlConnection - private

##	Methods
###	Customer
#### Purpose
     Creates a new instance of a customer and loads it with data from a database.
#### Parameters
	int id
#### Code\Pseudo-code
	Validate the id
	>= 0
	Initialize the connection variable
	Use a SqlCommand object to execute the  get_customer_by_id stored procedure
	If the customer is not found, raise an error
	Set internal the variables
### GetActiveRentals
#### Purpose
	Retrieves a DataSet containing the customer’s videos (hint: use a get_active_rentals stored procedure)
#### Returns
	DataSet
#### Parameters
	@p_customer_id
#### Code\Pseudo Code
	Execute the stored procedure
	If there are no records returned, return null
	If there are record, return the dataset
#### Dispose
##### Purpose
	Cleans up the database connection (if opened)
	Suppresses finalization
##### Returns
    Nothing
