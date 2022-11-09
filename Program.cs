// Pluto Zitek - Lab 9, "Listen and Learn"

string[] mainMenuOptions = new string[] {

	"Create new item", "View list of items", "Exit program"
};

void mainMenu() {

	bool menuBool = true;
	int activeItem = 0;

	while(menuBool) {

		Console.Clear();
		Snippet.LineBreak();
		Console.WriteLine("--- To-do || !To-do ---");

		for (int i = 0; i < mainMenuOptions.Length; i++) {

			string selector = "";

			if (activeItem == i) {
				selector = "> ";
			}

			Console.WriteLine($"{selector}[{i+1}] - {mainMenuOptions[i]}");
		}

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

			default:
				break;
		}

	}
}

mainMenu();

// DateTime now = DateTime.Now;
// var tempTuple = Item.Incomplete("Lorem ipsum", now, "An interesting description.");
// Console.WriteLine(tempTuple);

// --------------------------------------------------------

public enum ItemStatus {

	Incomplete,
	Complete,
}