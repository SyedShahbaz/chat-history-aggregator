using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerDiaryDataAggregator.Entities;

public class ChatHistory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? PersonName { get; init; }
    public int EventType { get; init; }
    public DateTime TimeStamp { get; init; }
    public string? AffectedByEvent { get; init; }
    public string? EventDetails { get; init; }
}