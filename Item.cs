public class Item {

	public string name;
	public DateTime start;
	public DateTime end;
	public string description;
	public ItemStatus status;

	public (string, DateTime, string, ItemStatus) Incomplete(string itemName, DateTime startTime, string itemDescription) {

		name = itemName;
		start = startTime;
		description = description;

		status = ItemStatus.Incomplete;

		(string, DateTime, string, ItemStatus) dataIncomplete = (name, start, description, status);
		return dataIncomplete;
	}

	public (string, DateTime, DateTime, string, ItemStatus) Complete(string itemName, DateTime startTime, DateTime endTime, string itemDescription) {


		name = itemName;
		start = startTime;
		end = endTime
		description = description;

		status = ItemStatus.Complete;

		(string, DateTime, DateTime, string, ItemStatus) dataComplete = (name, start, end, description, status);
		return dataComplete;
	}
}