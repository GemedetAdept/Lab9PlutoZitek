using Microsoft.VisualBasic;
using System.Text;

// Pluto Zitek - Lab 9, "Listen and Learn"

int activeItem = 0;

List<(string, DateTime, string, ItemStatus)> incompleteItems = new List<(string, DateTime, string, ItemStatus)>();
List<(string, DateTime, DateTime, string, ItemStatus)> completeItems = new List<(string, DateTime, DateTime, string, ItemStatus)>();

string[] mainMenuOptions = new string[] {

	"Create new item", "View list of items", "Exit program"
};

void mainMenu() {

	bool menuBool = true;

	while(menuBool) {

		Console.Clear();
		Console.WriteLine("--- To-Do || !To-Do ---");

		for (int i = 0; i < mainMenuOptions.Length; i++) {

			string selector = "";

			if (activeItem == i) {
				selector = "> ";
			}

			Console.WriteLine($"{selector}[{i+1}] - {mainMenuOptions[i]}");
		}

		// Provides option selection via arrow keys and Enter for a more satisfying feel
		var keyInput = Console.ReadKey(true).Key;

		switch(keyInput) {

			case ConsoleKey.DownArrow:
				if (activeItem < mainMenuOptions.Length-1) {
					activeItem += 1;
				}
				break;

			case ConsoleKey.UpArrow:
				if (activeItem > 0) {
					activeItem -= 1;
				}
				break;

			case ConsoleKey.Enter:

				switch(activeItem) {				
					
					case 0:
						var newItem = createNewItem();
						incompleteItems.Add(newItem);
						break;

					case 1:
						displayItems();
						break;

					case 2:
						Environment.Exit(0);
						break;

					default:
						break;
				}

				break;

			default:
				break;
		}

	}
}

mainMenu();

(string, DateTime, string, ItemStatus) createNewItem() {

	string name = "";
	DateTime currentTime = DateTime.Now;
	string description = "";

	Console.Clear();
	Console.WriteLine("--- Create a New To-Do Item ---");
	Snippet.LineBreak();

	Console.WriteLine("Enter a name for the To-Do item:");
	Console.Write("> ");
	name = Console.ReadLine();

	Snippet.LineBreak();

	Console.WriteLine("Enter a description for the To-Do item:");
	Console.Write("> ");
	description = Console.ReadLine();

	(string, DateTime, string, ItemStatus) newItem = Item.Incomplete(name, currentTime, description, ItemStatus.Incomplete);

	bool confirmBool = true;
	while(confirmBool) {

		Console.Clear();
		Console.WriteLine("Confirm inputted item details?");
		Snippet.LineBreak();

		// Console.WriteLine(newItem);
		// Snippet.LineBreak();

		string[] confirmOptions = new string[] {

			"Yes", "No",
		};

		for (int i = 0; i < confirmOptions.Length; i++) {

			string selector = "";

			if (activeItem == i) {
				selector = "> ";
			}

			Console.WriteLine($"{selector}[{i+1}] - {confirmOptions[i]}");
		}

		var keyInput = Console.ReadKey(true).Key;

		switch(keyInput) {

			case ConsoleKey.DownArrow:
				if (activeItem < confirmOptions.Length-1) {
					activeItem += 1;
				}
				break;

			case ConsoleKey.UpArrow:
				if (activeItem > 0) {
					activeItem -= 1;
				}
				break;

			case ConsoleKey.Enter:
				if (confirmOptions[activeItem] == confirmOptions[0]) {

					// Add method once one is made for viewing the list
					return newItem;
					break;
				}

				else if (confirmOptions[activeItem] == confirmOptions[1]) {

					Console.WriteLine("Redirecting to item creation...");
					confirmBool = false;
					createNewItem();
				}

				break;

			default:
				break;
		}
	}

	return newItem;

}


void displayItems() {

	Console.Clear();

	Console.OutputEncoding = Encoding.Unicode;

	// Section header
	string headerText = "  Current To-Do Items  ";
	int headerCenter = (Console.WindowWidth - headerText.Length)/2;
	string displayHeader = new string(' ', headerCenter);

	Console.WriteLine(displayHeader + headerText);
	Console.WriteLine(displayHeader + new string(Strings.ChrW(Strings.AscW('▔')), headerText.Length));
	Snippet.LineBreak();

	// Incomplete Items
	string headerIncomplete = "[ Incomplete Items ] :";
	Console.WriteLine(headerIncomplete);
	Console.WriteLine(new string(Strings.ChrW(Strings.AscW('▔')), headerIncomplete.Length));

	for (int i = 0; i < incompleteItems.Count(); i++) {

		Console.WriteLine($"[{(i+1):00}] {incompleteItems[i]}");
	}

	Snippet.LineBreak();

	// Complete Items
	string headerComplete = "[ Complete Items ] :";
	Console.WriteLine(headerComplete);
	Console.WriteLine(new string(Strings.ChrW(Strings.AscW('▔')), headerComplete.Length));

	for (int i = 0; i < completeItems.Count(); i++) {

		Console.WriteLine(completeItems[i]);
	}

	Snippet.LineBreak();

	// -------------------------------------------------------------------------------

	Console.WriteLine(@"Type item number to mark as complete OR Press [Enter] to return to menu");

	Console.Write("> ");
	var userInput = Console.ReadLine();

	int choiceIndex = 0;
	bool intCheck = int.TryParse(userInput, out choiceIndex);
	if (intCheck) {

		if (choiceIndex > incompleteItems.Count()) {

			Console.WriteLine($"Item [{userInput:00}] does not exist.");
			Console.Write("Press any key to continue...");

			Console.ReadKey();
			displayItems();
		}

		else {

			choiceIndex -= 1;

			DateTime done = DateTime.Now;
			var itemData = incompleteItems[choiceIndex];
			completeItems.Add(Item.Complete(itemData.Item1, itemData.Item2, done, itemData.Item3, ItemStatus.Complete));
			incompleteItems.Remove(itemData);
		}

	}

	mainMenu();

}



// DateTime now = DateTime.Now;
// var tempTuple = Item.Incomplete("Lorem ipsum", now, "An interesting description.");
// Console.WriteLine(tempTuple);

// --------------------------------------------------------

public enum ItemStatus {

	Incomplete,
	Complete,
}