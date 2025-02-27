using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eval_11_mars.Entities;

public partial class Musique
{
    public string? Artiste { get; set; }

    public string? Chanson { get; set; }

    public int? DateDeSortie { get; set; }

    public string? Langue { get; set; }

    public string? IdArtiste { get; set; }
}
public class MusiqueDTO
{
    [Required]
    public string? Artiste { get; set; }

    [Required]
    public string? Chanson { get; set; }

    [Required]
    public int? DateDeSortie { get; set; }

    [Required]
    public string? Langue { get; set; }

    [Required]
    public string? IdArtiste { get; set; }
}
