using System.Transactions;
using Weapon_Creator;

string command = string.Empty;
List<Weapon> createdWeapons = new List<Weapon>();

Console.WriteLine("|=====| Welcome to the Weapon Creation Program Ver 1.0|=====|");
Console.WriteLine("Press any key to continue: ");
Console.ReadKey();

Console.Clear();


do
{
    MenuShow();
    command = Console.ReadLine()!;
    Console.Clear();
    switch (command.ToLower())
    {
        case "create":
            {
                createdWeapons.Add(CreateWeapon());
                break;
            }
        case "delete":
            {
                int indexWeapon;

                do
                {
                    Console.WriteLine("Enter the index of the weapon you want to edit:");
                    indexWeapon = int.Parse(Console.ReadLine());
                    if (indexWeapon - 1 < 0 || indexWeapon - 1 > createdWeapons.Count - 1)
                    {
                        Console.WriteLine("Invalid index!");
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        createdWeapons.RemoveAt(indexWeapon-1);
                        Console.WriteLine("The weapon has been deleted!");
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                }
                while (indexWeapon - 1 < 0 || indexWeapon - 1 > createdWeapons.Count - 1);

                

                break;

            }
        case "edit":
            {
                int indexWeapon;
               
                do
                {
                    Console.WriteLine("Enter the index of the weapon you want to edit:");
                    indexWeapon = int.Parse(Console.ReadLine());
                    if (indexWeapon-1 < 0 || indexWeapon-1 > createdWeapons.Count - 1)
                    {
                        Console.WriteLine("Invalid index!");
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        break;
                    }                
                }
                while (indexWeapon-1 < 0 || indexWeapon-1 > createdWeapons.Count - 1);
                var selectedWeapon = createdWeapons[indexWeapon-1];

                Console.WriteLine($"Current name: {selectedWeapon.Name}");
                Console.WriteLine("New name: ");
                string newName = Console.ReadLine();
                selectedWeapon.Name = newName;

                Console.WriteLine($"Current type: {selectedWeapon.WeaponType}");
                Console.WriteLine("New type: ");
                string newWeaponType = Console.ReadLine();
                selectedWeapon.WeaponType = newWeaponType;

                Console.WriteLine($"Current damage: {selectedWeapon.Damage}");
                Console.WriteLine("New damage: ");
                int newDamage = int.Parse(Console.ReadLine());
                selectedWeapon.Damage = newDamage;

                Console.WriteLine($"Current description: {selectedWeapon.Description}");
                Console.WriteLine("New description: ");
                string newDescription = Console.ReadLine();

                if (newDescription == "")
                {
                    newDescription = "No description!";
                }
                selectedWeapon.Description = newDescription;

                Console.WriteLine("You have successfully edited your weapon!");
                Console.WriteLine("Press any key to continue: ");
                Console.ReadKey();
                Console.Clear();
                break;
            }
        case "show":
            {
                for (int i = 0; i < createdWeapons.Count; i++)
                {
                    var weapon = createdWeapons[i];
                    Console.WriteLine($"{i+1}. {weapon.Name}");
                }
                break;
            }
        case "view": 
            {
                int indexWeapon;

                do
                {
                    Console.WriteLine("Enter the index of the weapon you want to edit:");
                    indexWeapon = int.Parse(Console.ReadLine());
                    if (indexWeapon-1 < 0 || indexWeapon-1 > createdWeapons.Count - 1)
                    {
                        Console.WriteLine("Invalid index!");
                        Console.WriteLine("Press any key to continue!");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        break;
                    }
                }
                while (indexWeapon-1 < 0 || indexWeapon-1 > createdWeapons.Count - 1);
                var selectedWeapon = createdWeapons[indexWeapon-1];

                Console.WriteLine($"Weapon name: {selectedWeapon.Name}");
                Console.WriteLine($"Weapon type: {selectedWeapon.WeaponType}");
                Console.WriteLine($"Weapon damage: {selectedWeapon.Damage}");
                Console.WriteLine($"Weapon Description: {selectedWeapon.Description}");
                Console.WriteLine("Press any key to continue: ");
                Console.ReadKey();
                Console.Clear();

                break;
            }
        case "exit":
            {
                Console.WriteLine("Have a nice day!");                
                break;
            }
        default:
            {
                Console.WriteLine("Unknown command. Press any key and try again!");
                Console.ReadKey();
                Console.Clear();
                break;
            }

    }

}
while (command.ToLower() != "exit");

static Weapon CreateWeapon()
{
    Console.WriteLine("What is the name of the weapon: ");
    string nameWeapon = Console.ReadLine();
    Console.WriteLine("What is the type of the weapon: ");
    string typeWeapon = Console.ReadLine();
    Console.WriteLine("What is the damage of the weapon: ");
    int damageWeapon = int.Parse(Console.ReadLine());    
    string descriptionWeapon = "No description";
    string descAnswer = string.Empty;

    while (descAnswer != "yes" || descAnswer.ToLower() != "no")
    {
        Console.WriteLine("Do you need description: Yes or No?");
        descAnswer = Console.ReadLine();
        if (descAnswer.ToLower() == "yes")
        {
            Console.WriteLine("Write your description: ");
            descriptionWeapon = Console.ReadLine();
            Console.WriteLine("The description has been added!");
            Console.WriteLine("Press any key to continue!");
            Console.ReadKey();
            Console.Clear();
            break;
        }
        else if (descAnswer.ToLower() == "no")
        {
            Console.WriteLine("Your item has no description!");
            Console.WriteLine("Press any key to continue!");
            Console.ReadKey();
            Console.Clear();
            break;

        }
        else
        {
            Console.WriteLine("Wrong input! Try again!");
            Console.WriteLine("Press any key to continue!");
            Console.ReadKey();
            
        }
    }
       
    

    Weapon weapon = new Weapon
    {
        Name = nameWeapon, Damage = damageWeapon, WeaponType = typeWeapon, Description = descriptionWeapon
    };
    return weapon;

}


static void MenuShow()
{
    Console.WriteLine("=============================");
    Console.WriteLine("| What would you like to do: |");
    Console.WriteLine("=============================");
    Console.WriteLine("|   {Create} a new weapon   |");
    Console.WriteLine("=============================");
    Console.WriteLine("| {Edit} an existing weapon |");
    Console.WriteLine("=============================");
    Console.WriteLine("|{Show} all existing weapons|");
    Console.WriteLine("=============================");
    Console.WriteLine("| {View} an existing weapon |");
    Console.WriteLine("=============================");
    Console.WriteLine("|{Delete} an existing weapon|");
    Console.WriteLine("=============================");
    Console.WriteLine("|    {Exit} the program     |");
    Console.WriteLine("=============================");
}