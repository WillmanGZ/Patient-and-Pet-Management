using Patient_and_Pet_Management.Models;

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
        //List all patients
        case 1:
         

            break;
        case 2:
            break;
        case 3:
            break;
    }
}