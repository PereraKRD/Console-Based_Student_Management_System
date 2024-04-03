using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    public class SelectUserMenu
    {
        public int ColPos { get; set; }
        public int RowPos { get; set; }
        public int SelectedItem { get; set; }
        public List<MenuItem> Items { get; set; } // creating a list of type MenuItem. And the name of the list is Items

        public SelectUserMenu()
        { // overloaded ctor
            ColPos = 10;
            RowPos = 5;
            SelectedItem = 0;
            Items = new List<MenuItem> // enetering data into the list.
            {
                new MenuItem("  M O D I F Y   U S E R",true),
                new MenuItem("  A D D   M O D U L E S", false),
                new MenuItem("R E M O V E   M O D U L E S", false),
                new MenuItem("  D E L E T E   U S E R", false),
                new MenuItem("        B A C K", false)
            };
        }

        public void DisplayUserMenu(Student student,List<Student> students)
        {
            bool go = true;
            while (go)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor= ConsoleColor.Black;
                Console.Clear();
                Console.SetCursorPosition(46, 0);
                Console.WriteLine("--U S E R   M E N U--"); // Name of the main menu
                for(int i =0;i<Items.Count;i++)
                {
                    Console.SetCursorPosition((ColPos+30),(RowPos+i*2));
                    if (Items[i].IsSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(Items[i].Title);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine(Items[i].Title);
                    }
                }

                var key = Console.ReadKey();
                if(key.Key == ConsoleKey.DownArrow) // arrow key action definition
                {
                    Items[SelectedItem].IsSelected = false;
                    SelectedItem = (SelectedItem+1)%Items.Count;
                    Items[SelectedItem].IsSelected = true;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Items[SelectedItem].IsSelected = false;
                    SelectedItem= (SelectedItem-1);
                    if(SelectedItem<0)
                        SelectedItem=Items.Count-1;
                    Items[SelectedItem].IsSelected = true;
                }
                if(key.Key== ConsoleKey.Enter) {
                    
                    if (Items[SelectedItem].Title == "  M O D I F Y   U S E R") // MODIFY USER IMPLMENTATION
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Clear();
                        Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,-15} {4,-15}", "ID", "FirstName", "LastName", "DateOfBirth", "Address");
                        Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,-15} {4,-15}", student.ID, student.FirstName, student.LastName, student.DateOfBirth, student.Address);
                        Console.WriteLine();
                        Console.WriteLine("                       -E L E C T   Y O U R   O P T I O N-                     ");
                        Console.WriteLine("                       ____________________________________   ");
                        Console.WriteLine("                       |    1 -> Change the FirstName     |   ");
                        Console.WriteLine("                       |    2 -> Change the LastName      |   ");
                        Console.WriteLine("                       |    3 -> Change the DateofBirth   |   ");
                        Console.WriteLine("                       |    4 -> Change the Address       |   ");
                        Console.WriteLine("                       |__________________________________|   ");
                        Console.WriteLine();
                        Console.CursorVisible = true;
                        int choice;
                        try
                        {
                            Console.Write("E N T E R   Y O U R   C H O I C E : ");
                            choice = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            choice = 0;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("!!! -I N V A L I D   I N P U T- !!!");
                            Console.ReadKey();
                            continue;
                        }
                        switch (choice)
                        {
                                case 1:
                                    Console.Write("N E W   F I R S T   N A M E : ");
                                    student.FirstName = Console.ReadLine();                                    
                                    break;
                                case 2:
                                    Console.Write("N E W   L A S T   N A M E : ");
                                    student.LastName = Console.ReadLine();
                                    break;
                                case 3:
                                    Console.Write("N E W   D A T E   O F   B I R T H : ");
                                    student.DateOfBirth = Console.ReadLine();
                                    break;
                                case 4:
                                    Console.Write("N E W   R E S I D E N T I A L   A D D R E S S: ");
                                    student.Address = Console.ReadLine();
                                    break;
                        }
                        Console.Clear();
                        Console.WriteLine("T A K E   A   L O O K   U P O N   W H A T   Y O U   H A V E   U P D A T E D . .");
                        Console.WriteLine("{0,-5} {1,-15} {2,-15} {3,-15} {4,-15}", student.ID, student.FirstName, student.LastName, student.DateOfBirth, student.Address);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                        Console.CursorVisible = false;
                    }

                    if (Items[SelectedItem].Title == "  A D D   M O D U L E S")  // ADD MODULE IMPLEMENTATION
                    {
                        Console.ForegroundColor= ConsoleColor.DarkYellow;
                        Console.CursorVisible = true;
                        Console.Clear();

                        Console.WriteLine("                                              -M O D U L E   L I S T-                      ");
                        Console.WriteLine("_____________________________________________________________________________________________________________");
                        Console.WriteLine("MODULE ID\t|\tMODULE NAME\t\t\t|\tCREDITS");
                        Console.WriteLine("────────────────────────────────────────────────────────────────────────────────────────────────────────────");
                        Console.WriteLine("3301\t\t\tANALOG ELECTRONICS\t\t\t3");
                        Console.WriteLine("3302\t\t\tDATA STRUCTURES AND ALGORITHMS\t\t3");
                        Console.WriteLine("3151\t\t\tPROGRAMMING PROJECT\t\t\t1");
                        Console.WriteLine("3305\t\t\tSIGNALS AND SYSTEMS\t\t\t3");
                        Console.WriteLine("3308\t\t\tBASIC ECONOMICS\t\t\t\t3");
                        Console.WriteLine("3250\t\t\tGUI PROGRAMMING\t\t\t\t2");


                        Console.Write("\nEnter the Module ID\t\t\t   : ");
                        int mid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter the Grade(A+,A,A-,B+,B,B-,C+,C,C-,E) : ");
                        string grd = Console.ReadLine();

                        if (grd == "A+" || grd == "A" || grd == "A-" || grd == "B+" || grd == "B" || grd == "B-" || grd == "C+" || grd == "C" || grd == "C-" || grd == "E")
                        {
                            switch (mid)
                            {
                                case 3301:
                                    Module Modules1 = new Module(mid, "ANALOG ELECTRONICS", 3, grd);
                                    student.Modules.Add(Modules1);
                                    Modules1.MGPoint(grd);
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine(". . M O D U L E   A D D E D   S U C C E S S F U L L Y . .");
                                    Console.CursorVisible = false;
                                    Console.ReadKey();
                                    break;
                                case 3302:
                                    Module Modules2 = new Module(mid, "DATA STRUCTURES AND ALGORITHMS", 3, grd);
                                    student.Modules.Add(Modules2);
                                    Modules2.MGPoint(grd);
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine(". . M O D U L E   A D D E D   S U C C E S S F U L L Y . .");
                                    Console.CursorVisible = false;
                                    Console.ReadKey();
                                    break;
                                case 3151:
                                    Module Modules3 = new Module(mid, "PROGRAMMING PROJECT", 1, grd);
                                    student.Modules.Add(Modules3);
                                    Modules3.MGPoint(grd);
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine(". . M O D U L E   A D D E D   S U C C E S S F U L L Y . .");
                                    Console.CursorVisible = false;
                                    Console.ReadKey();
                                    break;
                                case 3305:
                                    Module Modules4 = new Module(mid, "SIGNALS AND SYSTEMS", 3, grd);
                                    student.Modules.Add(Modules4);
                                    Modules4.MGPoint(grd);
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine(". . M O D U L E   A D D E D   S U C C E S S F U L L Y . .");
                                    Console.CursorVisible = false;
                                    Console.ReadKey();
                                    break;
                                case 3308:
                                    Module Modules5 = new Module(mid, "BASIC ECONOMICS", 3, grd);
                                    student.Modules.Add(Modules5);
                                    Modules5.MGPoint(grd);
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine(". . M O D U L E   A D D E D   S U C C E S S F U L L Y . .");
                                    Console.CursorVisible = false;
                                    Console.ReadKey();
                                    break;
                                case 3250:
                                    Module Modules6 = new Module(mid, "GUI PROGRAMMING", 2, grd);
                                    student.Modules.Add(Modules6);
                                    Modules6.MGPoint(grd);
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine(". . M O D U L E   A D D E D   S U C C E S S F U L L Y . .");
                                    Console.CursorVisible = false;
                                    Console.ReadKey();
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nI N V A L I D   M O D U L E   C O D E!");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.ReadKey();
                                    break;
                            }
                            continue;

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nI N V A L I D   G R A D E");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                        }
                    }

                    if (Items[SelectedItem].Title == "R E M O V E   M O D U L E S") //REMOVE MODULE IMPLEMENTATION
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("                        -A D D E D   M O D U L E S-                      ");
                        Console.WriteLine("________________________________________________________________________");
                        Console.WriteLine("{0,-10} {1,-50} {2,-15}", "ID", "Name", "Credits");
                        foreach (Module module in student.Modules)
                        {
                            Console.WriteLine("{0,-10} {1,-50} {2,-15}", module.ID, module.Name, module.CreditValue);
                        }
                        Console.WriteLine();
                        int moduleID;
                        try
                        {
                            Console.Write("M O D U L E   I D   Y O U   W A N T   T O   D E L E T E: ");
                            moduleID = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            moduleID = 0;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("!!! -I N V A L I D   I N P U T- !!!");
                            Console.ReadKey();
                            continue;
                        }
                        bool found = false;
                        if (student.Modules.Count == null)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"M O D U L E   L I S T   OF   S T U D E N T  {student.ID}  IS   E M P T Y . .");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Press any key...");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            foreach (Module module in student.Modules)
                            {
                                if (module.ID==moduleID)
                                {
                                    Console.ForegroundColor= ConsoleColor.DarkYellow;
                                    Console.Clear();
                                    Console.WriteLine("                  -M O D U L E   D E T A I L S-                ");
                                    Console.WriteLine("  _____________________________________________________________ ");
                                    Console.WriteLine("  |                                                            | ");
                                    Console.WriteLine("        M O D U L E   I D        :" + module.ID);
                                    Console.WriteLine("        M O D U L E   N A M E    :" + module.Name);
                                    Console.WriteLine("        G R A D E                :" + module.Grade);
                                    Console.WriteLine("        C R E D I T   V A L U E  :" + module.CreditValue);
                                    Console.WriteLine("        G R A D E   P O I N T    :" + module.GradePoint);
                                    Console.WriteLine("                                                               | ");
                                    Console.WriteLine("  -------------------------------------------------------------- ");
                                    Console.WriteLine();
                                    Console.WriteLine("A R E   Y O U   S U R E   Y O U   W A N T   T O   D E L E T E ? (y/n)");
                                    char confirm;
                                    try
                                    {
                                        confirm = Convert.ToChar(Console.ReadLine());
                                    }
                                    catch (FormatException)
                                    {
                                        confirm = 'w';
                                        Console.WriteLine("!!! -I N V A L I D   I N P U T- !!!");
                                        Console.ReadLine();
                                        continue;
                                    }
                                    if (confirm == 'y' || confirm == 'Y')
                                    {
                                        student.Modules.Remove(module);
                                        Console.WriteLine(". . M O D U L E   D E L E T E D   S U C C E S S F U L L Y . .");
                                        Console.Beep();
                                        found = true;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Press any key...");
                                        Console.ReadKey();
                                    }
                                    else if(confirm == 'n' || confirm == 'N')
                                    {
                                        Console.WriteLine("M O D U L E   N O T   D E L E T E D . .");
                                        found = true;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Press any key...");
                                        Console.ReadKey();
                                        break;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine(". . Y O U R   C H O I C E   I S   W R O N G :( . .");
                                        Console.ReadLine();
                                        break;
                                    }
                                    break;
                                }
                            }
                            if (found == false)
                            {
                                Console.WriteLine("!!! -I N V A L I D   M O D U L E   I D   O R   M O D U L E   A L R E A D Y   D E L E T E D- !!!");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Press any key...");
                                Console.ReadKey();
                            }
                        }
                    }

                    if (Items[SelectedItem].Title == "  D E L E T E   U S E R") // DELETE USER IMPLEMENTATION
                    {
                        Console.Clear();
                        Console.ForegroundColor= ConsoleColor.DarkYellow;
                        Console.WriteLine("A R E   Y O U   S U R E   Y O U   W A N T   T O   D E L E T E ? (y/n) ");
                        char confirm;
                        try
                        {
                            confirm = Convert.ToChar(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            confirm = 'w';
                            Console.WriteLine("!!! -I N V A L I D   I N P U T- !!!");
                            Console.ReadLine();
                            continue;
                        }
                        if (confirm == 'y' || confirm == 'Y')
                        {
                            students.Remove(student);
                            Console.WriteLine(". . S T U D E N T   D E L E T E D   S U C C E S S F U L L Y . .");
                            Console.ReadKey();
                            go = false;

                        }
                        else if (confirm == 'n' || confirm == 'N')
                        {
                            Console.WriteLine("Y O U   S E L E C T E D   N O . .");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Press any key...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(". . Y O U R   C H O I C E   I S   W R O N G :( . .");
                            Console.ReadLine();
                        }
                    }

                    if (Items[SelectedItem].Title == "        B A C K") // GO BACK TO MAIN MENU
                    {
                        go = false;
                    }
                }
            }
        }
    }
}
