using Application.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        public List<App> app = new List<App>
        {
           new App{Id=123,Name="vishnu"},
            new App{Id=456,Name="ramesh"},
            new App{Id=789,Name="harish"},
            new App{Id=113,Name="harith"},
            new App{Id=143,Name="satish"},
        };


        [HttpGet]

        public IEnumerable<App> get()
        {
            return app;
        }

        [HttpGet("id")]
        public ActionResult<App> GetID(int id)
        {
            if(id==0)
            {
                return BadRequest();
            }
            var val = app.FirstOrDefault(x => x.Id == id);
            if(val==null)
            {
                return NotFound();
            }
            return val;
        }

        [HttpGet("name")]
        public ActionResult<App> GetByName(string name)
        {
            var val = app.FirstOrDefault(x => x.Name == name);
            if(val==null)
            {
                return NotFound();
            }
            return val;
        }
        [HttpPost]
        
        public IEnumerable<App> PostID(App obj)
        {
            app.Add(obj);
            return app;
            
        }
        [HttpDelete("id")]
        public ActionResult<IEnumerable<App>> Deleteby(int id)
        {
            var val = app.FirstOrDefault(u => u.Id == id);
            if(id==0)
            {
                return BadRequest();
            }
            if(val==null)
            {
                return NotFound();
            }
            app.Remove(val);
            return app;
        }
        [HttpPut("id")]
        
        public ActionResult<IEnumerable<App>> Update(int id,string name)
        {
            var val = app.FirstOrDefault(u => u.Id == id);
            if(val==null)
            {
                return NotFound();
                
            }

            val.Name=name;
            return app;
        }
    }
}
