using Patient_and_Pet_Management.Models;
using Patient_and_Pet_Management.Services;

// List to save all patients
List<Patient> patients = [];

// Show welcome message
Console.WriteLine("""

                  Welcome to the new patient system

                  Available options:
                  1. List all patients
                  2. Register new patient
                  3. Search patient by name
                  4. Exit

                  """);

// Ask for the option number
List<int> availibleOptions = [1, 2, 3, 4];
int option = 0;

// Main loop
while (option != 4)
{
    //Ask for an option
    while (true)
    {
        try
        {
            Console.Write("Please enter the option number (1-4): ");
            option = int.Parse(Console.ReadLine() ?? string.Empty);

            if (!availibleOptions.Contains(option))
            {
                Console.WriteLine("Invalid option");
                continue;
            }

            break;
        }
        catch (Exception err)
        {
            Console.WriteLine("Invalid option");
            continue;
        }
    }

    // Menu options
    switch (option)
    {
        // List all patients
        case 1:
            Console.WriteLine("-- List all patients --");
            PatientService.ListPatients(patients);
            break;

        // Register a new patient
        case 2:
            Console.WriteLine("-- Register a new Patient --");
            // Ask for all patient info
            Console.WriteLine("Please write the patient name: ");
            string patientName = Console.ReadLine() ?? String.Empty;
            int patientAge;
            while (true)
            {
                try
                {
                    Console.WriteLine("Please write the patient age: ");
                    patientAge = int.Parse(Console.ReadLine() ?? String.Empty);

                    if (patientAge < 0 || patientAge > 120)
                    {
                        Console.WriteLine("Invalid age (0 - 120)");
                        continue;
                    }

                    break;
                }
                catch (Exception err)
                {
                    Console.WriteLine("Invalid age");
                    continue;
                }
            }

            Console.WriteLine("Please write the patient symptoms ");
            string patientSymptoms = Console.ReadLine() ?? String.Empty;

            // Create new patient object
            Patient newPatient = new Patient(patientName, patientAge, patientSymptoms);

            // Register patient and save new patient list
            patients = PatientService.RegisterPatient(patients, newPatient);
            break;
        case 3:
            Console.WriteLine("-- Search a patient by name --");
            // Ask for all patient name
            Console.WriteLine("Please write the patient name: ");
            string name = Console.ReadLine() ?? String.Empty;
            PatientService.SearchPatient(patients, name);
            break;
    }
}

Console.WriteLine("We hope see you soon!");