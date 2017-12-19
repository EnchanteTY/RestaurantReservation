# Online Restaurant Reservation

<h2>
  This project is designed for a fictional Chinese Restaurant in which owner would like to extend their business online and automate the reservation process.
</h2>

<h4>
  Current features include:
</h4>
<ul>
 <li>CRUD action for the dish menu</li>
 <li>Online ordering and table reservation for desired meal date and time</li>
 <li>Order and serve list management</li>

</ul>
<h4> Tobe Improved </h4>
<ul>
  <li><h5>Update cart button on the checkout page</h5></li>
Problem: Update button need to be clicked after changing dish size and table to update total price, if it is not clicked, total price would not be updated
<br/>Suggested Solution: Write a web api to calculate total price and use jquery to invoke it
 <li><h5>Update meal time validation</h5><li>
 Problem: if the selected time is fully reserved, user only can get a validation message after hitting the save button
 <li><h5>Owner role initialization</h5></li>
    Problem: the owner account is currently initialize in configuration, not safe enough
 <li><h5>Refactoring<li>
    <ol>
      <li> Using Unit Of Work Pattern</li>
       Problem: Currently using repository pattern only, the pattern is violated since there is a save method in each repository
      <li>Better separation in Business Layer and Data Access Layer</li>
       Problem: Cart Entity is not persistence-ignorant
       <li>DRY </li>
   	Problem: dish image mapping block is duplicated
    </ol>

   
 </ul>
 <h4>Features not implemented but wish to include:</h4>
 <ul>
  <li>IDiscount Interface</li>
   <li>IsSeasoned field for dish (so admin can promote certain dishes on particular festival)</li>
  <li>Add external login service</li>
   <li>Enable order cancellation </li>
 </ul>


