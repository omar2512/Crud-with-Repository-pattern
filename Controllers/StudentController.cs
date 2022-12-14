using itilabcrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace itilabcrud.Controllers
{
    public class StudentController : Controller
    {
        IStudent db;
        //public StdActions db = new StdActions();

        public StudentController(IStudent _db)
        {
            this.db = _db;        
        }
        [HttpGet]
        public IActionResult DisplayData()
        {
            
            return View(db.GetAllData());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student std,IFormFile img)
        {
             std.Id = db.GetNextID();
            if(img != null)
            {
                string imgname = std.Id.ToString()+"."+img.FileName.Split(".")[1];
                using (var obj = new FileStream(@".\wwwroot\images\" + imgname, FileMode.Create))
                {
                    img.CopyTo(obj);
                }
                std.Stgimg = imgname;
            }
            db.Insert(std);    
            return RedirectToAction("DisplayData");
        }

        public IActionResult Preview(int? id)
        {
            if (id == null)
                return BadRequest();
            Student std =db.GetById(id.Value);
            if(std == null)
                return NotFound();
            return View(std);

        }
        [HttpGet]
        public IActionResult Edite(int?id)
        {

            if (id == null)
                return BadRequest();
            Student std = db.GetById(id.Value);
            if (std == null)
                return NotFound();
            return View(std);
        }
        [HttpPost]
        public IActionResult Edite(Student std )
        {
            db.Edit(std);   
            return RedirectToAction("DisplayData");
        }


        
        public IActionResult Deletes(int? id)
        {
            if (id == null)
                return BadRequest();
            Student std = db.GetById(id.Value);
            if (std != null)
                return NotFound();
            db.Delete(id.Value);
            return RedirectToAction("DisplayData");
        }

        public IActionResult Download(int? id)
        {
            if (id == null)
                return BadRequest();
            Student std = db.GetById(id.Value);
            if(id == null)
                return NotFound();
            return File("images/" + std.Stgimg, "image/jpj", "std.jpg");
        }
        [HttpGet]
        public IActionResult ChangeImg(int? id)
        {
            if (id == null)
                return BadRequest();
            Student std =db.GetById(id.Value);
            if (std == null)
                return NotFound();
            return View(std);
        }
        [HttpPost]
        public IActionResult ChangeImg(int ?id,IFormFile imgsrc)
        {
            Student std = db.GetById(id.Value);
            if (imgsrc != null)
            {
                string imgname = std.Id.ToString()+"." +imgsrc.FileName.Split(".")[1];
                using (var obj = new FileStream(@".\wwwroot\images\" + imgname, FileMode.Create))
                {
                    imgsrc.CopyTo(obj);
                }
                std.Stgimg = imgname;
            }
            
            return RedirectToAction("DisplayData");
        }
    }
}
