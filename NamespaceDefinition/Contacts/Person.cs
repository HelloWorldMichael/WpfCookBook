﻿namespace NamespaceDefinition.Contacts
{
	public class Person : ObservableObject
	{
		public string Name { get; set; }
		private int _age;
		public int Age
		{
			get
			{ return _age; }
			set
			{
				_age = value;
				OnPropertyChanged("Age");
			}
		}

		public override string ToString()
		{
			return string.Format("{0} is {1} years old.", Name, Age);
		}
	}
}
