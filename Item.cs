public class Item {

	public static (string, DateTime, string, ItemStatus) Incomplete(string itemName, DateTime startTime, string itemDescription) {

		string name = itemName;
		DateTime start = startTime;
		string description = itemDescription;

		ItemStatus status = ItemStatus.Incomplete;

		(string, DateTime, string, ItemStatus) dataIncomplete = (name, start, description, status);
		return dataIncomplete;
	}

	public static (string, DateTime, DateTime, string, ItemStatus) Complete(string itemName, DateTime startTime, DateTime endTime, string itemDescription) {


		string name = itemName;
		DateTime start = startTime;
		DateTime end = endTime;
		string description = itemDescription;

		ItemStatus status = ItemStatus.Complete;

		(string, DateTime, DateTime, string, ItemStatus) dataComplete = (name, start, end, description, status);
		return dataComplete;
	}
}