namespace DataAccess.DTO
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool? IsVerify { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ProgressId { get; set; }
        public bool? Status { get; set; }
        public string ProfilePicture { get; set; }
        public int RoleId { get; set; }
    }
}
