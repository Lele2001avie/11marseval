using System;
using System.Collections.Generic;

namespace Eval_11_mars.Entities;

public partial class Artisteinfo
{
    public string? IdArtiste { get; set; }

    public string? Nom { get; set; }

    public string? Nationalite { get; set; }

    public int? AnneeNaissance { get; set; }
}
public  class ArtisteinfoDTO
{
    public string? IdArtiste { get; set; }
    public string? Nom { get; set; }
    public string? Nationalite { get; set; }
    public int? AnneeNaissance { get; set; }
}
