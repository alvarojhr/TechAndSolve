using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechAndSolve_AlvaroHernandez.Models;

namespace TechAndSolve_AlvaroHernandez.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly FileContext _context;

        public FileUploadController(FileContext context)
        {
            _context = context;
        }

        // GET: /FileUpload
        [HttpGet]
        public ActionResult<IEnumerable<FileUpload>> GetFileUploads()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes("lazy_loading_example_output.txt");

            return File(fileBytes, "text/plain", "lazy_loading_example_output.txt");
        }

        // POST: /FileUpload
        [HttpPost]
        public async Task<ActionResult<FileUpload>> PostFileUpload([FromForm] FileUpload fileUpload)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileUpload.File.OpenReadStream()))
                {

                    fileUpload.ProcessFile(reader);

                    _context.FileUploads.Add(fileUpload);
                    await _context.SaveChangesAsync();

                }
                return StatusCode(201);
            }
            catch (Exception)
            {
                return StatusCode(500);
                throw;
            }
        }

    }
}
