This program is essentially modeled after and a VERY SIMPLIFIED version of familysearh.org.
You can use it to save basic vital details/life events (names, birth, marriage, death), 
ordinances information, and sources (for things like census record, birth certificates, etc.)

The following is a description of each menu item to give you an idea about what to expect from 
this program:

Main Menu
It begins with a simple menu to create a new record person/ancestor or you can load one from a file.
After the initial creation of a person record (which entails adding basic vital/event details),
or if the record is loaded from a file, you are taken to another menu which is the main 
working menu. I call it the Person Menu in the code. 

Person Menu
From this menu, you can Add/Edit basic vitals/event details, ordinances, and 
submit new sources (I did NOT include an option to edit or delete these souces).
It also includes options to display a couple of reports; one with full details, 
the other with simple temple card information. There is also an option to Save.

When saving, the file name and location are chosen in code and not by the user. 
The file name is a concatenation of Given Name and Last Name. If the file name already 
exists the program will add a number (ascending as high as needed) to make the name unique. 
The save folder is called Ancestors which is in the same location as the program itself. Note, if 
the Ancestors folder does not already exists, it will be created. 

**Note: I have included 3 sample .txt files that can be used with this program.

When exiting this menu, if changes have been made the user will be asked it they want to
save changes before exiting back to the Main Menu.

Ordinances Menu
All types of ordinances will be listed with the date, location and other details if applicable, 
and the option will be given to select one to add/edit. If no information has previously been 
recorded, the ordinance will display with a note saying "Not Complete". 

This is one area where I used Polymorphism. Sealing to Spouse ane Sealing to Parents both have 
additional attributes and therefore require different methods to return display results for them. 
Baptism, Confirmation, Initiatory and Endowment all use the base class function to return a display
string but Sealing to Spouse and Sealing to Parents have additional attributes to include in the
return string so they override the base class function and use their own.

Vitals and Events Menu
This one functions very much like the Ordiance Menu but the information stored is different.
Given Name, Last Name and Sex are simply attributes in the Person class as there is no additional
information or functionality required for them. Birth, Marriage, and Death are all similar but 
have unique attributes and methods so they are each included as a child class in the base, abstract
Event class.

Submit Source
This option, loads a display of all the previous sources and prompts for information on the new
source. Any or all the infromation can be left blank and the program will handle each scenario.
If all the details are blank the new source won't be added.

Display Full Details
This report displays all the details for the person so that the user can view all the information
at one time.

Display Temple Card Details
This report just displays the person's name, the ordinace info and the current date/time.

**NOTE: I have included some basic error handling for incorrect user input, but it is basic
and it is still possible to create problems. As it was not in the scope of the assignment
to account for all errors, I did not spend the extra time to work through all such 
possibilities.


