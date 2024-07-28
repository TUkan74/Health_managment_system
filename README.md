# Project: Healthcare Management System in Windows Forms

## Functionality

1. **User Authentication and Authorization:**
   - User authentication and authorization.
   - Different levels of access:
     - **Doctors:** Access to all patient records, ability to create and update records, prescribe medications.
     - **Nurses:** Access to all patient records, ability to update records (e.g., add treatment notes), cannot prescribe medications.
     - **Patients:** Access only to their own records, ability to view their medical history and prescriptions.

2. **Patient Record Management:**
   - Create, read, update, and delete (CRUD) patient records.
   - Each record includes basic patient information (name, surname, date of birth, address, contact information).
   - Ability to attach medical history (diagnoses, treatments, visit dates).

3. **Prescription and Medication Management:**
   - Doctors can create and update prescriptions for patients.
   - Medication records include drug name, dosage, usage instructions, and prescription date.
   - Patients can view their current and past prescriptions.

4. **Medical History Tracking:**
   - Record all medical events and patient treatment history.
   - Ability to add notes and examination results to individual records.
   - History of all prescribed medications and treatment procedures.

## Technical Solution

1. **Architecture:**
   - **Backend:** Using C# with Windows Forms to create a desktop application.
   - **Database:** SQL Server for data storage.

2. **Data Access:**
   - Use Entity Framework Core for ORM (Object-Relational Mapping) to interact with the database.
   - Define models for each entity (patients, records, prescriptions, users).

3. **Interesting C# Features:**
   - Use asynchronous methods (async/await) to improve application performance.
   - Implement dependency injection to manage component dependencies.
   - Use Data Annotations for data validation.

4. **Desktop Application:**
   - The application will run on Windows desktop devices.
   - Use Windows Forms to create the user interface.

## Detailed Functionality

1. **User Authentication:**
   - Login window with the option to register new users.
   - Upon login, users are assigned appropriate roles (doctor, nurse, patient) based on their permissions.

2. **Patient Record Management:**
   - Form to add a new patient with all necessary information.
   - List of patients with search and filter capabilities.
   - Detailed view of a patient with the ability to edit information and add medical history.

3. **Prescription and Medication Management:**
   - Form to add a new medication prescription.
   - List of a patient’s current and past prescriptions.
   - Ability to edit and cancel prescriptions.

4. **Medical History Tracking:**
   - Display a chronological list of all medical events for a patient.
   - Ability to add notes and examination results to individual records.
   - Overview of prescribed medications and treatment procedures.
