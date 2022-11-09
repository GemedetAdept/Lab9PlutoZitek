// Pluto Zitek - Lab 9, "Listen and Learn"

DateTime now = DateTime.Now;
var tempTuple = Item.Incomplete("Lorem ipsum", now, "An interesting description.");
Console.WriteLine(tempTuple);

// --------------------------------------------------------

public enum ItemStatus {

	Incomplete,
	Complete,
}