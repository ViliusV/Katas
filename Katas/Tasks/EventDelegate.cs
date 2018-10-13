using System;
using System.Collections.Generic;

public class PersonEventArgs : EventArgs
{
	public string Name { get; set; }
}

public class Publisher
{
	public delegate void ContactNotifyEnvetHandler(object source, PersonEventArgs args);

	public event ContactNotifyEnvetHandler ContactNotify;

	protected virtual void OnContactNotify(string person)
	{
		ContactNotify?.Invoke(this, new PersonEventArgs() { Name = person });
	}

	public void CountMessages(List<string> peopleList)
	{
		Dictionary<string, int> ContactList = new Dictionary<string, int>();
		foreach (string person in peopleList)
		{
			if (ContactList.ContainsKey(person))
			{
				ContactList[person] = ContactList[person] + 1;
				if (ContactList[person] == 3)
				{
					OnContactNotify(person);
					ContactList[person] = 0;
				}
			}
			else
			{
				ContactList[person] = 1;
			}
		}
	}
}