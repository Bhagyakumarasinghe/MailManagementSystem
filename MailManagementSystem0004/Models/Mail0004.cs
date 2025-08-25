
namespace MailManagementSystem0004.Models
{
    public class Mail0004
    {
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int SenderDepartmentId { get; set; }
        public int RecipientDepartmentId { get; set; }
        public MailStatus0004 Status { get; set; }

        
        public Department0004? SenderDepartment { get; set; }
        public Department0004? RecipientDepartment { get; set; }
    }
}