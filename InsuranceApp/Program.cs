//import
namespace InsuranceApp
{


    internal class Program
    {
        // Import Random
        static Random random = new Random();

        // Global Variables
        static List<string> DEVICECATEGORY = new List<string>()
        {

            "Laptop", "Desktop", "Other (Such as Smart Phones or Drones)"

        };

        static int laptopCounter = 0, desktopCounter = 0, otherCounter = 0;
        static string priciestDeviceName = "";
        static float totalInsuranceCost = 0, MostExpensiveDevice = 0;

        // Methods and Functions

        // This method checks the category that the user has selected and displays an error message if the input is incorrect
        static int CheckDeviceCategory()
        {
            while (true)
            {
                Console.WriteLine("Choose Device Category:");
                for (int i = 0; i < DEVICECATEGORY.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {DEVICECATEGORY[i]}");
                }
                Console.WriteLine($"Enter the number of your choice (1-{DEVICECATEGORY.Count}): ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("ERROR: You cannot leave the space blank. Please enter the number for the category.");
                }
                else
                {
                    if (int.TryParse(input, out int categoryChoice))
                    {
                        if (categoryChoice >= 1 && categoryChoice <= DEVICECATEGORY.Count)
                        {
                            return categoryChoice;
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: You must enter a valid number for the category (between 1 and {DEVICECATEGORY.Count}).");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: You must enter a valid number for the category.");
                    }
                }
            }
        }

        // This method checks the cost of the devicr that the user has entered and checks if the input has any special characters or letters in in or the input is blank. Then it displays an error message if the input is incorrect

        static float CheckDeviceCost()
        {
            while (true)
            {
                Console.WriteLine("Enter the Device Cost:");
                string input = Console.ReadLine();

                // Check if the input is blank
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("ERROR: You must enter a value cannot leave a blank space.");
                }
                else
                {
                    // Check if the input contains only digits
                    bool isValidNumber = input.All(char.IsDigit);

                    if (!isValidNumber)
                    {
                        Console.WriteLine("Error: You must enter a valid number for the device cost.");
                    }
                    else
                    {
                        try
                        {
                            float deviceCost = float.Parse(input);

                            if (deviceCost >= 1)
                            {
                                return deviceCost;
                            }
                            else
                            {
                                Console.WriteLine("ERROR: The cost needs to be $1 or more.");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Error: You must enter a valid number for the device cost.");
                        }
                    }
                }
            }
        }

        // This method checks the cost of the devicr that the user has entered and checks if the input has any special characters or letters in in or the input is blank. Then it displays an error message if the input is incorrect
        static int CheckDeviceCount()
        {
            while (true)
            {
                Console.WriteLine("Enter the number of devices you want to add:");
                string input = Console.ReadLine();

                // Check if the input is blank
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("ERROR: You cannot leave the space blank. Please enter the Number of Devices");
                }
                else
                {
                    // Check if the input contains only digits
                    bool isNumber = input.All(char.IsDigit);

                    if (!isNumber)
                    {
                        Console.WriteLine("Error: You must enter a valid number for the number of devices.");
                    }
                    else
                    {
                        try
                        {
                            int numberOfDevices = Convert.ToInt32(input);

                            if (numberOfDevices >= 1)
                            {
                                return numberOfDevices;
                            }
                            else
                            {
                                Console.WriteLine("ERROR: You must enter at least 1 device.");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Error: You must enter a valid number for the number of devices.");
                        }
                    }
                }
            }
        }

        // This Method Checks the name of the device entered by the User
        static string CheckDeviceName()
        {
            string deviceName;
            while (true)
            {
                Console.WriteLine("Enter the Device's Name:");
                deviceName = Console.ReadLine();

                // Check if the name is blank
                if (string.IsNullOrWhiteSpace(deviceName))
                {
                    Console.WriteLine("ERROR: Device name cannot be blank.");
                    continue;
                }

                // Check for special characters (allow letters, numbers, and spaces)
                if (!deviceName.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)))
                {
                    Console.WriteLine("ERROR: Device name cannot contain special characters.");
                    continue;
                }

