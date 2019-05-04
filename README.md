C# project includes an UI that helps you add new data (Students enrolling for an event in this example).

Functionalities:
 
ADD:

 - Select which event you want to enroll.
 - Select which college the student is from.
 - UI then remembers the college and shows you in the dropdown.
 - The UI generates an incremental enrollment number when a new student has been added.

UPDATE:

 - Lookup using enrollment number to edit the details. 
 - UI also displays the data entered. 
 - Filter the data on the basis of Name, Event, College, Enrollment No.
 
BACKUP: 

 - Enables you to create a backup of all the data and store the zip in your local.
 - Manage the backup already created. 
 
 DATABASE:
  - The store module uses sqlite database. I chose it because it was portable and light to use.
  

Information:
 Melange is the name of the event in my college that used this software in 2015 (My final year).
 
I used Visual Studio to create the project. I published it and created an installer. Executable can be run separately from inside the folder without running the installer.
 
