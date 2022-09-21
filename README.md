# Micros
## Functionality

## Balance Controller
### `GetBalance()` Will let you to get current balance
## Logs Controller
### `GetAll()` Will let you to get all logs for balance changes
### `GetLogsByMonth(string month, string year)` Will let you to get information about changes that happened in particular month. month and year is to define needed month for a result
### `GetById(string id)` Will let you to get one record by it's id
## Transactions Controller 
### `GetAll()` Will let you get all transactions
### `GetAllByCategory(string category)` Will let you to get records by this particular category
### `GetAllByType(string type)` Will let you to get records by type
### `GetAllByMonth(string month, string year)` Will let you to get information about changes that happened in particular month. month and year is to define needed month for a result
### `PostTransaction(string type, string category, double amount, string comment, string? dateTime)` Will create a transaction and add certain amount to current balance
### `AddCategories()` Is a helper method to add all categories that should be added

