namespace ABC_Retail_ST10255912_POE.Models
{
    public class FileRecord
    {
        public int FileRecordId { get; set; }
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public DateTime UploadDate { get; set; }
        public string? UploadedBy { get; set; }
    }

}