                // Capitalize ALL letters
                deviceName = deviceName.ToUpper();
                return deviceName;
            }
        }

        // Format All Dollar Values to display in a Dollar Format
        static string FormatToDollar(float amount)
        {
            return string.Format("${0:F2}", amount);
        }

        static string CheckProceed()
        {

            string proceed;
            while (true)
            {
                Console.WriteLine("Press <Enter> to add another Device information or type 'Stop' to quit");
                proceed = Console.ReadLine().ToUpper();

                if (proceed.Equals("") || proceed.Equals("STOP"))
                {
                    return proceed;
                }


                Console.WriteLine("Error: Invalid Input");

            }
        }

        // Create an ID for the devices
        static string CreateDeviceId(string deviceName, int category)
        {
            // Get the first letter of the device name
            string namePrefix = deviceName.Substring(0, 1).ToUpper();

            // Get a category identifier and make a prefix for each category
            string categoryPrefix = "";
            if (category == 1)
            {
                categoryPrefix = "LAP";
            }
            else if (category == 2)
            {
                categoryPrefix = "DES";
            }
            else
            {
                categoryPrefix = "OTH";
            }

            // Generate a random 4-digit number
            int randomNumber = random.Next(1, 9999);

            // Combine the parts to create the unique ID
            string deviceId = $"{namePrefix}-{categoryPrefix}-{randomNumber}";

            return deviceId;
        }

        // OneDevice Method
        static void OneDevice()

        {
            string deviceName; 
            int category, deviceCount; 
            float deviceCost, totalDeviceCost, deviceInsurance = 0; ;

            // Enter the Device name
            deviceName = CheckDeviceName();

            //Enter number of devices
            deviceCount = CheckDeviceCount();

            //Enter Device Cost
            deviceCost = CheckDeviceCost();

            // Choose category of device
            category = CheckDeviceCategory();


            // Counts how many of each device are entered and stored in this method
            if (category == 1)
            {
                laptopCounter += deviceCount;
            }
            else if (category == 2)
            {
                desktopCounter += deviceCount;

            }
            else
            {
                otherCounter += deviceCount;
            }


            // Calculate the Insurance
                if (deviceCount >= 5)
                {
                    deviceInsurance = (5 * deviceCost) + ((deviceCount - 5) * deviceCost * 0.90f);

                }

                else
                {
                    deviceInsurance = deviceCount * deviceCost;
                }  

                totalInsuranceCost += deviceInsurance;


            // Call the Create Device method and Generate the Device Id
            string deviceId = CreateDeviceId(deviceName, category);

            // Calculate the Total Cost of the Devices
            deviceCount = deviceCount;
            deviceCost = deviceCost;
            totalDeviceCost = deviceCount * deviceCost;

            Console.WriteLine("<------------------------------->");

            Console.WriteLine($"Device Name:{deviceName}");
            Console.WriteLine($"Device ID: {deviceId}");
            Console.WriteLine($"Total Cost for {deviceName}'s is {deviceCost} x {deviceCount} = {FormatToDollar(totalDeviceCost)}");


            // Calculate the change in value over a 6 month period (Cost of Device X 0.95) repeat 6 times
            Console.WriteLine($"Value of {deviceName} over a period of 6 Months");
            Console.WriteLine("Month\t value loss");

            float DeviceMarkdown = deviceCost;
            for (int month = 0; month < 6; month++)
            {
                DeviceMarkdown = DeviceMarkdown * 0.95f;
                DeviceMarkdown = (float)Math.Round(DeviceMarkdown, 2);
                Console.WriteLine($"{month + 1}\t{DeviceMarkdown}");

            }

            // To Find the most expesive device
            if (deviceCost > MostExpensiveDevice)
            {
                MostExpensiveDevice = deviceCost;
                priciestDeviceName = deviceName;
            }

        }

        // Main method
        static void Main(string[] args)
        {
            string proceed = "";
            while (proceed.Equals(""))
            {
                // Call OneDevice Method
                OneDevice();

                proceed = CheckProceed();
            }
           

            // Display the Summary (Number of Devices for each category, the total cost for the insurance, and the most expensive device)
            Console.WriteLine($"The number of Laptops:{laptopCounter}");
            Console.WriteLine($"The number of Desktops:{desktopCounter}");
            Console.WriteLine($"The number of Other Devices:{otherCounter}");

            Console.WriteLine($"The total value for insurance:{FormatToDollar(totalInsuranceCost)}");
            Console.WriteLine($"The most expensive device is: {priciestDeviceName} costing {FormatToDollar(MostExpensiveDevice)}");

        }


    }





}









