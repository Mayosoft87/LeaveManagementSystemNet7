namespace LeaveManagementSystem.Web.Data
{
	//Partial Meand that you can not use this Class on its own you have to extended a class using this class
	public abstract class BaseEntity
	{
		public int Id { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }
	}
}
