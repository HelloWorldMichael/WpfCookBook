namespace NamespaceDefinition.Contacts
{
	public class CompanyContact
	{
		public string Name { get; set; }
		public string PhoneNumber { get; set; }
		public int Age { get; set; }

		public override string ToString()
		{
			return string.Format("Name: {0}\nPhone Number: {1}\nAge: {2}", Name, PhoneNumber, Age);
		}
	}
}
