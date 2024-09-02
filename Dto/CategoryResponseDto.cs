namespace LibraryManagementSystemBackend.Dto
{
    public class CategoryResponseDto
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CratedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}