using KweziHealthESOP.Models;

namespace KweziHealthESOP.Services
{
    public class StaffService
    {
        private readonly List<StaffMember> _staffMembers =
            new List<StaffMember>();

        // Add a staff member
        public void AddStaffMember(StaffMember staffMember)
        {
            _staffMembers.Add(staffMember);
        }

        // Retrieve all staff members
        public List<StaffMember> GetAllStaffMembers()
        {
            return _staffMembers;
        }

        // Retrieve a staff member by ID
        public StaffMember? GetStaffMemberById(int staffId)
        {
            return _staffMembers.Find(
                staff => staff.StaffId == staffId);
        }

        // Update a staff member
        public bool UpdateStaffMember(
            int staffId,
            StaffMember updatedStaff)
        {
            var existingStaff = GetStaffMemberById(staffId);

            if (existingStaff == null)
            {
                return false;
            }

            existingStaff.FullName = updatedStaff.FullName;
            existingStaff.Email = updatedStaff.Email;
            existingStaff.Position = updatedStaff.Position;
            existingStaff.Unit = updatedStaff.Unit;

            return true;
        }

        // Delete a staff member
        public bool DeleteStaffMember(int staffId)
        {
            var staffMember = GetStaffMemberById(staffId);

            if (staffMember == null)
            {
                return false;
            }

            _staffMembers.Remove(staffMember);

            return true;
        }
    }
}