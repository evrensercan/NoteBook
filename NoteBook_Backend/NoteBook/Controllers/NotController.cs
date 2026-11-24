using Microsoft.AspNetCore.Mvc;
using NoteBook.Models;
using NoteBook.Services;

namespace NoteBook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotController : ControllerBase
    {
        private readonly NotServis _servis;

        public NotController(NotServis servis)
        {
            _servis = servis;
        }

        // CREATE -POST- EKleme
        [HttpPost]
        public IActionResult Create([FromBody] Notes not)
        {
            _servis.Create(not);

            return Ok(new { Message = "Not başarıyla veritabanına eklendi!" });
        }


        // READ -GET- Listeleme
        [HttpGet]
        public IActionResult GetAll()
        {
            var notlar = _servis.Listele();

            return Ok(notlar);
        }


        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _servis.Sil(id);
            return Ok(new { Message = id + " numaralı not silindi." });
        }


        //UPDATE-PUT
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Notes not)
        {
            // Güvenlik: Dışarıdan gelen ID ile modelin içindeki ID aynı olsun
            not.Id = id;

            _servis.Guncelle(not);
            return Ok(new { Message = id + " numaralı not güncellendi!" });
        }

    }
}
