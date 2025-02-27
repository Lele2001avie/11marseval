using Eval_11_mars.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Eval_11_mars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiqueDatacontrol : ControllerBase
    {
        private readonly MusiqueDataContext MusiqueDataContext;
        public MusiqueDatacontrol(MusiqueDataContext MusiqueDataContext)
        {
            this.MusiqueDataContext = MusiqueDataContext;
        }

        [HttpGet("GetMusique")]
        public async Task<ActionResult<List<MusiqueDTO>>> Get()
        {
            var ListMusique = await MusiqueDataContext.Musiques
                .Select(m => new MusiqueDTO
                {
                    Artiste = m.Artiste,
                    Chanson = m.Chanson,
                    DateDeSortie = m.DateDeSortie,
                    IdArtiste = m.IdArtiste,
                    Langue = m.Langue
                }).ToListAsync();

            if (ListMusique.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return ListMusique;
            }
        }
        [HttpGet("GetArtisteinfo")]

        public async Task<ActionResult<List<Artisteinfo>>> GetArtisteinfo()
        {
            var ListArtisteinfo = await MusiqueDataContext.Artisteinfos.ToListAsync();
            if (ListArtisteinfo.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return ListArtisteinfo;
            }
        }
        [HttpGet("GetMusiquebyid")]
        public async Task<ActionResult<MusiqueDTO>> GetMusiquebyid(string idArtiste)
        {
            var musique = await MusiqueDataContext.Musiques
                .Select(m => new MusiqueDTO
                {
                    Artiste = m.Artiste,
                    Chanson = m.Chanson,
                    DateDeSortie = m.DateDeSortie,
                    IdArtiste = m.IdArtiste,
                    Langue = m.Langue
                }).FirstOrDefaultAsync(m => m.IdArtiste == idArtiste);

            if (musique == null)
            {
                return NotFound();
            }
            else
            {
                return musique;
            }
        }
        [HttpGet("GetArtisteinfobyid")]
        public async Task<ActionResult<Artisteinfo>> GetArtisteinfobyid(string idArtiste)
        {
            var artisteinfo = await MusiqueDataContext.Artisteinfos
                .FirstOrDefaultAsync(a => a.IdArtiste == idArtiste);

            if (artisteinfo == null)
            {
                return NotFound();
            }
            else
            {
                return artisteinfo;
            }
        }
        [HttpPost("InsertMusique")]
        public async Task<HttpStatusCode> InsertUser(MusiqueDTO Musique)
        {
            var entity = new Musique()
            {
                Artiste = Musique.Artiste,
                Chanson = Musique.Chanson,
                DateDeSortie = Musique.DateDeSortie,
                IdArtiste = Musique.IdArtiste,
                Langue = Musique.Langue
            };
            MusiqueDataContext.Musiques.Add(entity);
            await MusiqueDataContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
    

    [HttpPost("InsertArtisteinfo")]
        public async Task<HttpStatusCode> InsertArtisteinfo(ArtisteinfoDTO artisteinfo)
        {
            var entity = new Artisteinfo()
            {
                IdArtiste = artisteinfo.IdArtiste,
                Nom = artisteinfo.Nom,
                Nationalite = artisteinfo.Nationalite,
                AnneeNaissance = artisteinfo.AnneeNaissance
            };
            MusiqueDataContext.Artisteinfos.Add(entity);
            await MusiqueDataContext.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpPut("UpdateMusique")]
        public async Task<HttpStatusCode> UpdateMusique(MusiqueDTO Musique)
        {
            var entity = await MusiqueDataContext.Musiques.FirstOrDefaultAsync(m => m.IdArtiste == Musique.IdArtiste);
            entity.Artiste = Musique.Artiste;
            entity.Chanson = Musique.Chanson;
            entity.DateDeSortie = Musique.DateDeSortie;
            entity.Langue = Musique.Langue;
            MusiqueDataContext.Musiques.Update(entity);
            await MusiqueDataContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }


        [HttpPut("UpdateArtisteinfo")]
        public async Task<HttpStatusCode> UpdateArtisteinfo(ArtisteinfoDTO artisteinfo)
        {
            var entity = await MusiqueDataContext.Artisteinfos.FirstOrDefaultAsync(a => a.IdArtiste == artisteinfo.IdArtiste);
            entity.Nom = artisteinfo.Nom;
            entity.Nationalite = artisteinfo.Nationalite;
            entity.AnneeNaissance = artisteinfo.AnneeNaissance;
            entity.IdArtiste = artisteinfo.IdArtiste;
            await MusiqueDataContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        [HttpDelete("DeleteMusique/{IdArtiste}")]
        public async Task<HttpStatusCode> DeleteMusique(string IdArtiste)
        {
            var entity = new Musique()
            {
                IdArtiste = IdArtiste
            };
            MusiqueDataContext.Musiques.Attach(entity);
            MusiqueDataContext.Musiques.Remove(entity);
            await MusiqueDataContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
        [HttpDelete("DeleteArtisteinfo/{IdArtiste}")]
        public async Task<HttpStatusCode> DeleteArtisteinfo(string IdArtiste)
        {
            var entity = new Artisteinfo()
            {
                IdArtiste = IdArtiste
            };
            MusiqueDataContext.Artisteinfos.Attach(entity);
            MusiqueDataContext.Artisteinfos.Remove(entity);
            await MusiqueDataContext.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }

}

