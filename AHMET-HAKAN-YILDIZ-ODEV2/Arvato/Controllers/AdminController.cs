using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Arvato.Migration;
using Arvato.Model;

namespace Arvato.Controllers
{
    [Route("arvato/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        #region List All Users
        [HttpGet]
        public List<User> GetUserByBootcampId() // Bütün katılımcıları listeler.
        {
            var u = UsersDbContext.Users.OrderBy(x => x.Id).ToList<User>();
            return u;
        }
        #endregion

        #region Add Bootcamp
        [HttpPost]
        public IActionResult AddBootcamp(Bootcamp newBootcamp) //Yeni Bootcamp kaydeder.
        {
            var bc = BootcampsDbContext.Bootcamps.SingleOrDefault(x => x.Id == newBootcamp.Id);
            if (bc != null) //Veritabanıyla yapmadığım için auto increment özelliği yok.Kaydedilecek bootcamp'in id'si listedeki başka bir bootcampin id'si ile çakışırsa badrequest döndürür.
            {
                return BadRequest("Bu id'ye kayıtlı bir bootcamp var.");
            }
            else
            {
                BootcampsDbContext.Bootcamps.Add(newBootcamp);
                return Ok();
            }
        }
        #endregion

        #region Remove Bootcamp
        [HttpDelete]

        public IActionResult DeleteBootcamp(int id) //ID'ye göre Bootcamp siler.
        {
            var u = BootcampsDbContext.Bootcamps.SingleOrDefault(x => x.Id == id);

            if (u == null) //Girilen id'ye karşılık bootcamp bulunamadıysa badrequest(400) response döndürür.
            {
                return BadRequest("Bulunamadı");
            }
            else
            {
                return Ok(BootcampsDbContext.Bootcamps.Remove(u));
            }
        }
        #endregion

        #region User Confirm
        [HttpPut("{id}")]
        public IActionResult VerifyUser(int id, bool verify) //Katılımcıyı onaylamak için user tablosunda tanımladığım bool türünde IsVerified değişkenini günceller.
        {
            var verifyeduser = UsersDbContext.Users.FirstOrDefault(x => x.Id == id);


            if (verifyeduser == null) //Girilen id'ye karşılık user bulunamadıysa badrequest(400) response döndürür.
            {
                return BadRequest("Onaylamaya çalıştığınız kullanıcı bulunamadı.");
            }
            else
            {
                verifyeduser.IsVerified = verify; // Katılımcıyı onayla ya da onaylama.(true or false)
                return Ok();
            }
        }
        #endregion

        #region Remove User
        [HttpDelete("{id}")]

        public IActionResult DeleteUser(int id) //Katılımcı siler.
        {
            var deleteduser = UsersDbContext.Users.FirstOrDefault(x => x.Id == id);

            if (deleteduser == null) //Girilen id'ye karşılık user bulunamadıysa badrequest(400) response döndürür.
            {
                return BadRequest("Böyle bir kullanıcı bulunamadı.");
            }
            else
            {
                return Ok(UsersDbContext.Users.Remove(deleteduser));
            }
        }
        #endregion

        #region List Users By BootcampId
        [HttpGet("{bootcampid}")]
        public List<User> GetUserByBootcampId(int bootcampid) // Id'si girilen bootcamp'e ait katılımcıları listeler.
        {
            var u = UsersDbContext.Users.Where(x => x.BootcampId == bootcampid).ToList<User>();
            return u;
        }

        #endregion
    }
}
