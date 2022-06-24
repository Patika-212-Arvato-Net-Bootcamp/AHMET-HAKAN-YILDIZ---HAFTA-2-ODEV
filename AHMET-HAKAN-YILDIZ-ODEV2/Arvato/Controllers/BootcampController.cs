using Arvato.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Arvato.Migration;

namespace Arvato.Controllers
{
    [Route("arvato/[controller]")]
    [ApiController]
    public class BootcampController : ControllerBase
    {

        #region List Bootcamps
        [HttpGet]
        public List<Bootcamp> GetBootcamps() // Kayıtlı bütün bootcamleri getirir.
        {
            var b = BootcampsDbContext.Bootcamps.OrderBy(x => x.Id).ToList<Bootcamp>();
            return b;
        }
        #endregion

        #region List Bootcamps By Id
        [HttpGet("{id}")]
        public IActionResult GetBootCampById(int id)  //Id'sine göre bootcamp getirir.
        {
            var b = BootcampsDbContext.Bootcamps.Where(x => x.Id == id).SingleOrDefault();
            if (b == null) //Id'ye ait bootcamp yoksa notfound(404) döndürür.
            {
                return NotFound();
            }
            else
            {
                return Ok(b);
            }
        }
        #endregion

        #region Add User
        [HttpPost]
        public IActionResult AddUser([FromBody] User newUser)
        {
            var user = UsersDbContext.Users.SingleOrDefault(x => x.TCNU == newUser.TCNU);
            if (user != null) //Katılımcının girdiği tc kimlik numarası listedeki diğer katılımcılardan herhangi birinin tc kimlik numarası ile uyuşuyorsa badreques(daha önce başvuru yapıldı) döndürür..
            {
                return BadRequest("Daha önce başvuru yapıldı.");
            }
            else
            {
                UsersDbContext.Users.Add(newUser);
                return Ok("Başvuru oluşturuldu.");
            }
        }
        #endregion

        #region View active and passive bootcamp
        [HttpPost("{actpass}")]
        public List<Bootcamp> GetActorPassBootcamps(bool actpass) //Seçime göre aktif ya da pasif bootcampleri görüntüler.
        {
            if (actpass == true)
            {
                var b = BootcampsDbContext.Bootcamps.Where(x => x.ActPass == true).ToList<Bootcamp>();
                return b;
            }
            else
            {
                var b = BootcampsDbContext.Bootcamps.Where(x => x.ActPass == false).ToList<Bootcamp>();
                return b;
            }
        } 
        #endregion

    }
}
