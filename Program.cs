// Pluto Zitek - Lab 9, "Listen and Learn"

int activeItem = 0;

List<(string, DateTime, string, ItemStatus)> IncompleteItems = new List<(string, DateTime, string, ItemStatus)>();
List<(string, DateTime, DateTime, string, ItemStatus)> CompleteItems = new List<(string, DateTime, DateTime, string, ItemStatus)>();

string[] mainMenuOptions = new string[] {

	"Create new item", "View list of items", "Exit program"
};

void mainMenu() {

	bool menuBool = true;

	while(menuBool) {

		Console.Clear();
		Snippet.LineBreak();
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
		Console.WriteLine(keyInput);

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

				switch(mainMenuOptions[activeItem]) {				
					
					case mainMenuOptions[0]: 
						var newItem = createNewItem();
						Console.WriteLine(newItem);

						break;

					case mainMenuOptions[1]:
						

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

	
}



// DateTime now = DateTime.Now;
// var tempTuple = Item.Incomplete("Lorem ipsum", now, "An interesting description.");
// Console.WriteLine(tempTuple);

// --------------------------------------------------------

public enum ItemStatus {

	Incomplete,
	Complete,
}