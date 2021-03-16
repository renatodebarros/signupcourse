# Sign-up System
## Architectural overview
![alt text](https://github.com/renatodebarros/signupcourse/blob/main/courseSignup.jpg)
## Business Solution
### Macro Solution
![alt text](https://github.com/renatodebarros/signupcourse/blob/main/bpm.png)

### Business Process Flow
 The administrator register the course, filling the max enrollments (maximum capacity of students in the course). After this assign the lecturer will be teaching the course.
 In the web portal the student will be signup the course, in this process with the student hasn't the account, the system fires the create new account.
 In the next step the system will be check if the maximum enrollments is the equals to the enrollmenteds, if has quantity available assign the student to the course, increase the enrollmenteds quantity and finally send the confirmation e-mail. Otherwise, send the notification e-mail about the course isn't more available.

### What need test
 First Step - create and list course
 Second Step - create and list lectures
 Third Step - Try signup course, when the course isn't not created yeat.
 Fourth Step - Try signup course (with course created on the first step).
 Fifth Step - Signup course until the limit of maximum enrollments is reached.
 
 ### Tools Libraries used
 Tools used:
 Visual Studio 2019 comunite;
 
 Library from Visual Studio 2019:
 Asp .net core 3.1
 
 I used the follow libraries from nuget:
  
 Autofac;
 Automapper (with autof acextension);
 MediatR (with autof acextension);
 
 ## Business Improvement
 
 In the process flow I suggested that the course could be the available is some week days and respective hours, time duration of course and time per day.
 The lecturer could be assigned to one or more courses if has skill.
 Create the ratting about the course and lecturer.
 
 
