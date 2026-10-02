namespace KweziHealthESOP.Models
{
    public class StaffMember
    {
        public int StaffId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;

        public string Unit { get; set; } = string.Empty;
    }
}