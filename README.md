# VendingMachine

* How to use the Vending Machine
  * Click on the coin images to insert coins
  * Click on the price of a product to purchase it after inserting enough money
  * Click on the product dispensing box to retrieve your product
  * Click on the coin dispensing box to retrieve your change or refund

* Assumptions
  * Coins Inserted by the customer are not added to coins available to the machine to make change
  
* Starting Conditions
  * The number of each product and coin loaded at start-up is a constant initially set to 2
    * Therefore 2 items of each product are loaded into the machine on start-up
    * Therefore 2 of each coin type are loaded into the machine on start-up
  
* Refill
  * Refilling products will ensure exactly 2 of each product are loaded into the machine (based on the constant)
  * Refelling the coins will ensure exactly 2 of each coin are loaded into the machine (based on the constant)
  
* Requires
  * .NET Framework 4.5
