# PersonalJournalApp
This is a Personal Journal application where users can keep track of their daily life.

### Check-in 1 Notes
- I have created the class library for my Model classes.
- I have created a MVC project for the Web App.
- I have created a Web API project.
- I have scaffolded all the controllers for both the Web App and API.
- I have modified the defaulted scaffolded pages and refined the UI.
- **As part of my ancillary goals, I used Azure to host my website, database and web API**.
- I have created a MS-Test project for my initial integration testing

### Check-in 2 Notes
- **As part of my ancillary goals, I have added a location field with auto-complete functionality which will access the Google Places API using an API Key.**
Note: In case this functionality not working in the local server, try using the Azure hosted website.

- **As part of my ancillary goals, I modifed the index page to add extra functionality aside from the default ones.**
  - I added a search functionality for the journal entries where users can search a specific entry using the title
  - I added a sort functionality to sort the journal entry dates by either ascending or descending order.
  
- **As part of my ancillary goals, I have started adding the speech-to-text functionality to populate subsection texts.**
  - I am still finalizing the speech to text part, I am thinking to have a single microphone button for all the text fields to simplify the logic instead of having to switch the mic on and off for different subsection texts.   

- I have added few integration tests for the CRUD operations. The test for the Create Journal Entry scenario is still pending.
- I have fixed some issues with the app

### Check-in 3 Notes

- Finalize the integration tests for the CRUD operations
- Fix issues with speech to text recognition
- Add date filter in the index page and modify custom CSS for the filter components
- Finalize and add the speech-to-text functionality for all the long text fields in Create/Edit Journal Entries
- As an added feature, I customized the home page and added an API call to fetch random quotes from a public API (https://nodejs-quoteapp.herokuapp.com/quote/3)

### Homepage Screenshot
![image](https://user-images.githubusercontent.com/22863383/164139370-b1132a27-4ee9-479a-86d2-7dbb47d49367.png)



